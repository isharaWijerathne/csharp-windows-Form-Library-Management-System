using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibSys.AppForms.MemberForm
{
    public partial class frmNewMember : Form
    {
        public frmNewMember()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        //clear Form Data
        public void ClearForm() {
            //Clear personal details
            txtFirstName.Text = "";
            txtLastName.Text = "";
            dtpDateOfBirth.Text = "";
            txtNic.Text = "";
            cmdAccountType.Text = "";

            //clear contact information
            txtResident.Text = "";
            txtStreetName.Text = "";
            txtCity.Text = "";
            txtEmail.Text = "";
            txtContactNum.Text = "";

        }

        //genarate next member_id
        public string nextMemberID() {

            string lastUsedIDQuery = " SELECT TOP 1 member_id FROM tblMember ORDER BY member_id DESC;";
            SqlCommand cmd = new SqlCommand(lastUsedIDQuery,MainWindow.con);

            MainWindow.con.Open();
            SqlDataReader r = cmd.ExecuteReader();

            string lastUsedID = null;

            if (r.Read())
            {
                lastUsedID = r[0].ToString();
            }

            r.Close();
            MainWindow.con.Close();
            string newID = null;


            if (lastUsedID == null)
            {
                newID = "MB-00001";
            }
            else
            {
                int newUsedInt = Convert.ToInt32(lastUsedID.Substring(3)) +1;
                newID = $"MB-{newUsedInt.ToString().PadLeft(5,'0')}";
            }
            return newID;
        }

        //subscription Id
        public string NextSubID()
        {

            string lastUsedIDQuery = " SELECT TOP 1 subscripion_id FROM tblAnnualSubscription ORDER BY subscripion_id DESC;";
            SqlCommand cmd = new SqlCommand(lastUsedIDQuery, MainWindow.con);

            MainWindow.con.Open();
            SqlDataReader r = cmd.ExecuteReader();

            string lastUsedID = null;

            if (r.Read())
            {
                lastUsedID = r[0].ToString();
            }

            r.Close();
            MainWindow.con.Close();
            string newID = null;


            if (lastUsedID == null)
            {
                newID = "SB-000001";
            }
            else
            {
                int newUsedInt = Convert.ToInt32(lastUsedID.Substring(3)) + 1;
                newID = $"SB-{newUsedInt.ToString().PadLeft(6, '0')}";
            }
            return newID;
        }
        //freeSubscription for next 30 Days
        public string freeSubEndDay = DateTime.Today.AddDays(30).ToString("yyyy-dd-MM");

        //printBillSample
        public void PrintBill(string memberID,string fName ,string lName ,string memberShipType,string anualPay, string availableBook ,string returnDay , string fine , string addmissionFee ,string cashier ) {
            string printBill = $@"-------------------------------------------------------
LIBRARY SYSTEM
NEW MEMBER REGISTRATION
PAYMRY BILL
-------------------------------------------------------

MEMBER ID - {memberID}
MEMBER NAME - {fName} {lName}
MEMBERSHIP TYPE - {memberShipType}
ANNUAL MONTH PAY - {anualPay}
AVAILABLE BOOK - {availableBook}
BOOK RETURN DAY - {returnDay}
FINE FOR DAY - {fine}

*****ONE MONTH FREE SUBSCRIPTION*****
FREE SUBSCRIPTION EXPIRE DATE - {freeSubEndDay}

ADMISSTION FEES - {addmissionFee}
CASHIER - {cashier}
DATE - {DateTime.Now.ToString()}
.......................................................
READING MAKETH A FULL MAN
.......................................................";

            txtMemberShipLetter.Text = printBill;
        }

        private void btnNICGenarate_Click(object sender, EventArgs e)
        {
            //Fake Nic A-A-A-A-X-X-B-B-Y-C-C-V
            //A-year B-Month C-Date V-Government Const
            //genarate x and y
            Random rnd = new Random();
            int x = rnd.Next(10,99);
            int y = rnd.Next(1, 9);
            //get Year,month,Date
            string memberBithYear = dtpDateOfBirth.Value.Year.ToString().PadLeft(2, '0');
            string memberBirthMonth = dtpDateOfBirth.Value.Month.ToString().PadLeft(2, '0');
            string memberBirthDay = dtpDateOfBirth.Value.Day.ToString().PadLeft(2, '0');
            //fake Id String
            string fakeINC = $"{memberBithYear}{x}{memberBirthMonth}{y}{memberBirthDay}V";
            //set to NIC textBox
            txtNic.Text = fakeINC;
            



            
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text == "" || txtLastName.Text == "" || txtNic.Text == "" || cmdAccountType.Text == "" || txtResident.Text == "" || txtStreetName.Text == "" || txtCity.Text == "" || txtEmail.Text == "" || txtContactNum.Text == "")
            {
                MessageBox.Show("Input Filed Incomplete");
            }
            else
            {
                try {
                    //get Account type addmission fee from DataBase
                    string accountTypeAddmissionfeeQuery = $"SELECT admission_fees,annual_pay_month,available_book,fine_for_day,return_day FROM tblAccountType WHERE account_type ='{cmdAccountType.Text}';";
                    SqlCommand firstCmd = new SqlCommand(accountTypeAddmissionfeeQuery,MainWindow.con);
                    MainWindow.con.Open();
                    SqlDataReader r = firstCmd.ExecuteReader();
                    //account type Data
                    double admissionFee = 0;
                    string annualMonthPay = "0";
                    string availableBook = "0";
                    string fineForDay = "0";
                    string returnDay = "0";

                    if (r.Read()) {
                        admissionFee = Convert.ToDouble(r[0].ToString());
                        annualMonthPay = r[1].ToString();
                        availableBook = r[2].ToString();
                        fineForDay = r[3].ToString();
                        returnDay = r[4].ToString();

                    }
                    r.Close();
                    MainWindow.con.Close();

                    //get availabe next member id
                    string newMemberID = nextMemberID();
                    //Add new Member To Database
                    string memberDetailsInsertQuery = $"INSERT INTO tblMember (member_id, first_name, last_name, nic, add_1, add_2, add_3, email, contact_num, account_type, account_statues, admission_fee, register_date_time, date_time, staff) VALUES ('{newMemberID}', '{txtFirstName.Text}', '{txtLastName.Text}', '{txtNic.Text}', '{txtResident.Text}', '{txtStreetName.Text}', '{txtCity.Text}', '{txtEmail.Text}', '{txtContactNum.Text}', '{cmdAccountType.Text}', 'ACTIVE', '{admissionFee.ToString()}', '{MainWindow.todayDate}', '{MainWindow.todayDate}', '{MainWindow.systemUser}');";
                    SqlCommand secondCmd = new SqlCommand(memberDetailsInsertQuery, MainWindow.con);
                    MainWindow.con.Open();
                    secondCmd.ExecuteNonQuery();
                    MessageBox.Show("Member Created Successfully.Paymet Added");
                    MainWindow.con.Close();



                    //Free ANUAL SUB

                    string nextSubId = NextSubID(  );

                    string insertsub = $" INSERT INTO tblAnnualSubscription (subscripion_id, member, payment, subscription_start, subscription_end, date_time, staff) VALUES ('{nextSubId}', '{newMemberID}', '{0}', '{MainWindow.todayDate}', '{freeSubEndDay}', '{MainWindow.todayDate}', '{MainWindow.systemUser}'); ";
                    SqlCommand CmdO = new SqlCommand(insertsub, MainWindow.con);
                    MainWindow.con.Open();
                    CmdO.ExecuteNonQuery();

                   // MainWindow.con.Close();





                    //Create bill
                    PrintBill(newMemberID,txtFirstName.Text,txtLastName.Text,cmdAccountType.Text,annualMonthPay,availableBook,returnDay,fineForDay,admissionFee.ToString(),MainWindow.systemUser);
                    //After Creating Member clear Form
                    ClearForm();


                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
                finally {
                    MainWindow.con.Close();
                  
                }
            
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtMemberShipLetter.Text = "";
        }
    }
}
