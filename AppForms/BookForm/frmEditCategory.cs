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
    public partial class frmEditCategory : Form
    {
        public frmEditCategory()
        {
            InitializeComponent();
        }

        public bool isDataLoaded = false;

        private void btnEnable_Click(object sender, EventArgs e)
        {
            if (isDataLoaded) { 
                txtName.ReadOnly = false;
                txtCode.ReadOnly = false;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCatId.Text = string.Empty;
            txtCode.Text = string.Empty;
            txtName.Text = string.Empty;

            //dataload set to false

            isDataLoaded = false;
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            try
            {

                //if member id empty,throw Err
                if (txtCatId.Text == "")
                {
                    throw new Exception("Enter Valid Category ID");
                }
                //find any recode using provided member_id 
                string categoryFindQuery = $"SELECT name,code FROM tblBookCategory WHERE category_code = '{txtCatId.Text.ToUpper()}'";
                SqlCommand getDataCMD = new SqlCommand(categoryFindQuery, MainWindow.con);

                MainWindow.con.Open();
                SqlDataReader r = getDataCMD.ExecuteReader();



                //check data can read and rowCount < 0
                if (r.Read() && r.HasRows)
                {
                    txtName.Text = r[0].ToString();
                    txtCode.Text = r[1].ToString();
                }
                else
                {
                    //in row count = 0 or data canot read throw err
                    throw new Exception("Enter ID");
                }


                isDataLoaded= true;

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

        private void btnEditCat_Click(object sender, EventArgs e)
        {
            try
            {
                //throw err if any txtbox empty
                if (txtName.Text =="" && txtCode.Text =="" && txtCatId.Text=="")
                {
                    throw new Exception("Input Filed Missing");
                }

                //update query
                string categoryDetailUpdateQuery = $@"UPDATE tblBookCategory
                                                    SET name ='{txtName.Text}', code ='{txtCode.Text.ToUpper()}',date_time ='{MainWindow.todayDate}',staff = '{MainWindow.systemUser}'
                                                    WHERE category_code = '{txtCatId.Text.ToUpper()}' ;" ;

                SqlCommand categoryDetailUpdateCMD = new SqlCommand(categoryDetailUpdateQuery, MainWindow.con);

                MainWindow.con.Open();
                categoryDetailUpdateCMD.ExecuteNonQuery();

                MessageBox.Show("Category details Update Succesfully");
                //After Data Update disable  grpBox
                txtName.ReadOnly = true;
                txtCode.ReadOnly = true;


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
