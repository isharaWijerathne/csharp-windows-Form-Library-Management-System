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
    public partial class frmBookCatList : Form
    {
        public frmBookCatList()
        {
            InitializeComponent();
            ShowData();
        }

        public void ShowData() {

            DataTable result = new DataTable();
            try
            {

                string query = "SELECT category_code,name,code FROM tblBookCategory;";

                

                //get data from dataBase and Store DataSet

                MainWindow.con.Open();
                SqlDataAdapter newAdapter = new SqlDataAdapter(query, MainWindow.con);

                newAdapter.Fill(result);

                //datadate connect to dagaGridViwe
                dgvCatList.DataSource = result;
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

        private void dgvCatList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
