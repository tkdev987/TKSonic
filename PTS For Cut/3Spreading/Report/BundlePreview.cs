using Microsoft.Reporting.WinForms;
using PTS_For_Cut._Main;

namespace PTS_For_Cut._3Spreading.Report
{
    public partial class BundlePreview : Form
    {
        AppData.BundleTbDataTable _Bundle;
        public BundlePreview(AppData.BundleTbDataTable Bundle)
        {
            InitializeComponent();
            _Bundle = Bundle;
        }

        private void BundlePreview_Load(object sender, EventArgs e)
        {
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DataSet1";
            reportDataSource.Value = _Bundle;//D:\Program TK by Phuriwaj\PTS For Cut\PTS For Cut\Spreading\Create\Report1.rdlc ==D:\Program TK by Phuriwaj\PTS For Cut\PTS For Cut\3Spreading\Create\Report1.rdlc
            reportViewer1.LocalReport.ReportEmbeddedResource = "PTS_For_Cut._3Spreading.Report.BundleReport.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();
            pg.Margins.Top = 0;
            pg.Margins.Bottom = 0;
            pg.Margins.Left = 0;
            pg.Margins.Right = 0;
            reportViewer1.SetPageSettings(pg);

            ReportParameter so = new ReportParameter("rpso", CuttingReport.ins.rSO);
            reportViewer1.LocalReport.SetParameters(so);
            ReportParameter style = new ReportParameter("rpstyle", CuttingReport.ins.rStyle);
            reportViewer1.LocalReport.SetParameters(style);
            ReportParameter cus = new ReportParameter("rpcus", CuttingReport.ins.rCus);
            reportViewer1.LocalReport.SetParameters(cus);
            ReportParameter ClothingPart = new ReportParameter("rpClothingPart", CuttingReport.ins.rClothingPart);
            reportViewer1.LocalReport.SetParameters(ClothingPart);
            ReportParameter cusStyle = new ReportParameter("rpcusStyle", CuttingReport.ins.rCusStyle);
            reportViewer1.LocalReport.SetParameters(cusStyle);
            ReportParameter mer = new ReportParameter("rpMer", CuttingReport.ins.rMer);
            reportViewer1.LocalReport.SetParameters(mer);
            ReportParameter Header = new ReportParameter("rpHeader", CuttingReport.ins.rHeader);
            reportViewer1.LocalReport.SetParameters(Header);
            //ReportParameter Deco = new ReportParameter("rpDeco", CuttingReport.ins.rDeco);
            //reportViewer1.LocalReport.SetParameters(Deco);
            ReportParameter Place = new ReportParameter("rpPlace", CuttingReport.ins.rPlace);
            reportViewer1.LocalReport.SetParameters(Place);

            this.reportViewer1.RefreshReport();

        }
    }
}
