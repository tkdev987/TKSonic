using Guna.UI2.WinForms;
using Production_Tracking_systems.myClass;
using PTS_For_Cut.Main;
using PTS_For_Cut.Myclass;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PTS_For_Cut._3Spreading.Report
{


    public partial class CuttingReport : Form
    {
        public static CuttingReport ins;
        private static CuttingReport _instance;

        public string stringToPrint;
        public string rSO { set; get; }
        public string rStyle { set; get; }
        public string rCus { set; get; }//Program /
        public string rCusCode { set; get; }//Program /
        public string rCusStyle { set; get; } //Program /
        public string rCusAddress { set; get; } //DB 
        public string rjobStart { set; get; } //DB
        public string rCutFinish { set; get; } //Program
        public string rDeadline { set; get; }//Program
        public string rCutBy { set; get; } //select Form
        public string rMer { set; get; } //select Form
        public string rPrice { set; get; } //select Form
        public string rIssuetoAccount { set; get; } //select Form
        public string rPlaceSew { set; get; } //select Form
        public string rPlaceEmbro { set; get; } //select Form
        public string rPlacePrint { set; get; } //select Form rpSoRemark
        public string rpSoRemark { set; get; }
        public string rpProduct_Type { set; get; }
        public string rpBrand { set; get; }

        public string rClothingPart { set; get; }
        public string rHeader { set; get; }
        public string rDeco { set; get; }
        public string rPlace { set; get; }



        public CuttingReport()
        {
            InitializeComponent();
            ins = this;
            dtpEnd.Value = DateTime.Now;
            dtpStart.Value = DateTime.Now;
        }

        private void btDailySearch_Click(object sender, EventArgs e)
        {
            gvDaily.DataSource = null;
            if (cbbSearchType.SelectedIndex == -1)
            {
                cbbSearchType.SelectedIndex = 0;
            }
            if (cbbSearchType.SelectedIndex == 0)
            {
                //DataTable dataActualCut = ConnectMySQL.MySQLtoDataTable(@"SELECT `b`.`SO`,`b`.`Color`, `a`.`Size`, (SUM(`a`.`QTY`)-SUM(`d`.`QTY`))AS `QTY` FROM `a_b1_bundle_tb` AS `a` 
                //LEFT JOIN `a_decrease_qty` AS `d`ON `d`.`BD_QRCode_Ref`=`a`.`QRCodeBundle`


                ConnectMySQL.DisplayAndSearch(@"SELECT `b`.`SO`, `b`.`Style`,`b`.`Color`, `a`.`Size`,SUM(`a`.`QTY`) AS `QTY`,  `e`.`SAM_Cut`,
                ROUND((`e`.`SAM_Cut`*SUM(`a`.`QTY`)),2)AS `Earn Min` ,DATE(`c`.`Cut_ScanOut`) AS 'Date'
                         FROM `a_b1_bundle_tb` AS `a`
                         JOIN `a_a1_spreading_list_tb` AS `b` ON `b`.`SD_ListDoc_No`=`a`.`SD_ListDoc_No` AND `b`.`FabricType` LIKE 'A' AND `b`.`SD_Status` LIKE '1' 
                         JOIN `a_a3_scandoc_sd_ct_tb` AS `c`ON `c`.`SD_ListDoc_No` =`a`.`SD_ListDoc_No`                        
                         LEFT JOIN `sizes_tb` AS `d` ON `d`.`Size` =`a`.`Size`
                         LEFT JOIN  `a_a0sam_cut_sew` AS `e` ON `e`.`Style` =`b`.`Style`
                         WHERE `MainPart`=1 AND  DATE(`c`.`Cut_ScanOut`)  BETWEEN '" + SetTimeA(dtpStart) + "' AND '" + SetTimeA(dtpEnd) + @"'
                         GROUP BY `b`.`SO`, `b`.`Style`,`b`.`Color`, `a`.`Size`
                        ORDER BY `b`.`SO`, `b`.`Style`,`b`.`Color`,`d`.`SeqNo`;", gvDaily); // AND `b`.`FabricType` LIKE 'A' AND `b`.`SD_Status` LIKE '1' `b`.`Cut_ScanOut`  IS NOT NULL 
            }
            else if (cbbSearchType.SelectedIndex == 1)
            {
                ConnectMySQL.DisplayAndSearch(@"SELECT  `b`.`SD_ListDoc_No`,`b`.`SO`, `b`.`Style`,`b`.`Table_No`,`b`.`Color`,SUM(`a`.`QTY`) AS `QTY`,  `e`.`SAM_Cut`,
            ROUND((`e`.`SAM_Cut`*SUM(`a`.`QTY`)),2)AS `Earn Min` , `c`.`SD_ScanIn` AS 'StartDateTime',
           `c`.`Cut_ScanOut` AS 'EndDateTime',
           TIMESTAMPDIFF(MINUTE, `c`.`SD_ScanIn`, `c`.`Cut_ScanOut`) AS `WorkTimeInMinutes`
                         FROM `a_b1_bundle_tb` AS `a`
                         JOIN `a_a1_spreading_list_tb` AS `b` ON `b`.`SD_ListDoc_No`=`a`.`SD_ListDoc_No` AND `b`.`FabricType` LIKE 'A' AND `b`.`SD_Status` LIKE '1' 
                         JOIN `a_a3_scandoc_sd_ct_tb` AS `c`ON `c`.`SD_ListDoc_No` =`a`.`SD_ListDoc_No`                        
                         LEFT JOIN `sizes_tb` AS `d` ON `d`.`Size` =`a`.`Size`
                         LEFT JOIN  `a_a0sam_cut_sew` AS `e` ON `e`.`Style` =`b`.`Style`
                         WHERE `MainPart`=1 AND  DATE(`c`.`Cut_ScanOut`)  BETWEEN '" + SetTimeA(dtpStart) + "' AND '" + SetTimeA(dtpEnd) + @"'
                         GROUP BY  `b`.`SD_ListDoc_No`,`b`.`SO`, `b`.`Style`,`b`.`Table_No`
                        ORDER BY  `b`.`SD_ListDoc_No`,`b`.`SO`, `b`.`Style`,`b`.`Table_No`;", gvDaily);
            }
            else if (cbbSearchType.SelectedIndex == 2)
            {
                ConnectMySQL.DisplayAndSearch(@"SELECT `b`.`Table_No`, SUM(`a`.`QTY`)AS `QTY`,  `e`.`SAM_Cut`,ROUND((`e`.`SAM_Cut`*(SUM(`a`.`QTY`))),2)AS `Earn Min`  ,DATE(`c`.`Cut_ScanOut`) AS 'Date'
                         FROM `a_b1_bundle_tb` AS `a`
                         JOIN `a_a1_spreading_list_tb` AS `b` ON `b`.`SD_ListDoc_No`=`a`.`SD_ListDoc_No` AND `b`.`FabricType` LIKE 'A' AND `b`.`SD_Status` LIKE '1' 
                         JOIN `a_a3_scandoc_sd_ct_tb` AS `c`ON `c`.`SD_ListDoc_No` =`a`.`SD_ListDoc_No`
                         LEFT JOIN  `a_a0sam_cut_sew` AS `e` ON `e`.`Style` =`b`.`Style`
                         WHERE `MainPart`=1 AND  DATE(`c`.`Cut_ScanOut`) BETWEEN '" + SetTimeA(dtpStart) + "' AND '" + SetTimeA(dtpEnd) + @"'
                         GROUP BY `b`.`Table_No`
                         ORDER BY `b`.`Table_No`;", gvDaily);
            }
            int ttQty = 0;
            if (gvDaily.Rows.Count > 0)
            {
                for (int i = 0; i < gvDaily.Rows.Count; i++)
                {
                    ttQty += int.Parse(gvDaily.Rows[i].Cells["QTY"].Value.ToString());
                }
                lbttQty.Text = ttQty.ToString();
            }
        }
        private string SetTimeA(Guna2DateTimePicker dtpVal)
        {
            string txtDate = "";
            System.Globalization.CultureInfo _cultureEnInfo = new System.Globalization.CultureInfo("en-US");
            DateTime dateEng = Convert.ToDateTime(dtpVal.Value, _cultureEnInfo);
            txtDate = dateEng.ToString("yyyy-MM-dd", _cultureEnInfo);
            return txtDate;
        }
        private void btSearch1_Click(object sender, EventArgs e)
        {
            searsh();
        }
        private void searchFtype(string Ftype)
        {
            dtSpreadingList = ConnectMySQL.MySQLtoDataTable("SELECT `a`.`SD_ListDoc_No`," +
                    "CASE " +
                        "WHEN `b`.`Cut_ScanOut`  IS NOT NULL  THEN 'Done' " +
                        "ELSE NULL " +
                    "END AS `Cut Status` " +
                    ",`a`.`Table_No`, `a`.`Color` " +
                    "FROM `a_a1_spreading_list_tb` AS `a` JOIN `a_a3_scandoc_sd_ct_tb` AS `b` ON `a`.`SD_ListDoc_No`=`b`.`SD_ListDoc_No` AND `b`.`wh_scanout` IS NOT NULL  " +
                    "WHERE `a`.`SO` LIKE '" + tbSo1.Text + "'  AND `a`.`FabricType` LIKE '" + Ftype + "' AND `a`.`SD_Status` LIKE '1' ;");
            gvSpreadingList.DataSource = dtSpreadingList;
        }
        private void tbSo1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searsh();
            }
        }
        public CheckedListBox checkedListBox = new CheckedListBox();
        public string styleCross = "";
        public DataTable dtSpreadingList = new DataTable();
        DataTable SizeFromMySql = new DataTable();
        DataTable dtsoDetail = new DataTable();
        private void searsh()
        {
            if (tbSo1.Text.Length == 12 || tbSo1.Text.Length == 13 || tbSo1.Text.Length == 14)
            {
                tbSo.Text = string.Empty;
                tbStyle.Text = string.Empty;
                tbMer.Text = string.Empty;
                tbPrice.Text = string.Empty;
                tbPlaceSew.Text = string.Empty;
                tbProductType.Text = string.Empty;
                tbCus.Text = string.Empty;
                tbcusCode.Text = string.Empty;
                tbCusStyle.Text = string.Empty;
                tbCutBy.Text = string.Empty;
                tbPlaceEmbro.Text = string.Empty;
                tbBrand.Text = string.Empty;
                tbSoStartDate.Text = string.Empty;
                tbCutFinishDate.Text = string.Empty;
                tbDeadline.Text = string.Empty;
                tbIssueDate.Text = string.Empty;
                tbPlacePrint.Text = string.Empty;
                tbPlaceSew.Text = string.Empty;
                if (gvRemarkByColor1.Rows.Count > 0)
                {
                    // MessageBox.Show(gvRemarkByColor1.Rows.Count.ToString());
                    for (int i = gvRemarkByColor1.Rows.Count - 1; i >= 0; i--)
                    {
                        // MessageBox.Show(i.ToString() + "||" + gvRemarkByColor1.Rows.Count.ToString());
                        gvRemarkByColor1.Rows.RemoveAt(i);
                    }
                }




                DataTable dataActualCut = ConnectMySQL.MySQLtoDataTable(@"SELECT `b`.`SO`,`b`.`Color`, `a`.`Size`, (SUM(`a`.`QTY`))AS `QTY` 
                FROM `a_b1_bundle_tb` AS `a`
                JOIN `a_a1_spreading_list_tb` AS `b` ON `b`.`SD_ListDoc_No`=`a`.`SD_ListDoc_No`AND `b`.`SO`='" + tbSo1.Text + @"' AND `b`.`FabricType` LIKE 'A' AND `b`.`SD_Status` LIKE '1' 
                JOIN `a_a3_scandoc_sd_ct_tb` AS `c`ON `c`.`SD_ListDoc_No` =`a`.`SD_ListDoc_No`AND `c`.`Cut_ScanOut` IS NOT NULL 
                    WHERE `MainPart`= 1  GROUP BY `b`.`SO`,`b`.`Color`,`a`.`Size`; ");
                SizeFromMySql = ConnectMySQL.MySQLtoDataTable(
                    @"SELECT a.`So`, a.`Style`, a.`Color`, a.`Size`,SUM(a.`Qty`) AS `QTY`, a.`Customer_Code`, a.`Customer_Name`, a.`Customer_Style` 
                                FROM `so_tb` a 
                                LEFT JOIN sizes_tb s ON a.`Size`= s.Size 
                                WHERE `So`LIKE '" + tbSo1.Text + @"' 
                                GROUP BY a.`So`,a.`Color`, a.`Size` 
                                ORDER BY s.SeqNo ASC;");

                searchFtype("A");

                if (SizeFromMySql.Rows.Count > 0)
                {
                    tbSo.Text = tbSo1.Text;
                    rSO = tbSo.Text;
                    tbCus.Text = SizeFromMySql.Rows[0]["Customer_Name"].ToString();
                    tbCusStyle.Text = SizeFromMySql.Rows[0]["Customer_Style"].ToString();
                    tbcusCode.Text = SizeFromMySql.Rows[0]["Customer_Code"].ToString();
                    tbStyle.Text = SizeFromMySql.Rows[0]["Style"].ToString();//`CusAddr`
                    styleCross = tbStyle.Text;


                    DataTable dtc = new DataTable();
                    dtc = SizeFromMySql.DefaultView.ToTable(true, "Size");
                    DataTable col = new DataTable();
                    col.Columns.Add("Color");
                    col.Columns.Add("-");
                    foreach (DataRow row in dtc.Rows)
                    {
                        col.Columns.Add(row[0].ToString());
                    }
                    DataTable dtr = new DataTable();
                    dtr = SizeFromMySql.DefaultView.ToTable(true, "Color");
                    checkedListBox.Items.Clear();

                    foreach (DataRow row in dtr.Rows)
                    {

                        checkedListBox.Items.Add(row[0].ToString());
                        col.Rows.Add(row[0].ToString(), "Order");
                        col.Rows.Add("", "Actual Cut");
                    }
                    for (int i = 0; i < col.Rows.Count; i++)
                    {
                        for (int j = 1; j < col.Columns.Count; j++)
                        {
                            for (int k = 0; k < SizeFromMySql.Rows.Count; k++)//
                            {
                                if (SizeFromMySql.Rows[k]["Size"].ToString() == col.Columns[j].ToString() && SizeFromMySql.Rows[k]["Color"].ToString() == col.Rows[i]["Color"].ToString())
                                {
                                    col.Rows[i][j] = SizeFromMySql.Rows[k]["QTY"];
                                }
                            }
                            if (dataActualCut.Rows.Count > 0)
                            {
                                for (int k = 0; k < dataActualCut.Rows.Count; k++)//
                                {
                                    // MessageBox.Show(dataActualCut.Rows[k]["Size"].ToString() +" == "+ col.Columns[j].ToString() + " && " + dataActualCut.Rows[k]["Color"].ToString() + " == " + col.Rows[i]["Color"].ToString());
                                    if (dataActualCut.Rows[k]["Size"].ToString() == col.Columns[j].ToString() && dataActualCut.Rows[k]["Color"].ToString() == col.Rows[i]["Color"].ToString())
                                    {
                                        col.Rows[i + 1][j] = dataActualCut.Rows[k]["QTY"];
                                    }
                                }
                            }
                        }
                    }
                    //gvRemarkByColor1.DataSource = dtSoRemark;

                    gvSoDetail.DataSource = col;
                    col.Columns.Add("Sum");
                    int rowSum = 0;
                    for (int i = 0; i < col.Rows.Count; i++)
                    {
                        for (int j = 2; j < col.Columns.Count - 1; j++)
                        {
                            // MessageBox.Show(col.Rows[i][j].GetType().ToString());
                            if (col.Rows[i][j].GetType() == typeof(string))
                            {
                                if (col.Rows[i][j] != "")
                                {
                                    rowSum += int.Parse(col.Rows[i][j].ToString());
                                }
                            }
                            else
                            {
                                if (col.Rows[i][j] != DBNull.Value)
                                {
                                    rowSum += int.Parse(col.Rows[i][j].ToString());
                                }
                            }
                        }
                        col.Rows[i][col.Columns.Count - 1] = rowSum;
                        rowSum = 0;
                    }
                    DataGridViewCellStyle style = new DataGridViewCellStyle();
                    style.BackColor = Color.Gainsboro;
                    style.ForeColor = Color.Black;
                    gvSoDetail.Columns[col.Columns.Count - 1].DefaultCellStyle = style;
                    gvSoDetail.Columns[0].DefaultCellStyle = style;
                    gvSoDetail.Columns[0].ReadOnly = true;
                    gvSoDetail.Columns["Color"].Width = 200;
                    gvSoDetail.Columns["-"].Width = 80;
                    for (int i = 2; i < gvSoDetail.Columns.Count; i++)
                    {
                        gvSoDetail.Columns[i].Width = 65;
                    }
                    gvSpreadingList.Columns["SD_ListDoc_No"].Width = 150;

                    gvSpreadingList.Columns["Cut Status"].Width = 100;//

                    gvSpreadingList.Columns["Color"].Width = 200;
                    gvSpreadingList.Columns["Table_No"].Width = 70;

                    // 



                    dtsoDetail = ConnectMySQL.MySQLtoDataTable("SELECT `Mer`,`Product_type`,`Brand`, `Color`, `Price`, `CutBy`, `PlaceSew`, `PlaceEmbr`, `PlacePrinting`, " +
                        "`JobStartSO`, `CutFinished`, `Deadline`, `issueAccount`, `ColorStartDate`, `ColorEndDate`, `ColorRemark`, `SoRemark` FROM `so_detail_tb`" +
                        " WHERE `So` LIKE '" + tbSo1.Text + "' ");
                    if (dtsoDetail.Rows.Count > 0)
                    {
                        tbSoStartDate.Text = dtsoDetail.Rows[0]["JobStartSO"].ToString();
                        tbCutFinishDate.Text = dtsoDetail.Rows[0]["CutFinished"].ToString();
                        tbDeadline.Text = dtsoDetail.Rows[0]["Deadline"].ToString();
                        tbIssueDate.Text = dtsoDetail.Rows[0]["issueAccount"].ToString();
                        tbPlaceSew.Text = dtsoDetail.Rows[0]["PlaceSew"].ToString();
                        tbPlaceEmbro.Text = dtsoDetail.Rows[0]["PlaceEmbr"].ToString();
                        tbPlacePrint.Text = dtsoDetail.Rows[0]["PlacePrinting"].ToString();
                        tbMer.Text = dtsoDetail.Rows[0]["Mer"].ToString();
                        tbPrice.Text = dtsoDetail.Rows[0]["Price"].ToString();
                        tbCutBy.Text = dtsoDetail.Rows[0]["CutBy"].ToString();//
                        tbSoRemark.Text = dtsoDetail.Rows[0]["SoRemark"].ToString();
                        tbProductType.Text = dtsoDetail.Rows[0]["Product_type"].ToString();
                        tbBrand.Text = dtsoDetail.Rows[0]["Brand"].ToString();
                    }

                    fbUsage_data();
                    //gvRemarkByColor1.Columns["Colors"].Width = 180;
                    //gvRemarkByColor1.Columns["Start"].Width = 120;
                    //gvRemarkByColor1.Columns["CutFinish"].Width = 120;
                    //gvRemarkByColor1.Columns["Remark"].Width = gvRemarkByColor1.Width - 150 - 80 - 120 - 5;
                    //gvRemarkByColor1.Columns["Remark"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                }
                else
                {
                    MessageBox.Show("!!! Don't Have Data !!!");
                }
            }
            else
            {
                MessageBox.Show("!!! SO Data Have 12 Digit !!!");
            }
        }
        private void fbUsage_data()
        {

            DataTable dtfabricUsagefrom_SD = new DataTable();
            string sqlfbUsage = @"SELECT
                            fb_Usage.PO,
                            fb_Usage.Color,
                            fb_Usage.Color_PO,
                            fb_Usage.FabricType,
                            SUM(fb_Usage.Cut_QTY) AS 'Cut_QTY',
                            ROUND(SUM(fb_Usage.Fabric_Usage),2) AS SD_FB_Usage,                           
                            f.FBReplatement AS ReCut,
                            f.FBSpare,
                            ROUND(SUM(fb_Usage.Defect),2) AS Defect,
                            ROUND(SUM(fb_Usage.Lapping),2) AS Lapping,
                            f.HemFB AS FBBinding,                            
     ROUND(SUM(fb_Usage.RestFabric),2) AS 'SD_RestFB',    
     ROUND(SUM(fb_Usage.ShortageInRoll),2) AS FB_Shortage,
     ROUND((SUM(fb_Usage.Fabric_Usage) + IFNULL(f.FBReplatement,0) + IFNULL(f.FBSpare,0) + IFNULL(fb_Usage.Defect,0)+IFNULL(fb_Usage.Lapping,0) + IFNULL(f.HemFB,0) - SUM(fb_Usage.ShortageInRoll)),3) AS FB_Total_Usage, 
     ROUND((SUM(fb_Usage.Fabric_Usage) + IFNULL(f.FBReplatement,0) + IFNULL(f.FBSpare,0) + IFNULL(fb_Usage.Defect,0)+IFNULL(fb_Usage.Lapping,0) + IFNULL(f.HemFB,0) - SUM(fb_Usage.ShortageInRoll))/SUM(fb_Usage.Cut_QTY), 3) AS 'Fabric/PCS',
                            fb_Usage.Unit,
                            f.startDate,
                            f.endDate,-- fabric_usage.
                            f.FBOffcut AS Rag,
                              ROUND(f.FBOffcut/(SUM(fb_Usage.Fabric_Usage) + IFNULL(f.FBReplatement,0) + IFNULL(f.FBSpare,0) + IFNULL(fb_Usage.Defect,0)+IFNULL(fb_Usage.Lapping,0) + IFNULL(f.HemFB,0) - SUM(fb_Usage.ShortageInRoll))*100,3) AS 'WasteAllowed%' ,
                            f.Remark  
                        FROM
                        (
                             SELECT
                                            fabric_usage.SO,
                                            fabric_usage.SD_ListDoc_No,
                                            fabric_usage.PO,
                                            fabric_usage.Color,
                                            fabric_usage.Color_PO,
                                            fabric_usage.FabricType,
                                            p.Cut_QTY,
                                            fabric_usage.RestFabric,
                                            fabric_usage.Defect, 
                            				fabric_usage.Lapping,
                                            
                                            fabric_usage.Fabric_Usage,
                                            fabric_usage.ShortageInRoll,
                                            fabric_usage.Unit
                                        FROM
                                        (
                                            SELECT
                                                b.SO,
                                                a.SD_ListDoc_No,
                                                a.Barcode,
                                                b.FabricPerPCS,
                                                CASE
                                                    WHEN d.Unit = 'M' THEN 'YDS'
                                                    ELSE d.Unit
                                                END AS Unit,
                                                -- Apply division by Consumtion if Unit is 'KGS'
                                                CASE
                                                    WHEN d.Unit = 'KGS' THEN SUM(a.QTY)
                                                    ELSE SUM(a.YardNet)
                                                END AS Fabric_Usage,
                                                SUM(a.ShortageInRoll) AS ShortageInRoll,
                                                CASE
                                                    WHEN d.Unit = 'KGS' THEN SUM(a.RestFabric) 
                                                    ELSE SUM(a.RestFabric)
                                                END AS RestFabric,
    		                                        CASE
                                                    WHEN d.Unit = 'KGS' THEN SUM(a.`Defect`) 
                                                    ELSE SUM(a.`Defect`)
                                                END AS Defect,
                                             		CASE
                                                    WHEN d.Unit = 'KGS' THEN SUM(a.`LappingFabric`) 
                                                    ELSE SUM(a.`LappingFabric`)
                                                END AS Lapping,
                                                IFNULL(d.LotNo , 'PO_DM') AS 'PO' ,
                                                b.Color,
                                                d.Color AS 'Color_PO',
                                                b.FabricType,
                                                b.FabricPerPCS AS CutPlan_FB_PCS
                                            FROM
                                                c_wh1_bc_sdactual_tb AS a
                                            LEFT JOIN
                                                c_warehouse1_bc_tb AS d ON d.Barcode = a.Barcode
                                            JOIN
                                                a_a1_spreading_list_tb AS b ON b.SD_ListDoc_No = a.SD_ListDoc_No 
                                            
                                            JOIN
                                                a_a3_scandoc_sd_ct_tb AS c ON c.SD_ListDoc_No = a.SD_ListDoc_No AND c.Cut_ScanOut  IS NOT NULL 
                                            WHERE
                                                
                                               b.SD_Status LIKE '1'
                                                AND b.SO LIKE '" + tbSo1.Text + @"'
                                            GROUP BY
                                                a.SD_ListDoc_No, d.LotNo, b.Color,d.FabricType
                                        ) AS fabric_usage
                                        LEFT JOIN
                                        (
                                            
                                            SELECT a.`SD_ListDoc_No`,  SUM(a.`QTY`) AS Cut_QTY,IFNULL(b.LotNo , 'PO_DM') AS PO 
                                            FROM `a_b1_bundle_tb` AS a
                                            LEFT JOIN c_warehouse1_bc_tb AS b ON a.BarcodeRef=b.Barcode
                                            WHERE  a.`MainPart`=1
                                            GROUP By a.`SD_ListDoc_No`,b.LotNo,b.FabricType
                                             
                                           
                                        ) AS p ON p.SD_ListDoc_No = fabric_usage.SD_ListDoc_No AND fabric_usage.PO=p.PO
                                        GROUP BY
                                            fabric_usage.SD_ListDoc_No, fabric_usage.PO, fabric_usage.Color,fabric_usage.FabricType
                            
                            
                            
                            
                                ) AS fb_Usage
                                LEFT JOIN
                                    a_fabric_usage AS f ON f.SO = fb_Usage.SO AND fb_Usage.Color = f.Color AND fb_Usage.PO = f.PO AND f.FabricType = fb_Usage.FabricType                                     
                                GROUP BY
                                    fb_Usage.PO, fb_Usage.Color ,fb_Usage.FabricType
                              ORDER BY  
                                                        fb_Usage.Color,
                                                        fb_Usage.PO,
                                                        fb_Usage.FabricType ASC;";
            ConnectMySQL.DisplayAndSearch(sqlfbUsage, gvRemarkByColor1);
            //dtfabricUsagefrom_SD = ConnectMySQL.MySQLtoDataTable(sqlfbUsage);
            //if (dtfabricUsagefrom_SD.Rows.Count > 0)
            //{
            //    for (int k = 0; k < gvRemarkByColor1.Rows.Count; k++)
            //    {
            //        for (int i = 0; i < dtfabricUsagefrom_SD.Rows.Count; i++)
            //        {
            //            if (gvRemarkByColor1.Rows[k].Cells["Colors"].Value.ToString() == dtfabricUsagefrom_SD.Rows[i]["Color"].ToString()
            //                && gvRemarkByColor1.Rows[k].Cells["PO"].Value.ToString() == dtfabricUsagefrom_SD.Rows[i]["PO"].ToString()
            //                && gvRemarkByColor1.Rows[k].Cells["FabricType"].Value.ToString() == dtfabricUsagefrom_SD.Rows[i]["FabricType"].ToString())
            //            {//Cut_QTY
            //                gvRemarkByColor1.Rows[k].Cells["Colors_PO"].Value = dtfabricUsagefrom_SD.Rows[i]["Color_PO"].ToString();

            //                gvRemarkByColor1.Rows[k].Cells["Cut_QTY"].Value = dtfabricUsagefrom_SD.Rows[i]["Cut_QTY"].ToString();
            //                gvRemarkByColor1.Rows[k].Cells["SD_FB_Usage"].Value = dtfabricUsagefrom_SD.Rows[i]["SD_FB_Usage"].ToString();
            //                gvRemarkByColor1.Rows[k].Cells["ReCut"].Value = dtfabricUsagefrom_SD.Rows[i]["ReCut"].ToString();
            //                gvRemarkByColor1.Rows[k].Cells["FBSpare"].Value = dtfabricUsagefrom_SD.Rows[i]["FBSpare"].ToString();
            //                gvRemarkByColor1.Rows[k].Cells["Lapping"].Value = dtfabricUsagefrom_SD.Rows[i]["Lapping"].ToString();
            //                gvRemarkByColor1.Rows[k].Cells["Defect"].Value = dtfabricUsagefrom_SD.Rows[i]["Defect"].ToString();
            //                gvRemarkByColor1.Rows[k].Cells["FBBinding"].Value = dtfabricUsagefrom_SD.Rows[i]["FBBinding"].ToString();
            //                gvRemarkByColor1.Rows[k].Cells["SD_RestFB"].Value = dtfabricUsagefrom_SD.Rows[i]["SD_RestFB"].ToString();
            //                gvRemarkByColor1.Rows[k].Cells["FB_Shortage"].Value = dtfabricUsagefrom_SD.Rows[i]["FB_Shortage"].ToString();
            //                gvRemarkByColor1.Rows[k].Cells["FB_Total_Usage"].Value = dtfabricUsagefrom_SD.Rows[i]["FB_Total_Usage"].ToString();
            //                gvRemarkByColor1.Rows[k].Cells["Fabric/PCS"].Value = dtfabricUsagefrom_SD.Rows[i]["Fabric/PCS"].ToString();
            //                gvRemarkByColor1.Rows[k].Cells["Unit"].Value = dtfabricUsagefrom_SD.Rows[i]["Unit"].ToString();
            //                gvRemarkByColor1.Rows[k].Cells["startDate"].Value = dtfabricUsagefrom_SD.Rows[i]["startDate"].ToString();
            //                gvRemarkByColor1.Rows[k].Cells["endDate"].Value = dtfabricUsagefrom_SD.Rows[i]["endDate"].ToString();
            //                gvRemarkByColor1.Rows[k].Cells["Rag"].Value = dtfabricUsagefrom_SD.Rows[i]["Rag"].ToString();
            //                gvRemarkByColor1.Rows[k].Cells["WasteAllowed%"].Value = dtfabricUsagefrom_SD.Rows[i]["WasteAllowed%"].ToString();
            //                gvRemarkByColor1.Rows[k].Cells["Remark"].Value = dtfabricUsagefrom_SD.Rows[i]["Remark"].ToString();

            //            }
            //        }
            //    }
            //}

        }
        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }
        public string selectpartToPrint = "";
        private void CuttingReport_Load(object sender, EventArgs e)
        {
            selectpartToPrint = "`a`.`MainPart`=1";
            cbbFabtricType.SelectedIndex = 0;
            if (tpSo.SelectedIndex == 0)
            {

            }
            //if (gvRemarkByColor1.Columns.Count == 0)
            //{
            //    gvRemarkByColor1.Columns.Add("PO", "PO");//
            //    gvRemarkByColor1.Columns.Add("Colors", "Colors");//
            //    gvRemarkByColor1.Columns.Add("Colors_PO", "Colors_PO");//
            //    gvRemarkByColor1.Columns.Add("FabricType", "FabricType");//

            //    gvRemarkByColor1.Columns.Add("Cut_QTY", "Cut_QTY");//
            //    gvRemarkByColor1.Columns.Add("SD_FB_Usage", "SD_FB_Usage");
            //    gvRemarkByColor1.Columns.Add("ReCut", "ReCut");//RestFabric
            //    gvRemarkByColor1.Columns.Add("FBSpare", "FBSpare");//
            //    gvRemarkByColor1.Columns.Add("Defect", "Defect");
            //    gvRemarkByColor1.Columns.Add("FBBinding", "FBBinding");                // AS 'YDS/KGS'
            //    gvRemarkByColor1.Columns.Add("SD_RestFB", "SD_RestFB");
            //    gvRemarkByColor1.Columns.Add("FB_Shortage", "FB_Shortage");
            //    gvRemarkByColor1.Columns.Add("Lapping", "Lapping");
            //    gvRemarkByColor1.Columns.Add("FB_Total_Usage", "FB_Total_Usage"); //Total
            //    gvRemarkByColor1.Columns.Add("Fabric/PCS", "Fabric/PCS");
            //    gvRemarkByColor1.Columns.Add("Unit", "Unit");
            //    gvRemarkByColor1.Columns.Add("startDate", "startDate");
            //    gvRemarkByColor1.Columns.Add("endDate", "endDate");
            //    gvRemarkByColor1.Columns.Add("Rag", "Rag"); //Rag
            //    gvRemarkByColor1.Columns.Add("WasteAllowed%", "WasteAllowed%");
            //    gvRemarkByColor1.Columns.Add("Remark", "Remark");

            //}
        }

        private void tbSo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searsh();
            }
        }

        private void gvSpreadingList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                SDRowIndex = e.RowIndex;

            }

        }

        private void btSave1_Click(object sender, EventArgs e)
        {
            if (tbSo.Text.Length == 12 || tbSo.Text.Length == 13 || tbSo.Text.Length == 14 && gvSoDetail.Rows.Count > 0)
            {
                rjobStart = tbSoStartDate.Text;
                rCutFinish = tbCutFinishDate.Text;
                rDeadline = tbDeadline.Text;
                rIssuetoAccount = tbIssueDate.Text;
                bool st = false;

                ConnectMySQL.db = "pts_db";
                string insertMultiValue = "";

                bool first = false;
                for (int i = 0; i < gvRemarkByColor1.Rows.Count; i++)
                {
                    string color = gvRemarkByColor1.Rows[i].Cells["Color"].Value.ToString();



                    if (!first)
                    {
                        insertMultiValue = "(NULL, '" + tbSo.Text + "','" + tbMer.Text + "','" + tbProductType.Text + "','" + tbBrand.Text + "','" + color + "','" + tbPrice.Text + "','" + tbCutBy.Text + "'," +
                        "'" + tbPlaceSew.Text + "','" + tbPlaceEmbro.Text + "','" + tbPlacePrint.Text + "','" + tbSoStartDate.Text + "'," +
                        "'" + tbCutFinishDate.Text + "','" + tbDeadline.Text + "','" + tbIssueDate.Text + "','" + tbSoRemark.Text + "')";
                        first = true;
                    }
                    else
                    {
                        insertMultiValue = insertMultiValue + ",(NULL, '" + tbSo.Text + "','" + tbMer.Text + "','" + tbProductType.Text + "','" + tbBrand.Text + "','" + color + "','" + tbPrice.Text + "'," +
                        "'" + tbCutBy.Text + "','" + tbPlaceSew.Text + "','" + tbPlaceEmbro.Text + "','" + tbPlacePrint.Text + "','" + tbSoStartDate.Text + "'," +
                        "'" + tbCutFinishDate.Text + "','" + tbDeadline.Text + "','" + tbIssueDate.Text + "','" + tbSoRemark.Text + "')";
                    }
                }
                if (insertMultiValue != "")
                {
                    ConnectMySQL.MysqlQuery("DELETE FROM `so_detail_tb` WHERE `So` LIKE '" + tbSo1.Text + "';");
                    ConnectMySQL.MysqlQuery("ALTER TABLE `so_detail_tb` auto_increment = 1;");
                    string stsql = "INSERT INTO `so_detail_tb` (`ID`, `So`, `Mer`,`Product_type`,`Brand`, `Color`, `Price`, `CutBy`, `PlaceSew`, `PlaceEmbr`, `PlacePrinting`, " +
                        "`JobStartSO`, `CutFinished`, `Deadline`, `issueAccount`,  `SoRemark`) " +
                    "VALUES " + insertMultiValue + ";";

                    st = ConnectMySQL.MysqlQuery(stsql);
                }
                if (st)
                {
                    MessageBox.Show("OK", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("!!! Can't save data !!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {//  MessageBox.Show("Operation was successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("!!!Please check data!!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string setDate(DateTimePicker dtpVal)
        {
            string txtDate = "";
            System.Globalization.CultureInfo _cultureEnInfo = new System.Globalization.CultureInfo("en-US");
            DateTime dateEng = Convert.ToDateTime(dtpVal.Value, _cultureEnInfo);
            txtDate = dateEng.ToString("yyyy-MM-dd", _cultureEnInfo);
            return txtDate;
        }
        public CheckedListBox getColortoPrint = new CheckedListBox();

        private void btActualPrint1_Click(object sender, EventArgs e)
        {
            if (gvSoDetail.Rows.Count > 0)
            {
                getColortoPrint.Items.Clear();
                using (selectColorPrint di = new selectColorPrint())
                {
                    if (di.ShowDialog() == DialogResult.OK)
                    {
                        //updateQTYFabric();

                        rSO = tbSo.Text;
                        rStyle = tbStyle.Text;
                        rCus = tbCus.Text;
                        rCusCode = tbcusCode.Text;
                        rCusStyle = tbCusStyle.Text;
                        rjobStart = tbSoStartDate.Text;
                        rCutFinish = tbCutFinishDate.Text;
                        rDeadline = tbDeadline.Text;
                        rIssuetoAccount = tbIssueDate.Text;
                        rCutBy = tbCutBy.Text;
                        rPrice = tbPrice.Text;
                        rPlaceSew = tbPlaceSew.Text;
                        rPlaceEmbro = tbPlaceEmbro.Text;
                        rPlacePrint = tbPlacePrint.Text;
                        rMer = tbMer.Text;
                        rpSoRemark = tbSoRemark.Text;
                        rpProduct_Type = tbProductType.Text;
                        rpBrand = tbBrand.Text;
                        appData1.Clear();
                        bool freeRout = false;
                        if (printMode == 0) //Actual Cut
                        {
                            for (int i = 0; i < gvSoDetail.Rows.Count; i++)
                            {
                                for (int k = 0; k < getColortoPrint.Items.Count; k++)
                                {
                                    if (gvSoDetail.Rows[i].Cells[0].Value.ToString() == getColortoPrint.Items[k].ToString() || freeRout)
                                    {
                                        for (int j = 2; j < gvSoDetail.Columns.Count; j++)
                                        {
                                            string ColumnName = gvSoDetail.Columns[j].HeaderText;
                                            string color = gvSoDetail.Rows[i].Cells[0].Value.ToString();
                                            string _r = gvSoDetail.Rows[i].Cells[1].Value.ToString();
                                            int RowId = gvSoDetail.Rows.IndexOf(gvSoDetail.Rows[i]);
                                            string Value = gvSoDetail.Rows[i].Cells[j].Value.ToString();
                                            appData1.ActualCutTb.AddActualCutTbRow(color, _r, ColumnName, RowId, Value);
                                        }
                                        if (gvSoDetail.Rows[i].Cells[0].Value.ToString().Trim().Length > 0)
                                        {
                                            freeRout = true;
                                        }
                                        else
                                        {
                                            freeRout = false;
                                        }
                                    }
                                }
                            }

                            for (int i = 0; i < gvRemarkByColor1.Rows.Count; i++)
                            {
                                for (int k = 0; k < getColortoPrint.Items.Count; k++)
                                {
                                    //MessageBox.Show(gvRemarkByColor1.Rows[i].Cells["Color"].Value.ToString() + "||" + getColortoPrint.Items[k].ToString());
                                    if (gvRemarkByColor1.Rows[i].Cells["Color"].Value.ToString() == getColortoPrint.Items[k].ToString())
                                    {
                                        //string ColumnName = gvSoDetail.Columns[j].HeaderText;
                                        string color = (gvRemarkByColor1.Rows[i].Cells["Color"].Value ?? "").ToString()
                                            + " || " + (gvRemarkByColor1.Rows[i].Cells["Color_PO"].Value ?? "").ToString()
                                            + " || " + (gvRemarkByColor1.Rows[i].Cells["PO"].Value ?? "").ToString();

                                        string StartDate = (gvRemarkByColor1.Rows[i].Cells["startDate"].Value ?? "").ToString();
                                        string EndDate = (gvRemarkByColor1.Rows[i].Cells["endDate"].Value ?? "").ToString();

                                        string Remark = "";
                                        var cells = gvRemarkByColor1.Rows[i].Cells;

                                        void AddToRemark(string title, object value, string suffix = "")
                                        {
                                            string text = (value ?? "").ToString().Trim();
                                            if (!string.IsNullOrEmpty(text) && text != "0" && text != "0.00")
                                            {
                                                Remark += $" || {title}: {text}{suffix}";
                                            }
                                        }

                                        AddToRemark("Fabric_Type", cells["FabricType"].Value);
                                        AddToRemark("Cut_QTY", cells["Cut_QTY"].Value, " PCS");
                                        AddToRemark("SD_FB_Usage", cells["SD_FB_Usage"].Value, $" {cells["Unit"].Value ?? ""}");
                                        AddToRemark("ReCut", cells["ReCut"].Value, $" {cells["Unit"].Value ?? ""}");
                                        AddToRemark("FBSpare", cells["FBSpare"].Value, $" {cells["Unit"].Value ?? ""}");
                                        AddToRemark("Defect", cells["Defect"].Value);
                                        AddToRemark("FBBinding", cells["FBBinding"].Value, $" {cells["Unit"].Value ?? ""}");
                                        AddToRemark("SD_RestFB", cells["SD_RestFB"].Value, $" {cells["Unit"].Value ?? ""}");
                                        AddToRemark("Lapping", cells["Lapping"].Value, $" {cells["Unit"].Value ?? ""}");
                                        AddToRemark("FB_Shortage", cells["FB_Shortage"].Value, $" {cells["Unit"].Value ?? ""}");
                                        AddToRemark("FB_Total_Usage", cells["FB_Total_Usage"].Value, $" {cells["Unit"].Value ?? ""}");
                                        AddToRemark("Fabric/PCS", cells["Fabric/PCS"].Value, $" {cells["Unit"].Value ?? ""}");
                                        AddToRemark("Rag", cells["Rag"].Value, " KGS");
                                        AddToRemark("WasteAllowed%", cells["WasteAllowed%"].Value, " %");
                                        AddToRemark("Remark", cells["Remark"].Value);

                                        // Remove leading " || " if exists
                                        if (Remark.StartsWith(" || "))
                                        {
                                            Remark = Remark.Substring(4);
                                        }

                                        for (int a = 0; a < dtsoDetail.Rows.Count; a++)
                                        {
                                            if (dtsoDetail.Rows[a]["Color"].ToString() == getColortoPrint.Items[k].ToString())
                                            {
                                                Remark = Remark + "   Manual Record" + dtsoDetail.Rows[a]["ColorRemark"].ToString();
                                            }
                                        }

                                        appData1.CuttingRemarkByColor.AddCuttingRemarkByColorRow(color, StartDate, EndDate, Remark);
                                    }
                                }
                            }
                            using (ActualCutPreview pf = new ActualCutPreview(appData1.ActualCutTb, appData1.CuttingRemarkByColor))
                            {
                                pf.ShowDialog();
                            }
                        }
                        else if (printMode == 1)//Bundle Report
                        {
                            for (int i = 0; i < dtBundleReport.Rows.Count; i++)
                            {
                                //if (dtBundleReport.Rows[i]["Spreading ID"].ToString().Trim() == chGetSpreadingID.Items[j].ToString().Trim())
                                //{
                                string color = dtBundleReport.Rows[i]["Color"].ToString();
                                string no = dtBundleReport.Rows[i]["No"].ToString();
                                string size = dtBundleReport.Rows[i]["Size"].ToString();
                                string sdid = dtBundleReport.Rows[i]["Spreading ID"].ToString();
                                string bdno = dtBundleReport.Rows[i]["Bundle No"].ToString();
                                string qty = dtBundleReport.Rows[i]["QTY"].ToString();
                                string dec = dtBundleReport.Rows[i]["Remark"].ToString();
                                appData1.BundleTb.AddBundleTbRow(color, no, size, sdid, bdno, qty, dec);
                                // }

                            }
                            using (BundlePreview pf = new BundlePreview(appData1.BundleTb))
                            {
                                pf.ShowDialog();
                            }
                        }

                    }
                }
            }
        }
        public DataTable dtBundleReport = new DataTable();//`a`.`MainPart`=1 
        public int printMode = -1;
        public void searchBundle(string spreadingIDSearch)
        {
            if (tbSo1.Text.Length == 12 || tbSo1.Text.Length == 13 || tbSo1.Text.Length == 14)
            {



                string query = "SELECT `b`.`Color`,`a`.`Size`,`a`.`SD_ListDoc_No`, `a`.`BundleNo`,(`a`.`QTY`) AS `QTY`, `a`.`Deco` " +
                    "FROM `a_b1_bundle_tb` AS `a`" +
                    "JOIN `a_a1_spreading_list_tb` AS `b` ON `a`.`SD_ListDoc_No`=`b`.`SD_ListDoc_No` AND `b`.`FabricType` LIKE '" + cbbFabtricType.Text + "' AND `b`.`SD_Status` LIKE '1' " +
                    "LEFT JOIN `sizes_tb` AS `c` ON `a`.`Size`=`c`.`Size` " +
                    "JOIN `a_a3_scandoc_sd_ct_tb` AS `d`ON `d`.`SD_ListDoc_No` =`a`.`SD_ListDoc_No`AND `d`.`Cut_ScanOut` IS NOT NULL  " +
                    "WHERE " + selectpartToPrint + " AND `a`.`SD_ListDoc_No` IN (" + spreadingIDSearch + ")" +
                    "ORDER BY `a`.`Color`,`c`.`SeqNo`,`a`.`SD_ListDoc_No`,`a`.`BundleNo` ASC;";
                HomePage.ins.txtQuery(query);
                DataTable dtBundle = ConnectMySQL.MySQLtoDataTable(query);
                DataTable dt = new DataTable();
                dt.Columns.Add("Color");
                dt.Columns.Add("No");
                dt.Columns.Add("Size");
                dt.Columns.Add("Spreading ID");
                dt.Columns.Add("Bundle No");
                dt.Columns.Add("QTY");
                dt.Columns.Add("Remark");
                bool checkDiff = false;
                string subcc = "";
                string subss = "";
                string subsd = "";
                int no = 0;
                //MessageBox.Show(dtBundle.Rows.Count.ToString()+"||"+ SizeFromMySql.Rows.Count.ToString());
                if (dtBundle.Rows.Count > 0 && SizeFromMySql.Rows.Count > 0)
                {
                    for (int i = 0; i < dtBundle.Rows.Count; i++)
                    {
                        string cc = dtBundle.Rows[i]["Color"].ToString();
                        string ss = dtBundle.Rows[i]["Size"].ToString();
                        string sd = dtBundle.Rows[i]["SD_ListDoc_No"].ToString();
                        string bdno = dtBundle.Rows[i]["BundleNo"].ToString();
                        string qty = dtBundle.Rows[i]["QTY"].ToString();

                        if (subcc != cc)
                        {
                            int orderQty = 0;
                            // MessageBox.Show(SizeFromMySql.Rows.Count.ToString());
                            for (int k = 0; k < SizeFromMySql.Rows.Count; k++)
                            {
                                if (cc == SizeFromMySql.Rows[k]["Color"].ToString())
                                {
                                    orderQty += int.Parse(SizeFromMySql.Rows[k]["QTY"].ToString());
                                }
                            }
                            string order = "Order : " + orderQty.ToString();
                            int ActualCutQty = 0;
                            for (int k = 0; k < dtBundle.Rows.Count; k++)
                            {
                                if (cc == dtBundle.Rows[k]["Color"].ToString())
                                {
                                    ActualCutQty += int.Parse(dtBundle.Rows[k]["QTY"].ToString());
                                }
                            }
                            string ActualCut = "Actual Cut : " + ActualCutQty.ToString();
                            dt.Rows.Add(cc, "", "", order, ActualCut);

                            no = 0;
                        }
                        if (subss != ss || subsd != sd)
                        {
                            no = 0;

                            int ActualCutQty = 0;
                            for (int k = 0; k < dtBundle.Rows.Count; k++)
                            {
                                if (ss == dtBundle.Rows[k]["Size"].ToString() && cc == dtBundle.Rows[k]["Color"].ToString() && sd == dtBundle.Rows[k]["SD_ListDoc_No"].ToString())
                                {
                                    ActualCutQty += int.Parse(dtBundle.Rows[k]["QTY"].ToString());
                                }
                            }
                            string ActualCut = "Actual Cut : " + ActualCutQty.ToString();
                            dt.Rows.Add("", "", ss, "", ActualCut);

                        }
                        no++;
                        dt.Rows.Add(cc, no.ToString(), ss, sd, bdno, qty, "");
                        subcc = cc;
                        subss = ss;
                        subsd = sd;
                    }
                    dtBundleReport = dt;

                }
                else
                {
                    MessageBox.Show("Please Check SO or Bundle Detail.");
                }
            }
            else
            {
                MessageBox.Show("!!! SO Data Have 12 Digit !!!");
            }
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void btUpdateColor_Click(object sender, EventArgs e)
        {
            if (HomePage.ins.checkPermiss("UpdateColortoSDlikeSO"))
            {
                if (soIndex > -1 && SDRowIndex > -1)
                {
                    if (MessageBox.Show("Are you sure you want to update color", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        bool st = ConnectMySQL.MysqlQuery("UPDATE `a_a1_spreading_list_tb` SET `Color`='" + gvSoDetail.Rows[soIndex].Cells[0].Value.ToString() + "' WHERE `SD_ListDoc_No`LIKE '" + gvSpreadingList.Rows[SDRowIndex].Cells[0].Value.ToString() + "'");
                        if (st)
                        {
                            MessageBox.Show("OK");
                            searsh();
                        }
                        else
                        {
                            MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        soIndex = -1;
                        SDRowIndex = -1;
                    }
                }
                else
                {
                    MessageBox.Show("Please Select SO row or Spreading row.");
                }
            }
            else
            {
                MessageBox.Show("Don't Have Permission.", "Imformation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        int soIndex = -1;
        int soColumnIndex = -1;
        private void gvSoDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                soIndex = e.RowIndex;
                soColumnIndex = e.ColumnIndex;
            }
        }
        int SDRowIndex = 0;
        int SDColumnIndex = 0;
        private void gvSpreadingList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                SDRowIndex = e.RowIndex;
                doubleSearch();
            }
        }
        private void doubleSearch()
        {



            string sdid = gvSpreadingList.Rows[SDRowIndex].Cells["SD_ListDoc_No"].Value.ToString();
            ConvertTable.getQTYBySizeBreakdownReport(@"SELECT `a`.`Color`,`a`.`Size`, SUM(`a`.`QTY`) AS `QTY` 
                FROM `a_b1_bundle_tb` AS `a`
                LEFT JOIN sizes_tb s ON a.`Size`= s.Size
                WHERE `a`.`SD_ListDoc_No`LIKE '" + sdid + "' AND `MainPart`=1 GROUP BY `a`.`Color`,`a`.`Size` ORDER BY s.SeqNo ASC;", gvSDDetail);
            lbhead1.Text = "Spreading Detail Table  " + sdid;
            gvSDDetail.Columns["Color"].Width = 200;
            for (int i = 1; i < gvSDDetail.Columns.Count; i++)
            {
                gvSDDetail.Columns[i].Width = 65;
            }

        }
        private void btUpdateSizeSo_Click(object sender, EventArgs e)
        {
            if (HomePage.ins.checkPermiss("UpdateSizetoSDlikeSO"))
            {
                if (soColumnIndex > -1 && SDColumnIndex > -1)
                {
                    if (MessageBox.Show("Are you sure you want to update size", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string query = @"UPDATE `a_b1_bundle_tb` AS `a`
                                            SET `a`.`Size` = '" + gvSoDetail.Columns[soColumnIndex].HeaderText + @"'
                                            WHERE `a`.`Size` LIKE '" + gvSDDetail.Columns[SDColumnIndex].HeaderText + @"'
                                              AND `a`.`SD_ListDoc_No` LIKE '" + gvSpreadingList.Rows[SDRowIndex].Cells[0].Value.ToString() + @"';

                                            UPDATE `b_scaned_bundle` AS `b`
                                            SET `b`.`sb_size` = '" + gvSoDetail.Columns[soColumnIndex].HeaderText + @"'
                                            WHERE `b`.`sb_size` LIKE '" + gvSDDetail.Columns[SDColumnIndex].HeaderText + @"'
                                              AND `b`.`sb_sdlistdocno` LIKE '" + gvSpreadingList.Rows[SDRowIndex].Cells[0].Value.ToString() + @"';";

                        bool st = ConnectMySQL.MysqlQuery(query);
                        if (st)
                        {
                            MessageBox.Show("OK");
                            searsh();
                            doubleSearch();
                        }
                        else
                        {
                            MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        soColumnIndex = -1;
                        SDColumnIndex = -1;
                    }
                }
                else
                {
                    MessageBox.Show("Please Select SO row or Spreading row.");
                }
            }
            else
            {
                MessageBox.Show("Don't Have Permission.", "Imformation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gvSDDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1)
            {
                SDColumnIndex = e.ColumnIndex;
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (HomePage.ins.checkPermiss("sd_StatusSD"))
            {
                if (SDRowIndex > -1)
                {
                    if (MessageBox.Show("Are you sure you want to cancel document", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string txt = gvSpreadingList.Rows[SDRowIndex].Cells[0].Value.ToString();
                        string batchQuery = $@"
    UPDATE `a_a1_spreading_list_tb` 
    SET `SD_Status` = '0' 
    WHERE `SD_ListDoc_No` LIKE '{txt}';

    DELETE FROM `a_a4_sd_scanout_qty_tb` 
    WHERE `SD_ListDoc_No` LIKE '{txt}';

    DELETE FROM `a_a3_scandoc_sd_ct_tb` 
    WHERE `SD_ListDoc_No` LIKE '{txt}';

    DELETE FROM `a_b1_bundle_tb` 
    WHERE `SD_ListDoc_No` LIKE '{txt}';
";

                        bool st = ConnectMySQL.MysqlQuery(batchQuery);
                        if (st)
                        {
                            MessageBox.Show("OK");
                        }
                        else
                        {
                            MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        SDRowIndex = -1;
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Spreading ID.");
                }
            }
        }

        public string fabricType = "";
        private void cbbFabtricType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //searchFtype(cbbFabtricType.Text);
            fabricType = cbbFabtricType.Text;
        }

        private void btSearchFB_Click(object sender, EventArgs e)
        {
            searchFtype(cbbFabtricType.Text);
        }

        private void btfabricUsage_Click(object sender, EventArgs e)
        {
            FabricUsage fabricUsage = new FabricUsage();
            fabricUsage.Show();
            fabricUsage.Location = new Point(
     (this.Location.X + this.Width * 20 / 21) - (fabricUsage.Width / 2),
     (this.Location.Y + this.Height / 2) - (fabricUsage.Height / 2));
            fabricUsage.StartPosition = FormStartPosition.Manual;
        }

        private void btFrbricUsage_Click(object sender, EventArgs e)
        {

            //       fabricUsage.Location = new Point(
            //(this.Location.X + this.Width * 20 / 21) - (fabricUsage.Width / 2),
            //(this.Location.Y + this.Height / 2) - (fabricUsage.Height / 2));
            //       fabricUsage.StartPosition = FormStartPosition.Manual;
        }

        private void btOffCut_Fabric_Click(object sender, EventArgs e)
        {//FabricUsage


        }

        private void btOffCut_Fabric1_Click(object sender, EventArgs e)
        {
            if (rSO != "" && po != "" && color != "")
            {
                using (FabricUsage di = new FabricUsage())
                {
                    if (di.ShowDialog() == DialogResult.OK)
                    {
                        fbUsage_data();
                    }
                }
                // FabricUsage fabricUsage = new FabricUsage();
                //fabricUsage.Show();
            }
            else
            {
                MessageBox.Show("Please Select Row");
            }
        }
        public string po = "";
        public string color = "";
        public string Unit = "";


        private void btFrbricUsage2_Click(object sender, EventArgs e)
        {
            FabricUsageBySD fabricUsage = new FabricUsageBySD();
            fabricUsage.Show();
            //using (FabricUsageBySD di = new FabricUsageBySD())
            //{
            //    if (di.ShowDialog() == DialogResult.OK)
            //    {

            //    }
            //}
        }

        private void gvRemarkByColor1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                po = gvRemarkByColor1.Rows[e.RowIndex].Cells["PO"].Value.ToString();
                color = gvRemarkByColor1.Rows[e.RowIndex].Cells["Color"].Value.ToString();
                fabricType = gvRemarkByColor1.Rows[e.RowIndex].Cells["FabricType"].Value.ToString();
                Unit = gvRemarkByColor1.Rows[e.RowIndex].Cells["Unit"].Value.ToString();
            }
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            if (gvDaily.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                xcelApp.Application.Workbooks.Add(Type.Missing);

                for (int i = 1; i < gvDaily.Columns.Count + 1; i++)
                {
                    xcelApp.Cells[1, i] = gvDaily.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < gvDaily.Rows.Count; i++)
                {
                    for (int j = 0; j < gvDaily.Columns.Count; j++)
                    {
                        xcelApp.Cells[i + 2, j + 1] = gvDaily.Rows[i].Cells[j].Value.ToString();
                    }
                }
                xcelApp.Columns.AutoFit();
                xcelApp.Visible = true;
            }
        }

        private void tool_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btRecut_Click(object sender, EventArgs e)
        {
            Recut recut = new Recut();
            recut.Show();
        }
    }
}
