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
    public partial class frmEditMember : Form
    {
        public frmEditMember()
        {
            InitializeComponent();
        }
        //check load data connected
        bool isDataLoded = false;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public void ClearForm() {
            //member Id
            txtMemberId.Text = "";

            //Clear Presonal Data
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtNic.Text = "";

            //Clear contact Infor
            txtResident.Text = "";
            txtStreetName.Text = "";
            txtCity.Text = "";
            txtContactNum.Text = "";
            txtEmail.Text = "";

        }

        private void btnEnableEdit_Click(object sender, EventArgs e)
        {
            //if data load complete , allow to edit dataForms
            if (isDataLoded) {
                grpContactInformation.Enabled = true;
                grpPresonalDetails.Enabled = true;
            
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            grpContactInformation.Enabled = false;
            grpPresonalDetails.Enabled = false;
            isDataLoded = false;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try {
                //throw err if any txtbox empty
                if (txtMemberId.Text == "" || txtFirstName.Text == "" || txtLastName.Text == "" || txtNic.Text == "" || txtResident.Text == "" || txtStreetName.Text == "" || txtCity.Text == "" || txtEmail.Text == "" || txtContactNum.Text == "") {
                    throw new Exception("Input Filed Missing");
                }

                //update query
                string memberDetailUpdateQuery = $@"UPDATE tblMember
                                                    SET first_name = '{txtFirstName.Text}' ,last_name = '{txtLastName.Text}',nic ='{txtNic.Text}',add_1='{txtResident.Text}',add_2='{txtStreetName.Text}',add_3='{txtCity.Text}',email='{txtEmail.Text}',contact_num='{txtContactNum.Text}',date_time='{MainWindow.todayDate}',staff='{MainWindow.systemUser}'
                                                    WHERE member_id = '{txtMemberId.Text.ToUpper()}';";

                SqlCommand memberDetailUpdateCMD= new SqlCommand(memberDetailUpdateQuery,MainWindow.con);

                MainWindow.con.Open();
                memberDetailUpdateCMD.ExecuteNonQuery();

                MessageBox.Show("Member details Update Succesfully");
                //After Data Update disable 2 grpBox
                grpContactInformation.Enabled = false;
                grpPresonalDetails.Enabled = false;


            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                MainWindow.con.Close();
            }
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
                string memberFindQuery = $"SELECT first_name,last_name,nic,add_1,add_2,add_3,email,contact_num FROM tblMember WHERE member_id = '{txtMemberId.Text.ToUpper()}';";
                SqlCommand getDataCMD = new SqlCommand(memberFindQuery, MainWindow.con);

                MainWindow.con.Open();
                SqlDataReader r = getDataCMD.ExecuteReader();



                //check data can read and rowCount < 0
                if (r.Read() && r.HasRows)
                {
                    txtFirstName.Text = r[0].ToString();
                    txtLastName.Text = r[1].ToString();
                    txtNic.Text = r[2].ToString();
                    txtResident.Text = r[3].ToString();
                    txtStreetName.Text = r[4].ToString();
                    txtCity.Text = r[5].ToString();
                    txtEmail.Text = r[6].ToString();
                    txtContactNum.Text = r[7].ToString();

                }
                else
                {
                    //in row count = 0 or data canot read throw err
                    throw new Exception("Enter Valid Membership ID");
                }
                

                //make Data set Load Ok
                isDataLoded = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally {
                MainWindow.con.Close();
            }
        }
    }
}
