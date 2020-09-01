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
using System.Windows.Forms.DataVisualization.Charting;

namespace POS
{
    public partial class DashboardForm : Form
    {
        MySqlConnection connect;
        MySqlCommand command;
        MySqlDataReader DataReader;
        DBConnection dbconnect = new DBConnection();
        
        
        
        
        public DashboardForm()
        {
            InitializeComponent();
            connect = new MySqlConnection();
            connect.ConnectionString = dbconnect.DataConnection();
            LoadChart();
           
            
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            //panel1.Left = (this.Width - panel1.Width) / 2;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            
        }

        public void LoadChart()
        {
            connect.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT MONTH(sdate)AS month, SUM(total) AS total FROM cart_tbl WHERE status LIKE 'Sold' GROUP BY MONTH(sdate)",connect);
            DataSet ds = new DataSet();

            da.Fill(ds, "Sales");
            chart1.DataSource = ds.Tables["Sales"];
            Series series1 = chart1.Series["Series1"];
            series1.ChartType = SeriesChartType.Doughnut;

            series1.Name = "SALES";

            var chart = chart1;
            chart.Series[series1.Name].XValueMember = "month";
            chart.Series[series1.Name].YValueMembers = "total";
            chart.Series[0].IsValueShownAsLabel = true;
            //chart.Series[0].LegendText = "#";
            connect.Close();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DailySalesTxt_Click(object sender, EventArgs e)
        {

        }
    }
}
