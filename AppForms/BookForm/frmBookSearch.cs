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
    public partial class frmBookSearch : Form
    {
        public frmBookSearch()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            /*
             Library Code
                Book Name
                Auther Name
                Publisher Name
                Year
                ISBN
                Category Name
                Caregory Code*/
            string searchQuery;
            DataTable result = new DataTable();
            try {
                if (cmbType.Text == "Library Code")
                {

                    searchQuery = $@"SELECT tblBookList.library_code,tblBookList.name AS book_name,tblAuthor.name AS author_name,tblPublisher.name AS publisher_name,tblBookList.year,tblBookList.isbn,tblBookList.price,tblBookCategory.name AS category_name,tblBookCategory.code,tblBookList.availability
                                FROM tblBookList 
                                JOIN tblAuthor ON tblBookList.author = tblAuthor.author_id
                                JOIN tblPublisher ON tblBookList.publisher = tblPublisher.publisher_id
                                JOIN tblBookCategory ON tblBookList.category = tblBookCategory.category_code
                                WHERE tblBookList.library_code = '{txtValue.Text.ToUpper()}';
                                ";
                }
                else if (cmbType.Text == "Book Name")
                {

                    searchQuery = $@"SELECT tblBookList.library_code,tblBookList.name AS book_name,tblAuthor.name AS author_name,tblPublisher.name AS publisher_name,tblBookList.year,tblBookList.isbn,tblBookList.price,tblBookCategory.name AS category_name,tblBookCategory.code,tblBookList.availability
                                FROM tblBookList 
                                JOIN tblAuthor ON tblBookList.author = tblAuthor.author_id
                                JOIN tblPublisher ON tblBookList.publisher = tblPublisher.publisher_id
                                JOIN tblBookCategory ON tblBookList.category = tblBookCategory.category_code
                                WHERE tblBookList.name LIKE '%{txtValue.Text.ToUpper()}%';
                                ";
                }
                else if (cmbType.Text == "Publisher Name")
                {

                    searchQuery = $@"SELECT tblBookList.library_code,tblBookList.name AS book_name,tblAuthor.name AS author_name,tblPublisher.name AS publisher_name,tblBookList.year,tblBookList.isbn,tblBookList.price,tblBookCategory.name AS category_name,tblBookCategory.code,tblBookList.availability
                                FROM tblBookList 
                                JOIN tblAuthor ON tblBookList.author = tblAuthor.author_id
                                JOIN tblPublisher ON tblBookList.publisher = tblPublisher.publisher_id
                                JOIN tblBookCategory ON tblBookList.category = tblBookCategory.category_code
                                WHERE tblPublisher.name LIKE '%{txtValue.Text.ToUpper()}%';
                                ";
                }
                else if (cmbType.Text == "Auther Name")
                {

                    searchQuery = $@"SELECT tblBookList.library_code,tblBookList.name AS book_name,tblAuthor.name AS author_name,tblPublisher.name AS publisher_name,tblBookList.year,tblBookList.isbn,tblBookList.price,tblBookCategory.name AS category_name,tblBookCategory.code,tblBookList.availability
                                FROM tblBookList 
                                JOIN tblAuthor ON tblBookList.author = tblAuthor.author_id
                                JOIN tblPublisher ON tblBookList.publisher = tblPublisher.publisher_id
                                JOIN tblBookCategory ON tblBookList.category = tblBookCategory.category_code
                                WHERE tblAuthor.name LIKE '%{txtValue.Text.ToUpper()}%';
                                ";
                }
                else if (cmbType.Text == "Year")
                {
                    searchQuery = $@"SELECT tblBookList.library_code,tblBookList.name AS book_name,tblAuthor.name AS author_name,tblPublisher.name AS publisher_name,tblBookList.year,tblBookList.isbn,tblBookList.price,tblBookCategory.name AS category_name,tblBookCategory.code,tblBookList.availability
                                FROM tblBookList 
                                JOIN tblAuthor ON tblBookList.author = tblAuthor.author_id
                                JOIN tblPublisher ON tblBookList.publisher = tblPublisher.publisher_id
                                JOIN tblBookCategory ON tblBookList.category = tblBookCategory.category_code
                                WHERE tblBookList.year = '{txtValue.Text.ToUpper()}';
                                ";
                }
                else if (cmbType.Text == "ISBN")
                {

                    searchQuery = $@"SELECT tblBookList.library_code,tblBookList.name AS book_name,tblAuthor.name AS author_name,tblPublisher.name AS publisher_name,tblBookList.year,tblBookList.isbn,tblBookList.price,tblBookCategory.name AS category_name,tblBookCategory.code,tblBookList.availability
                                FROM tblBookList 
                                JOIN tblAuthor ON tblBookList.author = tblAuthor.author_id
                                JOIN tblPublisher ON tblBookList.publisher = tblPublisher.publisher_id
                                JOIN tblBookCategory ON tblBookList.category = tblBookCategory.category_code
                                WHERE tblBookList.isbn = '{txtValue.Text.ToUpper()}';
                                ";
                }
                else if (cmbType.Text == "Category Name")
                {

                    searchQuery = $@"SELECT tblBookList.library_code,tblBookList.name AS book_name,tblAuthor.name AS author_name,tblPublisher.name AS publisher_name,tblBookList.year,tblBookList.isbn,tblBookList.price,tblBookCategory.name AS category_name,tblBookCategory.code,tblBookList.availability
                                FROM tblBookList 
                                JOIN tblAuthor ON tblBookList.author = tblAuthor.author_id
                                JOIN tblPublisher ON tblBookList.publisher = tblPublisher.publisher_id
                                JOIN tblBookCategory ON tblBookList.category = tblBookCategory.category_code
                                WHERE tblBookCategory.name LIKE '%{txtValue.Text.ToUpper()}%';
                                ";
                }
                else if (cmbType.Text == "Caregory Code")
                {

                    searchQuery = $@"SELECT tblBookList.library_code,tblBookList.name AS book_name,tblAuthor.name AS author_name,tblPublisher.name AS publisher_name,tblBookList.year,tblBookList.isbn,tblBookList.price,tblBookCategory.name AS category_name,tblBookCategory.code,tblBookList.availability
                                FROM tblBookList 
                                JOIN tblAuthor ON tblBookList.author = tblAuthor.author_id
                                JOIN tblPublisher ON tblBookList.publisher = tblPublisher.publisher_id
                                JOIN tblBookCategory ON tblBookList.category = tblBookCategory.category_code
                                WHERE tblBookCategory.code = '{txtValue.Text.ToUpper()}';
                                ";
                }
                else
                {
                    searchQuery = $"";
                    throw new Exception("Invalide Selection");

                }

                MainWindow.con.Open();
                SqlDataAdapter newAdapter = new SqlDataAdapter(searchQuery, MainWindow.con);

                newAdapter.Fill(result);

                //datadate connect to dagaGridViwe
                dgvData.DataSource = result;



            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally {
                MainWindow.con.Close();
            }


        }
    }
}
