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
    public partial class QtyForm : Form
    {
        MySqlConnection connect;
        MySqlCommand command;
        MySqlDataReader DataReader;
        DBConnection dbconnect = new DBConnection();

        private String pcode;
        private double price;
        private int qty;
        private String transno;

        string stitle = "POS System";
        PosForm fpos;

        public QtyForm(PosForm frmpos)
        {
            InitializeComponent();
            connect = new MySqlConnection();
            connect.ConnectionString = dbconnect.DataConnection();
            fpos = frmpos;
        }

        public void ProductDetails(String pcode, double price, String transno, int qty)
        {
            this.pcode = pcode;
            this.price = price;
            this.transno = transno;
            this.qty = qty;
       
            
        }

        private void QtyForm_Load(object sender, EventArgs e)
        {
            
        }

        private void QtyTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((e.KeyChar == 13) && (QtyTb.Text != String.Empty))
                {
                    String id = "";
                    int cart_qty = 0;
                    bool found = false;


                    connect.Open();
                    command = new MySqlCommand("SELECT * FROM cart_tbl WHERE transno = @transno AND pcode = @pcode ", connect);
                    command.Parameters.AddWithValue("@transno", fpos.TransNoLbl.Text);
                    command.Parameters.AddWithValue("@pcode", pcode);
                    DataReader = command.ExecuteReader();
                    DataReader.Read();

                    if (DataReader.HasRows)
                    {
                        found = true;
                        id = DataReader["id"].ToString();
                        cart_qty = int.Parse(DataReader["qty"].ToString());
                    }
                    else
                    {
                        found = false;
                    }
                    DataReader.Close();
                    connect.Close();

                    if (found == true)
                    {
                        if (qty < (int.Parse(QtyTb.Text) + cart_qty))
                        {
                            MessageBox.Show("Unable to proceed. remaining qty on hand is " + qty, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        connect.Open();
                        command = new MySqlCommand("UPDATE cart_tbl SET qty = (qty + " + int.Parse(QtyTb.Text) + ") WHERE id =  '" + id + "'", connect);
                        command.ExecuteNonQuery();
                        connect.Close();

                        //total

                        connect.Open();
                        command = new MySqlCommand("UPDATE cart_tbl SET total = (price * qty)", connect);
                        command.ExecuteNonQuery();
                        connect.Close();

                        fpos.SearchTb.Clear();
                        fpos.SearchTb.Focus();
                        fpos.LoadCart();
                        this.Dispose();
                    }
                    else
                    {
                        if (qty < int.Parse(QtyTb.Text))
                        {
                            MessageBox.Show("Unable to proceed. remaining qty on hand is " + qty, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        connect.Open();
                        command = new MySqlCommand("INSERT INTO cart_tbl (transno, pcode, price, qty, sdate, cashier) VALUES (@transno, @pcode, @price, @qty, @sdate, @cashier)", connect);
                        command.Parameters.AddWithValue("@transno", transno);
                        command.Parameters.AddWithValue("@pcode", pcode);
                        command.Parameters.AddWithValue("@price", price);
                        command.Parameters.AddWithValue("@qty", int.Parse(QtyTb.Text));
                        command.Parameters.AddWithValue("@sdate", DateTime.Now);
                        command.Parameters.AddWithValue("@cashier", fpos.usernamelbl.Text);
                        command.ExecuteNonQuery();
                        connect.Close();

                        //total

                        connect.Open();
                        command = new MySqlCommand("UPDATE cart_tbl SET total = (price * qty)", connect);
                        command.ExecuteNonQuery();
                        connect.Close();

                        fpos.SearchTb.Clear();
                        fpos.SearchTb.Focus();
                        fpos.LoadCart();
                        this.Dispose();
                    }

                 }
        }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void QtyTb_TextChanged(object sender, EventArgs e)
        {

        }

      
    }
}
