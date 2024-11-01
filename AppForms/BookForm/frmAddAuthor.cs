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
    public partial class frmAddAuthor : Form
    {
        public frmAddAuthor()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        public void ClearForm()
        {

            txtAuthorName.Text = "";
            txtAutherWeb.Text = "";
            txtAutherEmail.Text = "";
            txtAuthorInfo.Text = "";

        }

        public string NextId()
        {
            string lastUsedIDQuery = " SELECT TOP 1 author_id FROM tblAuthor ORDER BY author_id DESC;";
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
                newID = "AU-0001";
            }
            else
            {
                int newUsedInt = Convert.ToInt32(lastUsedID.Substring(3)) + 1;
                newID = $"AU-{newUsedInt.ToString().PadLeft(4, '0')}";
            }
            return newID;
        }

        private void btnSumbit_Click(object sender, EventArgs e)
        {
            if (txtAuthorName.Text == "" && txtAutherWeb.Text == "" && txtAutherEmail.Text == "" && txtAuthorInfo.Text == "")
            {
                MessageBox.Show("Input Filed Incomplete");
            }
            else
            {
                try
                {


                    //get availabe next member id
                    string newAuthorID = NextId();
                    //Add new Member To Database
                    string authorDetailsInsertQuery = $"INSERT INTO tblAuthor (author_id, name , webSite, email, info, date_time, staff) VALUES ('{newAuthorID}', '{txtAuthorName.Text}', '{txtAutherWeb.Text}', '{txtAutherEmail.Text}', '{txtAuthorInfo.Text}', '{MainWindow.todayDate}', '{MainWindow.systemUser}');";
                    SqlCommand secondCmd = new SqlCommand(authorDetailsInsertQuery, MainWindow.con);
                    MainWindow.con.Open();
                    secondCmd.ExecuteNonQuery();
                    MessageBox.Show("Author Created Successfully");




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
