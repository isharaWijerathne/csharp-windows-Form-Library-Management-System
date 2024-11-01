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
    public partial class frmSearchMember : Form
    {
        public frmSearchMember()
        {
            InitializeComponent();
        }
        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable result = new DataTable();
            try

            {

                string searchQuery;

                if (cmbType.Text == "Member ID")
                {
                    searchQuery = $" SELECT member_id,first_name,last_name,nic,add_1,add_2,add_3,email,contact_num,account_type,account_statues,register_date_time from tblMember WHERE member_id = '{txtValue.Text.ToUpper()}'; ";
                }
                else if (cmbType.Text == "First Name")
                {

                    searchQuery = $" SELECT member_id,first_name,last_name,nic,add_1,add_2,add_3,email,contact_num,account_type,account_statues,register_date_time from tblMember WHERE first_name LIKE '%{txtValue.Text.ToUpper()}%'; ";

                }
                else if (cmbType.Text == "Last Name")
                {

                    searchQuery = $" SELECT member_id,first_name,last_name,nic,add_1,add_2,add_3,email,contact_num,account_type,account_statues,register_date_time from tblMember WHERE last_name LIKE '%{txtValue.Text.ToUpper()}%'; ";

                }
                else if (cmbType.Text == "NIC")
                {

                    searchQuery = $" SELECT member_id,first_name,last_name,nic,add_1,add_2,add_3,email,contact_num,account_type,account_statues,register_date_time from tblMember WHERE nic LIKE '%{txtValue.Text.ToUpper()}%'; ";

                }
                else if (cmbType.Text == "Email")
                {
                    searchQuery = $" SELECT member_id,first_name,last_name,nic,add_1,add_2,add_3,email,contact_num,account_type,account_statues,register_date_time from tblMember WHERE email LIKE '%{txtValue.Text.ToUpper()}%'; ";

                }
                else if (cmbType.Text == "Contact Number")
                {
                    searchQuery = $" SELECT member_id,first_name,last_name,nic,add_1,add_2,add_3,email,contact_num,account_type,account_statues,register_date_time from tblMember WHERE contact_num LIKE '%{txtValue.Text.ToUpper()}%'; ";

                }
                else if (cmbType.Text == "Account Type")
                {
                    searchQuery = $" SELECT member_id,first_name,last_name,nic,add_1,add_2,add_3,email,contact_num,account_type,account_statues,register_date_time from tblMember WHERE account_type LIKE '%{txtValue.Text.ToUpper()}%'; ";

                }
                else
                {
                    searchQuery = $" SELECT member_id,first_name,last_name,nic,add_1,add_2,add_3,email,contact_num,account_type,register_date_time from tblMember WHERE member_id = '{txtValue.Text.ToUpper()}'; ";
                    throw new Exception("Invalide Selection");
                }



                //get data from dataBase and Store DataSet

                MainWindow.con.Open();
                SqlDataAdapter newAdapter = new SqlDataAdapter(searchQuery,MainWindow.con);
               
                newAdapter.Fill(result);

                //datadate connect to dagaGridViwe
                dgvData.DataSource = result;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally {
                //clear store data
                //
                MainWindow.con.Close();
            
            }
            




        }
    }
}
