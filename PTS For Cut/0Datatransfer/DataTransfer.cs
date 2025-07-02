using PTS_For_Cut.Main;
using PTS_For_Cut.Myclass;
using System.Data;
using DataTable = System.Data.DataTable;

namespace PTS_For_Cut._0Datatransfer
{
    public partial class DataTransfer : Form
    {


        // MySqlConnection connectionA = new MySqlConnection("datasource=12.0.100.251;port=3306;username=root1;password='88888888';database=pts_db;convert zero datetime=True");
        // MySqlConnection connectionB = new MySqlConnection("datasource=192.168.1.253;port=3306;username=root1;password='88888888';database=pts_db;convert zero datetime=True");
        public DataTransfer()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private DataTable Factory_dt = new DataTable();
        private string original_IP = "";
        private void DataTransfer_Load(object sender, EventArgs e)
        {
            original_IP = ConnectMySQL.ip;
            Factory_dt = HomePage.ins.Factory_dt;
            cbbFactory.Items.Clear();
            for (int i = 0; i < Factory_dt.Rows.Count; i++)
            {
                cbbFactory.Items.Add(Factory_dt.Rows[i]["FactoryCode"].ToString());
            }

        }


        bool loadData_Test(string Query)
        {
            string selectQuery = Query;
            gvDis.DataSource = null;
            //datasource = 103.239.52.204; Port = 85;
            ConnectMySQL.ip = tbIP.Text;
            //  ConnectMySQL.IPport = "8080";
            ConnectMySQL.DisplayAndSearch(selectQuery, gvDis);
            ConnectMySQL.ip = original_IP;
            return true;
        }
        private string txtDate()
        {
            string txtDate = "";
            System.Globalization.CultureInfo _cultureEnInfo = new System.Globalization.CultureInfo("en-US");
            DateTime dateEng = Convert.ToDateTime(DateTime.Now, _cultureEnInfo);
            txtDate = dateEng.ToString("yyyy-MM-dd", _cultureEnInfo);
            return txtDate;
        }
        private void btloadGetPart_Click(object sender, EventArgs e)
        {


        }


        string ConvertDataGridViewToString(DataGridView dataGridView)
        {
            List<string> rowsList = new List<string>();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (!row.IsNewRow) // Skip the last new row added by DataGridView
                {
                    List<string> cellValues = new List<string>();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cellValues.Add($"'{cell.Value?.ToString()}'");
                    }
                    rowsList.Add($"({string.Join(",", cellValues)})");
                }
            }
            string result = string.Join(",", rowsList);
            return result;
        }
        string ConvertDataTableToString(DataTable dataTable)
        {
            List<string> rowsList = new List<string>();

            foreach (DataRow row in dataTable.Rows)
            {
                List<string> cellValues = new List<string>();
                foreach (var item in row.ItemArray)
                {

                    if (item is DateTime dateTime)
                    {
                        // Format DateTime to "yyyy-MM-dd HH:mm:ss"
                        cellValues.Add($"'{dateTime.ToString("yyyy-MM-dd HH:mm:ss")}'");
                    }
                    else
                    {
                        cellValues.Add($"'{item?.ToString()}'");
                    }
                }
                rowsList.Add($"({string.Join(",", cellValues)})");
            }
            string result = string.Join(",", rowsList);

            return result;

        }
        string converttbToString(DataTable dataTable)
        {
            List<string> rowsList = new List<string>();

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                List<string> cellValues = new List<string>();

                for (int j = 0; j < dataTable.Rows[i].ItemArray.Length; j++)
                {
                    var item = dataTable.Rows[i].ItemArray[j];

                    if (j == 0)
                    {
                        cellValues.Add("NULL"); // Handle the first column as NULL
                    }
                    else
                    {
                        if (item == null || item == DBNull.Value)
                        {
                            cellValues.Add("NULL");
                        }
                        else if (item is DateTime dateTime)
                        {
                            // Format DateTime
                            cellValues.Add($"'{dateTime:yyyy-MM-dd}'");
                        }
                        else
                        {
                            // Escape single quotes in string values
                            cellValues.Add($"'{item.ToString().Replace("'", "''")}'");
                        }
                    }
                }

                rowsList.Add($"({string.Join(",", cellValues)})");
            }

            return string.Join(",", rowsList);
        }


        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btSOup_Click(object sender, EventArgs e)
        {


        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        bool checkcanUpLoadby_gv = false;
        private void btSDLoad_Click(object sender, EventArgs e)
        {
            //SELECT DISTINCT( `b`.`SD_ListDoc_No`) FROM `a_b1_bundle_tb` AS `b` JOIN `a_a1_spreading_list_tb` `a` ON `a`.`SD_ListDoc_No` = `b`.`SD_ListDoc_No` WHERE `a`.`SO` LIKE '%SOSTM24/0022%';


            //string selectQuery = @"
            //        SELECT `SD_ListDoc_No`, `SO`, `FabricType`, `Style`, `SMVcut`, `SMVsew`, `Mark_ID`, `Table_No`, `DateCreate`, 
            //        `Color`, `chShad`, `Marker_Width`, `Marker_LengthCm`, `Marker_LengthYard`, `User`, `SD_Status`, `Combo`, 
            //        `TTEM`, `Country`, `LastActive` FROM `a_a1_spreading_list_tb` 
            //        WHERE `SO` LIKE '%" + tbSO.Text + "'%";

            //ConnectMySQL.ip = tbIP.Text;

            //ConnectMySQL.DisplayAndSearch(selectQuery, gvDis);
            //ConnectMySQL.ip = original_IP;
        }

        private void gvDis_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void GetPart()
        {
            bool s1 = false;
            bool s2 = false;
            bool s3 = false;
            // MessageBox.Show(indexColumn.ToString() +"||"+indexRow.ToString());
            if (indexRow > -1)
            {
                string getSDID = gvDis.Rows[indexRow].Cells["SD_ListDoc_No"].Value.ToString();//chShad

                string selectQuery = @"
                        SELECT `SD_ListDoc_No`, `SO`, `FabricType`, `Style`, `SMVcut`, `SMVsew`, `Mark_ID`, `Table_No`, `DateCreate`, 
                        `Color`, 
                        CASE
                            WHEN `chShad` = 1 THEN '1'
                        ELSE '0'                        
                        END AS 'chShad',
                          `Marker_Width`, `Marker_LengthCm`, `Marker_LengthYard`, `User`, `SD_Status`, `Combo`, 
                        `TTEM`, `Country`, `LastActive` FROM `a_a1_spreading_list_tb` 
                        WHERE `SD_ListDoc_No` LIKE '%" + getSDID + "%'";
                ConnectMySQL.ip = tbIP.Text;
                DataTable dtSD = ConnectMySQL.MySQLtoDataTable(selectQuery);
                ConnectMySQL.ip = original_IP;

                if (dtSD.Rows.Count > 0)
                {
                    guna2DataGridView1.DataSource = null;
                    guna2DataGridView1.DataSource = dtSD;
                    ConnectMySQL.MysqlQuery("DELETE FROM `a_a1_spreading_list_tb` WHERE `SD_ListDoc_No` LIKE '" + getSDID + "'");
                    string insertQuery = @" INSERT INTO `a_a1_spreading_list_tb`(`SD_ListDoc_No`, `SO`, `FabricType`, `Style`, `SMVcut`, `SMVsew`, `Mark_ID`, 
                    `Table_No`, `DateCreate`, `Color`, `chShad`, `Marker_Width`, `Marker_LengthCm`, `Marker_LengthYard`, `User`, `SD_Status`, `Combo`, `TTEM`, 
                    `Country`, `LastActive`) VALUES " + ConvertDataTableToString(dtSD);
                    //MessageBox.Show(insertQuery);
                    bool st = ConnectMySQL.MysqlQuery(insertQuery);

                    if (st)
                    {
                        MessageBox.Show("Upload Spreading List " + getSDID + " Finished");
                        s1 = true;
                        //gvDis.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Green;
                    }
                    else
                    {
                        // MessageBox.Show("Spreading List Error");
                        MessageBox.Show("Upload Spreading List No" + getSDID + " Error ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //gvDis.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
                    }
                }
                else
                {
                    // MessageBox.Show("Spreading List Don't Have Data");
                    MessageBox.Show("Spreading List No" + getSDID + " Don't Have Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //--------------------------------------------------------------------------------------------------------------------------------------------
                string SQLS_D_ = @"
                    SELECT `b`.`SD_ListDoc_No`, `b`.`wh_scanout`, `b`.`SD_ScanIn`, `b`.`SD_ScanOut`, `b`.`Cut_ScanIn`, `b`.`Cut_ScanOut`, 
                        CASE
                            WHEN `b`.`ID_fabric_call` = 1 THEN '1'
                        ELSE '0'                        
                        END AS 'ID_fabric_call'
                    FROM `a_a3_scandoc_sd_ct_tb` `b`                              
                    WHERE `b`.`SD_ListDoc_No` LIKE '" + getSDID + "'";

                ConnectMySQL.ip = tbIP.Text;
                DataTable dtS_D_ = ConnectMySQL.MySQLtoDataTable(SQLS_D_);
                ConnectMySQL.ip = original_IP;
                if (dtS_D_.Rows.Count > 0)
                {
                    guna2DataGridView1.DataSource = null;
                    guna2DataGridView1.DataSource = dtS_D_;
                    ConnectMySQL.MysqlQuery("DELETE FROM `a_a3_scandoc_sd_ct_tb` WHERE `SD_ListDoc_No` LIKE '" + getSDID + "'");
                    string insertQuery1 = @" INSERT INTO `a_a3_scandoc_sd_ct_tb`(`SD_ListDoc_No`, `wh_scanout`, `SD_ScanIn`, `SD_ScanOut`, `Cut_ScanIn`, `Cut_ScanOut`, 
                    `ID_fabric_call`) VALUES " + ConvertDataTableToString(dtS_D_);

                    bool st1 = ConnectMySQL.MysqlQuery(insertQuery1);
                    //ConnectMySQL.ip = "12.0.100.251";
                    //ConnectMySQL.IPport = "3306";
                    if (st1)
                    {
                        s2 = true;
                        MessageBox.Show("Upload Spreading Scan " + getSDID + " Finished");
                        //gvDis.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Green;
                    }
                    else
                    {
                        MessageBox.Show("Upload Spreading Scan " + getSDID + "  Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // gvDis.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
                    }
                }
                else
                {
                    MessageBox.Show("Spreading List No" + getSDID + " Don't Have Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //--------------------------------------------------------------------------------------------------------------------------------------------
                //
                string SQLBD = @"
                   SELECT NULL, `QRCodeBundle`, `SD_ListDoc_No`, `BundleNo`, `Color`, `Size`, `DyeLot`, `ClothingPart`,
                    CASE
                        WHEN `MainPart` = 1 THEN '1'
                        ELSE '0'                        
                    END AS 'Main',
                    `Plies`, `QTY`, `Deco`, `is_active`, 
                    CASE
                        WHEN `SMKcheck` = 1 THEN '1'
                        ELSE '0'                        
                    END AS 'SMKcheck', `SO`, `FabricType` FROM `a_b1_bundle_tb`                            
                    WHERE `SD_ListDoc_No` LIKE '%" + getSDID + "%'";

                ConnectMySQL.ip = tbIP.Text;
                DataTable dtBD = ConnectMySQL.MySQLtoDataTable(SQLBD);
                ConnectMySQL.ip = original_IP;
                if (dtS_D_.Rows.Count > 0)
                {
                    guna2DataGridView1.DataSource = null;
                    guna2DataGridView1.DataSource = dtBD;
                    ConnectMySQL.MysqlQuery("DELETE FROM `a_b1_bundle_tb` WHERE `SD_ListDoc_No` LIKE '" + getSDID + "'");
                    string insertQuery2 = @"INSERT INTO `a_b1_bundle_tb`(`Bundle_ID`, `QRCodeBundle`, `SD_ListDoc_No`, `BundleNo`, `Color`, `Size`, `DyeLot`, `ClothingPart`,
                `MainPart`, `Plies`, `QTY`, `Deco`, `is_active`, `SMKcheck`, `SO`, `FabricType`) VALUES " + ConvertDataTableToString(dtBD);
                    /// MessageBox.Show(insertQuery2);
                    bool st2 = ConnectMySQL.MysqlQuery(insertQuery2);
                    //ConnectMySQL.ip = "12.0.100.251";
                    //ConnectMySQL.IPport = "3306";
                    if (st2)
                    {
                        s3 = true;
                        MessageBox.Show("Upload Bundle of " + getSDID + " Finished");

                        //gvDis.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Green;
                    }
                    else
                    {
                        //MessageBox.Show("Bundle Error");
                        //gvDis.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
                        MessageBox.Show("Upload Bundle of " + getSDID + " Error ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Spreading List No" + getSDID + " Don't Have Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // checkcanUpLoadby_gv = false;

                //------------------------------------------------------------------------------------------------------------------------
                string decreaseQTY = @" SELECT NULL, `Decoration`, `BD_QRCode_Ref`, `QTY`, `userID`, `DateTime`, 
                        `SD_ListDoc_No`, `SO`, `Remark`, `BundleNo` FROM `a_decrease_qty` WHERE `SD_ListDoc_No` ='" + getSDID + "';";
                ConnectMySQL.ip = tbIP.Text;
                DataTable dt_decrease = ConnectMySQL.MySQLtoDataTable(decreaseQTY);
                ConnectMySQL.ip = original_IP;
                if (dt_decrease.Rows.Count > 0)
                {
                    guna2DataGridView1.DataSource = null;
                    guna2DataGridView1.DataSource = dt_decrease;
                    ConnectMySQL.MysqlQuery("DELETE FROM `a_decrease_qty` WHERE `SD_ListDoc_No` LIKE '" + getSDID + "'");
                    string insertdecrease = @"INSERT INTO `a_decrease_qty`(`id`, `Decoration`, `BD_QRCode_Ref`, `QTY`, `userID`, `DateTime`, 
                                            `SD_ListDoc_No`, `SO`, `Remark`, `BundleNo`) VALUES " + ConvertDataTableToString(dt_decrease);
                    /// MessageBox.Show(insertQuery2);
                    bool st2 = ConnectMySQL.MysqlQuery(insertdecrease);
                    //ConnectMySQL.ip = "12.0.100.251";
                    //ConnectMySQL.IPport = "3306";
                    if (st2)
                    {
                        s3 = true;
                        MessageBox.Show("QTY Adjust Already for " + getSDID + " Finished");

                        //gvDis.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Green;
                    }
                    else
                    {
                        s3 = true;
                        //MessageBox.Show("Bundle Error");
                        //gvDis.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
                        MessageBox.Show("QTY Adjust of " + getSDID + " Error ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (s1 && s2 && s3)
                {
                    gvDis.Rows[indexRow].Cells["Status"].Value = "Pass";
                }

            }
            indexColumn = -1;
            indexRow = -1;
        }

        private void cbbFactory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbFactory.SelectedIndex > -1)
            {

                for (int i = 0; i < Factory_dt.Rows.Count; i++)
                {
                    //MessageBox.Show(Factory_dt.Rows[i]["FactoryCode"].ToString());
                    if (cbbFactory.Text == Factory_dt.Rows[i]["FactoryCode"].ToString())
                    {
                        tbIP.Text = Factory_dt.Rows[i]["ip_Network"].ToString();
                    }

                }
            }
        }

        private void btDownloadSD_Click(object sender, EventArgs e)
        {
            string selectQuery = "";
            if (cbbFunctionSelect.SelectedIndex == 0)
            {
                selectQuery = @"SELECT DISTINCT( a.`SD_ListDoc_No`) AS `SD_ListDoc_No` ,a.`Color`,'Status' AS `Status` FROM `a_a1_spreading_list_tb` AS a 
            JOIN `a_b1_bundle_tb` AS b ON b.`SD_ListDoc_No`=a.SD_ListDoc_No WHERE a.`SO` LIKE '" + tbSO.Text + @"' AND a.`FabricType` LIKE 'A' AND a.`SD_Status`=1 
            GROUP BY a.`SD_ListDoc_No`;";
            }
            else if (cbbFunctionSelect.SelectedIndex == 1)
            {
                selectQuery = @"SELECT DISTINCT( a.`SD_ListDoc_No`) AS `SD_ListDoc_No` ,a.`Color`,'Status' AS `Status` FROM `a_a1_spreading_list_tb` AS a 
            WHERE a.`SO` LIKE '" + tbSO.Text + @"' AND a.`FabricType` LIKE 'A' AND a.`SD_Status`=1 
            GROUP BY a.`SD_ListDoc_No`;";
            }

            ConnectMySQL.ip = tbIP.Text;
            ConnectMySQL.DisplayAndSearch(selectQuery, gvDis);
            ConnectMySQL.ip = original_IP;

        }

        private void btSDUpload_Click(object sender, EventArgs e)
        {
            if (cbbFunctionSelect.SelectedIndex == 0)
            {// Get Part
                GetPart();
            }
            else if (cbbFunctionSelect.SelectedIndex == 1)
            {//Get Fabric & SD Doc
                getFabricAndSD();
            }
        }


        private int indexRow;
        private int indexColumn;
        private void gvDis_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                indexRow = e.RowIndex;
                indexColumn = e.ColumnIndex;
                lbSDNO.Text = gvDis.Rows[indexRow].Cells[0].Value.ToString();
            }
        }
        private void getFabricAndSD()
        {

            bool s1 = false;
            bool s2 = false;
            bool s3 = false;
            bool s4 = false;
            bool s5 = false;
            bool s6 = false;
            if (indexColumn > -1 && indexRow > -1)
            {
                string getSDID = gvDis.Rows[indexRow].Cells["SD_ListDoc_No"].Value.ToString();

                string selectQuery = @"
                       SELECT `SD_ListDoc_No`, `SO`, `FabricType`, `Style`, `SMVcut`, `SMVsew`, `Mark_ID`, `Table_No`, `DateCreate`, 
                        `Color`, 
                        CASE
                            WHEN `chShad` = 1 THEN '1'
                        ELSE '0'                        
                        END AS 'chShad',
                         `Marker_Width`, `Marker_LengthCm`, `Marker_LengthYard`, `User`, `SD_Status`, `Combo`, 
                        `TTEM`, `Country`, `LastActive` FROM `a_a1_spreading_list_tb` 
                        WHERE `SD_ListDoc_No` LIKE '%" + getSDID + "%'";
                ConnectMySQL.ip = tbIP.Text;
                DataTable dtSD = ConnectMySQL.MySQLtoDataTable(selectQuery);
                ConnectMySQL.ip = original_IP;

                if (dtSD.Rows.Count > 0)
                {
                    guna2DataGridView1.DataSource = null;
                    guna2DataGridView1.DataSource = dtSD;

                    string insertQuery = @"DELETE FROM `a_a1_spreading_list_tb` WHERE `SD_ListDoc_No` LIKE '" + getSDID + @"' ;  INSERT INTO `a_a1_spreading_list_tb`(`SD_ListDoc_No`, `SO`, `FabricType`, `Style`, `SMVcut`, `SMVsew`, `Mark_ID`, 
                    `Table_No`, `DateCreate`, `Color`, `chShad`, `Marker_Width`, `Marker_LengthCm`, `Marker_LengthYard`, `User`, `SD_Status`, `Combo`, `TTEM`, 
                    `Country`, `LastActive`) VALUES " + ConvertDataTableToString(dtSD);
                    //MessageBox.Show(insertQuery);
                    bool st = ConnectMySQL.MysqlQuery(insertQuery);

                    if (st)
                    {
                        MessageBox.Show("Upload Spreading List " + getSDID + " Finished");
                        s1 = true;
                        //gvDis.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Green;
                    }
                    else
                    {
                        MessageBox.Show("Upload Spreading List No" + getSDID + " Error ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //gvDis.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
                    }
                }
                else
                {
                    MessageBox.Show("Spreading List No" + getSDID + " Don't Have Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //SELECT `No`, `SD_ListDoc_No`, `Plies`, `Size`, `RatioQTY` FROM `a_a2_spreading_detail_tb` WHERE `SD_ListDoc_No` LIKE ''
                string selectQuery1 = @"
                        SELECT NULL, `SD_ListDoc_No`, `Plies`, `Size`, `RatioQTY` FROM `a_a2_spreading_detail_tb` WHERE `SD_ListDoc_No` LIKE '%" + getSDID + "%'";

                ConnectMySQL.ip = tbIP.Text;
                DataTable dtSDDetail = ConnectMySQL.MySQLtoDataTable(selectQuery1);
                ConnectMySQL.ip = original_IP;
                guna2DataGridView1.DataSource = null;
                guna2DataGridView1.DataSource = dtSDDetail; //
                ConnectMySQL.MysqlQuery("DELETE FROM `a_a2_spreading_detail_tb` WHERE `SD_ListDoc_No` LIKE '" + getSDID + "'");
                string insertQuery1 = @" INSERT INTO `a_a2_spreading_detail_tb`(`No`, `SD_ListDoc_No`, `Plies`, `Size`, `RatioQTY`) VALUES " + ConvertDataTableToString(dtSDDetail);
                //MessageBox.Show(insertQuery);
                bool st1 = ConnectMySQL.MysqlQuery(insertQuery1);
                if (st1)
                {
                    MessageBox.Show("Upload Spreading Detail " + getSDID + " Finished");
                    s2 = true;
                    //gvDis.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Green;
                }
                else
                {
                    MessageBox.Show("Upload Spreading Detail No" + getSDID + " Error ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //gvDis.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
                }
                //SELECT `BcID`, `Barcode`, `CreateDate`, `Qty`, `QtyNet`, `YardNet`, `SD_ListDoc_No`, `Plies`, `PliesActual`, `RestFabric`, `Defect`, `LappingFabric`, `IndexSort`, `SeparateStatus`, `LastActive`, `Remark` FROM `c_wh1_bc_sdactual_tb` WHERE `SD_ListDoc_No`

                string selectQuery2 = @"
                       SELECT NULL, `Barcode`, `CreateDate`, `Qty`, `QtyNet`, `YardNet`, `SD_ListDoc_No`, `Plies`, `PliesActual`, `RestFabric`, 
                       `Defect`, `LappingFabric`, `IndexSort`,
                        CASE
                            WHEN `SeparateStatus` = 1 THEN '1'
                        ELSE '0'                        
                        END AS 'SeparateStatus',
                        `LastActive`, `Remark` FROM `c_wh1_bc_sdactual_tb` WHERE `SD_ListDoc_No` LIKE '%" + getSDID + "%'";
                ConnectMySQL.ip = tbIP.Text;
                DataTable dtSDwithFabricActual = ConnectMySQL.MySQLtoDataTable(selectQuery2);
                ConnectMySQL.ip = original_IP;
                guna2DataGridView1.DataSource = null;
                guna2DataGridView1.DataSource = dtSDwithFabricActual; //

                ConnectMySQL.MysqlQuery("DELETE FROM `c_wh1_bc_sdactual_tb` WHERE `SD_ListDoc_No` LIKE '" + getSDID + "'");
                string insertQuery2 = @" INSERT INTO `c_wh1_bc_sdactual_tb`(`BcID`, `Barcode`, `CreateDate`, `Qty`, `QtyNet`, `YardNet`, `SD_ListDoc_No`, `Plies`, `PliesActual`, `RestFabric`, 
                       `Defect`, `LappingFabric`, `IndexSort`, `SeparateStatus`, `LastActive`, `Remark`) VALUES " + ConvertDataTableToString(dtSDwithFabricActual);
                //MessageBox.Show(insertQuery);
                bool st2 = ConnectMySQL.MysqlQuery(insertQuery2);
                if (st2)
                {

                    MessageBox.Show("Upload Actual Fabric" + getSDID + " Finished");
                    s3 = true;
                    //gvDis.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Green;
                }
                else
                {
                    MessageBox.Show("Upload  Actual Fabric " + getSDID + " Error ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //gvDis.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White; BcIQC BcLab BcChannel ReadyUse
                }

                string selectQuery3 = @"
                      SELECT NULL, `b`.`Date`, `b`.`RollNo`, `b`.`Barcode`, `b`.`LotNo`, `b`.`DryLot`,`b`.`MatrClass`, `b`.`MatrCode`, `b`.`Color`, `b`.`Size`, 
                      `b`.`Qty`, `b`.`Unit`, `b`.`Warehouse`, `b`.`Location`, `b`.`LotRemark`, `b`.`Description`, `b`.`CreateDate`, `b`.`Supplier`, `b`.`SizeNet`,
                      `b`.`QtyNet`, `b`.`YardNet`, `b`.`SizeHead`, `b`.`SizeMiddle`, `b`.`SizeEnd`, `b`.`CircleWeight`, `b`.`Plies`, `b`.`StatusResult`,
                        CASE
                            WHEN `b`.`chShad` = 1 THEN '1'
                        ELSE '0'                        
                        END AS 'chShad',
                      `b`.`FabricType`, `b`.`Consumtion`, 
                        CASE
                            WHEN `b`.`chTubular` = 1 THEN '1'
                        ELSE '0'                        
                        END AS 'chTubular',
                      `b`.`SD_ListDoc_No`, `b`.`BarcodeRef`, 
                        CASE
                            WHEN `b`.`StatusBarcodeRef` = 1 THEN '1'
                        ELSE '0'                        
                        END AS 'StatusBarcodeRef',
                        CASE
                            WHEN `b`.`SeparateStatus` = 1 THEN '1'
                        ELSE '0'                        
                        END AS 'SeparateStatus',
                      `b`.`PliesActual`, `b`.`RestFabric`, `b`.`Defect`, `b`.`LappingFabric`, `b`.`IndexSort`, `b`.`IssueID`, `b`.`ReturnID`, 
                         CASE
                                                    WHEN `b`.`BcIQC` = 1 THEN '1'
                                                ELSE '0'                        
                                                END AS 'BcIQC',
                         CASE
                                                    WHEN `b`.`BcLab` = 1 THEN '1'
                                                ELSE '0'                        
                                                END AS 'BcLab',
                         CASE
                                                    WHEN `b`.`BcChannel` = 1 THEN '1'
                                                ELSE '0'                        
                                                END AS 'BcChannel',
                         CASE
                                                    WHEN `b`.`ReadyUse` = 1 THEN '1'
                                                ELSE '0'                        
                                                END AS 'ReadyUse', `RemarkStatus`, `DateStartIQC1`, `DateEndIQC1`
                      FROM `c_wh1_bc_sdactual_tb` AS `a` JOIN `c_warehouse1_bc_tb` AS `b` ON `a`.`Barcode`=`b`.`Barcode` WHERE `a`.`SD_ListDoc_No` LIKE '%" + getSDID + "%'";
                ConnectMySQL.ip = tbIP.Text;
                DataTable dtFabricOriginal = ConnectMySQL.MySQLtoDataTable(selectQuery3);
                ConnectMySQL.ip = original_IP;
                guna2DataGridView1.DataSource = null;
                guna2DataGridView1.DataSource = dtFabricOriginal; //              BcIQC BcLab BcChannel ReadyUse  

                string insertQuery3 = @"INSERT IGNORE INTO `c_warehouse1_bc_tb` (`BcID`, `Date`, `RollNo`, `Barcode`, `LotNo`, `DryLot`, `MatrClass`, `MatrCode`, `Color`, `Size`,
                                        `Qty`, `Unit`, `Warehouse`, `Location`, `LotRemark`, `Description`, `CreateDate`, `Supplier`, `SizeNet`, `QtyNet`, `YardNet`,
                                        `SizeHead`, `SizeMiddle`, `SizeEnd`, `CircleWeight`, `Plies`, `StatusResult`, `chShad`, `FabricType`, `Consumtion`, 
                                        `chTubular`, `SD_ListDoc_No`, `BarcodeRef`, `StatusBarcodeRef`, `SeparateStatus`, `PliesActual`, `RestFabric`, `Defect`, 
                                        `LappingFabric`, `IndexSort`, `IssueID`, `ReturnID`, `BcIQC`, `BcLab`, `BcChannel`, `ReadyUse`, `RemarkStatus`, `DateStartIQC1`, `DateEndIQC1`)
                                        VALUES " + converttbToString(dtFabricOriginal);

                string deletesql = @"DELETE `b`
                FROM `c_wh1_bc_sdactual_tb` AS `a`
                JOIN `c_warehouse1_bc_tb` AS `b` ON `a`.`Barcode` = `b`.`Barcode`
                WHERE `a`.`SD_ListDoc_No` LIKE '" + getSDID + "';";
                bool st3 = ConnectMySQL.MysqlQuery(deletesql + insertQuery3);
                if (st3)
                {
                    MessageBox.Show("Upload Fabric" + getSDID + " Finished");
                    s4 = true;
                    //gvDis.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Green;
                }
                else
                {
                    MessageBox.Show("Upload Fabric " + getSDID + " Error ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //gvDis.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
                }

                bool st4 = ConnectMySQL.MysqlQuery(@" DELETE FROM `a_a3_scandoc_sd_ct_tb` WHERE `SD_ListDoc_No` LIKE '" + getSDID + @"';
            INSERT INTO `a_a3_scandoc_sd_ct_tb`(`SD_ListDoc_No`, `wh_scanout`, `SD_ScanIn`, `SD_ScanOut`, `Cut_ScanIn`, `Cut_ScanOut`, `ID_fabric_call`) 
            VALUES ('" + getSDID + "','" + txtDate() + " 00:00:00.000000','NULL','NULL','NULL','NULL','0');");
                if (st4)
                {
                    MessageBox.Show("WH Scan Doc :" + getSDID + " Finished");
                    s5 = true;
                }
                else
                {
                    MessageBox.Show("WH Scan Doc :" + getSDID + " Error ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }




                if (s1 && s2 && s3 && s4 && s5)
                {
                    gvDis.Rows[indexRow].Cells["Status"].Value = "Pass";
                }
            }
        }

        private void btSOLoad1_Click(object sender, EventArgs e)
        {
            //CASE
            //                                        WHEN `b`.`BcIQC` = 1 THEN '1'
            //                                    ELSE '0'
            //                                    END AS 'BcIQC',

            gvDis.DataSource = null;
            guna2DataGridView1.DataSource = null;
            bool st = loadData_Test(@"
                        SELECT  'NULL',`So`, " + txtDate() + @", `Style`, `StyleDesc`, `Color`, `Size`, `Qty`, `Unit_Price`, `Unit`, 
                               `Customer_Code`, `Customer_Name`, `Customer_Style`, `CusAddr`, `Price`, `Fabric`, `CutBy`, 
                               `PlaceSew`, `JobStart`, `CutFinished`, `Deadline`, `issueAccount` 
                      FROM `so_tb` 
                      WHERE `So` LIKE '" + tbSO.Text + "'");

            ConnectMySQL.MysqlQuery("DELETE FROM `so_tb` WHERE `So` LIKE '" + tbSO.Text + "'");
            string insertQuery = @"INSERT INTO `so_tb` 
                            ( `ID_So`,`So`, `Date`, `Style`, `StyleDesc`, `Color`, `Size`, `Qty`, `Unit_Price`, `Unit`, 
                             `Customer_Code`, `Customer_Name`, `Customer_Style`, `CusAddr`, `Price`, `Fabric`, `CutBy`, 
                             `PlaceSew`, `JobStart`, `CutFinished`, `Deadline`, `issueAccount`) 
                            VALUES " + ConvertDataGridViewToString(gvDis);

            //ConnectMySQL.ip = "12.0.100.251";
            //ConnectMySQL.IPport = "3306";
            //MessageBox.Show(insertQuery);

            bool st8 = ConnectMySQL.MysqlQuery(insertQuery);

            if (st8 && st)
            {
                gvDis.DataSource = null;
                bool st_X = loadData_Test(@"
                        SELECT NULL, `LotNo`, `So`, `Style`, `MatrClass`, 
                              CASE
                                 WHEN `DirectionIQC` = 1 THEN '1'
                                 ELSE '0'
                                 END AS `DirectionIQC`,
                            `ReadyUse`, 
                            CASE
                               WHEN `Lab` = 1 THEN '1'
                               ELSE '0'
                               END AS `Lab`, 
                            `DateStartIQC`, `DateEndIQC`
                                                    FROM `c_warehouse2_so_tb` WHERE `So` LIKE '" + tbSO.Text + "'");

                string insertQuery_x = @"INSERT INTO `c_warehouse2_so_tb`(`LotID`, `LotNo`, `So`, `Style`, `MatrClass`, `DirectionIQC`, `ReadyUse`, `Lab`, `DateStartIQC`, `DateEndIQC`)
                VALUES" + ConvertDataGridViewToString(gvDis) + ";";
                bool st_n = ConnectMySQL.MysqlQuery("DELETE FROM `c_warehouse2_so_tb` WHERE `So` LIKE '" + tbSO.Text + "';" + insertQuery_x);
                if (st_X && st_n)
                {
                    MessageBox.Show("SO Upload Finish");

                }
                else
                {
                    MessageBox.Show("Error_so_match_Lot");
                }

            }
            else
            {
                MessageBox.Show("Error_so_tb");
            }
        }
    }
}