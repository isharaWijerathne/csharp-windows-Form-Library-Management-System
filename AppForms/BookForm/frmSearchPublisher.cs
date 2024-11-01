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
    public partial class frmSearchPublisher : Form
    {
        public frmSearchPublisher()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
      
            DataTable result = new DataTable();
            try
            {

                string searchQuery;

                if (cmbType.Text == "Publisher ID")
                {
                    searchQuery = $"SELECT name,add_1,add_2,add_3,email,contact_num FROM tblPublisher WHERE publisher_id = '{txtValue.Text.ToUpper()}';";
                }
                else if (cmbType.Text == "Publisher Name")
                {
                    searchQuery = $" SELECT name,add_1,add_2,add_3,email,contact_num FROM tblPublisher WHERE name LIKE '%{txtValue.Text}%'; ";

                }
                else if (cmbType.Text == "Company Name")
                {
                    searchQuery = $" SELECT name,add_1,add_2,add_3,email,contact_num FROM tblPublisher WHERE add_1 LIKE '%{txtValue.Text}%'; ";

                }
                else if (cmbType.Text == "Street")
                {
                    searchQuery = $" SELECT name,add_1,add_2,add_3,email,contact_num FROM tblPublisher WHERE add_2 LIKE '%{txtValue.Text}%'; ";

                }
                else if (cmbType.Text == "City")
                {
                    searchQuery = $" SELECT name,add_1,add_2,add_3,email,contact_num FROM tblPublisher WHERE add_3 LIKE '%{txtValue.Text}%'; ";

                }
                else if (cmbType.Text == "Email")
                {
                    searchQuery = $" SELECT name,add_1,add_2,add_3,email,contact_num FROM tblPublisher WHERE email LIKE '%{txtValue.Text}%'; ";

                }
                else if (cmbType.Text == "Contact Number")
                {
                    searchQuery = $" SELECT name,add_1,add_2,add_3,email,contact_num FROM tblPublisher WHERE contact_num LIKE '%{txtValue.Text}%'; ";

                }
                else
                {
                    searchQuery = $"";
                    throw new Exception("Invalide Selection");
                }



                //get data from dataBase and Store DataSet

                MainWindow.con.Open();
                SqlDataAdapter newAdapter = new SqlDataAdapter(searchQuery, MainWindow.con);

                newAdapter.Fill(result);

                //datadate connect to dagaGridViwe
                dgvData.DataSource = result;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                //clear store data
                //
                MainWindow.con.Close();

            }
        }
    }
}
