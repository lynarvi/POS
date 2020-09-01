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
    public partial class AdminPage : Form
    {
        MySqlConnection connect;
        MySqlCommand command;
        MySqlDataReader DataReader;
        DBConnection dbconnect = new DBConnection();
        
        
        

        public AdminPage()
        {
            InitializeComponent();
            connect = new MySqlConnection();
            connect.ConnectionString = dbconnect.DataConnection();
            NotifyCriticalItems();
            
            
            
            
            //connect.Open();
            //MessageBox.Show("Connected");
        }


        public void Dashboard()
        {
            DashboardForm d = new DashboardForm();
            d.TopLevel = false;
            MainPanel.Controls.Add(d);
            d.DailySalesTxt.Text = dbconnect.DailySales().ToString("#,##0.00");
            d.ProductLineTxt.Text = dbconnect.ProductLine().ToString();
            d.StockTxt.Text = dbconnect.StockOnHand().ToString();
            d.CriticalItemsTxt.Text = dbconnect.CriticalItems().ToString();
            d.BringToFront();
            d.Show();


        }
        private void AdminPage_Resize(object sender, EventArgs e)
        {
            //int intX = Screen.PrimaryScreen.Bounds.Width;
            //int intY = Screen.PrimaryScreen.Bounds.Height;
            //this.Width = intX;
            //this.Height = intY - 40;
            //this.Top = 0;
            //this.Left = 0; 
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
            command = new MySqlCommand("SELECT * FROM vwcriticalitems",connect);
            DataReader = command.ExecuteReader();
            while(DataReader.Read())
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

        private void ManageBrandBtn_Click(object sender, EventArgs e)
        {
            BrandListForm brand = new BrandListForm();
            brand.TopLevel = false;
            MainPanel.Controls.Add(brand);
            brand.BringToFront();
            brand.Show();


        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ManageCategoryBtn_Click(object sender, EventArgs e)
        {
            CategoryListForm CatList = new CategoryListForm();
            CatList.TopLevel = false;
            MainPanel.Controls.Add(CatList);
            CatList.BringToFront();
            CatList.Show();
            
        }

        private void ManageProductBtn_Click(object sender, EventArgs e)
        {
            ProductListForm plf = new ProductListForm();
            plf.TopLevel = false;
            MainPanel.Controls.Add(plf);
            plf.BringToFront();
            plf.LoadRecords();
            plf.Show(); 
        }

        private void StockInBtn_Click(object sender, EventArgs e)
        {
            StockInForm sf = new StockInForm();
            sf.TopLevel = false;
            MainPanel.Controls.Add(sf);
            sf.BringToFront();
            //sf.LoadProduct();
            sf.Show();
        }


        private void PosBtn_Click(object sender, EventArgs e)
        {
          
            //PosForm pos = new PosForm();
            //pos.ShowDialog();
        }

        private void UserSettingsBtn_Click(object sender, EventArgs e)
        {
            UserAccountForm us = new UserAccountForm(this);
            us.TopLevel = false;
            MainPanel.Controls.Add(us);
            us.LoadUsers();
            us.BringToFront();
            us.Show();
        }

        private void SalesHistoryBtn_Click(object sender, EventArgs e)
        {
            SoldItemsForm sold = new SoldItemsForm();
            sold.ShowDialog();
        }

        private void RecordsBtn_Click(object sender, EventArgs e)
        {
            RecordsForm r = new RecordsForm();
            r.TopLevel = false;
            r.LoadCriticalItems();
            r.LoadInvertory();
            r.CancelledItems();
            MainPanel.Controls.Add(r);
            r.BringToFront();
            r.Show();
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                LoginPage lp = new LoginPage();
                lp.ShowDialog();
            }
        }

        private void DashboardBtn_Click(object sender, EventArgs e)
        {
            Dashboard();
        }

        


        private void AdjustmentBtn_Click(object sender, EventArgs e)
        {
            AdjustmentForm a = new AdjustmentForm(this);
            a.LoadRecords();
            a.UserTxt.Text = usernametxt.Text;
            a.ReferenceNo();
            a.ShowDialog();
        }

        private void AdminPage_Load(object sender, EventArgs e)
        {
            Dashboard();
            //MessageBox.Show(dbconnect.DailySales().ToString());
        }

       

        

      

        
    }
}
