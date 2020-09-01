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
    public partial class StockInForm : Form
    {
        MySqlConnection connect;
        MySqlCommand command;
        MySqlDataReader DataReader;
        DBConnection dbconnect = new DBConnection();
        string stitle = "POS System";

        public StockInForm()
        {
            InitializeComponent();
            connect = new MySqlConnection();
            connect.ConnectionString = dbconnect.DataConnection();
        }

     

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void LoadStockInHistory()
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            connect.Open();
            command = new MySqlCommand("SELECT * FROM vwstockin WHERE sdate between '" + Date1.Value.ToString("yyy-MM-dd") + "' and '" + Date2.Value.ToString("yyy-MM-dd") + "' AND status LIKE 'Done'", connect);
            DataReader = command.ExecuteReader();

            while (DataReader.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, DataReader[0].ToString(), DataReader[1].ToString(), DataReader[2].ToString(), DataReader[3].ToString(), DataReader[4].ToString(), DateTime.Parse(DataReader[5].ToString()).ToShortDateString(), DataReader[6].ToString());
            }
            DataReader.Close();
            connect.Close();

        }
        public void LoadStockIn()
        {
            int i = 0;
            dataGridView2.Rows.Clear();
            connect.Open();
            command = new MySqlCommand("SELECT * FROM vwstockin WHERE refno LIKE '" + RefNoTb.Text + "' AND status LIKE 'Pending' ",connect);
            DataReader = command.ExecuteReader();

            while(DataReader.Read())
            {
                i++;
                dataGridView2.Rows.Add(i, DataReader[0].ToString(), DataReader[1].ToString(), DataReader[2].ToString(), DataReader[3].ToString(), DataReader[4].ToString(), DateTime.Parse(DataReader[5].ToString()).ToShortDateString(), DataReader[6].ToString());
            }
            DataReader.Close();
            connect.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView2.Columns[e.ColumnIndex].Name;
            if (colName == "ColDelete")
            {
                if (MessageBox.Show("Remove this item?", stitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    connect.Open();
                    command = new MySqlCommand("DELETE FROM stockintbl where id = '" + dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", connect);
                    command.ExecuteNonQuery();
                    connect.Close();
                    MessageBox.Show("Item has been successfully removed!",stitle,MessageBoxButtons.OK,MessageBoxIcon.Information);
                    LoadStockIn();
                }

            }
        }

        private void SearchTb_Click(object sender, EventArgs e)
        {

        }

        private void StockInForm_Load(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SearchProductStockinForm spf = new SearchProductStockinForm(this);
            spf.LoadProduct();
            spf.ShowDialog();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        public void Clear()
        {
            RefNoTb.Clear();
            StockByTb.Clear();
            DateTime1.Value = DateTime.Now;
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.Rows.Count > 0)
                {
                    if (MessageBox.Show("Are you sure you want to save this record?", stitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        for (int i = 0; i < dataGridView2.Rows.Count; i++)
                        {
                            //update producttbl qyt
                            connect.Open();
                            command = new MySqlCommand("UPDATE producttbl SET qty = qty + " + int.Parse(dataGridView2.Rows[i].Cells[5].Value.ToString()) + " WHERE pcode LIKE '" + dataGridView2.Rows[i].Cells[3].Value.ToString() + "'", connect);
                            command.ExecuteNonQuery();
                            connect.Close();

                            //update stockintbl qyt
                            connect.Open();
                            command = new MySqlCommand("UPDATE stockintbl SET qty = qty + " + int.Parse(dataGridView2.Rows[i].Cells[5].Value.ToString()) + ", status = 'Done' WHERE id like '" + dataGridView2.Rows[i].Cells[1].Value.ToString() + "'", connect);
                            command.ExecuteNonQuery();
                            connect.Close();

                        }

                        Clear();
                        LoadStockIn();
                    }
                }

            }
            catch(Exception ex)
            {
                connect.Close();
                MessageBox.Show(ex.Message,stitle,MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadRecordBtn_Click(object sender, EventArgs e)
        {
            LoadStockInHistory();
        }

        private void Date1_ValueChanged(object sender, EventArgs e)
        {

            Date1.Value.ToString("yyyy-MM-dd");
        }

        private void DateTime1_ValueChanged(object sender, EventArgs e)
        {
           
            
        }

        private void DateTime1_ValueChanged_1(object sender, EventArgs e)
        {
            DateTime1.Value.ToString("yyyy-MM-dd");
        }

        private void Date2_ValueChanged(object sender, EventArgs e)
        {
            Date2.Value.ToString("yyyy-MM-dd");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Random r = new Random();
            RefNoTb.Clear();
            RefNoTb.Text += "REF" + r.Next();
        }
    }
}
