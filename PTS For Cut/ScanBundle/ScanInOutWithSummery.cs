using Guna.UI2.WinForms;
using PTS_For_Cut._Main;
using PTS_For_Cut.Main;
using PTS_For_Cut.myClass;
using PTS_For_Cut.Myclass;
using PTS_For_Cut.ScanBundle.Delivery_Note;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlTypes;
using System.Media;
using System.Reflection.Metadata;
using System.Windows.Forms;
using Color = System.Drawing.Color;

namespace PTS_For_Cut.ScanBundle
{
    public partial class ScanInOutWithSummery : Form
    {
        int st_INOUT = -1;
        public string dec = "";
        private string stInOut = "";
        private string Dec_Out = "";
        private string factory = "";
        public string Location = "";
        public static ScanInOutWithSummery ins;
        public ScanInOutWithSummery()
        {
            InitializeComponent();
            ins = this;

        }

        private void btScan_Click(object sender, EventArgs e)
        {
            scan_fc();
        }
        private void soundStatus(bool st)
        {
            if (st)
            {
                using (Stream stream = Properties.Resources.OK) // 'success' คือชื่อ Resource
                {
                    SoundPlayer player = new SoundPlayer(stream);
                    player.Play();
                }
            }
            else
            {
                using (Stream stream = Properties.Resources.Error) // 'success' คือชื่อ Resource
                {
                    SoundPlayer player = new SoundPlayer(stream);
                    player.Play();
                }
            }
        }
        string checkMainPartBundleScan = "";
        private void scan_fc()
        {
            if (tbScan.Text.Length == 13)
            {





                DataTable getDataTB = new DataTable();
                getDataTB = ConnectMySQL.MySQLtoDataTable(@"WITH latest_dec AS (
                                        SELECT 
                                            QrcodeBD,
                                            QTY,
                                            Decoration,
                                            Location,
                                            stINOUT,
                                            MAX(id) AS latest_id
                                        FROM a_b1_bundle_to_dec_tb
                                        GROUP BY QrcodeBD
                                    )
                                    SELECT 
                                        a.QRCodeBundle, 
                                        a.SD_ListDoc_No,
                                        a.SO,
                                        a.BundleNo, 
                                        a.Color, 
                                        a.Size,
                                        a.ClothingPart, 
                                        a.QTY AS CUT_QTY,
                                        COALESCE(b.QTY, a.QTY) AS QTY,  -- ใช้ QTY จาก b ถ้ามีข้อมูล ถ้าไม่มีใช้ QTY จาก a
                                        a.Deco, 
                                        CASE  
                                            WHEN a.MainPart = 1 THEN '1'
                                            ELSE '0'
                                        END AS MainPart,                                   
                                        a.FabricType,
                                        b.ch_accept,
                                        b.DeliveryNoteID,
                                        COALESCE(b.Decoration, NULL) AS Decoration,  
                                        COALESCE(b.Location, NULL) AS Location, 
                                        COALESCE(b.stINOUT, NULL) AS stINOUT,
                                        b.`Dec_Out`
                                    FROM a_b1_bundle_tb AS a
                                    LEFT JOIN latest_dec AS ld ON a.QRCodeBundle = ld.QrcodeBD
                                    LEFT JOIN a_b1_bundle_to_dec_tb AS b 
                                        ON ld.latest_id = b.id
                                    WHERE a.QRCodeBundle = '" + tbScan.Text + "';");
                //"AND `a`.`Deco` LIKE '%%';");

                if (getDataTB.Rows.Count > 0)
                {
                    bool Alert_ST = false;

                    if (gvDisScan.Rows.Count > 0)
                    {
                        bool check_SO = false;
                        for (int i = 0; i < gvDisScan.Rows.Count; i++)
                        {
                            if (gvDisScan.Rows[i].Cells["QRCodeBundle"].Value.ToString() == tbScan.Text)
                            {
                                Alert_ST = true;
                                soundStatus(false);
                                MessageBox.Show("Already Scaned.|| ข้อมูลซ้ำ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                tbScan.Text = ""; tbScan.Focus();
                                goto cross;
                            }
                            string db_so = getDataTB.Rows[0]["SO"].ToString();
                            if (gvDisScan.Rows[i].Cells["SO"].Value.ToString() == db_so)
                            {
                                check_SO = true;

                            }

                        }
                        if (!check_SO)
                        {
                            Alert_ST = true;
                            soundStatus(false);
                            MessageBox.Show("Only one SO can be scanned.|| สแกนได้ทีละ 1 SO", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbScan.Text = ""; tbScan.Focus();
                            goto cross;
                        }

                    }
                    if (dn_Over4hour_dt.Rows.Count > 0) // check Over 4 Hours
                    {
                        bool check_have_value = false;
                        for (int i = 0; i < dn_Over4hour_dt.Rows.Count; i++)
                        {
                            if (getDataTB.Rows[0]["DeliveryNoteID"].ToString() == dn_Over4hour_dt.Rows[i]["DeliveryNoteID"].ToString())
                            {
                                check_have_value = true;
                            }
                        }
                        if (!check_have_value)
                        {
                            Alert_ST = true;
                            soundStatus(false);
                            blockpopup();
                            tbScan.Text = ""; tbScan.Focus();
                            goto cross;

                        }
                    }

                    // if (gvDisScan.Rows[])

                    string dbDec = getDataTB.Rows[0]["Deco"].ToString();
                    if (dbDec.Split('/').Contains(dec) || dec.Substring(0, 3) == "SMK" || dec == "Cutting" || dec == "Buffer")
                    {
                        string LastST_INOUT = "";
                        string LastST_INOUT_forSMK = "";
                        string checkDecLastBDScan = getDataTB.Rows[getDataTB.Rows.Count - 1]["Decoration"].ToString();
                        checkMainPartBundleScan = getDataTB.Rows[getDataTB.Rows.Count - 1]["MainPart"].ToString();
                        bool canScan = false;

                        string ch_accept = getDataTB.Rows[getDataTB.Rows.Count - 1]["ch_accept"].ToString();
                        string Dec_outBefore = getDataTB.Rows[getDataTB.Rows.Count - 1]["Dec_Out"].ToString(); ;

                        // if ()


                        if (dec == "Cutting" && checkDecLastBDScan == "" && st_INOUT == 0) //check never scan
                        {
                            if (Dec_Out == "SMK" && dbDec == "")
                            {
                                canScan = true;
                            }
                            else if (Dec_Out == "Buffer" && dbDec == "")
                            {
                                canScan = true;
                            }
                            else if (dbDec == Dec_Out)
                            {
                                canScan = true;
                            }
                            else
                            {
                                Alert_ST = true;
                                soundStatus(false);
                                MessageBox.Show("Bundle data does not match decoration scan-out.|| Decoration Scan-Out ไม่ตรงกับสติ๊กเกอร์ ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                tbScan.Text = ""; tbScan.Focus();
                            }

                        }
                        else
                        {
                            LastST_INOUT = getDataTB.Rows[getDataTB.Rows.Count - 1]["stINOUT"].ToString();

                            if (st_INOUT == 1 && Dec_outBefore != dec && dec != "SMK") // check Last department scan Out
                            {
                                Alert_ST = true;
                                soundStatus(false);
                                MessageBox.Show("This bundle for" + Dec_outBefore + " || งานมัดนี้สำหรับ " + Dec_outBefore, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                tbScan.Text = ""; tbScan.Focus();
                            }
                            else if (st_INOUT == 0 && LastST_INOUT == "1" && checkDecLastBDScan != dec) // Select Scan Out && Last bundle in DB Status Scanin && Last Dec = select dec
                            {//Scan Out need to check scan In finish yet
                                Alert_ST = true;
                                soundStatus(false);
                                MessageBox.Show(checkDecLastBDScan + " Department It Hasn't Been Scanned Out Yet. || แผนก " + checkDecLastBDScan + "ยังไม่ได้สแกนออก", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                tbScan.Text = ""; tbScan.Focus();
                            }
                            else if (st_INOUT == 0 && LastST_INOUT == "" && checkDecLastBDScan == "") //Select Scan Out && Last bundle in DB = "" && Last Dec = ""
                            {
                                Alert_ST = true;
                                soundStatus(false);
                                MessageBox.Show("This bundle has not been scanned in yet from cutting. || แผนกตัดยังไม่ได้สแกนออก", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                tbScan.Text = ""; tbScan.Focus();
                            }
                            else if (st_INOUT == 0 && LastST_INOUT == "0")
                            {
                                Alert_ST = true;
                                soundStatus(false);
                                MessageBox.Show("This bundle has not been scanned in yet. || งานมัดนี้ยังไม่ได้สแกนเข้า", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                tbScan.Text = ""; tbScan.Focus();
                            }

                            else if (st_INOUT == 1 && LastST_INOUT == "1" && checkDecLastBDScan != dec)
                            {
                                Alert_ST = true;
                                soundStatus(false);
                                MessageBox.Show(checkDecLastBDScan + " Department It Hasn't Been Scanned Out Yet. || แผนก " + checkDecLastBDScan + "ยังไม่ได้สแกนออก", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                tbScan.Text = ""; tbScan.Focus();
                            }
                            else if (st_INOUT == 1 && LastST_INOUT == "1" && checkDecLastBDScan == dec)
                            {
                                Alert_ST = true;
                                soundStatus(false);
                                MessageBox.Show("Scan In Already Can't Scan. || เคยสแกนแล้วสแกนอีกไม่ได้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                tbScan.Text = ""; tbScan.Focus();
                            }
                            else if (st_INOUT == 0 && LastST_INOUT == "1" && checkDecLastBDScan == dec)
                            {//Scan Out need to check scan In finish yet

                                canScan = true;
                            }
                            else if (st_INOUT == 1 && LastST_INOUT == "0")
                            {
                                canScan = true;
                            }
                        }
                        if (canScan)
                        {

                            if (gvDisAllOfGroup.Rows.Count > 0) //check scan within Group Rigth?
                            {
                                bool chcc = false;
                                for (int i = 0; i < gvDisAllOfGroup.Rows.Count; i++)
                                {
                                    if (gvDisAllOfGroup.Rows[i].Cells["QR"].Value.ToString() == tbScan.Text)
                                    {
                                        gvDisAllOfGroup.Rows[i].DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                                        chcc = true; break;
                                    }
                                }
                                if (chcc)
                                {
                                    canScan = true;

                                }
                                else
                                {
                                    canScan = false;
                                    Alert_ST = true;
                                    soundStatus(false);
                                    MessageBox.Show("Invalid Part: Not in Bundle Group || ไม่มีข้อมูลใน ตารางอ้างอิง ซ้ายมือ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    tbScan.Text = ""; tbScan.Focus();
                                }

                                if (dec == "Buffer" && canScan)
                                {
                                    if (ch_accept != "0")
                                    {
                                        canScan = false;
                                        Alert_ST = true;
                                        soundStatus(false);
                                        if (ch_accept == "1")
                                        {
                                            MessageBox.Show("Bundle already in buffer. || สแกนเข้า บัฟเฟอร์แล้ว ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            tbScan.Text = ""; tbScan.Focus();
                                        }
                                        else if (ch_accept == "")
                                        {
                                            MessageBox.Show("Previous department scan-out is incorrect. || แผนกก่อนหน้าแสนออกไม่ถูกต้อง", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            tbScan.Text = ""; tbScan.Focus();
                                        }

                                    }
                                }

                            }

                        }

                        if (canScan)
                        {

                            addRowDtToGV(getDataTB);
                        }
                        else
                        {
                            if (!Alert_ST)
                            {
                                soundStatus(false);
                                MessageBox.Show("Can't Scan. || สแกนไม่สำเร็จ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                tbScan.Text = ""; tbScan.Focus();
                            }
                        }

                    }
                    else
                    {
                        soundStatus(false);
                        MessageBox.Show("Decoration Not Match || Decoration ไม่ตรง", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbScan.Text = ""; tbScan.Focus();

                    }
                }
                else
                {
                    soundStatus(false);
                    MessageBox.Show("Don't Have Bundle for This Decoration. || งานมัดนี้ไม่มีในระบบ แจ้งคนทำสติ๊กเกอร์", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbScan.Text = ""; tbScan.Focus();

                }
            cross:;
            }
        }

        private void addRowDtToGV(DataTable getDataTB)
        {
            int QTY_Bundle = 0;

            if (gvDisScan.Columns.Count == 0)
            {
                DataTable newTable = new DataTable();

                foreach (DataColumn col in getDataTB.Columns)
                {
                    newTable.Columns.Add(col.ColumnName);
                }
                gvDisScan.DataSource = newTable;
            }
            DataTable disScanTable = (DataTable)gvDisScan.DataSource;
            DataRow newRow = disScanTable.NewRow();

            // Copy values from last row of getDataTB

            for (int i = 0; i < getDataTB.Columns.Count; i++)
            {
                string columnName = getDataTB.Columns[i].ColumnName;
                string txtGetData = getDataTB.Rows[getDataTB.Rows.Count - 1][i].ToString();

                if (disScanTable.Columns.Contains(columnName))
                {
                    newRow[columnName] = txtGetData;
                }
                if (columnName == "QTY")
                {
                    // Optional logic here
                }
            }
            disScanTable.Rows.Add(newRow); // ✅ Safe!

            gvDisScan.DataSource = disScanTable;

            string sd_dbID = gvDisScan.Rows[gvDisScan.Rows.Count - 1].Cells["SD_ListDoc_No"].Value.ToString();
            string ClothingPart = gvDisScan.Rows[gvDisScan.Rows.Count - 1].Cells["ClothingPart"].Value.ToString();

            if (gvDisAllOfGroup.Rows.Count == 0) // SMK Only
            {
                string sqlBD_all = "";
                if (dec == "SMK")
                {
                    sqlBD_all = @"
                                    SELECT `QRCodeBundle` AS QR, `ClothingPart`AS Part FROM a_b1_bundle_tb 
                                    WHERE `SD_ListDoc_No` LIKE '" + sd_dbID + @"' 
                                    AND `BundleNo`=(
                                                    SELECT `BundleNo` 
                                                    FROM a_b1_bundle_tb 
                                                    WHERE `QRCodeBundle` LIKE '" + tbScan.Text + @"' );";
                }
                else if (st_INOUT == 1)
                {
                    sqlBD_all = @"SELECT  `QrcodeBD` AS QR, `ClothingPart`AS Part FROM a_b1_bundle_to_dec_tb 
                    WHERE `DeliveryNoteID` IS NOT NULL AND `DeliveryNoteID` !='' AND `DeliveryNoteID`=(
                                    SELECT `DeliveryNoteID`
                                    FROM a_b1_bundle_to_dec_tb 
                                    WHERE `QrcodeBD` LIKE '" + tbScan.Text + @"' ORDER BY `id` DESC LIMIT 1 );";
                }
                else if (dec == "Cutting")
                {
                    string condition = " AND `Deco` LIKE '" + Dec_Out + "'";
                    if (Dec_Out == "SMK" || Dec_Out == "Buffer")
                    {
                        condition = "AND `Deco` IS NULL ";
                    }
                    if (cbbGroupPart.SelectedIndex == 1)
                    {
                        condition = "";
                    }
                    sqlBD_all = @"
                                    SELECT `QRCodeBundle` AS QR, `ClothingPart`AS Part FROM a_b1_bundle_tb 
                                            WHERE `SD_ListDoc_No` LIKE '" + sd_dbID + @"' AND 
                                            `BundleNo`=( SELECT `BundleNo` FROM a_b1_bundle_tb WHERE `QRCodeBundle` LIKE '" + tbScan.Text + @"' ) 
                                            " + condition + "; ";

                }

                if (sqlBD_all.Length > 0)
                {
                    ConnectMySQL.DisplayAndSearch(sqlBD_all, gvDisAllOfGroup);
                }

                // gvDisAllOfGroup.Columns["QR"].Visible = false;
                for (int i = 0; i < gvDisAllOfGroup.Rows.Count; i++)
                {
                    if (gvDisAllOfGroup.Rows[i].Cells["QR"].Value.ToString() == tbScan.Text)
                    {
                        gvDisAllOfGroup.Rows[i].DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                        break;
                    }

                }

            }

            string txt_sql = @"SELECT  `a`.`SD_ListDoc_No`, `a`.`Color`, `a`.`Size`, `a`.`ClothingPart`, `a`.`SO`,COUNT(`a`.`QRCodeBundle`)AS 'Bundle', SUM(`a`.`QTY`) AS 'QTY','' AS'Bundle_Scan','' AS'QTY_Scan'
                                    FROM `a_b1_bundle_tb` AS `a`
                                    LEFT JOIN `sizes_tb` AS `b` ON `a`.`Size`=`b`.`Size`
                                    WHERE `a`.`ClothingPart` = '" + ClothingPart + "' AND  `SD_ListDoc_No`LIKE '" + sd_dbID + @"' 
                                    GROUP BY `SD_ListDoc_No`,`Size`
                                    ORDER BY `b`.`SeqNo`;";             // Summary
            string sqltxtScanned = @"WITH LatestScanOut AS ( SELECT   
                                   `QrcodeBD`, 
                                   `stINOUT`,
                                   MAX(`id`) AS maxID       
                                FROM 
                                    `a_b1_bundle_to_dec_tb`
                                WHERE 
                                    `Decoration` LIKE 'SMK' AND `SD_ListDoc_No`= '" + sd_dbID + @"'
                                    GROUP BY  `stINOUT`,`QrcodeBD`)
                                        SELECT      `s`.`SD_ListDoc_No`,                                            
                                                    `s`.`Color`, 
                                                    `a`.`Size`,
                                                    `b`.`ClothingPart`,
                                                    COUNT(`b`.`QrcodeBD`) AS `BD_QTY`,
                                                   SUM(`b`.`QTY`) AS `QTY`
                                                  FROM 
                                                    `a_b1_bundle_to_dec_tb` `b`
                                                JOIN 
                                                    `a_b1_bundle_tb` `a` ON `a`.`QRCodeBundle` = `b`.`QrcodeBD` 
                                                JOIN 
                                                    `a_a1_spreading_list_tb` `s` ON `a`.`SD_ListDoc_No` = `s`.`SD_ListDoc_No`  AND               
                                                     `s`.`SD_ListDoc_No` LIKE '" + sd_dbID + @"'
                                                JOIN 
                                                    LatestScanOut `ls` 
                                                    ON `b`.`QrcodeBD` = `ls`.`QrcodeBD` 
                                                    AND `b`.`stINOUT`= `ls`.`stINOUT`
                                                    AND `b`.`id` = `ls`.`maxID`   
                                                WHERE
                                                       `b`.`stINOUT` = '" + st_INOUT + "'   AND `b`.`Decoration` LIKE 'SMK' AND `b`.`ClothingPart` = '" + ClothingPart + @"'
                                                    GROUP BY  
                                                    `s`.`SD_ListDoc_No`,                                            
                                                    `s`.`Color`, 
                                                    `a`.`Size`,
                                                    `b`.`ClothingPart`;";
            //------------------------------------------------------------------------------------------------ gvDisSummary

            //if (gvDisSummary.Rows.Count == 0)
            //{
            //    ConnectMySQL.DisplayAndSearch(txt_sql, gvDisSummary);
            //    checkNewSDAddQTYinCaseGetNewSD(sqltxtScanned);
            //}
            //else
            //{
            //    bool checkID = false;
            //    for (int i = 0; i < gvDisSummary.Rows.Count; i++)
            //    {
            //        if (sd_dbID == gvDisSummary.Rows[i].Cells["SD_ListDoc_No"].Value.ToString()
            //            && ClothingPart == gvDisSummary.Rows[i].Cells["ClothingPart"].Value.ToString())
            //        {
            //            checkID = true; break;
            //        }
            //    }

            //    if (!checkID && dec == "SMK" && checkMainPartBundleScan == "0")
            //    {
            //        checkID = true;
            //    }


            //    if (!checkID)//check Sprieading No in Summary table !checkID = don't have
            //    {
            //        DataTable newsd_totb = ConnectMySQL.MySQLtoDataTable(txt_sql); // Get data from MySQL
            //        DataTable dt = new DataTable();
            //        // If gvDisSummary already has data, get its DataSource
            //        if (gvDisSummary.DataSource != null)
            //        {
            //            dt = (DataTable)gvDisSummary.DataSource;
            //        }
            //        else
            //        {
            //            dt = newsd_totb.Clone(); // Clone structure if DataSource is null
            //        }
            //        // Add rows from `newsd_totb` correctly
            //        foreach (DataRow row in newsd_totb.Rows)
            //        {
            //            dt.Rows.Add(row.ItemArray); // Copy entire row data correctly
            //        }
            //        gvDisSummary.DataSource = dt;
            //        checkNewSDAddQTYinCaseGetNewSD(sqltxtScanned);
            //    }
            //    else
            //    {
            //        alreadyHaveSD_Data();
            //    }

            //}
            //------------------------------------------------------------------------------------------------- gvDisSummary

            if (gvDisScan.Rows.Count > 0)
            {
                var gv = gvDisScan.Rows[gvDisScan.Rows.Count - 1];
                int cut_QTY = int.Parse(gv.Cells["CUT_QTY"].Value.ToString());
                int QTY = int.Parse(gv.Cells["QTY"].Value.ToString());
                string colors = gv.Cells["Color"].Value.ToString();
                string size = gv.Cells["size"].Value.ToString();
                string Clothing_Part = gv.Cells["ClothingPart"].Value.ToString();
                // sd_dbID
                if (gvDisColorSizeBreak.Columns.Count == 0)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Spreading_No");
                    dt.Columns.Add("Colors");
                    dt.Columns.Add("Clothing_Part");
                    dt.Columns.Add(size);

                    dt.Rows.Add(sd_dbID, colors, Clothing_Part, QTY);
                    dt.Rows.Add("SUM", "", "");
                    gvDisColorSizeBreak.DataSource = dt;

                }
                else
                {//----------------------------------------------------------------------------------------v-- add Column Size  -----
                    bool checkSize = false;
                    for (int k = 3; k < gvDisColorSizeBreak.Columns.Count; k++)
                    {
                        string ssize = gvDisColorSizeBreak.Columns[k].Name;
                        if (size == ssize)
                        {
                            checkSize = true;
                        }
                    }
                    if (!checkSize)
                    {
                        DataTable dt = (DataTable)gvDisColorSizeBreak.DataSource;
                        dt.Columns.Add(size);
                        gvDisColorSizeBreak.DataSource = dt;

                    }
                    //-----------------------------------------------------------------------------------V--- Add Rows (SD,Colors,ClothingPart) ----
                    bool checkSD_color_Part = false;
                    for (int i = 0; i < gvDisColorSizeBreak.Rows.Count; i++)
                    {
                        string sdID = gvDisColorSizeBreak.Rows[i].Cells["Spreading_No"].Value.ToString();
                        string cc = gvDisColorSizeBreak.Rows[i].Cells["Colors"].Value.ToString();
                        string clotingPart = gvDisColorSizeBreak.Rows[i].Cells["Clothing_Part"].Value.ToString();

                        if (sdID == sd_dbID && colors == cc && Clothing_Part == clotingPart)
                        {
                            checkSD_color_Part = true;
                        }
                    }
                    if (!checkSD_color_Part)
                    {
                        if (dec == "SMK" && checkMainPartBundleScan == "0")
                        {
                            checkSD_color_Part = true;
                        }
                    }
                    if (!checkSD_color_Part)
                    {
                        DataTable dt = (DataTable)gvDisColorSizeBreak.DataSource;
                        dt.Rows.Add(sd_dbID, colors, Clothing_Part);
                        gvDisColorSizeBreak.DataSource = dt;

                    }
                    // --------------------------------------------------------------------------------------V--- Add Value QTY In table -----
                    for (int i = 0; i < gvDisColorSizeBreak.Rows.Count; i++)
                    {
                        string sdID = gvDisColorSizeBreak.Rows[i].Cells["Spreading_No"].Value.ToString();
                        string cc = gvDisColorSizeBreak.Rows[i].Cells["Colors"].Value.ToString();
                        string clotingPart = gvDisColorSizeBreak.Rows[i].Cells["Clothing_Part"].Value.ToString();

                        if (sdID == sd_dbID && colors == cc && Clothing_Part == clotingPart)
                        {
                            for (int j = 3; j < gvDisColorSizeBreak.Columns.Count; j++)
                            {
                                string ssize = gvDisColorSizeBreak.Columns[j].Name;
                                if (size == ssize)
                                {
                                    string qqty = gvDisColorSizeBreak.Rows[i].Cells[j].Value.ToString();
                                    int intqqty = 0;
                                    if (qqty != "")
                                    {
                                        intqqty = int.Parse(qqty) + QTY;
                                    }
                                    else
                                    {
                                        intqqty = QTY;
                                    }

                                    gvDisColorSizeBreak.Rows[i].Cells[j].Value = intqqty;
                                }
                            }
                        }
                    }
                    //---------------------------------------------------------------------------------------------------------
                }



                if (cut_QTY > QTY)
                {
                    gvDisScan.Rows[gvDisScan.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Red;
                }

                DataTable dt5 = (DataTable)gvDisColorSizeBreak.DataSource;

                DataRow sumRow = null;

                // Find and store the "SUM" row
                foreach (DataRow row in dt5.Rows)
                {
                    if (row[0] != null && row[0].ToString() == "SUM")
                    {
                        sumRow = row;
                        break;
                    }
                }

                if (sumRow != null)
                {
                    // Copy the data
                    DataRow newRow5 = dt5.NewRow();
                    newRow5.ItemArray = sumRow.ItemArray.Clone() as object[];

                    // Remove old row and add the new one to the end
                    dt5.Rows.Remove(sumRow);
                    dt5.Rows.Add(newRow5);
                }
                for (int k = 3; k < gvDisColorSizeBreak.Columns.Count; k++)
                {
                    int sumQty = 0;
                    for (int i = 0; i < gvDisColorSizeBreak.Rows.Count - 1; i++)
                    {
                        string qtyinRow = gvDisColorSizeBreak.Rows[i].Cells[k].Value.ToString();
                        if (qtyinRow != "")
                        {
                            sumQty += int.Parse(qtyinRow);
                        }
                    }
                    gvDisColorSizeBreak.Rows[gvDisColorSizeBreak.RowCount - 1].Cells[k].Value = sumQty;
                }
                gvDisColorSizeBreak.Rows[gvDisColorSizeBreak.RowCount - 1].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
            }
            soundStatus(true);
            tbScan.Text = ""; tbScan.Focus();
            gvDisScan.Rows[gvDisScan.Rows.Count - 1].Cells["Location"].Value = cbbLocation2.Text;
            tbScan.Focus();
            foreach (DataGridViewColumn col in gvDisColorSizeBreak.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn col in gvDisScan.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn col in gvDisSummary.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            bool ckeckIngroupScanfinshYet = false;
            for (int i = 0; i < gvDisAllOfGroup.Rows.Count; i++)
            {
                // MessageBox.Show(gvDisAllOfGroup.Rows[i].DefaultCellStyle.BackColor.ToString());
                if (gvDisAllOfGroup.Rows[i].DefaultCellStyle.BackColor == Color.Empty)
                {
                    ckeckIngroupScanfinshYet = true; break;
                }
            }
            //MessageBox.Show(ckeckIngroupScanfinshYet.ToString());
            if (!ckeckIngroupScanfinshYet)
            {
                for (int i = gvDisAllOfGroup.Columns.Count - 1; i >= 0; i--)
                {
                    gvDisAllOfGroup.Columns.RemoveAt(i);
                }
            }
        }

        private void checkNewSDAddQTYinCaseGetNewSD(string sqltxtScanned)
        {
            DataTable dt_scanned = ConnectMySQL.MySQLtoDataTable(sqltxtScanned); //
            string inOutSD = gvDisScan.Rows[gvDisScan.Rows.Count - 1].Cells["SD_ListDoc_No"].Value.ToString();
            string inOutColor = gvDisScan.Rows[gvDisScan.Rows.Count - 1].Cells["Color"].Value.ToString();
            string inOutSize = gvDisScan.Rows[gvDisScan.Rows.Count - 1].Cells["Size"].Value.ToString();
            string inClothingPart = gvDisScan.Rows[gvDisScan.Rows.Count - 1].Cells["ClothingPart"].Value.ToString();
            int inOutQTY = int.Parse(gvDisScan.Rows[gvDisScan.Rows.Count - 1].Cells["QTY"].Value.ToString());
            for (int i = 0; i < gvDisSummary.Rows.Count; i++)
            {
                var gv = gvDisSummary.Rows[i];
                string gvSD = gv.Cells["SD_ListDoc_No"].Value.ToString();
                string gvColor = gv.Cells["Color"].Value.ToString();
                string gvSize = gv.Cells["Size"].Value.ToString();
                string gvClothingPart = gv.Cells["ClothingPart"].Value.ToString();

                for (int j = 0; j < dt_scanned.Rows.Count; j++)
                {
                    var dt = dt_scanned.Rows[j];
                    string dtSD = dt["SD_ListDoc_No"].ToString();
                    string dtColor = dt["Color"].ToString();
                    string dtSize = dt["Size"].ToString();
                    string dtClothingPart = dt["ClothingPart"].ToString();
                    int dtBundle = int.Parse(dt["BD_QTY"].ToString());
                    int dtQTY = int.Parse(dt["QTY"].ToString());
                    // MessageBox.Show(gvSD + "=" + dtSD + "||" + gvColor + "=" + dtColor
                    //   + "||" + gvSize + "=" + dtSize + "||" + gvClothingPart + "=" + dtClothingPart);
                    if (gvSD == dtSD && gvColor == dtColor && gvSize == dtSize && gvClothingPart == dtClothingPart)
                    {
                        int QTY_Scan = 0;
                        if (gv.Cells["QTY_Scan"].Value.ToString() != "")
                        {
                            QTY_Scan = int.Parse(gv.Cells["QTY_Scan"].Value.ToString());
                        }
                        gv.Cells["Bundle_Scan"].Value = dtBundle;
                        gv.Cells["QTY_Scan"].Value = dtQTY;
                        if (inOutSD == gvSD && gvColor == inOutColor && inOutSize == gvSize && inClothingPart == gvClothingPart)
                        {
                            gv.Cells["Bundle_Scan"].Value = dtBundle + 1;
                            gv.Cells["QTY_Scan"].Value = dtQTY + inOutQTY;
                        }
                    }
                }
            }

            for (int i = 0; i < gvDisSummary.Rows.Count; i++)
            {
                var gv = gvDisSummary.Rows[i];
                string gvSD = gv.Cells["SD_ListDoc_No"].Value.ToString();
                string gvColor = gv.Cells["Color"].Value.ToString();
                string gvSize = gv.Cells["Size"].Value.ToString();
                string gvClothingPart = gv.Cells["ClothingPart"].Value.ToString();

                if (inOutSD == gvSD && gvColor == inOutColor && inOutSize == gvSize
                && gv.Cells["QTY_Scan"].Value.ToString() == ""
                && gvClothingPart == gv.Cells["ClothingPart"].Value.ToString())
                {
                    gv.Cells["Bundle_Scan"].Value = 1;
                    gv.Cells["QTY_Scan"].Value = inOutQTY;
                }
            }
            colorSummaryZone();


        }
        private void colorSummaryZone()
        {
            string checkSD_ListDoc_No = "";
            string checkClothingPart = "";
            bool ph = false;
            if (gvDisSummary.Rows.Count > 0)
            {
                for (int i = 0; i < gvDisSummary.Rows.Count; i++)
                {
                    string SD_ListDoc_No = gvDisSummary.Rows[i].Cells["SD_ListDoc_No"].Value.ToString();
                    string ClothingPart = gvDisSummary.Rows[i].Cells["ClothingPart"].Value.ToString();
                    // MessageBox.Show(checkSD_ListDoc_No + "||" + SD_ListDoc_No + "<<||>>" + checkClothingPart + "||" + ClothingPart + "<<||>>" + ph.ToString());

                    if (checkSD_ListDoc_No != SD_ListDoc_No || checkClothingPart != ClothingPart)
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
                        gvDisSummary.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                    }
                    else
                    {
                        gvDisSummary.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    }
                    checkSD_ListDoc_No = SD_ListDoc_No;
                    checkClothingPart = ClothingPart;
                }
            }
        }
        private void alreadyHaveSD_Data()
        {
            string inOutSD = gvDisScan.Rows[gvDisScan.Rows.Count - 1].Cells["SD_ListDoc_No"].Value.ToString();
            string inOutColor = gvDisScan.Rows[gvDisScan.Rows.Count - 1].Cells["Color"].Value.ToString();
            string inOutSize = gvDisScan.Rows[gvDisScan.Rows.Count - 1].Cells["Size"].Value.ToString();
            string inClothingPart = gvDisScan.Rows[gvDisScan.Rows.Count - 1].Cells["ClothingPart"].Value.ToString();
            int inOutQTY = int.Parse(gvDisScan.Rows[gvDisScan.Rows.Count - 1].Cells["QTY"].Value.ToString());
            for (int i = 0; i < gvDisSummary.Rows.Count; i++)
            {
                var gv = gvDisSummary.Rows[i];
                string gvSD = gv.Cells["SD_ListDoc_No"].Value.ToString();
                string gvColor = gv.Cells["Color"].Value.ToString();
                string gvSize = gv.Cells["Size"].Value.ToString();
                string gvClothingPart = gv.Cells["ClothingPart"].Value.ToString();
                int CountBD = 0;
                int qtyinSum = 0;
                if (gv.Cells["QTY_Scan"].Value.ToString() != "")
                {
                    CountBD = int.Parse(gv.Cells["Bundle_Scan"].Value.ToString());
                    qtyinSum = int.Parse(gv.Cells["QTY_Scan"].Value.ToString());
                }
                if (inOutSD == gvSD && gvColor == inOutColor && inOutSize == gvSize && inClothingPart == gvClothingPart)
                {
                    gv.Cells["Bundle_Scan"].Value = CountBD + 1;
                    gv.Cells["QTY_Scan"].Value = qtyinSum + inOutQTY;
                }
            }
        }
        bool _DeliveryNoteStatus = false;
        public string DNID = "";
        public DataTable dn_Over4hour_dt = new DataTable();
        private void ScanInOutWithSummery_Load(object sender, EventArgs e)
        {

            dec = HomePage.ins.Decoration;
            stInOut = HomePage.ins.DecMode;
            Dec_Out = HomePage.ins.DecOut;

            cbbPartPrint.SelectedIndex = 0;
            dtpSearch1.Value = DateTime.Now;
            _DeliveryNoteStatus = HomePage.ins.DeliveryNoteStatus;

            if (_DeliveryNoteStatus)
            {
                pnBDALL.Visible = false;
                toolStrip1.Visible = false;
                //
                btnToggleOpen3_Click(null, EventArgs.Empty);
                HomePage.ins.DecMode = "Scan Out";
                cbbDecoration.Items.Clear();
                for (int i = 0; i < Login.ins.dtDecoration.Rows.Count; i++)
                {
                    cbbDecoration.Items.Add(Login.ins.dtDecoration.Rows[i]["Dec_Eng"].ToString());
                }
                btSave.Visible = false;
                btNewDNID.Visible = false;
            }
            else
            {
                splitContainer2.Panel1Collapsed = true;
                btnToggleClose1_Click(null, EventArgs.Empty);
                DataTable dtLocation = SelectDepartScan.ins.dtLocation;
                cbbLocation2.Items.Clear();
                for (int i = 0; i < dtLocation.Rows.Count; i++)
                {
                    cbbLocation2.Items.Add(dtLocation.Rows[i]["Location"].ToString());
                }
                blockpopup();

            }

            lbBillNo.Text = "";
            tbScan.Focus();
            lbHeader.Text = HomePage.ins.Decoration + "::" + HomePage.ins.DecMode + "::" + HomePage.ins.DecOut;
            //cbbLocation.Text



            if (Properties.Settings.Default.Factory != "")
            {
                factory = Properties.Settings.Default.Factory;
            }
            cbbLocation2.Text = HomePage.ins.Declocation;
            Location = cbbLocation2.Text;
            if (stInOut == "Scan In")
            {
                st_INOUT = 1;
                Dec_Out = "";
                toolStripLabel1.Visible = false;
                lbBillNo.Visible = false;
                btNewDNID.Visible = false;
            }
            else if (stInOut == "Scan Out")
            {
                st_INOUT = 0;
                toolStripLabel1.Visible = true;
                lbBillNo.Visible = true;

                NewDNID();
            }
            //
            gvDisScan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gvDisSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gvDn.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gvDisColorSizeBreak.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gvDisAllOfGroup.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            if (dec == "Cutting")
            {
                cbbGroupPart.SelectedIndex = 0;
            }
            else
            {
                cbbGroupPart.Visible = false;
            }

        }
        private void blockpopup()
        {
            string sql = @"
                            SELECT a.`DeliveryNoteID`,`Decoration` AS FromDec, a.`SD_ListDoc_No`,b.Color,a.`SO`,COUNT(a.`QrcodeBD`) AS BundleIn_Bill,  SUM(a.`QTY`) AS QTY_In_Bill ,a.`TimeScan`
                             FROM `a_b1_bundle_to_dec_tb` a
                             LEFT JOIN a_a1_spreading_list_tb b ON b.`SD_ListDoc_No` =a.`SD_ListDoc_No`
                             WHERE a.`Dec_Out` LIKE '" + dec + @"' AND a.`ch_accept` = 0
                               AND a.`TimeScan` < NOW() - INTERVAL 2 HOUR
                               GROUP BY a.`DeliveryNoteID`
                               ORDER BY a.`TimeScan` ASC;";

            dn_Over4hour_dt = ConnectMySQL.MySQLtoDataTable(sql);
            if (dn_Over4hour_dt.Rows.Count > 0)
            {
                BlockScanOvertime blockScanOvertime = new BlockScanOvertime();
                blockScanOvertime.Show();
                blockScanOvertime.TopMost = true;
            }
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            bool check_RedColor = false;

            for (int i = 0; i < gvDisScan.Rows.Count; i++)
            {
                if (gvDisScan.Rows[i].DefaultCellStyle.BackColor == Color.Red)
                {
                    check_RedColor = true;
                    break;
                }
            }

            bool ckeckIngroupScanfinshYet = false;
            for (int i = 0; i < gvDisAllOfGroup.Rows.Count; i++)
            {
                // MessageBox.Show(gvDisAllOfGroup.Rows[i].DefaultCellStyle.BackColor.ToString());
                if (gvDisAllOfGroup.Rows[i].DefaultCellStyle.BackColor == Color.Empty && dec != "SMK")
                {
                    ckeckIngroupScanfinshYet = true; break;
                }
            }


            if (!check_RedColor)
            {
                if (!ckeckIngroupScanfinshYet)
                {
                    if (dec == "Buffer")
                    {
                        if (gvDisScan.Rows.Count > 0)
                        {
                            if (MessageBox.Show("Are you sure you want to save the data?", "Imformation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                HashSet<string> uniqueValues = new HashSet<string>();

                                // สมมุติว่าคุณต้องการดึงค่าจากคอลัมน์แรก (index 0) ของ DataGridView ชื่อ dgv1
                                foreach (DataGridViewRow row in gvDisScan.Rows)
                                {
                                    if (row.Cells["DeliveryNoteID"].Value != null) // ตรวจสอบว่าไม่ใช่ค่า null
                                    {
                                        string value = row.Cells["DeliveryNoteID"].Value.ToString();
                                        uniqueValues.Add(value); // HashSet จะเก็บเฉพาะค่าที่ไม่ซ้ำกัน
                                    }
                                }

                                // แปลงเป็น List ถ้าคุณต้องการใช้งานในรูปแบบ List
                                List<string> resultList = uniqueValues.ToList();
                                string inClause = string.Join(",", resultList.Select(id => $"'{id}'"));

                                // สร้าง SQL command
                                string sqlUpdate = $" UPDATE `a_b1_bundle_to_dec_tb` SET `ch_accept`='1' WHERE `DeliveryNoteID` IN ({inClause}); ";

                                bool st = ConnectMySQL.MysqlQuery(sqlUpdate);
                                if (st)
                                {
                                    MessageBox.Show("Data inserted successfully!");
                                }
                                else
                                {
                                    MessageBox.Show("Error inserting data.");
                                }

                            }
                        }
                    }
                    else
                    {
                        if (st_INOUT == 0)
                        {



                            if (lbBillNo.Text.Length > 0)
                            {
                                if (MessageBox.Show("Are you sure you want to save the data?", "Imformation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    ScanInOutSave();
                                }
                            }
                            else
                            {
                                soundStatus(false);
                                MessageBox.Show("Please generate a Delivery Note ID.", "Imformation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        else
                        {
                            if (MessageBox.Show("Are you sure you want to save the data?", "Imformation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                ScanInOutSave();
                            }
                        }
                    }
                }
                else
                {
                    soundStatus(false);
                    MessageBox.Show("Bundle scan incomplete", "Imformation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                soundStatus(false);
                MessageBox.Show("Please confirm the bundle decrease before saving.", "Imformation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ScanInOutSave()
        {
            string insertMultiValue = "";
            bool first = false;
            for (int i = 0; i < gvDisScan.Rows.Count; i++)
            {
                string QrcodeBD = gvDisScan.Rows[i].Cells["QRCodeBundle"].Value.ToString();
                string sd = gvDisScan.Rows[i].Cells["SD_ListDoc_No"].Value.ToString();
                string ClothingPart = gvDisScan.Rows[i].Cells["ClothingPart"].Value.ToString();
                string MainPart = gvDisScan.Rows[i].Cells["MainPart"].Value.ToString();
                string SO = gvDisScan.Rows[i].Cells["SO"].Value.ToString();
                string FabricType = gvDisScan.Rows[i].Cells["FabricType"].Value.ToString();
                string Decoration = dec; //gvDisScan.Rows[i].Cells["Deco"].Value.ToString();
                string Dec_Out_1 = Dec_Out;
                string Location = gvDisScan.Rows[i].Cells["Location"].Value.ToString(); // Replace with actual location if available
                string TimeScan = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // Or get it from the DataGridView if available
                int QTY = int.Parse(gvDisScan.Rows[i].Cells["QTY"].Value.ToString());
                string stINOUT = st_INOUT.ToString(); // Replace with actual stINOUT value if available sd
                string accept = "NULL";
                if (st_INOUT == 0) { accept = "0"; }
                if (!first)
                {
                    insertMultiValue = $"('{lbBillNo.Text}','{QrcodeBD}', '{Decoration}', '{Dec_Out_1}', '{Location}', '{TimeScan}', '{QTY}', '{stINOUT}', '{sd}', " +
                        $"'{ClothingPart}', '{MainPart}', '{SO}', '{FabricType}', '{accept}')";
                    first = true;
                }
                else
                {
                    insertMultiValue += $",('{lbBillNo.Text}','{QrcodeBD}', '{Decoration}', '{Dec_Out_1}', '{Location}', '{TimeScan}', '{QTY}', '{stINOUT}', '{sd}', " +
                         $"'{ClothingPart}', '{MainPart}', '{SO}', '{FabricType}', '{accept}')";
                }
            }
            if (insertMultiValue != "")
            {
                string delete_txt = string.Empty;

                if (_DeliveryNoteStatus)
                {
                    delete_txt = "DELETE FROM `a_b1_bundle_to_dec_tb` WHERE `DeliveryNoteID` = '" + lbBillNo.Text + "' ; ALTER TABLE `a_b1_bundle_to_dec_tb` auto_increment = 1; ";
                    ///ConnectMySQL.MysqlQuery(delete_txt +" ALTER TABLE `a_b1_bundle_to_dec_tb` auto_increment = 1;");
                }
                string sqlUpdate = "";
                if (st_INOUT == 1)
                {
                    HashSet<string> uniqueValues = new HashSet<string>();

                    // สมมุติว่าคุณต้องการดึงค่าจากคอลัมน์แรก (index 0) ของ DataGridView ชื่อ dgv1
                    foreach (DataGridViewRow row in gvDisScan.Rows)
                    {
                        if (row.Cells["DeliveryNoteID"].Value != null) // ตรวจสอบว่าไม่ใช่ค่า null
                        {
                            string value = row.Cells["DeliveryNoteID"].Value.ToString();
                            uniqueValues.Add(value); // HashSet จะเก็บเฉพาะค่าที่ไม่ซ้ำกัน
                        }
                    }

                    // แปลงเป็น List ถ้าคุณต้องการใช้งานในรูปแบบ List
                    List<string> resultList = uniqueValues.ToList();
                    string inClause = string.Join(",", resultList.Select(id => $"'{id}'"));

                    // สร้าง SQL command
                    sqlUpdate = $" UPDATE `a_b1_bundle_to_dec_tb` SET `ch_accept`='1' WHERE `DeliveryNoteID` IN ({inClause}); ";

                    //  string dn_id = gvDisScan.Rows[0].Cells["DeliveryNoteID"].Value.ToString();
                    // sqlUpdate = " UPDATE `a_b1_bundle_to_dec_tb` SET `ch_accept`='1' WHERE `DeliveryNoteID` LIKE '" + dn_id + "'; ";
                    // MessageBox.Show(sqlUpdate);
                }

                string sql = " INSERT INTO `a_b1_bundle_to_dec_tb` ( `DeliveryNoteID`, `QrcodeBD`, `Decoration`, `Dec_Out`, `Location`, `TimeScan`, `QTY`, " +
                    "`stINOUT`, `SD_ListDoc_No`, `ClothingPart`, `MainPart`, `SO`, `FabricType`,`ch_accept`) VALUES " + insertMultiValue + ";";
                bool success = ConnectMySQL.MysqlQuery(sqlUpdate + delete_txt + sql);

                if (success)
                {
                    for (int i = 0; i < gvDisScan.Rows.Count; i++)
                    {
                        gvDisScan.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    }
                    MessageBox.Show("Data inserted successfully!");

                    while (gvDisScan.Rows.Count > 0)
                    {
                        gvDisScan.Rows.RemoveAt(0);
                    }
                    DialogResult = DialogResult.OK;
                    lbBillNo.Text = "";
                }
                else
                {
                    MessageBox.Show("Error inserting data.");
                }
            }
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to clear all?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                while (gvDisScan.Rows.Count > 0)
                {
                    gvDisScan.Rows.RemoveAt(0);
                }
            }
        }
        public DataTable dtQRData = new DataTable();
        int rowsIndex = -1;
        private void btEdit_Click(object sender, EventArgs e)
        {
            if (rowsIndex > -1)
            {
                string QR = gvDisScan.Rows[rowsIndex].Cells["QRCodeBundle"].Value.ToString();
                string QQTY = gvDisScan.Rows[rowsIndex].Cells["QTY"].Value.ToString();

                string checkStartToSewingOrNot = ConnectMySQL.Subtext("SELECT  `sb_qrcodebundle` FROM `b_scaned_bundle` WHERE `sb_qrcodebundle` = '" + QR + "';");
                if (checkStartToSewingOrNot != QR)
                {
                    if (QQTY != "")
                    {
                        if (MessageBox.Show("Do you want to edit?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            HomePage.ins.Adjust_Show_Mode = false;
                            using (AdjustQTY_V2 di = new AdjustQTY_V2())
                            {
                                HomePage.ins.QRCODE_Adjust = QR;
                                HomePage.ins.departAdjustQTY = dec;
                                HomePage.ins.qtyDecreaseRef = int.Parse(QQTY);

                                foreach (DataGridViewColumn col in gvDisScan.Columns)
                                {
                                    dtQRData.Columns.Add(col.Name, typeof(string)); // ใช้ string หรือเปลี่ยนเป็น data type ตามจริง
                                }
                                // ตรวจสอบว่า DataGridView มีข้อมูลเพียงพอ

                                DataGridViewRow row = gvDisScan.Rows[rowsIndex]; // แถวที่ index = 1 (แถวที่สอง)

                                // สร้าง DataRow ใหม่และเพิ่มข้อมูลจาก DataGridView
                                DataRow dr = dtQRData.NewRow();
                                foreach (DataGridViewColumn col in gvDisScan.Columns)
                                {
                                    dr[col.Name] = row.Cells[col.Name].Value ?? DBNull.Value; // ป้องกันค่า NULL
                                }
                                dtQRData.Rows.Add(dr);

                                if (di.ShowDialog() == DialogResult.OK)
                                {
                                    gvDisScan.Rows[rowsIndex].Cells["QTY"].Value = int.Parse(gvDisScan.Rows[rowsIndex].Cells["QTY"].Value.ToString()) + HomePage.ins.qtyDecrease;
                                    gvDisScan.Rows[rowsIndex].DefaultCellStyle.BackColor = Color.Yellow;
                                    MessageBox.Show("OK");
                                    rowsIndex = -1;
                                }
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("Please check the QTY.");
                    }
                }
                else
                {
                    MessageBox.Show("Cannot decrease quantity because this bundle has already started sewing.");
                }
            }
            else { MessageBox.Show("Please click a row."); }
        }

        private void gvDisScan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                rowsIndex = e.RowIndex;
                // tbQTYEdit.Text = gvDisScan.Rows[e.RowIndex].Cells["QTY"].Value.ToString();
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (rowsIndex > -1)
            {
                if (MessageBox.Show("Do you want to delete?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    if (gvDisScan.Rows[rowsIndex].DefaultCellStyle.BackColor == Color.Yellow)
                    {
                        string QRCodeBundle = gvDisScan.Rows[rowsIndex].Cells["QRCodeBundle"].Value.ToString();
                        string sqlQueryDelete = "DELETE FROM `a_decrease_qty` WHERE `BD_QRCode_Ref` = (" + QRCodeBundle + ") AND `Decoration` = '" + dec + "'";
                        bool st = ConnectMySQL.MysqlQuery(sqlQueryDelete);
                        rowsIndex = -1;
                    }
                    gvDisScan.Rows.RemoveAt(rowsIndex);
                    MessageBox.Show("OK");
                }
            }
            else { MessageBox.Show("Please click a row."); }
        }

        private void tbScan_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                scan_fc();
            }
        }
        private void NewDNID()
        {
            string txtGroup = "";
            if (Properties.Settings.Default.workGroup != null)
            {
                txtGroup = Properties.Settings.Default.workGroup;
            }
            DateTimePicker dtpCreate = new DateTimePicker();
            dtpCreate.Value = DateTime.Now;
            string searchFil = "DN" + txtGroup.Substring(0, 1).ToUpper();
            lbBillNo.Text = Calculate.DocNoAutoGen(@"
                            SELECT `DeliveryNoteID` FROM `a_b1_bundle_to_dec_tb` WHERE `DeliveryNoteID`  LIKE 
                            '" + searchFil + "%'  ORDER BY `DeliveryNoteID` DESC LIMIT 1;",
                            searchFil, dtpCreate);
        }
        private void btNewDNID_Click(object sender, EventArgs e)

        { //SELECT `DeliveryNoteID` FROM `a_b1_bundle_to_dec_tb` WHERE `DeliveryNoteID`  LIKE 'DNM%' ORDER BY `SD_ListDoc_No` DESC LIMIT 1;

        }
        private void btnToggleClose1_Click(object sender, EventArgs e)
        {
            btnToggleClose1.Visible = false;
            //btnToggleOpen3.Visible = true;
            splitContainerMain.Panel1Collapsed = true;
        }
        private void btnToggleOpen3_Click(object sender, EventArgs e)
        {
            //btnToggleClose1.Visible = true; 
            btnToggleOpen3.Visible = false;
            splitContainerMain.Panel1Collapsed = false;
        }

        private void ScanInOutWithSummery_FormClosing(object sender, FormClosingEventArgs e)
        {

            string QRCodeList = "";

            for (int i = 0; i < gvDisScan.Rows.Count; i++)
            {
                if (gvDisScan.Rows[i].DefaultCellStyle.BackColor == Color.Yellow)
                {
                    var cellValue = gvDisScan.Rows[i].Cells["QRCodeBundle"].Value;
                    if (cellValue != null) // ตรวจสอบค่า NULL ก่อน
                    {
                        string qrCode = cellValue.ToString().Replace("'", "''"); // ป้องกัน SQL Injection (escape single quote)

                        if (QRCodeList == "")
                        {
                            QRCodeList = "'" + qrCode + "'";
                        }
                        else
                        {
                            QRCodeList += ", '" + qrCode + "'";
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(QRCodeList))
            {
                string sqlQueryDelete = "DELETE FROM `a_decrease_qty` WHERE `BD_QRCode_Ref` IN (" + QRCodeList + ") AND `Decoration` = '" + dec + "'";
                bool st = ConnectMySQL.MysqlQuery(sqlQueryDelete);

                if (st)
                {
                    // MessageBox.Show("Delete Decrease List finished");
                }
                else
                {

                }
            }
        }

        private void btConFirmDecrease_Click(object sender, EventArgs e)
        {
            if (rowsIndex != -1)
            {
                if (MessageBox.Show("Do you want to confirm the decrease status?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    gvDisScan.Rows[rowsIndex].DefaultCellStyle.BackColor = Color.Silver;
                    rowsIndex = -1;
                }
            }
        }

        private void cbUsedate_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            if (cbbDecoration.SelectedIndex > -1)
            {
                if (cbUsedate.Checked || tbSO.Text.Length > 0 || tbDN.Text.Length > 0)
                {

                    string dateSearch = "";
                    if (cbUsedate.Checked)
                    {
                        dateSearch = "DATE(`TimeScan`) = '" + setDate(dtpSearch1) + "' AND";
                    }

                    string mysqlSearch = @"SELECT DATE(`TimeScan`) AS DATE , `DeliveryNoteID`,`Decoration`,`Dec_Out`,`SO`,`Location`,`SD_ListDoc_No`
                                FROM `a_b1_bundle_to_dec_tb` WHERE " + dateSearch + @" `SO` LIKE '%" + tbSO.Text + @"%' AND 
                                `DeliveryNoteID` LIKE '%" + tbDN.Text + @"%' AND `stINOUT` = 0 AND `Decoration` LIKE '%" + cbbDecoration.Text + @"%'
                                AND `Location` LIKE '%" + cbbLocation.Text + @"%' 
                                GROUP BY  DATE, `DeliveryNoteID`  HAVING DeliveryNoteID IS NOT NULL;";

                    ConnectMySQL.DisplayAndSearch(mysqlSearch, gvDn);
                    if (gvDn.Rows.Count > 0)
                    {
                        foreach (DataGridViewColumn col in gvDn.Columns)
                        {
                            col.SortMode = DataGridViewColumnSortMode.NotSortable;
                        }

                    }

                }
                else
                {
                    MessageBox.Show("Please add text to textbox.", "Imfomation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please Select Decoration.", "Imfomation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private string setDate(Guna2DateTimePicker dtpDate)
        {
            string txtDate = "";
            System.Globalization.CultureInfo _cultureEnInfo = new System.Globalization.CultureInfo("en-US");
            DateTime date = Convert.ToDateTime(dtpDate.Value, _cultureEnInfo);
            txtDate = date.ToString("yyyy-MM-dd", _cultureEnInfo);
            return txtDate;
        }

        private void btEditDeliveryNote_Click(object sender, EventArgs e)
        {
            searchDaliveryNoteID();

        }
        int rowIndexgvDn = -1;
        private void gvDn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                rowIndexgvDn = e.RowIndex;
            }
        }
        private void searchDaliveryNoteID()
        {
            if (rowIndexgvDn > -1)
            {

                string DNID = gvDn.Rows[rowIndexgvDn].Cells["DeliveryNoteID"].Value.ToString();
                dec = gvDn.Rows[rowIndexgvDn].Cells["Decoration"].Value.ToString();
                Dec_Out = gvDn.Rows[rowIndexgvDn].Cells["Dec_Out"].Value.ToString();
                cbbLocation2.Text = gvDn.Rows[rowIndexgvDn].Cells["Location"].Value.ToString();
                Location = cbbLocation2.Text;
                lbBillNo.Text = DNID;
                string decrationSearch = "";
                if (cbbPartPrint.SelectedIndex == 0)
                {
                    decrationSearch = " AND a.MainPart=1 ";
                }

                string getDNdataSQL = @"SELECT a.QrcodeBD AS QRCodeBundle, a.SD_ListDoc_No, b.SO, b.BundleNo, s.Color, b.Size, 
                                        a.ClothingPart, b.QTY AS CUT_QTY, a.QTY, b.Deco,
                                            CASE  
                                            WHEN a.MainPart = 1 THEN '1'
                                            ELSE '0'
                                        END AS MainPart,
                                        a.FabricType, a.Decoration, 
                                        a.Location, 
                                        
                                        CASE  
                                            WHEN a.stINOUT = 1 THEN '1'
                                            ELSE '0'
                                        END AS stINOUT
                                        FROM a_b1_bundle_to_dec_tb a 
                                        LEFT JOIN a_b1_bundle_tb b ON b.QRCodeBundle = a.QrcodeBD 
                                        LEFT JOIN a_a1_spreading_list_tb s ON s.SD_ListDoc_No = a.SD_ListDoc_No 
                                        WHERE a.DeliveryNoteID LIKE '%" + DNID + "%' " + decrationSearch + " ORDER BY a.DeliveryNoteID, a.SD_ListDoc_No,s.Color,b.Size,b.BundleNo ASC;";
                ConnectMySQL.DisplayAndSearch(getDNdataSQL, gvDisScan);

                if (gvDisScan.Rows.Count > 0)
                {
                    if (gvDisColorSizeBreak.ColumnCount > 0)
                    {
                        for (int i = gvDisColorSizeBreak.Columns.Count - 1; i >= 0; i--)
                        {
                            gvDisColorSizeBreak.Columns.RemoveAt(i);
                        }
                    }

                    if (gvDisColorSizeBreak.Columns.Count == 0)
                    {
                        DataTable dt = new DataTable();
                        dt.Columns.Add("Spreading_No");
                        dt.Columns.Add("Colors");
                        dt.Columns.Add("Clothing_Part");

                        gvDisColorSizeBreak.DataSource = dt;

                    }
                    for (int y = 0; y < gvDisScan.Rows.Count; y++)
                    {
                        string sizee = gvDisScan.Rows[y].Cells["Size"].Value.ToString();
                        string sd_dbID = gvDisScan.Rows[y].Cells["SD_ListDoc_No"].Value.ToString();
                        string colors = gvDisScan.Rows[y].Cells["Color"].Value.ToString();
                        string Clothing_Part = gvDisScan.Rows[y].Cells["ClothingPart"].Value.ToString();
                        int QTY_gvScan = int.Parse(gvDisScan.Rows[y].Cells["QTY"].Value.ToString());

                        bool checkSize = false;
                        for (int k = 3; k < gvDisColorSizeBreak.Columns.Count; k++) //
                        {
                            string ssize = gvDisColorSizeBreak.Columns[k].Name;
                            if (sizee == ssize)
                            {
                                checkSize = true;
                            }
                        }
                        if (!checkSize)
                        {
                            DataTable dt = (DataTable)gvDisColorSizeBreak.DataSource;
                            dt.Columns.Add(sizee);
                            gvDisColorSizeBreak.DataSource = dt;

                        }
                        //-----------------------------------------------------------------------------------V--- Add Rows (SD,Colors,ClothingPart) ----
                        bool checkSD_color_Part = false;
                        for (int i = 0; i < gvDisColorSizeBreak.Rows.Count; i++)
                        {
                            string sdID = gvDisColorSizeBreak.Rows[i].Cells["Spreading_No"].Value.ToString();
                            string cc = gvDisColorSizeBreak.Rows[i].Cells["Colors"].Value.ToString();
                            string clotingPart = gvDisColorSizeBreak.Rows[i].Cells["Clothing_Part"].Value.ToString();

                            if (sdID == sd_dbID && colors == cc && Clothing_Part == clotingPart)
                            {
                                checkSD_color_Part = true;
                            }
                        }
                        if (!checkSD_color_Part)
                        {
                            DataTable dt = (DataTable)gvDisColorSizeBreak.DataSource;
                            dt.Rows.Add(sd_dbID, colors, Clothing_Part);
                            gvDisColorSizeBreak.DataSource = dt;

                        }
                        // --------------------------------------------------------------------------------------V--- Add Value QTY In table -----
                        for (int i = 0; i < gvDisColorSizeBreak.Rows.Count; i++)
                        {
                            string sdID = gvDisColorSizeBreak.Rows[i].Cells["Spreading_No"].Value.ToString();
                            string cc = gvDisColorSizeBreak.Rows[i].Cells["Colors"].Value.ToString();
                            string clotingPart = gvDisColorSizeBreak.Rows[i].Cells["Clothing_Part"].Value.ToString();

                            if (sdID == sd_dbID && colors == cc && Clothing_Part == clotingPart)
                            {
                                for (int j = 3; j < gvDisColorSizeBreak.Columns.Count; j++)
                                {
                                    string ssize = gvDisColorSizeBreak.Columns[j].Name;
                                    if (sizee == ssize)
                                    {
                                        string qqty = gvDisColorSizeBreak.Rows[i].Cells[j].Value.ToString();
                                        int intqqty = 0;
                                        if (qqty != "")
                                        {
                                            intqqty = int.Parse(qqty) + QTY_gvScan;
                                        }
                                        else
                                        {
                                            intqqty = QTY_gvScan;
                                        }

                                        gvDisColorSizeBreak.Rows[i].Cells[j].Value = intqqty;
                                    }
                                }
                            }
                        }
                        //---------------------------------------------------------------------------------------------------------

                    }
                    if (gvDisColorSizeBreak.Columns.Count > 0)
                    {
                        DataTable dt = (DataTable)gvDisColorSizeBreak.DataSource;
                        dt.Rows.Add("SUM");
                        gvDisColorSizeBreak.DataSource = dt;

                        foreach (DataGridViewColumn col in gvDisColorSizeBreak.Columns)
                        {
                            col.SortMode = DataGridViewColumnSortMode.NotSortable;
                        }
                        foreach (DataGridViewColumn col in gvDisScan.Columns)
                        {
                            col.SortMode = DataGridViewColumnSortMode.NotSortable;
                        }

                    }

                    for (int k = 3; k < gvDisColorSizeBreak.Columns.Count; k++)
                    {
                        int sumQty = 0;
                        for (int i = 0; i < gvDisColorSizeBreak.Rows.Count; i++)
                        {
                            string qtyinRow = gvDisColorSizeBreak.Rows[i].Cells[k].Value.ToString();
                            if (qtyinRow != "")
                            {
                                sumQty += int.Parse(qtyinRow);
                            }
                        }
                        // MessageBox.Show(sumQty.ToString());
                        gvDisColorSizeBreak.Rows[gvDisColorSizeBreak.RowCount - 1].Cells[k].Value = sumQty;
                    }
                    gvDisColorSizeBreak.Rows[gvDisColorSizeBreak.RowCount - 1].DefaultCellStyle.BackColor = Color.DeepSkyBlue;

                    gvDisColorSizeBreak.Columns.Add("Sum", "Sum");

                    for (int i = 0; i < gvDisColorSizeBreak.Rows.Count; i++)
                    {
                        int sumQty = 0;
                        for (int k = 3; k < gvDisColorSizeBreak.Columns.Count; k++)
                        {
                            if (gvDisColorSizeBreak.Rows[i].Cells[k].Value != null)
                            {
                                string qtyinRow = gvDisColorSizeBreak.Rows[i].Cells[k].Value.ToString();
                                if (qtyinRow != "")
                                {
                                    sumQty += int.Parse(qtyinRow);
                                }
                            }
                        }
                        // MessageBox.Show(sumQty.ToString());
                        gvDisColorSizeBreak.Rows[i].Cells[gvDisColorSizeBreak.ColumnCount - 1].Value = sumQty;
                    }
                    //gvDisColorSizeBreak.Rows[gvDisColorSizeBreak.RowCount - 1].Cells[gvDisColorSizeBreak.ColumnCount - 1].value= 
                    gvDisColorSizeBreak.Columns[gvDisColorSizeBreak.ColumnCount - 1].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                }
            }
            else
            {
                MessageBox.Show("Please click a row.");
            }
        }
        public string _so = "";
        public string _Style = "";
        private void btPrinter_Click(object sender, EventArgs e)
        {
            if (gvDisScan.Rows.Count > 0)
            {
                if (Properties.Settings.Default.Factory != "")
                {
                    // searchDaliveryNoteID();
                    appData2.Clear();
                    DNID = lbBillNo.Text;
                    _so = gvDisScan.Rows[0].Cells["SO"].Value.ToString();
                    Location = cbbLocation2.Text;
                    //_Style = gvDisScan.Rows[0].Cells["SO"].Value.ToString();

                    for (int i = 0; i < gvDisScan.Rows.Count; i++)
                    {

                        string QRCodeBundle = gvDisScan.Rows[i].Cells["QRCodeBundle"].Value.ToString();
                        string SD_ListDoc_No = gvDisScan.Rows[i].Cells["SD_ListDoc_No"].Value.ToString();
                        string Color = gvDisScan.Rows[i].Cells["Color"].Value.ToString();
                        string Size = gvDisScan.Rows[i].Cells["Size"].Value.ToString();
                        string ClothingPart = gvDisScan.Rows[i].Cells["ClothingPart"].Value.ToString();
                        string BundleNo = gvDisScan.Rows[i].Cells["BundleNo"].Value.ToString();
                        string QTY = gvDisScan.Rows[i].Cells["QTY"].Value.ToString();
                        appData2.BD_DN_tb.AddBD_DN_tbRow(QRCodeBundle, SD_ListDoc_No, Color, Size, ClothingPart, BundleNo, QTY);
                        // }
                    }

                    for (int i = 0; i < gvDisColorSizeBreak.Rows.Count; i++)
                    {
                        for (int j = 3; j < gvDisColorSizeBreak.Columns.Count; j++)
                        {
                            string sd = gvDisColorSizeBreak.Rows[i].Cells[0].Value.ToString();
                            string color = gvDisColorSizeBreak.Rows[i].Cells[1].Value.ToString();
                            string Part = gvDisColorSizeBreak.Rows[i].Cells[2].Value.ToString();
                            string ColumnName = gvDisColorSizeBreak.Columns[j].HeaderText;
                            int RowId = gvDisColorSizeBreak.Rows.IndexOf(gvDisColorSizeBreak.Rows[i]);
                            string Value = gvDisColorSizeBreak.Rows[i].Cells[j].Value.ToString();
                            appData2.BD_DN_Sumtb.AddBD_DN_SumtbRow(ColumnName, RowId, Value, sd, color, Part);
                        }
                    }
                    using (Delivery_NotePrivew pf = new Delivery_NotePrivew(appData2.BD_DN_tb, appData2.BD_DN_Sumtb))
                    {
                        pf.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Please select a factory before printing.");
                }
            }
            else
            {
                MessageBox.Show("Please select Delivery_Note", "Imfomation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cbbDecoration_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvDisScan.DataSource = null;
            gvDn.DataSource = null;

            DataTable dtLocation = ConnectMySQL.MySQLtoDataTable("SELECT `Location` FROM `location_tb` WHERE `LocationGroup` LIKE '" + cbbDecoration.Text + "';");
            cbbLocation.Items.Clear();
            for (int i = 0; i < dtLocation.Rows.Count; i++)
            {
                cbbLocation.Items.Add(dtLocation.Rows[i]["Location"].ToString());
            }

        }

        private void dtpSearch1_ValueChanged(object sender, EventArgs e)
        {
            cbUsedate.Checked = true;
        }

        private void cbbLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbLocation.SelectedIndex > -1)
            {

            }
        }

        private void btRefreash_Click(object sender, EventArgs e)
        {
            cbbLocation.SelectedIndex = -1;
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void btcleargv_Click(object sender, EventArgs e)
        {
            if (gvDisAllOfGroup.Rows.Count > 0)
            {
                for (int i = 0; i < gvDisAllOfGroup.Rows.Count; i++)
                {
                    var gvAll = gvDisAllOfGroup.Rows[i];
                    for (int j = 0; j < gvDisScan.Rows.Count; j++)
                    {
                        var gvScan = gvDisScan.Rows[j];

                        if (gvAll.Cells["QR"].Value.ToString() == gvScan.Cells["QRCodeBundle"].Value.ToString())
                        {
                            gvDisScan.Rows.RemoveAt(j);
                        }
                    }
                }


                for (int i = gvDisAllOfGroup.Columns.Count - 1; i >= 0; i--)
                {
                    gvDisAllOfGroup.Columns.RemoveAt(i);
                }
            }
        }
        public string DN_ID = "";
        private void btTransactions_Click(object sender, EventArgs e)
        {
            DN_ID = "";
            DN_detail dN_Detail = new DN_detail();
            dN_Detail.Show();
        }
    }

}
