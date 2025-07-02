using PTS_For_Cut.Myclass;

namespace PTS_For_Cut._9Report
{
    public partial class SoBundleReport : Form
    {

        public SoBundleReport()
        {
            InitializeComponent();

        }
        string search2Mode(string txt)
        {
            string query = "";
            if (txt == "startScan")
            {
                query = @"
                                           SELECT 
                                             `a`.`SD_ListDoc_No`, 
                                             `a`.`SO`,  
                                             `c`.`Color`,
                                             `a`.`QRCodeBundle`, 
                                             `a`.`BundleNo`, 
                                             `h`.`sb_lineno` AS `Line`,
                                             `a`.`Size`,
                                             `a`.`QTY` AS `Cutting Output`,
                                             SUM(IFNULL(`h`.`sb_qty`, 0)) AS `Sewing Output`, 
                                             `h`.`sb_scantime` AS `Scantime`
                                             FROM 
                                              `a_b1_bundle_tb` AS `a`
                                        INNER JOIN 
                                            `b_scaned_bundle` AS `h` ON `a`.`QRCodeBundle` = `h`.`sb_qrcodebundle`
                                        INNER JOIN `a_a1_spreading_list_tb` AS `c` ON `a`.`SD_ListDoc_No` = `c`.`SD_ListDoc_No`
                                        WHERE 
                                             `a`.`MainPart` = 1 
                                             AND `a`.`FabricType` LIKE 'A'
                                             AND `c`.`SD_Status` LIKE '1'
                                             AND `a`.`SO` LIKE '" + tbSO.Text + @"'                                       
                                        GROUP BY 
                                            `a`.QRCodeBundle,  
                                            `a`.SO
                                       HAVING 
                                        (a.QTY - SUM(h.sb_qty)) > 0;";
            }
            else if (txt == "notStart")
            {
                query = @"
                            SELECT 
                                `a`.`SD_ListDoc_No`, 
                                `a`.`SO`,  
                                `c`.`Color`,
                                `a`.`QRCodeBundle`, 
                                `a`.`BundleNo`, 
                                `a`.`Size`,
                                `a`.`QTY` AS `Cutting Output`,
                                 0 AS `Sewing Output`  
                            FROM 
                                `a_b1_bundle_tb` AS `a`
                            INNER JOIN `a_a1_spreading_list_tb` AS `c` ON `a`.`SD_ListDoc_No` = `c`.`SD_ListDoc_No`
                            WHERE 
                                `a`.`MainPart` = 1 
                                AND `a`.`FabricType` LIKE 'A'
                                AND `c`.`SD_Status` LIKE '1'
                                AND `a`.`SO`LIKE '" + tbSO.Text + @"'    
                                AND NOT EXISTS (
                                    SELECT 1 
                                    FROM `b_scaned_bundle` AS `h2`
                                    WHERE `h2`.`sb_qrcodebundle` = `a`.`QRCodeBundle`
                                )
                            GROUP BY 
                                `a`.`QRCodeBundle`,  
                                `a`.`SO`  
                            ORDER BY `a`.`QRCodeBundle` ASC;";
            }
            return query;
        }

        private void SoBundleReport_Load(object sender, EventArgs e)
        {
            // lbSO.Text = "SO : " + SoReport.ins.so_No;

            cbbStatusScan.SelectedIndex = 0;


        }

        private void btExcel_Click(object sender, EventArgs e)
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

        private void cbbStatusScan_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            if (cbbStatusScan.SelectedIndex == 0)
            {
                string query = search2Mode("startScan");
                ConnectMySQL.DisplayAndSearch(query, gvDis);
            }
            else if (cbbStatusScan.SelectedIndex == 1)
            {
                string query = search2Mode("notStart");
                ConnectMySQL.DisplayAndSearch(query, gvDis);
            }
            if (tbSO.Text.Length > 0)
            {

                if (gvDis.Rows.Count > 0)
                {
                    lbBundleQTY.Text = "Bundle QTY : " + gvDis.Rows.Count.ToString() + " Piece.     ";
                    int cut = 0, sew = 0;

                    for (int i = 0; i < gvDis.Rows.Count; i++)
                    {
                        int c = 0, s = 0;
                        if (gvDis.Rows[i].Cells["Cutting Output"].Value.ToString() != "")
                        {
                            c = int.Parse(gvDis.Rows[i].Cells["Cutting Output"].Value.ToString());
                            cut += c;
                        }

                        if (gvDis.Rows[i].Cells["Sewing Output"].Value.ToString() != "")
                        {
                            s = int.Parse(gvDis.Rows[i].Cells["Sewing Output"].Value.ToString());
                            sew += s;
                        }

                        if (c > s)

                        {
                            gvDis.Rows[i].Cells["Sewing Output"].Style.BackColor = Color.Red;
                        }
                    }
                    //lbCutQTY.Text = "Total Cutting Output : " + cut.ToString() + "     ";
                    //lbSewQTY.Text = "Total Sewing Output : " + sew.ToString() + "     ";
                }
            }
        }
    }
}
