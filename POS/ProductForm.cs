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
    public partial class ProductForm : Form
    {
        MySqlConnection connect;
        MySqlCommand command;
        MySqlDataReader DataReader;
        DBConnection dbconnect = new DBConnection();
        ProductListForm formlist;

        public ProductForm(ProductListForm frm)
        {
            InitializeComponent();
            connect = new MySqlConnection();
            connect.ConnectionString = dbconnect.DataConnection();
            formlist = frm;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void LoadCategory()
        {
            CategoryCb.Items.Clear();
            connect.Open();
            command = new MySqlCommand("SELECT category FROM categorytbl",connect);
            DataReader = command.ExecuteReader();

            while(DataReader.Read())
            {
                CategoryCb.Items.Add(DataReader[0].ToString());
            }

            DataReader.Close();
            connect.Close();
         }

        public void LoadBrand()
        {
            BrandCb.Items.Clear();
            connect.Open();
            command = new MySqlCommand("SELECT brand FROM brandtbl", connect);
            DataReader = command.ExecuteReader();

            while (DataReader.Read())
            {
                BrandCb.Items.Add(DataReader[0].ToString());
            }

            DataReader.Close();
            connect.Close();
        }

        private void CategoryCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (MessageBox.Show("Are you sure you want to save this product", "Save Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
                {
                    string brandid = ""; string categoryid = "";
                    
                    // for brand
                    connect.Open();
                    command = new MySqlCommand("SELECT id FROM brandtbl where brand LIKE '" + BrandCb.Text + "'", connect);
                    DataReader = command.ExecuteReader();
                    DataReader.Read();

                    if (DataReader.HasRows) { brandid = DataReader[0].ToString(); }
                    DataReader.Close();
                    connect.Close();

                    //for category
                    connect.Open();
                    command = new MySqlCommand("SELECT id FROM categorytbl WHERE category LIKE '" + CategoryCb.Text + "'", connect);
                    DataReader = command.ExecuteReader();
                    DataReader.Read();

                    if (DataReader.HasRows) { categoryid = DataReader[0].ToString(); }
                    DataReader.Close();
                    connect.Close();



                    connect.Open();
                    command = new MySqlCommand("INSERT INTO producttbl (pcode, barcode, pdescription, generic_name, brandid, categoryid, price, expiry, reorder) VALUES (@pcode, @barcode, @pdescription,@generic_name, @brandid, @categoryid, @price, @expiry, @reorder)", connect);
                    command.Parameters.AddWithValue("@pcode", PCodeTb.Text);
                    command.Parameters.AddWithValue("@barcode", Barcodetb.Text);
                    command.Parameters.AddWithValue("@pdescription", DescriptionTb.Text);
                    command.Parameters.AddWithValue("@generic_name", GenericNamextxt.Text);
                    command.Parameters.AddWithValue("@brandid", brandid);
                    command.Parameters.AddWithValue("@categoryid", categoryid);
                    command.Parameters.AddWithValue("@price", Double.Parse(PriceTb.Text));
                    command.Parameters.AddWithValue("@expiry", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@reorder", int.Parse(ReorderTb.Text));
                    command.ExecuteNonQuery();
                    connect.Close();
                    MessageBox.Show("Product has been succeddfully saved!");
                    Clear();
                    formlist.LoadRecords();
                }
            }
            catch(Exception ex)
            {
                connect.Close();
                MessageBox.Show(ex.Message);

            }
        }

        public void Clear()
        {
            PCodeTb.Text = "";
            Barcodetb.Text = "";
            DescriptionTb.Text = "";
            GenericNamextxt.Text = "";
            BrandCb.Text = "";
            CategoryCb.Text = "";
            PriceTb.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            ReorderTb.Text = "";
            PCodeTb.Focus();
            SaveBtn.Visible = true;
            UpdateBtn.Visible = false;
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("Are you sure you want to update this product", "Update Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string BrandId = ""; string CategoryId = "";

                    // for brand
                    connect.Open();
                    command = new MySqlCommand("SELECT id FROM brandtbl WHERE brand LIKE '" + BrandCb.Text + "'", connect);
                    DataReader = command.ExecuteReader();
                    DataReader.Read();

                    if (DataReader.HasRows) { BrandId = DataReader[0].ToString(); }
                    DataReader.Close();
                    connect.Close();

                    //for category
                    connect.Open();
                    command = new MySqlCommand("SELECT id FROM categorytbl WHERE category LIKE '" + CategoryCb.Text + "'", connect);
                    DataReader = command.ExecuteReader();
                    DataReader.Read();

                    if (DataReader.HasRows) { CategoryId = DataReader[0].ToString(); }
                    DataReader.Close();
                    connect.Close();



                    connect.Open();
                    command = new MySqlCommand("UPDATE producttbl SET barcode=@barcode, pdescription=@pdescription, generic_name=@generic_name, brandid=@brandid, categoryid=@categoryid, price=@price, expiry=@expiry, reorder=@reorder WHERE pcode LIKE @pcode", connect);
                    command.Parameters.AddWithValue("@pcode", PCodeTb.Text);
                    command.Parameters.AddWithValue("@barcode", Barcodetb.Text);
                    command.Parameters.AddWithValue("@pdescription", DescriptionTb.Text);
                    command.Parameters.AddWithValue("@generic_name",GenericNamextxt.Text);
                    command.Parameters.AddWithValue("@brandid", BrandId);
                    command.Parameters.AddWithValue("@categoryid", CategoryId);
                    command.Parameters.AddWithValue("@price", Double.Parse(PriceTb.Text));
                    command.Parameters.AddWithValue("@expiry", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@reorder", int.Parse(ReorderTb.Text));
                    command.ExecuteNonQuery();
                    connect.Close();
                    MessageBox.Show("Product has been succeddfully updated!");
                    Clear();
                    formlist.LoadRecords();
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void PriceTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46)
            {
                //accept . char
            }
            else if (e.KeyChar == 8)
            {
                //accept backspace
            }
            else if((e.KeyChar < 48) || (e.KeyChar > 57)) //ascii code 48-57 0-9 
            {
                e.Handled = true;
            }
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {

        }

        private void BrandCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


            
    }
}
