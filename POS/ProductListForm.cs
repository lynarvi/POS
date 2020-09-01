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
    public partial class ProductListForm : Form
    {
        MySqlConnection connect;
        MySqlCommand command;
        MySqlDataReader DataReader;
        DBConnection dbconnect = new DBConnection();
        string stitle = "POS System";
        

        public ProductListForm()
        {
            InitializeComponent();
            connect = new MySqlConnection();
            connect.ConnectionString = dbconnect.DataConnection();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ProductForm pf = new ProductForm(this);
            pf.SaveBtn.Enabled = true;
            pf.UpdateBtn.Enabled = false;
            pf.LoadBrand();
            pf.LoadCategory();
            pf.ShowDialog();
        }

        public void LoadRecords()
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            connect.Open();
            command = new MySqlCommand("SELECT p.pcode, p.barcode, p.pdescription, p.generic_name, b.brand, c.category, p.price, p.expiry, p.reorder FROM producttbl AS p INNER JOIN brandtbl AS b on b.id = p.brandid INNER JOIN categorytbl AS c on c.id = p.categoryid WHERE p.pdescription LIKE '" + SearchTb.Text + "%' order by p.pdescription",connect);
            DataReader = command.ExecuteReader();

            while(DataReader.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, DataReader[0].ToString(), DataReader[1].ToString(), DataReader[2].ToString(), DataReader[3].ToString(), DataReader[4].ToString(), DataReader[5].ToString(), DataReader[6].ToString(),DateTime.Parse (DataReader[7].ToString()).ToShortDateString(), DataReader[8].ToString());

            }
            DataReader.Close();
            connect.Close();
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ColName = dataGridView1.Columns[e.ColumnIndex].Name;
           
            if(ColName == "Edit")
            {
                ProductForm form = new ProductForm(this);
                form.SaveBtn.Enabled = false;
                form.UpdateBtn.Enabled = true;
                form.PCodeTb.Enabled = false;
                form.PCodeTb.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                form.Barcodetb.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                form.DescriptionTb.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                form.PriceTb.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                form.BrandCb.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                form.CategoryCb.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                form.GenericNamextxt.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                form.dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                form.ReorderTb.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                form.ShowDialog();
            }
             if (ColName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo , MessageBoxIcon.Question) == DialogResult.Yes) 
                {
                    connect.Open();
                    command = new MySqlCommand("DELETE FROM producttbl where pcode like '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "'",connect);
                    command.ExecuteNonQuery();
                    connect.Close();
                    LoadRecords();

                }
            }
        }

        private void SearchTb_TextChanged(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void SearchTb_Click(object sender, EventArgs e)
        {

        }
    }
}
