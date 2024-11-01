using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LibSys
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //SqlPublic Connection
      /*  public SqlConnection con = new SqlConnection();
        //public Dataset for store user athendication data
        public DataSet ds = new DataSet();
      
        */
        
        private void btnTest_Click(object sender, EventArgs e)
        {
            /*  //Setting up SqlConnection
              con.ConnectionString = @"Data Source=LAPTOP-URNGUL0F;Initial Catalog=libSysData;Integrated Security=True";
              string sqlCheckUserQuery = $"SELECT user_name , password FROM tblSystemUsers WHERE user_name = '{txtUserName.Text.ToString()}' and password = '{txtPassword.Text.ToString()}' ;";
              //set sql query and connection to sql command
              SqlCommand cmd = new SqlCommand(sqlCheckUserQuery,con);
              //open Sql connection
              con.Open();
              //DataAdapter To get DataFrom DataBase
              SqlDataAdapter da = new SqlDataAdapter(cmd);
              da.Fill(ds, "tblCurrentUser");
              //Connection Close
              da.Dispose();
              cmd.Dispose();
              con.Close();

              //check datset table "tblCurrentUser" rows
              if (ds.Tables["tblCurrentUser"].Rows.Count != 0)
              {

                  //if Password match the DataBase Data Open MainWindow
                  if (txtUserName.Text.ToString() == ds.Tables["tblCurrentUser"].Rows[0].ItemArray[0].ToString() && txtPassword.Text.ToString() == ds.Tables["tblCurrentUser"].Rows[0].ItemArray[1].ToString())
                  {
                      AppForms.MainWindow mainWindow = new AppForms.MainWindow();
                      mainWindow.Show();
                      this.Hide();
                  }
                  else
                  { 

                      ds.Tables["tblCurrentUser"].Clear();
                      MessageBox.Show("Email and Password Incorrect.Try Agani");
                  }


              }
              else {
                  //Catch DataSet row unfill Err
                  MessageBox.Show("Email and Password Incorrect.Try Agani");

              }

              */

            AppForms.MainWindow mainWindow = new AppForms.MainWindow();
            mainWindow.Show();
            this.Hide();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           
            
        }
    }
    }

