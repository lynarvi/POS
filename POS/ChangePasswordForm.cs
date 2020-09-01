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
    public partial class ChangePasswordForm : Form
    {
        MySqlConnection connect;
        MySqlCommand command;
        MySqlDataReader DataReader;
        DBConnection dbconnect = new DBConnection();
        PosForm f;
        public ChangePasswordForm(PosForm frm)
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

        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string _oldpass = dbconnect.GetPassword(f.usernamelbl.Text);

                if(_oldpass != oldPassTxt.Text)
                {
                    MessageBox.Show("Old password did not match!","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                else if (newPassTxt.Text != confirmPassTxt.Text)
                {
                    MessageBox.Show("New Password did not match!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if(MessageBox.Show("Change Password?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
                    {
                        connect.Open();
                        command = new MySqlCommand("UPDATE users_tbl SET password = @password WHERE username = @username",connect);
                        command.Parameters.AddWithValue("@password", newPassTxt.Text);
                        command.Parameters.AddWithValue("@username",f.usernamelbl.Text);
                        command.ExecuteNonQuery();
                        connect.Close();

                        MessageBox.Show("Password has been successfully saved!", "Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();
                    }
                }

            }
            catch(Exception ex)
            {
                connect.Close();
                MessageBox.Show(ex.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void ChangePasswordForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }
    }
}
