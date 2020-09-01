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
    public partial class BrandListForm : Form
    {

        MySqlConnection connect;
        MySqlCommand command;
        MySqlDataReader DataReader;
        DBConnection dbconnect = new DBConnection();

        public BrandListForm()
        {
            InitializeComponent();
            connect = new MySqlConnection();
            connect.ConnectionString = dbconnect.DataConnection();
            LoadRecords();
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ColName = dataGridView1.Columns[e.ColumnIndex].Name;
            if(ColName == "Edit")
            {
                BrandForm form = new BrandForm(this);
                form.IdLabel.Text = dataGridView1[1, e.RowIndex].Value.ToString();
                form.BrandNameTb.Text = dataGridView1[2, e.RowIndex].Value.ToString();
                form.ShowDialog();
            }
            else if (ColName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) ;
                {
                    connect.Open();
                    command = new MySqlCommand("DELETE FROM brandtbl where id like '" + dataGridView1[1,e.RowIndex].Value.ToString() + "'",connect);
                    command.ExecuteNonQuery();
                    connect.Close();
                    MessageBox.Show("Brand has been successfully deleted!","POS",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    LoadRecords();

                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            BrandForm brandF = new BrandForm(this);
            brandF.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LoadRecords()
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            connect.Open();
            command = new MySqlCommand("SELECT * FROM brandtbl order by brand",connect);
            DataReader = command.ExecuteReader();

            while (DataReader.Read())
            {
                i += 1; 
                dataGridView1.Rows.Add(i, DataReader["id"].ToString(), DataReader["brand"].ToString());
            }
            DataReader.Close();
            connect.Close();

        }
    }
}
