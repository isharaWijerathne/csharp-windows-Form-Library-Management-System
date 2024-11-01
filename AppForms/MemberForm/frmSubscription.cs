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
    public partial class frmSubscription : Form
    {
        public frmSubscription()
        {
            InitializeComponent();
        }

        //member Loading
        public bool ismemberLoad = false;
        public bool isPayCalculated = false;

        //member data
        public string memberName = "";
        public double annualPay = 0;
        public  string subEndDate = "";


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
                string subFindQuery = $@"SELECT TOP 1 tblMember.first_name,tblMember.last_name,tblAnnualSubscription.payment,tblAnnualSubscription.subscription_start,tblAnnualSubscription.subscription_end,tblAccountType.annual_pay_month
                                        FROM tblAnnualSubscription
                                        JOIN tblMember ON tblAnnualSubscription.member = tblMember.member_id
                                        JOIN tblAccountType ON tblMember.account_type = tblAccountType.account_type
                                        WHERE tblAnnualSubscription.member = '{txtMemberId.Text.ToUpper()}' ORDER BY tblAnnualSubscription.subscripion_id DESC;";
                SqlCommand getDataCMD = new SqlCommand(subFindQuery, MainWindow.con);

                MainWindow.con.Open();
                SqlDataReader r = getDataCMD.ExecuteReader();



                //hold Last Paymtn Data;
                string lastPayment = "";
                string subStartday = "";

                //check data can read and rowCount < 0


                if (r.Read() && r.HasRows)
                {
                    memberName = $"{r[0].ToString()} {r[1].ToString()}";
                    lastPayment = r[2].ToString();
                    subStartday = r[3].ToString();
                    subEndDate = r[4].ToString();
                    annualPay = Convert.ToDouble(r[5].ToString());

                }
                else
                {
                    //in row count = 0 or data canot read throw err
                    throw new Exception("Enter Valid Membership ID");
                }


                //make MemberVerify = ok

                ismemberLoad = true;

                //InterFace
                string showLastPayment = $@"Member Name : {memberName}
Subscription Start Date :{subStartday}
Subscription Start End : {subEndDate}
Payment : {lastPayment}
";

                txtLastSubData.Text = showLastPayment;
                txtNewSubDate.Text = subEndDate.Substring(0,9);

                txtMemberId.ReadOnly= true;
                btncheckPay.Enabled = true;


                

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
            ismemberLoad = false;
            isPayCalculated = false;
            txtMemberId.ReadOnly = false;

            txtMemberId.Text = string.Empty;
            txtLastSubData.Text = string.Empty;
            txtNewSubDate.Text = string.Empty;
            txtPayment.Text = string.Empty;

            txtMemberShipUpgrateLetter.Text = string.Empty;

            btnPaymentComplete.Enabled = false;
            

        }

        private void btncheckPay_Click(object sender, EventArgs e)
        {
            /*DateTime avaReturnDayFormated = DateTime.Parse(avlReturndDay);
                int dateCheck = DateTime.Today.CompareTo(avaReturnDayFormated);*/

            if (ismemberLoad)
            {
                DateTime subEndDateConvet = DateTime.Parse(subEndDate);
                DateTime nextSubDate = DateTime.Parse(dtpNewSubEndDate.Text);
                TimeSpan dateDifferance = nextSubDate - subEndDateConvet;
                double payMonth = (dateDifferance.TotalDays / 30) * annualPay;

                txtPayment.Text = Convert.ToString(Math.Round(payMonth));

                isPayCalculated = true;
                btnPaymentComplete.Enabled = true;
                btncheckPay.Enabled = false;
            }
            else {
                MessageBox.Show("Invalid Member ID");
            
            }


            

        }

        private void btnPaymentComplete_Click(object sender, EventArgs e)
        {

            try
            {


                // 1-Create sub table 
                string subId = NextSubID();
                if (txtMemberId.Text =="")
                {

                    throw new Exception("Invalid Issue ID");
                }

                string insertsub = $" INSERT INTO tblAnnualSubscription (subscripion_id, member, payment, subscription_start, subscription_end, date_time, staff) VALUES ('{subId}', '{txtMemberId.Text.ToUpper()}', '{txtPayment.Text}', '{txtNewSubDate.Text}', '{dtpNewSubEndDate.Text}', '{MainWindow.todayDate}', '{MainWindow.systemUser}'); ";
                SqlCommand CmdO = new SqlCommand(insertsub, MainWindow.con);
                MainWindow.con.Open();
                CmdO.ExecuteNonQuery();
                MainWindow.con.Close();


                //2-UPDATE member Statue to active;

                string memberUpdateQuery = $@"UPDATE tblMember
                                            SET account_statues = 'ACTIVE'
                                            WHERE member_id = '{txtMemberId.Text}' ;";
                SqlCommand Cmd = new SqlCommand(memberUpdateQuery, MainWindow.con);
                MainWindow.con.Open();
                Cmd.ExecuteNonQuery();

                string printBill = $@"-------------------------------------------------------
LIBRARY SYSTEM
ANNUAL SUBSCRIPTION
PAYMRY BILL
-------------------------------------------------------

MEMBER ID - {txtMemberId.Text.ToUpper()}
SUBSCRIPTION START DAY - {txtNewSubDate.Text}
SUBSCRIPTION START DAY - {dtpNewSubEndDate.Text}
PAYMENT - {txtPayment.Text}




CASHIER - {MainWindow.systemUser}
DATE - {DateTime.Now.ToString()}
.......................................................
READING MAKETH A FULL MAN
.......................................................";

                MainWindow.con.Close();
                txtMemberShipUpgrateLetter.Text = printBill;
                btnPaymentComplete.Enabled = false;
                MessageBox.Show("Book Issued And Fine Bill Completed");


            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                MainWindow.con.Close();
            }
        }
    }
}
