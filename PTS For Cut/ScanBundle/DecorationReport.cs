using Guna.UI2.WinForms;
using PTS_For_Cut.Main;
using PTS_For_Cut.Myclass;
using System.Data;
using DataTable = System.Data.DataTable;

namespace PTS_For_Cut.ScanBundle
{
    public partial class DecorationReport : Form
    {
        public DecorationReport()
        {
            InitializeComponent();
        }
        private int currentPage = 1;
        private int pageSize = 20;
        private int totalRecords = 0;
        private int totalPages = 0;

        private void btSearch_Click(object sender, EventArgs e)
        {
            LoadData(tbSO.Text);
        }
        private string setDate(Guna2DateTimePicker dtpDate)
        {
            string txtDate = "";
            System.Globalization.CultureInfo _cultureEnInfo = new System.Globalization.CultureInfo("en-US");
            DateTime date = Convert.ToDateTime(dtpDate.Value, _cultureEnInfo);
            txtDate = date.ToString("yyyy-MM-dd", _cultureEnInfo);
            return txtDate;
        }
        private void LoadData(string so)
        {
            if (cbbDec1.SelectedIndex > -1)
            {
                string txtDateFrom = setDate(dtpFrom);
                string txtDateTo = setDate(dtpTo);

                string txtColumnInQuery = "";
                string txtgroupBy = "";
                if (cbbGroupBy1.SelectedIndex == 0)
                {
                    txtColumnInQuery = @"`s`.`SO`,
                                              SUM(`b`.`QTY`) AS `QTY`
";
                    txtgroupBy = @"GROUP BY `s`.`SO` ;";
                }
                else if (cbbGroupBy1.SelectedIndex == 1)
                {
                    txtColumnInQuery = @"`a`.`QRCodeBundle`, 
                                            `a`.`SD_ListDoc_No`,
                                            `s`.`SO`, 
                                            `a`.`BundleNo`, 
                                            `s`.`Color`, 
                                            `a`.`Size`,
                                            `a`.`ClothingPart`,
                                            `b`.`Decoration`,
                                            `b`.`Dec_Out`, 
                                            `b`.`QTY`,                                                                                          
                                            `b`.`Location`, 
                                            `b`.`TimeScan`, 
                                            CASE
                                                WHEN `b`.`stINOUT` = 1 THEN 'Scan In'
                                                WHEN `b`.`stINOUT` = 0 THEN 'Scan Out'
                                                ELSE 'Unknown'
                                            END AS `stINOUT`";
                }

                if (cbbType.SelectedIndex == 0)
                {
                    string line = "";
                    string dec = "";
                    string CheckMain = "";
                    string ConditionSelect = "";
                    string ShowMorethanZero = "`a`.`QTY_Balance` > 0";
                    if (cbbDec1.Text == "SMK")
                    {
                        line = " AND `Location` LIKE '%" + cbbLine.Text + "%'";
                        dec = "AND `b`.`Dec_Out` LIKE 'Sewing'";
                        CheckMain = "AND `MainPart` =1 ";
                        ConditionSelect = CheckMain;
                    }
                    else
                    {
                        ConditionSelect = " AND `Deco` LIKE '%" + cbbDec1.Text + "%' ";
                    }
                    if (tbSO.Text.Length > 8)
                    {
                        ShowMorethanZero = "1";
                    }

                    string query = @"WITH LatestScans AS (
                                            SELECT 
                                                `b`.`QrcodeBD`,
                                                `b`.`stINOUT`,
                                                `b`.`Location`,
                                                MAX(`b`.`TimeScan`) AS `LatestScanTime`
                                            FROM 
                                                `a_b1_bundle_to_dec_tb` `b`
                                            WHERE 
                                            `b`.`Decoration` LIKE '" + cbbDec1.Text + "' AND DATE(`b`.`TimeScan`) <= '" + txtDateFrom + @"' " + CheckMain + @"
                                             
                                            GROUP BY 
                                                `b`.`QrcodeBD`, 
                                                `b`.`stINOUT`
                                        ),
                                        ScansWithDetails AS (
                                            SELECT  
                                                `s`.`SO`,   
                                                `b`.`TimeScan`,
                                                `b`.`QTY` AS `Scan_QTY`,
                                                `b`.`stINOUT`,
    	                                        `b`.`Location`,
    	                                        `b`.`Dec_Out`
                                            FROM 
                                                `a_b1_bundle_to_dec_tb` `b`
                                            JOIN 
                                                `a_b1_bundle_tb` `a` ON `a`.`QRCodeBundle` = `b`.`QrcodeBD`
                                            JOIN 
                                                `a_a1_spreading_list_tb` `s` ON `a`.`SD_ListDoc_No` = `s`.`SD_ListDoc_No`
                                            JOIN 
                                                LatestScans `ls` 
                                                ON `b`.`QrcodeBD` = `ls`.`QrcodeBD` 
                                                AND `b`.`stINOUT` = `ls`.`stINOUT` 
                                                AND `b`.`TimeScan` = `ls`.`LatestScanTime`
                                            WHERE 
                                                `s`.`FabricType` LIKE 'A'
                                                AND `s`.`SO` LIKE '%" + tbSO.Text + @"%'
                                                AND `b`.`Decoration` LIKE '" + cbbDec1.Text + @"'
                                                AND DATE(`b`.`TimeScan`) <= '" + txtDateFrom + @"' -- Adjust your date range here	
                                        ),
                                        OriginalData AS (
                                            SELECT
                                                `s`.`SO`,
                                                COUNT(DISTINCT `a`.`QRCodeBundle`) AS `Bundle_Cutting`,
                                                SUM(`a`.`QTY`) AS `QTY_Cutting`
                                            FROM
                                                `a_b1_bundle_tb` `a`
                                            JOIN
                                                `a_a1_spreading_list_tb` `s` ON `a`.`SD_ListDoc_No` = `s`.`SD_ListDoc_No`
 
                                            WHERE
                                                `s`.`FabricType` LIKE 'A'
                                                AND `s`.`SO` LIKE '%" + tbSO.Text + @"%' " + ConditionSelect + @"
                                            GROUP BY 
                                                `s`.`SO`
                                        ),
                                        AggregatedData AS (
                                            SELECT
                                                `b`.`SO`,
                                                SUM(CASE WHEN `stINOUT` = 1" + line + @" THEN 1 ELSE 0 END) AS `Bundle_In`,
                                                SUM(CASE WHEN `stINOUT` = 1 " + line + @" THEN `Scan_QTY` ELSE 0 END) AS `QTY_In`,
                                                SUM(CASE WHEN `stINOUT` = 0 " + line + dec + @" THEN 1 ELSE 0 END) AS `Bundle_Out`,
                                                SUM(CASE WHEN `stINOUT` = 0 " + line + dec + @" THEN `Scan_QTY` ELSE 0 END) AS `QTY_Out`,
                                              SUM(CASE WHEN `stINOUT` = 1 " + line + @" THEN 1 ELSE 0 END) 
                                            - SUM(CASE WHEN `stINOUT` = 0 " + line + dec + @"  THEN 1 ELSE 0 END) AS `Bundle_Balance`,
                                              SUM(CASE WHEN `stINOUT` = 1 " + line + @" THEN `Scan_QTY` ELSE 0 END) 
                                            - SUM(CASE WHEN `stINOUT` = 0 " + line + dec + @"  THEN `Scan_QTY` ELSE 0 END) AS `QTY_Balance`
                                            FROM
                                                ScansWithDetails `b`
                                            GROUP BY 
                                                `b`.`SO`
                                        )
                                        SELECT
                                            `a`.`SO`,
                                            `o`.`Bundle_Cutting`,
                                            `o`.`QTY_Cutting`,
                                            `a`.`Bundle_In`,
                                            `a`.`QTY_In`,
                                            `a`.`Bundle_Out`,
                                            `a`.`QTY_Out`,
                                            `a`.`Bundle_Balance`,
                                            `a`.`QTY_Balance`
                                        FROM
                                            AggregatedData `a`
                                        JOIN
                                            OriginalData `o` ON `a`.`SO` = `o`.`SO`
                                        WHERE
                                            " + ShowMorethanZero + @"
                                        ORDER BY
                                            `a`.`SO`;";

                    HomePage.ins.txtQuery(query);
                    ConnectMySQL.DisplayAndSearch(query, gvDis);
                    UpdatePaginationControls();

                }
                else
                if (cbbType.SelectedIndex == 1) //Scan In
                {
                    string useDateChecked = "";
                    if (cbUseDate.Checked)
                    {
                        useDateChecked = "AND DATE(`b`.`TimeScan`) BETWEEN '" + txtDateFrom + "' AND '" + txtDateTo + "' ";
                    }
                    gvDis.DataSource = null;

                    string query = @"WITH LatestScans AS (
                                SELECT 
                                    `b`.`QrcodeBD`,
                                    `b`.`stINOUT`,
                                    MAX(`b`.`TimeScan`) AS `LatestScanTime`
                                FROM 
                                    `a_b1_bundle_to_dec_tb` `b`
                                WHERE `b`.`stINOUT` ='1'  AND `b`.`Decoration` LIKE '" + cbbDec1.Text + "'" + useDateChecked +
                           @" GROUP BY 
                                    `b`.`QrcodeBD`)
                                SELECT  " +
                                          txtColumnInQuery +
                                   @" FROM 
                                            `a_b1_bundle_to_dec_tb` `b`
                                        JOIN 
                                            `a_b1_bundle_tb` `a` ON `a`.`QRCodeBundle` = `b`.`QrcodeBD`
                                        JOIN 
                                            `a_a1_spreading_list_tb` `s` ON `a`.`SD_ListDoc_No` = `s`.`SD_ListDoc_No`
                                        JOIN 
                                            LatestScans `ls` 
                                            ON `b`.`QrcodeBD` = `ls`.`QrcodeBD`
                                            AND `b`.`stINOUT` = `ls`.`stINOUT` 
                                            AND `b`.`TimeScan` = `ls`.`LatestScanTime` 
                                            
                                        WHERE 
                                            `s`.`FabricType` LIKE 'A' AND `b`.`stINOUT`=1
                                            AND `s`.`SO` LIKE '%" + so + "%'" + useDateChecked +

                                        "AND `b`.`Decoration` LIKE '" + cbbDec1.Text + "' " + txtgroupBy;
                    HomePage.ins.txtQuery(query);
                    ConnectMySQL.DisplayAndSearch(query, gvDis);

                }
                else if (cbbType.SelectedIndex == 2) //Scan Out
                {
                    string for_SMK = "";
                    if (cbbDec1.Text == "SMK")
                    {
                        for_SMK = "`a`.`MainPart`=1 AND `b`.`Dec_Out` ='Sewing' AND `s`.`FabricType` LIKE 'A' AND ";
                    }

                    string useDateChecked = "";
                    if (cbUseDate.Checked)
                    {
                        useDateChecked = "AND DATE(`TimeScan`) BETWEEN '" + txtDateFrom + "' AND '" + txtDateTo + "'";
                    }

                    gvDis.DataSource = null;
                    string query = @"WITH LatestScanOut AS (
                        SELECT 
                            `QrcodeBD`, 
                           `stINOUT`,
                            MAX(`TimeScan`) AS LatestTimeScan
                        FROM 
                            `a_b1_bundle_to_dec_tb`
                        WHERE 
                            `stINOUT` = '0' " + useDateChecked + "  AND `Decoration` LIKE '" + cbbDec1.Text + @"'
                        GROUP BY 
                            `QrcodeBD`
                    )
                                SELECT  
                                           " +
                                              txtColumnInQuery +
                                       @" FROM 
                                            `a_b1_bundle_to_dec_tb` `b`
                                        JOIN 
                                            `a_b1_bundle_tb` `a` ON `a`.`QRCodeBundle` = `b`.`QrcodeBD`
                                        JOIN 
                                            `a_a1_spreading_list_tb` `s` ON `a`.`SD_ListDoc_No` = `s`.`SD_ListDoc_No`
                                        JOIN 
                                            LatestScanOut `ls` 
                                            ON `b`.`QrcodeBD` = `ls`.`QrcodeBD`
                                            AND `b`.`stINOUT` = `ls`.`stINOUT` 
                                            AND `b`.`TimeScan` = `ls`.`LatestTimeScan`                                             
                                        WHERE   
                                                " + for_SMK + @"                
                                             `s`.`SO` LIKE '%" + so + "%'" +
                                            "AND `b`.`stINOUT` = 0 " + useDateChecked + "  AND `b`.`Decoration` LIKE '" + cbbDec1.Text + "'" + txtgroupBy;

                    HomePage.ins.txtQuery(query);
                    ConnectMySQL.DisplayAndSearch(query, gvDis);

                }
                else if (cbbType.SelectedIndex == 3) //Scan inTx
                {
                    string useDateChecked = "";
                    if (cbUseDate.Checked)
                    {
                        useDateChecked = "AND DATE(`b`.`TimeScan`) BETWEEN '" + txtDateFrom + "' AND '" + txtDateTo + "'";
                    }

                    gvDis.DataSource = null;
                    string query = @"
                                        SELECT 
                                            `a`.`QRCodeBundle`, 
                                            `a`.`SD_ListDoc_No`,
                                            `s`.`SO`, 
                                            `a`.`BundleNo`, 
                                            `s`.`Color`, 
                                            `a`.`Size`,
                                            `a`.`ClothingPart`,
                                            `b`.`Decoration`,
                                            `a`.`QTY`,                                                                                          
                                            `b`.`Location`, 
                                            `b`.`TimeScan`, 
                                            CASE
                                                WHEN `b`.`stINOUT` = 1 THEN 'Scan In'
                                                WHEN `b`.`stINOUT` = 0 THEN 'Scan Out'
                                                ELSE 'Unknown'
                                            END AS `stINOUT` 
                                        FROM 
                                            `a_b1_bundle_tb` `a`
                                        JOIN 
                                            `a_b1_bundle_to_dec_tb` `b` 
                                        ON 
                                            `a`.`QRCodeBundle` = `b`.`QrcodeBD`
                                        JOIN 
                                            `a_a1_spreading_list_tb` `s` 
                                        ON 
                                            `a`.`SD_ListDoc_No` = `s`.`SD_ListDoc_No` AND `s`.`FabricType` LIKE 'A'
                                        WHERE 
                                            `b`.`stINOUT` = '1'
                                            AND `s`.`SO` LIKE '%" + so + "%'" +
                                            "AND `b`.`Decoration` = '" + cbbDec1.Text + "'" + useDateChecked +
                                        "ORDER BY " +
                                            "`b`.`TimeScan`;";
                    HomePage.ins.txtQuery(query);
                    ConnectMySQL.DisplayAndSearch(query, gvDis);

                }
                else if (cbbType.SelectedIndex == 4) //Scan Out Tx
                {
                    string useDateChecked = "";
                    if (cbUseDate.Checked)
                    {
                        useDateChecked = "AND DATE(`b`.`TimeScan`) BETWEEN '" + txtDateFrom + "' AND '" + txtDateTo + "'";
                    }
                    gvDis.DataSource = null;
                    string query = @"
                                        SELECT 
                                            `a`.`QRCodeBundle`, 
                                            `a`.`SD_ListDoc_No`,
                                            `s`.`SO`, 
                                            `a`.`BundleNo`, 
                                            `s`.`Color`, 
                                            `a`.`Size`,
                                            `a`.`ClothingPart`,
                                            `b`.`Decoration`,
                                            `b`.`Dec_Out`,
                                            `a`.`QTY`,                                                                                          
                                            `b`.`Location`, 
                                            `b`.`TimeScan`, 
                                            CASE
                                                WHEN `b`.`stINOUT` = 1 THEN 'Scan In'
                                                WHEN `b`.`stINOUT` = 0 THEN 'Scan Out'
                                                ELSE 'Unknown'
                                            END AS `stINOUT` 
                                        FROM 
                                            `a_b1_bundle_tb` `a`
                                        JOIN 
                                            `a_b1_bundle_to_dec_tb` `b` 
                                        ON 
                                            `a`.`QRCodeBundle` = `b`.`QrcodeBD`
                                        JOIN 
                                            `a_a1_spreading_list_tb` `s` 
                                        ON 
                                            `a`.`SD_ListDoc_No` = `s`.`SD_ListDoc_No` AND `s`.`FabricType` LIKE 'A'
                                        WHERE 
                                            `b`.`stINOUT` = '0'
                                            AND `s`.`SO` LIKE '%" + so + "%'" +
                                            "AND `b`.`Decoration` = '" + cbbDec1.Text + "'" + useDateChecked +
                                        "ORDER BY " +
                                            "`b`.`TimeScan`;";
                    ConnectMySQL.DisplayAndSearch(query, gvDis);

                }
                //else if (cbbType.SelectedIndex == 5)
                //{

                //}
            }
            else
            {
                MessageBox.Show("!!!!! Please Select Decoration !!!!!");
            }
        }
        private void UpdatePaginationControls()
        {
            btnPrevious.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPages;
            lblPageNumber.Text = $"Page {currentPage} of {totalPages}";
        }
        private void DecorationReport_Load(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = (int)(this.ClientSize.Width * 0.3);
            dtpFrom.Value = DateTime.Now;
            dtpTo.Value = DateTime.Now;
            // cbbType.SelectedIndex = 0;
            cbbGroupBy1.SelectedIndex = 0;
            cbbDec1.Items.Clear();
            for (int i = 0; i < Login.ins.dtDecoration.Rows.Count; i++)
            {
                cbbDec1.Items.Add(Login.ins.dtDecoration.Rows[i]["Dec_Eng"].ToString());
            }

            DataTable dt = new DataTable();
            dt = Login.ins.Line_dt;
            cbbLine.Items.Clear();
            cbbLine.Items.Add("");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["Department"].ToString() == "Sewing")
                {
                    cbbLine.Items.Add(dt.Rows[i]["Line"].ToString());
                }
            }
        }

        private void cbbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbType.SelectedIndex > -1)
            {

                if (cbbDec1.Text == "SMK")
                {
                    cbbLine.Visible = true;
                    cbUseDate.Checked = true;
                }
                else
                {
                    cbbLine.Visible = false;
                }



            }
            if (cbbType.SelectedIndex == 0)
            {
                dtpFrom.Visible = true;
                dtpTo.Visible = false;
                // cbUseDate.Visible = false;
                lbTo.Visible = false;
                tsLeft.Visible = false;
                tsRigth.Visible = true;
                btExcel.Visible = true;
                splitContainer1.SplitterDistance = 100;
                splitContainer1.SplitterDistance = (int)(this.ClientSize.Width * 0.3);
            }
            else
            if (cbbType.SelectedIndex == 1)
            {

                cbUseDate.Visible = true;
                lbTo.Visible = true;
                tsLeft.Visible = true;
                tsRigth.Visible = false;
                btExcel.Visible = true;
                splitContainer1.SplitterDistance = this.ClientSize.Width / 2;
            }
            else if (cbbType.SelectedIndex == 2)
            {
                cbUseDate.Visible = true;
                lbTo.Visible = true;
                tsLeft.Visible = true;
                tsRigth.Visible = false;
                btExcel.Visible = true;
                splitContainer1.SplitterDistance = this.ClientSize.Width / 2;
            }
            else if (cbbType.SelectedIndex == 3)
            {
                cbUseDate.Visible = true;
                lbTo.Visible = true;
                tsLeft.Visible = true;
                tsRigth.Visible = false;
                btExcel.Visible = true;
                splitContainer1.SplitterDistance = this.ClientSize.Width / 2;
            }
            else if (cbbType.SelectedIndex == 4)
            {
                cbUseDate.Visible = true;
                lbTo.Visible = true;
                tsLeft.Visible = true;
                tsRigth.Visible = false;
                btExcel.Visible = true;
                splitContainer1.SplitterDistance = this.ClientSize.Width / 2;
            }
            //else if (cbbType.SelectedIndex == 5)
            //{
            //    dtpFrom.Visible = false;
            //    dtpTo.Visible = false;
            //    cbUseDate.Visible = false;
            //    lbTo.Visible = false;
            //    tsLeft.Visible = false;
            //    tsRigth.Visible = true;
            //    btExcel.Visible = true;
            //    splitContainer1.SplitterDistance = this.ClientSize.Width / 2;
            //}
        }

        private void tbSO_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadData(tbSO.Text);
            }
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            if (gvDis.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                xcelApp.Application.Workbooks.Add(Type.Missing);

                for (int i = 1; i < gvDis.Columns.Count + 1; i++)
                {
                    xcelApp.Cells[1, i] = gvDis.Columns[i - 1].HeaderText;

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

        private void btExcel2_Click(object sender, EventArgs e)
        {
            if (gvDisDetail.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                xcelApp.Application.Workbooks.Add(Type.Missing);

                for (int i = 0; i < gvDisDetail.Columns.Count; i++)
                {
                    xcelApp.Cells[1, i + 1] = gvDisDetail.Columns[i].HeaderText;

                }
                for (int i = 0; i < gvDisDetail.Rows.Count; i++)
                {
                    for (int j = 0; j < gvDisDetail.Columns.Count; j++)
                    {
                        if (gvDisDetail.Rows[i].Cells[j].Value != null)
                        {

                            xcelApp.Cells[i + 2, j + 1] = gvDisDetail.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }
                xcelApp.Columns.AutoFit();
                xcelApp.Visible = true;
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadData(tbSO.Text);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadData(tbSO.Text);
            }
        }
        int columnIndex = -1;
        int rowIndex = -1;
        string so_no = "";
        private void gvDis_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                so_no = gvDis.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void gvDis_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                if (e.ColumnIndex == 2 || e.ColumnIndex == 4 || e.ColumnIndex == 6 || e.ColumnIndex == 8)
                {
                    rowIndex = e.RowIndex;
                    columnIndex = e.ColumnIndex;
                    so_no = gvDis.Rows[e.RowIndex].Cells[0].Value.ToString();
                    lbSO.Text = so_no;
                    lbDec.Text = cbbDec1.Text;
                    lbPartOf.Text = gvDis.Columns[columnIndex].HeaderText;

                    searchDetail();
                }
            }
        }
        private void searchDetail()
        {
            if (rowIndex > -1 && columnIndex > -1)
            {
                string columnName = gvDis.Columns[columnIndex].HeaderText;
                DataTable dt = new DataTable();
                string query = "";
                if (columnName == "QTY_Cutting")
                {
                    query = @"SELECT `b`.`Color`, `a`.`Size`, SUM(`a`.`QTY`)AS `QTY` 
                                        FROM `a_b1_bundle_tb` AS `a` 
                                        JOIN `a_a1_spreading_list_tb` AS `b` ON `b`.`SD_ListDoc_No`=`a`.`SD_ListDoc_No` AND b.`FabricType` LIKE 'A' AND b.`SD_Status` LIKE '1' AND `b`.`SO`= '" + so_no + "' " + @"
                                       
                                        WHERE `a`.`MainPart` = '1'
                                        GROUP BY `b`.`Color`,`a`.`Size`; ";
                }
                else if (columnName == "QTY_In")
                {
                    query = @"WITH LatestScans AS (
                                                SELECT 
                                                    `b`.`QrcodeBD`,
                                                    `b`.`stINOUT`,
                                                    MAX(`b`.`TimeScan`) AS `LatestScanTime`
                                                FROM 
                                                    `a_b1_bundle_to_dec_tb` `b`
                                                WHERE `b`.`stINOUT` ='1' AND `b`.`Decoration` LIKE '" + cbbDec1.Text + @"'
                                          GROUP BY 
                                                    `b`.`QrcodeBD`, 
                                                    `b`.`stINOUT`)
                                                SELECT  
                                                  `s`.`Color`,
                                                  `a`.`Size`,
                                                  SUM(`a`.`QTY`) AS `QTY`   
                                                    FROM 
                                                            `a_b1_bundle_to_dec_tb` `b`
                                                        JOIN 
                                                            `a_b1_bundle_tb` `a` ON `a`.`QRCodeBundle` = `b`.`QrcodeBD`
                                                        JOIN 
                                                            `a_a1_spreading_list_tb` `s` ON `a`.`SD_ListDoc_No` = `s`.`SD_ListDoc_No`
                                                        JOIN 
                                                            LatestScans `ls` 
                                                            ON `b`.`QrcodeBD` = `ls`.`QrcodeBD`
                                                            AND `b`.`stINOUT` = `ls`.`stINOUT` 
                                                            AND `b`.`TimeScan` = `ls`.`LatestScanTime`                        
                                                        WHERE 
                                                            `s`.`FabricType` LIKE 'A'
                                                            AND `s`.`SO` LIKE '" + so_no + "' " + @"
                                                        AND `b`.`Decoration` LIKE '" + cbbDec1.Text + "' " + @"
                                                        GROUP BY `s`.`Color`,`a`.`Size` 
                                                        ORDER BY `s`.`Color`;";
                }
                else if (columnName == "QTY_Out")
                {
                    query = @"WITH LatestScans AS (
                                                SELECT 
                                                    `b`.`QrcodeBD`,
                                                    `b`.`stINOUT`,
                                                    MAX(`b`.`TimeScan`) AS `LatestScanTime`
                                                FROM 
                                                    `a_b1_bundle_to_dec_tb` `b`
                                                WHERE `b`.`stINOUT` ='0' AND `b`.`Decoration` LIKE '" + cbbDec1.Text + @"'
                                          GROUP BY 
                                                    `b`.`QrcodeBD`, 
                                                    `b`.`stINOUT`)
                                                SELECT  
                                                  `s`.`Color`,
                                                  `a`.`Size`,
                                                  SUM(`a`.`QTY`) AS `QTY`   
                                                    FROM 
                                                            `a_b1_bundle_to_dec_tb` `b`
                                                        JOIN 
                                                            `a_b1_bundle_tb` `a` ON `a`.`QRCodeBundle` = `b`.`QrcodeBD`
                                                        JOIN 
                                                            `a_a1_spreading_list_tb` `s` ON `a`.`SD_ListDoc_No` = `s`.`SD_ListDoc_No`
                                                        JOIN 
                                                            LatestScans `ls` 
                                                            ON `b`.`QrcodeBD` = `ls`.`QrcodeBD`
                                                            AND `b`.`stINOUT` = `ls`.`stINOUT` 
                                                            AND `b`.`TimeScan` = `ls`.`LatestScanTime`                        
                                                        WHERE 
                                                            `s`.`FabricType` LIKE 'A'
                                                            AND `s`.`SO` LIKE '" + so_no + "' " + @"
                                                        AND `b`.`Decoration` LIKE '" + cbbDec1.Text + "' " + @"
                                                        GROUP BY `s`.`Color`,`a`.`Size` 
                                                        ORDER BY `s`.`Color`;";
                }
                else if (columnName == "QTY_Balance")
                {
                    query = @"WITH LatestScansIn AS (
                                SELECT 
                                    `b`.`QrcodeBD`,
                                    `b`.`stINOUT`,
                                    MAX(`b`.`TimeScan`) AS `LatestScanTime`
                                FROM 
                                    `a_b1_bundle_to_dec_tb` `b`
                                WHERE 
                                    `b`.`stINOUT` = '1' 
                                    AND `b`.`Decoration` LIKE '" + cbbDec1.Text + @"'
                                GROUP BY 
                                    `b`.`QrcodeBD`, 
                                    `b`.`stINOUT`
                            ),
                            ScannedIn AS (
                                SELECT  
                                    `s`.`Color`,
                                    `a`.`Size`,
                                    SUM(`a`.`QTY`) AS `QtyIn`
                                FROM 
                                    `a_b1_bundle_to_dec_tb` `b`
                                    JOIN `a_b1_bundle_tb` `a` ON `a`.`QRCodeBundle` = `b`.`QrcodeBD`
                                    JOIN `a_a1_spreading_list_tb` `s` ON `a`.`SD_ListDoc_No` = `s`.`SD_ListDoc_No`
                                    JOIN LatestScansIn `ls` ON 
                                        `b`.`QrcodeBD` = `ls`.`QrcodeBD`
                                        AND `b`.`stINOUT` = `ls`.`stINOUT`
                                        AND `b`.`TimeScan` = `ls`.`LatestScanTime`
                                WHERE 
                                    `s`.`FabricType` LIKE 'A'
                                    AND `s`.`SO` LIKE '" + so_no + "' "
                                    + @" AND `b`.`Decoration` LIKE '" + cbbDec1.Text + @"'
                                GROUP BY `s`.`Color`, `a`.`Size`
                            ),
                            LatestScansOut AS (
                                SELECT 
                                    `b`.`QrcodeBD`,
                                    `b`.`stINOUT`,
                                    MAX(`b`.`TimeScan`) AS `LatestScanTime`
                                FROM 
                                    `a_b1_bundle_to_dec_tb` `b`
                                WHERE 
                                    `b`.`stINOUT` = '0' 
                                    AND `b`.`Decoration` LIKE '" + cbbDec1.Text + @"'
                                GROUP BY 
                                    `b`.`QrcodeBD`, 
                                    `b`.`stINOUT`
                            ),
                            ScannedOut AS (
                                SELECT  
                                    `s`.`Color`,
                                    `a`.`Size`,
                                    SUM(`a`.`QTY`) AS `QtyOut`
                                FROM 
                                    `a_b1_bundle_to_dec_tb` `b`
                                    JOIN `a_b1_bundle_tb` `a` ON `a`.`QRCodeBundle` = `b`.`QrcodeBD`
                                    JOIN `a_a1_spreading_list_tb` `s` ON `a`.`SD_ListDoc_No` = `s`.`SD_ListDoc_No`
                                    JOIN LatestScansOut `ls` ON 
                                        `b`.`QrcodeBD` = `ls`.`QrcodeBD`
                                        AND `b`.`stINOUT` = `ls`.`stINOUT`
                                        AND `b`.`TimeScan` = `ls`.`LatestScanTime`
                                WHERE 
                                    `s`.`FabricType` LIKE 'A'
                                    AND `s`.`SO` LIKE '" + so_no + "' "
                                    + @" AND `b`.`Decoration` LIKE '" + cbbDec1.Text + @"'
                                GROUP BY `s`.`Color`, `a`.`Size`
                            )
                            SELECT 
                                COALESCE(InData.`Color`, OutData.`Color`) AS `Color`,
                                COALESCE(InData.`Size`, OutData.`Size`) AS `Size`,
                                COALESCE(InData.`QtyIn`, 0) AS `QtyIn`,
                                COALESCE(OutData.`QtyOut`, 0) AS `QtyOut`,
                                COALESCE(InData.`QtyIn`, 0) - COALESCE(OutData.`QtyOut`, 0) AS `QTY`
                            FROM 
                                (ScannedIn InData
                                LEFT JOIN ScannedOut OutData 
                                    ON InData.`Color` = OutData.`Color` 
                                    AND InData.`Size` = OutData.`Size`)
                            UNION ALL
                            SELECT 
                                COALESCE(InData.`Color`, OutData.`Color`) AS `Color`,
                                COALESCE(InData.`Size`, OutData.`Size`) AS `Size`,
                                COALESCE(InData.`QtyIn`, 0) AS `QtyIn`,
                                COALESCE(OutData.`QtyOut`, 0) AS `QtyOut`,
                                COALESCE(InData.`QtyIn`, 0) - COALESCE(OutData.`QtyOut`, 0) AS `QTY`
                            FROM 
                                (ScannedOut OutData
                                LEFT JOIN ScannedIn InData 
                                    ON OutData.`Color` = InData.`Color` 
                                    AND OutData.`Size` = InData.`Size`)
                            ORDER BY 
                                `Color`, `Size`;
                            ";

                }
                if (query != "")
                {
                    Detail_TB(query);
                }

            }
        }
        DataTable sizeRef = new DataTable();
        private void Detail_TB(string txtQuery)
        {
            DataTable dt_Query = new DataTable();
            dt_Query = ConnectMySQL.MySQLtoDataTable(txtQuery);

            gvDisDetail.DataSource = new DataTable();
            if (dt_Query.Rows.Count > 0)
            {
                bool chNumref = false;
                for (int i = 0; i < dt_Query.Columns.Count; i++)
                {
                    if (dt_Query.Columns[i].ColumnName == "NumRef")
                    {
                        chNumref = true;
                    }
                }
                if (!chNumref)
                {
                    dt_Query.Columns.Add("NumRef", typeof(System.Int32));
                }

                for (int i = 0; i < dt_Query.Rows.Count; i++)//Add Size form DB to Array.
                {
                    for (int j = 0; j < sizeRef.Rows.Count; j++)
                    {
                        if (sizeRef.Rows[j]["Size"].ToString() == dt_Query.Rows[i]["Size"].ToString())
                        {
                            dt_Query.Rows[i]["NumRef"] = sizeRef.Rows[j]["SeqNo"];
                        }
                    }
                }
                dt_Query.DefaultView.Sort = "NumRef ASC";
                DataTable dtc = new DataTable();
                dtc = dt_Query.DefaultView.ToTable(true, "Size");
                DataTable col = new DataTable();
                col.Columns.Add("Color");
                foreach (DataRow row in dtc.Rows)
                {
                    col.Columns.Add(row[0].ToString());
                }
                DataTable dtr = new DataTable();
                dtr = dt_Query.DefaultView.ToTable(true, "Color");
                foreach (DataRow row in dtr.Rows)
                {
                    col.Rows.Add(row[0].ToString());

                }
                for (int i = 0; i < col.Rows.Count; i++)
                {
                    for (int j = 1; j < col.Columns.Count; j++)
                    {
                        for (int k = 0; k < dt_Query.Rows.Count; k++)//
                        {
                            if (dt_Query.Rows[k]["Size"].ToString() == col.Columns[j].ToString() && dt_Query.Rows[k]["Color"].ToString() == col.Rows[i]["Color"].ToString())
                            {
                                col.Rows[i][j] = dt_Query.Rows[k]["QTY"];
                            }
                        }
                    }
                }
                gvDisDetail.DataSource = col;
                col.Columns.Add("Sum");
                int rowSum = 0;
                for (int i = 0; i < col.Rows.Count; i++)
                {
                    for (int j = 1; j < col.Columns.Count - 1; j++)
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

                List<string> AuthorList = new List<string>();
                for (int i = 0; i < col.Columns.Count; i++)
                {
                    if (i == 0) { AuthorList.Add("SUM"); } else { AuthorList.Add(""); }
                }
                col.Rows.Add(AuthorList.ToArray());
                for (int j = 1; j < col.Columns.Count; j++)
                {
                    for (int i = 0; i < col.Rows.Count - 1; i++)
                    {
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
                    col.Rows[col.Rows.Count - 1][j] = rowSum;
                    rowSum = 0;
                }

                gvDisDetail.Columns[0].ReadOnly = true;
                gvDisDetail.Columns["Color"].Width = 250;
                DataGridViewCellStyle style = new DataGridViewCellStyle();
                style.BackColor = Color.FromArgb(223, 231, 235);
                style.ForeColor = Color.Black;
                gvDisDetail.Columns[gvDisDetail.Columns.Count - 1].DefaultCellStyle = style;
                gvDisDetail.Columns[0].DefaultCellStyle = style;
                gvDisDetail.Rows[gvDisDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.FromArgb(223, 231, 235);

            }
            else
            {
                MessageBox.Show("!!! Don't Have Data !!!");
            }
        }


        private void btCompareDec_Click(object sender, EventArgs e)
        {

        }

        private void cbUseDate_CheckedChanged(object sender, EventArgs e)
        {
            if (cbUseDate.Checked)
            {
                dtpFrom.Visible = true;
                dtpTo.Visible = true;
            }
            else if (!cbUseDate.Checked)
            {

                dtpFrom.Visible = false;
                dtpTo.Visible = false;


            }
        }

        private void cbbLine_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbbDec1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbbType_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btLoadDataNetYetScan_Click(object sender, EventArgs e)
        {
            if (cbbDec1.SelectedIndex > -1 && so_no != "")
            {
                string CheckMain = "";
                string ConditionSelect = "";
                string dec = "";


                if (cbbDec1.Text == "SMK")
                {
                    CheckMain = " AND `MainPart` =1 ";
                    ConditionSelect = CheckMain;
                    dec = "AND `Dec_Out` LIKE 'Sewing'";
                }
                else
                {
                    ConditionSelect = " AND `Deco` LIKE '%" + cbbDec1.Text + "%' ";
                }








                string sqlBalanceNotyetScan = @"
                                WITH LatestScans AS (
                                    SELECT 
                                        b.QrcodeBD,
                                        b.stINOUT,
                                        b.Location,
                                        MAX(b.TimeScan) AS LatestScanTime
                                    FROM 
                                        a_b1_bundle_to_dec_tb b
                                    WHERE 
                                        b.Decoration = '" + cbbDec1.Text + @"'
                                         " + CheckMain + @"
                                         AND b.SO = '" + so_no + @"'
                                    GROUP BY 
                                        b.QrcodeBD, 
                                        b.stINOUT
                                ),
                                ScansWithDetails AS (
                                    SELECT  
                                        s.SO,   
                                        b.QrcodeBD,
                                        b.SD_ListDoc_No,
                                        a.`BundleNo`,
                                        b.QTY AS Scan_QTY,
                                        b.stINOUT,
                                        a.Size,
                                        b.Dec_Out
                                    FROM 
                                        a_b1_bundle_to_dec_tb b
                                    JOIN 
                                        a_b1_bundle_tb a ON a.QRCodeBundle = b.QrcodeBD
                                    JOIN 
                                        a_a1_spreading_list_tb s ON a.SD_ListDoc_No = s.SD_ListDoc_No
                                    JOIN 
                                        LatestScans ls 
                                            ON b.QrcodeBD = ls.QrcodeBD 
                                            AND b.stINOUT = ls.stINOUT 
                                            AND b.TimeScan = ls.LatestScanTime
                                    WHERE 
                                        s.FabricType = 'A'
                                         AND s.SO = '" + so_no + @"'
                                         AND b.Decoration LIKE '" + cbbDec1.Text + @"' 
                                )
                                -- ส่วนนี้คือผลต่าง: ScanIN ที่ไม่มีใน ScanOUT

                                    SELECT 
                                    s.SO,
                                    s.SD_ListDoc_No,
                                    s.`BundleNo`,
                                    s.QrcodeBD,
                                    s.Scan_QTY,                                                   
                                    s.Size, 
                                    'IN but not OUT' AS Status
                                   
                                FROM 
                                    ScansWithDetails s
                                WHERE 
                                    s.stINOUT = '1'
                                    AND s.QrcodeBD NOT IN (
                                        SELECT QrcodeBD 
                                        FROM ScansWithDetails 
                                        WHERE stINOUT = '0' " + dec + @"
                                    )
 UNION ALL

                                        SELECT 
                                            s.SO,   
                                            s.SD_ListDoc_No,
                                            s.`BundleNo`,
                                            s.QRCodeBundle AS QrcodeBD,                                            
                                            s.QTY AS Scan_QTY,                                                   
                                            s.Size, 
                                            'Not yet scan in.' AS Status
                                        FROM 
                                            a_b1_bundle_tb s
                                        LEFT JOIN 
                                            ScansWithDetails i ON s.QRCodeBundle = i.QrcodeBD AND i.stINOUT = 1 
                                        WHERE 
                                            i.QrcodeBD IS NULL 
                                            AND s.SO = '" + so_no + "' " + ConditionSelect + ";";
                ConnectMySQL.DisplayAndSearch(sqlBalanceNotyetScan, gvNotYetScan);

            }
            else
            {
                MessageBox.Show("Please Select Row.");
            }
        }

        private void btExcel2_Click_1(object sender, EventArgs e)
        {
            if (gvNotYetScan.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                xcelApp.Application.Workbooks.Add(Type.Missing);

                for (int i = 1; i < gvNotYetScan.Columns.Count + 1; i++)
                {
                    xcelApp.Cells[1, i] = gvNotYetScan.Columns[i - 1].HeaderText;

                }
                for (int i = 0; i < gvNotYetScan.Rows.Count; i++)
                {
                    for (int j = 0; j < gvNotYetScan.Columns.Count; j++)
                    {
                        if (gvNotYetScan.Rows[i].Cells[j].Value != null)
                        {

                            xcelApp.Cells[i + 2, j + 1] = gvNotYetScan.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }
                xcelApp.Columns.AutoFit();
                xcelApp.Visible = true;
            }
        }
    }
}
