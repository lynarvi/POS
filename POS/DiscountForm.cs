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
    public partial class DiscountForm : Form
    {
        MySqlConnection connect;
        MySqlCommand command;
        MySqlDataReader DataReader;
        DBConnection dbconnect = new DBConnection();
        //string stitle = "POS System";
        PosForm f;
       

        public DiscountForm(PosForm form)
        {
            InitializeComponent();
            connect = new MySqlConnection();
            connect.ConnectionString = dbconnect.DataConnection();

            f = form;
            this.KeyPreview = true;
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void PercentTb_TextChanged(object sender, EventArgs e)
        {

            try
            {
                
                //string _SCName = SeniorName.Text;
                //string _SCId = SeniorIdtxt.Text;
                double discount = Double.Parse(PriceTb.Text) * (Double.Parse(PercentTb.Text) / 100);
                AmountTb.Text = discount.ToString("#,##0.00");
                

            }
            catch (Exception ex)
            {

                AmountTb.Text = "0.00";
            }
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string sdate = DateTime.Now.ToString("yyyy-MM-dd");

                if (MessageBox.Show("Add Discount? click yes to confirm.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    if (SeniorName.Text == String.Empty)
                    {
                        //connect.Open();
                        //command = new MySqlCommand("UPDATE cart_tbl SET discount = @discount WHERE id = @id", connect);
                        //command.Parameters.AddWithValue("@discount", Double.Parse(AmountTb.Text));
                        //command.Parameters.AddWithValue("@id", int.Parse(IDlbl.Text));
                        //command.ExecuteNonQuery();
                        //connect.Close();

                        //connect.Open();
                        //command = new MySqlCommand("UPDATE cart_tbl SET total = @total - @discount WHERE id = @id", connect);
                        //command.Parameters.AddWithValue("@total", double.Parse(PriceTb.Text));
                        //command.Parameters.AddWithValue("@discount", double.Parse(AmountTb.Text));
                        //command.Parameters.AddWithValue("@id", int.Parse(IDlbl.Text));
                        //command.ExecuteNonQuery();
                        //connect.Close();

                        connect.Open();
                        command = new MySqlCommand("INSERT INTO discounts (transno,discount,sdate) VALUES (@transno,@discount,@sdate)", connect);
                        command.Parameters.AddWithValue("@transno", f.TransNoLbl.Text);
                        command.Parameters.AddWithValue("@discount", AmountTb.Text);
                        command.Parameters.AddWithValue("@sdate",sdate);
                        command.ExecuteNonQuery();
                        connect.Close();

                        connect.Open();
                        command = new MySqlCommand("INSERT INTO discounted_tbl (transno,discount,discounted_price,sdate) VALUES (@transno,@discount,@discounted_price,@sdate)", connect);
                        command.Parameters.AddWithValue("@transno", f.TransNoLbl.Text);
                        command.Parameters.AddWithValue("@discount",double.Parse(PercentTb.Text)/100);
                        command.Parameters.AddWithValue("@discounted_price", AmountTb.Text);
                        command.Parameters.AddWithValue("@sdate",sdate);
                        command.ExecuteNonQuery();
                        connect.Close();

                        
                    }
                        

                    else
                    {

                        //connect.Open();
                        //command = new MySqlCommand("UPDATE cart_tbl SET discount = @discount WHERE id = @id", connect);
                        //command.Parameters.AddWithValue("@discount", Double.Parse(AmountTb.Text));
                        //command.Parameters.AddWithValue("@id", int.Parse(IDlbl.Text));
                        //command.ExecuteNonQuery();
                        //connect.Close();    

                        connect.Open();
                        command = new MySqlCommand("INSERT INTO discounts (transno,discount,sdate) VALUES (@transno,@discount,@sdate)", connect);
                        command.Parameters.AddWithValue("@transno", f.TransNoLbl.Text);
                        command.Parameters.AddWithValue("@discount", AmountTb.Text);
                        command.Parameters.AddWithValue("@sdate", sdate);
                        command.ExecuteNonQuery();
                        connect.Close();

                        connect.Open();
                        command = new MySqlCommand("INSERT INTO discounted_tbl (transno,name,id_no,discount,discounted_price,sdate) VALUES (@transno,@name,@id_no,@discount,@discounted_price,@sdate)", connect);
                        command.Parameters.AddWithValue("@transno", f.TransNoLbl.Text);
                        command.Parameters.AddWithValue("@name",SeniorName.Text);
                        command.Parameters.AddWithValue("@id_no", SeniorIdtxt.Text);
                        command.Parameters.AddWithValue("@discount", double.Parse(PercentTb.Text)/100);
                        command.Parameters.AddWithValue("@discounted_price", AmountTb.Text);
                        command.Parameters.AddWithValue("@sdate", sdate);
                        command.ExecuteNonQuery();
                        connect.Close();

                        f.label4.Visible = true;
                        f.label5.Visible = true;
                        f.senioridtxt.Visible = true;
                        f.seniornametxt.Visible = true;
                        f.seniornametxt.Text = SeniorName.Text;
                        f.senioridtxt.Text = SeniorIdtxt.Text;
                        //f.LoadCart();
                        //this.Dispose();
                    }

                    f.LoadCart();
                    this.Dispose();
                  
                }
            }
            catch (Exception ex)
            {
                connect.Close();
                MessageBox.Show(ex.Message);
            }
            f.LoadCart();
            this.Dispose();
        }

        private void DiscountForm_Load(object sender, EventArgs e)
        {

        }

        private void DiscountForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                ConfirmBtn_Click(sender, e);
            }
        }

        private void PriceTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
