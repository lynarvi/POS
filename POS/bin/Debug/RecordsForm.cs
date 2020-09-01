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
    public partial class RecordsForm : Form
    {
        MySqlConnection connect;
        MySqlCommand command;
        MySqlDataReader DataReader;
        DBConnection dbconnect = new DBConnection();
        public RecordsForm()
        {
            InitializeComponent();
            connect = new MySqlConnection();
            connect.ConnectionString = dbconnect.DataConnection();
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void LoadRecord()
        {
            
            int i = 0;
            DataGridView1.Rows.Clear();
            connect.Open();
            command = new MySqlCommand("SELECT pcode, pdescription, SUM(qty) AS qty FROM vwsold WHERE sdate BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' AND status LIKE 'Sold' GROUP BY pcode, pdescription ORDER BY qty DESC",connect);
            DataReader = command.ExecuteReader();

            while(DataReader.Read())
            {
                i++;
                DataGridView1.Rows.Add(i, DataReader["pcode"].ToString(), DataReader["pdescription"].ToString(), DataReader["qty"].ToString());
            }
            DataReader.Close();
            connect.Close();
        }

        public void CancelledItems()
        {
            dataGridView5.Rows.Clear();
            int i = 0;
            connect.Open();
            command = new MySqlCommand("SELECT * FROM vwcancelleditems WHERE sdate BETWEEN '" + dateTimePicker6.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker5.Value.ToString("yyyy-MM-dd") + "'",connect);
            DataReader = command.ExecuteReader();

            while(DataReader.Read())
            {
                i++;
                dataGridView5.Rows.Add(i, DataReader["transno"].ToString(), DataReader["pcode"].ToString(), DataReader["pdescription"].ToString(), DataReader["price"].ToString(), DataReader["qty"].ToString(), DataReader["total"].ToString(), DateTime.Parse (DataReader["sdate"].ToString()).ToShortDateString(), DataReader["voidby"].ToString(), DataReader["cancelledby"].ToString(), DataReader["reason"].ToString(), DataReader["action"].ToString());
            }
            DataReader.Close();
            connect.Close();

        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            LoadRecord();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView2.Rows.Clear();
                int i = 0;
                connect.Open();
                command = new MySqlCommand("SELECT c.pcode, p.pdescription, c.price, SUM(c.qty) AS total_qty, SUM(c.discount) AS total_discount, SUM(total) AS total FROM cart_tbl AS c INNER JOIN producttbl AS p ON c.pcode = p.pcode WHERE status LIKE 'Sold' AND  sdate BETWEEN '" + dateTimePicker4.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker3.Value.ToString("yyyy-MM-dd") + "'  GROUP BY p.pcode, p.pdescription, c.price", connect);
                DataReader = command.ExecuteReader();

                while (DataReader.Read())
                {
                    i++;
                    dataGridView2.Rows.Add(i, DataReader["pcode"].ToString(), DataReader["pdescription"].ToString(), Double.Parse(DataReader["price"].ToString()).ToString("#,##0.00"), DataReader["total_qty"].ToString(), DataReader["total_discount"].ToString(), Double.Parse(DataReader["total"].ToString()).ToString("#,##0.00"));
                }
                DataReader.Close();
                connect.Close();

                String x;
                connect.Open();
                command = new MySqlCommand("SELECT SUM(total) FROM cart_tbl WHERE status LIKE 'Sold' AND  sdate BETWEEN '" + dateTimePicker4.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker3.Value.ToString("yyyy-MM-dd") + "'", connect);
                TotalLb.Text = Double.Parse(command.ExecuteScalar().ToString()).ToString("#,##0.00");
                connect.Close();
            }
            catch(Exception ex)
            {
                connect.Close();
                MessageBox.Show(ex.Message,"Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        public void LoadInvertory()
        {
            int i = 0;
            dataGridView4.Rows.Clear();
            connect.Open();
            command = new MySqlCommand("SELECT p.pcode, p.barcode, p.pdescription, b.brand, c.category, p.price, p.qty, p.reorder FROM producttbl AS p INNER JOIN brandtbl AS b ON p.brandid = b.id INNER JOIN categorytbl AS c ON p.categoryid = c.id",connect);
            DataReader = command.ExecuteReader();

            while(DataReader.Read())
            {
                i++;
                dataGridView4.Rows.Add(i, DataReader["pcode"].ToString(), DataReader["barcode"].ToString(), DataReader["pdescription"].ToString(), DataReader["brand"].ToString(), DataReader["category"].ToString(), DataReader["price"].ToString(), DataReader["reorder"].ToString(), DataReader["qty"].ToString());
            }
            DataReader.Close();
            connect.Close();
        }

        public void LoadCriticalItems()
        {
            try
            {
                
                dataGridView3.Rows.Clear();
                int i = 0;
                connect.Open();
                command = new MySqlCommand("SELECT * FROM vwCriticalItems",connect);
                DataReader = command.ExecuteReader();

                while(DataReader.Read())
                {
                    i++;
                    dataGridView3.Rows.Add(i, DataReader["pcode"].ToString(), DataReader["barcode"].ToString(),DataReader["pdescription"].ToString(),DataReader["brand"].ToString(),DataReader["category"].ToString(),DataReader["price"].ToString(),DataReader["reorder"].ToString(),DataReader["qty"].ToString());
                }
                DataReader.Close();
                connect.Close();
            }
            catch(Exception ex)
            {
                connect.Close();
                MessageBox.Show(ex.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void PrintPreview_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            InventoryReportForm i = new InventoryReportForm();
            i.LoadReport();
            i.ShowDialog();
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            CancelledItems();
        }
    }
}
