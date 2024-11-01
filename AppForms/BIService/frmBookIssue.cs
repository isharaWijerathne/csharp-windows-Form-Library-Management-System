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
    public partial class frmBookIssue : Form
    {
        public frmBookIssue()
        {
            InitializeComponent();
        }

        public string nextIssiuedID()
        {

            string lastUsedIDQuery = " SELECT TOP 1 issued_id FROM tblBookIssued ORDER BY issued_id DESC;";
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
                newID = "IS-000001";
            }
            else
            {
                int newUsedInt = Convert.ToInt32(lastUsedID.Substring(3)) + 1;
                newID = $"IS-{newUsedInt.ToString().PadLeft(6, '0')}";
            }
            return newID;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            

            try {
                /* 1) check member active statues and available_bok and available rerun days*/
                if (txtMemberID.Text == "" && txtLibrayCode.Text == "") {
                    throw new Exception("Input filed Invalid");
                }

                string partOnequery = $@"SELECT tblMember.account_statues,tblAccountType.available_book,tblAccountType.return_day
                                        FROM tblMember 
                                        JOIN tblAccountType ON tblMember.account_type = tblAccountType.account_type
                                        WHERE tblMember.member_id = '{txtMemberID.Text.ToUpper()}'";

                SqlCommand getDataCMD = new SqlCommand(partOnequery, MainWindow.con);
                //firstConnection Open
                MainWindow.con.Open();
                SqlDataReader r = getDataCMD.ExecuteReader();


                string memberAccountStates;
                int availableBokk =0;
                int returnDay = 0;

                //check data can read and rowCount < 0
                if (r.Read() && r.HasRows)
                {
                    memberAccountStates = r[0].ToString();
                    availableBokk = Convert.ToInt32(r[1].ToString());
                    returnDay = Convert.ToInt32(r[2].ToString());
                    
                }
                else
                {
                    //in row count = 0 or data canot read throw err
                    throw new Exception("Enter Valid Membership ID");
                }
                //data Reader Close
                r.Close();

                if (memberAccountStates != "ACTIVE") {
                    //if members account not in  ACTIVE mode Show Erro
                    throw new Exception("Account INACTIVATED");
                }
                //close First connection
                MainWindow.con.Close();


                /* 2) find how many book already issued and compair with book rerun count*/

                string partTwoQuery = $"SELECT COUNT(statues) FROM tblBookIssued WHERE statues = 'PENDING' and member_id = '{txtMemberID.Text.ToUpper()}'";

                SqlCommand getDataCMD2 = new SqlCommand(partTwoQuery, MainWindow.con);
                //secondConnection Open
                MainWindow.con.Open();
                SqlDataReader s = getDataCMD2.ExecuteReader();


                int allreadyIssuedBookCount = 0;
                if (s.Read())
                {
                    allreadyIssuedBookCount = Convert.ToInt32(s[0].ToString());

                }

                //data reder s close
                s.Close();

                //check available book count >= isuued book count
                if (allreadyIssuedBookCount >= availableBokk) {
                    throw new Exception("Available Book Count Issued,\n\rUpgrade Your Membership");
                }
                //connection 2 clsoe
                MainWindow.con.Close();




                // 3) saveBook Issue

                //calcutale available retun Day
                DateTime today = new DateTime();
                today= DateTime.Now;
                today = today.AddDays(returnDay);

                //dataBase input variables

                string issuedId = nextIssiuedID();
                string avlRetunDay = today.ToString("yyyy-MM-dd");


                string partThreeQuery = $"INSERT INTO tblBookIssued (issued_id, member_id, library_code, issued_day, available_return_day,open_staff,statues) VALUES ('{issuedId}', '{txtMemberID.Text.ToUpper()}', '{txtLibrayCode.Text.ToUpper()}', '{MainWindow.todayDate}', '{avlRetunDay}', '{MainWindow.systemUser}','PENDING');";

                SqlCommand secondCmd = new SqlCommand(partThreeQuery, MainWindow.con);
                MainWindow.con.Open();
                secondCmd.ExecuteNonQuery();


                MessageBox.Show($"Issued Process Complete\n\rAvailable Rerturn Day : {avlRetunDay}");
                MainWindow.con.Close();







            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally {
                MainWindow.con.Close();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtMemberID.Text = string.Empty;
            txtLibrayCode.Text = string.Empty;
        }
    }
}
