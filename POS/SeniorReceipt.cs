using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;


namespace POS
{
    public partial class SeniorReceipt : Form
    {
        MySqlConnection connect;
        MySqlCommand command;
        MySqlDataReader DataReader;
        DBConnection dbconnect = new DBConnection();
        string store = "Hualde Convenience Store";
        string address = "Rizal Ilawod, Cabatuan, Iloilo";
        PosForm f;
        public SeniorReceipt(PosForm frm)
        {
            InitializeComponent();
            connect = new MySqlConnection();
            connect.ConnectionString = dbconnect.DataConnection();
            f = frm;
            this.KeyPreview = true;
        }

        private void SeniorReceipt_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
        public void LoadReport(string pcash, string pchange)
        {
            ReportDataSource rptDataSource;
            try
            {
                this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Reports\Report4.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();

                DataSet1 ds = new DataSet1();
                MySqlDataAdapter da = new MySqlDataAdapter();

                connect.Open();
                da.SelectCommand = new MySqlCommand("SELECT c.id, c.transno, c.pcode, c.price, c.qty, c.discount, c.total, c.sdate, c.status, p.pdescription FROM cart_tbl as c inner join producttbl as p ON p.pcode = c.pcode WHERE transno LIKE '" + f.TransNoLbl.Text + "'", connect);
                da.Fill(ds.Tables["dtSenior"]);
                connect.Close();

                //connect.Open();
                //command = new MySqlCommand("SELECT name, id_no FROM discounted_tbl WHERE transno LIKE '" + f.TransNoLbl.Text + "'",connect);
                
                //connect.Close();

                ReportParameter pVatable = new ReportParameter("pVatable", f.VatableLbl.Text);
                ReportParameter pVat = new ReportParameter("pVat", f.VatLbl.Text);
                ReportParameter pDiscount = new ReportParameter("pDiscount", f.DiscountLbl.Text);
                ReportParameter pTotal = new ReportParameter("pTotal", f.TotalLbl.Text);
                ReportParameter pCash = new ReportParameter("pCash", pcash);
                ReportParameter pChange = new ReportParameter("pChange", pchange);
                ReportParameter pStore = new ReportParameter("pStore", store);
                ReportParameter pAddress = new ReportParameter("pAddress", address);
                ReportParameter pTransaction = new ReportParameter("pTransaction", "Invoice #: " + f.TransNoLbl.Text);
                ReportParameter pCashier = new ReportParameter("pCashier","Cahsier: " + f.usernamelbl.Text);
                ReportParameter pTotal_Sales = new ReportParameter("pTotal_Sales", f.TotalSalestxt.Text);
                ReportParameter pSeniorName = new ReportParameter("pSeniorName",  f.seniornametxt.Text);
                ReportParameter pSeniorId = new ReportParameter("pSeniorId", "SC Id: " + f.senioridtxt.Text);
                //ReportParameter pTin = new ReportParameter("pTin", tin);

                reportViewer1.LocalReport.SetParameters(pVatable);
                reportViewer1.LocalReport.SetParameters(pVat);
                reportViewer1.LocalReport.SetParameters(pDiscount);
                reportViewer1.LocalReport.SetParameters(pTotal);
                reportViewer1.LocalReport.SetParameters(pCash);
                reportViewer1.LocalReport.SetParameters(pChange);
                reportViewer1.LocalReport.SetParameters(pStore);
                reportViewer1.LocalReport.SetParameters(pAddress);
                reportViewer1.LocalReport.SetParameters(pTransaction);
                reportViewer1.LocalReport.SetParameters(pCashier);
                reportViewer1.LocalReport.SetParameters(pTotal_Sales);
                reportViewer1.LocalReport.SetParameters(pSeniorName);
                reportViewer1.LocalReport.SetParameters(pSeniorId);
                // reportViewer1.LocalReport.SetParameters(pTin);

                rptDataSource = new ReportDataSource("DataSet1", ds.Tables["dtSenior"]);
                reportViewer1.LocalReport.DataSources.Add(rptDataSource);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void SeniorReceipt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }
    }
}
