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
    public partial class VoidForm : Form
    {
        MySqlConnection connect;
        MySqlCommand command;
        MySqlDataReader DataReader;
        DBConnection dbconnect = new DBConnection();
        CancelDetailsForm f;

        public VoidForm(CancelDetailsForm frm)
        {
            InitializeComponent();
            connect = new MySqlConnection();
            connect.ConnectionString = dbconnect.DataConnection();
            f = frm;
            this.KeyPreview = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void VoidBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(TxtPassword.Text != string.Empty)
                {
                    
                    string user;
                    connect.Open();
                    command = new MySqlCommand("SELECT * FROM users_tbl WHERE username = @username AND password = @password",connect);
                    command.Parameters.AddWithValue("@username",txtusername.Text);
                    command.Parameters.AddWithValue("@password", TxtPassword.Text);
                    DataReader = command.ExecuteReader();
                    DataReader.Read();

                    if(DataReader.HasRows)
                    {
                        
                        user = DataReader["username"].ToString();
                        DataReader.Close();
                        connect.Close();

                        SaveCancel(user);
                        
                        if(f.ActionCb.Text == "Yes")
                        {
                            UpdateInProduct();
                        }

                        UpdateInCart();
                        UpdateSoldItems();


                        MessageBox.Show("Successfully Cancelled!", "Cancel Purchase", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();
                        f.RefreshList();
                        f.Dispose();
                    }
                    
                    DataReader.Close();
                    connect.Close();

                  

                    
                }
            }
            catch(Exception ex)
            {
                connect.Close();
                MessageBox.Show(ex.Message,"Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                //MessageBox.Show(ex.ToString());
                
            }
        }

        private void TxtPassword_Click(object sender, EventArgs e)
        {

        }

        public void SaveCancel(string user)
        {
            connect.Open();
            command = new MySqlCommand("INSERT INTO cancel_tbl (transno,pcode,price,qty,sdate,voidby,cancelledby,reason,action) VALUES (@transno,@pcode,@price,@qty,@sdate,@voidby,@cancelledby,@reason,@action)",connect);
            command.Parameters.AddWithValue("@transno", f.TransnoTxt.Text);
            command.Parameters.AddWithValue("@pcode", f.PcodeTxt.Text);
            command.Parameters.AddWithValue("@price", double.Parse(f.PriceTxt.Text));
            command.Parameters.AddWithValue("@qty", int.Parse(f.CancelQtyTxt.Text));
            command.Parameters.AddWithValue("@sdate", DateTime.Now);
            command.Parameters.AddWithValue("@voidby", user);
            command.Parameters.AddWithValue("@cancelledby", f.CancelByTxt.Text);
            command.Parameters.AddWithValue("@reason", f.ReasonTxt.Text);
            command.Parameters.AddWithValue("@action", f.ActionCb.Text);
            command.ExecuteNonQuery();
            connect.Close();

            connect.Open();
            command = new MySqlCommand("UPDATE cancel_tbl SET total = price * qty",connect);
            command.ExecuteNonQuery();
            connect.Close();

        }

       public void UpdateInProduct()
        {
            connect.Open();
            command = new MySqlCommand("UPDATE producttbl SET qty = qty + " + int.Parse(f.CancelQtyTxt.Text) + " WHERE pcode = '" + f.PcodeTxt.Text + "'",connect);
            command.ExecuteNonQuery();
            connect.Close();

        }

        public void UpdateInCart()
       {
           connect.Open();
           command = new MySqlCommand("UPDATE cart_tbl SET qty  = qty - " + int.Parse(f.CancelQtyTxt.Text) + " WHERE id LIKE '" + f.IDtxt.Text + "'",connect);
           command.ExecuteNonQuery();
           connect.Close();

           connect.Open();
           command = new MySqlCommand("UPDATE cart_tbl SET status = 'Cancelled' WHERE qty <= 0",connect);
           command.ExecuteNonQuery();
           connect.Close(); 

       }

        public void UpdateSoldItems()
        {
            connect.Open();
            command = new MySqlCommand("UPDATE cart_tbl SET total = price * qty",connect);
            command.ExecuteNonQuery();
            connect.Close();
        }

        private void VoidForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                VoidBtn_Click(sender, e);
            }
        }
      

        
    }
}
