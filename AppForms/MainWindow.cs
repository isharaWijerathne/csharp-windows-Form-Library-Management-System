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

namespace LibSys.AppForms
{
    public partial class MainWindow : Form
    {
        //variable to hold active form
        Form activeForm;
        public MainWindow()
        {
            InitializeComponent();
        }

        //SqlPublic Connection
        public static SqlConnection con = new SqlConnection();
        //public Dataset for store user athendication data
        public static DataSet ds = new DataSet();
        //SystemUser
        public static string systemUser;
        public static string todayDate = $"{DateTime.Now.ToString("yyyy-MM-dd")}";



        //Desktop panal manage method
        public  void openChildForm(Form childForm) {
            //if any form loaded to desktop panal close it first
            if (activeForm != null) {
                activeForm.Close();
            }

            //open new form in desktop panal
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            //Desktop panale name as pnlDesktop
            this.pnlDesktop.Controls.Add(childForm);
            this.pnlDesktop.Tag= childForm;
            childForm.BringToFront();
            childForm.Show();

           
        }

        private void createNewMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new AppForms.MemberForm.frmNewMember());
        }

        private void editMemberDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new AppForms.MemberForm.frmEditMember());
        }

        private void membershipUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new AppForms.MemberForm.frmMebUpgrade());
        }

        private void annualSubscriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new AppForms.MemberForm.frmSearchMember());
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void accountTypeSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void annualSubscriptionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openChildForm(new AppForms.MemberForm.frmSubscription()); ;
        }

        private void addNewBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new AppForms.BookForm.frmAddNewBook());
        }

        private void editBookDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new AppForms.BookForm.frmEditViewBook()); ;
        }

        private void addNewCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new AppForms.BookForm.frmAddNewCategory()) ;
        }

        private void editCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new AppForms.BookForm.frmEditCategory());
        }

        private void bookCategoryListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new AppForms.BookForm.frmBookCatList());
        }

        private void addAuthorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new AppForms.BookForm.frmAddAuthor());
        }

        private void editAuthorDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new AppForms.BookForm.frmEditAuthor()) ;
        }

        private void searchAuthorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new AppForms.BookForm.frmSearchAuthor()); ;
        }

        private void addPublisherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new AppForms.BookForm.frmAddNewPublisher());
        }

        private void editPublisherDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new AppForms.BookForm.frmEditPublisher());
        }

        private void searchPublisherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new AppForms.BookForm.frmSearchPublisher()); ;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            openChildForm(new AppForms.BookForm.frmBookSearch()); ;
        }

        private void bookIssueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new AppForms.BIService.frmBookIssue());
        }

        private void bookReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new AppForms.BIService.frmBookReturn()); 
        }

        private void bookTrakingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new AppForms.BIService.frmBookTracking()); ;
        }

        private void fineToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }



        public void LogOut() {
            if (activeForm != null)
            {
                activeForm.Close();
                menuStripMain.Enabled = false;
                lblLinkUseShow.Text = "";
                lblLinkUseShow.Visible = false;
                grpAuth.Visible = true;

                toolStripButton2.Enabled= false;
                tsHome.Enabled = false;
                ds.Tables["tblCurrentUser"].Clear();

            }
            else{
                menuStripMain.Enabled = false;
                lblLinkUseShow.Text = "";
                lblLinkUseShow.Visible = false;
                grpAuth.Visible = true;

                toolStripButton2.Enabled = false;
                tsHome.Enabled = false;
                ds.Tables["tblCurrentUser"].Clear();


            }
        }
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Show LogForm


            LogOut();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            try {
                //Setting up SqlConnection         Server=LAPTOP-URNGUL0F;Database=libSysData;Trusted_Connection=True;
                con.ConnectionString = @";";
                string sqlCheckUserQuery = $"SELECT user_name , password, type FROM tblSystemUsers WHERE user_name = '{txtUserName.Text.ToString()}' and password = '{txtPassword.Text.ToString()}' ;";
                //set sql query and connection to sql command
                SqlCommand cmd = new SqlCommand(sqlCheckUserQuery, con);
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
                        menuStripMain.Enabled = true;
                        systemUser = ds.Tables["tblCurrentUser"].Rows[0].ItemArray[0].ToString();
                        lblLinkUseShow.Text = $"{ds.Tables["tblCurrentUser"].Rows[0].ItemArray[0].ToString()} ({ds.Tables["tblCurrentUser"].Rows[0].ItemArray[2].ToString()}) ";
                        lblLinkUseShow.Visible = true;

                        MessageBox.Show("Welcome");

                        txtUserName.Text = "";
                        txtPassword.Text = "";
                        grpAuth.Visible = false;
                        tsLogOut.Enabled = true;
                        toolStripButton2.Enabled = true;

                        tsHome.Enabled = true;
                        menuStripMain.Enabled = true;

                        if (ds.Tables["tblCurrentUser"].Rows[0].ItemArray[2].ToString() == "ADMIN")
                        {

                            tsHome.Enabled = true;
                            menuStripMain.Enabled = true;

                        }
                        else if (ds.Tables["tblCurrentUser"].Rows[0].ItemArray[2].ToString() == "STANDEARD")
                        {

                            tsHome.Enabled = true;
                            menuStripMain.Enabled = true;

                            addAuthorToolStripMenuItem.Enabled = false;
                            editAuthorDetailsToolStripMenuItem.Enabled = false;
                            addPublisherToolStripMenuItem.Enabled = false;
                            editPublisherDetailsToolStripMenuItem.Enabled = false;
                            editBookDetailsToolStripMenuItem.Enabled = false;
                            addNewCategoryToolStripMenuItem.Enabled = false;
                            editCategoryToolStripMenuItem.Enabled = false;
                            reportsToolStripMenuItem.Enabled = false;



                        }
                        else if (ds.Tables["tblCurrentUser"].Rows[0].ItemArray[2].ToString() == "LIMITED")
                        {

                            createNewMemberToolStripMenuItem.Enabled = false;
                            editMemberDetailsToolStripMenuItem.Enabled = false;
                            membershipUpdateToolStripMenuItem.Enabled = false;

                            addNewBookToolStripMenuItem.Enabled = false;
                            editBookDetailsToolStripMenuItem.Enabled = false;
                            addNewCategoryToolStripMenuItem.Enabled = false;
                            editCategoryToolStripMenuItem.Enabled = false;
                            addAuthorToolStripMenuItem.Enabled = false;
                            editAuthorDetailsToolStripMenuItem.Enabled = false;
                            addPublisherToolStripMenuItem.Enabled = false;
                            editPublisherDetailsToolStripMenuItem.Enabled = false;

                            toolStripMenuItem1.Enabled = false;
                            paymentToolStripMenuItem.Enabled = false;
                            reportsToolStripMenuItem.Enabled = false;

                            tsbAddmember.Enabled = false;
                            tsbEditMember.Enabled = false;
                            tsbAddNewBook.Enabled = false;
                            tsbBookIsue.Enabled = false;
                            tsbBookreturn.Enabled = false;






                        }
                    }
                    else
                    {

                        ds.Tables["tblCurrentUser"].Clear();
                        MessageBox.Show("Email and Password Incorrect.Try Agani");
                    }


                }
                else
                {
                    //Catch DataSet row unfill Err
                    MessageBox.Show("Email and Password Incorrect.Try Agani");

                }


            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblLinkUseShow_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void tsbAddmember_Click(object sender, EventArgs e)
        {
            openChildForm(new AppForms.MemberForm.frmNewMember());
        }

        private void tsbEditMember_Click(object sender, EventArgs e)
        {
            openChildForm(new AppForms.MemberForm.frmEditMember());
        }

        private void tsbSearcMember_Click(object sender, EventArgs e)
        {
            openChildForm(new AppForms.MemberForm.frmSearchMember());
        }

        private void tsbAddNewBook_Click(object sender, EventArgs e)
        {
            openChildForm(new AppForms.BookForm.frmAddNewBook());
        }

        private void tsbBookCatList_Click(object sender, EventArgs e)
        {
            openChildForm(new AppForms.BookForm.frmBookCatList());
        }

        private void tsbPublisherList_Click(object sender, EventArgs e)
        {
            openChildForm(new AppForms.BookForm.frmSearchPublisher());
        }

        private void tsbAuthorLsit_Click(object sender, EventArgs e)
        {
            openChildForm(new AppForms.BookForm.frmSearchAuthor());
        }

        private void tsbSerBook_Click(object sender, EventArgs e)
        {
            openChildForm(new AppForms.BookForm.frmBookSearch()); ;
        }

        private void tsbBookIsue_Click(object sender, EventArgs e)
        {
            openChildForm(new AppForms.BIService.frmBookIssue());
        }

        private void tsbBookreturn_Click(object sender, EventArgs e)
        {
            openChildForm(new AppForms.BIService.frmBookReturn());
        }

        private void tsbBookTrack_Click(object sender, EventArgs e)
        {
            openChildForm(new AppForms.BIService.frmBookTracking());
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LogOut();
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
    }

