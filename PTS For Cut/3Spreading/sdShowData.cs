using Production_Tracking_systems.myClass;
using PTS_For_Cut._3Spreading;
using PTS_For_Cut.Main;
using PTS_For_Cut.myClass;
using PTS_For_Cut.Myclass;
using PTS_For_Cut.Spreading.ScanIn;
using System.Data;
using MessageBox = System.Windows.Forms.MessageBox;
using Size = System.Drawing.Size;

namespace PTS_For_Cut.Spreading
{
    public partial class sdShowData : Form
    {
        private bool checkKey = false;
        private bool canKey = false;
        public static sdShowData ins { get; private set; }
        public sdShowData()
        {
            InitializeComponent();
            ins = this;
        }
        private void GetDataFromSD_DOC_DB()
        {
            ConnectMySQL.db = "pts_db";
            DataTable dt = new DataTable();
            dt = ConnectMySQL.MySQLtoDataTable("SELECT `a`.`SD_ListDoc_No`, `a`.`SO`, `a`.`Style`, `a`.`Mark_ID`, `b`.`Plies`, `a`.`Table_No`, " +
                 "`a`.`DateCreate`,  " +
                 "`a`.`Color`, `a`.`Marker_Width`, `a`.`Marker_LengthCm`, `a`.`Marker_LengthYard`, `a`.`User` " +
                 "FROM `a_a1_spreading_list_tb` AS `a`  " +
                 "LEFT JOIN `a_a2_spreading_detail_tb` AS `b` ON `a`.`SD_ListDoc_No`=`b`.`SD_ListDoc_No` " +
                 "WHERE `a`.`SD_ListDoc_No`='" + ScanInSpreading.ins.DocNo + "' GROUP BY `a`.`SD_ListDoc_No`");
            if (dt.Rows.Count > 0)
            {
                tbSDid.Text = dt.Rows[0]["SD_ListDoc_No"].ToString();
                tbSO.Text = dt.Rows[0]["SO"].ToString();
                tbStyle.Text = dt.Rows[0]["Style"].ToString();
                tbMarkID.Text = dt.Rows[0]["Mark_ID"].ToString();
                numPlies.Value = 0; // Default value
                if (dt.Rows[0]["Plies"] != null && !string.IsNullOrWhiteSpace(dt.Rows[0]["Plies"].ToString()))
                {
                    numPlies.Value = int.Parse(dt.Rows[0]["Plies"].ToString().Trim());
                }
                cbbLine.Text = dt.Rows[0]["Table_No"].ToString();
                tbColor.Text = dt.Rows[0]["Color"].ToString();
                tbMarkerWidth.Text = dt.Rows[0]["Marker_Width"].ToString();
                tbMarkerLengthCm.Text = dt.Rows[0]["Marker_LengthCm"].ToString();
                tbMarkerLengthYard.Text = dt.Rows[0]["Marker_LengthYard"].ToString();
                dtpCreate1.Text = dt.Rows[0]["DateCreate"].ToString();
                lbUser.Text = dt.Rows[0]["User"].ToString();
                ConvertTable.SDconvertDBtoTable(@"SELECT a.`Size`, a.`RatioQTY` 
    FROM `a_a2_spreading_detail_tb` a 
    LEFT JOIN sizes_tb s ON a.`Size`= s.Size
    WHERE `SD_ListDoc_No`='" + ScanInSpreading.ins.DocNo + "' ORDER BY s.SeqNo ASC;", int.Parse(numPlies.Value.ToString()), gvSpreading);

                ConnectMySQL.DisplayAndSearch("SELECT ROW_NUMBER() OVER(ORDER BY `Barcode`)AS NO,`Barcode`, `PliesActual`, `RestFabric`, `Defect`, `LappingFabric`,`ShortageInRoll` FROM `c_wh1_bc_sdactual_tb` WHERE `SD_ListDoc_No`='" + tbSDid.Text + "' ORDER BY `Barcode`;", gvFabric);
            }
        }
        private void GetDataFromSD_DOC_UPdate_DB()
        {
            ConnectMySQL.db = "pts_db";
            DataTable dt = new DataTable();
            dt = ConnectMySQL.MySQLtoDataTable("SELECT `a`.`SD_ListDoc_No`, `a`.`SO`, `a`.`Style`, `a`.`Mark_ID`, `b`.`Plies`, `a`.`Table_No`, " +
                "`a`.`Combo`, `a`.`TTEM`, `a`.`DateCreate`, `a`.`Country`, " +
                "`a`.`Color`, `a`.`Marker_Width`, `a`.`Marker_LengthCm`, `a`.`Marker_LengthYard`, `a`.`User` " +
                "FROM `a_a1_spreading_list_tb` AS `a`  " +
                "LEFT JOIN `a_a4_sd_scanout_qty_tb` AS `b` ON `a`.`SD_ListDoc_No`=`b`.`SD_ListDoc_No` " +
                "WHERE `a`.`SD_ListDoc_No`='" + ScanInSpreading.ins.DocNo + "' GROUP BY `a`.`SD_ListDoc_No`");
            //  MessageBox.Show(dt.Rows.Count.ToString());
            //  MessageBox.Show(ScanInSpreading.ins.DocNo.ToString());
            if (dt.Rows.Count > 0)
            {
                tbSDid.Text = dt.Rows[0]["SD_ListDoc_No"].ToString();
                tbSO.Text = dt.Rows[0]["SO"].ToString();
                tbStyle.Text = dt.Rows[0]["Style"].ToString();
                tbMarkID.Text = dt.Rows[0]["Mark_ID"].ToString();
                numPlies.Value = 0; // Default value
                if (dt.Rows[0]["Plies"] != null && !string.IsNullOrWhiteSpace(dt.Rows[0]["Plies"].ToString()))
                {
                    numPlies.Value = int.Parse(dt.Rows[0]["Plies"].ToString().Trim());
                }
                cbbLine.Text = dt.Rows[0]["Table_No"].ToString();
                tbColor.Text = dt.Rows[0]["Color"].ToString();
                tbMarkerWidth.Text = dt.Rows[0]["Marker_Width"].ToString();
                tbMarkerLengthCm.Text = dt.Rows[0]["Marker_LengthCm"].ToString();
                tbMarkerLengthYard.Text = dt.Rows[0]["Marker_LengthYard"].ToString();
                dtpCreate1.Text = dt.Rows[0]["DateCreate"].ToString();
                lbUser.Text = dt.Rows[0]["User"].ToString();//
                ConvertTable.SDconvertDBtoTable(@"SELECT a.`Size`, a.`RatioQTY` 
FROM `a_a4_sd_scanout_qty_tb` a 
LEFT JOIN sizes_tb s ON a.`Size`= s.Size 
WHERE `SD_ListDoc_No`='" + ScanInSpreading.ins.DocNo + "' ORDER BY s.SeqNo ASC;", int.Parse(numPlies.Value.ToString()), gvSpreading);

                ConnectMySQL.DisplayAndSearch("SELECT ROW_NUMBER() OVER(ORDER BY `BcID`)AS NO,`Barcode`, `PliesActual`, `RestFabric`, `Defect`, `LappingFabric`,`ShortageInRoll` FROM `c_wh1_bc_sdactual_tb` WHERE `SD_ListDoc_No`='" + tbSDid.Text + "' ORDER BY `BcID`;", gvFabric);

            }

        }
        private string xGroup = "";
        private void sdShowData_Load(object sender, EventArgs e)
        {
            numPliesofRoll.Maximum = 200;
            DataTable dataT = new DataTable();
            dataT.Columns.Add("No");
            dataT.Columns.Add("Barcode");
            dataT.Columns.Add("PliesActual");
            dataT.Columns.Add("RestFabric");
            dataT.Columns.Add("Defect");
            dataT.Columns.Add("LappingFabric");
            dataT.Columns.Add("ShortageInRoll");
            gvFabric.DataSource = dataT;

            //if (DateTime.Now.TimeOfDay < new TimeSpan(9, 0, 0)) // Check if the time is before 9:00 AM
            //{
            //    string query = "DELETE FROM `c_wh1_bc_sdactual_tb` WHERE `SD_ListDoc_No`='';";
            //    ConnectMySQL.MysqlQuery(query);
            //}
            AddRow = true;
            xGroup = Properties.Settings.Default.workGroup;
            if (HomePage.ins.sdDataScan == "ScanInSD")
            {
                setForm();
                checkKey = true;
                numPlies.Enabled = false;
                gvSpreading.Enabled = false;
                lbHeadText.Text = "Scan In Spreading";
                GetDataFromSD_DOC_DB();
                picConfirm.Visible = false;
            }
            else if (HomePage.ins.sdDataScan == "ScanOutSD")
            {
                pnSD.Visible = false;
                pnBar.Visible = false;
                tlpFabricDetial.Visible = false;
                pnAdd.Visible = true;

                lbLine.Visible = true;
                cbbLine.Visible = true;

                checkKey = true;
                numPlies.Enabled = true;
                gvSpreading.Enabled = false;
                picConfirm.Visible = true;
                // ConnectMySQL.ComboboxList("",cbbLine);

                DataTable dt = new DataTable();
                dt = Login.ins.Line_dt;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["Department"].ToString() == "Cutting")
                    {
                        string value = dt.Rows[i]["Line"].ToString();
                        cbbLine.Items.Add(value);
                    }
                }
                lbHeadText.Text = "Scan Out Spreading";
                GetDataFromSD_DOC_DB();
            }
            else if (HomePage.ins.sdDataScan == "ScanInCut")//`Cut_ScanIn`, `Cut_ScanOut` 
            {
                setForm();
                numPlies.Enabled = false;
                gvSpreading.Enabled = false;
                lbHeadText.Text = "Scan In Cutting";
                GetDataFromSD_DOC_UPdate_DB();
                picConfirm.Visible = false;
            }
            else if (HomePage.ins.sdDataScan == "ScanOutCut")
            {
                setForm();
                numPlies.Enabled = false;
                gvSpreading.Enabled = true;
                lbHeadText.Text = "Scan Out Cutting";
                GetDataFromSD_DOC_UPdate_DB();
                picConfirm.Visible = true;
            }
            else if (HomePage.ins.sdDataScan == "EditData")
            {
                pnAdd.Visible = true;
                pnSD.Visible = false;
                pnBar.Visible = false;
                tlpFabricDetial.Visible = false;
                //DataTable dataT = new DataTable();
                //dataT.Columns.Add("No");
                //dataT.Columns.Add("Barcode");
                //dataT.Columns.Add("Plies");
                //dataT.Columns.Add("Rest Fabric");
                //dataT.Columns.Add("Defect");
                //dataT.Columns.Add("LapFabric");//BDM2410067779   ShortageInRoll
                //dataT.Columns.Add("ShortageInRoll");
                //gvFabric.DataSource = dataT;
                //gvFabric.Columns["No"].Width = 40;
                //gvFabric.Columns["Barcode"].Width = 120;
                //gvFabric.Columns["Plies"].Width = 50;
                //gvFabric.Columns["Rest Fabric"].Width = 100;
                //gvFabric.Columns["Defect"].Width = 70;
                //gvFabric.Columns["LapFabric"].Width = 70;
                lbLine.Visible = true;
                cbbLine.Visible = true;
                checkKey = true;
                numPlies.Enabled = true;
                gvSpreading.Enabled = true;
                picConfirm.Visible = true;
                // ConnectMySQL.ComboboxList("",cbbLine);

                DataTable dt = new DataTable();
                dt = Login.ins.Line_dt;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["Department"].ToString() == "Cutting")
                    {
                        string value = dt.Rows[i]["Line"].ToString();
                        cbbLine.Items.Add(value);
                    }
                }
                lbHeadText.Text = "Scan Out Spreading";

                GetDataFromSD_DOC_UPdate_DB();

            }
            numPliesofRoll.ResetText();
            numDefect.ResetText();
            numRestFab.ResetText();
            numLappFab.ResetText();
            numShortageInRoll.ResetText();
            AddRow = false;
            if (gvFabric.Columns.Count == 7)
            {
                //.cells["Plies"]
                gvFabric.Columns["No"].Width = 40;
                gvFabric.Columns["Barcode"].Width = 120;
                gvFabric.Columns["PliesActual"].Width = 50;
                gvFabric.Columns["RestFabric"].Width = 100;
                gvFabric.Columns["Defect"].Width = 70;
                gvFabric.Columns["LappingFabric"].Width = 70;
                gvFabric.Columns["ShortageInRoll"].Width = 100;
                //`PliesActual`, `RestFabric`, `Defect`, `LappingFabric`
            }
        }
        private void setForm()
        {
            pnAdd.Visible = false;
            this.Size = new Size(850, 795);
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            if (HomePage.ins.sdDataScan == "ScanOutSD" && HomePage.ins.sdDataScan == "EditData")
            {
                if (cbbLine.SelectedIndex > -1)
                {
                    if (gvFabric.Rows.Count > 0)
                    {
                        Save();
                    }
                    else
                    {
                        MessageBox.Show("!!! Add Fabric Data Please. !!!");
                    }

                }
                else
                {
                    MessageBox.Show("!!! Select Production Line Please. !!!");
                }
            }
            else
            {
                Save();
            }

        }
        //private void savePliesRoll()
        //{

        //    string insertMultiValue = "";
        //    bool first = false;
        //    if (gvFabric.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < gvFabric.Rows.Count; i++)
        //        {
        //            string BarCodeFabric = gvFabric.Rows[i].Cells["Barcode"].Value.ToString();
        //            string Plies = gvFabric.Rows[i].Cells["Plies"].Value.ToString();
        //            string RestFab = gvFabric.Rows[i].Cells["Rest Fabric"].Value.ToString();
        //            string defect = gvFabric.Rows[i].Cells["Defect"].Value.ToString();
        //            string lapFab = gvFabric.Rows[i].Cells["LapFabric"].Value.ToString();//tbSDid.Text

        //            if (!first)
        //            {
        //                insertMultiValue = "('NULL', '" + BarCodeFabric + "','" + tbSDid.Text + "','" + Plies + "','" + RestFab + "','" + defect + "','" + lapFab + "')";
        //                first = true;
        //            }
        //            else
        //            {
        //                insertMultiValue = insertMultiValue + ",('NULL', '" + BarCodeFabric + "','" + tbSDid.Text + "','" + Plies + "','" + RestFab + "','" + defect + "','" + lapFab + "')";
        //            }
        //        }
        //        if (insertMultiValue != "")
        //        {
        //            ConnectMySQL.MysqlQuery("DELETE FROM `a_a5_plies_roll_sd_tb` WHERE `SD_ListDoc_No`='" + tbSDid.Text + "' ");
        //            ConnectMySQL.MysqlQuery("ALTER TABLE `a_a5_plies_roll_sd_tb` auto_increment = 1;");
        //            ConnectMySQL.MysqlQuery("INSERT INTO `a_a5_plies_roll_sd_tb`(`Plies_Roll_ID`, `BarcodeFabric`, `SD_ListDoc_No`, `Plies`, `RestFabric`, `Defect`, `LappingFabric`) " +
        //                "VALUES" + insertMultiValue + ";");
        //        }
        //    }
        //}

        private void Save()
        {
            if (MessageBox.Show("Are you sure you want to save data?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                ConnectMySQL.db = "pts_db";
                string dateText = "";
                if (HomePage.ins.sdDataScan == "ScanInSD")
                {

                    dateText = st();
                    //bool status = ConnectMySQL.MysqlQuery("INSERT INTO `a_a3_scandoc_sd_ct_tb` (`SD_ListDoc_No`, `SD_ScanIn`, `SD_ScanOut`, `Cut_ScanIn`, `Cut_ScanOut`) " +
                    //       "VALUES ('" + tbSDid.Text + "', '" + dateText + "', NULL, NULL, NULL);");
                    bool status = ConnectMySQL.MysqlQuery("UPDATE `a_a3_scandoc_sd_ct_tb` SET `SD_ScanIn`='" + dateText + "' WHERE `SD_ListDoc_No`='" + tbSDid.Text + "'AND`SD_ScanIn`IS NULL ");

                    if (status)
                    {
                        MessageBox.Show("Successfully");
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Not Save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else if (HomePage.ins.sdDataScan == "ScanOutSD" || HomePage.ins.sdDataScan == "EditData")
                {
                    if (cbbLine.SelectedIndex > -1)
                    {
                        dateText = st();
                        bool status2 = saveToScanOutTB();
                        //MessageBox.Show(status2.ToString());
                        if (status2)
                        {//UPDATE `c_warehouse1_bc_tb` SET `SD_ListDoc_No` = @newValue,`Plies`=@newPlies WHERE `Barcode` = @condition"
                            ConnectMySQL.MysqlQuery("UPDATE `a_a3_scandoc_sd_ct_tb` SET `SD_ScanOut`='" + dateText + "' WHERE `SD_ListDoc_No`='" + tbSDid.Text + "'AND`SD_ScanOut`IS NULL ");
                            //ConnectMySQL.MysqlQuery("UPDATE `c_wh1_bc_sdactual_tb` SET `SD_ListDoc_No`='' WHERE `SD_ListDoc_No`='" + tbSDid.Text + "';");
                            //bool status = ConnectMySQL.AddgvtoDBplies("UPDATE `c_wh1_bc_sdactual_tb` SET `PliesActual`=@Cell1,`RestFabric`=@Cell2,`Defect`=@Cell3,`LappingFabric`=@Cell4,`ShortageInRoll`=@Cell5 WHERE `Barcode`=@condition AND `SD_ListDoc_No` LIKE '" + tbSDid.Text + "';", tbSDid.Text, gvFabric);
                            //if (status)
                            //{
                            MessageBox.Show("Successfully");
                            DialogResult = DialogResult.OK;
                            //}
                            //else
                            //{
                            //    MessageBox.Show("!!!!!!! Error !!!!!!!!!");
                            //}
                        }
                        else
                        {
                            MessageBox.Show("Not Save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select Line", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (HomePage.ins.sdDataScan == "ScanInCut")//`Cut_ScanIn`, `Cut_ScanOut` 
                {

                    dateText = st();
                    bool status = ConnectMySQL.MysqlQuery("UPDATE `a_a3_scandoc_sd_ct_tb` SET `Cut_ScanIn`='" + dateText + "' WHERE `SD_ListDoc_No`='" + tbSDid.Text + "'AND`Cut_ScanIn`IS NULL ");
                    if (status)
                    {
                        MessageBox.Show("Successfully");
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Not Save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (HomePage.ins.sdDataScan == "ScanOutCut")
                {
                    dateText = st();
                    bool status2 = saveToScanOutTB();
                    // bool status = ConnectMySQL.MysqlQuery("UPDATE `a_a3_scandoc_sd_ct_tb` SET `Cut_ScanOut`='" + dateText + "' WHERE `SD_ListDoc_No`='" + tbDocNo.Text + "'AND`Cut_ScanOut`IS NULL ");
                    if (status2)
                    {
                        bool status = ConnectMySQL.MysqlQuery("UPDATE `a_a3_scandoc_sd_ct_tb` SET `Cut_ScanOut`='" + dateText + "' WHERE `SD_ListDoc_No`='" + tbSDid.Text + "'AND`Cut_ScanOut`IS NULL ");

                        if (status)
                        {
                            MessageBox.Show("Successfully");
                            DialogResult = DialogResult.OK;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Not Save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private string st()
        {
            string txtDate = "";
            System.Globalization.CultureInfo _cultureEnInfo = new System.Globalization.CultureInfo("en-US");
            DateTime dateEng = Convert.ToDateTime(DateTime.Now, _cultureEnInfo);
            txtDate = dateEng.ToString("yyyy-MM-dd HH:mm:ss", _cultureEnInfo);
            return txtDate;
        }
        private bool saveToScanOutTB()
        {
            //MessageBox.Show(checkKey.ToString());
            if (checkKey)
            {
                bool aSave = false;
                string insertMultiValue = "";
                bool first = false;
                //for (int i = 0; i < gvSpreading.Rows.Count - 1; i++)
                //{
                for (int j = 1; j < gvSpreading.Columns.Count; j++)
                {
                    //string color = gvSpreading.Rows[i].Cells[0].Value.ToString();// IsNullOrWhiteSpace
                    string size = gvSpreading.Columns[j].Name;
                    string qty = "";
                    string RatioQty = "";
                    string Line = "";
                    if (cbbLine.Visible)
                    {
                        Line = cbbLine.Text;
                    }
                    //MessageBox.Show(gvSpreading.Rows[i].Cells[j].Value.GetType().ToString());
                    if (gvSpreading.Rows[0].Cells[j].Value.ToString() != "" && gvSpreading.Rows[0].Cells[j].Value.ToString() != "0") //`Style`='" + lbStyle.Text + "'
                    {

                        RatioQty = gvSpreading.Rows[0].Cells[j].Value.ToString();//`Plies`
                        qty = gvSpreading.Rows[1].Cells[j].Value.ToString();
                        //MessageBox.Show(gvSpreading.Rows[1].Cells[j].Value.ToString());
                        if (!first)
                        {
                            insertMultiValue = "('NULL', '" + tbSDid.Text + "','" + Line + "','" + numPlies.Value.ToString() + "','" + size + "','" + RatioQty + "','" + qty + "')";
                            first = true;
                        }
                        else
                        {
                            insertMultiValue = insertMultiValue + ",('NULL', '" + tbSDid.Text + "','" + Line + "','" + numPlies.Value.ToString() + "','" + size + "','" + RatioQty + "','" + qty + "')";
                        }
                    }
                    // }
                }
                if (insertMultiValue != "")
                {
                    //MessageBox.Show(insertMultiValue);
                    ConnectMySQL.MysqlQuery("UPDATE `a_a1_spreading_list_tb` SET `Table_No` = '" + cbbLine.Text + "' WHERE `SD_ListDoc_No`='" + tbSDid.Text + "' ");
                    ConnectMySQL.MysqlQuery("DELETE FROM `a_a4_sd_scanout_qty_tb` WHERE `SD_ListDoc_No`='" + tbSDid.Text + "' ");
                    ConnectMySQL.MysqlQuery("ALTER TABLE `a_a4_sd_scanout_qty_tb` auto_increment = 1;");
                    ConnectMySQL.MysqlQuery("INSERT INTO `a_a4_sd_scanout_qty_tb`( `No`, `SD_ListDoc_No`,`Line`,`Plies`, `Size`, `RatioQTY`, `QTY`) " +
                                                     "VALUES" + insertMultiValue + ";");

                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (HomePage.ins.sdDataScan == "ScanOutSD")
                {
                    MessageBox.Show("Please Confirm Plies Value.");
                }

                if (HomePage.ins.sdDataScan == "ScanOutCut")
                {
                    //  MessageBox.Show("Please Confirm Plies Value.");
                    return true;
                }
                return false;
            }


        }
        private void gvSpreading_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("dd");

            checkKey = true;
            // numPlies.Focus();
        }

        private void numPlies_KeyPress(object sender, KeyPressEventArgs e)
        {
            canKey = true;
            checkKey = false;
        }
        private void picConfirm_Click(object sender, EventArgs e)
        {
            if (canKey)
            {
                if (gvSpreading.Rows.Count > 0)
                {
                    checkKey = true;
                    for (int i = 1; i < gvSpreading.Columns.Count; i++)
                    {
                        gvSpreading.Rows[0].Cells[i].Value.GetType().ToString();
                        if (gvSpreading.Rows[0].Cells[i].Value.ToString() != "")
                        {
                            gvSpreading.Rows[1].Cells[i].Value = int.Parse(gvSpreading.Rows[0].Cells[i].Value.ToString().Trim()) * numPlies.Value;
                        }
                    }
                }

            }
        }
        private void lbHeadText_Click(object sender, EventArgs e)
        {

        }
        private void label22_Click(object sender, EventArgs e)
        {

        }
        private string setDate()
        {
            string txtDate = "";
            System.Globalization.CultureInfo _cultureEnInfo = new System.Globalization.CultureInfo("en-US");
            DateTime dateEng = Convert.ToDateTime(DateTime.Now, _cultureEnInfo);
            txtDate = dateEng.ToString("yyyy-MM-dd", _cultureEnInfo);
            return txtDate;
        }
        public DataTable checkFabric = new DataTable();
        public string BarCodeScan = "";
        private void btToTable_Click(object sender, EventArgs e)
        {
            if (RowIndexEditValue != -1)
            {

                if (tbBarcode.Text.Length > 0)
                {

                    if (tbBarcode.Text.Substring(0, 2).ToString() == "DM" && gvFabric.Rows.Count <= 3)
                    {
                        insertType = 3;
                    }
                    else
                    {

                        insertType = 2;
                    }
                    //ConnectMySQL.MysqlQuery("UPDATE `c_wh1_bc_sdactual_tb` SET `Qty`='0.00'," +
                    //                  "`YardNet`='0.00' WHERE `Barcode` LIKE '" + tbBarcode.Text + "' AND `SD_ListDoc_No`LIKE '" + tbSDid.Text + "'");
                }
            }

            if (insertType == 1)
            {
                if (tbspidAdd.Text != "" && tbBarcode.Text != "" && numPlies.Value != 0)
                {
                    checkFabric = ConnectMySQL.MySQLtoDataTable("SELECT `Qty` AS 'Balance Qty' ,`YardNet` AS `Balance Length YDS`, `Plies` FROM `c_wh1_bc_sdactual_tb` WHERE `Barcode`LIKE '" + tbBarcode.Text + "' AND `SD_ListDoc_No` LIKE '" + tbspidAdd.Text + "';");
                    if (checkFabric.Rows.Count == 0)
                    {
                        MessageBox.Show("This barcode is not in this spreading document.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("!!Please Check Data!!");
                }
            }
            else if (insertType == 2)
            {
                string sql = @"SELECT `B`.`Qty`,`B`.`Unit`,`B`.`Consumtion` AS `YDS/KGS` , `B`.`YardNet`AS `Igarment Length YDS`, 
            IFNULL((`B`.`Qty`-(SELECT SUM(`c`.`Qty`) FROM c_wh1_bc_sdactual_tb AS `c` WHERE`c`.`Barcode`= `B`.`Barcode` GROUP BY `c`.`Barcode`)),`B`.`Qty`)AS 'Balance Qty' 
            ,`B`.`Unit` ,(SELECT SUM(`d`.`YardNet`) FROM c_wh1_bc_sdactual_tb AS `d` WHERE `d`.`Barcode`= `B`.`Barcode` GROUP BY `d`.`Barcode`) AS 'Usage',
            IFNULL((`B`.`YardNet`-(SELECT SUM(`d`.`YardNet`) FROM c_wh1_bc_sdactual_tb AS `d` WHERE `d`.`Barcode`= `B`.`Barcode` GROUP BY `d`.`Barcode`))
            ,`B`.`YardNet`) AS `Balance Length YDS`,  `B`.`StatusResult`,
                CASE 
                    WHEN `B`.`ReadyUse`=1 THEN 'Ready'
                    ELSE 'No Ready'
                END AS `ReadyUse`
                FROM c_warehouse2_so_tb AS `A` 
                INNER JOIN c_warehouse1_bc_tb AS `B` ON`A`.`LotNo`=`B`.`LotNo`
                WHERE `B`.`Barcode` LIKE '" + tbBarcode.Text + @"'
                GROUP BY `B`.`Barcode`;";
                //checkFabric = ConnectMySQL.MySQLtoDataTable("SELECT `Qty`,`YardNet`, `Plies` FROM `c_warehouse1_bc_tb` WHERE `Barcode`LIKE '" + tbBarcode.Text + "' AND `SD_ListDoc_No` LIKE '" + tbspidAdd.Text + "';");
                checkFabric = ConnectMySQL.MySQLtoDataTable(sql);
                bool checkCondition = false;
                if (checkFabric.Rows.Count != 0)
                {
                    if (checkFabric.Rows[0]["ReadyUse"].ToString() == "No Ready")
                    {
                        // checkFabric.Rows[0]["ReadyUse"].Style.BackColor = Color.Red;
                        checkCondition = true;
                    }
                    else
                    {
                        if (checkFabric.Rows[0]["StatusResult"].ToString() == "R")
                        {
                            // checkFabric.Rows[0]["StatusResult"].Style.BackColor = Color.Red;
                            checkCondition = true;
                        }
                        else
                        {
                            //if (checkFabric.Rows[0]["Balance Length YDS"].ToString() != "")
                            //{
                            //    double x = double.Parse(checkFabric.Rows[0]["Balance Length YDS"].ToString().Trim());
                            //    if (x <= 0)
                            //    {
                            //        //checkFabric.Rows[0]["Balance Length YDS"].Style.BackColor = Color.Red;
                            //        checkCondition = true;
                            //    }
                            //}
                            //else
                            //{
                            //    // checkFabric.Rows[0]["Balance Length YDS"].Style.BackColor = Color.Red;
                            //    checkCondition = true;
                            //}
                        }

                    }
                    if (checkCondition)
                    {
                        BarCodeScan = tbBarcode.Text;
                        ///MessageBox.Show(BarCodeScan);
                        MessageBox.Show("Can't Scan Please Check Conditions", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        sdShowDataWrong sdShowDataWrong = new sdShowDataWrong();
                        sdShowDataWrong.Show();
                        goto goJumpOut;
                    }

                }
                else if (checkFabric.Rows.Count == 0)
                {
                    MessageBox.Show("This barcode does not exist. Please inform the warehouse.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else if (insertType == 3)
            {

            }

            if (tbBarcode.Text != "" && numPliesofRoll.Value != 0)
            {
                // MessageBox.Show("A1");
                string DateST = setDate();
                DataTable dt = new DataTable();
                dt = (DataTable)gvFabric.DataSource;
                int NoRows = 1;
                bool checkForAdd = false;
                if (gvFabric.Rows.Count > 0)
                {
                    string txt = tbBarcode.Text.Replace(" ", "");
                    for (int i = 0; i < gvFabric.Rows.Count; i++)
                    {
                        if (txt == dt.Rows[i]["Barcode"].ToString() && RowIndexEditValue == -1)
                        {
                            checkForAdd = true;
                            goto jump;
                        }
                    }
                jump:;
                }

                if (!checkForAdd)
                {
                    double yardUseNewFab = 0;
                    double oldYard = 0;
                    double yardBalance = 0;
                    double percentUseOld = 0;
                    double percentUseNew = 0;
                    double oldQty = 0;
                    double qtyBalanceOld = 0;
                    double qtyBalanceNew = 0;
                    yardUseNewFab = double.Parse(numPliesofRoll.Value.ToString()) * double.Parse(tbMarkerLengthYard.Text);
                    if (checkFabric.Rows.Count > 0 && insertType != 3)
                    {
                        if (gvFabric.Rows.Count > 0)
                        {
                            NoRows = gvFabric.Rows.Count + 1;
                        }
                        oldYard = double.Parse(checkFabric.Rows[0]["Balance Length YDS"].ToString().Trim()); // Get YDS
                        yardBalance = oldYard - yardUseNewFab; // old-new  >>check balance
                        percentUseOld = yardBalance / oldYard; //
                        percentUseNew = yardUseNewFab / oldYard;
                        oldQty = double.Parse(checkFabric.Rows[0]["Balance Qty"].ToString().Trim());
                        qtyBalanceOld = oldQty * percentUseOld;
                        qtyBalanceNew = oldQty * percentUseNew;
                        //  double OLW = (double)(oldYard * 1.02);

                        //if (yardUseNewFab > oldYard * 2) บล็อกผ้าเกิน ยกเลิกวันที่ 30/01/25
                        //{
                        //    MessageBox.Show("Balance Not Enough Can't Scan", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    BarCodeScan = tbBarcode.Text;
                        //    ///MessageBox.Show(BarCodeScan);                               
                        //    sdShowDataWrong sdShowDataWrong = new sdShowDataWrong();
                        //    sdShowDataWrong.Show();
                        //    goto goJumpOut;
                        //}




                        if (RowIndexEditValue != -1) //UPDATE `c_wh1_bc_sdactual_tb` SET `PliesActual`=@Cell1,`RestFabric`=@Cell2,`Defect`=@Cell3,`LappingFabric`=@Cell4,`ShortageInRoll`=@Cell5 WHERE `Barcode`=@condition AND `SD_ListDoc_No` LIKE '" + tbSDid.Text + "';
                        {
                            //Query เดิมก่อน อัพเดต
                            //ConnectMySQL.MysqlQuery("UPDATE `c_wh1_bc_sdactual_tb` SET `PliesActual`='" + numPliesofRoll.Value.ToString() + "'," +
                            //    "`RestFabric`='" + numRestFab.Value.ToString() + "',`Defect`='" + numDefect.Value.ToString() + "'," +
                            //    "`LappingFabric`='" + numLappFab.Value.ToString() + "',`ShortageInRoll`='" + numShortageInRoll.Value.ToString() + "', " +
                            //    "`Qty`='" + qtyBalanceNew + "', `YardNet`='" + yardUseNewFab + "' " +
                            //    "WHERE `Barcode` LIKE '" + tbBarcode.Text + "' AND `SD_ListDoc_No` LIKE '" + tbSDid.Text + "'");//RowIndexEditValue

                            ConnectMySQL.MysqlQuery("UPDATE `c_wh1_bc_sdactual_tb` SET `PliesActual`='" + numPliesofRoll.Value.ToString() + "'," +
                                "`RestFabric`='" + numRestFab.Value.ToString() + "',`Defect`='" + numDefect.Value.ToString() + "'," +
                                "`LappingFabric`='" + numLappFab.Value.ToString() + "',`ShortageInRoll`='" + numShortageInRoll.Value.ToString() + "'" +

                                "WHERE `Barcode` LIKE '" + tbBarcode.Text + "' AND `SD_ListDoc_No` LIKE '" + tbSDid.Text + "'");//RowIndexEditValue


                            gvFabric.Rows[RowIndexEditValue].Cells["PliesActual"].Value = numPliesofRoll.Value;
                            gvFabric.Rows[RowIndexEditValue].Cells["RestFabric"].Value = numRestFab.Value.ToString();
                            gvFabric.Rows[RowIndexEditValue].Cells["Defect"].Value = numDefect.Value.ToString();
                            gvFabric.Rows[RowIndexEditValue].Cells["LappingFabric"].Value = numLappFab.Value.ToString();
                            gvFabric.Rows[RowIndexEditValue].Cells["ShortageInRoll"].Value = numShortageInRoll.Value.ToString();
                        }
                        else
                        {
                            if (insertType == 1)
                            {
                                ConnectMySQL.MysqlQuery("UPDATE `c_wh1_bc_sdactual_tb` SET `Qty`='" + qtyBalanceOld.ToString("##.##") + "'," +
                                    "`YardNet`='" + yardBalance.ToString("##.##") + "' WHERE `Barcode` LIKE '" + tbBarcode.Text + "' AND `SD_ListDoc_No`LIKE '" + tbspidAdd.Text + "'");
                                ConnectMySQL.MysqlQuery("INSERT INTO `c_wh1_bc_sdactual_tb`( `BcID`, `Barcode`, `CreateDate`, `Qty`, `YardNet`, `SD_ListDoc_No`," +
                                    "`PliesActual`,`RestFabric`,`Defect`,`LappingFabric`,`ShortageInRoll`) " +
                                "VALUES (NULL, '" + tbBarcode.Text + "', '" + DateST + "', '" + qtyBalanceNew + "', '" + yardUseNewFab + "','" + tbSDid.Text + "'," +
                                "'" + numPliesofRoll.Value + "','" + numRestFab.Value + "','" + numDefect.Value + "','" + numLappFab.Value + "','" + numShortageInRoll.Value + "');");
                                dt.Rows.Add(NoRows.ToString(), tbBarcode.Text, numPliesofRoll.Value, numRestFab.Value, numDefect.Value, numLappFab.Value, numShortageInRoll.Value);
                            }
                            else if (insertType == 2)
                            {
                                ConnectMySQL.MysqlQuery("INSERT INTO `c_wh1_bc_sdactual_tb`( `BcID`, `Barcode`, `CreateDate`, `Qty`, `YardNet`, `SD_ListDoc_No`," +
                                     "`PliesActual`,`RestFabric`,`Defect`,`LappingFabric`,`ShortageInRoll`) " +
                                "VALUES (NULL, '" + tbBarcode.Text + "', '" + DateST + "', '" + qtyBalanceNew + "', '" + yardUseNewFab + "','" + tbSDid.Text + "'," +
                               "'" + numPliesofRoll.Value + "','" + numRestFab.Value + "','" + numDefect.Value + "','" + numLappFab.Value + "','" + numShortageInRoll.Value + "');");
                                dt.Rows.Add(NoRows.ToString(), tbBarcode.Text, numPliesofRoll.Value, numRestFab.Value, numDefect.Value, numLappFab.Value, numShortageInRoll.Value);
                            }
                        }
                    }
                    else if (insertType == 3)
                    {
                        bool st = ConnectMySQL.MysqlQuery("INSERT INTO `c_wh1_bc_sdactual_tb` ( `BcID`, `Barcode`, `CreateDate`, `YardNet`, `SD_ListDoc_No`," +
                                "`PliesActual`,`RestFabric`,`Defect`,`LappingFabric`,`ShortageInRoll`) " +
                          "VALUES (NULL, '" + tbBarcode.Text + "', '" + DateST + "', '" + yardUseNewFab + "','" + tbSDid.Text + "'," +
                           "'" + numPliesofRoll.Value + "','" + numRestFab.Value + "','" + numDefect.Value + "','" + numLappFab.Value + "','" + numShortageInRoll.Value + "');");
                        if (st)
                        {
                            MessageBox.Show("OK");
                        }
                        dt.Rows.Add(NoRows.ToString(), tbBarcode.Text, numPliesofRoll.Value, numRestFab.Value, numDefect.Value, numLappFab.Value, numShortageInRoll.Value);
                    }
                    gvFabric.DataSource = dt;
                    picTakefromDoc.Visible = true;
                    picTakefromWH.Visible = true;
                    picClearFabric.Visible = true;
                    pnBar.Visible = false;
                    pnSD.Visible = false;
                    tlpFabricDetial.Visible = false;
                    tbspidAdd.Text = "";
                    tbBarcode.Text = "";
                    numPliesofRoll.Value = 0;
                    numRestFab.Value = 0;
                    numDefect.Value = 0;
                    numLappFab.Value = 0;
                    numShortageInRoll.Value = 0;
                    tbBarcode.Focus();
                    RowIndexEditValue = -1;
                }
                else
                {
                    MessageBox.Show("...Your Barcode is Duplicate...");
                }
            }
            else
            {
                MessageBox.Show("...Check Your Data...");
            }
        goJumpOut:;

        }
        private bool AddRow = false;

        private void numPlies_ValueChanged(object sender, EventArgs e)
        {
            canKey = true;
            checkKey = false;
        }
        int fabricIndex = -1;
        private void gvFabric_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvFabric.Rows.Count > 0)
            {
                if (e.RowIndex > -1)
                {
                    fabricIndex = e.RowIndex;
                }
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (gvFabric.Rows.Count > 0)
            {
                // MessageBox.Show(fabricIndex.ToString());

                string bar = gvFabric.Rows[fabricIndex].Cells["Barcode"].Value.ToString();
                ConnectMySQL.MysqlQuery("DELETE FROM `c_wh1_bc_sdactual_tb` WHERE `Barcode` LIKE '" + bar + "'AND `SD_ListDoc_No` LIKE '" + tbSDid.Text + "' ");
                gvFabric.Rows.RemoveAt(fabricIndex);
            }
        }

        private void gvFabric_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            checkKey = true;
            // MessageBox.Show("xcx");
        }
        int insertType = 0;
        private void picTakefromDoc_Click(object sender, EventArgs e)
        {
            numPliesofRoll.Maximum = 200;
            insertType = 1;
            pnBar.Visible = true;
            pnSD.Visible = true;
            tlpFabricDetial.Visible = true;
            picTakefromDoc.Visible = true;
            picTakefromWH.Visible = false;
            picClearFabric.Visible = false;
            tbBarcode.ReadOnly = false;
            tbspidAdd.Focus();
        }

        private void picTakefromWH_Click(object sender, EventArgs e)
        {
            numPliesofRoll.Maximum = 200;
            insertType = 2;
            pnBar.Visible = true;
            pnSD.Visible = false;
            tlpFabricDetial.Visible = true;
            picTakefromDoc.Visible = false;
            picTakefromWH.Visible = true;
            picClearFabric.Visible = false;
            tbBarcode.ReadOnly = false;
            tbBarcode.Focus();
        }

        private void picClearFabric_Click(object sender, EventArgs e)
        {
            double lengthMark = double.Parse(tbMarkerLengthYard.Text);
            if (lengthMark <= 3)
            {
                numPliesofRoll.Maximum = 4;
                insertType = 3;
                pnBar.Visible = true;
                pnSD.Visible = false;
                tlpFabricDetial.Visible = true;
                AutoGenDMBarcode();
                picTakefromDoc.Visible = false;
                picTakefromWH.Visible = false;
                picClearFabric.Visible = true;
                tbBarcode.ReadOnly = true;
                numPliesofRoll.Focus();
            }
            else
            {
                MessageBox.Show("ฟังก์ชั่นนี้ใช้ได้เมื่อความยาวมาร์คน้อยกว่าหรือเท่ากับ 3หลา This function allows the use of a mark length of 3 yards or less.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void AutoGenDMBarcode()
        {
            if (xGroup != "")
            {
                string searchFil = "DM" + xGroup.Substring(0, 1).ToUpper();//.`Barcode`
                DateTimePicker dateTimePicker = new DateTimePicker();
                dateTimePicker.Value = DateTime.Now;
                tbBarcode.Text = Calculate.DocNoAutoGen("SELECT `Barcode`  FROM `c_wh1_bc_sdactual_tb`  WHERE `Barcode` LIKE '%" + searchFil + "%'  ORDER BY `Barcode` DESC LIMIT 1;", searchFil, dateTimePicker);

            }

        }

        private void picRefresh_Click(object sender, EventArgs e)
        {
            numPliesofRoll.Maximum = 200;
            picTakefromDoc.Visible = true;
            picTakefromWH.Visible = true;
            picClearFabric.Visible = true;
            pnBar.Visible = false;
            pnSD.Visible = false;
            tlpFabricDetial.Visible = false;
            tbspidAdd.Text = "";
            tbBarcode.Text = "";
            numPliesofRoll.Value = 0;
            numRestFab.Value = 0;
            numDefect.Value = 0;
            numLappFab.Value = 0;

        }

        private void tbspidAdd_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbBarcode.Focus();
            }
        }

        private void tbBarcode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                numPliesofRoll.Focus();
            }
        }
        int RowIndexEditValue = -1;
        private void gvFabric_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvFabric.Rows.Count > 0)
            {
                if (e.RowIndex > -1)
                {
                    if (MessageBox.Show("Are you sure you want to edit values?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        pnBar.Visible = true;
                        tlpFabricDetial.Visible = true;
                        picTakefromDoc.Visible = false;
                        picTakefromWH.Visible = false;
                        picClearFabric.Visible = false;
                        numPliesofRoll.Value = decimal.Parse(gvFabric.Rows[e.RowIndex].Cells["PliesActual"].Value.ToString());
                        numRestFab.Value = decimal.Parse(gvFabric.Rows[e.RowIndex].Cells["RestFabric"].Value.ToString());
                        numDefect.Value = decimal.Parse(gvFabric.Rows[e.RowIndex].Cells["Defect"].Value.ToString());
                        numLappFab.Value = decimal.Parse(gvFabric.Rows[e.RowIndex].Cells["LappingFabric"].Value.ToString());
                        numShortageInRoll.Value = decimal.Parse(gvFabric.Rows[e.RowIndex].Cells["ShortageInRoll"].Value.ToString());
                        tbBarcode.Text = gvFabric.Rows[e.RowIndex].Cells["Barcode"].Value.ToString();
                        RowIndexEditValue = e.RowIndex;
                    }
                }
            }
        }
    }
}
