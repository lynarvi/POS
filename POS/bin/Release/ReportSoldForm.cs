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
using Microsoft.Reporting.WinForms;

namespace POS
{
    public partial class ReportSoldForm : Form
    {
        MySqlConnection connect;
        MySqlCommand command;
        MySqlDataReader DataReader;
        DBConnection dbconnect = new DBConnection();
        SoldItemsForm f;

        public ReportSoldForm(SoldItemsForm frm)
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

        private void ReportSoldForm_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        public void LoadReport()
        { 
            try
            {
                ReportDataSource rptDS;
                this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Reports\Report2.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();

                DataSet1 ds = new DataSet1();
                MySqlDataAdapter da = new MySqlDataAdapter();

                connect.Open();
                if (f.CashierCb.Text == "All Cashier")
                {
                    da.SelectCommand = new MySqlCommand("SELECT c.id, c.transno, c.pcode, p.pdescription, c.price, c.qty, c.discount, c.total FROM cart_tbl AS c INNER JOIN producttbl AS p ON c.pcode = p.pcode WHERE status LIKE 'Sold' AND sdate BETWEEN '" + f.dt1.Value.ToString("yyyy-MM-dd") + "' AND '" + f.dt2.Value.ToString("yyyy-MM-dd") + "'", connect);
                }
                else
                {
                    da.SelectCommand = new MySqlCommand("SELECT c.id, c.transno, c.pcode, p.pdescription, c.price, c.qty, c.discount, c.total FROM cart_tbl AS c INNER JOIN producttbl AS p ON c.pcode = p.pcode WHERE status LIKE 'Sold' AND sdate BETWEEN '" + f.dt1.Value.ToString("yyyy-MM-dd") + "' AND '" + f.dt2.Value.ToString("yyyy-MM-dd") + "' AND cashier LIKE '" + f.CashierCb.Text + "'", connect);
                }
               
                da.Fill(ds.Tables["dtSoldReport"]);
                connect.Close();

                ReportParameter pCashier = new ReportParameter("pCashier", "Cashier: "  + f.CashierCb.Text);
                ReportParameter pDate = new ReportParameter("pDate", "Date From: " +  f.dt1.Value.ToShortDateString() + " To: " + f.dt2.Value.ToShortDateString() );
                
                reportViewer1.LocalReport.SetParameters(pCashier);
                reportViewer1.LocalReport.SetParameters(pDate);

                rptDS = new ReportDataSource("DataSet1", ds.Tables["dtSoldReport"]);
                reportViewer1.LocalReport.DataSources.Add(rptDS);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
            }
            catch(Exception ex)
            {
                connect.Close();
                MessageBox.Show(ex.Message);

            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
