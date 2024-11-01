using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibSys.AppForms.BookForm
{
    public partial class frmSearchAuthor : Form
    {
        public frmSearchAuthor()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable result = new DataTable();
            try
            {

                string searchQuery;

                if (cmbType.Text == "Author ID")
                {
                    searchQuery = $"SELECT name,webSite,email,info FROM tblAuthor WHERE author_id = '{txtValue.Text.ToUpper()}';";
                }
                else if (cmbType.Text == "Name")
                {
                    searchQuery = $"SELECT name,webSite,email,info FROM tblAuthor WHERE name LIKE '%{txtValue.Text.ToUpper()}%';";

                }
                else if (cmbType.Text == "Email")
                {
                    searchQuery = $"SELECT name,webSite,email,info FROM tblAuthor WHERE email LIKE '%{txtValue.Text.ToUpper()}%';";

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
                dgvtable.DataSource = result;
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
