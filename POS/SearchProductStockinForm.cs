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
    public partial class SearchProductStockinForm : Form
    {
        MySqlConnection connect;
        MySqlCommand command;
        MySqlDataReader DataReader;
        DBConnection dbconnect = new DBConnection();
        string stitle = "Simple POS System";
        StockInForm slist;


        public SearchProductStockinForm(StockInForm flist)
        {
            InitializeComponent();
            connect = new MySqlConnection();
            connect.ConnectionString = dbconnect.DataConnection();
            slist = flist;
        }

        public void LoadProduct()
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            connect.Open();
            command = new MySqlCommand("SELECT pcode, pdescription, qty  FROM producttbl where pdescription LIKE '%" + SearchTb.Text + "%' order by pdescription", connect);
            DataReader = command.ExecuteReader();

            while (DataReader.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, DataReader[0].ToString(), DataReader[1].ToString(), DataReader[2].ToString());

            }
            DataReader.Close();
            connect.Close();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ColName = dataGridView1.Columns[e.ColumnIndex].Name; 

            if (ColName == "ColSelect")
            {
                if (slist.RefNoTb.Text == string.Empty) { MessageBox.Show("Please enter reference number", stitle, MessageBoxButtons.OK, MessageBoxIcon.Warning); slist.RefNoTb.Focus(); return; }
                if (slist.StockByTb.Text == string.Empty) { MessageBox.Show("Please enter stock in by", stitle, MessageBoxButtons.OK, MessageBoxIcon.Warning); slist.StockByTb.Focus(); return; }
                if (MessageBox.Show("Add this item?", stitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    connect.Open();
                    command = new MySqlCommand("INSERT INTO stockintbl (refno,pcode,sdate,stockinby) VALUES (@refno,@pcode,@sdate,@stockinby)", connect);//* FROM producttbl WHERE pcode LIKE '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", connect);
                    command.Parameters.AddWithValue("@refno", slist.RefNoTb.Text);
                    command.Parameters.AddWithValue("@pcode", dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    command.Parameters.AddWithValue("@sdate", slist.DateTime1.Value.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@stockinby", slist.StockByTb.Text);
                    command.ExecuteNonQuery();
                    connect.Close();


                    MessageBox.Show("Successfully added!", stitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    slist.LoadStockIn();
                }
            }
        }

        private void SearchTb_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }
    }
}
