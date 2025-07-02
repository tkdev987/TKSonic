using PTS_For_Cut.Main;
using PTS_For_Cut.Myclass;
using System.Data;
using DataTable = System.Data.DataTable;

namespace PTS_For_Cut._9Report
{
    public partial class ReportCompareNew : Form
    {
        public static ReportCompareNew Ins;
        public ReportCompareNew()
        {
            InitializeComponent();
            Ins = this;
        }

        private void ReportCompareNew_Load(object sender, EventArgs e)
        {

        }

        public string so_ = "";
        private void search_()
        {
            setUpStructureTB(
@"SELECT a.`Color`, a.`Size`,SUM(a.`Qty`) AS `QTY` 
                        FROM `so_tb` a
                        LEFT JOIN sizes_tb s ON s.`Size` = a.`Size`
                        WHERE a.`So`LIKE '" + tbSO.Text + @"'
                        GROUP BY a.`Color`, a.`Size` ORDER BY s.`SeqNo` ASC;");

            string sqlString = @"SELECT `b`.`Color`, `a`.`Size`,  SUM(`a`.`QTY`)AS `QTY` 
                                        FROM `a_b1_bundle_tb` AS `a`
                                        JOIN `a_a1_spreading_list_tb` AS `b` ON `b`.`SD_ListDoc_No`=`a`.`SD_ListDoc_No` AND `b`.`FabricType` LIKE 'A' AND `b`.`SD_Status` LIKE '1' AND `b`.`SO`= '" + tbSO.Text + "' " + @"
                                        JOIN a_a3_scandoc_sd_ct_tb AS c ON a.SD_ListDoc_No = c.SD_ListDoc_No AND c.wh_scanout  IS NOT NULL 
                                        WHERE `a`.`MainPart` = '1'
                                        GROUP BY `b`.`Color`,`a`.`Size`; ";
            putData(sqlString, "Cutting");
            string txtQuery = @"SELECT 
                                b.Color,
                                b.Size,
                                SUM(c.QTY) AS `QTY`
                                FROM 
                                `a_a1_spreading_list_tb` AS a
                                JOIN 
                                  `a_b1_bundle_tb` AS b ON a.`SD_ListDoc_No` = b.`SD_ListDoc_No` AND a.`FabricType` LIKE 'A' AND a.`SD_Status` LIKE '1'
                                JOIN 
                                    (
                                        SELECT 
                                            t1.`QrcodeBD`, 
                                            t1.`Decoration`, 
                                            t1.`Dec_Out`, 
                                            t1.`QTY`
                                        FROM 
                                            `a_b1_bundle_to_dec_tb` t1
                                        INNER JOIN (
                                            SELECT 
                                                `QrcodeBD`, 
                                                MAX(`TimeScan`) AS `LatestTimeScan`
                                            FROM 
                                                `a_b1_bundle_to_dec_tb`
                                            WHERE `Decoration` = 'SMK'
                                            GROUP BY 
                                                `QrcodeBD`
                                        ) t2 ON 
                                            t1.`QrcodeBD` = t2.`QrcodeBD` 
                                            AND t1.`TimeScan` = t2.`LatestTimeScan`) AS c ON b.`QRCodeBundle` = c.`QrcodeBD`
                                WHERE 
                                    a.`SO` LIKE '" + tbSO.Text + "' " + @"
                                    AND b.`MainPart` = 1
                                    AND c.`Dec_Out` = 'Sewing'
                                    AND c.`Decoration` = 'SMK'
                                GROUP BY 
                                    b.Color,
                                    b.Size;";
            putData(txtQuery, "SMK");

            string txtQuerySewing = @"SELECT `b`.`Color`, `a`.`sb_size` AS `Size`, SUM(`a`.`sb_qty`)AS `QTY` " +
                   "FROM `b_scaned_bundle` AS `a` " +
                   "JOIN `a_a1_spreading_list_tb` AS `b` ON `b`.`SD_ListDoc_No`=`a`.`sb_sdlistdocno` AND `b`.`FabricType` LIKE 'A' AND `b`.`SD_Status` LIKE '1' AND `b`.`SO`='" + tbSO.Text + "' " +
                   "GROUP BY`b`.`Color`,`a`.`sb_size`;";
            putData(txtQuerySewing, "Sewing");

            string txtQueryPACKING = @"SELECT  `fgscanin_color` AS `Color`, `fgscanin_size`AS `Size`, SUM(`fgscanin_qty`)AS `QTY` " +
                  "FROM `b_fgscanin` WHERE `fgscanin_so` LIKE '" + tbSO.Text + "' GROUP BY `fgscanin_color`,`fgscanin_size`";
            putData(txtQueryPACKING, "Packing");


            string txtQueryDefect = "SELECT `DefectList`, `Color`, `Size`, `Department`, SUM(`QTY`) AS 'QTY' " +
                "FROM `a_defect_so_report` WHERE  `SO` LIKE '" + tbSO.Text + "' GROUP BY `SO`,`DefectList`, `Color`, `Size`, `Department`;";
            DataTable dt = new DataTable();
            dt = ConnectMySQL.MySQLtoDataTable(txtQueryDefect);

            for (int i = 0; i < gvDis.Rows.Count; i++)
            {
                for (int j = gvDis.Columns.Count - defect_dt.Rows.Count; j < gvDis.Columns.Count; j++)
                {
                    for (int k = 0; k < dt.Rows.Count; k++)//
                    {

                        if (dt.Rows[k]["DefectList"].ToString() == gvDis.Columns[j].HeaderText &&
                            dt.Rows[k]["Color"].ToString() == gvDis.Rows[i].Cells["Color"].Value.ToString() &&
                            gvDis.Rows[i].Cells["Department"].Value.ToString() == dt.Rows[k]["Department"].ToString())
                        {
                            gvDis.Rows[i].Cells[j].Value = gvDis.Rows[i].Cells[j].Value.ToString() + dt.Rows[k]["Size"].ToString() + "=" + dt.Rows[k]["QTY"].ToString() + ",";
                        }
                    }
                }
            }



            so_ = tbSO.Text;

        }

        private void putData(string sqlString, string department)
        {

            DataTable dt = new DataTable();
            dt = ConnectMySQL.MySQLtoDataTable(sqlString);

            for (int i = 0; i < gvDis.Rows.Count; i++)
            {
                for (int j = 2; j < gvDis.Columns.Count; j++)
                {
                    for (int k = 0; k < dt.Rows.Count; k++)//
                    {

                        if (dt.Rows[k]["Size"].ToString() == gvDis.Columns[j].HeaderText &&
                            dt.Rows[k]["Color"].ToString() == gvDis.Rows[i].Cells["Color"].Value.ToString() &&
                            gvDis.Rows[i].Cells["Department"].Value.ToString() == department)
                        {
                            gvDis.Rows[i].Cells[j].Value = dt.Rows[k]["QTY"];
                        }
                    }
                }
            }

        }
        public DataTable dt_Size = new DataTable();
        public DataTable dt_Color = new DataTable();
        public DataTable defect_dt = new DataTable();
        private void setUpStructureTB(string txtQuery)
        {
            DataTable dt_Query = new DataTable();
            dt_Query = ConnectMySQL.MySQLtoDataTable(txtQuery);

            gvDis.DataSource = new DataTable();
            if (dt_Query.Rows.Count > 0)
            {


                dt_Size = dt_Query.DefaultView.ToTable(true, "Size");
                DataTable col = new DataTable();
                col.Columns.Add("Color");
                col.Columns.Add("Department");
                foreach (DataRow row in dt_Size.Rows)
                {
                    col.Columns.Add(row[0].ToString());
                }

                defect_dt = ConnectMySQL.MySQLtoDataTable("SELECT `DefectList` FROM `a_defect_list_so_report` WHERE 1");
                foreach (DataRow row in defect_dt.Rows)
                {
                    col.Columns.Add(row[0].ToString());
                }

                dt_Color = dt_Query.DefaultView.ToTable(true, "Color");
                foreach (DataRow row in dt_Color.Rows)
                {

                    col.Rows.Add(row[0].ToString(), "Order");
                    col.Rows.Add(row[0].ToString(), "Cutting");
                    col.Rows.Add(row[0].ToString(), "Printing"); //EMBROIDERY
                    col.Rows.Add(row[0].ToString(), "Embroidery");
                    col.Rows.Add(row[0].ToString(), "SMK");
                    col.Rows.Add(row[0].ToString(), "Sewing");
                    col.Rows.Add(row[0].ToString(), "Packing");
                    col.Rows.Add(row[0].ToString(), "FG");//Shipping
                    col.Rows.Add(row[0].ToString(), "Shipping");

                }
                //dt_Query

                for (int i = 0; i < col.Rows.Count; i++)
                {
                    for (int j = 2; j < col.Columns.Count; j++)
                    {
                        for (int k = 0; k < dt_Query.Rows.Count; k++)//
                        {
                            if (dt_Query.Rows[k]["Size"].ToString() == col.Columns[j].ToString() &&
                                dt_Query.Rows[k]["Color"].ToString() == col.Rows[i]["Color"].ToString() &&
                                col.Rows[i]["Department"].ToString() == "Order")
                            {
                                col.Rows[i][j] = dt_Query.Rows[k]["QTY"];
                            }
                        }
                    }
                }




                gvDis.DataSource = col;
                colorofcolor();
                int checkDefectZone = defect_dt.Rows.Count;
                for (int i = gvDis.Columns.Count - checkDefectZone; i < gvDis.Columns.Count; i++)
                {
                    for (int j = 0; j < gvDis.Rows.Count; j++)
                    {
                        gvDis.Rows[j].Cells[i].Style.BackColor = Color.WhiteSmoke; // Set cell-specific style
                    }
                }

                gvDis.Columns[0].Width = 250;

            }
        }
        private void colorofcolor()
        {
            string checkDryLot = "";
            bool ph = false;
            if (gvDis.Rows.Count > 0)
            {
                for (int i = 0; i < gvDis.Rows.Count; i++)
                {
                    string drylot = gvDis.Rows[i].Cells["Color"].Value.ToString();
                    if (checkDryLot != drylot)
                    {
                        if (!ph)
                        {
                            ph = true;
                        }
                        else
                        {
                            ph = false;
                        }
                    }

                    if (ph)
                    {
                        gvDis.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                    }
                    else
                    {
                        gvDis.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    }


                    checkDryLot = drylot;
                }
            }
        }
        private void btSearchSO_Click(object sender, EventArgs e)
        {
            search_();
        }

        private void btAddDefect_Click(object sender, EventArgs e)
        {
            //ReportCompareNew_AddDefect
            if (HomePage.ins.checkPermiss("DefectAt_SOReport"))
            {
                using (ReportCompareNew_AddDefect di = new ReportCompareNew_AddDefect())
                {
                    if (di.ShowDialog() == DialogResult.OK)
                    {

                    }
                }
            }
        }

        private void btDefectRecord_Click(object sender, EventArgs e)
        {

            if (HomePage.ins.checkPermiss("DefectAt_SOReport"))
            {
                using (ReportCompareNewRecordDefect di = new ReportCompareNewRecordDefect())
                {
                    if (di.ShowDialog() == DialogResult.OK)
                    {
                        search_();
                    }
                }
            }
        }
        public string Color_ = "";
        public string Depart_ = "";
        public string Size_ = "";

        private void gvDis_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tbSO_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)

            {
                search_();
            }
        }

        private void btExporttoExcel_Click(object sender, EventArgs e)
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
    }
}
