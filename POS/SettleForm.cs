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
    public partial class SettleForm : Form
    {
        PosForm fpos;
        MySqlConnection connect;
        MySqlCommand command;
        MySqlDataReader DataReader;
        DBConnection dbconnect = new DBConnection();
        
        public SettleForm(PosForm fp)
        {
            InitializeComponent();
            connect = new MySqlConnection();
            connect.ConnectionString = dbconnect.DataConnection();
            fpos = fp;
            this.KeyPreview = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void CashTxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double sale = double.Parse(SalesTxt.Text);
                double cash = double.Parse(CashTxt.Text);
                double change = cash - sale;
                ChangeTxt.Text = change.ToString("#,##0.00");
            }
            catch(Exception ex)
            {
                ChangeTxt.Text = "0.00";
            }
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            CashTxt.Text += btn7.Text;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            CashTxt.Text += btn8.Text;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            CashTxt.Text += btn9.Text;
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            CashTxt.Clear();
            CashTxt.Focus();

        }

        private void btn4_Click(object sender, EventArgs e)
        {
            CashTxt.Text += btn4.Text;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            CashTxt.Text += btn5.Text;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            CashTxt.Text += btn6.Text;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            CashTxt.Text += btn0.Text;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            CashTxt.Text += btn1.Text;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            CashTxt.Text += btn2.Text;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            CashTxt.Text += btn3.Text;
        }

        private void btn00_Click(object sender, EventArgs e)
        {
            CashTxt.Text += btn00.Text;
        }

        private void btnenter_Click(object sender, EventArgs e)
        {
            try
            {
                if ((double.Parse(ChangeTxt.Text) < 0) || (CashTxt.Text == String.Empty))
                {
                    MessageBox.Show("Insufficient amount, please enter the correct amount!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {

                    for (int i = 0; i < fpos.dataGridView1.Rows.Count; i++)
                    {
                        connect.Open();
                        command = new MySqlCommand("UPDATE producttbl SET qty = qty - " + int.Parse(fpos.dataGridView1.Rows[i].Cells[6].Value.ToString()) + " WHERE pcode =  '" + fpos.dataGridView1.Rows[i].Cells[2].Value.ToString() + "'", connect);
                        command.Parameters.AddWithValue("@transno", fpos.TransNoLbl.Text);
                        command.ExecuteNonQuery();
                        connect.Close();

                        connect.Open();
                        command = new MySqlCommand("UPDATE cart_tbl SET status = 'Sold' WHERE id = '" + (fpos.dataGridView1.Rows[i].Cells[1].Value.ToString()) + "'", connect);
                        command.ExecuteNonQuery();
                        connect.Close();

                    }


                    if (fpos.seniornametxt.Text == String.Empty)
                    {
                        fpos.SoldTotal();
                        ReceiptForm rf = new ReceiptForm(fpos);
                        rf.LoadReport(CashTxt.Text, ChangeTxt.Text);
                        rf.ShowDialog();

                        MessageBox.Show("Payment successfully saved!", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fpos.GetTransNo();
                        fpos.TotalLbl.Text = "0.00";
                        fpos.TotalSalestxt.Text = "0.00";
                        fpos.LoadCart();
                        this.Dispose();
                        fpos.senioridtxt.Visible = false; fpos.seniornametxt.Visible = false; fpos.label4.Visible = false; fpos.label5.Visible = false;

                    }
                    else
                    {
                        fpos.SoldTotal();
                        SeniorReceipt s = new SeniorReceipt(fpos);
                        s.LoadReport(CashTxt.Text, ChangeTxt.Text);
                        s.ShowDialog();

                        ReceiptForm r = new ReceiptForm(fpos);
                        r.LoadReport(CashTxt.Text, ChangeTxt.Text);
                        r.ShowDialog();

                        MessageBox.Show("Payment successfully saved!", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fpos.GetTransNo();
                        fpos.LoadCart();
                        this.Dispose();
                        fpos.senioridtxt.Visible = false; fpos.seniornametxt.Visible = false; fpos.label4.Visible = false; fpos.label5.Visible = false;
                    }
                   


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("Insufficient amount, please enter the correct amount!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void SettleForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
            if (e.KeyCode == Keys.Enter)
            {
                btnenter_Click(sender, e);
            }
        }
    }
}
