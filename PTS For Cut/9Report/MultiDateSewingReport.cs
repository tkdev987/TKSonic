using PTS_For_Cut.Myclass;
using System.Data;

namespace PTS_For_Cut._9Report
{
    public partial class MultiDateSewingReport : Form
    {
        public MultiDateSewingReport()
        {
            InitializeComponent();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {

            loadForm("TK");
        }
        DataTable dtLoadTarget = new DataTable();
        private void loadForm(string txt)
        {
            while (gvDis.Rows.Count > 0)
            {
                gvDis.Rows.RemoveAt(0);
            }
            while (gvDis.Columns.Count > 0)
            {
                gvDis.Columns.RemoveAt(0);
            }
            DataTable dtStructure = new DataTable();
            dtStructure.Columns.Add("Date");
            dtStructure.Columns.Add("Line");
            dtStructure.Columns.Add("Brand");
            dtStructure.Columns.Add("Style");
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

            gvDis.DataSource = dtStructure;
            //gvDis.Columns["12:00"].Width = 32;
            //gvDis.Columns["Line"].Width = 70;
            //gvDis.Columns["SO"].Width = 160;
            this.gvDis.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            foreach (DataGridViewColumn column in gvDis.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

            }
            gvDis.Columns[3].Frozen = true; //so style
            gvDis.Columns[2].Frozen = true;
            DataTable dtHrOutput = new DataTable();
            string txtDate = setDate(dtpStart);
            string txtDateEnd = setDate(dtpEnd);

            dtHrOutput = ConnectMySQL.MySQLtoDataTable(@"SELECT DATE(`a`.`sb_scantime`) AS 'Date',IF(DATE_FORMAT(`a`.`sb_scantime`, '%H') = '12', '11:00', DATE_FORMAT(`a`.`sb_scantime`, '%H:00')) AS `Time`,`b`.`Style`,`a`.`sb_lineno`,MAX(c.Brand) AS Brand,
                   IFNULL(SUM(`a`.`sb_qty`),0)AS`QTY` FROM `b_scaned_bundle` AS `a` 
                            LEFT JOIN (
                                    SELECT DISTINCT `SO`, `Style`, `Brand`
                                    FROM `so_tb`
                                ) AS c ON a.`SO` = c.`SO`
                   JOIN `a_a1_spreading_list_tb` AS `b` ON `a`.`sb_sdlistdocno`=`b`.`SD_ListDoc_No` AND `b`.`FabricType` LIKE 'A' AND `b`.`SD_Status` LIKE '1' 
                   
                   WHERE DATE(`a`.`sb_scantime`) BETWEEN '" + txtDate + "' AND '" + txtDateEnd + "'  GROUP BY DATE(`a`.`sb_scantime`), `b`.`Style`,`a`.`sb_lineno`,`Time` ORDER BY `a`.`sb_lineno`,`b`.`Style`, `Time` ASC;");
            //`TimeScan` BETWEEN '2025-03-30 16:51:04.000000' AND '2025-03-31 16:51:04.000000'

            dtLoadTarget = ConnectMySQL.MySQLtoDataTable("SELECT  `a`.`Date`, `a`.`Line`,`e`.`Brand`, `e`.`Style`, ROUND(`a`.`SAM`, 2) AS `SAM`,SUM(`a`.`RunDate`) AS `RunDate`, `a`.`ManTarget`," +
                    " `a`.`ManActual`, `a`.`Jupper`, SUM( `a`.`TimeTarget`)AS `TimeTarget`, SUM( `a`.`TimeActual`) AS `TimeActual`, `a`.`EffTargetplan`, `a`.`EffTargetForecast`" +
                    " FROM `a_setuptargetforproduction` AS `a` " +
                    "LEFT JOIN ( SELECT `SO`, MAX(`Style`) AS `Style` ,`Brand` FROM `so_tb` GROUP BY `SO` ) AS `e` ON `e`.SO = `a`.SO WHERE `a`.`Type`= 'sew' AND DATE(`a`.`Date`) BETWEEN '" + txtDate + "' AND '" + txtDateEnd + "'" +
                    "AND `a`.`Line` LIKE '%" + txt + "%' GROUP BY DATE(`a`.`Date`),`a`.`Line`, `e`.`Style` ORDER BY `a`.`Line` ASC;");


            DataTable newdt = new DataTable();
            newdt = (DataTable)gvDis.DataSource;
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
                string so = dtHrOutput.Rows[i]["Style"].ToString();
                string time = dtHrOutput.Rows[i]["Time"].ToString();
                string qty = dtHrOutput.Rows[i]["QTY"].ToString();
                string brand = dtHrOutput.Rows[i]["Brand"].ToString();
                // MessageBox.Show(line +"!="+ Subline + "--"+ so +"!="+ Subso);

                if (i == 0)
                {
                    countRows++;
                    newdt.Rows.Add("", line, brand, so);
                }
                else
                if (line != Subline || so != Subso)
                {
                    countRows++;
                    newdt.Rows.Add("", line, brand, so);
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
                for (int j = 0; j < newdt.Rows.Count; j++)//"Style"
                {
                    if (dtLoadTarget.Rows[i]["Line"].ToString() == newdt.Rows[j]["Line"].ToString()
                        && dtLoadTarget.Rows[i]["Style"].ToString() == newdt.Rows[j]["Style"].ToString() && dtLoadTarget.Rows[i]["Date"].ToString() == newdt.Rows[j]["Date"].ToString())
                    {
                        checkAddLine = true;
                        break;
                    }
                }
                if (!checkAddLine)
                {
                    object[] newRow = { dtLoadTarget.Rows[i]["Date"].ToString(), dtLoadTarget.Rows[i]["Line"].ToString(), dtLoadTarget.Rows[i]["Brand"].ToString(), dtLoadTarget.Rows[i]["Style"].ToString() };
                    //AddAndMoveRow("Line", newRow);

                }
            }


            //newdt.DefaultView.Sort = "Line ASC";
            // lbtimeNow();

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

                for (int i = 0; i < gvDis.Rows.Count; i++)
                {
                    var gv = gvDis.Rows[i];
                    for (int k = 0; k < dtLoadTarget.Rows.Count; k++)
                    {
                        var tr = dtLoadTarget.Rows[k];
                        if (gv.Cells["Line"].Value.ToString() == tr["Line"].ToString()
                            && gv.Cells["Style"].Value.ToString() == tr["Style"].ToString() && gv.Cells["Date"].Value.ToString() == tr["Date"].ToString())
                        {
                            //gv.Cells["SAM"].Value = tr["SAM"];
                            //gv.Cells["ManAct"].Value = tr["ManAct"];
                            //gv.Cells["TimeAct"].Value = tr["TimeAct"];
                            //gv.Cells["Fc PCS"].Value = tr["TotalPCS"];

                            string no = (newdt.Rows.Count + 1).ToString();
                            string Line = tr["Line"].ToString();
                            string Brand = tr["Brand"].ToString();
                            string so = tr["Style"].ToString();
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
                            gv.Cells["Date"].Value = tr["Date"];
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

            gvDis.DataSource = newdt;

            //for (int i = 0; i < gvDis.RowCount - 1; i++)
            //{
            //    gvDis.Rows[i].Cells["No."].Value = i + 1;
            //}
            //}

            // DataInTable();
        }
        private string setDate(DateTimePicker dtpDate)
        {
            string txtDate = "";
            System.Globalization.CultureInfo _cultureEnInfo = new System.Globalization.CultureInfo("en-US");
            DateTime date = Convert.ToDateTime(dtpDate.Value, _cultureEnInfo);
            txtDate = date.ToString("yyyy-MM-dd", _cultureEnInfo);
            return txtDate;
        }
        //private void lbtimeNow()
        //{
        //    //System.Globalization.CultureInfo _cultureEnInfo = new System.Globalization.CultureInfo("en-US");
        //    string txtDateStart = DateNow() + " 08:00:00";
        //    DateTime newTime = DateTime.Now;
        //    DateTime Start = Convert.ToDateTime(txtDateStart);
        //    TimeSpan span = newTime.Subtract(Start);
        //    lbTime.Text = DateTime.Now.ToString("HH:mm:ss");
        //    lbMinute.Text = span.TotalMinutes.ToString("##");

        //    if (span.TotalHours <= 4)
        //    {
        //        lbMinute.Text = span.TotalMinutes.ToString("##");
        //    }
        //    else if (span.TotalHours > 4 && span.TotalHours <= 5)
        //    {
        //        lbMinute.Text = "240";
        //    }
        //    else if (span.TotalHours > 5)
        //    {
        //        lbMinute.Text = (span.TotalMinutes - 60).ToString("##");
        //    }

        //}
    }
}
