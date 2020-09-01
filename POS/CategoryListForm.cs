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
    public partial class CategoryListForm : Form
    {
        MySqlConnection connect;
        MySqlCommand command;
        MySqlDataReader DataReader;
        DBConnection dbconnect = new DBConnection();

        public CategoryListForm()
        {
            InitializeComponent();
            connect = new MySqlConnection();
            connect.ConnectionString = dbconnect.DataConnection();
            LoadRecords();
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            CategoryForm cf = new CategoryForm(this);
            //cf.SaveBtn.Enabled = true;
            cf.ShowDialog();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CategoryDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ColName = CategoryDataGridView.Columns[e.ColumnIndex].Name;
            if (ColName == "Edit")
            {
                CategoryForm form = new CategoryForm(this);
                form.CatIdLabel.Text = CategoryDataGridView[1, e.RowIndex].Value.ToString();
                form.CategoryNameTb.Text = CategoryDataGridView[2, e.RowIndex].Value.ToString();
                form.ShowDialog();
            }
            else // (ColName == "Delete")
            {
                 if (MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) ;
                    {
                        connect.Open();
                        command = new MySqlCommand("DELETE FROM categorytbl where id like '" + CategoryDataGridView[1, e.RowIndex].Value.ToString() + "'", connect);
                        command.ExecuteNonQuery();
                        connect.Close();
                        LoadRecords();

                    }
 
            }
   }
        public void LoadRecords()
        {
            int i = 0;
            CategoryDataGridView.Rows.Clear();
            connect.Open();
            command = new MySqlCommand("SELECT * FROM categorytbl order by category", connect);
            DataReader = command.ExecuteReader();

            while (DataReader.Read())
            {
                i += 1;
                CategoryDataGridView.Rows.Add(i, DataReader["id"].ToString(), DataReader["category"].ToString());
            }
            DataReader.Close();
            connect.Close();

        }
    }
}
