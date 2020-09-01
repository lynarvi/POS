using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace POS
{
    public partial class CategoryForm : Form
    {
        MySqlConnection connect;
        MySqlCommand command;
        MySqlDataReader DataReader;
        DBConnection dbconnect = new DBConnection();
        CategoryListForm categlist;

        public CategoryForm(CategoryListForm clist)
        {
            InitializeComponent();
            connect = new MySqlConnection();
            connect.ConnectionString = dbconnect.DataConnection();
            categlist = clist;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this category?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    connect.Open();
                    command = new MySqlCommand("INSERT INTO categorytbl(category) VALUES (@category)", connect);
                    command.Parameters.AddWithValue("@category", CategoryNameTb.Text);
                    command.ExecuteNonQuery();
                    connect.Close();
                    MessageBox.Show("Record has been saved!");
                    Clear();
                    categlist.LoadRecords();
                }
            }
            catch (Exception ex)
            {
                connect.Close();
                MessageBox.Show(ex.Message);

            }
        }

        private void Clear()
        {
            SaveBtn.Enabled = true;
            CategoryNameTb.Text = "";
            CategoryNameTb.Focus();



        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
             try
            {
                if (MessageBox.Show("Are you you sure to update this category?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
                connect.Open();
                command = new MySqlCommand("UPDATE categorytbl SET category = @category where id like '" + CatIdLabel.Text + "'",connect);
                command.Parameters.AddWithValue("@category",CategoryNameTb.Text);
               
                command.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("Category has been successfully updated!");
                Clear();
                categlist.LoadRecords();
                this.Dispose();


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {

        }
    }
}
