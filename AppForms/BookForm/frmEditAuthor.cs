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

namespace LibSys.AppForms.BookForm
{
    public partial class frmEditAuthor : Form
    {
        public frmEditAuthor()
        {
            InitializeComponent();
        }

        //find auther verify
        public bool isAuthorVerify = false;

        public void ClearForm() {
            txtAuherName.Text = "";
            txtAuthorweb.Text = "";
            txtAuthorEmail.Text = "";
            txtAuthorInfo.Text = "";
            txtAuthorID.Text = "";
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            try
            {

                //if member id empty,throw Err
                if (txtAuthorID.Text=="")
                {
                    throw new Exception("Enter Valid Membership ID");
                }
                //find any recode using provided member_id 
                string authorFindQuery = $"SELECT name,webSite,email,info FROM tblAuthor WHERE author_id = '{txtAuthorID.Text.ToUpper()}';";
                SqlCommand getDataCMD = new SqlCommand(authorFindQuery, MainWindow.con);

                MainWindow.con.Open();
                SqlDataReader r = getDataCMD.ExecuteReader();



                //check data can read and rowCount < 0
                if (r.Read() && r.HasRows)
                {
                    txtAuherName.Text = r[0].ToString();
                    txtAuthorweb.Text = r[1].ToString();
                    txtAuthorEmail.Text = r[2].ToString();
                    txtAuthorInfo.Text = r[3].ToString();

                }
                else
                {
                    //in row count = 0 or data canot read throw err
                    throw new Exception("Enter Valid Membership ID");
                }


                //make authorVerify = ok
                isAuthorVerify = true;

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
            grpBox.Enabled = false;
            isAuthorVerify = false;
        }

        private void btnEnableEdit_Click(object sender, EventArgs e)
        {
            if (isAuthorVerify) {
                grpBox.Enabled = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                //throw err if any txtbox empty
                if (txtAuthorID.Text=="" && txtAuherName.Text=="" && txtAuthorweb.Text =="" && txtAuthorEmail.Text=="" && txtAuthorInfo.Text =="")
                {
                    throw new Exception("Input Filed Missing");
                }

                //update query
                string authorDetailUpdateQuery = $@"UPDATE tblAuthor
                                                    SET name = '{txtAuherName.Text}' ,webSite = '{txtAuthorweb.Text}',email='{txtAuthorEmail.Text}',info='{txtAuthorInfo.Text}',date_time='{MainWindow.todayDate}',staff='{MainWindow.systemUser}'
                                                    WHERE author_id = '{txtAuthorID.Text.ToUpper()}'";

                SqlCommand authorDetailUpdateCMD = new SqlCommand(authorDetailUpdateQuery, MainWindow.con);

                MainWindow.con.Open();
                authorDetailUpdateCMD.ExecuteNonQuery();

                MessageBox.Show("Author details Update Succesfully");
                //After Data Update disable  grpBox
                grpBox.Enabled = false;


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
    }
}
