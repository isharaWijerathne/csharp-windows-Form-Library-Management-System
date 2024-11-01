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

namespace LibSys.AppForms.BIService
{
    public partial class frmBookReturn : Form
    {
        public frmBookReturn()
        {
            InitializeComponent();
        }
        public string avlReturndDay = "";
        public double fineForDay = 0;

        public bool isLoad = false;

        public string NextFineID()
        {

            string lastUsedIDQuery = " SELECT TOP 1 fine_id FROM tblFine ORDER BY fine_id DESC;";
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
                newID = "FI-00001";
            }
            else
            {
                int newUsedInt = Convert.ToInt32(lastUsedID.Substring(3)) + 1;
                newID = $"FI-{newUsedInt.ToString().PadLeft(5, '0')}";
            }
            return newID;
        }

        
        private void butRetunProcess_Click(object sender, EventArgs e)
        {
            if (isLoad)
            {

                DateTime avaReturnDayFormated = DateTime.Parse(avlReturndDay);
                int dateCheck = DateTime.Today.CompareTo(avaReturnDayFormated);

                //dateCkeck == -1 date not expierd ---fineAvailable
                if (dateCheck == 1)
                {
                    //fine WindowOpen
                    string meg = "Fines Available\n\rAre your Pay now";
                    string title = "Fine Payment Aavailable";
                    MessageBoxButtons btn = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(meg, title, btn);

                    if (result == DialogResult.Yes)
                    {
                        //formData Close
                        
                        txtAddition.ReadOnly = false;
                        txtNote.ReadOnly = false;


                        //calculate fine
                        TimeSpan extraTimeSpan = DateTime.Today - avaReturnDayFormated;
                        double extraDay = extraTimeSpan.Days;
                        double finePay = extraDay * fineForDay;
                        txtFineAmount.Text = finePay.ToString();

                        btnPay.Enabled = true;
                        btnRetunProcess.Enabled = false;

                       

                    }
                    else
                    {

                        MessageBox.Show("Return Incomplete");
                    }

                }
                else {

                    //bookIssedComplete without Fine

                    try {
                        string bookIssuedQuery = $@"UPDATE tblBookIssued
                                                SET returned_day = '{MainWindow.todayDate}' ,close_staff = '{MainWindow.systemUser}',statues ='DONE'
                                                WHERE issued_id = '{txtIssuedID.Text.ToUpper()}';
                                                ";
                        SqlCommand Cmd = new SqlCommand(bookIssuedQuery, MainWindow.con);
                        MainWindow.con.Open();
                        Cmd.ExecuteNonQuery();
                        MessageBox.Show("Book Issued Completed");

                        txtMemberID.Text = string.Empty;
                        txtIssuedID.Text = string.Empty;
                        txtLibraryCode.Text = string.Empty;
                        txtIssuedDate.Text = string.Empty;
                        txtFineAmount.Text = string.Empty;
                        txtAddition.Text = string.Empty;
                        txtNote.Text = string.Empty;

                        isLoad = false;
                        

                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    finally {
                        MainWindow.con.Close();
                    }

                   



                }
                


                
            }
            else {

                MessageBox.Show("Verify ID First"); 
                
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtMemberID.Text = string.Empty;
            txtIssuedID.Text = string.Empty;
            txtLibraryCode.Text = string.Empty;
            txtIssuedDate.Text = string.Empty;
            txtNote.Text = string.Empty;
            txtFineAmount.Text = string.Empty;
            txtAddition.Text = string.Empty;

            txtBill.Text = string.Empty;

            txtAddition.Enabled = false;
            txtNote.Enabled = false;

            btnRetunProcess.Enabled = true;
            btnPay.Enabled = false;

            isLoad = false;
        }

        private void btnVefiry_Click(object sender, EventArgs e)
        {
           

            try
            {
                if (txtIssuedID.Text == "")
                {
                    throw new Exception("Enter Valid Issued ID");
                }
                //find any recode using provided member_id 
                string issuedIDFindQuery = $@"SELECT tblBookIssued.member_id,library_code,issued_day,available_return_day,tblAccountType.fine_for_day FROM tblBookIssued
                                            JOIN tblMember ON tblBookIssued.member_id = tblMember.member_id
                                            JOIN tblAccountType ON tblMember.account_type = tblAccountType.account_type
                                            WHERE issued_id = '{txtIssuedID.Text.ToUpper()}' and statues = 'PENDING'; ";
                SqlCommand getDataCMD = new SqlCommand(issuedIDFindQuery, MainWindow.con);

                MainWindow.con.Open();
                SqlDataReader r = getDataCMD.ExecuteReader();

                

                //check data can read and rowCount < 0
                if (r.Read() && r.HasRows)
                {
                    txtMemberID.Text = r[0].ToString();
                    txtLibraryCode.Text = r[1].ToString();
                    txtIssuedDate.Text = r[2].ToString();
                    avlReturndDay = r[3].ToString();
                    fineForDay = Convert.ToDouble(r[4].ToString());
                }
                else
                {
                    //in row count = 0 or data canot read throw err
                    throw new Exception("Valid Issued ID or ID Expired");
                }

                isLoad= true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                MainWindow.con.Close();
            }

        }

        private void btnPay_Click(object sender, EventArgs e)
        {

          try {


                // 1-Create Fine table 
                string fineID = NextFineID();
                if (txtIssuedID.Text == "") {

                    throw new Exception("Invalid Issue ID");
                }

                string insertFine = $" INSERT INTO tblFine (fine_id, issued_id, fine, addition, note, date_time, staff) VALUES ('{fineID}','{txtIssuedID.Text.ToUpper()}','{txtFineAmount.Text}','{txtAddition.Text}','{txtNote.Text}', '{MainWindow.todayDate}', '{MainWindow.systemUser}'); ";
                SqlCommand CmdO = new SqlCommand(insertFine, MainWindow.con);
                MainWindow.con.Open();
                CmdO.ExecuteNonQuery();
                MainWindow.con.Close();


                //2-UPDATE bookIssued

                string bookIssuedQuery = $@"UPDATE tblBookIssued
                                                SET returned_day = '{MainWindow.todayDate}' ,close_staff = '{MainWindow.systemUser}',payment_id ='{fineID}',statues ='DONE'
                                                WHERE issued_id = '{txtIssuedID.Text.ToUpper()}'; ";
                SqlCommand Cmd = new SqlCommand(bookIssuedQuery, MainWindow.con);
                MainWindow.con.Open();
                Cmd.ExecuteNonQuery();

                string printBill = $@"-------------------------------------------------------
LIBRARY SYSTEM
BOOK RETURN FINES
PAYMRY BILL
-------------------------------------------------------

MEMBER ID - {txtMemberID.Text.ToUpper()}
ISSUED IS - {txtIssuedID.Text.ToUpper()}
FINE ID - {fineID}
FINE - {txtFineAmount.Text}
ADDITION - {txtAddition.Text}




CASHIER - {MainWindow.systemUser}
DATE - {DateTime.Now.ToString()}
.......................................................
READING MAKETH A FULL MAN
.......................................................";

                MainWindow.con.Close();
                txtBill.Text = printBill;
                btnPay.Enabled = false;
                MessageBox.Show("Book Issued And Fine Bill Completed");


           }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally {
                MainWindow.con.Close();
            }
        }
    }
}
