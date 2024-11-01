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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace LibSys.AppForms.BookForm
{
    public partial class frmEditPublisher : Form
    {
        public frmEditPublisher()
        {
            InitializeComponent();
        }

        //find auther verify
        public bool isPublisherVerify = false;

        public void ClearForm()
        {
            txtPublisherID.Text = string.Empty;
            txtPublisherName.Text = string.Empty;
            txtCompany.Text= string.Empty;
            txtStreet.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtEmail.Text=string.Empty;
            txtNumber.Text = string.Empty;
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            try
            {

                //if member id empty,throw Err
                if (txtPublisherID.Text == "")
                {
                    throw new Exception("Enter Valid Membership ID");
                }
                //find any recode using provided member_id 
                string publisherFindQuery = $"SELECT name,add_1,add_2,add_3,email,contact_num FROM tblPublisher WHERE publisher_id = '{txtPublisherID.Text.ToUpper()}';";
                SqlCommand getDataCMD = new SqlCommand(publisherFindQuery, MainWindow.con);

                MainWindow.con.Open();
                SqlDataReader r = getDataCMD.ExecuteReader();



                //check data can read and rowCount < 0
                if (r.Read() && r.HasRows)
                {
                    txtPublisherName.Text = r[0].ToString();
                    txtCompany.Text = r[1].ToString();
                    txtStreet.Text = r[2].ToString();
                    txtCity.Text = r[3].ToString();
                    txtEmail.Text = r[4].ToString();
                    txtNumber.Text = r[5].ToString();

                }
                else
                {
                    //in row count = 0 or data canot read throw err
                    throw new Exception("Enter Valid Membership ID");
                }


                //make publisherVerify = ok
                isPublisherVerify = true;

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
            grpMain.Enabled = false;
            isPublisherVerify = false;
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            if (isPublisherVerify)
            {
                grpMain.Enabled = true;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                //throw err if any txtbox empty
                if (txtPublisherName.Text == "" && txtCompany.Text == "" && txtStreet.Text == "" && txtCity.Text == "" && txtEmail.Text == "" && txtNumber.Text =="" && txtPublisherID.Text=="")
                {
                    throw new Exception("Input Filed Missing");
                }

                //update query
                string publisherDetailUpdateQuery = $@"UPDATE tblPublisher
                                                    SET name='{txtPublisherName.Text}',add_1='{txtCompany.Text}',add_2='{txtStreet.Text}',add_3='{txtCity.Text}',email='{txtEmail.Text}',contact_num='{txtNumber.Text}',date_time='{MainWindow.todayDate}',staff='{MainWindow.todayDate}'
                                                    WHERE publisher_id ='{txtPublisherID.Text.ToUpper()}';";

                SqlCommand publisherDetailUpdateCMD = new SqlCommand(publisherDetailUpdateQuery, MainWindow.con);

                MainWindow.con.Open();
                publisherDetailUpdateCMD.ExecuteNonQuery();

                MessageBox.Show("Author details Update Succesfully");
                //After Data Update disable  grpBox
                grpMain.Enabled = false;


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
