using PTS_For_Cut.Myclass;
using System.Data;
using System.Text.RegularExpressions;

namespace PTS_For_Cut._3Spreading.Report
{
    public partial class FabricUsageBySD : Form
    {
        public FabricUsageBySD()
        {
            InitializeComponent();
        }

        private void FabricUsageBySD_Load(object sender, EventArgs e)
        {
            //cbbSeparateBy2.Items.Clear();
            //cbbSeparateBy2.Items.Add("PO");
            //cbbSeparateBy2.Items.Add("Spreading Doc");
            cbbSearchBy.SelectedIndex = 0;
            tbSOSearch.Text = CuttingReport.ins.rSO;
            if (tbSOSearch.Text.Length > 10)
            {
                fb_UsageSearch(tbSOSearch.Text);
            }

        }
        private void fb_UsageSearch(string txt)
        {
            gvFBUsage.DataSource = null;

            txt = txt.Trim();

            // Split by multiple delimiters: comma, hyphen, space, newline, and carriage return
            string[] items = Regex.Split(txt, @"[\s,\-\r\n]+").Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

            // Format the output with single quotes
            string formatted = $"({string.Join(",", items.Select(item => $"'{item}'"))})";
            string sql = "";
            string startDate = setDate(dtpStart1);
            string endDate = setDate(dtpEnd1);
            if (cbbSearchBy.SelectedIndex == 0)
            {
                if (cbbSeparateBy2.SelectedIndex == 0)
                {
                    sql = @"SELECT
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
                                                AND b.SO IN " + formatted + @"
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
                }
                else if (cbbSeparateBy2.SelectedIndex == 1)
                {
                    sql = @" SELECT
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
                                                AND b.SO IN " + formatted + @"
                                            GROUP BY
                                                a.SD_ListDoc_No, d.LotNo, b.Color,d.FabricType;";
                }
                else if (cbbSeparateBy2.SelectedIndex == 2)
                {
                    sql = @"SELECT
                                (SELECT MAX(SO) FROM a_a1_spreading_list_tb b WHERE b.SD_ListDoc_No = a.SD_ListDoc_No AND b.SD_Status = '1') AS SO,
                                 a.SD_ListDoc_No,
                                    a.`Barcode`,									
                                    (SELECT MAX(Color) FROM a_a1_spreading_list_tb b WHERE b.SD_ListDoc_No = a.SD_ListDoc_No AND b.SD_Status = '1') AS Color,
                                    p.Cut_QTY,
                                    (SELECT MAX(`Marker_LengthYard`) FROM a_a1_spreading_list_tb b WHERE b.SD_ListDoc_No = a.SD_ListDoc_No AND b.SD_Status = '1') AS Marker_LengthYard,
                                    CASE
                                        WHEN d.Unit = 'KGS' THEN a.QTY
                                        WHEN d.Unit = 'YDS' THEN a.YardNet
                                        ELSE NULL
                                    END AS 'FB_Cutplan',
                                    a.`Plies`,
                                    a.`PliesActual`,
                                    
                                    CASE
                                        WHEN d.Unit = 'KGS' THEN a.QTY- a.ShortageInRoll
                                        WHEN d.Unit = 'YDS' THEN a.YardNet -a.ShortageInRoll
                                        ELSE NULL
                                    END AS 'FB_Usage'
                                    ,
                                    (a.ShortageInRoll) AS ShortageInRoll,
                                    (a.RestFabric) AS RestFabric,
                                    (a.`Defect`) AS Defect,
                                    (a.`LappingFabric`) AS Lapping,
                                    (SELECT MAX(FabricPerPCS) FROM a_a1_spreading_list_tb b WHERE b.SD_ListDoc_No = a.SD_ListDoc_No AND b.SD_Status = '1') AS 'CutPlan_FB/PCS',
                                     CASE
                                        WHEN d.Unit = 'KGS' THEN (a.QTY- a.ShortageInRoll)/p.Cut_QTY
                                        WHEN d.Unit = 'YDS' THEN (a.YardNet -a.ShortageInRoll)/p.Cut_QTY
                                        ELSE NULL
                                    END  AS 'Act_FB/PCS',
                                   CASE
      	                                WHEN d.Unit = 'M' THEN 'YDS'
    	                                ELSE d.Unit
                                    END AS 'Unit',
                                    a.`IndexSort`
                                FROM c_wh1_bc_sdactual_tb AS a
                                  LEFT JOIN
                                  c_warehouse1_bc_tb AS d ON d.Barcode = a.Barcode
                                  JOIN
                                    (
                                        SELECT
                                            SD_ListDoc_No,BarcodeRef,
                                            SUM(QTY) AS Cut_QTY 
                                        FROM
                                            a_b1_bundle_tb
                                        WHERE MainPart = 1
                                        GROUP BY SD_ListDoc_No,BarcodeRef
                                    ) AS p ON p.SD_ListDoc_No = a.SD_ListDoc_No AND p.BarcodeRef = a.Barcode
                                WHERE EXISTS (
                                    SELECT 1 FROM a_a1_spreading_list_tb b WHERE b.SD_ListDoc_No = a.SD_ListDoc_No AND b.SD_Status = '1' 
                                    AND b.SO IN " + formatted + @"                               
                                )
                                GROUP BY a.`Barcode`, a.SD_ListDoc_No
                                ORDER BY SO, Color,a.SD_ListDoc_No, a.`IndexSort`,a.`BcID`;";
                }
            }
            if (cbbSearchBy.SelectedIndex == 1)
            {
                if (cbbSeparateBy2.SelectedIndex == 0)
                {
                    sql = @"SELECT
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
     ROUND((SUM(fb_Usage.Fabric_Usage) + IFNULL(f.FBReplatement,0)  + IFNULL(f.HemFB,0) - SUM(fb_Usage.ShortageInRoll)),3) AS FB_Total_Usage, 
     ROUND((SUM(fb_Usage.Fabric_Usage) + IFNULL(f.FBReplatement,0)+ IFNULL(f.HemFB,0) - SUM(fb_Usage.ShortageInRoll))/SUM(fb_Usage.Cut_QTY), 3) AS 'Fabric/PCS',
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
                                                SUM(a.RestFabric) AS RestFabric,
    		                                    SUM(a.`Defect`) AS Defect,
                                             	SUM(a.`LappingFabric`) AS Lapping,
                                                d.LotNo AS 'PO',
                                                b.Color,
                                                d.Color AS 'Color_PO',
                                                d.FabricType,
                                                b.FabricPerPCS AS CutPlan_FB_PCS
                                            FROM
                                                c_wh1_bc_sdactual_tb AS a
                                            LEFT JOIN
                                                c_warehouse1_bc_tb AS d ON d.Barcode = a.Barcode
                                            JOIN
                                                a_a1_spreading_list_tb AS b ON b.SD_ListDoc_No = a.SD_ListDoc_No
                                            JOIN
                                                a_a3_scandoc_sd_ct_tb AS c ON c.SD_ListDoc_No = a.SD_ListDoc_No 
                                            WHERE
                                                b.FabricType LIKE 'A'
                                                AND b.SD_Status LIKE '1'
                                                AND DATE(c.Cut_ScanOut) BETWEEN '" + startDate + @"' AND '" + endDate + @"'
                                            GROUP BY
                                                a.SD_ListDoc_No, d.LotNo, b.Color
                                        ) AS fabric_usage
                                        JOIN
                                        (
                                            SELECT
                                                SD_ListDoc_No,
                                                SUM(QTY) AS Cut_QTY  -- SUM Cut_QTY from a_b1_bundle_tb
                                            FROM
                                                a_b1_bundle_tb
                                            WHERE MainPart = 1
                                            GROUP BY SD_ListDoc_No
                                        ) AS p ON p.SD_ListDoc_No = fabric_usage.SD_ListDoc_No
                                        GROUP BY
                                            fabric_usage.SD_ListDoc_No, fabric_usage.PO, fabric_usage.Color

                                ) AS fb_Usage
                                LEFT JOIN
                                    a_fabric_usage AS f ON f.SO = fb_Usage.SO AND fb_Usage.Color = f.Color AND fb_Usage.PO = f.PO AND f.FabricType = fb_Usage.FabricType                                     
                                GROUP BY
                                    fb_Usage.PO, fb_Usage.Color;";

                }
            }
            //MessageBox.Show(sql);
            ConnectMySQL.DisplayAndSearch(sql, gvFBUsage);

            //   ConnectMySQL.DisplayAndSearch("SELECT `id`,`SO`, `Color`, `PO`, `FBOffcut` FROM `a_fabric_usage` WHERE `SO` IN  " + formatted, gvOffCut);

        }
        private string setDate(DateTimePicker dtpVal)
        {
            string txtDate = "";
            System.Globalization.CultureInfo _cultureEnInfo = new System.Globalization.CultureInfo("en-US");
            DateTime dateEng = Convert.ToDateTime(dtpVal.Value, _cultureEnInfo);
            txtDate = dateEng.ToString("yyyy-MM-dd", _cultureEnInfo);
            return txtDate;
        }

        private void tbSearchSO_Click(object sender, EventArgs e)
        {
            if (tbSOSearch.Text.Length > 10)
            {
                fb_UsageSearch(tbSOSearch.Text);
            }
        }

        private void tbSOSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tbSOSearch.Text.Length > 10)
                {
                    fb_UsageSearch(tbSOSearch.Text);
                }

            }
        }


        int gvOffCutRow = -1;
        private void gvOffCut_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                gvOffCutRow = e.RowIndex;
            }
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            if (gvFBUsage.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                xcelApp.Application.Workbooks.Add(Type.Missing);

                for (int i = 1; i < gvFBUsage.Columns.Count + 1; i++)
                {
                    xcelApp.Cells[1, i] = gvFBUsage.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < gvFBUsage.Rows.Count; i++)
                {
                    for (int j = 0; j < gvFBUsage.Columns.Count; j++)
                    {
                        xcelApp.Cells[i + 2, j + 1] = gvFBUsage.Rows[i].Cells[j].Value.ToString();
                    }
                }
                xcelApp.Columns.AutoFit();
                xcelApp.Visible = true;
            }
        }

        private void cbbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbSearchBy.SelectedIndex > -1)
            {

                if (cbbSearchBy.SelectedIndex == 0)
                {

                    tbSOSearch.Visible = true;
                    pnDate.Visible = false;
                    cbbSeparateBy2.SelectedIndex = 0;
                }
                else if (cbbSearchBy.SelectedIndex == 1)
                {

                    tbSOSearch.Visible = false;
                    pnDate.Visible = true;
                    cbbSeparateBy2.SelectedIndex = 0;
                }
            }

        }
    }
}
