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
    public partial class frmMebUpgrade : Form
    {
        public frmMebUpgrade()
        {
            InitializeComponent();
        }
        //privious Account Type
        string previousAccountType;


        //form Clear
        public void ClearForm() {
            txtMemberId.Text = "";
            txtMmberName.Text = "";
            txtPreviousAccType.Text = "";
            cmdNewAccountType.Text = "";

            //txtmembershipID txtbox ReadAble
            txtMemberId.ReadOnly = false;
        }

        public void PrintBill(string memberID, string memberName, string memberShipType, string anualPay, string availableBook, string returnDay, string fine, string addmissionFee, string cashier)
        {
            string printBill = $@"-------------------------------------------------------
LIBRARY SYSTEM
MEMBERSHIP UPGRADE
PAYMRY BILL
-------------------------------------------------------

MEMBER ID - {memberID}
MEMBER NAME - {memberName}
NEW MEMBERSHIP TYPE - {memberShipType}
ANNUAL MONTH PAY - {anualPay}
AVAILABLE BOOK - {availableBook}
BOOK RETURN DAY - {returnDay}
FINE FOR DAY - {fine}

MEMBERSHIP RENEVAL FEES - {addmissionFee}
CASHIER - {cashier}
DATE - {DateTime.Now.ToString()}
.......................................................
READING MAKETH A FULL MAN
.......................................................";

            txtMemberShipUpgrateLetter.Text = printBill;

            
        }

        private void btnVerifyId_Click(object sender, EventArgs e)
        {
            try
            {

                //if member id empty,throw Err
                if (txtMemberId.Text == "")
                {
                    throw new Exception("Enter Valid Membership ID");
                }
                //find any recode using provided member_id 
                string memberFindQuery = $" SELECT first_name,last_name,account_type from tblMember WHERE member_id = '{txtMemberId.Text.ToUpper()}'; ";
                SqlCommand getDataCMD = new SqlCommand(memberFindQuery, MainWindow.con);

                MainWindow.con.Open();
                SqlDataReader r = getDataCMD.ExecuteReader();



                //check data can read and rowCount < 0
                if (r.Read() && r.HasRows)
                {
                    txtMmberName.Text = $"{r[0].ToString()} {r[1].ToString()}";
                    txtPreviousAccType.Text = r[2].ToString() ;

                    //assgin previous AccountType
                    previousAccountType = r[2].ToString();
                    //txtMembershipID textBox  make UnEditeable
                    txtMemberId.ReadOnly = true;
                    cmdNewAccountType.Enabled = true;

                }
                else
                {
                    //in row count = 0 or data canot read throw err
                    throw new Exception("Enter Valid Membership ID");
                }

                r.Close();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MainWindow.con.Close();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnUpgrate_Click(object sender, EventArgs e)
        {

            try
            {
                //throw err if Old membership type == new memberShip typw
                if (previousAccountType == cmdNewAccountType.Text || txtMmberName.Text == "")
                {
                    throw new Exception("Acoount Alreadu In This Account Type");
                }


                //update query
                string memberAccountTypeUpdateQuery = $@"UPDATE tblMember
                                                        SET account_type = '{cmdNewAccountType.Text}', staff ='{MainWindow.systemUser}', date_time= '{MainWindow.todayDate}',account_statues ='HOLD'
                                                        WHERE member_id = '{txtMemberId.Text.ToUpper()}'";

                SqlCommand memberAccountTypeUpdateCMD = new SqlCommand(memberAccountTypeUpdateQuery, MainWindow.con);

                MainWindow.con.Open();
                memberAccountTypeUpdateCMD.ExecuteNonQuery();
                MainWindow.con.Close();

                MessageBox.Show("Member Account Type Update Succesfully \n\rMake New Annual Subscription");


                //Make printBill
                string accountTypeFindQuery = $" SELECT admission_fees,annual_pay_month,available_book,fine_for_day,return_day FROM tblAccountType WHERE account_type = '{cmdNewAccountType.Text}'; ";
                SqlCommand getDataCMD = new SqlCommand(accountTypeFindQuery, MainWindow.con);

                MainWindow.con.Open();
                SqlDataReader r = getDataCMD.ExecuteReader();



                //check data can read and rowCount < 0
                if (r.Read() && r.HasRows)
                {
                    PrintBill(txtMemberId.Text, txtMmberName.Text, cmdNewAccountType.Text, r[1].ToString(), r[2].ToString(), r[4].ToString(), r[3].ToString(), r[0].ToString(),MainWindow.systemUser) ;

                }
                else
                {
                    //in row count = 0 or data canot read throw err
                    throw new Exception("Something Went Wrong,Try Again");
                }


                ClearForm();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MainWindow.con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearForm();
            txtMemberShipUpgrateLetter.Text = "";
        }
    }
}
