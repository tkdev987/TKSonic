using Production_Tracking_systems.myClass;
using PTS_For_Cut._Main;
using PTS_For_Cut.Main;
using PTS_For_Cut.myClass;
using PTS_For_Cut.Myclass;
using QRCoder;
using System.Data;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PTS_For_Cut._4BundleGenerate
{
    public partial class BundleGen : Form
    {
        public string selectRowSD_ID = "";
        public string selectRowSO = "";
        public string selectRowStyle = "";
        private string Group_work = "";
        public string stringToPrint;
        private int numberOfItemsPerPage;
        private int numberOfItemsPrintedSoFar;
        public static BundleGen ins;
        private static BundleGen _instance;
        private StringBuilder sb = new StringBuilder();
        private PrintDocument printDocument3 = new PrintDocument();
        private System.Windows.Forms.PrintDialog printDialog3;
        private DataGridView gvSubColumn = new DataGridView();
        DataTable dtBundleAll = new DataTable();
        DataTable dtBundleGroup = new DataTable();
        DataTable dtBundleSingle = new DataTable();
        public static BundleGen Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new BundleGen();
                return _instance;
            }
        }
        public BundleGen()
        {
            InitializeComponent();
            ins = this;
            printDocument3.PrintPage += new PrintPageEventHandler(printDocument3_PrintPage);
            printDialog3 = new System.Windows.Forms.PrintDialog();

        }

        private void SearchSD()
        {
            if (tbSearchSD_ID1.Text.Length > 3)
            {
                gvClothingPart.DataSource = null;
                gvSize.DataSource = null;
                gvFabric.DataSource = null;

                //HomePage.ins.ID_for_CreateBundle = "ScanOutSD";
                ConnectMySQL.DisplayAndSearch("SELECT `a`.`SD_ListDoc_No`, `a`.`SO`, `a`.`Style`, DATE(`b`.`SD_ScanOut`)AS `Spreading Date`,(`a`.`Table_No`) AS `Table` ,`a`.`FabricType`,`c`.`Customer_Style` " +
                    "FROM `a_a1_spreading_list_tb`AS`a` LEFT JOIN `a_a3_scandoc_sd_ct_tb`AS`b`ON`a`.`SD_ListDoc_No`=`b`.`SD_ListDoc_No` " +
                    "LEFT JOIN `so_tb`AS`c`ON`a`.`SO`=`c`.`So`" +
                    "WHERE `a`.`SD_ListDoc_No`LIKE '%" + tbSearchSD_ID1.Text + "%' AND `b`.`SD_ScanOut`IS NOT NULL " +
                    "GROUP BY `a`.`SD_ListDoc_No`;", gvDisBundle);
                ConnectMySQL.DisplayAndSearch("SELECT `Bundle_ID`AS `No.`, `QRCodeBundle`AS `QRCode Bundle`, `BundleNo`AS `Bundle No.`, `Color`, `Size`,`DyeLot`, " +
                    "`ClothingPart`AS `Clothing Part`, `Deco`AS `Decoration`, `Plies`AS`PliesActual`, `MainPart`, `QTY`,`BarcodeRef`  FROM `a_b1_bundle_tb` " +
                    "WHERE `SD_ListDoc_No`='89898';", gvGenBundle);

                gvSubColumn.DataSource = gvGenBundle.DataSource;

                if (gvGenBundle.Rows.Count > 0)
                {

                    btSaveBundle1.Visible = false;
                    btPrintQrCodeBundle.Visible = true;
                    tbOffsetX1.Visible = true;
                    lbOffsetX.Visible = true;
                }

                gvDisBundle.Columns["SD_ListDoc_No"].Width = 150;
                gvDisBundle.Columns["SO"].Width = 150;
                gvDisBundle.Columns["Style"].Width = 150;//
                gvDisBundle.Columns["Spreading Date"].Width = 150;
            }
        }
        private void tbSearchSD_ID1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchSD();
            }
        }


        private void btBundlePopup1_Click(object sender, EventArgs e)
        {
            SearchSD();
        }

        private void printDocument3_PrintPage(object sender, PrintPageEventArgs e)
        {

            try
            {
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.InterpolationMode = InterpolationMode.High;

                // Draw some text along some line segments.

                float pageWidth = e.PageSettings.PrintableArea.Width;
                float pageHeight = e.PageSettings.PrintableArea.Height;
                int _x = int.Parse(tbOffsetX1.Text);
                int _y = int.Parse(tbOffsetY1.Text);
                int offsetY = 90;
                int height = 0;


                for (int l = numberOfItemsPrintedSoFar; l < gvGenBundle.Rows.Count; l++)
                {
                    numberOfItemsPerPage = numberOfItemsPerPage + 1;

                    if (numberOfItemsPerPage <= 1)
                    {
                        int checkLastSticker = gvGenBundle.Rows.Count - numberOfItemsPrintedSoFar;
                        //string printerName = tbPrinterName.Text; // Replace with your printer's name

                        //PrintDocument printDocument = new PrintDocument();
                        //foreach (string printer in PrinterSettings.InstalledPrinters)
                        //{
                        //    if (printer == printerName)
                        //    {
                        //        printDocument.PrinterSettings.PrinterName = printerName;
                        //        break;
                        //    }
                        //}
                        //if (printDocument.PrinterSettings.PrinterName == printerName)
                        //{
                        if (checkLastSticker >= 3)
                        {
                            string qtyStick1 = gvGenBundle.Rows[l].Cells["No."].Value.ToString() + "/" + dtBundleAll.Rows.Count.ToString();
                            string bNo1 = gvGenBundle.Rows[l].Cells["Bundle No."].Value.ToString();
                            Bitmap bm1 = (Bitmap)gvGenBundle.Rows[l].Cells["Image"].Value;
                            //e.Graphics.DrawImage(bm1, new RectangleF(60 + _x, 54 + _y, 65, 65));
                            imgDraw(e.Graphics, bm1, 60 + _x, 54 + _y);
                            DrawTextOnSegment(e.Graphics, "-------------" + gvGenBundle.Rows[l].Cells["QRCode Bundle"].Value.ToString(), 12 + _x, 104 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, qtyStick1, 81 + _x, 8 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, tbTableCut2.Text, 81 + _x, 15 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, selectRowSD_ID, 12 + _x, 8 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, selectRowSO, 12 + _x, 15 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, selectRowStyle, 12 + _x, 22 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, "Part:" + gvGenBundle.Rows[l].Cells["Clothing Part"].Value.ToString(), 12 + _x, 30 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, "Dec.:" + gvGenBundle.Rows[l].Cells["Decoration"].Value.ToString(), 12 + _x, 37 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, "Clor:" + gvGenBundle.Rows[l].Cells["Color"].Value.ToString(), 12 + _x, 44 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, "DLot." + gvGenBundle.Rows[l].Cells["Dyelot"].FormattedValue.ToString(), 12 + _x, 52 + _y, 0, 6);
                            if (Convert.ToBoolean(gvGenBundle.Rows[l].Cells["MainPart"].Value.ToString()))
                            {
                                DrawTextOnSegment(e.Graphics, "★★★★★", 12 + _x, 62 + _y, 0, 5);
                                DrawTextOnSegment(e.Graphics, "★Main★", 15 + _x, 68 + _y, 0, 5);
                            }
                            DrawTextOnSegment(e.Graphics, "Siz:", 12 + _x, 76 + _y, 0, 6);
                            int size_size1 = 5;
                            if (gvGenBundle.Rows[l].Cells["Size"].FormattedValue.ToString().Length < 6)
                            {
                                size_size1 = 8;
                            }
                            DrawTextOnSegment(e.Graphics, gvGenBundle.Rows[l].Cells["Size"].FormattedValue.ToString(), 26 + _x, 76 + _y, 0, size_size1);
                            DrawTextOnSegment(e.Graphics, "Bun:", 12 + _x, 88 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, bNo1, 30 + _x, 86 + _y, 0, 8);
                            DrawTextOnSegment(e.Graphics, "QTY:", 12 + _x, 98 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, gvGenBundle.Rows[l].Cells["QTY"].FormattedValue.ToString(), 31 + _x, 96 + _y, 0, 8);
                            DrawTextOnSegment(e.Graphics, tbRemarkStick.Text, 122 + _x, 8 + _y, 90, 6);
                            //--------
                            string qtyStick2 = gvGenBundle.Rows[l + 1].Cells["No."].Value.ToString() + "/" + dtBundleAll.Rows.Count.ToString();
                            string bNo2 = gvGenBundle.Rows[l + 1].Cells["Bundle No."].Value.ToString();
                            Bitmap bm2 = (Bitmap)gvGenBundle.Rows[l + 1].Cells["Image"].Value;

                            imgDraw(e.Graphics, bm2, 188 + _x, 54 + _y);
                            DrawTextOnSegment(e.Graphics, "-------------" + gvGenBundle.Rows[l + 1].Cells["QRCode Bundle"].Value.ToString(), 140 + _x, 104 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, qtyStick2, 209 + _x, 8 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, tbTableCut2.Text, 209 + _x, 15 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, selectRowSD_ID, 140 + _x, 8 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, selectRowSO, 140 + _x, 15 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, selectRowStyle, 140 + _x, 23 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, "Part:" + gvGenBundle.Rows[l + 1].Cells["Clothing Part"].Value.ToString(), 140 + _x, 30 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, "Dec.:" + gvGenBundle.Rows[l + 1].Cells["Decoration"].Value.ToString(), 140 + _x, 37 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, "Color:" + gvGenBundle.Rows[l + 1].Cells["Color"].Value.ToString(), 140 + _x, 44 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, "DLot." + gvGenBundle.Rows[l + 1].Cells["Dyelot"].FormattedValue.ToString(), 140 + _x, 52 + _y, 0, 6);
                            if (Convert.ToBoolean(gvGenBundle.Rows[l + 1].Cells["MainPart"].Value.ToString()))
                            {
                                DrawTextOnSegment(e.Graphics, "★★★★★", 140 + _x, 62 + _y, 0, 5);
                                DrawTextOnSegment(e.Graphics, "★Main★", 143 + _x, 68 + _y, 0, 5);
                            }
                            DrawTextOnSegment(e.Graphics, "Siz:", 140 + _x, 78 + _y, 0, 6);
                            int size_size2 = 5;
                            if (gvGenBundle.Rows[l + 1].Cells["Size"].FormattedValue.ToString().Length < 6)
                            {
                                size_size2 = 8;
                            }
                            DrawTextOnSegment(e.Graphics, gvGenBundle.Rows[l + 1].Cells["Size"].FormattedValue.ToString(), 154 + _x, 76 + _y, 0, size_size2);
                            DrawTextOnSegment(e.Graphics, "Bun:", 140 + _x, 88 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, bNo2, 160 + _x, 86 + _y, 0, 8);
                            DrawTextOnSegment(e.Graphics, "QTY:", 140 + _x, 98 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, gvGenBundle.Rows[l + 1].Cells["QTY"].FormattedValue.ToString(), 160 + _x, 96 + _y, 0, 8);
                            DrawTextOnSegment(e.Graphics, tbRemarkStick.Text, 250 + _x, 8 + _y, 90, 6);

                            ///////////////////////////////////////////

                            //-------------------------------------------------------------------------
                            string qtyStick3 = gvGenBundle.Rows[l + 2].Cells["No."].Value.ToString() + "/" + dtBundleAll.Rows.Count.ToString();
                            string bNo3 = gvGenBundle.Rows[l + 2].Cells["Bundle No."].Value.ToString();
                            Bitmap bm3 = (Bitmap)gvGenBundle.Rows[l + 2].Cells["Image"].Value;

                            imgDraw(e.Graphics, bm3, 315 + _x, 54 + _y);
                            DrawTextOnSegment(e.Graphics, "-------------" + gvGenBundle.Rows[l + 2].Cells["QRCode Bundle"].Value.ToString(), 268 + _x, 104 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, qtyStick3, 337 + _x, 8 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, tbTableCut2.Text, 337 + _x, 15 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, selectRowSD_ID, 268 + _x, 8 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, selectRowSO, 268 + _x, 15 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, selectRowStyle, 268 + _x, 23 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, "Part:" + gvGenBundle.Rows[l + 2].Cells["Clothing Part"].Value.ToString(), 268 + _x, 30 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, "Dec.:" + gvGenBundle.Rows[l + 2].Cells["Decoration"].Value.ToString(), 268 + _x, 37 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, "Color:" + gvGenBundle.Rows[l + 2].Cells["Color"].Value.ToString(), 268 + _x, 44 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, "DLot." + gvGenBundle.Rows[l + 2].Cells["Dyelot"].FormattedValue.ToString(), 268 + _x, 52 + _y, 0, 6);
                            if (Convert.ToBoolean(gvGenBundle.Rows[l + 2].Cells["MainPart"].Value.ToString()))
                            {
                                DrawTextOnSegment(e.Graphics, "★★★★★", 268 + _x, 62 + _y, 0, 5);
                                DrawTextOnSegment(e.Graphics, "★Main★", 271 + _x, 68 + _y, 0, 5);
                            }
                            DrawTextOnSegment(e.Graphics, "Siz:", 268 + _x, 78 + _y, 0, 6);
                            int size_size3 = 5;
                            if (gvGenBundle.Rows[l + 2].Cells["Size"].FormattedValue.ToString().Length < 6)
                            {
                                size_size3 = 8;
                            }
                            DrawTextOnSegment(e.Graphics, gvGenBundle.Rows[l + 2].Cells["Size"].FormattedValue.ToString(), 282 + _x, 76 + _y, 0, size_size3);
                            DrawTextOnSegment(e.Graphics, "Bun:", 268 + _x, 88 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, bNo3, 288 + _x, 86 + _y, 0, 8);
                            DrawTextOnSegment(e.Graphics, "QTY:", 268 + _x, 98 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, gvGenBundle.Rows[l + 2].Cells["QTY"].FormattedValue.ToString(), 288 + _x, 96 + _y, 0, 8);
                            DrawTextOnSegment(e.Graphics, tbRemarkStick.Text, 378 + _x, 8 + _y, 90, 6);

                            if (checkLastSticker == 3)
                            {
                                numberOfItemsPrintedSoFar += 3;
                                e.HasMorePages = false;
                                return;
                            }
                            else
                            {
                                numberOfItemsPrintedSoFar += 3;
                            }
                        }
                        else if (checkLastSticker == 2)
                        {
                            string qtyStick1 = gvGenBundle.Rows[l].Cells["No."].Value.ToString() + "/" + dtBundleAll.Rows.Count.ToString();
                            string bNo1 = gvGenBundle.Rows[l].Cells["Bundle No."].Value.ToString();
                            Bitmap bm1 = (Bitmap)gvGenBundle.Rows[l].Cells["Image"].Value;
                            //e.Graphics.DrawImage(bm1, new RectangleF(60 + _x, 54 + _y, 65, 65));
                            imgDraw(e.Graphics, bm1, 60 + _x, 54 + _y);
                            DrawTextOnSegment(e.Graphics, "-------------" + gvGenBundle.Rows[l].Cells["QRCode Bundle"].Value.ToString(), 12 + _x, 104 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, qtyStick1, 81 + _x, 8 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, tbTableCut2.Text, 81 + _x, 15 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, selectRowSD_ID, 12 + _x, 8 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, selectRowSO, 12 + _x, 15 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, selectRowStyle, 12 + _x, 22 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, "Part:" + gvGenBundle.Rows[l].Cells["Clothing Part"].Value.ToString(), 12 + _x, 30 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, "Dec.:" + gvGenBundle.Rows[l].Cells["Decoration"].Value.ToString(), 12 + _x, 37 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, "Clor:" + gvGenBundle.Rows[l].Cells["Color"].Value.ToString(), 12 + _x, 44 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, "DLot." + gvGenBundle.Rows[l].Cells["Dyelot"].FormattedValue.ToString(), 12 + _x, 52 + _y, 0, 6);
                            if (Convert.ToBoolean(gvGenBundle.Rows[l].Cells["MainPart"].Value.ToString()))
                            {
                                DrawTextOnSegment(e.Graphics, "★★★★★", 12 + _x, 62 + _y, 0, 5);
                                DrawTextOnSegment(e.Graphics, "★Main★", 15 + _x, 68 + _y, 0, 5);
                            }
                            DrawTextOnSegment(e.Graphics, "Siz:", 12 + _x, 76 + _y, 0, 6);
                            int size_size1 = 5;
                            if (gvGenBundle.Rows[l].Cells["Size"].FormattedValue.ToString().Length < 6)
                            {
                                size_size1 = 8;
                            }
                            DrawTextOnSegment(e.Graphics, gvGenBundle.Rows[l].Cells["Size"].FormattedValue.ToString(), 26 + _x, 76 + _y, 0, size_size1);
                            DrawTextOnSegment(e.Graphics, "Bun:", 12 + _x, 88 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, bNo1, 30 + _x, 86 + _y, 0, 8);
                            DrawTextOnSegment(e.Graphics, "QTY:", 12 + _x, 98 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, gvGenBundle.Rows[l].Cells["QTY"].FormattedValue.ToString(), 31 + _x, 96 + _y, 0, 8);
                            DrawTextOnSegment(e.Graphics, tbRemarkStick.Text, 122 + _x, 8 + _y, 90, 6);
                            //--------
                            string qtyStick2 = gvGenBundle.Rows[l + 1].Cells["No."].Value.ToString() + "/" + dtBundleAll.Rows.Count.ToString();
                            string bNo2 = gvGenBundle.Rows[l + 1].Cells["Bundle No."].Value.ToString();
                            Bitmap bm2 = (Bitmap)gvGenBundle.Rows[l + 1].Cells["Image"].Value;

                            imgDraw(e.Graphics, bm2, 188 + _x, 54 + _y);
                            DrawTextOnSegment(e.Graphics, "-------------" + gvGenBundle.Rows[l + 1].Cells["QRCode Bundle"].Value.ToString(), 140 + _x, 104 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, qtyStick2, 209 + _x, 8 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, tbTableCut2.Text, 209 + _x, 15 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, selectRowSD_ID, 140 + _x, 8 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, selectRowSO, 140 + _x, 15 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, selectRowStyle, 140 + _x, 23 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, "Part:" + gvGenBundle.Rows[l + 1].Cells["Clothing Part"].Value.ToString(), 140 + _x, 30 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, "Dec.:" + gvGenBundle.Rows[l + 1].Cells["Decoration"].Value.ToString(), 140 + _x, 37 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, "Color:" + gvGenBundle.Rows[l + 1].Cells["Color"].Value.ToString(), 140 + _x, 44 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, "DLot." + gvGenBundle.Rows[l + 1].Cells["Dyelot"].FormattedValue.ToString(), 140 + _x, 52 + _y, 0, 6);
                            if (Convert.ToBoolean(gvGenBundle.Rows[l + 1].Cells["MainPart"].Value.ToString()))
                            {
                                DrawTextOnSegment(e.Graphics, "★★★★★", 140 + _x, 62 + _y, 0, 5);
                                DrawTextOnSegment(e.Graphics, "★Main★", 143 + _x, 68 + _y, 0, 5);
                            }
                            DrawTextOnSegment(e.Graphics, "Siz:", 140 + _x, 78 + _y, 0, 6);
                            int size_size2 = 5;
                            if (gvGenBundle.Rows[l + 1].Cells["Size"].FormattedValue.ToString().Length < 6)
                            {
                                size_size2 = 8;
                            }
                            DrawTextOnSegment(e.Graphics, gvGenBundle.Rows[l + 1].Cells["Size"].FormattedValue.ToString(), 154 + _x, 76 + _y, 0, size_size2);
                            DrawTextOnSegment(e.Graphics, "Bun:", 140 + _x, 88 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, bNo2, 160 + _x, 86 + _y, 0, 8);
                            DrawTextOnSegment(e.Graphics, "QTY:", 140 + _x, 98 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, gvGenBundle.Rows[l + 1].Cells["QTY"].FormattedValue.ToString(), 160 + _x, 96 + _y, 0, 8);
                            DrawTextOnSegment(e.Graphics, tbRemarkStick.Text, 250 + _x, 8 + _y, 90, 6);
                            if (checkLastSticker == 2)
                            {
                                numberOfItemsPrintedSoFar += 2;
                                e.HasMorePages = false;
                                return;
                            }
                            else
                            {
                                numberOfItemsPrintedSoFar += 2;
                            }
                        }
                        else if (checkLastSticker == 1)
                        {
                            string qtyStick1 = gvGenBundle.Rows[l].Cells["No."].Value.ToString() + "/" + dtBundleAll.Rows.Count.ToString();
                            string bNo1 = gvGenBundle.Rows[l].Cells["Bundle No."].Value.ToString();
                            Bitmap bm1 = (Bitmap)gvGenBundle.Rows[l].Cells["Image"].Value;
                            //e.Graphics.DrawImage(bm1, new RectangleF(60 + _x, 54 + _y, 65, 65));
                            imgDraw(e.Graphics, bm1, 60 + _x, 54 + _y);
                            DrawTextOnSegment(e.Graphics, "-------------" + gvGenBundle.Rows[l].Cells["QRCode Bundle"].Value.ToString(), 12 + _x, 104 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, qtyStick1, 81 + _x, 8 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, tbTableCut2.Text, 81 + _x, 15 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, selectRowSD_ID, 12 + _x, 8 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, selectRowSO, 12 + _x, 15 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, selectRowStyle, 12 + _x, 22 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, "Part:" + gvGenBundle.Rows[l].Cells["Clothing Part"].Value.ToString(), 12 + _x, 30 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, "Dec.:" + gvGenBundle.Rows[l].Cells["Decoration"].Value.ToString(), 12 + _x, 37 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, "Clor:" + gvGenBundle.Rows[l].Cells["Color"].Value.ToString(), 12 + _x, 44 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, "DLot." + gvGenBundle.Rows[l].Cells["Dyelot"].FormattedValue.ToString(), 12 + _x, 52 + _y, 0, 6);
                            if (Convert.ToBoolean(gvGenBundle.Rows[l].Cells["MainPart"].Value.ToString()))
                            {
                                DrawTextOnSegment(e.Graphics, "★★★★★", 12 + _x, 62 + _y, 0, 5);
                                DrawTextOnSegment(e.Graphics, "★Main★", 15 + _x, 68 + _y, 0, 5);
                            }
                            DrawTextOnSegment(e.Graphics, "Siz:", 12 + _x, 76 + _y, 0, 6);
                            int size_size1 = 5;
                            if (gvGenBundle.Rows[l].Cells["Size"].FormattedValue.ToString().Length < 6)
                            {
                                size_size1 = 8;
                            }
                            DrawTextOnSegment(e.Graphics, gvGenBundle.Rows[l].Cells["Size"].FormattedValue.ToString(), 26 + _x, 76 + _y, 0, size_size1);
                            DrawTextOnSegment(e.Graphics, "Bun:", 12 + _x, 88 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, bNo1, 30 + _x, 86 + _y, 0, 8);
                            DrawTextOnSegment(e.Graphics, "QTY:", 12 + _x, 98 + _y, 0, 6);
                            DrawTextOnSegment(e.Graphics, gvGenBundle.Rows[l].Cells["QTY"].FormattedValue.ToString(), 31 + _x, 96 + _y, 0, 8);
                            DrawTextOnSegment(e.Graphics, tbRemarkStick.Text, 122 + _x, 8 + _y, 90, 6);
                            e.HasMorePages = false;
                            return;
                        }
                        else
                        {
                            e.HasMorePages = false;
                            return;
                        }
                        //}
                        //else
                        //{
                        //    e.HasMorePages = false;
                        //}

                    }
                    else
                    {
                        numberOfItemsPerPage = 0;
                        e.HasMorePages = true;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void DrawTextOnSegment(Graphics gr, string txt, int x, int y, int angle, int si)
        {
            GraphicsState state = gr.Save();
            gr.RotateTransform(angle, MatrixOrder.Append);
            gr.TranslateTransform(x, y, MatrixOrder.Append);

            // Define brush and font for the text
            Brush brush = Brushes.Black;
            Font font = new Font("Book Antiqua", si);

            // Position adjustment to shift everything to the right
            int rightShift = 18; // Adjust this value to shift the text and line to the right

            // If the text contains parentheses, it means it's in the format "50(48)"
            //if (txt.Contains("(") && txt.Contains(")"))
            //{
            //    // Extract the original and decreased values
            //    string originalQty = txt.Split('(')[0]; // Original quantity (before '(')
            //    string decreasedQty = txt.Split('(')[1].TrimEnd(')'); // Decreased quantity (inside the parentheses)

            //    // Measure the width of the original quantity for cross-out
            //    int qtyEndX = (int)gr.MeasureString(originalQty, font).Width;

            //    // Set a custom length for the cross-out line (adjust this value)
            //    int crossOutLineLength = qtyEndX - 18; // Increase 10 pixels beyond the original text

            //    // Position adjustments (optional)
            //    int lineYOffset = 4; // Adjust vertical position of the cross-out line

            //    // Shift the text and line to the right
            //    gr.DrawString(originalQty, font, brush, 0, 0); // Draw the original quantity at the right-shifted position

            //    // Create a pen for the cross-out line (adjust thickness and color)
            //    Pen crossOutPen = new Pen(Brushes.Black, 1); // Red color, 1 pixel thickness

            //    // Draw the cross-out line with the adjusted length
            //    gr.DrawLine(crossOutPen, rightShift, lineYOffset, rightShift + crossOutLineLength, lineYOffset); // Cross-out line of custom length

            //    // Draw the parentheses and decreased quantity (e.g., "(48)")
            //    gr.DrawString("(" + decreasedQty + ")", font, brush, rightShift + crossOutLineLength - 1, 0); // Position the decreased qty inside parentheses
            //}
            //else
            //{
            // If no parentheses, just draw the value normally
            gr.DrawString(txt, font, brush, 0, 0); // Draw normally with right shift
            //}

            gr.Restore(state);
        }
        private void imgDraw(Graphics gr, Bitmap bm, int x, int y)
        {
            gr.DrawImage(bm, new RectangleF(x, y, 60, 60));
        }
        public string Originalcolor = "";
        private void btPush2GenBundle1_Click(object sender, EventArgs e)
        {
            if (gvDisBundle.Rows.Count == 1)
            {
                int d = 0;
                DataGridViewRow sel = gvDisBundle.Rows[d];
                selectRowSD_ID = sel.Cells["SD_ListDoc_No"].Value.ToString();
                selectRowSO = sel.Cells["SO"].Value.ToString();
                selectRowStyle = sel.Cells["Style"].Value.ToString();
                tbTableCut2.Text = sel.Cells["Table"].Value.ToString();
                tbRemarkStick.Text = sel.Cells["Customer_Style"].Value.ToString();
                selectFabricType = sel.Cells["FabricType"].Value.ToString();
            }

            if (selectRowSD_ID != "")
            {
                //directPrintST = false;
                string xzx = ConnectMySQL.Subtext("SELECT `SD_ListDoc_No` FROM `a_a3_scandoc_sd_ct_tb` WHERE `SD_ListDoc_No` LIKE '" + selectRowSD_ID + "' AND `Cut_ScanIn` IS NOT NULL");
                if (xzx == selectRowSD_ID)
                {
                    HomePage.ins.ID_for_CreateBundle = selectRowSD_ID;

                    ConvertTable.getQTYBySizeBreakdown(@"SELECT `b`.`Color`,`a`.`Size`,`a`.`RatioQTY`AS `Ratio`, `a`.`QTY` FROM `a_a4_sd_scanout_qty_tb` AS `a`
                         LEFT JOIN `a_a1_spreading_list_tb`AS `b` ON `a`.`SD_ListDoc_No`=`b`.`SD_ListDoc_No`
                        LEFT JOIN sizes_tb s ON a.`Size`= s.Size
                         WHERE `a`.`SD_ListDoc_No`LIKE '" + selectRowSD_ID + "' ORDER BY s.SeqNo ASC;", gvSize);
                    if (gvSize.Columns.Count > 0)
                    {
                        if (gvSize.Rows.Count > 1)
                        {
                            Originalcolor = gvSize.Rows[1].Cells[0].Value.ToString();
                        }
                        gvSize.Columns["Color"].Width = 250;
                        for (int i = 1; i < gvSize.Columns.Count; i++)
                        {
                            gvSize.Columns[i].Width = 65;
                        }
                    }
                    ConnectMySQL.DisplayAndSearch("SELECT ROW_NUMBER() OVER(ORDER BY `a`.`BcID`)AS `No`,`a`.`Barcode`, `a`.`PliesActual`, `b`.`DryLot` AS `DyeLot` " +
                        "FROM `c_wh1_bc_sdactual_tb` AS `a` LEFT JOIN `c_warehouse1_bc_tb` AS `b` ON `a`.`Barcode`=`b`.`Barcode` " +
                        "WHERE `a`.`SD_ListDoc_No`LIKE'" + selectRowSD_ID + "' AND `a`.`PliesActual`!='0' ORDER BY `a`.`IndexSort`,`a`.`BcID`", gvFabric);
                    gvFabric.Columns["No"].Width = 50;
                    gvFabric.Columns["Barcode"].Width = 150;

                    ConnectMySQL.DisplayAndSearch("SELECT ROW_NUMBER() OVER(ORDER BY `ClothingPartID`) AS `No.`, `Part`, `QTYPart`,`MainPart`,`Decoration` " +
                        "FROM `a_a0clothing_part` WHERE `Style`LIKE '" + selectRowStyle + "'", gvClothingPart);

                    if (gvClothingPart.Columns.Count > 0)
                    {
                        gvClothingPart.Columns["No."].Width = 40;
                        gvClothingPart.Columns["Part"].Width = 150;
                        gvClothingPart.Columns["QTYPart"].Width = 80;
                        gvClothingPart.Columns["MainPart"].Width = 80;
                        gvClothingPart.Columns["Decoration"].Width = 120;
                    }
                    string countItem = ConnectMySQL.Subtext("SELECT COUNT(`SD_ListDoc_No`) FROM `a_b1_bundle_tb` WHERE `SD_ListDoc_No` LIKE '" + HomePage.ins.ID_for_CreateBundle + "';");
                    if (countItem == "0")
                    {

                    }
                    else
                    {
                        if (dtBundleAll.Rows.Count > 0)
                        {
                            dtBundleAll.Rows.Clear();
                        }
                        string txtSql = @"SELECT 
                        ROW_NUMBER() OVER (ORDER BY b.`Bundle_ID`) AS `No.`,
                        b.`QRCodeBundle` AS `QRCode Bundle`,
                        b.`BundleNo` AS `Bundle No.`,
                        b.`Color`,
                        b.`Size`,
                        b.`DyeLot`,
                        b.`ClothingPart` AS `Clothing Part`,
                        b.`Deco` AS `Decoration`,
                        b.`Plies` AS `PliesActual`,
                        b.`MainPart`,
                        SUM(b.`QTY`) AS `QTY`, 
                        b.`BarcodeRef`
                    FROM 
                        `a_b1_bundle_tb` b
                 
                    WHERE 
                        b.`SD_ListDoc_No` LIKE '" + HomePage.ins.ID_for_CreateBundle + @"'
                    GROUP BY 
                        b.`Bundle_ID`
                    ORDER BY 
                        b.`Bundle_ID`;";
                        dtBundleAll = ConnectMySQL.MySQLtoDataTable(txtSql);
                        gvGenBundle.DataSource = dtBundleAll; //
                        imgGenerate();//Color
                        gvGenBundle.Columns["No."].Width = 50;
                        gvGenBundle.Columns["QRCode Bundle"].Width = 150;
                        gvGenBundle.Columns["Color"].Width = 150;
                        gvGenBundle.Columns["Size"].Width = 60;
                        gvGenBundle.Columns["Clothing Part"].Width = 150;
                        gvGenBundle.Columns["Bundle No."].Width = 100;
                        gvGenBundle.Columns["PliesActual"].Width = 50;
                        gvGenBundle.Columns["QTY"].Width = 60;
                        // AddBundtocbb("Bundle No.", cbbBundle);
                    }
                }
                else
                {
                    MessageBox.Show("!!!! Need to Scan Out. !!!!");
                }
            }
            else
            {
                MessageBox.Show("Please Select Item.");
            }
        }
        private void imgGenerate()
        {
            if (gvGenBundle.Rows.Count > 0)
            {
                bool checkColumnImg = false;
                if (gvGenBundle.Columns.Count > 0)
                {
                    for (int i = 0; i < gvGenBundle.Columns.Count; i++)
                    {
                        if (gvGenBundle.Columns[i].HeaderText.ToString() == "Image")
                        {
                            checkColumnImg = true; break;
                        }
                    }
                }
                if (!checkColumnImg)
                {

                    DataGridViewImageColumn img = new DataGridViewImageColumn();
                    gvGenBundle.Columns.Add(img);
                    img.HeaderText = "Image";
                    img.Name = "Image";
                }
                for (int i = 0; i < gvGenBundle.Rows.Count; i++)
                {
                    string xx = gvGenBundle.Rows[i].Cells["QRCode Bundle"].Value.ToString();
                    gvGenBundle.Rows[i].Cells["Image"].Value = GenerateQRCode(xx);
                }
            }
        }
        private Bitmap GenerateQRCode(string data)
        {
            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeBitmap = qrCode.GetGraphic(5);
            // Bitmap qrCodeBitmap = qrCode.GetGraphic(2, Color.Black, Color.White, (Bitmap)Properties.Resources.logo,30);
            return qrCodeBitmap;
        }
        private void AddBundtocbb(string txtColumn, ToolStripComboBox cbb)
        {
            if (gvGenBundle.Rows.Count > 0)
            {//Bundle No.
                cbb.Items.Clear();
                var vv = gvGenBundle.Rows.Cast<DataGridViewRow>()
                           .Select(x => x.Cells[txtColumn].Value.ToString())
                           .Distinct()
                           .ToList();
                for (int i = 0; i < vv.Count; i++)
                {
                    cbb.Items.Add(vv[i]);
                }
            }
        }

        private void btItemUp_Click(object sender, EventArgs e)
        {
            if (RowFabIndex > -1)
            {
                DataTable dt = new DataTable();
                dt = (DataTable)gvFabric.DataSource;
                object[] arr0 = dt.Rows[RowFabIndex - 1].ItemArray;
                object[] arr1 = dt.Rows[RowFabIndex].ItemArray;
                dt.Rows[RowFabIndex - 1].ItemArray = arr1;
                dt.Rows[RowFabIndex].ItemArray = arr0;
                RowFabIndex--;
            }
        }

        private void btItemDown_Click(object sender, EventArgs e)
        {
            if (RowFabIndex > -1)
            {
                DataTable dt = new DataTable();
                dt = (DataTable)gvFabric.DataSource;
                object[] arr0 = dt.Rows[RowFabIndex + 1].ItemArray;
                object[] arr1 = dt.Rows[RowFabIndex].ItemArray;
                dt.Rows[RowFabIndex + 1].ItemArray = arr1;
                dt.Rows[RowFabIndex].ItemArray = arr0;
                RowFabIndex++;
            }
        }
        int RowFabIndex = -1;
        private void gvFabric_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                RowFabIndex = e.RowIndex;
            }
        }
        private void GenerateBundle()
        {
            DataTable dt = new DataTable();

            if (gvGenBundle.Rows.Count > 0)
            {
                gvGenBundle.DataSource = null;
                gvGenBundle.DataSource = gvSubColumn.DataSource;
                gvGenBundle.Columns["Image"].DisplayIndex = gvGenBundle.ColumnCount - 1;
            }

            if (gvGenBundle.Rows.Count == 0)
            {
                if (Group_work != "")
                {
                    dt = (DataTable)gvGenBundle.DataSource;
                    string group = Group_work.Substring(0, 1).ToUpper();
                    string searchFil = "BD" + group;
                    string QrCodeBundle = Calculate.DocNoAutoGen("SELECT `QRCodeBundle`  FROM `a_b1_bundle_tb` WHERE `QRCodeBundle`LIKE '" + searchFil + "%'  ORDER BY `QRCodeBundle` DESC LIMIT 1;", "BD" + Group_work.Substring(0, 1).ToUpper(), dtpCreate);
                    int numRun = int.Parse(QrCodeBundle.Substring(7, 6)) - 1;
                    string query1 = "SELECT `a`.`BundleNo` FROM `a_b1_bundle_tb` AS `a` JOIN `a_a1_spreading_list_tb` AS `b` ON `b`.`SD_ListDoc_No`=`a`.`SD_ListDoc_No`" +
                        "AND `b`.`SO`='" + selectRowSO + "'" +
                        "WHERE `MainPart`='1' AND `a`.`BundleNo` LIKE '" + group + "%' " +
                        "ORDER BY CAST(SUBSTRING_INDEX(`a`.`BundleNo`, '" + group + "', -1) AS UNSIGNED) DESC, `a`.`BundleNo` DESC LIMIT 1;";
                    string BD_NO_FromDB = ConnectMySQL.Subtext(query1);
                    int bundleNo = Calculate.BundleAutoGen(BD_NO_FromDB);
                   
                    for (int c = 1; c < gvSize.Columns.Count; c++)
                    {
                        for (int clR = 0; clR < gvClothingPart.Rows.Count; clR++)
                        {
                            int ybundlel = bundleNo;
                            for (int fR = 0; fR < gvFabric.Rows.Count; fR++)
                            {
                                ybundlel++;
                                string RowNo = (dt.Rows.Count + 1).ToString();
                                string color = gvSize.Rows[1].Cells[0].Value.ToString();
                                string size = gvSize.Columns[c].HeaderText;
                                string DyeLot = gvFabric.Rows[fR].Cells["DyeLot"].Value.ToString();
                                string part = gvClothingPart.Rows[clR].Cells["Part"].Value.ToString();
                                string Dec = gvClothingPart.Rows[clR].Cells["Decoration"].Value.ToString();
                                bool mainPart = Convert.ToBoolean(gvClothingPart.Rows[clR].Cells["MainPart"].Value.ToString());
                                numRun += 1;
                                string QR_CodeBundle = "BD" + Group_work.Substring(0, 1).ToUpper() + QrCodeBundle.Substring(3, 4) + numRun.ToString("######000000");
                                int Ratio = int.Parse(gvSize.Rows[0].Cells[c].Value.ToString());
                                int plies = int.Parse(gvFabric.Rows[fR].Cells["PliesActual"].Value.ToString());
                                int QTYPart = int.Parse(gvClothingPart.Rows[clR].Cells["QTYPart"].Value.ToString());
                                string QTY = (Ratio * plies * QTYPart).ToString();
                                string barRef = gvFabric.Rows[fR].Cells["Barcode"].Value.ToString();

                                dt.Rows.Add(RowNo, QR_CodeBundle, group + ybundlel, color, size, DyeLot, part, Dec, plies.ToString(), mainPart, QTY, barRef);
                                if ((fR == (gvFabric.Rows.Count - 1)) && (clR == (gvClothingPart.Rows.Count - 1)))
                                {
                                    bundleNo = ybundlel;
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please Check Group");
                }
            }
            gvGenBundle.DataSource = dt;
            dtBundleAll = dt;
            gvGenBundle.Columns["No."].Width = 50;
            gvGenBundle.Columns["QRCode Bundle"].Width = 150;
            gvGenBundle.Columns["Size"].Width = 60;
            gvGenBundle.Columns["Clothing Part"].Width = 150;
            gvGenBundle.Columns["Bundle No."].Width = 50;
            gvGenBundle.Columns["Decoration"].Width = 50;
            gvGenBundle.Columns["MainPart"].Width = 50;
            gvGenBundle.Columns["QTY"].Width = 60;
        }
        private void btGenBundle2_Click(object sender, EventArgs e)
        {
            bool checkPerMiss = false;
            if (gvGenBundle.Rows.Count == 0)
            {
                if (HomePage.ins.checkPermiss("bd_gen"))
                {
                    checkPerMiss = true;
                }
            }
            else
            {
                if (HomePage.ins.checkPermiss("bd_genAgain"))
                {
                    checkPerMiss = true;
                }
            }

            if (checkPerMiss)
            {


                if (selectRowSD_ID != "" && selectRowSO != "")
                {
                    string sdID = ConnectMySQL.Subtext("SELECT `SD_ListDoc_No` FROM `a_b1_bundle_to_dec_tb` WHERE `SD_ListDoc_No` ='" + selectRowSD_ID + "' ORDER BY `SD_ListDoc_No` ASC LIMIT 1");
                    if (sdID != selectRowSD_ID)
                    {
                        if (gvSize.Rows.Count > 0 && gvFabric.Rows.Count > 0 && gvClothingPart.Rows.Count > 0)
                        {
                            if (MessageBox.Show("Are you sure you want to generate bundle again?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                GenerateBundle();
                                imgGenerate();
                                btSaveBundle1.Visible = true;
                                btPrintQrCodeBundle.Visible = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Don't Have Data For Generate.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bundle already scanned out. Cannot generate again.|| ใบปูนี้สแกนงานออกแล้ว ออกสติ๊กเกอร์ใหม่ไม่ได้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
                else
                {
                    MessageBox.Show("Please Select Spreading.");
                }
            }
            else
            {
                MessageBox.Show("This Account Don't Have Permission For This Function.");
            }

        }
        private void opsitionxysave()
        {
            int _x = int.Parse(tbOffsetX1.Text);
            int _y = int.Parse(tbOffsetY1.Text);
            Properties.Settings.Default.printStickerX = _x;
            Properties.Settings.Default.printStickerY = _y;
            Properties.Settings.Default.Save();
        }
        Boolean FabricSortSave = false;
        private void btSaveBundle1_Click(object sender, EventArgs e)
        {
            if (gvGenBundle.Rows.Count > 0)
            {
                if (selectRowSD_ID != "" && selectRowSO != "")
                {
                    if (MessageBox.Show("Are you sure you want to save data?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {

                        opsitionxysave();
                        string insertMultiValue = "";
                        bool first = false;
                        for (int i = 0; i < gvGenBundle.Rows.Count; i++) //`DyeLot`
                        {
                            string QRcodeBundle = gvGenBundle.Rows[i].Cells["QRCode Bundle"].Value.ToString();
                            string SD_ListDoc_No = HomePage.ins.ID_for_CreateBundle;
                            string bundleNo = gvGenBundle.Rows[i].Cells["Bundle No."].Value.ToString();
                            string Color = gvGenBundle.Rows[i].Cells["Color"].Value.ToString();
                            string Size = gvGenBundle.Rows[i].Cells["Size"].Value.ToString();
                            string Clothing_Part = gvGenBundle.Rows[i].Cells["Clothing Part"].Value.ToString();
                            string Plies = gvGenBundle.Rows[i].Cells["PliesActual"].Value.ToString();
                            string QTY = gvGenBundle.Rows[i].Cells["QTY"].Value.ToString();//,`BarcodeRef`
                            string BarcodeRef = gvGenBundle.Rows[i].Cells["BarcodeRef"].Value.ToString();
                            string dyelot = gvGenBundle.Rows[i].Cells["DyeLot"].Value.ToString();
                            string MainPart = "0";

                            if (Convert.ToBoolean(gvGenBundle.Rows[i].Cells["MainPart"].Value.ToString()))
                            {
                                MainPart = "1";
                            }
                            string Dec = "";
                            if (gvGenBundle.Rows[i].Cells["Decoration"].Value.ToString() == "")
                            {
                                Dec = "NULL";
                            }
                            else
                            {
                                Dec = "'" + gvGenBundle.Rows[i].Cells["Decoration"].Value.ToString() + "'";
                            }
                            if (!first)
                            {
                                insertMultiValue = "(NULL, '" + QRcodeBundle + "','" + SD_ListDoc_No + "','" + bundleNo + "','" + Color + "','" + Size + "','" + dyelot + "','" + Clothing_Part + "','" + Plies + "','" + QTY + "','" + MainPart + "'," + Dec + ",'" + selectRowSO + "','" + selectFabricType + "','" + BarcodeRef + "')";//selectFabricType
                                first = true;
                            }
                            else
                            {
                                insertMultiValue = insertMultiValue + ",(NULL, '" + QRcodeBundle + "','" + SD_ListDoc_No + "','" + bundleNo + "','" + Color + "','" + Size + "','" + dyelot + "','" + Clothing_Part + "','" + Plies + "','" + QTY + "','" + MainPart + "'," + Dec + ",'" + selectRowSO + "','" + selectFabricType + "','" + BarcodeRef + "')";
                            }
                        }

                        if (insertMultiValue != "")
                        {
                            ConnectMySQL.MysqlQuery("DELETE FROM `a_b1_bundle_tb` WHERE `SD_ListDoc_No`='" + HomePage.ins.ID_for_CreateBundle + "' ");
                            ConnectMySQL.MysqlQuery("ALTER TABLE `a_b1_bundle_tb` auto_increment = 1;");
                            string sqlxx = @"INSERT INTO `a_b1_bundle_tb`(`Bundle_ID`, `QRCodeBundle`, `SD_ListDoc_No`,`BundleNo`, `Color`,`Size`,`DyeLot`, `ClothingPart`, `Plies`, `QTY`,`MainPart`,`Deco`,`SO`,`FabricType`,`BarcodeRef`)" +//BarcodeRef
                                 "VALUES" + insertMultiValue + ";";

                            // MessageBox.Show(sqlxx);
                            // textBox1.Text = sqlxx;
                            bool state = ConnectMySQL.MysqlQuery(sqlxx);
                            if (state)
                            {
                                MessageBox.Show("OK");
                                btPrintQrCodeBundle.Visible = true;
                                if (!FabricSortSave)
                                {
                                    ConnectMySQL.UpdateIndexSort(gvFabric);
                                    FabricSortSave = false;
                                }

                                selectFabricType = "";
                            }
                            else
                            {
                                MessageBox.Show("Bundle Can't Save Data to DB", "Can't Save",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Spreading.");
                }
            }
            else
            {
                MessageBox.Show("Generate Bundle Before Save Data.");
            }
        }
        string selectFabricType = "";
        private void gvDisBundle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (gvDisBundle.Rows.Count > 0)
                {
                    //status = true;
                    int d = e.RowIndex;
                    DataGridViewRow sel = gvDisBundle.Rows[d];
                    selectRowSD_ID = sel.Cells["SD_ListDoc_No"].Value.ToString();
                    selectRowSO = sel.Cells["SO"].Value.ToString();
                    selectRowStyle = sel.Cells["Style"].Value.ToString();
                    tbTableCut2.Text = sel.Cells["Table"].Value.ToString();
                    tbRemarkStick.Text = sel.Cells["Customer_Style"].Value.ToString();
                    selectFabricType = sel.Cells["FabricType"].Value.ToString();
                }
            }
        }

        private void tbPrinterName_TextBoxTextAlignChanged(object sender, EventArgs e)
        {
            //Properties.Settings.Default.printerName = tbPrinterName.Text;
            //Properties.Settings.Default.Save();
        }

        private void btPrintQrCodeBundle_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to print sticker?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //if (tbPrinterName.Text != "")
                //{
                //    Properties.Settings.Default.printerName = tbPrinterName.Text;
                //    Properties.Settings.Default.Save();
                //}
                if (gvPreview.RowCount == 0)
                {
                    gvGenBundle.DataSource = dtBundleAll;
                    imgGenerate();
                }
                else if (gvPreview.RowCount > 0)
                {
                    gvGenBundle.DataSource = dtBundleGroup;
                    imgGenerate();
                }
                numberOfItemsPrintedSoFar = 0;
                numberOfItemsPerPage = 0;
                PrintDocument printDocument3 = new PrintDocument();
                PrintPreviewDialog printPreviewDialog3 = new PrintPreviewDialog();
                printDocument3.DefaultPageSettings.PaperSize = new PaperSize("Custom", 400, 120);
                printDocument3.PrinterSettings.DefaultPageSettings.PaperSize = printDocument3.DefaultPageSettings.PaperSize;

                opsitionxysave();
                printDocument3.PrintPage += printDocument3_PrintPage;


                //printPreviewDialog3.Document = printDocument3;

                //printPreviewDialog3.ShowDialog();

                //printDocument3.Dispose();
                //printPreviewDialog3.Dispose();



                try
                {
                    DialogResult result = printDialog3.ShowDialog();
                    // If the result is OK then print the document.
                    if (result == DialogResult.OK)
                    {
                        stringToPrint = printDocument3.DocumentName;
                        printDocument3.PrinterSettings = printDialog3.PrinterSettings;
                        printDocument3.Print();
                        System.Windows.MessageBox.Show("Is printed!");
                        dtBundleGroup.Rows.Clear();
                        gvPreview.DataSource = dtBundleGroup;
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message, ToString());
                }
            }
        }
        //private void btSaveEdit_Click(object sender, EventArgs e)
        //{
        //    if (cbbBundle.SelectedIndex > -1 && int.Parse(tbQtyBD.Text) > 0)
        //    {
        //        if (MessageBox.Show("Are you sure you want to save data?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
        //        {
        //            if (ConnectMySQL.MysqlQuery("UPDATE `a_b1_bundle_tb` SET `QTY`='" + tbQtyBD.Text + "'WHERE `SD_ListDoc_No` LIKE '" + HomePage.ins.ID_for_CreateBundle + "' AND `BundleNo` LIKE '" + cbbBundle.Text + "'"))
        //            {
        //                if (dtBundleAll.Rows.Count > 0)
        //                {
        //                    dtBundleAll.Rows.Clear();
        //                }
        //                dtBundleAll = ConnectMySQL.MySQLtoDataTable("SELECT ROW_NUMBER() OVER(ORDER BY `Bundle_ID`) AS `No.`, `QRCodeBundle`AS `QRCode Bundle`, `BundleNo`AS `Bundle No.`, `Color`, `Size`, `DyeLot`, `ClothingPart`AS `Clothing Part`, `Deco`AS `Decoration`, `Plies`AS`PliesActual`, `MainPart`, `QTY`,`BarcodeRef`  " +
        //                      "FROM `a_b1_bundle_tb` WHERE `SD_ListDoc_No`LIKE '" + HomePage.ins.ID_for_CreateBundle + "'");
        //                gvGenBundle.DataSource = null;
        //                gvGenBundle.DataSource = dtBundleAll;
        //                imgGenerate();//Color
        //                gvGenBundle.Columns["No."].Width = 50;
        //                gvGenBundle.Columns["QRCode Bundle"].Width = 150;
        //                gvGenBundle.Columns["Color"].Width = 150;
        //                gvGenBundle.Columns["Size"].Width = 60;
        //                gvGenBundle.Columns["Clothing Part"].Width = 150;
        //                gvGenBundle.Columns["Bundle No."].Width = 100;
        //                gvGenBundle.Columns["PliesActual"].Width = 50;
        //                gvGenBundle.Columns["QTY"].Width = 60;
        //                //AddBundtocbb("Bundle No.", cbbBundle);
        //                gvGenBundle.Columns["Image"].DisplayIndex = gvGenBundle.ColumnCount - 1;

        //                MessageBox.Show("OK.");
        //            }
        //        }
        //    }
        //}
        private void cbbPrintMode1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbPrintMode1.SelectedIndex == 0)
            {
                lbcbbBundleNo1.Visible = false;
                cbbBundleNo1.Visible = false;
                lbtbQRcodeNO1.Visible = false;
                tbQRcodeNO1.Visible = false;
                // btPreviewUp.Visible = false;
            }
            else if (cbbPrintMode1.SelectedIndex == 1)
            {
                lbcbbBundleNo1.Visible = false;
                cbbBundleNo1.Visible = false;
                lbtbQRcodeNO1.Visible = false;
                tbQRcodeNO1.Visible = false;
                // btPreviewUp.Visible = true;
            }
            else if (cbbPrintMode1.SelectedIndex == 2)
            {//cbbBundleNo
                lbcbbBundleNo1.Visible = true;
                cbbBundleNo1.Visible = true;
                lbtbQRcodeNO1.Visible = false;
                tbQRcodeNO1.Visible = false;
                AddBundtocbb("Bundle No.", cbbBundleNo1);
                //btPreviewUp.Visible = true;
            }
            else if (cbbPrintMode1.SelectedIndex == 3)
            {
                lbcbbBundleNo1.Visible = false;
                cbbBundleNo1.Visible = false;
                lbtbQRcodeNO1.Visible = true;
                tbQRcodeNO1.Visible = true;
                // btPreviewUp.Visible = true;
            }
            else if (cbbPrintMode1.SelectedIndex == 4)
            {
                lbcbbBundleNo1.Visible = true;
                cbbBundleNo1.Visible = true;
                lbtbQRcodeNO1.Visible = false;
                tbQRcodeNO1.Visible = false;
                AddBundtocbb("Clothing Part", cbbBundleNo1);
            }
        }
        private void btPreviewUp_Click(object sender, EventArgs e)
        {
            if (cbbPrintMode1.SelectedIndex == 1)
            {
                // directPrintST = false;
                for (int i = 0; i < dtBundleAll.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dtBundleAll.Rows[i]["MainPart"].ToString()))
                    {
                        List<string> bundleList = new List<string>();
                        bool chColumn = false;
                        if (dtBundleGroup.Columns.Count > 0)
                            chColumn = true;

                        for (int k = 0; k < dtBundleAll.Columns.Count; k++)
                        {
                            if (!chColumn)
                            {
                                string header = dtBundleAll.Columns[k].ColumnName;
                                dtBundleGroup.Columns.Add(header);
                            }
                            bundleList.Add(dtBundleAll.Rows[i][k].ToString());
                        }
                        dtBundleGroup.Rows.Add(bundleList.ToArray());
                    }
                }
                gvPreview.DataSource = dtBundleGroup;
            }
            else if (cbbPrintMode1.SelectedIndex == 2)
            {
                for (int i = 0; i < dtBundleAll.Rows.Count; i++)
                {
                    if (dtBundleAll.Rows[i]["Bundle No."].ToString() == cbbBundleNo1.Text)
                    {
                        List<string> bundleList = new List<string>();
                        bool chColumn = false;
                        if (dtBundleGroup.Columns.Count > 0)
                            chColumn = true;

                        for (int k = 0; k < dtBundleAll.Columns.Count; k++)
                        {
                            if (!chColumn)
                            {
                                string header = dtBundleAll.Columns[k].ColumnName;
                                dtBundleGroup.Columns.Add(header);
                            }
                            bundleList.Add(dtBundleAll.Rows[i][k].ToString());
                        }
                        dtBundleGroup.Rows.Add(bundleList.ToArray());
                    }
                }
                gvPreview.DataSource = dtBundleGroup;
            }
            else if (cbbPrintMode1.SelectedIndex == 3)
            {
                for (int i = 0; i < dtBundleAll.Rows.Count; i++)
                {
                    if (dtBundleAll.Rows[i]["QRCode Bundle"].ToString() == tbQRcodeNO1.Text)
                    {
                        List<string> bundleList = new List<string>();
                        bool chColumn = false;
                        if (dtBundleGroup.Columns.Count > 0)
                            chColumn = true;

                        for (int k = 0; k < dtBundleAll.Columns.Count; k++)
                        {
                            if (!chColumn)
                            {
                                string header = dtBundleAll.Columns[k].ColumnName;
                                dtBundleGroup.Columns.Add(header);
                            }
                            bundleList.Add(dtBundleAll.Rows[i][k].ToString());
                        }
                        dtBundleGroup.Rows.Add(bundleList.ToArray());
                    }
                }
                gvPreview.DataSource = dtBundleGroup;
            }
            else if (cbbPrintMode1.SelectedIndex == 4)
            {
                for (int i = 0; i < dtBundleAll.Rows.Count; i++)
                {
                    if (dtBundleAll.Rows[i]["Clothing Part"].ToString() == cbbBundleNo1.Text)
                    {
                        List<string> bundleList = new List<string>();
                        bool chColumn = false;
                        if (dtBundleGroup.Columns.Count > 0)
                            chColumn = true;

                        for (int k = 0; k < dtBundleAll.Columns.Count; k++)
                        {
                            if (!chColumn)
                            {
                                string header = dtBundleAll.Columns[k].ColumnName;
                                dtBundleGroup.Columns.Add(header);
                            }
                            bundleList.Add(dtBundleAll.Rows[i][k].ToString());
                        }
                        dtBundleGroup.Rows.Add(bundleList.ToArray());
                    }
                }
                gvPreview.DataSource = dtBundleGroup;
            }
            if (gvPreview.Rows.Count > 0)
            {
                gvPreview.Columns["No."].Width = 50;
                gvPreview.Columns["QRCode Bundle"].Width = 150;
                gvPreview.Columns["Color"].Width = 150;
                gvPreview.Columns["Size"].Width = 60;
                gvPreview.Columns["Clothing Part"].Width = 150;
                gvPreview.Columns["Bundle No."].Width = 100;
                gvPreview.Columns["PliesActual"].Width = 80;
                gvPreview.Columns["QTY"].Width = 60;
            }
        }

        private void btClearTb_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear row of Preview Table?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dtBundleGroup.Rows.Clear();
                gvPreview.DataSource = dtBundleGroup;
            }
        }

        private void brReLoad_Click(object sender, EventArgs e)
        {
            gvGenBundle.DataSource = dtBundleAll;
            imgGenerate();
        }
        int leftQTYinBundleBeforeAdjust = 0;

        private void gvGenBundle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                cbbPrintMode1.SelectedIndex = 3;

                HomePage.ins.BundleNo_Adjust = gvGenBundle.Rows[e.RowIndex].Cells["Bundle No."].Value.ToString();
                tbQRcodeNO1.Text = gvGenBundle.Rows[e.RowIndex].Cells["QRCode Bundle"].Value.ToString();
                leftQTYinBundleBeforeAdjust = int.Parse(gvGenBundle.Rows[e.RowIndex].Cells["QTY"].Value.ToString());
                // MessageBox.Show("BD NO: " + HomePage.ins.BundleNo_Adjust);
                for (int i = 0; i < gvGenBundle.Rows.Count; i++)
                {
                    //MessageBox.Show(">> : " + gvGenBundle.Rows[i].Cells["Bundle No."].Value.ToString() + " :: " + HomePage.ins.BundleNo_Adjust + " >>: " + Convert.ToBoolean(gvGenBundle.Rows[i].Cells["MainPart"].EditedFormattedValue));
                    if (gvGenBundle.Rows[i].Cells["Bundle No."].Value.ToString() == HomePage.ins.BundleNo_Adjust && Convert.ToBoolean(gvGenBundle.Rows[i].Cells["MainPart"].EditedFormattedValue))
                    {

                        tbQRCodeModify.Text = gvGenBundle.Rows[i].Cells["QRCode Bundle"].Value.ToString();
                        // tbQRCodeModify.Text = tbQRcodeNO1.Text;
                        // MessageBox.Show(tbQRcodeNO1.Text);
                        break;
                    }
                }
            }
        }



        private void tbQtyBD_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void BundleGen_Load(object sender, EventArgs e)
        {
            dtpCreate.Value = DateTime.Now;
            Group_work = Properties.Settings.Default.workGroup;
            //if (Properties.Settings.Default.printerName != "")
            //{
            //    tbPrinterName.Text = Properties.Settings.Default.printerName;
            //}

            tbOffsetX1.Text = Properties.Settings.Default.printStickerX.ToString();
            tbOffsetY1.Text = Properties.Settings.Default.printStickerY.ToString();
            cbbPrintMode1.SelectedIndex = 0;
        }

        private void btExTemplate_Click(object sender, EventArgs e)
        {// ConnectMySQL.DisplayAndSearch("SELECT `Bundle_ID`AS `No.`, `QRCodeBundle`AS `QRCode Bundle`, `BundleNo`AS `Bundle No.`, `Color`, `Size`, `ClothingPart`AS `Clothing Part`, `Deco`AS `Decoration`, `Plies`AS`PliesActual`, `MainPart`, `QTY`  FROM `a_b1_bundle_tb` WHERE `SD_ListDoc_No`='89898';", gvGenBundle);


            DataTable dt = new DataTable();
            dt.Columns.Add("No.");
            dt.Columns.Add("QRCode Bundle");
            dt.Columns.Add("Bundle No.");
            dt.Columns.Add("Color");
            dt.Columns.Add("Size");
            dt.Columns.Add("Clothing Part");
            dt.Columns.Add("Decoration");
            dt.Columns.Add("PliesActual");
            dt.Columns.Add("MainPart");
            dt.Columns.Add("QTY");

            Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
            xcelApp.Application.Workbooks.Add(Type.Missing);

            for (int i = 1; i < dt.Columns.Count + 1; i++)
            {
                xcelApp.Cells[1, i] = dt.Columns[i - 1].ColumnName;

            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (dt.Rows[i][j] != null)
                    {
                        xcelApp.Cells[i + 2, j + 1] = dt.Rows[i][j].ToString();
                    }
                }
            }
            xcelApp.Columns.AutoFit();
            xcelApp.Visible = true;

        }
        public DataTable dtDirectPrint = new DataTable();
        //bool directPrintST = false;
        public bool checkGenDirectBD = false;
        private void btDirectBD_Click(object sender, EventArgs e)
        {

            using (DirecBundle direcBundle = new DirecBundle())
            {
                //dtDirectPrint = ConnectMySQL.MySQLtoDataTable("SELECT `Bundle_ID`AS `No.`, `QRCodeBundle`AS `QRCode Bundle`, `BundleNo`AS `Bundle No.`, `Color`, `Size`, `ClothingPart`AS `Clothing Part`, `Deco`AS `Decoration`, `Plies`AS`PliesActual`, `MainPart`, `QTY`  FROM `a_b1_bundle_tb` WHERE `SD_ListDoc_No`='89898';");

                if (direcBundle.ShowDialog() == DialogResult.OK)
                {
                    dtBundleAll = dtDirectPrint;
                    gvGenBundle.DataSource = dtBundleAll;

                    if (checkGenDirectBD)
                    {
                        btSaveBundle1.Visible = true;
                        btPrintQrCodeBundle.Visible = false;
                    }
                    else
                    {
                        btSaveBundle1.Visible = false;
                        btPrintQrCodeBundle.Visible = true;
                    }


                    FabricSortSave = true;


                }
            }

        }

        private void btPreview_Click(object sender, EventArgs e)
        {


            if (gvPreview.RowCount == 0)
            {
                gvGenBundle.DataSource = dtBundleAll;
                imgGenerate();
            }
            else if (gvPreview.RowCount > 0)
            {
                gvGenBundle.DataSource = dtBundleGroup;
                imgGenerate();
            }

            numberOfItemsPerPage = 0;
            numberOfItemsPrintedSoFar = 0;

            PrintDocument printDocument3 = new PrintDocument();
            PrintPreviewDialog printPreviewDialog3 = new PrintPreviewDialog();

            printDocument3.DefaultPageSettings.PaperSize = new PaperSize("Custom", 400, 120);
            printDocument3.PrinterSettings.DefaultPageSettings.PaperSize = printDocument3.DefaultPageSettings.PaperSize;
            //opsitionxysave();

            printDocument3.PrintPage += printDocument3_PrintPage;
            printPreviewDialog3.Document = printDocument3;

            printPreviewDialog3.ShowDialog();

            printDocument3.Dispose();
            printPreviewDialog3.Dispose();

            // PrintPreviewDialog printpreviewDialogl = new PrintpreviewDialog();
            //try
            //{
            //    DialogResult result = printDialog3.ShowDialog();
            //    // If the result is OK then print the document.
            //    if (result == DialogResult.OK)
            //    {
            //        stringToPrint = printDocument3.DocumentName;
            //        printDocument3.PrinterSettings = printDialog3.PrinterSettings;
            //        printDocument3.Print();
            //        System.Windows.MessageBox.Show("Is printed!");
            //        dtBundleGroup.Rows.Clear();
            //        gvPreview.DataSource = dtBundleGroup;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    System.Windows.MessageBox.Show(ex.Message, ToString());
            //}

        }

        private void cbbBundleNo1_Click(object sender, EventArgs e)
        {

        }

        private void tbDuplicate_Click(object sender, EventArgs e)
        {
            Duplicate_Spreading_Doc duplicate_Spreading_Doc = new Duplicate_Spreading_Doc();
            duplicate_Spreading_Doc.Show();
        }

        private void btAdjustDB_Click(object sender, EventArgs e)
        {


        }

        private void btAdjustDB2_Click(object sender, EventArgs e)
        {

            if (tbQRCodeModify.Text.Length > 0)
            {
                if (leftQTYinBundleBeforeAdjust > 0)
                {
                    if (MessageBox.Show("You want to adjust this Bundle No :" + HomePage.ins.BundleNo_Adjust + " right?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        HomePage.ins.QRCODE_Adjust = tbQRCodeModify.Text;
                        HomePage.ins.departAdjustQTY = "Cutting";
                        HomePage.ins.qtyDecreaseRef = leftQTYinBundleBeforeAdjust;
                        HomePage.ins.Adjust_Show_Mode = false;
                        //Adjust_qty adjust_Qty = new Adjust_qty();
                        //adjust_Qty.Show();
                        using (AdjustQTY_V2 di = new AdjustQTY_V2())
                        {
                            if (di.ShowDialog() == DialogResult.OK)
                            {
                                if (HomePage.ins.qtyDecrease != 0)
                                {

                                    if (ConnectMySQL.MysqlQuery("UPDATE `a_b1_bundle_tb` SET `QTY`=`QTY`+'" + HomePage.ins.qtyDecrease + "' WHERE `SD_ListDoc_No` LIKE '" + HomePage.ins.ID_for_CreateBundle + "' AND `BundleNo` LIKE '" + HomePage.ins.BundleNo_Adjust + "'"))
                                    {
                                        if (dtBundleAll.Rows.Count > 0)
                                        {
                                            dtBundleAll.Rows.Clear();
                                        }
                                        dtBundleAll = ConnectMySQL.MySQLtoDataTable("SELECT ROW_NUMBER() OVER(ORDER BY `Bundle_ID`) AS `No.`, `QRCodeBundle`AS `QRCode Bundle`, `BundleNo`AS `Bundle No.`, `Color`, `Size`, `DyeLot`, `ClothingPart`AS `Clothing Part`, `Deco`AS `Decoration`, `Plies`AS`PliesActual`, `MainPart`, `QTY`,`BarcodeRef`  " +
                                              "FROM `a_b1_bundle_tb` WHERE `SD_ListDoc_No`LIKE '" + HomePage.ins.ID_for_CreateBundle + "'");
                                        gvGenBundle.DataSource = null;
                                        gvGenBundle.DataSource = dtBundleAll;
                                        imgGenerate();//Color
                                        gvGenBundle.Columns["No."].Width = 50;
                                        gvGenBundle.Columns["QRCode Bundle"].Width = 150;
                                        gvGenBundle.Columns["Color"].Width = 150;
                                        gvGenBundle.Columns["Size"].Width = 60;
                                        gvGenBundle.Columns["Clothing Part"].Width = 150;
                                        gvGenBundle.Columns["Bundle No."].Width = 100;
                                        gvGenBundle.Columns["PliesActual"].Width = 50;
                                        gvGenBundle.Columns["QTY"].Width = 60;
                                        //AddBundtocbb("Bundle No.", cbbBundle);
                                        gvGenBundle.Columns["Image"].DisplayIndex = gvGenBundle.ColumnCount - 1;

                                        MessageBox.Show("OK.");
                                        tbQRCodeModify.Text = string.Empty;
                                    }

                                }
                            }
                        }

                    }
                }
                else
                {
                    MessageBox.Show("QTY not enough", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please Select QRCode Number ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btSeparate_Click(object sender, EventArgs e)
        {
            //SetUpPosition.CenterLabelInPanel(lbHeader, pnHeader);
            if (tbQRCodeModify.Text.Length > 0)
            {
                HomePage.ins.QRCODE_Adjust = tbQRCodeModify.Text;
                if (MessageBox.Show("You want to separate this Bundle No :" + HomePage.ins.BundleNo_Adjust + " right?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    using (BDSeparate di = new BDSeparate())
                    {
                        if (di.ShowDialog() == DialogResult.OK)
                        {
                            if (dtBundleAll.Rows.Count > 0)
                            {
                                dtBundleAll.Rows.Clear();
                            }
                            dtBundleAll = ConnectMySQL.MySQLtoDataTable("SELECT ROW_NUMBER() OVER(ORDER BY `Bundle_ID`) AS `No.`, `QRCodeBundle`AS `QRCode Bundle`, `BundleNo`AS `Bundle No.`, `Color`, `Size`, `DyeLot`, `ClothingPart`AS `Clothing Part`, `Deco`AS `Decoration`, `Plies`AS`PliesActual`, `MainPart`, `QTY`,`BarcodeRef`  " +
                                  "FROM `a_b1_bundle_tb` WHERE `SD_ListDoc_No`LIKE '" + HomePage.ins.ID_for_CreateBundle + "'");
                            gvGenBundle.DataSource = null;
                            gvGenBundle.DataSource = dtBundleAll;
                            imgGenerate();//Color
                            gvGenBundle.Columns["No."].Width = 50;
                            gvGenBundle.Columns["QRCode Bundle"].Width = 150;
                            gvGenBundle.Columns["Color"].Width = 150;
                            gvGenBundle.Columns["Size"].Width = 60;
                            gvGenBundle.Columns["Clothing Part"].Width = 150;
                            gvGenBundle.Columns["Bundle No."].Width = 100;
                            gvGenBundle.Columns["PliesActual"].Width = 50;
                            gvGenBundle.Columns["QTY"].Width = 60;
                            //AddBundtocbb("Bundle No.", cbbBundle);
                            gvGenBundle.Columns["Image"].DisplayIndex = gvGenBundle.ColumnCount - 1;

                            MessageBox.Show("OK.");
                            tbQRCodeModify.Text = string.Empty;
                        }
                    }
                }
            }

        }

        private void btAjList_Click(object sender, EventArgs e)
        {

            if (tbSearchSD_ID1.Text.Length > 0)
            {
                selectRowSD_ID = tbSearchSD_ID1.Text;
                HomePage.ins.Adjust_Show_Mode = true;
                using (AdjustQTY_V2 di = new AdjustQTY_V2())
                {
                    di.ShowDialog();

                }
            }
        }
    }
}
