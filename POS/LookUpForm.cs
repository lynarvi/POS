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
    public partial class LookUpForm : Form
    {
        PosForm posform;
        MySqlConnection connect;
        MySqlCommand command;
        MySqlDataReader DataReader;
        DBConnection dbconnect = new DBConnection();
        string stitle = "POS System";
        

        public LookUpForm(PosForm frm)
        {
            InitializeComponent();
            connect = new MySqlConnection();
            connect.ConnectionString = dbconnect.DataConnection();
            posform = frm;
            this.KeyPreview = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        public void LoadRecords()
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            connect.Open();
            command = new MySqlCommand("SELECT p.pcode, p.barcode, p.pdescription, p.generic_name, b.brand, c.category, p.price, p.qty FROM producttbl as p inner join brandtbl as b on b.id = p.brandid inner join categorytbl as c on c.id = p.categoryid where p.pdescription like '" + SearchTb.Text + "%' order by p.pdescription ", connect);
            DataReader = command.ExecuteReader();

            while (DataReader.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, DataReader[0].ToString(), DataReader[1].ToString(), DataReader[2].ToString(), DataReader[3].ToString(), DataReader[4].ToString(), DataReader[5].ToString(), DataReader[6].ToString(), DataReader[7].ToString());

            }
            DataReader.Close();
            connect.Close();


        }

        private void SearchTb_TextChanged(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string ColName = dataGridView1.Columns[e.ColumnIndex].Name;


                if (ColName == "Select")
                {
                    QtyForm qf = new QtyForm(posform);
                    qf.ProductDetails(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(), Double.Parse(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString()), posform.TransNoLbl.Text, int.Parse(dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString()));
                    qf.ShowDialog();


                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void LookUpForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
           
        }
    }
}
