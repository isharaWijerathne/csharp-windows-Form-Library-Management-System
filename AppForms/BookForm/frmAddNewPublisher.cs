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
    public partial class frmAddNewPublisher : Form
    {
        public frmAddNewPublisher()
        {
            InitializeComponent();
        }

        public void ClearForm() {

            txtPublisherName.Text = "";
            txtCompanyName.Text = "";
            txtStreet.Text = "";
            txtCity.Text = "";
            txtEmail.Text = "";
            txtContNum.Text = "";
        
        }

        public string NextId()
        {
            string lastUsedIDQuery = " SELECT TOP 1 publisher_id FROM tblPublisher ORDER BY publisher_id DESC;";
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
                newID = "PU-0001";
            }
            else
            {
                int newUsedInt = Convert.ToInt32(lastUsedID.Substring(3)) + 1;
                newID = $"PU-{newUsedInt.ToString().PadLeft(4, '0')}";
            }
            return newID;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (txtPublisherName.Text == "" && txtCompanyName.Text == "" && txtStreet.Text == "" && txtCity.Text == "" && txtEmail.Text =="" && txtContNum.Text=="")
            {
                MessageBox.Show("Input Filed Incomplete");
            }
            else
            {
                try
                {


                    //get availabe next member id
                    string newPublisherID = NextId();
                    //Add new Member To Database
                    string publisherDetailsInsertQuery = $" INSERT INTO tblPublisher (publisher_id, name, add_1, add_2, add_3, email, contact_num, date_time, staff) VALUES ('{newPublisherID}', '{txtPublisherName.Text}', '{txtCompanyName.Text}', '{txtStreet.Text}', '{txtCity.Text}', '{txtEmail.Text}', '{txtContNum.Text}', '{MainWindow.todayDate}', '{MainWindow.systemUser}'); ";
                    SqlCommand Cmd = new SqlCommand(publisherDetailsInsertQuery, MainWindow.con);
                    MainWindow.con.Open();
                    Cmd.ExecuteNonQuery();
                    MessageBox.Show("Publisher Created Successfully");




                    //After Creating Member clear Form
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
        }
    }
}
