using Microsoft.Reporting.WinForms;
using PTS_For_Cut._Main;
using PTS_For_Cut.Myclass;
using System.Data;

namespace PTS_For_Cut.ScanBundle.Delivery_Note
{
    public partial class Delivery_NotePrivew : Form
    {
        AppData.BD_DN_tbDataTable _DN;
        AppData.BD_DN_SumtbDataTable _DN_SUM;

        //public Delivery_NotePrivew(AppData.BD_DN_tbDataTable DN)
        //{
        //    InitializeComponent();
        //    _DN = DN;

        // }
        public Delivery_NotePrivew(AppData.BD_DN_tbDataTable DN, AppData.BD_DN_SumtbDataTable DN_SUM)
        {
            InitializeComponent();
            _DN = DN;
            _DN_SUM = DN_SUM;
        }

        private void Delivery_NotePrivew_Load(object sender, EventArgs e)
        {
            //D:\Program TK by Phuriwaj\PTS Cut v2\PTS For Cut\PTS For Cut\ScanBundle\Delivery_Note\DNReport.rdlc
            string Fac_Code = Properties.Settings.Default.Factory;
            string location = ScanInOutWithSummery.ins.Location;
            string txtSql = @"SELECT `sc_Code`, `sc_Name`, `sc_Address`, `sc_Tax`, `sc_Tel`, `ip_Network`, `group_Fac` 
                            FROM `sup_cus_tb` WHERE `sc_Code` IN ('" + Fac_Code + "','" + location + "') ORDER BY FIELD(`sc_Code`, '" + Fac_Code + "','" + location + "');";
            DataTable dtFactoryList = ConnectMySQL.MySQLtoDataTable(txtSql);
            if (dtFactoryList.Rows.Count == 2)
            {
                var dtfac = dtFactoryList.Rows[0];
                var dtSup = dtFactoryList.Rows[1];

                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "DataSet1";
                reportDataSource.Value = _DN;

                ReportDataSource reportDataSource2 = new ReportDataSource();
                reportDataSource2.Name = "DataSet2";
                reportDataSource2.Value = _DN_SUM;

                reportViewer1.LocalReport.ReportEmbeddedResource = "PTS_For_Cut.ScanBundle.Delivery_Note.DNReport.rdlc";
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
                System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();
                pg.Margins.Top = 0;
                pg.Margins.Bottom = 0;
                pg.Margins.Left = 0;
                pg.Margins.Right = 0;
                reportViewer1.SetPageSettings(pg);

                ReportParameter so = new ReportParameter("SO", ScanInOutWithSummery.ins._so);
                reportViewer1.LocalReport.SetParameters(so);
                ReportParameter style = new ReportParameter("Style", "");
                reportViewer1.LocalReport.SetParameters(style);
                ReportParameter factory = new ReportParameter("Factory", dtfac["sc_Name"].ToString());
                reportViewer1.LocalReport.SetParameters(factory);
                ReportParameter Address = new ReportParameter("Address", dtfac["sc_Address"].ToString() + " Tel:" + dtfac["sc_Tel"].ToString());
                reportViewer1.LocalReport.SetParameters(Address);
                ReportParameter TaxID = new ReportParameter("TaxID", dtfac["sc_Tax"].ToString());
                reportViewer1.LocalReport.SetParameters(TaxID); //Supplier
                ReportParameter supplier = new ReportParameter("Supplier", dtSup["sc_Name"].ToString());
                reportViewer1.LocalReport.SetParameters(supplier);
                ReportParameter SupAddress = new ReportParameter("SupAddress", dtSup["sc_Address"].ToString() + " Tel:" + dtSup["sc_Tel"].ToString());
                reportViewer1.LocalReport.SetParameters(SupAddress);
                ReportParameter SupTaxID = new ReportParameter("SupTaxID", dtSup["sc_Tax"].ToString()); //_so
                reportViewer1.LocalReport.SetParameters(SupTaxID);
                ReportParameter DocID = new ReportParameter("DocID", ScanInOutWithSummery.ins.DNID);
                reportViewer1.LocalReport.SetParameters(DocID);
                ReportParameter dec_From = new ReportParameter("dec_From", ScanInOutWithSummery.ins.dec); //_so
                reportViewer1.LocalReport.SetParameters(dec_From);
                ReportParameter dec_To = new ReportParameter("dec_To", location);
                reportViewer1.LocalReport.SetParameters(dec_To);
                ReportParameter Tel = new ReportParameter("Tel", dtfac["sc_Tel"].ToString()); //_so
                reportViewer1.LocalReport.SetParameters(Tel);
                ReportParameter SupTel = new ReportParameter("SupTel", dtSup["sc_Tel"].ToString());
                reportViewer1.LocalReport.SetParameters(SupTel);

                this.reportViewer1.RefreshReport();
            }
            else
            {
                MessageBox.Show("Data should include both factory and supplier.", "Imformation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
