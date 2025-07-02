using Guna.UI2.WinForms;
using PTS_For_Cut.myClass;
using PTS_For_Cut.Myclass;
using System.Data;
using System.Text.RegularExpressions;

namespace PTS_For_Cut._9Report
{
    public partial class SoReportV2 : Form
    {
        public string so_No = "";

        public SoReportV2()
        {
            InitializeComponent();
        }

        private void SoReportV2_Load(object sender, EventArgs e)
        {
            dtpStart.Value = DateTime.Now;
            dtpEnd.Value = DateTime.Now;
            dtpEnd.Visible = false;
            dtpStart.Visible = false;
            SetUpPosition.CenterLabelInPanel(lbHeader, pnlbHeader);

            cbbDec.SelectedIndex = 0;
        }

        private void search(string txt)
        {
            if (txt.Length > 10)
            {


                txt = txt.Trim();

                // Split by multiple delimiters: comma, hyphen, space, newline, and carriage return
                string[] items = Regex.Split(txt, @"[\s,\-\r\n]+").Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

                // Format the output with single quotes
                string formatted = $"({string.Join(",", items.Select(item => $"'{item}'"))})";
                string orderQuery = @"SELECT a.`SO`,a.Style,a.Customer_Style, a.`Color`, a.`Size`,SUM(`Qty`) AS `Order` ,
                                        NULL AS Cutting,NULL AS  Printing ,NULL AS Embroidery ,NULL AS SMK ,NULL AS Sewing,NULL AS  Washing ,
                                        NULL AS Packing ,NULL AS FG ,NULL AS Shipping
                                        FROM `so_tb` AS a
                  
                                LEFT JOIN `sizes_tb` AS b ON b.Size=a.Size
                                WHERE `So` IN " + formatted + @"
                                GROUP BY a.`So`,a.`Color`, a.`Size`
                                ORDER BY a.`So`,a.`Color`,b.SeqNo ASC;";

                ConnectMySQL.DisplayAndSearch(orderQuery, gvDis);
                //gvDis.Columns["SO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //gvDis.Columns["Style"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //gvDis.Columns["Customer_Style"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //gvDis.Columns["Color"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //so-style
                gvDis.Columns["SO"].Width = 170;
                gvDis.Columns["Style"].Width = 200;
                gvDis.Columns["Customer_Style"].Width = 200;
                gvDis.Columns["Color"].Width = 200;

                string subColor = "";
                string subSO = "";
                DataTable dt = (DataTable)gvDis.DataSource;
                int countAddColumn = 0;
                List<object[]> new_Rows = new List<object[]> { };

                DataTable dtDistinct = dt.DefaultView.ToTable(true, "SO", "Color");

                for (int i = 0; i < dtDistinct.Rows.Count; i++)
                {
                    string so = dtDistinct.Rows[i]["SO"].ToString();
                    subColor = dtDistinct.Rows[i]["Color"].ToString();

                    object[] newRow = { so, "SUM_Color", "", subColor };
                    new_Rows.Add(newRow);

                    //if (subSO != so || i == dtDistinct.Rows.Count - 1 || dtDistinct.Rows.Count == 1)
                    //{
                    //    object[] newRowSO = { so, "SUM_SO", "", "" };
                    //    new_Rows.Add(newRowSO);
                    //}
                    //subSO = so;
                }


                foreach (var row in new_Rows)
                {
                    dt.Rows.Add(row);
                }
                // Step 5️⃣: Identify matching rows and other rows based on both "SO" and "Color"
                List<object[]> matchingRows = new List<object[]>();
                List<object[]> otherRows = new List<object[]>();
                string subSO_s = "";
                for (int x = 0; x < new_Rows.Count; x++)
                {

                    string matchSO = new_Rows[x][Array.IndexOf(dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToArray(), "SO")].ToString();
                    string matchColor = new_Rows[x][Array.IndexOf(dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToArray(), "Color")].ToString();
                    // Compare both "SO" and "Color" columns

                    if (x == 0)
                    {
                        subSO_s = matchSO;
                    }

                    if (subSO_s != matchSO)
                    {
                        object[] newRowSO = { subSO_s, "SUM_SO", "", "" };
                        matchingRows.Add(newRowSO);
                    }


                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var row = dt.Rows[i];
                        string sso = row["SO"].ToString().Trim();
                        if (sso == matchSO.Trim() && row["Color"].ToString().Trim() == matchColor.Trim())
                        {
                            matchingRows.Add(row.ItemArray); // Store matching rows
                        }

                    }

                    if (x == new_Rows.Count - 1)
                    {
                        object[] newRowSO = { matchSO, "SUM_SO", "", "" };
                        matchingRows.Add(newRowSO);
                    }

                    subSO_s = matchSO;
                }
                // Step 6️⃣: Clear the DataTable and re-add rows in the desired order
                dt.Rows.Clear();
                // Then, add all matching rows, but place the newly added rows last
                foreach (object[] rowData in matchingRows)
                {
                    dt.Rows.Add(rowData);
                }
                gvDis.DataSource = dt;


                string txtCut = "";
                if (!cbDate.Checked)
                {
                    txtCut = "c.`Cut_ScanOut`  IS NOT NULL ";
                }
                else
                {
                    txtCut = "DATE(c.`Cut_ScanOut`) BETWEEN '" + setDate(dtpStart) + "' AND '" + setDate(dtpEnd) + "'";

                }



                string sqlString = @"SELECT `b`.`SO`,`b`.`Color`, `a`.`Size`,  SUM(`a`.`QTY`) AS `QTY` 
                                        FROM `a_b1_bundle_tb` AS `a`
                                        JOIN `a_a1_spreading_list_tb` AS `b` ON `b`.`SD_ListDoc_No`=`a`.`SD_ListDoc_No` AND `b`.`FabricType` LIKE 'A' AND `b`.`SD_Status` LIKE '1' AND `b`.`SO` IN " + formatted + @"
                                        JOIN a_a3_scandoc_sd_ct_tb AS c ON a.SD_ListDoc_No = c.SD_ListDoc_No AND " + txtCut + @"
                                        WHERE `a`.`MainPart` = '1'
                                        GROUP BY `b`.`SO`,`b`.`Color`,`a`.`Size`;  ";
                putData(sqlString, "Cutting");

                string txtSMK = "AND DATE(b.`TimeScan`) BETWEEN '" + setDate(dtpStart) + "' AND '" + setDate(dtpEnd) + "'";
                if (!cbDate.Checked) txtSMK = "";

                string txtQuery = @"WITH LatestScanOut AS (
                        SELECT 
                            `QrcodeBD`, 
                           `stINOUT`,
                            MAX(`TimeScan`) AS LatestTimeScan
                        FROM 
                            `a_b1_bundle_to_dec_tb`
                        WHERE 
                            `stINOUT` = '0'  AND `Decoration` LIKE 'SMK'
                        GROUP BY 
                            `QrcodeBD`
                    )
                                SELECT                                  
                                            `s`.`SO`,                                            
                                            `s`.`Color`, 
                                            `a`.`Size`,
                                           SUM(`b`.`QTY`) AS `QTY`
                                          FROM 
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
                                            " + txtSMK + @"
                                        WHERE   
                                               `a`.`MainPart`=1 AND `b`.`Dec_Out` ='Sewing' AND `s`.`FabricType` LIKE 'A' AND               
                                             `s`.`SO` IN " + formatted + @"
                                            AND `b`.`stINOUT` = 0   AND `b`.`Decoration` LIKE 'SMK' GROUP BY  `s`.`SO`,                                            
                                            `s`.`Color`, 
                                            `a`.`Size`;";
                putData(txtQuery, "SMK");

                string txtSewing = " AND DATE(`a`.`sb_scantime`) BETWEEN '" + setDate(dtpStart) + "' AND '" + setDate(dtpEnd) + "'";
                if (!cbDate.Checked) txtSewing = "";
                string txtQuerySewing = @"SELECT `b`.`SO`,`b`.`Color`, `a`.`sb_size` AS `Size`, SUM(`a`.`sb_qty`)AS `QTY` 
                   FROM `b_scaned_bundle` AS `a` 
                   JOIN `a_a1_spreading_list_tb` AS `b` ON `b`.`SD_ListDoc_No`=`a`.`sb_sdlistdocno` AND `b`.`FabricType` LIKE 'A' AND `b`.`SD_Status` LIKE '1' AND `b`.`SO` IN " + formatted + txtSewing + @"
                   GROUP BY `b`.`SO`,`b`.`Color`,`a`.`sb_size`;";
                putData(txtQuerySewing, "Sewing");

                string txtPack = " AND DATE(`a`.`pkg_date`) BETWEEN '" + setDate(dtpStart) + "' AND '" + setDate(dtpEnd) + "'";
                if (!cbDate.Checked) txtPack = "";
                string txtQueryPACKING = @"SELECT `b`.`SO`,`b`.`Color`, `a`.`sb_size` AS `Size`, SUM(`a`.`sb_qty`)AS `QTY` 
            FROM `b_scaned_bundle` AS `a` 
                   JOIN `a_a1_spreading_list_tb` AS `b` ON `b`.`SD_ListDoc_No`=`a`.`sb_sdlistdocno` AND `b`.`FabricType` LIKE 'A' AND `b`.`SD_Status` LIKE '1' AND `b`.`SO` IN " + formatted + txtPack + @"
                   WHERE `a`.`pkg_status` =1
                    GROUP BY `b`.`SO`,`b`.`Color`,`a`.`sb_size`; ";
                putData(txtQueryPACKING, "Packing");

                string txtFG = " AND DATE(`fgscanin_time`) BETWEEN '" + setDate(dtpStart) + "' AND '" + setDate(dtpEnd) + "'";
                if (!cbDate.Checked) txtFG = "";
                string txtQueryFG = @"SELECT  `fgscanin_so` AS `SO`, `fgscanin_color` AS `Color`, `fgscanin_size`AS `Size`, SUM(`fgscanin_qty`)AS `QTY` " +
                     "FROM `b_fgscanin` WHERE `fgscanin_so` IN " + formatted + txtFG + " GROUP BY  `fgscanin_so`,`fgscanin_color`,`fgscanin_size`;";
                putData(txtQueryFG, "FG");

                string txtSH = " AND DATE(`fgscanout_date`) BETWEEN '" + setDate(dtpStart) + "' AND '" + setDate(dtpEnd) + "'";
                if (!cbDate.Checked) txtSH = "";
                string txtQueryShipping = @"SELECT  `fgscanin_so` AS `SO`, `fgscanin_color` AS `Color`, `fgscanin_size`AS `Size`, SUM(`fgscanin_qty`)AS `QTY` " +
                     "FROM `b_fgscanin` WHERE `fgscanin_so` IN " + formatted + txtSH + " GROUP BY  `fgscanin_so`,`fgscanin_color`,`fgscanin_size`;";

                putData(txtQueryShipping, "Shipping");

                string subcolor = "";
                for (int i = 5; i < gvDis.Columns.Count; i++)
                {

                    int QTYSum = 0;
                    for (int j = 0; j < gvDis.Rows.Count; j++)
                    {
                        if (gvDis.Rows[j].Cells[i].Value != DBNull.Value)
                        {

                            int QTY = 0; // Default value if parsing fails

                            // Ensure the value is not null before calling ToString()
                            if (gvDis.Rows[j].Cells[i].Value != null)
                            {
                                string cellValue = gvDis.Rows[j].Cells[i].Value.ToString().Trim(); // Trim removes leading/trailing spaces

                                // Try parsing safely
                                if (!int.TryParse(cellValue, out QTY))
                                {
                                    QTY = 0; // Set to 0 if conversion fails
                                }
                            }
                            QTYSum += QTY;

                        }
                        string checkSum = gvDis.Rows[j].Cells["Style"].Value.ToString();



                        if (checkSum == "SUM_Color")
                        {
                            gvDis.Rows[j].Cells[i].Value = QTYSum;
                            QTYSum = 0;
                        }
                    }
                }
                int order = 0;
                int cut = 0;
                int print = 0;
                int Emp = 0;
                int SMK = 0;
                int sewing = 0;
                int washing = 0;
                int Packing = 0;
                int FG = 0;
                int Shipping = 0;

                //`Order` ,
                // NULL AS Cutting,NULL AS  Printing ,NULL AS Embroidery ,NULL AS SMK ,
                // NULL AS Sewing,NULL AS  Washing ,
                // NULL AS Packing ,NULL AS FG ,NULL AS Shipping

                for (int i = 0; i < gvDis.Rows.Count; i++)
                {
                    string checkSum = gvDis.Rows[i].Cells["Style"].Value.ToString();

                    if (checkSum == "SUM_Color")
                    {
                        gvDis.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                        gvDis.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                        gvDis.Rows[i].DefaultCellStyle.Font = new Font("Bahnschrift", 12, FontStyle.Bold);
                        var Row = gvDis.Rows[i];
                        order += int.Parse(Row.Cells["Order"].Value.ToString());
                        cut += int.Parse(Row.Cells["Cutting"].Value.ToString());
                        print += int.Parse(Row.Cells["Printing"].Value.ToString());
                        Emp += int.Parse(Row.Cells["Embroidery"].Value.ToString());
                        SMK += int.Parse(Row.Cells["SMK"].Value.ToString());
                        sewing += int.Parse(Row.Cells["Sewing"].Value.ToString());
                        washing += int.Parse(Row.Cells["Washing"].Value.ToString());
                        Packing += int.Parse(Row.Cells["Packing"].Value.ToString());
                        FG += int.Parse(Row.Cells["FG"].Value.ToString());
                        Shipping += int.Parse(Row.Cells["Shipping"].Value.ToString());
                    }
                    if (checkSum == "SUM_SO")
                    {
                        gvDis.Rows[i].DefaultCellStyle.BackColor = Color.Goldenrod;
                        gvDis.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                        gvDis.Rows[i].DefaultCellStyle.Font = new Font("Bahnschrift", 12, FontStyle.Bold);

                        var Row = gvDis.Rows[i];
                        Row.Cells["Order"].Value = order;
                        Row.Cells["Cutting"].Value = cut;
                        Row.Cells["Printing"].Value = print;
                        Row.Cells["Embroidery"].Value = Emp;
                        Row.Cells["SMK"].Value = SMK;
                        Row.Cells["Sewing"].Value = sewing;
                        Row.Cells["Washing"].Value = washing;
                        Row.Cells["Packing"].Value = Packing;
                        Row.Cells["FG"].Value = FG;
                        Row.Cells["Shipping"].Value = Shipping;

                        order = 0;
                        cut = 0;
                        print = 0;
                        Emp = 0;
                        SMK = 0;
                        sewing = 0;
                        washing = 0;
                        Packing = 0;
                        FG = 0;
                        Shipping = 0;
                    }

                }

                if (cbbDec.SelectedIndex == 0)
                {
                    for (int i = 0; i < gvDis.Columns.Count; i++)
                    {
                        var col = gvDis.Columns[i]; // Washing
                        if (col.HeaderText == "Embroidery" || col.HeaderText == "Printing" || col.HeaderText == "Washing")
                        {
                            col.Visible = false;
                        }
                    }
                }
                else if (cbbDec.SelectedIndex == 1)
                {
                    for (int i = 0; i < gvDis.Columns.Count; i++)
                    {
                        var col = gvDis.Columns[i]; // Washing
                        if (col.HeaderText == "Embroidery" || col.HeaderText == "Printing" || col.HeaderText == "Washing")
                        {
                            col.Visible = true;
                        }
                    }
                }
            }
        }
        public DataTable dt_Size = new DataTable();
        public DataTable dt_Color = new DataTable();

        private string setDate(Guna2DateTimePicker dtpDate)
        {
            string txtDate = "";
            System.Globalization.CultureInfo _cultureEnInfo = new System.Globalization.CultureInfo("en-US");
            DateTime date = Convert.ToDateTime(dtpDate.Value, _cultureEnInfo);
            txtDate = date.ToString("yyyy-MM-dd", _cultureEnInfo);
            return txtDate;
        }
        private void btSearch_Click(object sender, EventArgs e)
        {
            search(tbSearch.Text);
        }

        private void gvDis_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (e.ColumnIndex == 0 || e.ColumnIndex == 1 || e.ColumnIndex == 2 || e.ColumnIndex == 3)
            {
                if (gvDis[e.ColumnIndex, e.RowIndex].Value == null) return;

                System.Drawing.Rectangle rect = e.CellBounds;
                int startRow = e.RowIndex;
                int mergeHeight = rect.Height;

                // Find the first row of the merge group
                while (startRow > 0 &&
                       gvDis[e.ColumnIndex, startRow].Value != null &&
                       gvDis[e.ColumnIndex, startRow].Value.Equals(gvDis[e.ColumnIndex, startRow - 1].Value))
                {
                    startRow--;
                }

                // Find the last row of the merge group
                int endRow = startRow;
                while ((endRow + 1) < gvDis.RowCount &&
                       gvDis[e.ColumnIndex, endRow + 1].Value != null &&
                       gvDis[e.ColumnIndex, endRow + 1].Value.Equals(gvDis[e.ColumnIndex, startRow].Value))
                {
                    endRow++;
                    mergeHeight += gvDis.Rows[endRow].Height;
                }

                // Skip painting for all rows except the first row in the merged group
                if (e.RowIndex != startRow)
                {
                    e.Handled = true;
                    return;
                }

                // Ensure background color is consistently applied
                Color originalBackColor = gvDis[e.ColumnIndex, e.RowIndex].Style.BackColor;
                if (originalBackColor == Color.Empty)
                {
                    originalBackColor = gvDis.DefaultCellStyle.BackColor;
                }

                rect.Y = gvDis.GetRowDisplayRectangle(startRow, true).Y;
                rect.Height = mergeHeight;

                // Paint background
                using (Brush brush = new SolidBrush(originalBackColor))
                {
                    e.Graphics.FillRectangle(brush, rect);
                }

                // Draw cell border
                e.Graphics.DrawRectangle(SystemPens.Control, rect);

                // Get text value
                string text = gvDis[e.ColumnIndex, startRow].Value.ToString();

                using (Font font = new Font("Bahnschrift", 15, FontStyle.Regular))
                {
                    Size textSize = TextRenderer.MeasureText(text, font);

                    // Ensure the column width is wide enough to fit the text
                    if (gvDis.Columns[e.ColumnIndex].Width < textSize.Width + 10)
                    {
                        gvDis.Columns[e.ColumnIndex].Width = textSize.Width + 10;
                    }

                    System.Drawing.Rectangle textRect = new System.Drawing.Rectangle(rect.X + 5, rect.Y, gvDis.Columns[e.ColumnIndex].Width - 10, rect.Height);

                    TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak;
                    TextRenderer.DrawText(e.Graphics, text, font, textRect, SystemColors.ControlText, flags);
                }

                e.Handled = true;
            }
        }
        public void EnableDoubleBuffering()
        {
            Type dgvType = gvDis.GetType();
            System.Reflection.PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            pi.SetValue(gvDis, true, null);
        }
        private void putData(string sqlString, string department)
        {
            DataTable dt = new DataTable();
            dt = ConnectMySQL.MySQLtoDataTable(sqlString);
            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < gvDis.Rows.Count; i++)
                {
                    for (int k = 0; k < dt.Rows.Count; k++)//
                    {

                        if (dt.Rows[k]["SO"].ToString() == gvDis.Rows[i].Cells["SO"].Value.ToString() &&
                            dt.Rows[k]["Size"].ToString() == gvDis.Rows[i].Cells["Size"].Value.ToString() &&
                            dt.Rows[k]["Color"].ToString() == gvDis.Rows[i].Cells["Color"].Value.ToString())
                        {

                            gvDis.Rows[i].Cells[department].Value = dt.Rows[k]["QTY"];

                        }
                    }
                }


            }

        }

        private void tbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                if (tbSearch.Text.Length > 10)
                {
                    search(tbSearch.Text);
                }
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

        private void gvDis_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void btCompare_Click(object sender, EventArgs e)
        {


            ReportCompareNew reportCompareNew = new ReportCompareNew();
            reportCompareNew.Show();

        }

        private void btBundle_Click(object sender, EventArgs e)
        {
            SoBundleReport SoBundleReport = new SoBundleReport();
            SoBundleReport.Show();
        }

        private void gvDis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbDate_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDate.Checked)
            {
                dtpStart.Visible = true;
                dtpEnd.Visible = true;
            }
            else
            {
                dtpStart.Visible = false;
                dtpEnd.Visible = false;
            }
        }

        private void tbTimeline_Click(object sender, EventArgs e)
        {

        }
    }
}
