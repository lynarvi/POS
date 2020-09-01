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
    public partial class SoldItemsForm : Form
    {

        MySqlConnection connect;
        MySqlCommand command;
        MySqlDataReader DataReader;
        DBConnection dbconnect = new DBConnection();
        
        public string User;

        public SoldItemsForm()
        {
            InitializeComponent();
            connect = new MySqlConnection();
            connect.ConnectionString = dbconnect.DataConnection();
            dt1.Value = DateTime.Now;
            dt2.Value = DateTime.Now;
            //LoadRecord();
            LoadCashier();
            
            this.KeyPreview = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

       

        public void LoadRecord()
        {
           
                int i = 0;
                double _total = 0;
                DataGridView1.Rows.Clear();

                connect.Open();
                if (CashierCb.Text == "All Cashier")
                {
                    command = new MySqlCommand("SELECT c.id, c.transno, c.pcode, p.pdescription, c.price, c.qty, c.discount, c.total FROM cart_tbl AS c INNER JOIN producttbl AS p ON c.pcode = p.pcode WHERE status LIKE 'Sold' AND sdate BETWEEN '" + dt1.Value.ToString("yyyy-MM-dd") + "' AND '" + dt2.Value.ToString("yyyy-MM-dd") +"'", connect);
                }
                else
                {
                    command = new MySqlCommand("SELECT c.id, c.transno, c.pcode, p.pdescription, c.price, c.qty, c.discount, c.total FROM cart_tbl AS c INNER JOIN producttbl AS p ON c.pcode = p.pcode WHERE status LIKE 'Sold' AND sdate BETWEEN '" + dt1.Value.ToString("yyyy-MM-dd") + "' AND '" + dt2.Value.ToString("yyyy-MM-dd") + "' AND cashier LIKE '" + CashierCb.Text + "'", connect);
                }

                DataReader = command.ExecuteReader();

                while (DataReader.Read())
                {
                    i += 1;
                    _total += double.Parse(DataReader["total"].ToString());
                    DataGridView1.Rows.Add(i, DataReader["id"].ToString(), DataReader["transno"].ToString(), DataReader["pcode"].ToString(), DataReader["pdescription"].ToString(), DataReader["price"].ToString(), DataReader["qty"].ToString(), DataReader["discount"].ToString(), DataReader["total"].ToString());
                }
                DataReader.Close();
                connect.Close();

                TotalSalesTxt.Text = _total.ToString("#,##0.00");
                lblTotal.Text = dbconnect.DailySales().ToString("#,##0.00");
          
        }

        private void SoldItemsForm_Load(object sender, EventArgs e)
        {

        }

        private void dt1_ValueChanged(object sender, EventArgs e)
        {
            
           LoadRecord();
        }

        private void dt2_ValueChanged(object sender, EventArgs e)
        {
            LoadRecord();
        }

        private void PrintBtn_Click(object sender, EventArgs e)
        {
            ReportSoldForm rs = new ReportSoldForm(this);
            rs.LoadReport();
            rs.ShowDialog();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CashierCb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        public void LoadCashier()
        {
            CashierCb.Items.Clear();
            CashierCb.Items.Add("All Cashier");
            connect.Open();
            command = new MySqlCommand("SELECT * FROM users_tbl WHERE role LIKE 'Cashier'", connect);
            DataReader = command.ExecuteReader();
            while(DataReader.Read())
            {
                CashierCb.Items.Add(DataReader["username"].ToString());
            }
            DataReader.Close();
            connect.Close();
        }

        private void CashierCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRecord();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = DataGridView1.Columns[e.ColumnIndex].Name;

            if (colName == "colCancel")
            {
                CancelDetailsForm f = new CancelDetailsForm(this);
                f.IDtxt.Text = DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                f.TransnoTxt.Text = DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                f.PcodeTxt.Text = DataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                f.DescriptionTxt.Text = DataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                f.PriceTxt.Text = DataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                f.QtyTxt.Text = DataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                f.DiscountTxt.Text = DataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                f.TotalTxt.Text = DataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

                f.CancelByTxt.Text = User;
                f.ShowDialog();
            }

            //connect.Open();
            //command = new MySqlCommand("");
            //connect.Close();
        }

        

        private void SoldItemsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }
    }
}
