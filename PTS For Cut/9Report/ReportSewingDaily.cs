using Guna.UI2.WinForms;
using Microsoft.Scripting.Utils;
using OfficeOpenXml;
using PTS_For_Cut.Main;
using PTS_For_Cut.myClass;
using PTS_For_Cut.Myclass;
using System.Data;
using DataTable = System.Data.DataTable;
using Font = System.Drawing.Font;

// Set the license context before using EPPlus
//
namespace PTS_For_Cut._9Report
{
    public partial class ReportSewingDaily : Form
    {
        public ReportSewingDaily()
        {
            InitializeComponent();
            //
        }
        string colSoStyle = "";
        private void btDataReport_Click(object sender, EventArgs e)
        {
            reportSewingDatapara reportSewingDatapara = new reportSewingDatapara();
            reportSewingDatapara.Show();
        }
        string Lastline_Load = "";
        private void btLoad_Click(object sender, EventArgs e)
        {         
            loadForm(Lastline_Load);
        }
        private void DataInTable()
        {
            if (gvDis2.Rows.Count > 0)
            {
                string txtDate = setDate(dtpDate);
                if (DateNow() == txtDate)
                {
                    toolStripLabel3.Visible = true;
                    toolStripLabel7.Visible = true;
                    toolStripLabel5.Visible = true;
                    lbTime.Visible = true;
                    lbMinute.Visible = true;
                    checkHrsNow();
                }
                else
                {
                    //  pnLastTime.Visible = false;
                    toolStripLabel3.Visible = false;
                    toolStripLabel7.Visible = false;
                    toolStripLabel5.Visible = false;
                    lbTime.Visible = false;
                    lbMinute.Visible = false;
                }

                double TotalEarnMinRow = 0;
                double TotalclockMin = 0;
                double TTotalPcs = 0;
                int TTotalDiff = 0;
                int[] keepindexnotsetTarget_ar;
                //List<int> keepindexnotsetTarget_ls = new List<int> { };
                int All_QTY = 0;
                for (int i = 0; i < gvDis2.RowCount - 1; i++)
                {
                    //string lineStructure = gvDis2.Rows[i].Cells["Line"].Value.ToString().Trim();
                    //string soStructure = gvDis2.Rows[i].Cells[colSoStyle].Value.ToString().Trim(); //so syle


                    //gvDis2.Rows[i].Cells["Act PCS."].Value = 
                    // MessageBox.Show(gvDis2.Rows[i].Cells["TimeAct"].Value.ToString());



                    double sam = string.IsNullOrEmpty(gvDis2.Rows[i].Cells["SAM"].Value?.ToString())
                        ? 0
                        : double.Parse(gvDis2.Rows[i].Cells["SAM"].Value.ToString());

                    double manAc = string.IsNullOrEmpty(gvDis2.Rows[i].Cells["ManAct"].Value?.ToString())
                        ? 0
                        : double.Parse(gvDis2.Rows[i].Cells["ManAct"].Value.ToString());

                    double TimeAc = string.IsNullOrEmpty(gvDis2.Rows[i].Cells["TimeAct"].Value?.ToString())
                        ? 0
                        : double.Parse(gvDis2.Rows[i].Cells["TimeAct"].Value.ToString()) * 60;
                    //Fc PCS/Hr

                    double FcPCShr = string.IsNullOrEmpty(gvDis2.Rows[i].Cells["Fc PCS/Hr"].Value?.ToString())
                       ? 0
                       : double.Parse(gvDis2.Rows[i].Cells["Fc PCS/Hr"].Value.ToString());

                    bool check1800 = false;
                    double timeMin = 0;
                    if (gvDis2.Rows[i].Cells["18:00 19:00"].Value.ToString() != "")
                    { check1800 = true; }
                    if (txtDate == DateNow())
                    {
                        timeMin = checkHrsNow(check1800);
                        //MessageBox.Show(timeHrs.ToString());
                        if (timeMin >= TimeAc)
                        {
                            timeMin = TimeAc;
                        }
                        else
                        {
                            timeMin = timeMin;
                        }
                    }
                    else
                    {
                        timeMin = TimeAc;
                    }
                    //timeHrs = TimeAc;
                    int pcsAllLine = 0;
                    for (int j = 16; j < gvDis2.Columns.Count - 6; j++)
                    {
                        //pcsAllLine+=int

                        string qty_table = gvDis2.Rows[i].Cells[j].Value?.ToString().Trim();
                        pcsAllLine += string.IsNullOrEmpty(qty_table) ? 0 : int.Parse(qty_table);


                    }
                    gvDis2.Rows[i].Cells["Act PCS."].Value = pcsAllLine.ToString("#,##0.#");
                    double EarnMinRow = pcsAllLine * sam;
                    double clockMin = manAc * timeMin;
                    int diff = pcsAllLine - (int)(FcPCShr * (timeMin / 60));

                    string txtDiff = diff.ToString("#,##0.#");
                    if (diff > 0)
                    {
                        txtDiff = "+" + diff.ToString("#,##0.#");
                    }
                    else
                    {
                        TTotalDiff += diff;
                    }



                    gvDis2.Rows[i].Cells["Diff"].Value = txtDiff;
                    gvDis2.Rows[i].Cells["Earn Min"].Value = EarnMinRow.ToString("#,##0.#");
                    gvDis2.Rows[i].Cells["Clock Min"].Value = clockMin.ToString("#,##0.#");
                    double eff = (EarnMinRow / clockMin) * 100;
                    if (eff > 0)
                    {
                        //if (cbbReportMode.SelectedIndex == 0)   ----------------------------------------Eff
                        //{
                        string txtEff = eff.ToString("#,##0.#");

                        gvDis2.Rows[i].Cells["Act Eff%"].Value = txtEff + "%";
                        // }
                    }
                    else
                    {
                        gvDis2.Rows[i].Cells["Act Eff%"].Value = "0%";
                    }


                    TotalEarnMinRow += double.Parse(gvDis2.Rows[i].Cells["Earn Min"].Value.ToString());
                    TotalclockMin += double.Parse(gvDis2.Rows[i].Cells["Clock Min"].Value.ToString());
                    TTotalPcs += double.Parse(gvDis2.Rows[i].Cells["Act PCS."].Value.ToString());
                }
                //for (int k = 0; k < dtHrOutput.Rows.Count; k++)
                //{
                //    string qty = dtHrOutput.Rows[k]["QTY"].ToString().Trim();
                //    //MessageBox.Show("SSS");
                //    //

                //    int x = int.Parse(qty);
                //    All_QTY += x;

                //}

                gvDis2.Rows[gvDis2.Rows.Count - 1].Cells["Earn Min"].Value = TotalEarnMinRow.ToString("#,##0.#");
                gvDis2.Rows[gvDis2.Rows.Count - 1].Cells["Clock Min"].Value = TotalclockMin.ToString("#,##0.#");
                gvDis2.Rows[gvDis2.Rows.Count - 1].Cells["Act PCS."].Value = TTotalPcs.ToString("#,##0");
                gvDis2.Rows[gvDis2.Rows.Count - 1].Cells["TotalAct Eff%"].Value = (TotalEarnMinRow / TotalclockMin * 100).ToString("#,##0.#") + "%";
                gvDis2.Rows[gvDis2.Rows.Count - 1].Cells["Diff"].Value = TTotalDiff.ToString();

                for (int i = 16; i < gvDis2.Columns.Count - 7; i++)//.ForeColor = Color.Red;
                {
                    double QTYColumn = 0;
                    // gvDis2.Columns[i].DefaultCellStyle.Font = new Font("Bahnschrift", 10, FontStyle.Regular); //new Font("Bahnschrift Condensed", 15F, GraphicsUnit.Pixel);
                    for (int j = 0; j < gvDis2.RowCount - 1; j++)
                    {
                        string xx = gvDis2.Rows[j].Cells[i].Value.ToString();
                        if (xx == "") xx = "0";
                        QTYColumn += int.Parse(xx);
                    }
                    gvDis2.Rows[gvDis2.Rows.Count - 1].Cells[i].Value = QTYColumn.ToString("#,##0.#");
                    // MessageBox.Show(QTYColumn.ToString("#,##0.#"));
                }
                for (int i = 0; i < gvDis2.Rows.Count; i++)
                {
                    var gv2 = gvDis2.Rows[i];
                    for (int j = 0; j < dtRFT.Rows.Count; j++)
                    {
                        var dt_rft = dtRFT.Rows[j];
                        if (gv2.Cells["Line"].Value.ToString() == dt_rft["Line"].ToString()
                            && gv2.Cells[colSoStyle].Value.ToString() == dt_rft[colSoStyle].ToString())
                        {
                            gv2.Cells["RFT"].Value = dt_rft["RFT"].ToString();
                        }
                    }

                }



                chColor = false;
                TimerRefreshFirst.Start();
            }
        }
        private void checkHrsNow()
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

        bool firstTimeNoLoad = false;
        private void ReportSewingDaily_Load(object sender, EventArgs e)
        {
            firstTimeNoLoad = false;

            cbbShow.SelectedIndex = Properties.Settings.Default.Sewing_Daily_Show;
            cbbReportMode.SelectedIndex = 0;
            dtpDate.Value = DateTime.Now;
            cbbBuilding.SelectedIndex = 0;
            if (Properties.Settings.Default.DirectReport == 2 || HomePage.ins.checkPermiss("SewingRefresh"))
            {
                timerRefresh.Enabled = true;
            }
            SetUpPosition.CenterLabelInPanel(lbHeader, pnlbHeader);

            Lastline_Load = "";
            loadForm(Lastline_Load);

            firstTimeNoLoad = true;
        }

        DataTable dtLoadTarget = new DataTable();
        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            if (firstTimeNoLoad)
            {
                if (Properties.Settings.Default.DirectReport > -1)
                {
                    timerRefresh.Start();
                }
                
                loadForm(Lastline_Load);
            }
        }
        DataTable dtRFT = new DataTable();

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
            dtStructure.Columns.Add("Run Date");
            dtStructure.Columns.Add("Man");
            dtStructure.Columns.Add("ManAct");
            dtStructure.Columns.Add("Time");
            dtStructure.Columns.Add("TimeAct");
            dtStructure.Columns.Add("Plan Eff%");
            dtStructure.Columns.Add("Plan PCS");
            dtStructure.Columns.Add("Plan PCS/Hr");
            dtStructure.Columns.Add("Fc Eff%");
            dtStructure.Columns.Add("Fc PCS");
            dtStructure.Columns.Add("Fc PCS/Hr");
            dtStructure.Columns.Add("08:00 09:00");
            dtStructure.Columns.Add("09:00 10:00");
            dtStructure.Columns.Add("10:00 11:00");
            dtStructure.Columns.Add("11:00 12:00");
            dtStructure.Columns.Add("12:00");
            dtStructure.Columns.Add("13:00 14:00");
            dtStructure.Columns.Add("14:00 15:00");
            dtStructure.Columns.Add("15:00 16:00");
            dtStructure.Columns.Add("16:00 17:00");
            dtStructure.Columns.Add("17:00 18:00");
            dtStructure.Columns.Add("18:00 19:00");
            dtStructure.Columns.Add("19:00 20:00");
            dtStructure.Columns.Add("20:00 21:00");
            dtStructure.Columns.Add("21:00 22:00");
            dtStructure.Columns.Add("22:00 23:00");
            dtStructure.Columns.Add("23:00 24:00");

            dtStructure.Columns.Add("Act PCS.");
            dtStructure.Columns.Add("Diff");
            dtStructure.Columns.Add("RFT");
            dtStructure.Columns.Add("Earn Min");
            dtStructure.Columns.Add("Clock Min");
            dtStructure.Columns.Add("Act Eff%");
            dtStructure.Columns.Add("TotalAct Eff%");

            gvDis2.DataSource = dtStructure;
            //gvDis2.Columns["12:00"].Width = 32;
            //gvDis2.Columns["Line"].Width = 70;
            //gvDis2.Columns["SO"].Width = 160;
            this.gvDis2.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            foreach (DataGridViewColumn column in gvDis2.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

            }
            gvDis2.Columns[3].Frozen = true; //so style
            gvDis2.Columns[2].Frozen = true;
            DataTable dtHrOutput = new DataTable();
            string txtDate = setDate(dtpDate);
            if (cbbReportMode.SelectedIndex == 0)
            {
                dtHrOutput = ConnectMySQL.MySQLtoDataTable(@"SELECT IF(DATE_FORMAT(`a`.`sb_scantime`, '%H') = '12', '11:00', DATE_FORMAT(`a`.`sb_scantime`, '%H:00')) AS `Time`,`b`.`Style`,`a`.`sb_lineno`,MAX(c.Brand) AS Brand,
                   IFNULL(SUM(`a`.`sb_qty`),0)AS`QTY` FROM `b_scaned_bundle` AS `a` 
                            LEFT JOIN (
                                    SELECT DISTINCT `SO`, `Style`, `Brand`
                                    FROM `so_tb`
                                ) AS c ON a.`SO` = c.`SO`
                   JOIN `a_a1_spreading_list_tb` AS `b` ON `a`.`sb_sdlistdocno`=`b`.`SD_ListDoc_No` AND `b`.`FabricType` LIKE 'A' AND `b`.`SD_Status` LIKE '1' 
                   
                   WHERE DATE(`a`.`sb_scantime`)='" + txtDate + "' AND `a`.`sb_lineno` LIKE '%" + txt + "%' GROUP BY `b`.`Style`,`a`.`sb_lineno`,`Time` ORDER BY `a`.`sb_lineno`,`b`.`Style`, `Time` ASC;");

                dtLoadTarget = ConnectMySQL.MySQLtoDataTable("SELECT  `a`.`Date`, `a`.`Line`,`e`.`Brand`, `e`.`Style`, ROUND(`a`.`SAM`, 2) AS `SAM`,SUM(`a`.`RunDate`) AS `RunDate`, `a`.`ManTarget`," +
                    " `a`.`ManActual`, `a`.`Jupper`, SUM( `a`.`TimeTarget`)AS `TimeTarget`, SUM( `a`.`TimeActual`) AS `TimeActual`, `a`.`EffTargetplan`, `a`.`EffTargetForecast`" +
                    " FROM `a_setuptargetforproduction` AS `a` " +
                    "LEFT JOIN ( SELECT `SO`, MAX(`Style`) AS `Style` ,`Brand` FROM `so_tb` GROUP BY `SO` ) AS `e` ON `e`.SO = `a`.SO WHERE `a`.`Type`= 'sew' AND DATE(`a`.`Date`)='" + txtDate + "' " +
                    "AND `a`.`Line` LIKE '%" + txt + "%' GROUP BY `a`.`Line`, `e`.`Style` ORDER BY `a`.`Line` ASC;");
                dtRFT = ConnectMySQL.MySQLtoDataTable(@"SELECT 
                                                            a.`sb_lineno` AS Line,
                                                               c.`Style`,
                                                                COUNT(CASE WHEN a.rft_status = 1 THEN 1 END) AS matched_count,
                                                                COUNT(*) AS total_count,
                                                                ROUND(
                                                                    COUNT(CASE WHEN a.rft_status = 1 THEN 1 END) / COUNT(*) * 100, 2
                                                                ) AS RFT
                                                            FROM 
                                                                b_scaned_bundle a
                                                                 LEFT JOIN (
                                                                     SELECT DISTINCT `SO`, `Style`, `Brand`
                                                                     FROM `so_tb`
                                                                 ) AS c ON a.`SO` = c.`SO`
                                                            WHERE 
                                                                DATE(a.pkg_date) = '" + txtDate + @"'
                                                            GROUP BY 
                                                                a.`sb_lineno`,c.`Style`;");
            }
            else if (cbbReportMode.SelectedIndex == 1)
            {
                dtHrOutput = ConnectMySQL.MySQLtoDataTable(@"SELECT IF(DATE_FORMAT(`a`.`sb_scantime`, '%H') = '12', '11:00', DATE_FORMAT(`a`.`sb_scantime`, '%H:00')) AS `Time`,`a`.`SO`,`a`.`sb_lineno`,MAX(c.Brand) AS Brand,
                   IFNULL(SUM(`a`.`sb_qty`),0)AS`QTY` FROM `b_scaned_bundle` AS `a` 
                     LEFT JOIN (
                                    SELECT DISTINCT `SO`, `Brand`
                                    FROM `so_tb`
                                ) AS c ON a.`SO` = c.`SO`
                   JOIN `a_a1_spreading_list_tb` AS `b` ON `a`.`sb_sdlistdocno`=`b`.`SD_ListDoc_No` AND `b`.`FabricType` LIKE 'A' AND `b`.`SD_Status` LIKE '1' 
                   
                   WHERE DATE(`a`.`sb_scantime`)='" + txtDate + "' AND `a`.`sb_lineno` LIKE '%" + txt + "%' GROUP BY `a`.`SO`,`a`.`sb_lineno`,`Time` ORDER BY `a`.`sb_lineno`,`a`.`SO`, `Time` ASC;");

                dtLoadTarget = ConnectMySQL.MySQLtoDataTable("SELECT `a`.`Date`, `a`.`Line`,`e`.`Brand`, `a`.`SO`, ROUND(`a`.`SAM`, 2) AS `SAM` ,`a`.`RunDate`, `a`.`ManTarget`, `a`.`ManActual`, `a`.`Jupper`, `a`.`TimeTarget`, " +
                  "`a`.`TimeActual`, `a`.`EffTargetplan`, `a`.`EffTargetForecast` " +
                  "FROM `a_setuptargetforproduction` AS `a`" +
                  "LEFT JOIN ( SELECT `SO`,`Brand` FROM `so_tb` GROUP BY `SO` ) AS `e` ON `e`.SO = `a`.SO " +
                  "WHERE `a`.`Type`= 'sew' AND DATE(`a`.`Date`)='" + txtDate + "' AND `a`.`Line` LIKE '%" + txt + "%' GROUP BY `a`.`Line`,`a`.`SO` ORDER BY `a`.`Line` ASC");

                dtRFT = ConnectMySQL.MySQLtoDataTable(@"SELECT 
                                    a.`sb_lineno` AS Line,
                                        a.SO,
                                        COUNT(CASE WHEN a.rft_status = 1 THEN 1 END) AS matched_count,
                                        COUNT(*) AS total_count,
                                        ROUND(
                                            COUNT(CASE WHEN a.rft_status = 1 THEN 1 END) / COUNT(*) * 100, 2
                                        ) AS RFT
                                    FROM 
                                        b_scaned_bundle a
    
                                    WHERE 
                                         DATE(a.pkg_date) = '" + txtDate + @"'
                                    GROUP BY 
                                       a.`sb_lineno`,a.SO;");
            }

            DataTable newdt = new DataTable();
            newdt = (DataTable)gvDis2.DataSource;
            //if (dtHrOutput.Rows.Count > 0)
            //{

            string Subline = "";
            string Subso = "";
            string Subtime = "";
            string Subqty = "";

            int countRows = 0;

            for (int i = 0; i < dtHrOutput.Rows.Count; i++)
            {
                string line = dtHrOutput.Rows[i]["sb_lineno"].ToString();
                string so = dtHrOutput.Rows[i][colSoStyle].ToString();
                string time = dtHrOutput.Rows[i]["Time"].ToString();
                string qty = dtHrOutput.Rows[i]["QTY"].ToString();
                string brand = dtHrOutput.Rows[i]["Brand"].ToString();
                // MessageBox.Show(line +"!="+ Subline + "--"+ so +"!="+ Subso);

                if (i == 0)
                {
                    countRows++;
                    newdt.Rows.Add(countRows.ToString(), line, brand, so);
                }
                else
                if (line != Subline || so != Subso)
                {
                    countRows++;
                  
                    newdt.Rows.Add(countRows.ToString(), line, brand, so);
                }
                for (int j = 16; j < newdt.Columns.Count - 6; j++)
                {

                    string columnName = newdt.Columns[j].ColumnName.Substring(0, 5);
                    if (time == columnName)
                    {
                        newdt.Rows[newdt.Rows.Count - 1][j] = qty;

                    }

                    Subline = line;
                    Subso = so;
                    Subtime = time;
                    Subqty = qty;

                }
            }

            for (int i = 0; i < dtLoadTarget.Rows.Count; i++)
            {
                bool checkAddLine = false;
                for (int j = 0; j < newdt.Rows.Count; j++)//colSoStyle
                {
                    if (dtLoadTarget.Rows[i]["Line"].ToString() == newdt.Rows[j]["Line"].ToString()
                        && dtLoadTarget.Rows[i][colSoStyle].ToString() == newdt.Rows[j][colSoStyle].ToString())
                    {
                        checkAddLine = true;
                        break;
                    }
                }
                if (!checkAddLine)
                {
                    
                    object[] newRow = { newdt.Rows.Count + 1, dtLoadTarget.Rows[i]["Line"].ToString(), dtLoadTarget.Rows[i]["Brand"].ToString(), dtLoadTarget.Rows[i][colSoStyle].ToString() };
                    AddAndMoveRow("Line", newRow);

                }
            }


            //newdt.DefaultView.Sort = "Line ASC";
            lbtimeNow();

            if (dtLoadTarget.Rows.Count > 0)
            {

                double Mmantar = 0;
                double MmanAc = 0;
                double Ttime = 0;
                double TtimeAc = 0;
                double PplPcs = 0;
                double IintplPcsHr = 0;
                double plSamAll = 0;

                double FfePcs = 0;
                double IintfePcsHr = 0;
                double feSamAll = 0;

                for (int i = 0; i < gvDis2.Rows.Count; i++)
                {
                    var gv = gvDis2.Rows[i];
                    for (int k = 0; k < dtLoadTarget.Rows.Count; k++)
                    {
                        var tr = dtLoadTarget.Rows[k];
                        if (gv.Cells["Line"].Value.ToString() == tr["Line"].ToString()
                            && gv.Cells[colSoStyle].Value.ToString() == tr[colSoStyle].ToString())
                        {
                            //gv.Cells["SAM"].Value = tr["SAM"];
                            //gv.Cells["ManAct"].Value = tr["ManAct"];
                            //gv.Cells["TimeAct"].Value = tr["TimeAct"];
                            //gv.Cells["Fc PCS"].Value = tr["TotalPCS"];

                            string no = (newdt.Rows.Count + 1).ToString();
                            string Line = tr["Line"].ToString();
                            string Brand = tr["Brand"].ToString();
                            string so = tr[colSoStyle].ToString();
                            string sam = tr["SAM"].ToString();
                            string RunDate = tr["RunDate"].ToString();
                            string planEff = tr["EffTargetplan"].ToString();
                            double plEff = double.Parse(planEff) / 100;
                            string forecastEff = tr["EffTargetForecast"].ToString();
                            double fcEff = double.Parse(forecastEff) / 100;
                            string manTar = tr["ManTarget"].ToString();
                            double intMantar = double.Parse(manTar);
                            Mmantar += intMantar;
                            string manAc = tr["ManActual"].ToString();
                            string jupper = tr["Jupper"].ToString();
                            double SumManAc = int.Parse(manAc) + int.Parse(jupper);
                            MmanAc += SumManAc;
                            double intSam = double.Parse(sam);

                            string time = tr["TimeTarget"].ToString();
                            double timeWorkTarSec = double.Parse(time) * 60;
                            Ttime += (double.Parse(time) * intMantar);
                            double plPcs = Math.Round((plEff * intMantar * timeWorkTarSec) / intSam, 0, MidpointRounding.AwayFromZero);
                            PplPcs += plPcs;
                            plSamAll += (plPcs * intSam);
                            double plpcsHr = Math.Round(plPcs / double.Parse(time), 0, MidpointRounding.AwayFromZero);
                            var intplPcsHr = Math.Round(plpcsHr, 0, MidpointRounding.AwayFromZero);
                            IintplPcsHr += intplPcsHr;

                            string TimeAc = tr["TimeActual"].ToString();
                            double timeWorkAcSec = double.Parse(TimeAc) * 60;
                            TtimeAc += (double.Parse(TimeAc) * SumManAc);
                            double fcPcs = Math.Round((fcEff * SumManAc * timeWorkAcSec) / intSam, 0, MidpointRounding.AwayFromZero);
                            FfePcs += fcPcs;
                            feSamAll += (fcPcs * intSam);
                            double fcpcsHr = fcPcs / double.Parse(TimeAc);
                            IintfePcsHr += fcpcsHr;

                            gv.Cells["SAM"].Value = tr["SAM"];
                            gv.Cells["Run Date"].Value = tr["RunDate"];
                            gv.Cells["Man"].Value = tr["ManTarget"];
                            gv.Cells["ManAct"].Value = SumManAc.ToString();
                            gv.Cells["Time"].Value = tr["TimeTarget"];
                            gv.Cells["TimeAct"].Value = tr["TimeActual"];
                            gv.Cells["Plan Eff%"].Value = planEff.ToString() + "%";
                            gv.Cells["Plan PCS"].Value = plPcs.ToString("#,##0.##");
                            gv.Cells["Plan PCS/Hr"].Value = intplPcsHr.ToString("#,##0.##");
                            gv.Cells["Fc Eff%"].Value = forecastEff.ToString() + "%";
                            gv.Cells["Fc PCS"].Value = fcPcs.ToString("#,##0.##");
                            gv.Cells["Fc PCS/Hr"].Value = fcpcsHr.ToString("#,##0.##");

                        }
                    }

                }

                double PplEff = plSamAll / (Ttime * 60) * 100;
                double FfcEff = feSamAll / (TtimeAc * 60) * 100;
                newdt.Rows.Add(
                    "", "", "", "SUM", "", "", Mmantar.ToString("#,##0.##"), MmanAc.ToString("#,##0.##"), Ttime.ToString("#,##0.##"),
                    TtimeAc.ToString("#,##0.##"), PplEff.ToString("##.#") + "%", PplPcs.ToString("#,##0.##"), IintplPcsHr.ToString("#,##0.##"),
                    FfcEff.ToString("##.#") + "%", FfePcs.ToString("#,##0.##"), IintfePcsHr.ToString("#,##0.##")
                    );
            }
            else
            {
                newdt.Rows.Clear();
            }

            gvDis2.DataSource = newdt;

            for (int i = 0; i < gvDis2.RowCount - 1; i++)
            {
                gvDis2.Rows[i].Cells["No."].Value = i + 1;
            }
            //}

            DataInTable();
        }
        private string setDate(Guna2DateTimePicker dtpDate)
        {
            string txtDate = "";
            System.Globalization.CultureInfo _cultureEnInfo = new System.Globalization.CultureInfo("en-US");
            DateTime date = Convert.ToDateTime(dtpDate.Value, _cultureEnInfo);
            txtDate = date.ToString("yyyy-MM-dd", _cultureEnInfo);
            return txtDate;
        }
        private string DateNow()
        {
            string txtDate = "";
            System.Globalization.CultureInfo _cultureEnInfo = new System.Globalization.CultureInfo("en-US");
            DateTime date = Convert.ToDateTime(DateTime.Now, _cultureEnInfo);
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



        private void timerRefresh_Tick(object sender, EventArgs e)
        {

            //loadForm("");
        }
        string chLine = "";
        bool chColor = false;


        private void btExcel_Click(object sender, EventArgs e)
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
                // Export data
                int countColumnVisible1 = 0;
                for (int i = 0; i < gvDis2.Columns.Count; i++)
                {
                    if (dataGridView.Columns[i].Visible == true)
                    {
                        worksheet.Cells[1, i + 1 - countColumnVisible1].Value = gvDis2.Columns[i].HeaderText;
                    }
                    else
                    {
                        countColumnVisible1++;
                    }
                }

                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    int countColumnVisible2 = 0;
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        if (dataGridView.Columns[j].Visible == true)
                        {
                            int jj = j + 1 - countColumnVisible2;
                            worksheet.Cells[i + 2, jj].Value = dataGridView.Rows[i].Cells[j].Value;

                            if (dataGridView.Rows[i].Cells[j].Style.BackColor == Color.Lime)
                            {
                                worksheet.Cells[i + 2, jj].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                worksheet.Cells[i + 2, jj].Style.Fill.BackgroundColor.SetColor(Color.Lime);
                                worksheet.Cells[i + 2, jj].Style.Font.Color.SetColor(Color.Black);
                            }
                            else if (dataGridView.Rows[i].Cells[j].Style.BackColor == Color.Red)
                            {
                                worksheet.Cells[i + 2, jj].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                worksheet.Cells[i + 2, jj].Style.Fill.BackgroundColor.SetColor(Color.Red);
                                worksheet.Cells[i + 2, jj].Style.Font.Color.SetColor(Color.Black);
                            }
                            else if (dataGridView.Rows[i].Cells[j].Style.BackColor == Color.LightCoral)
                            {
                                worksheet.Cells[i + 2, jj].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                worksheet.Cells[i + 2, jj].Style.Fill.BackgroundColor.SetColor(Color.LightCoral);
                                worksheet.Cells[i + 2, jj].Style.Font.Color.SetColor(Color.Black);
                            }
                            else if (dataGridView.Rows[i].Cells[j].Style.BackColor == Color.DeepSkyBlue)
                            {
                                worksheet.Cells[i + 2, jj].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                worksheet.Cells[i + 2, jj].Style.Fill.BackgroundColor.SetColor(Color.DeepSkyBlue);
                                worksheet.Cells[i + 2, jj].Style.Font.Color.SetColor(Color.Black);
                            }
                            else if (dataGridView.Rows[i].Cells[j].Style.BackColor == SystemColors.Menu)//DeepSkyBlue
                            {
                                worksheet.Cells[i + 2, jj].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                worksheet.Cells[i + 2, jj].Style.Fill.BackgroundColor.SetColor(SystemColors.Menu);
                                worksheet.Cells[i + 2, jj].Style.Font.Color.SetColor(Color.Black);
                            }
                        }
                        else
                        {
                            countColumnVisible2++;
                        }
                    }
                }

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
        bool colorLoop = false;

        private void TimerRefreshFirst_Tick(object sender, EventArgs e)
        {
            if (gvDis2.Rows.Count > 0)
            {
                // MessageBox.Show("DDDDD");
                for (int i = 0; i < gvDis2.Rows.Count; i++)
                {
                    string checkJobOutside = gvDis2.Rows[i].Cells["Line"].Value.ToString();
                    if (checkJobOutside != "TKOUT")
                    {
                        if (chLine != gvDis2.Rows[i].Cells[1].Value.ToString())
                        {
                            chColor = !chColor;
                        }
                        chLine = gvDis2.Rows[i].Cells[1].Value.ToString();
                        for (int j = 0; j < gvDis2.Columns.Count; j++)
                        {
                            if (j >= 16 && j < gvDis2.Columns.Count - 7 && i < gvDis2.Rows.Count - 1) // Note: Column index is zero-based
                            {
                                double valueCol1 = 0;
                                if (gvDis2.Rows[i].Cells["Fc PCS/Hr"].Value != DBNull.Value)
                                {
                                    valueCol1 = double.Parse(gvDis2.Rows[i].Cells["Fc PCS/Hr"].Value.ToString());
                                }

                                double outputValue = 0;
                                if (gvDis2.Rows[i].Cells[j].Value != DBNull.Value)
                                {
                                    outputValue = double.Parse(gvDis2.Rows[i].Cells[j].Value.ToString());
                                }

                                if (outputValue >= valueCol1 && outputValue > 0)
                                {
                                    gvDis2.Rows[i].Cells[j].Style.BackColor = Color.Lime;
                                }
                                else if (outputValue <= valueCol1)
                                {
                                    if (outputValue > 0)//outputValue 
                                    {
                                        gvDis2.Rows[i].Cells[j].Style.BackColor = Color.LightCoral;
                                    }
                                    else
                                    {
                                        gvDis2.Rows[i].Cells[j].Style.BackColor = Color.Red;
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


                            if (j == 13 || j == 37)
                            {
                                Color ccolor = Color.Blue;
                                if (j == 37 && gvDis2.Rows[i].Cells[13].Value.ToString() != "" && gvDis2.Rows[i].Cells[j].Value.ToString() != "" && i < gvDis2.RowCount - 2)
                                {

                                    string txteffTar = gvDis2.Rows[i].Cells[13].Value.ToString();
                                    string txteffAct = gvDis2.Rows[i].Cells[j].Value.ToString();
                                    double effTar = double.Parse(txteffTar.Substring(0, txteffTar.Length - 1));
                                    double effAct = double.Parse(txteffAct.Substring(0, txteffAct.Length - 1));
                                    if (effAct < effTar)
                                    {
                                        ccolor = Color.Red;
                                    }
                                }

                                gvDis2.Rows[i].Cells[j].Style.ForeColor = ccolor;
                            }
                            if (j == 14 || j == 32)
                            {
                                if (i < gvDis2.Rows.Count - 1)
                                {
                                    gvDis2.Rows[i].Cells[j].Style.ForeColor = Color.DarkRed;
                                }

                            }
                            if (j == 33 && i < gvDis2.Rows.Count - 1)

                            {
                                if (gvDis2.Rows[i].Cells[j].Value.ToString().Substring(0, 1) == "-")
                                {
                                    gvDis2.Rows[i].Cells[j].Style.ForeColor = Color.Red;
                                }
                                else
                                {
                                    gvDis2.Rows[i].Cells[j].Style.ForeColor = Color.Blue;
                                }
                            }
                            if (i == gvDis2.RowCount - 1 || i == gvDis2.RowCount - 1)
                            {

                                if (j == 1)
                                {// using (Font font = new Font("Bahnschrift", 10, FontStyle.Regular))
                                    gvDis2.Rows[i].Cells[j - 1].Style.BackColor = Color.DeepSkyBlue;

                                    //gvDis2.Rows[i].Cells[j - 1].Style.ForeColor = Color.White;
                                }
                                gvDis2.Rows[i].Cells[j].Style.BackColor = Color.DeepSkyBlue;

                                //gvDis2.Rows[i].Cells[j].Style.ForeColor = Color.White;
                            }
                            if (j == 20)
                            {
                                gvDis2.Rows[i].Cells[j].Style.BackColor = Color.White;
                            }

                        }
                    }
                }

                //---------------------------------------------------------------------------------//----------------------------------



                int manTar = 0, manAct = 0;
                string subBeforeCurrentLine = "";
                for (int i = 0; i < gvDis2.Rows.Count - 1; i++)
                {
                    if (gvDis2.Rows[i].Cells["Line"].Value.ToString() != "TKOUT")
                    {
                        //MessageBox.Show(gvDis2.Rows[i].Cells["Man"].Value.ToString());
                        string currentlineCheck = gvDis2.Rows[i].Cells["Line"].Value.ToString();
                        string manValue = gvDis2.Rows[i].Cells["Man"].Value?.ToString().Trim();
                        int man_t = string.IsNullOrEmpty(manValue) ? 0 : int.Parse(manValue);

                        string man_actValue = gvDis2.Rows[i].Cells["ManAct"].Value?.ToString().Trim();
                        int man_act = string.IsNullOrEmpty(man_actValue) ? 0 : int.Parse(man_actValue);


                        if (currentlineCheck != subBeforeCurrentLine)
                        {
                            manTar += man_t;
                            manAct += man_act;
                        }

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

                            for (int m = 16; m < gvDis2.Columns.Count - 6; m++)
                            {
                                if (m != 20)
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
                            //if (cbbReportMode.SelectedIndex == 0) ------------------------------------eff
                            //{
                            double Earn = 0;
                            double Clock = 0;
                            for (int b = 0; b < indaxArray.Count(); b++)
                            {
                                Earn += double.Parse(gvDis2.Rows[indaxArray[b]].Cells["Earn Min"].Value.ToString());
                                Clock += double.Parse(gvDis2.Rows[indaxArray[b]].Cells["Clock Min"].Value.ToString());
                            }
                            double eff = (Earn / Clock) * 100;

                            for (int b = 0; b < indaxArray.Count(); b++)
                            {
                                gvDis2.Rows[indaxArray[b]].Cells["TotalAct Eff%"].Value = eff.ToString("#,##0.#") + "%";
                            }
                            //}
                        }
                        else if (indaxArray.Count() == 1)
                        {
                            gvDis2.Rows[i].Cells["TotalAct Eff%"].Value = gvDis2.Rows[i].Cells["Act Eff%"].Value;
                        }
                    }
                }
                gvDis2.Rows[gvDis2.Rows.Count - 1].Cells["Man"].Value = manTar.ToString();
                gvDis2.Rows[gvDis2.Rows.Count - 1].Cells["ManAct"].Value = manAct.ToString();


            }
            //****************************----------------------------*******************
            Color ccolor2 = Color.Lime;
            string txteffTar2 = gvDis2.Rows[gvDis2.RowCount - 1].Cells["Fc Eff%"].Value.ToString();
            string txteffAct2 = gvDis2.Rows[gvDis2.RowCount - 1].Cells["TotalAct Eff%"].Value.ToString();
            double effTar2 = double.Parse(txteffTar2.Substring(0, txteffTar2.Length - 1));
            double effAct2 = double.Parse(txteffAct2.Substring(0, txteffAct2.Length - 1));
            if (effAct2 < effTar2)
            {
                ccolor2 = Color.Red;
            }
            gvDis2.Rows[gvDis2.RowCount - 1].Cells["TotalAct Eff%"].Style.BackColor = ccolor2;
            //Act PCS.

            for (int i = 16; i < gvDis2.Columns.Count - 7; i++)
            {
                bool checkNull = false;
                for (int j = 0; j < gvDis2.Rows.Count - 1; j++)
                {
                    var chValue = gvDis2.Rows[j].Cells[i];
                    if (DateTime.Now.ToString("yyyy-MM-dd") == dtpDate.Value.ToString("yyyy-MM-dd"))
                    {

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
                //
                if (!checkNull)
                {
                    TimeSpan time1 = TimeSpan.Parse(gvDis2.Columns[i].Name.Substring(0, 5));
                    TimeSpan time2 = TimeSpan.Parse(DateTime.Now.ToString("HH:00"));
                    // Compare the two times
                    int result = TimeSpan.Compare(time1, time2);
                    // Check the result
                    if (dtpDate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
                    {
                        if (result > 0)
                        {
                            if (gvDis2.Columns[i].Name != "12:00")
                            {
                                gvDis2.Columns[i].Visible = false;
                            }
                        }
                    }
                    else
                    {
                        if (gvDis2.Columns[i].Name != "12:00")
                        {
                            gvDis2.Columns[i].Visible = false;
                        }
                    }
                }
                else
                {
                    gvDis2.Columns[i].Visible = true;
                }
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


            gvDis2.Columns["12:00"].Width = 15;
            gvDis2.Columns["12:00"].HeaderCell.Style.ForeColor = SystemColors.Control;//
            gvDis2.Columns["12:00"].DefaultCellStyle.ForeColor = SystemColors.Control;
            gvDis2.Rows[gvDis2.Rows.Count - 1].Cells[20].Value = null;
            gvDis2.Columns["RFT"].Visible = false;

            //int qtyNotSetTarget = int.Parse(gvDis2.Rows[gvDis2.RowCount - 2].Cells["Act PCS."].Value.ToString());
            //if (qtyNotSetTarget > 0)
            //{
            //    gvDis2.Rows[gvDis2.RowCount - 2].Cells["Act PCS."].Style.BackColor = Color.Yellow;
            //}
            //else
            //{
            //    gvDis2.Rows.RemoveAt(gvDis2.RowCount - 2);
            //}
            TimerRefreshFirst.Stop();
            visible_Table();
            AdjustRowHeightToFitScreen(gvDis2);
        }
        private void cbbBuilding_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (firstTimeNoLoad) // No Load first Time
            {
                if (cbbBuilding.SelectedIndex == 0)
                {
                    Lastline_Load = "";
                    loadForm(Lastline_Load);
                }
                else if (cbbBuilding.SelectedIndex == 1)
                {
                    
                    Lastline_Load = "TK1";
                    loadForm(Lastline_Load);
                }
                else if (cbbBuilding.SelectedIndex == 2)
                {
                   
                    Lastline_Load = "TK2";
                    loadForm(Lastline_Load);
                }
            }

        }


        private void gvDis2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.ColumnIndex == 1)
            {
                // Ensure the row index is within valid bounds
                if (e.RowIndex < gvDis2.RowCount)
                {
                    // Get the rectangle for the current cell
                    System.Drawing.Rectangle rect = e.CellBounds;


                    float fontSize = string.IsNullOrEmpty(tbFontSize.Text)
                      ? 0
                    : float.Parse(tbFontSize.Text);

                    fontSize = fontSize + 3;


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


                        using (Font font = new Font("Bahnschrift", fontSize, FontStyle.Regular))
                        {
                            string text = gvDis2[e.ColumnIndex, e.RowIndex].Value.ToString();
                            string newLineText = "★ QCO"; // Text for the new line

                            SizeF textSize = e.Graphics.MeasureString(text, font);
                            SizeF newLineTextSize = e.Graphics.MeasureString(newLineText, font);

                            // Calculate the center position for the original text
                            float x = rect.X + (rect.Width - textSize.Width) / 2;
                            float y = rect.Y + (rect.Height - textSize.Height) / 2 - 20; // Adjust upward for better alignment

                            // Use higher quality rendering for clearer text
                            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

                            // Draw the main text in default color
                            e.Graphics.DrawString(text, font, SystemBrushes.ControlText, new PointF(x, y));

                            // Draw "★ CHO" below in red
                            if (cbbReportMode.Text == "Style")
                            {


                                float newLineY = y + textSize.Height; // Position below the main text
                                float fontSize2 = fontSize - 3;
                                Font font_2 = new Font("Bahnschrift", fontSize2, FontStyle.Regular);
                                using (Brush redBrush = new SolidBrush(Color.Red))
                                {
                                    e.Graphics.DrawString(newLineText, font_2, redBrush, new PointF(x, newLineY));
                                }
                            }
                        }

                        // Apply the same effect to column 31
                        if (e.RowIndex > 0 && gvDis2[31, e.RowIndex].Value != null &&
                            gvDis2[31, e.RowIndex].Value.Equals(gvDis2[31, e.RowIndex - 1].Value))
                        {
                            // Repeat the same logic for column 31
                            System.Drawing.Rectangle rect31 = gvDis2.GetCellDisplayRectangle(31, e.RowIndex, true);

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
                            using (Font font = new Font("Bahnschrift", fontSize, FontStyle.Regular))
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

        private void cbbReportMode_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbbReportMode.SelectedIndex == 0)
            {
                colSoStyle = "Style";
            }
            else if (cbbReportMode.SelectedIndex == 1)
            {
                colSoStyle = "SO";
            }
            if (cbbReportMode.SelectedIndex > 0 && firstTimeNoLoad)
            {
                Lastline_Load = "";
                loadForm(Lastline_Load);
            }
        }

        private void btAdjustOutput_Click(object sender, EventArgs e)
        {
            if (HomePage.ins.checkPermiss("AdjustOutput"))
            {
                if (RowIndex > -1)
                {
                    if (MessageBox.Show("Are you sure you want to Adjust Output?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string datee = setDate(dtpDate);
                        string line = gvDis2.Rows[RowIndex].Cells["Line"].Value.ToString();
                        bool st = ConnectMySQL.MysqlQuery("UPDATE `b_scaned_bundle` SET `sb_scantime`='" + datee + " 16:50:00' " +
                             "WHERE `sb_lineno`LIKE '" + line + "' AND DATE(`sb_scantime`) = '" + datee + "' AND TIME(`sb_scantime`) > '16:59:00';");
                        if (st)
                        {
                            Lastline_Load = "";
                            loadForm(Lastline_Load);
                            MessageBox.Show("OK");
                            RowIndex = -1;
                        }
                        else
                        {
                            MessageBox.Show("Can't Adjust Output.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else
            {
                MessageBox.Show("This Account Don't Have Permission For This Function.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        int RowIndex = -1;
        private void gvDis2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                RowIndex = e.RowIndex;

            }

        }

        private void cbbShow_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbShow.SelectedIndex == 0)
            {
                tbFontSize.Text = Properties.Settings.Default.FontSizeSewingReportViewAll.ToString();
            }
            else if (cbbShow.SelectedIndex == 1)
            {
                tbFontSize.Text = Properties.Settings.Default.FontSizeSewingReportViewOutput.ToString();
            }
            Properties.Settings.Default.Sewing_Daily_Show = cbbShow.SelectedIndex;
            Properties.Settings.Default.Save();
            visible_Table();
        }
        private void visible_Table()
        {

            int fontSize = int.Parse(tbFontSize.Text);
            if (cbbShow.SelectedIndex == 0) // Show All
            {

                if (gvDis2.ColumnCount > 0)
                {
                    for (int i = 0; i < gvDis2.Columns.Count; i++)
                    {
                        if ((i > 3 && i < 16) || i > 32)
                        {
                            gvDis2.Columns[i].Visible = (cbbShow.SelectedIndex == 0);
                        }

                        // Get row height and adjust font size dynamically
                        int rowHeight = gvDis2.RowTemplate.Height;
                        // Ensures minimum font size of 9

                        if ((i > 3 && i < 16) || i > 32)
                        {
                            gvDis2.Columns[i].DefaultCellStyle.Font = new Font("Bahnschrift", fontSize, FontStyle.Regular);
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


                    gvDis2.Rows[lastRowIndex].DefaultCellStyle.Font = new Font("Bahnschrift", fontSize, FontStyle.Regular);
                }

            }
            else if (cbbShow.SelectedIndex == 1) // Show Output Only
            {


                if (gvDis2.ColumnCount > 0)
                {
                    for (int i = 0; i < gvDis2.Columns.Count; i++)
                    {
                        if ((i > 3 && i < 16) || i > 32)
                        {
                            gvDis2.Columns[i].Visible = (cbbShow.SelectedIndex == 0);
                        }

                        // Get row height and adjust font size dynamically
                        int rowHeight = gvDis2.RowTemplate.Height;


                        if ((i > 3 && i < 16) || i > 32)
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
                row.Height = rowHeight;
            }
        }


        private void btSaveFontSize_Click(object sender, EventArgs e)
        {
            if (cbbShow.SelectedIndex == 0)
            {
                if (tbFontSize.Text.Length > 0)
                {
                    Properties.Settings.Default.FontSizeSewingReportViewAll = int.Parse(tbFontSize.Text);
                    Properties.Settings.Default.Save();
                }
                else
                {
                    MessageBox.Show("Please Add Number");
                }
            }
            else if (cbbShow.SelectedIndex == 1)
            {
                if (tbFontSize.Text.Length > 0)
                {
                    Properties.Settings.Default.FontSizeSewingReportViewOutput = int.Parse(tbFontSize.Text);
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

        private void tbFontSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Prevent the character from being entered
            }
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


    }
}


