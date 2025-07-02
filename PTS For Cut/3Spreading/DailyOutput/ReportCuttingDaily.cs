using Guna.UI2.WinForms;
using OfficeOpenXml;
using PTS_For_Cut.Myclass;
using System.Data;

namespace PTS_For_Cut._3Spreading.DailyOutput
{
    public partial class ReportCuttingDaily : Form
    {
        string chLine = "";
        bool chColor = false;
        string colSoStyle = "";

        public ReportCuttingDaily()
        {
            InitializeComponent();
        }
        private void CenterLabel(Label lb, Panel pn)
        {
            lb.Left = (pn.Width - lb.Width) / 2;
            lb.Top = (pn.Height - lb.Height) / 2;
        }
        private void btReload_Click(object sender, EventArgs e)
        {
            loadForm("TKC");
        }

        DataTable dtLoadTarget = new DataTable();

        private void loadForm(string txt)
        {

            while (gvDis2.Rows.Count > 0)
            {
                gvDis2.Rows.RemoveAt(0);
            }
            while (gvDis2.Columns.Count > 0)
            {
                gvDis2.Columns.RemoveAt(0);
            }

            DataTable dtStructure = new DataTable();

            dtStructure.Columns.Add("No.");
            dtStructure.Columns.Add("Line");
            dtStructure.Columns.Add("Brand");
            dtStructure.Columns.Add(colSoStyle);
            dtStructure.Columns.Add("SAM");
            dtStructure.Columns.Add("Man");
            dtStructure.Columns.Add("ManAct");
            dtStructure.Columns.Add("Time");  //7
            dtStructure.Columns.Add("TimeAct");
            dtStructure.Columns.Add("Plan Eff%");
            dtStructure.Columns.Add("Plan PCS");
            dtStructure.Columns.Add("Plan PCS/Hr");
            dtStructure.Columns.Add("Fc Eff%"); //12
            dtStructure.Columns.Add("Fc PCS");
            dtStructure.Columns.Add("Fc PCS/Hr"); //14            
            if (cbbWorkshift.SelectedIndex == 0)
            {
                dtStructure.Columns.Add("08:00 09:00");//15
                dtStructure.Columns.Add("09:00 10:00");
                dtStructure.Columns.Add("10:00 11:00");
                dtStructure.Columns.Add("11:00 12:00");
                dtStructure.Columns.Add("12:00"); //19
                dtStructure.Columns.Add("13:00 14:00");
                dtStructure.Columns.Add("14:00 15:00");
                dtStructure.Columns.Add("15:00 16:00");
                dtStructure.Columns.Add("16:00 17:00");
                dtStructure.Columns.Add("17:00 18:00");
                dtStructure.Columns.Add("18:00 19:00");
                dtStructure.Columns.Add("19:00 20:00");
                dtStructure.Columns.Add("20:00 21:00");
                dtStructure.Columns.Add("21:00"); //28
                dtStructure.Columns.Add("22:00 23:00");
                dtStructure.Columns.Add("23:00 24:00"); //30
                dtStructure.Columns.Add("00:00 01:00");
                dtStructure.Columns.Add("01:00 02:00"); //32
            }
            else if (cbbWorkshift.SelectedIndex == 1)
            {
                dtStructure.Columns.Add("07:00 08:00");//15
                dtStructure.Columns.Add("08:00 09:00");
                dtStructure.Columns.Add("09:00 10:00");
                dtStructure.Columns.Add("10:00 11:00");
                dtStructure.Columns.Add("11:00 12:00");//19
                dtStructure.Columns.Add("12:00 13.00");
                dtStructure.Columns.Add("13:00 14:00");
                dtStructure.Columns.Add("14:00 15:00");
                dtStructure.Columns.Add("15:00 16:00");
                dtStructure.Columns.Add("16:00 17:00");
                dtStructure.Columns.Add("17:00 18:00");
                dtStructure.Columns.Add("18:00 19:00");
                dtStructure.Columns.Add("19:00 20:00");
                dtStructure.Columns.Add("20:00 21:00");
                dtStructure.Columns.Add("21:00 22:00"); //29
                dtStructure.Columns.Add("22:00 23:00");
                dtStructure.Columns.Add("23:00 24:00"); //31
                dtStructure.Columns.Add("00:00 01:00");
                dtStructure.Columns.Add("01:00 02:00"); //33
                dtStructure.Columns.Add("02:00 03:00");
                dtStructure.Columns.Add("03:00 04:00"); //36
                dtStructure.Columns.Add("04:00 05:00");
                dtStructure.Columns.Add("05:00 06:00");
                dtStructure.Columns.Add("06:00 07:00");
            }
            dtStructure.Columns.Add("Act PCS.");//33,40
            dtStructure.Columns.Add("Earn Min");
            dtStructure.Columns.Add("Clock Min");
            dtStructure.Columns.Add("Act Eff%"); //36 ,43
            dtStructure.Columns.Add("TotalAct Eff%");


            gvDis2.DataSource = dtStructure;
            this.gvDis2.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            foreach (DataGridViewColumn column in gvDis2.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

            }
            gvDis2.Columns[3].Frozen = true; //so style
            gvDis2.Columns[2].Frozen = true;

            DataTable getTarget = new DataTable();
            string txtDate = setDate(dtpDate);
            if (cbbReportMode.SelectedIndex == 0)
            {
                string sqltxt = "";
                if (cbbWorkshift.SelectedIndex == 0)
                {
                    sqltxt = @"SELECT 
                                                                C.Table_No AS Line,
                                                                C.Style,
                                                                IF(DATE_FORMAT(`Cut_ScanOut`, '%H') = '12', '11:00', DATE_FORMAT(`Cut_ScanOut`, '%H:00')) AS `Time`,
                                                                SUM(B.`QTY`) AS `QTY`,
                                                                CASE 
                                                                    WHEN TIME(`Cut_ScanOut`) BETWEEN '00:00:00' AND '05:00:00' 
                                                                    THEN DATE_SUB(DATE(`Cut_ScanOut`), INTERVAL 1 DAY)
                                                                    ELSE DATE(`Cut_ScanOut`)
                                                                END AS `Adjusted_Date`
                                                            FROM `a_a3_scandoc_sd_ct_tb` AS A 
                                                            LEFT JOIN `a_b1_bundle_tb` AS B ON A.SD_ListDoc_No = B.SD_ListDoc_No
                                                            JOIN `a_a1_spreading_list_tb` AS C ON A.SD_ListDoc_No = C.SD_ListDoc_No AND C.`FabricType`='A' AND C.`SD_Status` = 1
                                                            WHERE 
                                                            (
                                                                CASE 
                                                                    WHEN TIME(`Cut_ScanOut`) BETWEEN '00:00:00' AND '05:00:00' 
                                                                    THEN DATE_SUB(DATE(`Cut_ScanOut`), INTERVAL 1 DAY)
                                                                    ELSE DATE(`Cut_ScanOut`)
                                                                END 
                                                            )  =  '" + txtDate + @"' AND `MainPart` ='1' AND C.Table_No LIKE '%" + txt + "%' GROUP BY C.Table_No, C.Style, `Time` ORDER BY C.Table_No, C.Style, `Time` ASC;";
                }
                else if (cbbWorkshift.SelectedIndex == 1)
                {
                    sqltxt = @"SELECT 
                                                                C.Table_No AS Line,
                                                                C.Style,
                                                                 DATE_FORMAT(`Cut_ScanOut`, '%H:00') AS `Time`,
                                                                SUM(B.`QTY`) AS `QTY`,
                                                                CASE 
                                                                    WHEN TIME(`Cut_ScanOut`) BETWEEN '00:00:00' AND '05:00:00' 
                                                                    THEN DATE_SUB(DATE(`Cut_ScanOut`), INTERVAL 1 DAY)
                                                                    ELSE DATE(`Cut_ScanOut`)
                                                                END AS `Adjusted_Date`
                                                            FROM `a_a3_scandoc_sd_ct_tb` AS A 
                                                            LEFT JOIN `a_b1_bundle_tb` AS B ON A.SD_ListDoc_No = B.SD_ListDoc_No
                                                             JOIN `a_a1_spreading_list_tb` AS C ON A.SD_ListDoc_No = C.SD_ListDoc_No AND C.`FabricType`='A' AND C.`SD_Status` = 1
                                                            WHERE 
                                                            (
                                                                CASE 
                                                                    WHEN TIME(`Cut_ScanOut`) BETWEEN '00:00:00' AND '05:00:00'  
                                                                    THEN DATE_SUB(DATE(`Cut_ScanOut`), INTERVAL 1 DAY)
                                                                    ELSE DATE(`Cut_ScanOut`)
                                                                END 
                                                            )  =  '" + txtDate + @"' AND `MainPart` ='1' AND C.Table_No LIKE '%" + txt + "%' GROUP BY C.Table_No, C.Style, `Time` ORDER BY C.Table_No, C.Style, `Time` ASC;";
                }
                dtLoadTarget = ConnectMySQL.MySQLtoDataTable(sqltxt);

                getTarget = ConnectMySQL.MySQLtoDataTable(@"SELECT `a`.`id`, `a`.`Date`, `a`.`Line`,`b`.`Brand`,  b.`Style`, ROUND(`a`.`SAM`, 4) AS `SAM` , `a`.`ManTarget` AS Man, `a`.`ManActual` AS ManAct, `a`.`TimeTarget` AS Time,`a`.`TimeActual` AS TimeAct, `a`.`EffTargetplan`, `a`.`EffTargetForecast` 
                                                FROM `a_setuptargetforproduction` AS `a` 
                                                LEFT JOIN ( SELECT `SO`, MAX(`Style`) AS `Style` ,`Brand` FROM `so_tb` GROUP BY `SO` ) AS `b` ON `b`.SO = `a`.SO 
                                                WHERE `a`.`Date`= '" + txtDate + @"' AND `Type` = 'cut' AND `a`.`Line` LIKE '%" + txt + "%' GROUP BY DATE(`a`.`Date`),`a`.`Line`,b.`Style`,`Type` ORDER BY `a`.`Line` ASC;");

            }
            else if (cbbReportMode.SelectedIndex == 1)
            {
                dtLoadTarget = ConnectMySQL.MySQLtoDataTable(@"SELECT 
                                                                C.Table_No AS Line,
                                                                C.SO,
                                                                IF(DATE_FORMAT(`Cut_ScanOut`, '%H') = '12', '11:00', DATE_FORMAT(`Cut_ScanOut`, '%H:00')) AS `Time`,
                                                                SUM(B.`QTY`) AS `QTY`,
                                                                CASE 
                                                                    WHEN TIME(`Cut_ScanOut`) BETWEEN '00:00:00' AND '07:00:00' 
                                                                    THEN DATE_SUB(DATE(`Cut_ScanOut`), INTERVAL 1 DAY)
                                                                    ELSE DATE(`Cut_ScanOut`)
                                                                END AS `Adjusted_Date`
                                                            FROM `a_a3_scandoc_sd_ct_tb` AS A 
                                                            LEFT JOIN `a_b1_bundle_tb` AS B ON A.SD_ListDoc_No = B.SD_ListDoc_No
                                                            JOIN `a_a1_spreading_list_tb` AS C ON A.SD_ListDoc_No = C.SD_ListDoc_No  AND C.`SD_Status` = 1 AND C.`FabricType`='A'
                                                            WHERE 
                                                            (
                                                                CASE 
                                                                    WHEN TIME(`Cut_ScanOut`) BETWEEN '00:00:00' AND '07:00:00' 
                                                                    THEN DATE_SUB(DATE(`Cut_ScanOut`), INTERVAL 1 DAY)
                                                                    ELSE DATE(`Cut_ScanOut`)
                                                                END 
                                                            )  =  '" + txtDate + @"' AND `MainPart` ='1' AND C.Table_No LIKE '%" + txt + "%' GROUP BY C.Table_No, C.SO, `Time` ORDER BY C.Table_No, C.SO, `Time` ASC;");
                getTarget = ConnectMySQL.MySQLtoDataTable(@"SELECT `a`.`id`, `a`.`Date`, `a`.`Line`,`b`.`Brand`, `a`.`SO`, ROUND(`a`.`SAM`, 4) AS `SAM` , `a`.`ManTarget` AS Man, `a`.`ManActual` AS ManAct, `a`.`TimeTarget` AS Time, 
                                                                `a`.`TimeActual` AS TimeAct, `a`.`EffTargetplan`, `a`.`EffTargetForecast` 
                                                                FROM `a_setuptargetforproduction` AS `a` 
                                                                LEFT JOIN ( SELECT `SO`,`Brand` FROM `so_tb` GROUP BY `SO` ) AS `b` ON `b`.SO = `a`.SO 
                                                                WHERE `a`.`Date`= '" + txtDate + @"' AND `a`.`Type` = 'cut' AND `a`.`Line` LIKE '%" + txt + "%' GROUP BY DATE(`a`.`Date`),`a`.`Line`,`a`.`SO`,`a`.`Type` ORDER BY `a`.`Line` ASC");

            }

            DataTable dt = new DataTable();
            dt = (DataTable)gvDis2.DataSource;
            //if (dtLoadTarget.Rows.Count > 0)
            //{
            string Subline = "";
            string Subso = "";
            string Subtime = "";
            string Subqty = "";
            // MessageBox.Show("KKK");
            int countRows = 0;
            for (int i = 0; i < dtLoadTarget.Rows.Count; i++)
            {
                string line = dtLoadTarget.Rows[i]["Line"].ToString();
                string so = dtLoadTarget.Rows[i][colSoStyle].ToString();
                string time = dtLoadTarget.Rows[i]["Time"].ToString();
                double qty = double.Parse(dtLoadTarget.Rows[i]["QTY"].ToString());
                //   MessageBox.Show(line + "--" + so);
                if (i == 0)
                {
                    countRows++;
                    dt.Rows.Add(countRows.ToString(), line, "", so);
                }
                else if (line != Subline || so != Subso)
                {
                    countRows++;
                    dt.Rows.Add(countRows.ToString(), line, "", so);
                }
                for (int j = 15; j < dt.Columns.Count - 5; j++)
                {
                    string columnName = dt.Columns[j].ColumnName.Substring(0, 5);
                    if (time == columnName)
                    {
                        dt.Rows[dt.Rows.Count - 1][j] = qty.ToString("#,##0.#");
                    }
                }
                Subline = line;
                Subso = so;
            }
            for (int i = 0; i < getTarget.Rows.Count; i++)
            {
                bool checkAddLine = false;
                for (int j = 0; j < dt.Rows.Count; j++)//colSoStyle
                {
                    if (getTarget.Rows[i]["Line"].ToString() == dt.Rows[j]["Line"].ToString()
                        && getTarget.Rows[i][colSoStyle].ToString() == dt.Rows[j][colSoStyle].ToString())
                    {
                        checkAddLine = true;
                        break;
                    }
                }
                if (!checkAddLine)
                {
                    object[] newRow = { dt.Rows.Count + 1, getTarget.Rows[i]["Line"].ToString(), "", getTarget.Rows[i][colSoStyle].ToString() };
                    AddAndMoveRow("Line", newRow);
                }
            }
            dt.Rows.Add("", "", "", "SUM");
            // dt.Rows.Add("", "", "", "SUM", "", "", Mmantar.ToString("#,##0.##"), MmanAc.ToString("#,##0.##"), Ttime.ToString("#,##0.##"), TtimeAc.ToString("#,##0.##"), PplEff.ToString("##.#") + "%", PplPcs.ToString("#,##0.##"), IintplPcsHr.ToString("#,##0.##"), FfcEff.ToString("##.#") + "%", FfePcs.ToString("#,##0.##"), IintfePcsHr.ToString("#,##0.##"));
            gvDis2.DataSource = dt;

            lbtimeNow();

            for (int i = 0; i < gvDis2.Rows.Count; i++)
            {
                var gv = gvDis2.Rows[i];

                for (int k = 0; k < getTarget.Rows.Count; k++)
                {
                    var tr = getTarget.Rows[k];

                    string gvLine = gv.Cells["Line"].Value?.ToString();
                    string trLine = tr["Line"]?.ToString();
                    string gvStyle = gv.Cells[colSoStyle].Value?.ToString();
                    string trStyle = tr[colSoStyle]?.ToString();

                    if (!string.IsNullOrEmpty(gvLine) && !string.IsNullOrEmpty(trLine) &&
                        !string.IsNullOrEmpty(gvStyle) && !string.IsNullOrEmpty(trStyle) &&
                        gvLine == trLine && gvStyle == trStyle)
                    {
                        gv.Cells["SAM"].Value = tr["SAM"];
                        gv.Cells["Man"].Value = tr["Man"];

                        // ตรวจสอบว่ามีคอลัมน์ "ManAct" หรือไม่
                        if (getTarget.Columns.Contains("ManAct"))
                        {
                            gv.Cells["ManAct"].Value = tr["ManAct"];
                        }

                        gv.Cells["Time"].Value = tr["Time"];
                        gv.Cells["TimeAct"].Value = tr["TimeAct"];
                        gv.Cells["Brand"].Value = tr["Brand"];
                        gv.Cells["Plan Eff%"].Value = tr["EffTargetplan"] + "%";
                        gv.Cells["Fc Eff%"].Value = tr["EffTargetForecast"] + "%";

                        double PcsFC = 0, SamFC = 0, EffFC = 0, ManFc = 0, timeAct = 0, timeAct1 = 0;

                        if (double.TryParse(tr["SAM"]?.ToString(), out SamFC) && SamFC > 0 &&
                            double.TryParse(tr["EffTargetForecast"]?.ToString(), out EffFC) &&
                            double.TryParse(tr["ManAct"]?.ToString(), out ManFc) &&
                            double.TryParse(tr["TimeAct"]?.ToString(), out timeAct) &&
                            double.TryParse(tr["TimeAct"]?.ToString(), out timeAct1))
                        {
                            timeAct *= 60;
                            PcsFC = Math.Round(((EffFC * ManFc * timeAct) / 100) / SamFC, 0, MidpointRounding.AwayFromZero);
                        }

                        if (gvDis2.Columns.Contains("Fc PCS"))
                        {
                            gv.Cells["Fc PCS"].Value = PcsFC > 0 ? PcsFC.ToString("#,##0.#") : "0";
                        }

                        if (gvDis2.Columns.Contains("Fc PCS/Hr"))
                        {
                            gv.Cells["Fc PCS/Hr"].Value = timeAct1 > 0 ? Math.Round((PcsFC / timeAct1)).ToString("#,##0.#") : "0";
                        }

                        double TtimeAc = 0;
                        double MmanAc = 0;

                        // ตรวจสอบว่ามีคอลัมน์ "ManAct" ก่อนทำการแปลงค่า
                        if (getTarget.Columns.Contains("ManAct"))
                        {
                            double SumManAc = double.Parse(tr["ManAct"].ToString());
                            MmanAc += SumManAc;

                            if (dtLoadTarget.Columns.Contains("TimeAct"))
                            {
                                string TimeAc = dtLoadTarget.Rows[i]["TimeAct"].ToString();
                                double timeWorkAcSec = double.Parse(TimeAc) * 60;
                                TtimeAc += (double.Parse(TimeAc) * SumManAc);
                            }
                        }

                        double PcsPl = 0, SamPl = 0, EffPl = 0, ManPl = 0, time = 0, time1 = 0;

                        if (double.TryParse(tr["SAM"]?.ToString(), out SamPl) && SamPl > 0 &&
                            double.TryParse(tr["EffTargetplan"]?.ToString(), out EffPl) &&
                            double.TryParse(tr["Man"]?.ToString(), out ManPl) &&
                            double.TryParse(tr["Time"]?.ToString(), out time) &&
                            double.TryParse(tr["Time"]?.ToString(), out time1))
                        {
                            time *= 60;
                            PcsPl = Math.Round(((EffPl * ManPl * time) / 100) / SamPl, 0, MidpointRounding.AwayFromZero);
                        }

                        if (gvDis2.Columns.Contains("Plan PCS"))
                        {
                            gv.Cells["Plan PCS"].Value = PcsPl > 0 ? PcsPl.ToString("#,##0.#") : "0";
                        }

                        if (gvDis2.Columns.Contains("Plan PCS/Hr"))
                        {
                            gv.Cells["Plan PCS/Hr"].Value = timeAct1 > 0 ? Math.Round((PcsPl / timeAct1)).ToString("#,##0.#") : "0";
                        }
                    }
                }
            }
            /// Sum Man and Man Act
            decimal totalMan = 0;
            decimal totalManAct = 0;
            HashSet<string> processedValues = new HashSet<string>(); // ใช้เก็บค่าที่ไม่ซ้ำกัน

            foreach (DataGridViewRow row in gvDis2.Rows)
            {
                if (row.Cells[1].Value != null && row.Cells["Man"].Value != null) // ตรวจสอบว่ามีค่าหรือไม่
                {
                    string manActValue = row.Cells["ManAct"].Value != null ? row.Cells["ManAct"].Value.ToString() : "0"; // ป้องกัน null
                    string uniqueKey = row.Cells[1].Value.ToString() + "_" + row.Cells["Man"].Value.ToString() + "_" + manActValue; // รวมค่าเพื่อเช็คความซ้ำกัน

                    if (!processedValues.Contains(uniqueKey)) // ถ้ายังไม่เคยเจอค่าที่ซ้ำกัน
                    {
                        processedValues.Add(uniqueKey); // บันทึกค่าใน HashSet

                        decimal man = 0;
                        decimal manAct = 0;

                        // เช็คและเพิ่มค่าในคอลัมน์ "Man" หากมีค่า
                        if (decimal.TryParse(row.Cells["Man"].Value.ToString(), out man))
                        {
                            totalMan += man;
                        }

                        // เช็คและเพิ่มค่าในคอลัมน์ "ManAct" หากมีค่า
                        if (row.Cells["ManAct"].Value != null && decimal.TryParse(row.Cells["ManAct"].Value.ToString(), out manAct))
                        {
                            totalManAct += manAct;
                        }
                    }
                }
            }

            // อัปเดตแถวสุดท้าย (SUM)
            if (gvDis2.Rows.Count > 0)
            {
                DataGridViewRow sumRow = gvDis2.Rows[gvDis2.Rows.Count - 1];
                sumRow.Cells["Man"].Value = totalMan.ToString("#,##0.#");
                sumRow.Cells["ManAct"].Value = totalManAct.ToString("#,##0.#");

            }


            /// Sum TotalPlanPCS , TotalPlanPCSperHr, TotalFcPCS, TotalPlanFcPCSHr, TotalTime, TotalTimeAct
            double TotalPlanPCS = 0, TotalPlanPCSperHr = 0, TotalFcPCS = 0, TotalPlanFcPCSHr = 0, TotalTime = 0, TotalTimeAct = 0;
            foreach (DataGridViewRow row in gvDis2.Rows)
            {
                if (row.IsNewRow) continue; // ข้ามแถวว่างที่เพิ่มใหม่
                if (double.TryParse(row.Cells["Plan PCS"].Value?.ToString(), out double parsedPlanPCS))
                {
                    TotalPlanPCS += parsedPlanPCS;
                }

                if (double.TryParse(row.Cells["Plan PCS/Hr"].Value?.ToString(), out double parsedPlanPCSHr))
                {
                    TotalPlanPCSperHr += parsedPlanPCSHr;
                }
                if (double.TryParse(row.Cells["Fc PCS"].Value?.ToString(), out double parsedFcPCS))
                {
                    TotalFcPCS += parsedFcPCS;
                }
                if (double.TryParse(row.Cells["Fc PCS/Hr"].Value?.ToString(), out double parsedTotalFcPCSHr))
                {
                    TotalPlanFcPCSHr += parsedTotalFcPCSHr;
                }
                if (double.TryParse(row.Cells["Time"].Value?.ToString(), out double parsedTotalTime))
                {
                    TotalTime += parsedTotalTime;
                }

                if (double.TryParse(row.Cells["TimeAct"].Value?.ToString(), out double parsedTotalTimeAct))
                {
                    TotalTimeAct += parsedTotalTimeAct;
                }

            }

            // เพิ่มผลรวมลงในแถวสุดท้าย
            var lastRow = gvDis2.Rows[gvDis2.Rows.Count - 1];
            lastRow.Cells["Plan PCS"].Value = TotalPlanPCS.ToString("#,##0.#");
            lastRow.Cells["Plan PCS/Hr"].Value = TotalPlanPCSperHr.ToString("#,##0.#");
            lastRow.Cells["Fc PCS"].Value = TotalFcPCS.ToString("#,##0.#");
            lastRow.Cells["Fc PCS/Hr"].Value = TotalPlanFcPCSHr.ToString("#,##0.#");
            lastRow.Cells["Time"].Value = TotalTime.ToString("#,##0.#");
            lastRow.Cells["TimeAct"].Value = TotalTimeAct.ToString("#,##0.#");




            /// จำนวนรวม Act PCS

            double qtyAllAct = 0;

            for (int i = 0; i < gvDis2.Rows.Count - 1; i++)
            {
                double qtyEachLineActual = 0;
                for (int j = 15; j < gvDis2.Columns.Count - 5; j++)
                {
                    var chValue = gvDis2.Rows[i].Cells[j];

                    // Ensure the value is not null and is a valid integer
                    if (chValue.Value != null && !string.IsNullOrWhiteSpace(chValue.Value.ToString()))
                    {

                        if (double.TryParse(chValue.Value.ToString(), out double parsedValue))
                        {
                            qtyEachLineActual += parsedValue;
                        }
                        else
                        {
                            continue;
                        }

                    }

                    if (j == gvDis2.Columns.Count - 6)
                    {
                        gvDis2.Rows[i].Cells[j + 1].Value = qtyEachLineActual.ToString("#,##0.#");
                        qtyAllAct += qtyEachLineActual;
                    }
                }

            }

            // Assign total value to the appropriate cells
            gvDis2.Rows[gvDis2.Rows.Count - 1].Cells[gvDis2.Columns.Count - 5].Value = qtyAllAct;
            gvDis2.Rows[gvDis2.Rows.Count - 1].Cells["Act PCS."].Value = qtyAllAct.ToString("#,##0.#");

            // คำนวณ Earn Min

            double TotalEarnMinRow = 0;
            double TotalclockMin = 0;
            double TotalActEff = 0;

            for (int i = 0; i < gvDis2.Rows.Count - 1; i++)
            {
                // Safely parse "Act PCS."
                double totalPcs = gvDis2.Rows[i].Cells["Act PCS."].Value != null &&
                                  !string.IsNullOrWhiteSpace(gvDis2.Rows[i].Cells["Act PCS."].Value.ToString())
                    ? double.TryParse(gvDis2.Rows[i].Cells["Act PCS."].Value.ToString(), out double parsedTotalPcs)
                        ? parsedTotalPcs
                        : 0
                    : 0;

                // Safely parse "SAM"
                double sam = gvDis2.Rows[i].Cells["SAM"].Value != null &&
                             !string.IsNullOrWhiteSpace(gvDis2.Rows[i].Cells["SAM"].Value.ToString())
                    ? double.TryParse(gvDis2.Rows[i].Cells["SAM"].Value.ToString(), out double parsedSam)
                        ? parsedSam
                        : 0
                    : 0;

                double ManFc = gvDis2.Rows[i].Cells["ManAct"].Value != null &&
                               !string.IsNullOrWhiteSpace(gvDis2.Rows[i].Cells["ManAct"].Value.ToString())
                    ? double.TryParse(gvDis2.Rows[i].Cells["ManAct"].Value.ToString(), out double parsedManFc)
                        ? parsedManFc
                        : 0
                    : 0;

                double timeAct = string.IsNullOrEmpty(gvDis2.Rows[i].Cells["TimeAct"].Value?.ToString())
                    ? 0
                    : double.Parse(gvDis2.Rows[i].Cells["TimeAct"].Value.ToString()) * 60;


                // Calculate EarnMinRow
                double EarnMinRow = totalPcs * sam;

                // Assign EarnMinRow to the cell
                gvDis2.Rows[i].Cells["Earn Min"].Value = EarnMinRow.ToString("#,##0.#");

                // Safely parse "Earn Min" for the total
                if (gvDis2.Rows[i].Cells["Earn Min"].Value != null &&
                    !string.IsNullOrWhiteSpace(gvDis2.Rows[i].Cells["Earn Min"].Value.ToString()))
                {
                    if (double.TryParse(gvDis2.Rows[i].Cells["Earn Min"].Value.ToString(), out double parsedEarnMin))
                    {
                        TotalEarnMinRow += parsedEarnMin;
                    }
                }
                bool check1800 = false;
                double timeMin = 0;


                //  if (gvDis2.Rows[i].Cells["18:00 19:00"].Value.ToString() != "")
                { check1800 = true; }
                if (txtDate == DateNow())
                {
                    timeMin = checkHrsNow(check1800);

                    if (timeMin >= timeAct)
                    {
                        timeMin = timeAct;
                    }
                    else
                    {
                        timeMin = timeMin;
                    }
                }
                else
                {
                    timeMin = timeAct;
                }
                double clockMin = ManFc * timeMin;

                //  MessageBox.Show(ManFc.ToString() +"||"+timeMin.ToString());
                gvDis2.Rows[i].Cells["Clock Min"].Value = clockMin.ToString("#,##0.#");

                if (gvDis2.Rows[i].Cells["Clock Min"].Value != null &&
                    !string.IsNullOrWhiteSpace(gvDis2.Rows[i].Cells["Clock Min"].Value.ToString()))
                {
                    if (double.TryParse(gvDis2.Rows[i].Cells["Clock Min"].Value.ToString(), out double parsedClockMin))
                    {
                        TotalclockMin += parsedClockMin;
                    }
                }

                double ActEff = (EarnMinRow / clockMin) * 100;
                if (ActEff > 0)
                {
                    string txtActEff = ActEff.ToString("#,##0.#");
                    gvDis2.Rows[i].Cells["Act Eff%"].Value = txtActEff + "%";
                }
                else
                {
                    gvDis2.Rows[i].Cells["Act Eff%"].Value = "0%";
                }


                if (gvDis2.Rows[i].Cells["Act Eff%"].Value != null &&
                   !string.IsNullOrWhiteSpace(gvDis2.Rows[i].Cells["Act Eff%"].Value.ToString()))
                {
                    if (double.TryParse(gvDis2.Rows[i].Cells["Act Eff%"].Value.ToString(), out double parsedActEff))
                    {
                        TotalclockMin += parsedActEff;
                    }
                }

            }

            // Assign total Earn Min to the last row
            gvDis2.Rows[gvDis2.Rows.Count - 1].Cells["Earn Min"].Value = TotalEarnMinRow.ToString("#,##0.#");
            gvDis2.Rows[gvDis2.Rows.Count - 1].Cells["Clock Min"].Value = TotalclockMin.ToString("#,##0.#");



            // Ensure TotalclockMin is not zero to avoid division by zero
            if (TotalclockMin != 0 && !double.IsNaN(TotalEarnMinRow) && !double.IsNaN(TotalclockMin))
            {
                double percentage = (TotalEarnMinRow / TotalclockMin) * 100;
                gvDis2.Rows[gvDis2.Rows.Count - 1].Cells["TotalAct Eff%"].Value = percentage.ToString("#,##0.#") + "%";
            }
            else
            {
                gvDis2.Rows[gvDis2.Rows.Count - 1].Cells["TotalAct Eff%"].Value = "0%"; // Default to 0% if division is not possible
            }



            for (int i = 15; i < gvDis2.Columns.Count - 5; i++)
            {
                bool checkNull = false;
                for (int j = 0; j < gvDis2.Rows.Count - 1; j++)
                {
                    var chValue = gvDis2.Rows[j].Cells[i];
                    if (DateTime.Now.ToString("yyyy-MM-dd") == dtpDate.Value.ToString("yyyy-MM-dd"))
                    {
                        //(e.Value == null || string.IsNullOrWhiteSpace(e.Value.ToString()))

                        if (chValue.Value != DBNull.Value || !string.IsNullOrWhiteSpace(chValue.Value.ToString()))
                        {
                            checkNull = true;
                        }
                    }
                    else
                    {
                        if (chValue.Value != DBNull.Value || !string.IsNullOrWhiteSpace(chValue.Value.ToString()))
                        {
                            checkNull = true;
                        }
                    }
                }
                // ตั้งค่า AutoSizeMode และความกว้างของคอลัมน์
                gvDis2.Columns["No."].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                gvDis2.Columns["Line"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                gvDis2.Columns["Brand"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                gvDis2.Columns[colSoStyle].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //so-style
                gvDis2.Columns["SAM"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                gvDis2.Columns["Act PCS."].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                gvDis2.Columns["Earn Min"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                gvDis2.Columns["Clock Min"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                gvDis2.Columns["Act Eff%"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                gvDis2.Columns["TotalAct Eff%"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                gvDis2.Columns[colSoStyle].Width = 150;
                if (cbbWorkshift.SelectedIndex == 0)
                {
                    gvDis2.Columns["12:00"].Width = 15;
                    gvDis2.Columns["12:00"].HeaderCell.Style.ForeColor = SystemColors.Control;
                    gvDis2.Columns["12:00"].DefaultCellStyle.ForeColor = SystemColors.Control;
                    gvDis2.Columns["21:00"].Width = 15;
                    gvDis2.Columns["21:00"].HeaderCell.Style.ForeColor = SystemColors.Control;
                    gvDis2.Columns["21:00"].DefaultCellStyle.ForeColor = SystemColors.Control;
                }

            }
            for (int i = 15; i < gvDis2.Columns.Count - 5; i++)
            {
                double QTYColumn = 0;

                for (int j = 0; j < gvDis2.RowCount - 1; j++)
                {
                    // Check if the cell value is valid
                    string xx = gvDis2.Rows[j].Cells[i].Value?.ToString()?.Trim() ?? "0";

                    if (string.IsNullOrEmpty(xx) || !double.TryParse(xx, out double cellValue))
                    {
                        cellValue = 0; // Default to 0 if parsing fails
                    }

                    QTYColumn += cellValue;
                }

                // Update the last row's cell with the calculated total
                if (QTYColumn > 0)
                {
                    gvDis2.Rows[gvDis2.Rows.Count - 1].Cells[i].Value = QTYColumn.ToString("#,##0.#");
                }
                else
                {
                    gvDis2.Rows[gvDis2.Rows.Count - 1].Cells[i].Value = "";
                }
            }
            chColor = false;
            TimerRefreshFirst.Start();
        }

        private string DateNow()
        {
            string txtDate = "";
            System.Globalization.CultureInfo _cultureEnInfo = new System.Globalization.CultureInfo("en-US");
            DateTime date = Convert.ToDateTime(DateTime.Now, _cultureEnInfo);
            txtDate = date.ToString("yyyy-MM-dd", _cultureEnInfo);
            return txtDate;
        }
        private string setDate(Guna2DateTimePicker dtpDate)
        {
            string txtDate = "";
            System.Globalization.CultureInfo _cultureEnInfo = new System.Globalization.CultureInfo("en-US");
            DateTime date = Convert.ToDateTime(dtpDate.Value, _cultureEnInfo);
            txtDate = date.ToString("yyyy-MM-dd", _cultureEnInfo);
            return txtDate;
        }

        private void lbtimeNow()
        {
            //System.Globalization.CultureInfo _cultureEnInfo = new System.Globalization.CultureInfo("en-US");
            string txtDateStart = DateNow() + " 08:00:00";
            DateTime newTime = DateTime.Now;
            DateTime Start = Convert.ToDateTime(txtDateStart);
            TimeSpan span = newTime.Subtract(Start);
            lbTime.Text = DateTime.Now.ToString("HH:mm:ss");
            lbMinute.Text = span.TotalMinutes.ToString("##");

            if (span.TotalHours <= 4)
            {
                lbMinute.Text = span.TotalMinutes.ToString("##");
            }
            else if (span.TotalHours > 4 && span.TotalHours <= 5)
            {
                lbMinute.Text = "240";
            }
            else if (span.TotalHours > 5)
            {
                lbMinute.Text = (span.TotalMinutes - 60).ToString("##");
            }

        }
        private double checkHrsNow(bool CheckDataTime1800)
        {
            //System.Globalization.CultureInfo _cultureEnInfo = new System.Globalization.CultureInfo("en-US");
            string txtDateStart = DateNow() + " 08:00:00";
            DateTime newTime = DateTime.Now;
            DateTime Start = Convert.ToDateTime(txtDateStart);
            TimeSpan span = newTime.Subtract(Start);


            if (span.TotalHours <= 9)
            {
                return double.Parse(lbMinute.Text);
            }
            else if (span.TotalHours > 9 && span.TotalHours <= 10 && CheckDataTime1800)
            {
                return double.Parse(lbMinute.Text);
            }
            else if (span.TotalHours > 9 && span.TotalHours <= 10 && !CheckDataTime1800)
            {
                return 480;
            }
            else
            {
                if (CheckDataTime1800)
                {
                    return double.Parse(lbMinute.Text);
                }
                else
                {
                    return double.Parse(lbMinute.Text) - 60;
                }
            }
        }
        bool formLoadfirstTimeNotLoad = false;
        private void ReportCuttingDaily_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.workShift != -1)
            {
                cbbWorkshift.SelectedIndex = Properties.Settings.Default.workShift;
            }
            else
            {
                cbbWorkshift.SelectedIndex = 0;
            }
            cbbReportMode.SelectedIndex = 0;
            dtpDate.Value = DateTime.Now;
            gvDis2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            gvDis2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            cbbShowData.SelectedIndex = 0;
            CenterLabel(lbHeader, pnlbHeader);
            formLoadfirstTimeNotLoad = true;
            loadForm("TKC");
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            // loadForm("TK");
        }

        private void btSetUpTarget_Click(object sender, EventArgs e)
        {
            SetTargetCut setTargetPack = new SetTargetCut();
            setTargetPack.Show();
        }


        private void gvDis2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                // Ensure the row index is within valid bounds
                if (e.RowIndex < gvDis2.RowCount - 1)
                {
                    // Get the rectangle for the current cell
                    System.Drawing.Rectangle rect = e.CellBounds;

                    // Check if the current cell's value is equal to the value of the previous cell in the same column
                    if (e.RowIndex > 0 &&
                        gvDis2[e.ColumnIndex, e.RowIndex].Value != null &&
                        gvDis2[e.ColumnIndex, e.RowIndex].Value.Equals(gvDis2[e.ColumnIndex, e.RowIndex - 1].Value))
                    {
                        // Prevent painting of the current cell
                        e.Handled = true;

                        // Extend the rectangle to cover the previous cell
                        rect.Y -= rect.Height;
                        rect.Height *= 3;

                        // Capture the background color of the cell before merging
                        Color originalBackColor = gvDis2[e.ColumnIndex, e.RowIndex].Style.BackColor;
                        if (originalBackColor == Color.Empty)
                        {
                            originalBackColor = gvDis2.DefaultCellStyle.BackColor; // Default background
                        }

                        // Paint the merged cell with the captured background color
                        using (Brush brush = new SolidBrush(originalBackColor))
                        {
                            e.Graphics.FillRectangle(brush, rect);
                        }

                        // Draw the border of the merged cell
                        e.Graphics.DrawRectangle(SystemPens.Control, rect);

                        // Draw the value of the merged cell
                        using (Font font = new Font("Bahnschrift", 12, FontStyle.Regular))
                        {
                            string text = gvDis2[e.ColumnIndex, e.RowIndex].Value.ToString();
                            SizeF textSize = e.Graphics.MeasureString(text, font);

                            // Calculate the center position for the text
                            float x = rect.X + (rect.Width - textSize.Width) / 2;
                            float y = rect.Y + (rect.Height - textSize.Height) / 2;

                            // Use higher quality rendering for clearer text
                            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                            e.Graphics.DrawString(text, font, SystemBrushes.ControlText, new PointF(x, y));
                        }

                        // Apply the same effect to column 31
                        if (e.RowIndex > 0 && gvDis2[37, e.RowIndex].Value != null &&
                            gvDis2[37, e.RowIndex].Value.Equals(gvDis2[37, e.RowIndex - 1].Value))
                        {
                            // Repeat the same logic for column 31
                            System.Drawing.Rectangle rect31 = gvDis2.GetCellDisplayRectangle(37, e.RowIndex, true);

                            rect31.Y -= rect31.Height;
                            rect31.Height *= 3;

                            // Paint the merged cell for column 31
                            using (Brush brush = new SolidBrush(originalBackColor))
                            {
                                e.Graphics.FillRectangle(brush, rect31);
                            }

                            // Draw the border for column 31
                            e.Graphics.DrawRectangle(SystemPens.Control, rect31);

                            // Draw the value of the merged cell for column 31
                            using (Font font = new Font("Bahnschrift", 12, FontStyle.Regular))
                            {
                                string text = gvDis2[31, e.RowIndex].Value.ToString();
                                SizeF textSize = e.Graphics.MeasureString(text, font);

                                float x = rect31.X + (rect31.Width - textSize.Width) / 2;
                                float y = rect31.Y + (rect31.Height - textSize.Height) / 2;

                                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                                e.Graphics.DrawString(text, font, SystemBrushes.ControlText, new PointF(x, y));
                            }
                        }
                    }
                }
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {

            // timerRefresh.Stop();

            if (formLoadfirstTimeNotLoad)
            { loadForm("TKC"); }

        }
        bool colorLoop = false;

        private void TimerRefreshFirst_Tick(object sender, EventArgs e)
        {
            if (gvDis2.Rows.Count > 0)
            {

                for (int i = 0; i < gvDis2.Rows.Count; i++)
                {
                    if (chLine != gvDis2.Rows[i].Cells[1].Value.ToString())
                    {
                        chColor = !chColor; // Status เปลี่ยนสี
                    }
                    chLine = gvDis2.Rows[i].Cells[1].Value.ToString();



                    for (int j = 0; j < gvDis2.Columns.Count; j++)
                    {
                        var gv = gvDis2.Rows[i].Cells[j];
                        if (j >= 15 && j < gvDis2.Columns.Count - 5 && i < gvDis2.Rows.Count - 1) // Note: Column index is zero-based
                        {
                            double valueCol1 = 0;

                            // Get the cell value safely
                            var cellValue = gvDis2.Rows[i].Cells["Fc PCS/Hr"].Value;

                            // Convert to a string, handle nulls, and trim spaces
                            string cellText = cellValue?.ToString()?.Trim() ?? "0";

                            // Try parsing the value
                            if (!double.TryParse(cellText, out valueCol1))
                            {
                                valueCol1 = 0; // Default to 0 if parsing fails
                            }


                            double outputValue = 0;
                            if (gv.Value != DBNull.Value)
                            {
                                outputValue = double.Parse(gv.Value.ToString());
                            }
                            if (outputValue >= valueCol1 && valueCol1 > 0)
                            {
                                gv.Style.BackColor = Color.Lime;
                            }
                            else if (outputValue < valueCol1 || outputValue == 0 || valueCol1 == 0)
                            {
                                if (j != 19 && j != 28 && cbbWorkshift.SelectedIndex == 0)  // ยกเว้น 12.00 ,21.00-22.00
                                {
                                    if (outputValue > 0)//outputValue 
                                    {
                                        gvDis2.Rows[i].Cells[j].Style.BackColor = Color.LightCoral;
                                    }
                                    else
                                    {

                                        gv.Style.BackColor = Color.Red;
                                    }

                                }
                                else if (cbbWorkshift.SelectedIndex == 1)
                                {
                                    if (outputValue > 0)//outputValue 
                                    {
                                        gvDis2.Rows[i].Cells[j].Style.BackColor = Color.LightCoral;
                                    }
                                    else
                                    {

                                        gv.Style.BackColor = Color.Red;
                                    }
                                }
                            }
                        }
                        if (j > 0 && gvDis2.Rows[i].Cells[j].Style.BackColor != Color.Red && gvDis2.Rows[i].Cells[j].Style.BackColor != Color.LightCoral &&
                       gvDis2.Rows[i].Cells[j].Style.BackColor != Color.Lime)
                        {

                            if (chColor)
                            {
                                if (j == 1)
                                {
                                    gvDis2.Rows[i].Cells[j - 1].Style.BackColor = Color.White;
                                }

                                gvDis2.Rows[i].Cells[j].Style.BackColor = Color.White;
                            }
                            else
                            {
                                if (j == 1)
                                {
                                    gvDis2.Rows[i].Cells[j - 1].Style.BackColor = SystemColors.Menu;
                                }
                                gvDis2.Rows[i].Cells[j].Style.BackColor = SystemColors.Menu;
                            }
                        }


                        if (j == Eff_Act_columnIndex || j == 12) // เปรียบเทียบสีตัวอักษร % EFF Fc & Eff Act
                        {
                            Color ccolor = Color.Blue;

                            if (j == Eff_Act_columnIndex && gvDis2.Rows[i].Cells[12].Value != null && gvDis2.Rows[i].Cells[j].Value != null && i < gvDis2.RowCount - 2)
                            {
                                // Convert values to strings, handling null and trimming spaces
                                string txteffTar = gvDis2.Rows[i].Cells[12].Value.ToString().Trim();
                                string txteffAct = gvDis2.Rows[i].Cells[j].Value.ToString().Trim();

                                // Ensure values are not empty
                                if (!string.IsNullOrEmpty(txteffTar) && !string.IsNullOrEmpty(txteffAct))
                                {
                                    // Remove the '%' symbol safely if it exists
                                    if (txteffTar.EndsWith("%")) txteffTar = txteffTar.Substring(0, txteffTar.Length - 1);
                                    if (txteffAct.EndsWith("%")) txteffAct = txteffAct.Substring(0, txteffAct.Length - 1);

                                    double effTar, effAct;

                                    // Try parsing, default to 0 if parsing fails
                                    if (double.TryParse(txteffTar, out effTar) && double.TryParse(txteffAct, out effAct))
                                    {
                                        if (effAct < effTar)
                                        {
                                            ccolor = Color.Red;
                                        }
                                    }
                                }
                            }

                            gvDis2.Rows[i].Cells[j].Style.ForeColor = ccolor;
                        }

                        if (j == 13 || j == pcs_Act_columnIndex) // เปรียบเทียบ PCS
                        {
                            if (i < gvDis2.Rows.Count - 1)
                            {
                                gvDis2.Rows[i].Cells[j].Style.ForeColor = Color.DarkRed;
                            }

                        }

                        if (i == gvDis2.RowCount - 1)
                        {

                            if (j == 1)
                            {// using (Font font = new Font("Bahnschrift", 10, FontStyle.Regular))
                                gvDis2.Rows[i].Cells[j - 1].Style.BackColor = Color.DeepSkyBlue;

                                //gvDis2.Rows[i].Cells[j - 1].Style.ForeColor = Color.White;
                            }
                            gvDis2.Rows[i].Cells[j].Style.BackColor = Color.DeepSkyBlue;

                            //gvDis2.Rows[i].Cells[j].Style.ForeColor = Color.White;
                        }

                    }
                }
                //จำนวนคน
                int manTar = 0, manAct = 0;
                string subBeforeCurrentLine = "";

                for (int i = 0; i < gvDis2.Rows.Count - 1; i++)
                {
                    string currentlineCheck = gvDis2.Rows[i].Cells["Line"].Value.ToString();

                    //Safely parse the "Man" column
                    string manValue = gvDis2.Rows[i].Cells["Man"].Value?.ToString();
                    int man_t = 0;
                    if (!int.TryParse(manValue, out man_t))
                    {
                        man_t = 0; // Default to 0 if invalid
                    }

                    // Safely parse the "ManAct" column
                    string manActValue = gvDis2.Rows[i].Cells["ManAct"].Value?.ToString();
                    int man_act = 0;
                    if (!int.TryParse(manActValue, out man_act))
                    {
                        man_act = 0; // Default to 0 if invalid
                    }

                    if (currentlineCheck != subBeforeCurrentLine)
                    {
                        manTar += man_t;
                        manAct += man_act;
                    }

                    DataGridViewRow sumRow = gvDis2.Rows[gvDis2.Rows.Count - 1]; // Last row

                    // Safely update the "Man" and "ManAct" columns
                    sumRow.Cells["Man"].Value = manTar.ToString("#,##0.#");
                    sumRow.Cells["ManAct"].Value = manAct.ToString("#,##0.#");

                    subBeforeCurrentLine = currentlineCheck;
                    List<int> indexList = new List<int>();

                    for (int k = 0; k < gvDis2.Rows.Count; k++)
                    {
                        string LineCheck = gvDis2.Rows[k].Cells["Line"].Value.ToString();
                        if (currentlineCheck == LineCheck)
                        {

                            indexList.Add(k);
                        }
                    }

                    int[] indaxArray = indexList.ToArray();
                    if (indaxArray.Count() > 1)
                    {

                        for (int m = 15; m < gvDis2.Columns.Count - 5; m++)
                        {
                            if (cbbWorkshift.SelectedIndex == 0)
                            {
                                if (m != 19)
                                {
                                    Color backgroundColor = Color.Empty;

                                    for (int b = 0; b < indaxArray.Count(); b++)
                                    {
                                        if (gvDis2.Rows[indaxArray[b]].Cells[m].Style.BackColor == Color.Lime)
                                        {
                                            backgroundColor = gvDis2.Rows[indaxArray[b]].Cells[m].Style.BackColor;
                                        }
                                    }
                                    if (backgroundColor != Color.Empty)
                                    {

                                        for (int b = 0; b < indaxArray.Count(); b++)
                                        {
                                            gvDis2.Rows[indaxArray[b]].Cells[m].Style.BackColor = backgroundColor;
                                        }
                                    }
                                }
                            }
                            else if (cbbWorkshift.SelectedIndex == 1)
                            {
                                Color backgroundColor = Color.Empty;

                                for (int b = 0; b < indaxArray.Count(); b++)
                                {
                                    if (gvDis2.Rows[indaxArray[b]].Cells[m].Style.BackColor == Color.Lime)
                                    {
                                        backgroundColor = gvDis2.Rows[indaxArray[b]].Cells[m].Style.BackColor;
                                    }
                                }
                                if (backgroundColor != Color.Empty)
                                {

                                    for (int b = 0; b < indaxArray.Count(); b++)
                                    {
                                        gvDis2.Rows[indaxArray[b]].Cells[m].Style.BackColor = backgroundColor;
                                    }
                                }
                            }

                        }
                        //if (cbbReportMode.SelectedIndex == 0) //------------------------------------eff
                        //  {
                        double Earn = 0;
                        double Clock = 0;

                        for (int b = 0; b < indaxArray.Count(); b++)
                        {
                            string earnValue = gvDis2.Rows[indaxArray[b]].Cells["Earn Min"].Value?.ToString() ?? "0";
                            string clockValue = gvDis2.Rows[indaxArray[b]].Cells["Clock Min"].Value?.ToString() ?? "0";

                            if (double.TryParse(earnValue, out double earnMin))
                                Earn += earnMin;

                            if (double.TryParse(clockValue, out double clockMin))
                                Clock += clockMin;
                        }
                        // Prevent division by zero
                        double eff = (Clock > 0) ? (Earn / Clock) * 100 : 0;

                        for (int b = 0; b < indaxArray.Count(); b++)
                        {
                            gvDis2.Rows[indaxArray[b]].Cells["TotalAct Eff%"].Value = eff.ToString("#,##0.#") + "%";
                        }
                    }
                    else if (indaxArray.Count() == 1)
                    {
                        gvDis2.Rows[i].Cells["TotalAct Eff%"].Value = gvDis2.Rows[i].Cells["Act Eff%"].Value;
                    }
                }
            }

            Color ccolor2 = Color.Lime;

            for (int i = 15; i < gvDis2.Columns.Count - 5; i++)
            {
                bool checkNull = false;
                for (int j = 0; j < gvDis2.Rows.Count - 1; j++)
                {
                    if (DateTime.Now.ToString("yyyy-MM-dd") == dtpDate.Value.ToString("yyyy-MM-dd"))
                    {

                        if (gvDis2.Rows[j].Cells[i].Value.ToString() != "")
                        {
                            checkNull = true;
                        }
                    }
                    else
                    {
                        if (gvDis2.Rows[j].Cells[i].Value.ToString() != "")
                        {
                            checkNull = true;
                        }
                    }
                }
                if (!checkNull)
                {

                    TimeSpan time1 = TimeSpan.Parse(gvDis2.Columns[i].Name.Substring(0, 5));
                    TimeSpan time2 = TimeSpan.Parse(DateTime.Now.ToString("HH:00"));
                    int result = TimeSpan.Compare(time1, time2);
                    if (dtpDate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
                    {

                        //ซ่อนคอลัมน์ที่มีเวลามากกว่าปัจจุบัน(ยกเว้น "12:00")
                        if (result > 0 && gvDis2.Columns[i].Name != "12:00")
                        {
                            gvDis2.Columns[i].Visible = false;
                        }
                    }
                    else
                    {
                        if (cbbWorkshift.SelectedIndex == 0)
                        {
                            if (gvDis2.Columns[i].Name != "12:00" && gvDis2.Columns[i].Name != "21:00")
                            {
                                gvDis2.Columns[i].Visible = false;
                            }
                        }


                    }

                    // ตรวจสอบค่าของ "23:00 24:00" ว่ามีค่าหรือไม่
                    //bool isColumn23HasValue = false;

                    //foreach (DataGridViewRow row in gvDis2.Rows)
                    //{
                    //    if (row.Cells["23:00 24:00"].Value != null &&
                    //        int.TryParse(row.Cells["23:00 24:00"].Value.ToString(), out int value) &&
                    //        value > 0)
                    //    {
                    //        isColumn23HasValue = true;
                    //        break;
                    //    }
                    //}

                    //// ถ้า "23:00 24:00" ไม่มีค่า หรือค่าเป็น 0 → ซ่อน "00:00 01:00" และ "01:00 02:00"
                    //if (!isColumn23HasValue)
                    //{
                    //    if (gvDis2.Columns[i].Name == "00:00 01:00" || gvDis2.Columns[i].Name == "01:00 02:00")
                    //    {
                    //        gvDis2.Columns[i].Visible = false;
                    //    }
                    //}
                    //else
                    //{
                    //    // แสดงคอลัมน์ "00:00 01:00" และ "01:00 02:00" เมื่อ "23:00 24:00" มีค่า
                    //    if (gvDis2.Columns[i].Name == "00:00 01:00" || gvDis2.Columns[i].Name == "01:00 02:00")
                    //    {
                    //        gvDis2.Columns[i].Visible = true;
                    //    }
                    //}
                }
                else
                {
                    gvDis2.Columns[i].Visible = true;
                }


                gvDis2.Columns["No."].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                gvDis2.Columns["Line"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                gvDis2.Columns["Brand"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                gvDis2.Columns[colSoStyle].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //so-style
                gvDis2.Columns["SAM"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                gvDis2.Columns["Act PCS."].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                gvDis2.Columns["Earn Min"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                gvDis2.Columns["Clock Min"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                gvDis2.Columns["Act Eff%"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                gvDis2.Columns["TotalAct Eff%"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                if (cbbWorkshift.SelectedIndex == 0)
                {
                    gvDis2.Columns["12:00"].Width = 15;
                    gvDis2.Columns["12:00"].HeaderCell.Style.ForeColor = SystemColors.Control;//
                    gvDis2.Columns["12:00"].DefaultCellStyle.ForeColor = SystemColors.Control;
                    gvDis2.Columns["21:00"].Width = 15;
                    gvDis2.Columns["21:00"].HeaderCell.Style.ForeColor = SystemColors.Control;//
                    gvDis2.Columns["21:00"].DefaultCellStyle.ForeColor = SystemColors.Control;
                }

            }

            TimerRefreshFirst.Stop();
            visible_Table();
            AdjustRowHeightToFitScreen(gvDis2);
        }

        int RowIndex = -1;
        private void gvDis2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                RowIndex = e.RowIndex;

            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (gvDis2.Rows.Count > 0)
            {
                ExportToExcel(gvDis2);
            }
        }
        private void ExportToExcel(DataGridView dataGridView)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");

                // Export Header
                int countColumnVisible1 = 0;
                for (int i = 0; i < dataGridView.Columns.Count; i++)
                {
                    if (dataGridView.Columns[i].Visible)
                    {
                        worksheet.Cells[1, i + 1 - countColumnVisible1].Value = dataGridView.Columns[i].HeaderText;
                    }
                    else
                    {
                        countColumnVisible1++;
                    }
                }

                // Export Data
                int rowIndex = 2; // เริ่มจากแถวที่ 2 เพราะแถวที่ 1 เป็น Header
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    if (!dataGridView.Rows[i].IsNewRow) // ข้ามแถวว่างสุดท้าย
                    {
                        int countColumnVisible2 = 0;
                        for (int j = 0; j < dataGridView.Columns.Count; j++)
                        {
                            if (dataGridView.Columns[j].Visible)
                            {
                                int jj = j + 1 - countColumnVisible2;
                                worksheet.Cells[rowIndex, jj].Value = dataGridView.Rows[i].Cells[j].Value;

                                // ตั้งค่าสีพื้นหลัง
                                Color cellColor = dataGridView.Rows[i].Cells[j].Style.BackColor;
                                if (cellColor != Color.Empty)
                                {
                                    worksheet.Cells[rowIndex, jj].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                    worksheet.Cells[rowIndex, jj].Style.Fill.BackgroundColor.SetColor(cellColor);
                                    worksheet.Cells[rowIndex, jj].Style.Font.Color.SetColor(Color.Black);
                                }
                            }
                            else
                            {
                                countColumnVisible2++;
                            }
                        }
                        rowIndex++; // เพิ่ม index แถวสำหรับ Excel
                    }
                }

                // บันทึกไฟล์
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                    saveFileDialog.FilterIndex = 2;
                    saveFileDialog.RestoreDirectory = true;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        FileInfo file = new FileInfo(saveFileDialog.FileName);
                        excelPackage.SaveAs(file);
                    }
                }
            }
        }
        private void cbbReportMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbReportMode.SelectedIndex == 0)
            {
                colSoStyle = "Style";
            }
            else if (cbbReportMode.SelectedIndex == 1)
            {
                colSoStyle = "SO";
            }
            if (formLoadfirstTimeNotLoad)
            {
                loadForm("TKC");
            }

        }
        /// Show column time
        private void visible_Table()
        {

            int fontSize = int.Parse(tbFontSize.Text);
            if (cbbShowData.SelectedIndex == 0) // Show All
            {

                if (gvDis2.ColumnCount > 0)
                {
                    for (int i = 0; i < gvDis2.Columns.Count; i++)
                    {
                        if ((i > 3 && i < 15) || i > pcs_Act_columnIndex)
                        {
                            gvDis2.Columns[i].Visible = (cbbShowData.SelectedIndex == 0);
                        }

                        // Get row height and adjust font size dynamically
                        int rowHeight = gvDis2.RowTemplate.Height;
                        // Ensures minimum font size of 9

                        if ((i > 3 && i < 15) || i > pcs_Act_columnIndex)
                        {
                            gvDis2.Columns[i].DefaultCellStyle.Font = new Font("Bahnschrift", fontSize, FontStyle.Regular);
                        }
                        else
                        {

                            gvDis2.Columns[i].DefaultCellStyle.Font = new Font("Bahnschrift", fontSize + 2, FontStyle.Regular);

                        }
                    }
                }

                if (gvDis2.Rows.Count > 0)
                {
                    int lastRowIndex = gvDis2.Rows.Count - 1;
                    int lastRowHeight = gvDis2.Rows[lastRowIndex].Height;


                    gvDis2.Rows[lastRowIndex].DefaultCellStyle.Font = new Font("Bahnschrift", fontSize, FontStyle.Regular);
                }

            }
            else if (cbbShowData.SelectedIndex == 1) // Show Output Only
            {


                if (gvDis2.ColumnCount > 0)
                {
                    for (int i = 0; i < gvDis2.Columns.Count; i++)
                    {
                        if ((i > 3 && i < 15) || i > pcs_Act_columnIndex)
                        {
                            gvDis2.Columns[i].Visible = (cbbShowData.SelectedIndex == 0);
                        }

                        // Get row height and adjust font size dynamically
                        int rowHeight = gvDis2.RowTemplate.Height;


                        if ((i > 3 && i < 15) || i > 32)
                        {
                            // gvDis2.Columns[i].DefaultCellStyle.Font = new Font("Bahnschrift", fontSize, FontStyle.Regular);
                        }
                        else
                        {

                            gvDis2.Columns[i].DefaultCellStyle.Font = new Font("Bahnschrift", fontSize + 3, FontStyle.Regular);

                        }
                    }
                }


                if (gvDis2.Rows.Count > 0)
                {
                    int lastRowIndex = gvDis2.Rows.Count - 1;
                    int lastRowHeight = gvDis2.Rows[lastRowIndex].Height;


                    gvDis2.Rows[lastRowIndex].DefaultCellStyle.Font = new Font("Bahnschrift", fontSize + 4, FontStyle.Regular);
                }
            }
            if (gvDis2.Rows.Count > 0)
            {
                gvDis2.Invalidate();
                //MoveRowToLast(colSoStyle, "SUM");

            }
            // gvDis2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


        }

        int resize = 1;
        private void AdjustRowHeightToFitScreen(Guna2DataGridView gvDis2)
        {
            // Ensure AutoSizeRowsMode is disabled
            gvDis2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            // Get the total available height (exclude headers if necessary)
            int totalHeight = gvDis2.Height;
            if (gvDis2.ColumnHeadersVisible)
            {
                totalHeight -= gvDis2.ColumnHeadersHeight; // Subtract header height
            }

            // Get the number of rows
            int rowCount = gvDis2.Rows.Count;
            if (rowCount == 0) return; // Prevent division by zero if no rows

            // Calculate the row height
            int rowHeight = totalHeight / rowCount;

            // Apply the calculated height to all rows
            foreach (DataGridViewRow row in gvDis2.Rows)
            {
                row.Height = rowHeight / resize;
            }
        }

        private void cbbShowData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbShowData.SelectedIndex == 0)
            {
                //  MessageBox.Show(Properties.Settings.Default.FontSizeCuttingReportViewAll.ToString());
                tbFontSize.Text = Properties.Settings.Default.FontSizeCuttingReportViewAll.ToString();
            }
            else if (cbbShowData.SelectedIndex == 1)
            {
                tbFontSize.Text = Properties.Settings.Default.FontSizeCuttingReportViewOutput.ToString();
            }
            visible_Table();
        }

        private void cbbBuilding_TextChanged(object sender, EventArgs e)
        {
            //if (cbbBuilding.SelectedIndex == 0)
            //{
            //    loadForm("TKC");
            //}
            //else if (cbbBuilding.SelectedIndex == 1)
            //{
            //    loadForm("TKC1");
            //}
            //else if (cbbBuilding.SelectedIndex == 2)
            //{
            //    loadForm("TKC2");
            //}
        }
        private void AddAndMoveRow(string columnName, object[] newRowData)
        {
            DataTable dt = (DataTable)gvDis2.DataSource;
            if (dt == null) return;

            // Step 1️⃣: Add new row
            dt.Rows.Add(newRowData);
            string newValue = newRowData[Array.IndexOf(dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToArray(), columnName)].ToString();

            // Step 2️⃣: Extract all rows and sort them correctly
            List<object[]> sortedRows = dt.Rows.Cast<DataRow>()
                .Select(row => row.ItemArray)
                .OrderBy(row => ExtractNumericValue(row[Array.IndexOf(dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToArray(), columnName)].ToString()))
                .ToList();

            // Step 3️⃣: Clear table and re-add sorted rows
            dt.Rows.Clear();
            foreach (var row in sortedRows)
            {
                dt.Rows.Add(row);
            }

            // Step 4️⃣: Rebind the DataGridView
            gvDis2.DataSource = dt;
        }

        // Helper Function: Extract numeric value for sorting
        private int ExtractNumericValue(string text)
        {
            // Extract numbers from a string (e.g., "TK101" → 101, "TKS102" → 102)
            string numericPart = new string(text.Where(char.IsDigit).ToArray());
            return int.TryParse(numericPart, out int result) ? result : 0;
        }
        int Eff_Act_columnIndex = -1;
        int pcs_Act_columnIndex = -1;
        private void cbbWorkshift_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbWorkshift.SelectedIndex > -1)
            {
                Properties.Settings.Default.workShift = cbbWorkshift.SelectedIndex;
                Properties.Settings.Default.Save();

                if (cbbWorkshift.SelectedIndex == 0)
                {
                    Eff_Act_columnIndex = 36;
                    pcs_Act_columnIndex = 33;
                }
                else if (cbbWorkshift.SelectedIndex == 1)
                {
                    Eff_Act_columnIndex = 43;
                    pcs_Act_columnIndex = 40;
                }
                if (formLoadfirstTimeNotLoad)
                { loadForm("TKC"); }
            }
        }

        private void btFontsize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Prevent the character from being entered
            }
        }

        private void btSaveFontSize_Click(object sender, EventArgs e)
        {
            if (cbbShowData.SelectedIndex == 0)
            {
                if (tbFontSize.Text.Length > 0)
                {
                    Properties.Settings.Default.FontSizeCuttingReportViewAll = int.Parse(tbFontSize.Text);
                    Properties.Settings.Default.Save();
                    MessageBox.Show(tbFontSize.Text);
                }
                else
                {
                    MessageBox.Show("Please Add Number");
                }
            }
            else if (cbbShowData.SelectedIndex == 1)
            {
                if (tbFontSize.Text.Length > 0)
                {
                    Properties.Settings.Default.FontSizeCuttingReportViewOutput = int.Parse(tbFontSize.Text);
                    Properties.Settings.Default.Save();
                }
                else
                {
                    MessageBox.Show("Please Add Number");
                }
            }
            if (cbbReportMode.SelectedIndex > -1)
            {
                visible_Table();
            }
        }
    }
}
