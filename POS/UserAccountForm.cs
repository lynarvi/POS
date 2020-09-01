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
    public partial class UserAccountForm : Form
    {
        MySqlConnection connect;
        MySqlCommand command;
        MySqlDataReader DataReader;
        DBConnection dbconnect = new DBConnection();
        AdminPage f;
        public UserAccountForm(AdminPage frm)
        {
            InitializeComponent();
            connect = new MySqlConnection();
            connect.ConnectionString = dbconnect.DataConnection();
            f = frm;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void UserAccountForm_Resize(object sender, EventArgs e)
        {
            metroTabControl1.Left = (this.Width - metroTabControl1.Width) / 2;
            metroTabControl1.Top = (this.Height - metroTabControl1.Height) / 2;
        }

        private void UserAccountForm_Load(object sender, EventArgs e)
        {
           
        }

        private void PasswordTb_OnValueChanged(object sender, EventArgs e)
        {
            PasswordTb.isPassword = true;
        }

        private void RetypePassTb_OnValueChanged(object sender, EventArgs e)
        {
            RetypePassTb.isPassword = true;
        }

        private void Clear()
        {
            UsernameTb.Text = "";
            PasswordTb.Text = "";
            RetypePassTb.Text = "";
            RoleCb.Text = "";
            NameTb.Text = "";
            UsernameTb.Focus();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            { 
                if(PasswordTb.Text != RetypePassTb.Text)
                {
                    MessageBox.Show("Password do not match!","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }

                connect.Open();
                command = new MySqlCommand("INSERT INTO users_tbl (username,name,password,role) VALUES (@username,@name,@password,@role)",connect);
                command.Parameters.AddWithValue("@username",UsernameTb.Text);
                command.Parameters.AddWithValue("@name", NameTb.Text);
                command.Parameters.AddWithValue("@password", PasswordTb.Text);
                command.Parameters.AddWithValue("@role", RoleCb.Text);
                command.ExecuteNonQuery();
                connect.Close();

                MessageBox.Show("Account has been saved!");
                Clear();
            }
            catch(Exception ex)
            {
                connect.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void savetxt_Click(object sender, EventArgs e)
        {
            try
            {
                string _oldpass = dbconnect.GetPassword(f.usernametxt.Text);

                if (_oldpass != oldpasstxt.Text)
                {
                    MessageBox.Show("Old password did not match!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (newpasstxt.Text != retypetxt.Text)
                {
                    MessageBox.Show("New Password did not match!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (MessageBox.Show("Change Password?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        connect.Open();
                        command = new MySqlCommand("UPDATE users_tbl SET password = @password WHERE username = @username", connect);
                        command.Parameters.AddWithValue("@password", newpasstxt.Text);
                        command.Parameters.AddWithValue("@username", f.usernametxt.Text);
                        command.ExecuteNonQuery();
                        connect.Close();

                        MessageBox.Show("Password has been successfully saved!", "Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();
                    }
                }

            }
            catch (Exception ex)
            {
                connect.Close();
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void canceltxt_Click(object sender, EventArgs e)
        {
            oldpasstxt.Text = "";
            newpasstxt.Text = "";
            retypetxt.Text = "";

        }

        private void oldpasstxt_OnValueChanged(object sender, EventArgs e)
        {
            oldpasstxt.isPassword = true;
        }

        private void newpasstxt_OnValueChanged(object sender, EventArgs e)
        {
            newpasstxt.isPassword = true;
        }

        private void retypetxt_OnValueChanged(object sender, EventArgs e)
        {
            retypetxt.isPassword = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ColName = dataGridView1.Columns[e.ColumnIndex].Name;

            if (ColName == "Delete")
            {
                if (MessageBox.Show("Delete User?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    connect.Open();
                    command = new MySqlCommand("DELETE FROM users_tbl WHERE username like '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", connect);
                    command.ExecuteNonQuery();
                    connect.Close();
                    MessageBox.Show("User removed.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsers();


                }
            }
        }

        public void LoadUsers()
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            connect.Open();
            command = new MySqlCommand("SELECT * FROM users_tbl",connect);
            DataReader = command.ExecuteReader();

            while(DataReader.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, DataReader["username"].ToString(), DataReader["name"].ToString(), DataReader["password"].ToString(), DataReader["role"].ToString());
            }
            DataReader.Close();
            connect.Close();

        }
             
        
    }
}
