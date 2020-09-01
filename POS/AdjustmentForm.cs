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
    public partial class AdjustmentForm : Form
    {
        MySqlConnection connect;
        MySqlCommand command;
        MySqlDataReader DataReader;
        DBConnection dbconnect = new DBConnection();
        AdminPage f;
        int _qty = 0;
        public AdjustmentForm(AdminPage f)
        {
            InitializeComponent();
            connect = new MySqlConnection();
            connect.ConnectionString = dbconnect.DataConnection();
            this.f = f;
        }

        public void ReferenceNo()
        {
            Random r = new Random();
            RefNotxt.Clear();
            RefNotxt.Text += "REF" + r.Next();
        }
        public void LoadRecords()
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            connect.Open();
            command = new MySqlCommand("SELECT p.pcode, p.barcode, p.pdescription, b.brand, c.category, p.price, p.qty FROM producttbl as p inner join brandtbl as b on b.id = p.brandid inner join categorytbl as c on c.id = p.categoryid where p.pdescription like '" + SearchTb.Text + "%' order by p.pdescription", connect);
            DataReader = command.ExecuteReader();

            while (DataReader.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, DataReader[0].ToString(), DataReader[1].ToString(), DataReader[2].ToString(), DataReader[3].ToString(), DataReader[4].ToString(), DataReader[5].ToString(), DataReader[6].ToString());

            }
            DataReader.Close();
            connect.Close();


        }

        private void AdjustmentForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ColName = dataGridView1.Columns[e.ColumnIndex].Name;
           
            if(ColName == "Select")
            {
                Pcodetxt.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                DescriptionTxt.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() + " " + dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() + " " +  dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                _qty = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
            }
        }

        private void SearchTb_TextChanged(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //validation for empty fields

                if(int.Parse(qtytxt.Text) < _qty)
                {
                    MessageBox.Show("STOCK ON HAND QUANTITY SHOULD BE GREATER THAN THE ADJUSTMENT QUANTITY.","WARNING",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }

                //update stock

                if(CommandCb.Text == "REMOVE FROM INVENTORY")
                {
                    connect.Open();
                    command = new MySqlCommand("UPDATE producttbl SET qty = (qty -  " + int.Parse(qtytxt.Text) + ") WHERE pcode LIKE '" + Pcodetxt.Text + "' ",connect);
                    command.ExecuteNonQuery();
                    connect.Close();
                }
                else if (CommandCb.Text == "ADD TO INVENTORY")
                {
                    connect.Open();
                    command = new MySqlCommand("UPDATE producttbl SET qty = (qty +  " + int.Parse(qtytxt.Text) + ") WHERE pcode LIKE '" + Pcodetxt.Text + "' ", connect);
                    command.ExecuteNonQuery();
                    connect.Close();
                }

                connect.Open();
                command = new MySqlCommand("INSERT INTO adjustment_tbl (reference_no,pcode,qty,action,remarks,sdate,user) VALUES (@reference_no,@pcode,@qty,@action,@remarks,@sdate,@user)", connect);
                command.Parameters.AddWithValue("@reference_no",RefNotxt.Text);
                command.Parameters.AddWithValue("@pcode", Pcodetxt.Text);
                command.Parameters.AddWithValue("@qty", _qty);
                command.Parameters.AddWithValue("@action", CommandCb.Text);
                command.Parameters.AddWithValue("@remarks", RemarksTxt.Text);
                command.Parameters.AddWithValue("@sdate", DateTime.Now.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@user", UserTxt.Text);
                command.ExecuteNonQuery();
                connect.Close();

                MessageBox.Show("STOCK HAS BEEN SUCCESSFULLY ADJUSTED!","STOCK ADJUSTMENT",MessageBoxButtons.OK,MessageBoxIcon.Information);

                Clear();
                LoadRecords();
                
            }
            catch(Exception ex)
            {
                connect.Close();
                MessageBox.Show(ex.Message,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        public void Clear()
        {
            Pcodetxt.Clear();
            qtytxt.Clear();
            CommandCb.Text = "";
            RemarksTxt.Clear();
            UserTxt.Text = "";
            DescriptionTxt.Clear();
            ReferenceNo();

        }
        private void CommandCb_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void CommandCb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
