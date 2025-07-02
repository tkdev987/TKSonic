using Microsoft.Reporting.WinForms;
using PTS_For_Cut._Main;
using PTS_For_Cut.Main;
using PTS_For_Cut.Myclass;
using QRCoder;
using System.Data;

namespace PTS_For_Cut.Spreading.Create
{
    public partial class SDPreviweReport : Form
    {
        DataSet1.dtRetioDataTable _SD;

        //public fr_PL_Report(Appdata.PackingListDetailDataTable Pk)
        //{
        //    InitializeComponent();
        //    _Pk = Pk;
        //}
        public SDPreviweReport(DataSet1.dtRetioDataTable SD)
        {
            InitializeComponent();
            _SD = SD;
        }

        private void SDPreviweReport_Load(object sender, EventArgs e)//`c_warehouse1_bc_tb`.`Unit`
        {
            if (HomePage.ins.Regis_SD_ID != "")
            {
                // MessageBox.Show(HomePage.ins.Regis_SD_ID);
                DataTable dtFb = ConnectMySQL.MySQLtoDataTable("SELECT `a`.`Barcode`,`a`.`Plies`,`a`.`Qty`,`a`.`YardNet`,`a`.`SeparateStatus`,`b`.`Unit`,`b`.`LotNo`, `b`.`DryLot`,`b`.`RollNo`,`b`.`Color` " +
                    "FROM `c_wh1_bc_sdactual_tb` AS `a` " +
                    "JOIN `c_warehouse1_bc_tb` AS `b` ON `a`.`Barcode`=`b`.`Barcode`" +
                    "WHERE `a`.`SD_ListDoc_No`LIKE '" + ImportCutPlan.ins.rDocNo + "'");
                string reportPath = "";
                if (ImportCutPlan.ins.LangSelectIndex == 0)
                {
                    reportPath = "PTS_For_Cut._3Spreading.Create.Report3.rdlc";
                }
                else if (ImportCutPlan.ins.LangSelectIndex == 1)
                {
                    reportPath = "PTS_For_Cut._3Spreading.Create.Report2.rdlc";
                }

                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "DataSet1";
                reportDataSource.Value = _SD;
                reportViewer1.LocalReport.ReportEmbeddedResource = reportPath;
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();
                pg.Margins.Top = 0;
                pg.Margins.Bottom = 0;
                pg.Margins.Left = 0;
                pg.Margins.Right = 0;
                reportViewer1.SetPageSettings(pg);
                ReportParameter qrCodeParameter = new ReportParameter("QRCodeImage", Convert.ToBase64String(ImgByte(ImportCutPlan.ins.rDocNo)));
                reportViewer1.LocalReport.SetParameters(qrCodeParameter);

                ReportParameter DocNo = new ReportParameter("rpDocNo", ImportCutPlan.ins.rDocNo);
                reportViewer1.LocalReport.SetParameters(DocNo);
                ReportParameter rRegisID = new ReportParameter("rRegisID", HomePage.ins.Regis_SD_ID);
                reportViewer1.LocalReport.SetParameters(rRegisID);
                ReportParameter So = new ReportParameter("rpSo", ImportCutPlan.ins.rSO);
                reportViewer1.LocalReport.SetParameters(So);
                ReportParameter FabricType = new ReportParameter("rpFabricType", ImportCutPlan.ins.rFabricType);
                reportViewer1.LocalReport.SetParameters(FabricType);
                ReportParameter St = new ReportParameter("rpSt", ImportCutPlan.ins.rStyle);
                reportViewer1.LocalReport.SetParameters(St);
                ReportParameter MarkId = new ReportParameter("rpMarkId", ImportCutPlan.ins.rMarkID);
                reportViewer1.LocalReport.SetParameters(MarkId);
                ReportParameter Plies = new ReportParameter("rpPlies", ImportCutPlan.ins.rPlies);
                reportViewer1.LocalReport.SetParameters(Plies);
                ReportParameter TableNo = new ReportParameter("rpTableNo", ImportCutPlan.ins.rTableNo);
                reportViewer1.LocalReport.SetParameters(TableNo);
                ReportParameter Color = new ReportParameter("rpColor", ImportCutPlan.ins.rColor);
                reportViewer1.LocalReport.SetParameters(Color);
                ReportParameter MarkerWidth = new ReportParameter("rpW", ImportCutPlan.ins.rMarkerWidth);
                reportViewer1.LocalReport.SetParameters(MarkerWidth);
                ReportParameter MarkerLengthCm = new ReportParameter("rpLCm", ImportCutPlan.ins.rMarkerLengthCm);
                reportViewer1.LocalReport.SetParameters(MarkerLengthCm);
                ReportParameter MarkerLengthYard = new ReportParameter("rpLY", ImportCutPlan.ins.rMarkerLengthYard);
                reportViewer1.LocalReport.SetParameters(MarkerLengthYard);
                ReportParameter Dtp = new ReportParameter("rpDateCreate", ImportCutPlan.ins.rDtp); //rAutoCutCode
                reportViewer1.LocalReport.SetParameters(Dtp);
                ReportParameter Shad = new ReportParameter("rpShading", ImportCutPlan.ins.rShading);
                reportViewer1.LocalReport.SetParameters(Shad);
                ReportParameter AutoCut = new ReportParameter("rpCutCode", ImportCutPlan.ins.rAutoCutCode);
                reportViewer1.LocalReport.SetParameters(AutoCut);


                if (dtFb.Rows.Count > 0)
                {
                    double ttWeight = 0;
                    double ttLength = 0;
                    double ttWeightig = 0;
                    string uunit = dtFb.Rows[0]["Unit"].ToString();
                    for (int i = 0; i < dtFb.Rows.Count; i++)
                    {
                        if (dtFb.Rows[i]["Barcode"] != DBNull.Value)
                        {//`b`.`LotNo`, `b`.`DryLot`,`b`.`RollNo` 
                            string color = dtFb.Rows[i]["Color"].ToString();
                            string lot = dtFb.Rows[i]["LotNo"].ToString();
                            string dyeLot = dtFb.Rows[i]["DryLot"].ToString();
                            string rollNo = dtFb.Rows[i]["RollNo"].ToString();
                            string fb1 = dtFb.Rows[i]["Barcode"].ToString();
                            string Lfb1 = dtFb.Rows[i]["Plies"].ToString();
                            string wt = dtFb.Rows[i]["Qty"].ToString();//
                            string lg = dtFb.Rows[i]["YardNet"].ToString();
                            string chSep = dtFb.Rows[i]["SeparateStatus"].ToString();
                            string MarkSep = "";
                            if (chSep == "True")
                            {
                                MarkSep = "[***]";
                            }
                            ReportParameter rColor = new ReportParameter("rColor" + (i + 1).ToString(), "Co:" + color);
                            reportViewer1.LocalReport.SetParameters(rColor);
                            ReportParameter rFbt1 = new ReportParameter("rFBT" + (i + 1).ToString(), fb1 + MarkSep);
                            reportViewer1.LocalReport.SetParameters(rFbt1);
                            ReportParameter l1 = new ReportParameter("rL" + (i + 1).ToString(), "Plies:" + Lfb1);
                            reportViewer1.LocalReport.SetParameters(l1);
                            ReportParameter wtt = new ReportParameter("rw" + (i + 1).ToString(), "Ig:" + wt + uunit + "/L: " + lg + "YDS");
                            reportViewer1.LocalReport.SetParameters(wtt);
                            ReportParameter rLot = new ReportParameter("rLot" + (i + 1).ToString(), lot);
                            reportViewer1.LocalReport.SetParameters(rLot);
                            ReportParameter rdyeLot = new ReportParameter("rDye" + (i + 1).ToString(), "DyeL:" + dyeLot);
                            reportViewer1.LocalReport.SetParameters(rdyeLot);
                            ReportParameter rRollNo = new ReportParameter("rRN" + (i + 1).ToString(), rollNo);
                            reportViewer1.LocalReport.SetParameters(rRollNo);
                            ReportParameter rQ = new ReportParameter("rQ" + (i + 1).ToString(), Convert.ToBase64String(ImgByte(fb1)));
                            reportViewer1.LocalReport.SetParameters(rQ);
                        }
                        if (dtFb.Rows[i]["YardNet"] != DBNull.Value)
                        {
                            ttLength += double.Parse(dtFb.Rows[i]["YardNet"].ToString());
                        }
                        if (dtFb.Rows[i]["Qty"] != DBNull.Value)
                        {
                            ttWeightig += double.Parse(dtFb.Rows[i]["Qty"].ToString());
                        }
                    }//rpIgLength

                    ReportParameter _Length = new ReportParameter("rTotalLength", ttLength.ToString("##.##"));
                    reportViewer1.LocalReport.SetParameters(_Length);
                    ReportParameter _Weigthig = new ReportParameter("rpIgLength", ttWeightig.ToString("##.##") + uunit);
                    reportViewer1.LocalReport.SetParameters(_Weigthig);
                }
                this.reportViewer1.RefreshReport();
            }
            else
            {
                MessageBox.Show("Please Select Factory On Main Page.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static Bitmap GenerateQRCodeImage(string text)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(30);
            return qrCodeImage;
        }
        static byte[] ImgByte(string stringToimg)
        {
            Bitmap qrCodeImage = GenerateQRCodeImage(stringToimg);
            byte[] qrCodeBytes;
            using (var stream = new System.IO.MemoryStream())
            {
                qrCodeImage.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                qrCodeBytes = stream.ToArray();
            }
            return qrCodeBytes;
        }
    }
}
