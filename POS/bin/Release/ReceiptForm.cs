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
    public partial class ReceiptForm : Form
    {
        MySqlConnection connect;
        MySqlCommand command;
        MySqlDataReader DataReader;
        DBConnection dbconnect = new DBConnection();
        string store = "Hualde Convenience Store";
        string address = "Rizal Ilawod, Cabatuan, Iloilo";
        //string tin = "non-VAT Reg TIN: 248-292-082-000 ";
        PosForm f;
        public ReceiptForm(PosForm frm)
        {
            InitializeComponent();
            connect = new MySqlConnection();
            connect.ConnectionString = dbconnect.DataConnection();
            f = frm;
            this.KeyPreview = true;
        }

        private void ReceiptForm_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();

        }

       

        public void LoadReport(string pcash, string pchange)
        {
            ReportDataSource rptDataSource;
            try
            {
                this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Reports\Report1.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();

                DataSet1 ds = new DataSet1();
                MySqlDataAdapter da = new MySqlDataAdapter();

                connect.Open();
                da.SelectCommand = new MySqlCommand("SELECT c.id, c.transno, c.pcode, c.price, c.qty, c.discount, c.total, c.sdate, c.status, p.pdescription FROM cart_tbl as c inner join producttbl as p ON p.pcode = c.pcode WHERE transno LIKE '" + f.TransNoLbl.Text + "'",connect);
                da.Fill(ds.Tables["dtSold"]);
                connect.Close();

                ReportParameter pVatable = new ReportParameter("pVatable", f.VatableLbl.Text);
                ReportParameter pVat = new ReportParameter("pVat", f.VatLbl.Text);
                ReportParameter pDiscount = new ReportParameter("pDiscount", f.DiscountLbl.Text);
                ReportParameter pTotal = new ReportParameter("pTotal", f.TotalLbl.Text);
                ReportParameter pCash = new ReportParameter("pCash", pcash);
                ReportParameter pChange = new ReportParameter("pChange", pchange);
                ReportParameter pStore = new ReportParameter("pStore", store);
                ReportParameter pAddress = new ReportParameter("pAddress", address);
                ReportParameter pTransaction = new ReportParameter("pTransaction", "Invoice #:" + f.TransNoLbl.Text);
                ReportParameter pCashier= new ReportParameter("pCashier", f.usernamelbl.Text);
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
               // reportViewer1.LocalReport.SetParameters(pTin);

                rptDataSource = new ReportDataSource("DataSet1",ds.Tables["dtSold"]);
                reportViewer1.LocalReport.DataSources.Add(rptDataSource);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ReceiptForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
