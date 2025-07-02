using Microsoft.Reporting.WinForms;
using PTS_For_Cut._Main;

namespace PTS_For_Cut._9_1Inc
{
    public partial class IncBreakReport : Form
    {
        DataSet1.IncRateTableDataTable _Inc;
        //public IncBreakReport(DataSet1.IncRateTableDataTable Inc)
        public IncBreakReport(DataSet1.IncRateTableDataTable Inc)
        {
            InitializeComponent();
            _Inc = Inc;
        }

        private void IncBreakReport_Load(object sender, EventArgs e)
        {
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DataSetInc";
            reportDataSource.Value = _Inc;
            PreReportInc.LocalReport.ReportEmbeddedResource = "PTS_For_Cut._9_1Inc.ReportInc.rdlc";
            PreReportInc.LocalReport.DataSources.Clear();
            PreReportInc.LocalReport.DataSources.Add(reportDataSource);
            System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();
            pg.Margins.Top = 0;
            pg.Margins.Bottom = 0;
            pg.Margins.Left = 0;
            pg.Margins.Right = 0;


            MessageBox.Show(Inc_Break.ins.ReUrlImg);

            FileInfo fi = new FileInfo(Inc_Break.ins.ReUrlImg);
            ReportParameter rpUrlImg = new ReportParameter("prUrlImg", new Uri(Inc_Break.ins.ReUrlImg).AbsoluteUri);
            PreReportInc.LocalReport.EnableExternalImages = true;
            PreReportInc.LocalReport.SetParameters(rpUrlImg);

            ReportParameter rpTitle = new ReportParameter("prTitleName", Inc_Break.ins.ReGroup + " " + "Incentive Break");
            PreReportInc.LocalReport.SetParameters(rpTitle);
            ReportParameter prDoc = new ReportParameter("prDoc", Inc_Break.ins.ReDoc);
            PreReportInc.LocalReport.SetParameters(prDoc);
            ReportParameter prStyle = new ReportParameter("prStyle", Inc_Break.ins.ReStyle);
            PreReportInc.LocalReport.SetParameters(prStyle);

            ReportParameter prCustomer = new ReportParameter("prCustomer", Inc_Break.ins.ReCus);
            PreReportInc.LocalReport.SetParameters(prCustomer);
            ReportParameter prCustomerType = new ReportParameter("prCustomerType", Inc_Break.ins.ReCusType);
            PreReportInc.LocalReport.SetParameters(prCustomerType);
            ReportParameter prProductType = new ReportParameter("prProductType", Inc_Break.ins.ReProType);
            PreReportInc.LocalReport.SetParameters(prProductType);


            ReportParameter rpPrice = new ReportParameter("prPrice", Inc_Break.ins.RePrice);
            PreReportInc.LocalReport.SetParameters(rpPrice);
            ReportParameter rpPriceInc = new ReportParameter("prPriceInc", Inc_Break.ins.ReIncPrice);
            PreReportInc.LocalReport.SetParameters(rpPriceInc);
            ReportParameter rpSAM = new ReportParameter("prSAM", Inc_Break.ins.ReSAM);
            PreReportInc.LocalReport.SetParameters(rpSAM);
            ReportParameter rpEffSale = new ReportParameter("prEffSale", Inc_Break.ins.ReEffSale);
            PreReportInc.LocalReport.SetParameters(rpEffSale);
            ReportParameter rpOutput = new ReportParameter("prOutput", Inc_Break.ins.ReOutput);
            PreReportInc.LocalReport.SetParameters(rpOutput);
            ReportParameter rpEmpInc = new ReportParameter("prEmpInc", Inc_Break.ins.ReEmpInc);
            PreReportInc.LocalReport.SetParameters(rpEmpInc);
            ReportParameter rpLineLeadInc = new ReportParameter("prLineInc", Inc_Break.ins.ReLineLeadInc);
            PreReportInc.LocalReport.SetParameters(rpLineLeadInc);
            ReportParameter rpSupInc = new ReportParameter("prSupInc", Inc_Break.ins.ReSupInc);
            PreReportInc.LocalReport.SetParameters(rpSupInc);
            ReportParameter prOperator = new ReportParameter("prOperator", Inc_Break.ins.ReOperator);
            PreReportInc.LocalReport.SetParameters(prOperator);

            this.PreReportInc.RefreshReport();

        }
    }
}
