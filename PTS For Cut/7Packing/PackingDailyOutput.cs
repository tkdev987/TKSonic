using Guna.UI2.WinForms;
using PTS_For_Cut.Myclass;
using System.Data;

namespace PTS_For_Cut._7Packing
{
    public partial class PackingDailyOutput : Form
    {
        public PackingDailyOutput()
        {
            InitializeComponent();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        string Lastline_Load = "";
        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
            {
                timerRefresh.Start();
                loadForm(Lastline_Load);
            }
            else
            {
                timerRefresh.Stop();
                loadForm(Lastline_Load);
            }
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
            dtStructure.Columns.Add("ManAct");
            dtStructure.Columns.Add("TimeAct");
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
            dtStructure.Columns.Add("Earn Min");
            dtStructure.Columns.Add("Clock Min");
            dtStructure.Columns.Add("Act Eff%");
            dtStructure.Columns.Add("TotalAct Eff%");

            gvDis2.DataSource = dtStructure;
            this.gvDis2.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            foreach (DataGridViewColumn column in gvDis2.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

            }
            gvDis2.Columns[3].Frozen = true; //so style
            gvDis2.Columns[2].Frozen = true;
            //gvDis2.Columns["12:00"].Width = 32;
            //gvDis2.Columns["Line"].Width = 70;
            //gvDis2.Columns["SO"].Width = 160;


            string txtDate = setDate(dtpDate);
            DataTable getTarget = new DataTable();
            if (cbbReportMode.SelectedIndex == 0)
            {
                string sqltxt = @"SELECT a.`sb_lineno` AS `Line`, b.`Style`, b.Brand,
                                       IF(DATE_FORMAT(a.`pkg_date`, '%H') = '12', '11:00', DATE_FORMAT(a.`pkg_date`, '%H:00')) AS `Time`,
                                       IFNULL(SUM(a.`sb_qty`), 0) AS `QTY`
                                FROM `b_scaned_bundle` AS a
                                LEFT JOIN (
                                    SELECT DISTINCT `SO`, `Style`, `Brand`
                                    FROM `so_tb`
                                ) AS b ON a.`SO` = b.`SO`
                                WHERE a.`pkg_status` = 1 AND  DATE(a.`pkg_date`)='" + txtDate + @"'  AND `sb_lineno` LIKE '%" + txt + @"%'
                                GROUP BY b.`Style`, a.`sb_lineno`, `Time`
                                ORDER BY a.`sb_lineno`, b.`Style`, `Time` ASC;";
                dtLoadTarget = ConnectMySQL.MySQLtoDataTable(sqltxt);

                getTarget = ConnectMySQL.MySQLtoDataTable(@"SELECT a.`Line`, b.`Style`, a.`SAM`, a.`ManActual`, a.`TimeActual`, a.`QtyTargetForecast` 
                                                    FROM `a_setuptargetforproduction` AS a
                                                    LEFT JOIN (
                                                        SELECT DISTINCT `SO`, `Style`
                                                        FROM `so_tb`
                                                    ) AS b ON a.`SO` = b.`SO`
                                                    WHERE DATE(a.`Date`) = '" + txtDate + "' AND a.Type = 'pack';");
            }
            else if (cbbReportMode.SelectedIndex == 1)
            {
                string sqltxt = @"SELECT a.`sb_lineno` AS `Line` , a.`SO`, b.Brand,
                                       IF(DATE_FORMAT(a.`pkg_date`, '%H') = '12', '11:00', DATE_FORMAT(a.`pkg_date`, '%H:00')) AS `Time`,
                                       IFNULL(SUM(a.`sb_qty`), 0) AS `QTY`
                                FROM `b_scaned_bundle` AS a
                                LEFT JOIN (
                                    SELECT DISTINCT `SO`, `Brand`
                                    FROM `so_tb`
                                ) AS b ON a.`SO` = b.`SO`
                                WHERE a.`pkg_status` = 1 AND  DATE(a.`pkg_date`)='" + txtDate + @"'  AND `sb_lineno` LIKE '%" + txt + @"%'
                                GROUP BY a.`SO`, a.`sb_lineno`, `Time`
                                ORDER BY a.`sb_lineno`, a.`SO`, `Time` ASC;";

                dtLoadTarget = ConnectMySQL.MySQLtoDataTable(sqltxt);
                getTarget = ConnectMySQL.MySQLtoDataTable("SELECT `Line`, `SO`, `SAM`, `ManActual`, `TimeActual`, `QtyTargetForecast` FROM `a_setuptargetforproduction` WHERE `Date` = '" + txtDate + "' AND Type = 'pack';");

            }

            DataTable dt = new DataTable();
            dt = (DataTable)gvDis2.DataSource;
            if (dtLoadTarget.Rows.Count > 0)
            {

                string Subline = "";
                string Subso = "";
                string Subtime = "";
                string Subqty = "";

                int countRows = 0;

                for (int i = 0; i < dtLoadTarget.Rows.Count; i++)
                {
                    string line = dtLoadTarget.Rows[i]["Line"].ToString();
                    string so = dtLoadTarget.Rows[i][colSoStyle].ToString();
                    string time = dtLoadTarget.Rows[i]["Time"].ToString();
                    string qty = dtLoadTarget.Rows[i]["QTY"].ToString();
                    string brand = dtLoadTarget.Rows[i]["brand"].ToString();
                    // MessageBox.Show(line +"!="+ Subline + "--"+ so +"!="+ Subso);

                    if (i == 0)
                    {
                        countRows++;
                        dt.Rows.Add(countRows.ToString(), line, "", so);
                    }
                    else
                    if (line != Subline || so != Subso)
                    {
                        countRows++;
                        dt.Rows.Add(countRows.ToString(), line, brand, so);
                    }
                    for (int j = 10; j < dt.Columns.Count - 6; j++)
                    {

                        string columnName = dt.Columns[j].ColumnName.Substring(0, 5);
                        if (time == columnName)
                        {
                            dt.Rows[dt.Rows.Count - 1][j] = qty;

                        }

                        Subline = line;
                        Subso = so;
                        Subtime = time;
                        Subqty = qty;

                    }
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
                gvDis2.DataSource = dt;

                lbtimeNow();


                double tttimeAct = 0;
                double tt_EarnMinRow = 0;
                double tt_clockMin = 0;
                for (int i = 0; i < gvDis2.Rows.Count; i++)
                {
                    var gv = gvDis2.Rows[i];
                    for (int k = 0; k < getTarget.Rows.Count; k++)
                    {
                        var tr = getTarget.Rows[k];
                        if (gv.Cells["Line"].Value.ToString() == tr["Line"].ToString()
                            && gv.Cells[colSoStyle].Value.ToString() == tr[colSoStyle].ToString())
                        {
                            gv.Cells["SAM"].Value = tr["SAM"];
                            gv.Cells["ManAct"].Value = tr["ManActual"];
                            gv.Cells["TimeAct"].Value = tr["TimeActual"];
                            gv.Cells["Fc PCS"].Value = tr["QtyTargetForecast"];
                        }
                    }

                    if (gv.Cells["SAM"].Value != DBNull.Value && !string.IsNullOrEmpty(gv.Cells["SAM"].Value?.ToString()) &&
                      gv.Cells["Fc PCS"].Value != DBNull.Value && !string.IsNullOrEmpty(gv.Cells["Fc PCS"].Value?.ToString()) &&
                      gv.Cells["ManAct"].Value != DBNull.Value && !string.IsNullOrEmpty(gv.Cells["ManAct"].Value?.ToString()) &&
                      gv.Cells["TimeAct"].Value != DBNull.Value && !string.IsNullOrEmpty(gv.Cells["TimeAct"].Value?.ToString()))
                    {
                        double eff = 0;
                        double sam = double.Parse(gv.Cells["SAM"].Value.ToString());
                        double totalPcs = double.Parse(gv.Cells["Fc PCS"].Value.ToString());
                        double manAc = double.Parse(gv.Cells["ManAct"].Value.ToString());
                        double timeAct = double.Parse(gv.Cells["TimeAct"].Value.ToString());
                        double timeAct_min = timeAct * 60;
                        tttimeAct += timeAct;
                        eff = ((sam * totalPcs) / (manAc * timeAct_min)) * 100;
                        gv.Cells["Fc Eff%"].Value = (eff == 0 ? "0" : eff.ToString("##.#")) + "%";
                        double FcPCShr = totalPcs / timeAct;
                        gv.Cells["Fc PCS/Hr"].Value = FcPCShr == 0 ? "0" : FcPCShr.ToString("##.#");
                        bool check1800 = false;
                        double timeMin = 0;
                        if (gvDis2.Rows[i].Cells["18:00 19:00"].Value.ToString() != "")
                        { check1800 = true; }
                        if (txtDate == DateNow())
                        {
                            timeMin = checkHrsNow(check1800);
                            // MessageBox.Show(timeMin.ToString());
                            if (timeMin >= timeAct_min)
                            {
                                timeMin = timeAct_min;
                            }
                            else
                            {
                                timeMin = timeMin;
                            }
                        }
                        else
                        {
                            timeMin = timeAct_min;
                        }
                        double EarnMinRow = 0;
                        double clockMin = 0;
                        EarnMinRow += totalPcs * sam;
                        clockMin += manAc * timeMin;
                        tt_EarnMinRow += EarnMinRow;
                        tt_clockMin += clockMin;

                        int ActQTY = 0;
                        for (int k = 10; k < gvDis2.Columns.Count - 5; k++)
                        {
                            if (gvDis2.Rows[i].Cells[k].Value != DBNull.Value)
                                ActQTY += int.Parse(gvDis2.Rows[i].Cells[k].Value.ToString());
                        }
                        gvDis2.Rows[i].Cells["Act PCS."].Value = ActQTY;
                        gvDis2.Rows[i].Cells["Earn Min"].Value = (ActQTY * sam) == 0 ? "0" : (ActQTY * sam).ToString("#,##0.#"); ;// EarnMinRow.ToString("##.#");
                        gvDis2.Rows[i].Cells["Clock Min"].Value = clockMin == 0 ? "0" : clockMin.ToString("##.#");//clockMin.ToString("##.#");
                        gv.Cells["Fc PCS/Hr"].Value = FcPCShr == 0 ? "0" : FcPCShr.ToString("##.#");

                        double effAct = ((ActQTY * sam) / clockMin) * 100;
                        if (effAct > 0)
                        {

                            string txtEff = effAct.ToString("#,##0.#");

                            gvDis2.Rows[i].Cells["Act Eff%"].Value = txtEff + "%";

                        }
                        else
                        {
                            gvDis2.Rows[i].Cells["Act Eff%"].Value = "0%";
                        }
                        // 
                        //gvDis2.Rows[i].Cells["Earn Min"].Value = EarnMinRow == 0 ? "0" : EarnMinRow.ToString("##.#");// EarnMinRow.ToString("##.#");
                        //gvDis2.Rows[i].Cells["Clock Min"].Value = clockMin == 0 ? "0" : clockMin.ToString("##.#");//clockMin.ToString("##.#");
                        int diff = ActQTY - (int)((FcPCShr / 60) * timeMin);
                        gvDis2.Rows[i].Cells["Diff"].Value = diff == 0 ? "0" : diff.ToString("#,##0.#"); //diff; 
                    }
                }
                double Fc_eff = tt_EarnMinRow / tt_clockMin * 100;
                gvDis2.Rows[gvDis2.RowCount - 1].Cells["Fc Eff%"].Value = Fc_eff.ToString("##.#");
                gvDis2.Rows[gvDis2.RowCount - 1].Cells["TimeAct"].Value = tttimeAct;

                for (int i = 8; i < gvDis2.Columns.Count - 2; i++)//.ForeColor = Color.Red;
                {
                    double QTYColumn = 0;
                    for (int j = 0; j < gvDis2.RowCount - 1; j++)
                    {
                        var varGvDis = gvDis2.Rows[j].Cells[i].Value;
                        if (varGvDis != DBNull.Value || varGvDis.ToString() != "")
                        {
                            string xx = gvDis2.Rows[j].Cells[i].Value.ToString();
                            if (xx == "") xx = "0";
                            QTYColumn += double.Parse(xx);

                            // gvDis2.Rows[i].Cells["Act Eff%"].Value
                        }
                    }
                    if (i != 14)
                    {
                        gvDis2.Rows[gvDis2.Rows.Count - 1].Cells[i].Value = QTYColumn == 0 ? "0" : QTYColumn.ToString("#,##0.#");
                    }// QTYColumn.ToString("#,##0.#");
                    // MessageBox.Show(QTYColumn.ToString("#,##0.#"));  gvDis2.Rows[i].Cells["Diff"].Value = diff == 0 ? "0" : diff; 
                }
                double ttEarnMin = double.Parse(gvDis2.Rows[gvDis2.Rows.Count - 1].Cells["Earn Min"].Value.ToString());
                double ttclockMin = double.Parse(gvDis2.Rows[gvDis2.Rows.Count - 1].Cells["Clock Min"].Value.ToString());
                double tteff = (ttEarnMin / ttclockMin) * 100;
                gvDis2.Rows[gvDis2.Rows.Count - 1].Cells["TotalAct Eff%"].Value = tteff == 0 ? "0" : tteff.ToString("#,##0.#") + "%";

                for (int i = 10; i < gvDis2.Columns.Count - 6; i++)
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
                                                                                                   //gvDis2.Columns["SAM"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                                                                                                   //gvDis2.Columns["Act PCS."].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                                                                                                   //gvDis2.Columns["Earn Min"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                                                                                                   //gvDis2.Columns["Clock Min"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                                                                                                   //gvDis2.Columns["Act Eff%"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                                                                                                   //gvDis2.Columns["TotalAct Eff%"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                //  gvDis2.Columns[colSoStyle].Width = 150;
                gvDis2.Columns["12:00"].Width = 15;
                gvDis2.Columns["12:00"].HeaderCell.Style.ForeColor = SystemColors.Control;//
                gvDis2.Columns["12:00"].DefaultCellStyle.ForeColor = SystemColors.Control;
                TimerRefreshFirst.Start();
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
        private int ExtractNumericValue(string text)
        {
            // Extract numbers from a string (e.g., "TK101" → 101, "TKS102" → 102)
            string numericPart = new string(text.Where(char.IsDigit).ToArray());
            return int.TryParse(numericPart, out int result) ? result : 0;
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

        private void btReload_Click(object sender, EventArgs e)
        {
            loadForm(Lastline_Load);
        }
        string colSoStyle = "";
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
            loadForm(Lastline_Load);
        }

        private void PackingDailyOutput_Load(object sender, EventArgs e)
        {

            dtpDate.Value = DateTime.Now;
            gvDis2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            gvDis2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //loadForm("TK");
            cbbReportMode.SelectedIndex = 0;
            // if(Properties.Settings.Default.Packing_Daily_Show )
            cbbShow.SelectedIndex = Properties.Settings.Default.Packing_Daily_Show;
            CenterLabel(lbHeader, pnlbHeader);


        }
        private void CenterLabel(Label lb, Panel pn)
        {
            lb.Left = (pn.Width - lb.Width) / 2;
            lb.Top = (pn.Height - lb.Height) / 2;
        }

        private void btSetUpTarget_Click(object sender, EventArgs e)
        {
            SetTargetPack setTargetPack = new SetTargetPack();
            setTargetPack.Show();
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {

        }
        string chLine = "";
        bool chColor = false;
        private void TimerRefreshFirst_Tick(object sender, EventArgs e)
        {
            if (gvDis2.Rows.Count > 0)
            {

                for (int i = 0; i < gvDis2.Rows.Count; i++)
                {
                    //MessageBox.Show(chLine + chColor);
                    if (chLine != gvDis2.Rows[i].Cells["Line"].Value.ToString())
                    {
                        chColor = !chColor;
                    }
                    chLine = gvDis2.Rows[i].Cells["Line"].Value.ToString();
                    for (int j = 0; j < gvDis2.Columns.Count; j++)
                    {
                        var gv = gvDis2.Rows[i].Cells[j];
                        if (j >= 10 && j < gvDis2.Columns.Count - 6 && i < gvDis2.Rows.Count - 1) // Note: Column index is zero-based
                        {
                            double valueCol1 = 0;
                            if (gvDis2.Rows[i].Cells["Fc PCS/Hr"].Value != DBNull.Value)
                            {
                                valueCol1 = double.Parse(gvDis2.Rows[i].Cells["Fc PCS/Hr"].Value.ToString());
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
                                if (j != 14)
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
                        if (j > 0 && gv.Style.BackColor != Color.Red && gv.Style.BackColor != Color.LightCoral && gv.Style.BackColor != Color.Lime)
                        {

                            if (chColor)
                            {
                                if (j == 1)
                                {
                                    gvDis2.Rows[i].Cells[j - 1].Style.BackColor = Color.White;
                                }
                                gv.Style.BackColor = Color.White;
                            }
                            else
                            {
                                if (j == 1)
                                {
                                    gvDis2.Rows[i].Cells[j - 1].Style.BackColor = Color.LightGray;//SystemColors.Menu;
                                }
                                gv.Style.BackColor = Color.LightGray;//SystemColors.Menu;
                            }
                        }


                        if (j == 7 || j == 30) //eff
                        {
                            Color ccolor = Color.Blue;
                            if (j == 30 && gvDis2.Rows[i].Cells[7].Value.ToString() != "" && gv.Value.ToString() != "" && i < gvDis2.RowCount - 1)
                            {

                                string txteffTar = gvDis2.Rows[i].Cells[7].Value.ToString();
                                // MessageBox.Show(txteffTar);
                                string txteffAct = gv.Value.ToString();
                                double effTar = double.Parse(txteffTar.Substring(0, txteffTar.Length - 1));
                                double effAct = double.Parse(txteffAct.Substring(0, txteffAct.Length - 1));
                                if (effAct < effTar || effTar == 0 || effAct == 0)
                                {
                                    ccolor = Color.Red;
                                }

                            }

                            gv.Style.ForeColor = ccolor;
                        }
                        if (j == 8 || j == 26) // Act
                        {
                            if (i < gvDis2.Rows.Count - 1)
                            {
                                gv.Style.ForeColor = Color.DarkRed;
                            }

                        }
                        if (j == 27 && i < gvDis2.Rows.Count - 1)

                        {
                            if (gv.Value != DBNull.Value)
                            {
                                if (gv.Value.ToString().Substring(0, 1) == "-")
                                {
                                    gv.Style.ForeColor = Color.Red;
                                }
                                else
                                {
                                    gv.Style.ForeColor = Color.Blue;
                                }
                            }
                        }
                        if (i == gvDis2.RowCount - 1)
                        {

                            if (j == 1)
                            {// using (Font font = new Font("Bahnschrift", 10, FontStyle.Regular))
                                gvDis2.Rows[i].Cells[j - 1].Style.BackColor = Color.DeepSkyBlue;
                                // gvDis2.Rows[i].Cells[j - 1].Style.Font = new Font("Bahnschrift", 12, FontStyle.Bold);
                                //gvDis2.Rows[i].Cells[j - 1].Style.ForeColor = Color.White;
                            }
                            gv.Style.BackColor = Color.DeepSkyBlue;
                            // gv.Style.Font = new Font("Bahnschrift", 12, FontStyle.Bold);
                            //gvDis2.Rows[i].Cells[j].Style.ForeColor = Color.White;
                        }
                        if (j == 14)
                        {
                            gv.Style.BackColor = Color.White;
                        }

                    }
                }
                //*******************************-------------------------------------

                double manTar = 0, manAct = 0;
                string subBeforeCurrentLine = "";
                for (int i = 0; i < gvDis2.Rows.Count - 1; i++)
                {
                    string currentlineCheck = gvDis2.Rows[i].Cells["Line"].Value?.ToString();
                    //  int man_t = int.Parse(gvDis2.Rows[i].Cells["Man"].Value.ToString());
                    if (gvDis2.Rows[i].Cells["ManAct"].Value != DBNull.Value)
                    {
                        double man_act = double.Parse(gvDis2.Rows[i].Cells["ManAct"].Value?.ToString());
                        if (currentlineCheck != subBeforeCurrentLine)
                        {
                            // manTar += man_t;
                            manAct += man_act;
                        }
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

                        for (int m = 10; m < gvDis2.Columns.Count - 6; m++)
                        {
                            if (m != 14)
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
                        double effAvg = 0;
                        for (int b = 0; b < indaxArray.Count(); b++)
                        {
                            var varEarn = gvDis2.Rows[indaxArray[b]].Cells["Earn Min"].Value;
                            var varClock = gvDis2.Rows[indaxArray[b]].Cells["Clock Min"].Value;
                            if (varEarn.ToString() != "" && varClock.ToString() != "")
                            {
                                Earn += double.Parse(varEarn.ToString());
                                Clock += double.Parse(varClock.ToString());
                                effAvg = (Earn / Clock) * 100;
                            }
                        }


                        for (int b = 0; b < indaxArray.Count(); b++)
                        {
                            gvDis2.Rows[indaxArray[b]].Cells["TotalAct Eff%"].Value = effAvg.ToString("#,##0.#") + "%";
                        }
                        //}
                    }
                    else if (indaxArray.Count() == 1)
                    {
                        gvDis2.Rows[i].Cells["TotalAct Eff%"].Value = gvDis2.Rows[i].Cells["Act Eff%"].Value;
                    }
                }
                // gvDis2.Rows[gvDis2.Rows.Count - 1].Cells["Man"].Value = manTar.ToString();
                gvDis2.Rows[gvDis2.Rows.Count - 1].Cells["ManAct"].Value = manAct.ToString("##.##");

            }
            TimerRefreshFirst.Stop();

            visible_Table();
            AdjustRowHeightToFitScreen(gvDis2);
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
                        if ((i > 3 && i < 10) || i > 26)
                        {
                            gvDis2.Columns[i].Visible = (cbbShow.SelectedIndex == 0);
                        }

                        // Get row height and adjust font size dynamically
                        int rowHeight = gvDis2.RowTemplate.Height;
                        // Ensures minimum font size of 9

                        if ((i > 3 && i < 10) || i > 26)
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
                        if ((i > 3 && i < 10) || i > 26)
                        {
                            gvDis2.Columns[i].Visible = (cbbShow.SelectedIndex == 0);
                        }

                        // Get row height and adjust font size dynamically
                        int rowHeight = gvDis2.RowTemplate.Height;


                        if ((i > 3 && i < 10) || i > 26)
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
        private void StartDelay(int milliseconds)
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer
            {
                Interval = milliseconds
            };
            timer.Tick += (s, e) =>
            {
                timer.Stop(); // Stop the timer after the delay
                gvDis2.Invalidate(); // Trigger a repaint of the DataGridView
            };
            timer.Start();
        }

        private void dtpDate_ValueChanged_1(object sender, EventArgs e)
        {
            loadForm(Lastline_Load);
        }

        private void cbbShow_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbShow.SelectedIndex == 0)
            {
                tbFontSize.Text = Properties.Settings.Default.FontSizePackingReportViewAll.ToString();
            }
            else if (cbbShow.SelectedIndex == 1)
            {
                tbFontSize.Text = Properties.Settings.Default.FontSizePackingReportViewOutput.ToString();
            }
            Properties.Settings.Default.Packing_Daily_Show = cbbShow.SelectedIndex;
            Properties.Settings.Default.Save();
            visible_Table();
        }

        private void cbbShow_Click(object sender, EventArgs e)
        {

        }

        private void btSaveFontSize_Click(object sender, EventArgs e)
        {
            if (cbbShow.SelectedIndex == 0)
            {
                if (tbFontSize.Text.Length > 0)
                {
                    Properties.Settings.Default.FontSizePackingReportViewAll = int.Parse(tbFontSize.Text);
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
                    Properties.Settings.Default.FontSizePackingReportViewOutput = int.Parse(tbFontSize.Text);
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
