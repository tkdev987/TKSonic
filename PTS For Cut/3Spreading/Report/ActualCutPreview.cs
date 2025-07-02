using Microsoft.Reporting.WinForms;
using PTS_For_Cut._Main;

namespace PTS_For_Cut._3Spreading.Report
{

    public partial class ActualCutPreview : Form
    {
        AppData.ActualCutTbDataTable _ActualCut;
        AppData.CuttingRemarkByColorDataTable _ActualCutRemark;
        public ActualCutPreview(AppData.ActualCutTbDataTable actualCut, AppData.CuttingRemarkByColorDataTable actualCutRemark)
        {
            InitializeComponent();
            _ActualCut = actualCut;
            _ActualCutRemark = actualCutRemark;
        }

        private void ActualCutPreview_Load(object sender, EventArgs e)
        {
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DataSet1";
            reportDataSource.Value = _ActualCut;


            ReportDataSource reportDataSource2 = new ReportDataSource();
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = _ActualCutRemark;
            //D:\Program TK by Phuriwaj\PTS For Cut\PTS For Cut\Spreading\Create\Report1.rdlc ==D:\Program TK by Phuriwaj\PTS For Cut\PTS For Cut\3Spreading\Create\Report1.rdlc
            reportViewer1.LocalReport.ReportEmbeddedResource = "PTS_For_Cut._3Spreading.Report.ActualCutReport.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();

            reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            reportViewer1.LocalReport.DataSources.Add(reportDataSource2);

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
            ReportParameter cusCode = new ReportParameter("rpcusCode", CuttingReport.ins.rCusCode);
            reportViewer1.LocalReport.SetParameters(cusCode);
            ReportParameter cusStyle = new ReportParameter("rpcusStyle", CuttingReport.ins.rCusStyle);
            reportViewer1.LocalReport.SetParameters(cusStyle);
            ReportParameter jobStart = new ReportParameter("rpJobStart", CuttingReport.ins.rjobStart);
            reportViewer1.LocalReport.SetParameters(jobStart);
            ReportParameter cutFinishDate = new ReportParameter("rpCutFinish", CuttingReport.ins.rCutFinish);
            reportViewer1.LocalReport.SetParameters(cutFinishDate);
            ReportParameter Deadline = new ReportParameter("rpDeadline", CuttingReport.ins.rDeadline);
            reportViewer1.LocalReport.SetParameters(Deadline);
            ReportParameter cutBy = new ReportParameter("rpCutBy", CuttingReport.ins.rCutBy);
            reportViewer1.LocalReport.SetParameters(cutBy);
            ReportParameter mer = new ReportParameter("rpMer", CuttingReport.ins.rMer);
            reportViewer1.LocalReport.SetParameters(mer);
            ReportParameter price = new ReportParameter("rpPrice", CuttingReport.ins.rPrice);
            reportViewer1.LocalReport.SetParameters(price);
            ReportParameter IssueAccount = new ReportParameter("rpAccountDate", CuttingReport.ins.rIssuetoAccount);
            reportViewer1.LocalReport.SetParameters(IssueAccount);
            ReportParameter PlaceSew = new ReportParameter("rpPlaceSew", CuttingReport.ins.rPlaceSew);
            reportViewer1.LocalReport.SetParameters(PlaceSew);
            ReportParameter PlaceEmbro = new ReportParameter("rpEmpbroPl", CuttingReport.ins.rPlaceEmbro);
            reportViewer1.LocalReport.SetParameters(PlaceEmbro);
            ReportParameter PlacePrint = new ReportParameter("rpPrintPl", CuttingReport.ins.rPlacePrint);
            reportViewer1.LocalReport.SetParameters(PlacePrint);
            ReportParameter SoRemark = new ReportParameter("rpSoRemark", CuttingReport.ins.rpSoRemark);
            reportViewer1.LocalReport.SetParameters(SoRemark);
            ReportParameter ProductType = new ReportParameter("rpProductType", CuttingReport.ins.rpProduct_Type);
            reportViewer1.LocalReport.SetParameters(ProductType);
            ReportParameter Brand = new ReportParameter("rpBrand", CuttingReport.ins.rpBrand);
            reportViewer1.LocalReport.SetParameters(Brand);

            this.reportViewer1.RefreshReport();
        }
    }
}
