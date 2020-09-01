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
using Tulpep.NotificationWindow;
namespace POS
{
    public partial class PosForm : Form
    {
        String id;
        String price;
        MySqlConnection connect;
        MySqlCommand command;
        MySqlDataReader DataReader;
        DBConnection dbconnect = new DBConnection();
        string stitle = "POS System";
        int qty;
        LoginPage f;

        public PosForm(LoginPage frm)
        {
            InitializeComponent();
            DateLbl.Text = DateTime.Now.ToLongDateString();
            connect = new MySqlConnection();
            connect.ConnectionString = dbconnect.DataConnection();
            this.KeyPreview = true;
            f = frm;
            
            DiscountBtn.Enabled = false;
            NotifyCriticalItems(); 
            
        }

        public void NotifyCriticalItems()
        {
            string critical = "";

            connect.Open();
            command = new MySqlCommand("SELECT COUNT(*) FROM vwcriticalitems", connect);
            string count = command.ExecuteScalar().ToString();
            connect.Close();

            int i = 0;
            connect.Open();
            command = new MySqlCommand("SELECT * FROM vwcriticalitems", connect);
            DataReader = command.ExecuteReader();
            while (DataReader.Read())
            {
                i++;
                critical += i + "." + DataReader["pdescription"].ToString() + Environment.NewLine;
            }
            DataReader.Close();
            connect.Close();

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.icons8_warning_48;
            popup.TitleText = count + " CRITICAL ITEM(S)";
            popup.ContentText = critical;
            popup.Popup();

        }

        public void GetTransNo()
        { 
            try
            {
                string sdate = DateTime.Now.ToString("yyyyMMdd");
                string transno;
                int count;
                connect.Open();
                command = new MySqlCommand("SELECT transno from cart_tbl where transno like '" + sdate + "%' order by id DESC",connect);
                DataReader = command.ExecuteReader();
                DataReader.Read();


                if (DataReader.HasRows) 
                { 
                    transno = DataReader[0].ToString();
                    count = int.Parse(transno.Substring(8, 4));
                    TransNoLbl.Text = sdate + (count + 1);
                } 
                else
                { 
                    transno = sdate + "1001";
                    TransNoLbl.Text = transno;
                } 
               
                DataReader.Close();
                connect.Close();
                
            }
            catch(Exception ex)
            {
                connect.Close();
                MessageBox.Show(ex.Message, stitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void GetCartTotal()
        {
            double total_ = double.Parse(TotalSalestxt.Text);
            double discount = Double.Parse(DiscountLbl.Text);
            double sales = Double.Parse(TotalLbl.Text) - discount;
            //double vat = sales * dbconnect.GetVal();
            //double vatable = sales - vat;

            TotalLbl.Text = sales.ToString("#,##0.00");
            //VatLbl.Text = vat.ToString("#,##0.00");
            //VatableLbl.Text = vatable.ToString("#,##0.00");
            DisplayTotalLbl.Text = sales.ToString("#,##0.00");

        }

        public void SoldTotal()
        {
            string sdate = DateTime.Now.ToString("yyyy-MM-dd");
            connect.Open();
            command = new MySqlCommand("INSERT INTO sold_total (transno,sdate,total_sales) VALUES (@transno,@sdate,@total_sales) ",connect);
            command.Parameters.AddWithValue("@transno",TransNoLbl.Text);
            command.Parameters.AddWithValue("@sdate", sdate);
            command.Parameters.AddWithValue("@total_sales", double.Parse(TotalLbl.Text));
            command.ExecuteNonQuery();
            connect.Close();
        }

        private void NewBtn_Click(object sender, EventArgs e)
        {
            
            if (dataGridView1.Rows.Count > 0)
            {
                return;
            }
            GetTransNo();
            SearchTb.Enabled = true;
            SearchTb.Focus();
        }

        private void SearchTb_Click(object sender, EventArgs e)
        {
           
        }

        private void SearchTb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (SearchTb.Text == String.Empty)
                {
                    return;
                }
                else
                {
                    connect.Open();
                    command = new MySqlCommand("SELECT * FROM producttbl WHERE barcode like '" + SearchTb.Text + "'", connect);
                    DataReader = command.ExecuteReader();
                    DataReader.Read();

                    if (DataReader.HasRows)
                    {
                        qty = int.Parse(DataReader["qty"].ToString());
                        QtyForm qf = new QtyForm(this);
                        qf.ProductDetails(DataReader["pcode"].ToString(), double.Parse(DataReader["price"].ToString()),TransNoLbl.Text, qty);
                        DataReader.Close();
                        connect.Close();
                        qf.ShowDialog();      
                    }

                    else
                    {
                        DataReader.Close();
                        connect.Close();
                    }

                    
                }
            }
            catch (Exception ex)
            {
                connect.Close();
                MessageBox.Show(ex.Message, stitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ColName = dataGridView1.Columns[e.ColumnIndex].Name;
            string discount = "";
            string disc = DiscountLbl.Text;
            string quantity = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();

            if(ColName == "Delete")
            {
                if (MessageBox.Show("Remove this item?", "Remove Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    connect.Open();
                    command = new MySqlCommand("DELETE FROM cart_tbl where id like '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", connect);
                    command.ExecuteNonQuery();
                    connect.Close(); LoadCart();

                    if (disc != "0.00")
                    {

                        connect.Open();
                        command = new MySqlCommand("UPDATE discounted_tbl set discounted_price = (@total * 0.20) WHERE transno LIKE '" + TransNoLbl.Text + "'", connect);
                        command.Parameters.AddWithValue("@total", TotalSalestxt.Text);
                        command.ExecuteNonQuery();
                        connect.Close();

                        connect.Open();
                        command = new MySqlCommand("SELECT discounted_price FROM discounted_tbl WHERE transno LIKE '" + TransNoLbl.Text + "'", connect);
                        DataReader = command.ExecuteReader();
                        while (DataReader.Read()) ;
                        {
                            discount = DataReader["discounted_price"].ToString();
                        }
                        DataReader.Close();
                        connect.Close();
                        DiscountLbl.Text = discount;

                        connect.Open();
                        command = new MySqlCommand("UPDATE discounts set discount = @discount WHERE transno LIKE '" + TransNoLbl.Text + "'", connect);
                        command.Parameters.AddWithValue("@discount", DiscountLbl.Text);
                        command.ExecuteNonQuery();
                        connect.Close();
                    }

                    
                    MessageBox.Show("Item removed.",stitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCart();  

                }
            }

            if(ColName == "Minus")
            {
                if(int.Parse(quantity) > 1 )
                {
                    connect.Open();
                    command = new MySqlCommand("UPDATE cart_tbl set qty = @qty - 1 WHERE id LIKE '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", connect);
                    command.Parameters.AddWithValue("@qty", dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
                    command.ExecuteNonQuery();
                    connect.Close();
                    LoadCart();
                }
                else
                {
                    MessageBox.Show("Please enter 1 or more quantity","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                
            }
            if(ColName == "Add")
            {
                
                    connect.Open();
                    command = new MySqlCommand("UPDATE cart_tbl set qty = @qty + 1 WHERE id LIKE '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", connect);
                    command.Parameters.AddWithValue("@qty", dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
                    command.ExecuteNonQuery();
                    connect.Close();
                    LoadCart();
               
            }
        }

        public void LoadCart()
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            double total = 0;
            double discount = 0;

            try
           {
               Boolean HasRecord = false;
               connect.Open();
               command = new MySqlCommand("SELECT c.id, c.pcode, p.pdescription, p.generic_name, c.price, c.qty, c.discount, c.total FROM cart_tbl AS c INNER JOIN producttbl AS p ON c.pcode = p.pcode WHERE transno LIKE '" + TransNoLbl.Text + "' AND status LIKE 'Pending'",connect);
               DataReader = command.ExecuteReader();
               while(DataReader.Read())
               {
                   i++;
                   total += Double.Parse(DataReader["total"].ToString());
                   //discount += Double.Parse(DataReader["discount"].ToString());
                   dataGridView1.Rows.Add(i, DataReader["id"].ToString(), DataReader["pcode"].ToString(), DataReader["pdescription"].ToString(), DataReader["generic_name"].ToString(),DataReader["price"].ToString(),DataReader["qty"].ToString(), DataReader["discount"].ToString(), Double.Parse(DataReader["total"].ToString()).ToString("#,##0.00"));
                   HasRecord = true;
               }
               DataReader.Close();
               connect.Close();


               connect.Open();
               command = new MySqlCommand("SELECT discount FROM discounts WHERE transno LIKE '" + TransNoLbl.Text + "'",connect);
               DataReader = command.ExecuteReader();
               while (DataReader.Read())
               {
                   discount = double.Parse(DataReader["discount"].ToString());
               }

               DataReader.Close();
               connect.Close();

               
               TotalLbl.Text = total.ToString("#,##0.00");
               TotalSalestxt.Text = total.ToString("#,##0.00");
               DiscountLbl.Text = discount.ToString("#,##0.00");
               GetCartTotal();

               if (HasRecord == true) { PaymentBtn.Enabled = true; DiscountBtn.Enabled = true; ClearCartBtn.Enabled = true; } else { PaymentBtn.Enabled = false; DiscountBtn.Enabled = false; ClearCartBtn.Enabled = false; }
           }
           catch (Exception ex)
           {
               connect.Close();
               MessageBox.Show(ex.Message, stitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
           }

        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            if (TransNoLbl.Text == "0000000000000")
            {
                return;
            }

            LookUpForm form = new LookUpForm(this);
            form.LoadRecords();
            form.ShowDialog();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DiscountBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Senior Citizen Discount?","DISCOUNT",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DiscountForm df = new DiscountForm(this);
                    df.IDlbl.Text = id;
                    df.PriceTb.Text = TotalLbl.Text;
                    df.SeniorName.Select();
                    df.ShowDialog();
                }
                else
                {
                    DiscountForm df = new DiscountForm(this);
                    df.IDlbl.Text = id;
                    df.PriceTb.Text = TotalLbl.Text;
                    df.PercentTb.Select();
                    df.SeniorName.Enabled = false;
                    df.SeniorIdtxt.Enabled = false;
                    df.ShowDialog();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }
        
        

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            id = dataGridView1[1, i].Value.ToString();
            //price = dataGridView1[8, i].Value.ToString();
        }

        private void TransNoLbl_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeLbl.Text = DateTime.Now.ToString("hh:mm:ss tt");
            LblDate.Text = DateTime.Now.ToLongDateString();
        }

        private void PaymentBtn_Click(object sender, EventArgs e)
        {
            SettleForm sf = new SettleForm(this);
            sf.SalesTxt.Text = DisplayTotalLbl.Text;
            sf.ShowDialog();
        }

        private void SalesBtn_Click(object sender, EventArgs e)
        {
            SoldItemsForm sold = new SoldItemsForm();
            sold.dt1.Enabled = false;
            sold.dt2.Enabled = false;
            sold.User = usernamelbl.Text;
            sold.CashierCb.Enabled = false;
            sold.CashierCb.Text = usernamelbl.Text;
            sold.ShowDialog();
        }

        private void bunifuFlatButton14_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                MessageBox.Show("Unable to logout. Please cancel all transactions","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            if(MessageBox.Show("Are you sure you want to logout?","Logout",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
            {
                this.Hide();
                LoginPage lp = new LoginPage();
                lp.ShowDialog();
            }
        }

        private void PosForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F1)
            {
                NewBtn_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F2)
            {
                SearchBtn_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F3)
            {
                DiscountBtn_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F4)
            {
                PaymentBtn_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F6)
            {
                SalesBtn_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F7)
            {
                ChangePassBtn_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F10)
            {
                bunifuFlatButton14_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F5)
            {
                ClearCartBtn_Click(sender, e);
            }
        }

        private void ChangePassBtn_Click(object sender, EventArgs e)
        {
            ChangePasswordForm c = new ChangePasswordForm(this);
            c.ShowDialog();
        }

        private void ClearCartBtn_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Remove all items in cart?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                connect.Open();
                command = new MySqlCommand("DELETE FROM cart_tbl WHERE transno LIKE '" + TransNoLbl.Text + "'", connect);
                command.ExecuteNonQuery();
                connect.Close();
                connect.Open();
                command = new MySqlCommand("DELETE FROM discounted_tbl WHERE transno LIKE '"+ TransNoLbl.Text + "'",connect);
                command.ExecuteNonQuery();
                connect.Close();
                connect.Open();
                command = new MySqlCommand("DELETE FROM discounts WHERE transno LIKE '"+ TransNoLbl.Text + "'",connect);
                command.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("All items removed from cart", "Remove Items", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCart();
                senioridtxt.Visible = false; seniornametxt.Visible = false; label4.Visible = false; label5.Visible = false;
            }
        }

        private void PosForm_Load(object sender, EventArgs e)
        {

        }

       

        

        
    }
}
