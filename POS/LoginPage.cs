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
    public partial class LoginPage : Form
    {
        MySqlConnection connect;
        MySqlCommand command;
        MySqlDataReader DataReader;
        DBConnection dbconnect = new DBConnection();

        public LoginPage()
        {
            InitializeComponent();
            connect = new MySqlConnection();
            connect.ConnectionString = dbconnect.DataConnection();
            this.KeyPreview = true;
            usertxt.Select();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string _username = "", _role = "", _name = "";
            try
            {
                bool found = false;
                connect.Open();
                command = new MySqlCommand("SELECT * FROM users_tbl where username = @username AND password = @password",connect);
                command.Parameters.AddWithValue("@username", usertxt.Text);
                command.Parameters.AddWithValue("@password", passtxt.Text);
                DataReader = command.ExecuteReader();
                DataReader.Read();
                if(DataReader.HasRows)
                {
                    found = true;
                    _username = DataReader["username"].ToString();
                    _role = DataReader["role"].ToString();
                    _name = DataReader["name"].ToString();
                }
                else
                {
                    found = false;

                }
                DataReader.Close();
                connect.Close();

                if (found == true)
                {
                    if (_role == "Cashier")
                    {
                        MessageBox.Show("Welcome " + _name + "!", "Access Granted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        usertxt.Text = "";
                        passtxt.Text = "";
                        this.Hide();
                        PosForm pf = new PosForm(this);
                        pf.usernamelbl.Text = _username;
                        pf.cashierlbl.Text = _name + " | " + _role;
                        pf.ShowDialog();


                    }
                    else if (_role == "Administrator")
                    {
                        MessageBox.Show("Welcome " + _name + "!", "Access Granted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        usertxt.Text = "";
                        passtxt.Text = "";
                        this.Hide();
                        AdminPage frm = new AdminPage();
                        frm.nametxt.Text = _name;
                        frm.usernametxt.Text = _username;
                        frm.ShowDialog();
                       
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username" + _name + "!", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    usertxt.Text = "";
                    passtxt.Text = "";
                    
                }
                

            }
            catch(Exception ex)
            {
                connect.Close();
                MessageBox.Show(ex.Message, "Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
           
        }

        private void PassTxt_OnValueChanged(object sender, EventArgs e)
        {
            //PassTxt.isPassword = true;
        }

        private void LoginPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginBtn_Click(sender, e);
            }
           
        }
    }
}
