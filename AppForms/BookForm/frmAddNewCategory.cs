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
    public partial class frmAddNewCategory : Form
    {
        public frmAddNewCategory()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Text = string.Empty;
            txtCode.Text = string.Empty;
        }

        public string NextId()
        {
            string lastUsedIDQuery = " SELECT TOP 1 category_code FROM tblBookCategory ORDER BY category_code DESC;";
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
                newID = "BT-0001";
            }
            else
            {
                int newUsedInt = Convert.ToInt32(lastUsedID.Substring(3)) + 1;
                newID = $"BT-{newUsedInt.ToString().PadLeft(4, '0')}";
            }
            return newID;
        }

        private void btnCreateCat_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" && txtCode.Text == "")
            {
                MessageBox.Show("Input Filed Incomplete");
            }
            else
            {
                try
                {


                    //get availabe next member id
                    string newCategoryID = NextId();
                    //Add new Member To Database
                    string categoryDetailsInsertQuery = $" INSERT INTO tblBookCategory (category_code, name, code, date_time, staff) VALUES ('{newCategoryID}', '{txtName.Text}', '{txtCode.Text.ToUpper()}', '{MainWindow.todayDate}', '{MainWindow.systemUser}'); ";
                    SqlCommand Cmd = new SqlCommand(categoryDetailsInsertQuery, MainWindow.con);
                    MainWindow.con.Open();
                    Cmd.ExecuteNonQuery();
                    MessageBox.Show("Author Created Successfully");




                    //After Creating Member clear Form
                    txtName.Text = string.Empty;
                    txtCode.Text = string.Empty;


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
