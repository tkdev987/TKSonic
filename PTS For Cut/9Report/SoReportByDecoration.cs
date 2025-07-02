using PTS_For_Cut.Myclass;
using System.Data;

namespace PTS_For_Cut._9Report
{
    public partial class SoReportByDecoration : Form
    {
        public SoReportByDecoration()
        {
            InitializeComponent();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            string txt = tbSo.Text.Trim();
            string[] items = txt.Split(',');

            // Use string.Join to concatenate the items, adding single quotes around each item
            string SearchIn = $"({string.Join(",", items.Select(item => $"'{item}'"))})";
            string txtSql = "";
            if (cbbDepartment.SelectedIndex == 0)
            {
                txtSql = "SELECT `So`,`Style`,`Customer_Name`,`Customer_Style`,`Date`,`Color`, `Size`,SUM(`Qty`) AS `QTY`," +
                    "`GarmentType`,`Brand` FROM `so_tb` WHERE `So`IN " + SearchIn + " GROUP BY `So`,`Color`, `Size`;";
            }
            else if (cbbDepartment.SelectedIndex == 1)
            {
                txtSql = @"SELECT `a`.`SO`,MIN(DATE(c.`Cut_ScanOut`)) AS FirstDATE,MAX(DATE(c.`Cut_ScanOut`)) AS LastDATE,`b`.`Color`, `a`.`Size`, SUM(`a`.`QTY`)AS `QTY` 
                                        FROM `a_b1_bundle_tb` AS `a` 
                                      
                                        JOIN `a_a1_spreading_list_tb` AS `b` ON `b`.`SD_ListDoc_No`=`a`.`SD_ListDoc_No` AND b.`FabricType` LIKE 'A' AND b.`SD_Status` LIKE '1' 
                                        JOIN a_a3_scandoc_sd_ct_tb AS c ON a.SD_ListDoc_No = c.SD_ListDoc_No AND c.`Cut_ScanOut`  IS NOT NULL 
                                        
                                        WHERE `a`.`MainPart` = '1'
                                        AND `a`.`So`IN " + SearchIn + @"
                        GROUP BY `a`.`SO`,`b`.`Color`,`a`.`Size`
                        ORDER BY `a`.`SO`,`b`.`Color` DESC;
                        ";
            }
            else if (cbbDepartment.SelectedIndex == 2)
            {
                txtSql = "";
            }
            else if (cbbDepartment.SelectedIndex == 3)
            {
                txtSql = @"SELECT `a`.`SO`,MIN(DATE(`sb_scantime`)) AS FirstDate ,Max(DATE(`sb_scantime`)) AS LastDate ,`b`.`Color`, `a`.`sb_size` AS `Size`, SUM(`a`.`sb_qty`)AS `QTY` 
                        FROM `b_scaned_bundle` AS `a` 
                        JOIN `a_a1_spreading_list_tb` AS `b` ON `b`.`SD_ListDoc_No`=`a`.`sb_sdlistdocno` AND b.`FabricType` LIKE 'A' AND `b`.`SD_Status` LIKE '1' 
                        WHERE  `a`.`So`IN " + SearchIn + @"
                        GROUP BY`a`.`SO`,`b`.`Color`,`a`.`sb_size`
                        ORDER BY `a`.`SO`,`b`.`Color`;
                        ";
            }
            else if (cbbDepartment.SelectedIndex == 4)
            {
                txtSql = "SELECT  `fgscanin_so` AS `SO`,`fgscanin_style` AS `Style` ,MIN(DATE(`fgscanin_time`)) AS FirstDate ,Max(DATE(`fgscanin_time`)) AS LastDate ,`fgscanin_color` AS `Color`, " +
                    "`fgscanin_size`AS `Size`, SUM(`fgscanin_qty`)AS `QTY` FROM `b_fgscanin` " +
                    "WHERE `fgscanin_so` IN " + SearchIn + @"
                    GROUP BY `fgscanin_color`,`fgscanin_size`";
            }
            if (txtSql != "")
            {
                gvDis.DataSource = null;
                ConnectMySQL.DisplayAndSearch(txtSql, gvDis);
            }

        }

        private void btExportToExcel_Click(object sender, EventArgs e)
        {
            if (gvDis.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                xcelApp.Application.Workbooks.Add(Type.Missing);

                for (int i = 0; i < gvDis.Columns.Count; i++)
                {
                    xcelApp.Cells[1, i + 1] = gvDis.Columns[i].HeaderText;

                }
                for (int i = 0; i < gvDis.Rows.Count; i++)
                {
                    for (int j = 0; j < gvDis.Columns.Count; j++)
                    {
                        if (gvDis.Rows[i].Cells[j].Value != null)
                        {

                            xcelApp.Cells[i + 2, j + 1] = gvDis.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }
                xcelApp.Columns.AutoFit();
                xcelApp.Visible = true;
            }
        }

        private void SoReportByDecoration_Load(object sender, EventArgs e)
        {

        }
    }
}
