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
    public partial class BrandForm : Form
    {
        MySqlConnection connect;
        MySqlCommand command;
        MySqlDataReader DataReader;
        DBConnection dbconnect = new DBConnection();
        BrandListForm formlist;

        public BrandForm(BrandListForm flist)
        {
            InitializeComponent();
            connect = new MySqlConnection();
            connect.ConnectionString = dbconnect.DataConnection();
            formlist = flist;
            //connect.Open();
           
        }

        private void Clear()
       {
           SaveBtn.Enabled = true;
           BrandNameTb.Text = "";
           BrandNameTb.Focus();


            
       }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this brand?","",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)

                {
                    
                    connect.Open();
                    command = new MySqlCommand("INSERT INTO brandtbl(brand) VALUES (@brand)", connect);
                    command.Parameters.AddWithValue("@brand", BrandNameTb.Text);
                    command.ExecuteNonQuery();
                    connect.Close();
                    MessageBox.Show("Record has been saved!");
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            //update brand name
           
            try
            {
                if (MessageBox.Show("Are you you sure to update this Brand?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
                connect.Open();
                command = new MySqlCommand("UPDATE brandtbl SET brand = @brand where id like '" + IdLabel.Text + "'",connect);
                command.Parameters.AddWithValue("@brand",BrandNameTb.Text);
               
                command.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("Brand has been successfully updated!");
                Clear();
                formlist.LoadRecords();
                this.Dispose();


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {

        }

        private void BrandNameTb_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void BrandForm_Load(object sender, EventArgs e)
        {

        }
    }
}
