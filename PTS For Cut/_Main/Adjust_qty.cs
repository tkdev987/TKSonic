using PTS_For_Cut.myClass;
using PTS_For_Cut.Myclass;
using System.Data;

namespace PTS_For_Cut._Main
{
    public partial class Adjust_qty : Form
    {
        public Adjust_qty()
        {
            InitializeComponent();
        }

        private void Adjust_qty_Load(object sender, EventArgs e)
        {
            cbbAdjust.SelectedIndex = 0;
            Group_work = Properties.Settings.Default.workGroup;
            DataTable dtLine = new DataTable();
            dtLine = Login.ins.Line_dt;
            cbbLine.Items.Clear();
            for (int i = 0; i < dtLine.Rows.Count; i++)
            {
                cbbLine.Items.Add(dtLine.Rows[i]["Line"].ToString());
            }
            cbbDec.Items.Clear();
            for (int i = 0; i < Login.ins.dtDecoration.Rows.Count; i++)
            {
                cbbDec.Items.Add(Login.ins.dtDecoration.Rows[i]["Dec_Eng"].ToString());
            }

            //if (HomePage.ins.adjustQTYBD != string.Empty)
            //{
            //    string func_Dec = HomePage.ins.adjustQTYBD;
            //    string funcWorking = func_Dec.Substring(0, 3);
            //    string checkDec = func_Dec.Substring(4, func_Dec.Length - 4);
            //    if (funcWorking == "dec")
            //    {
            //        cbbAdjust.SelectedIndex = 0;

            //    }
            //    else if (funcWorking == "inc")
            //    {
            //        cbbAdjust.SelectedIndex = 1;
            //    }
            //    else
            //    {
            //        MessageBox.Show("Error Adjust Mode", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }

            //    if (checkDec != "")
            //    {
            //        cbbDec.Text = checkDec;
            //    }
            //    else
            //    {
            //        MessageBox.Show("Error Decoration Mode", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}


        }

        private void cbbAdjust_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbAdjust.SelectedIndex == 0)//Decrease
            {
                lbSO.Visible = false;
                tbSO.Visible = false;
                lbLine.Visible = false;
                cbbLine.Visible = false;
                lbSize.Visible = false;
                cbbSize.Visible = false;

                tbQRCode.Visible = true;
                lbScan.Visible = true;
                tbBundleNo.Visible = true;
                lbBundleNo.Visible = true;


            }
            else if (cbbAdjust.SelectedIndex == 1) // Increase
            {
                tbQRCode.Visible = false;
                lbScan.Visible = false;
                lbBundleNo.Visible = false;
                tbBundleNo.Visible = false;


                lbSO.Visible = true;
                tbSO.Visible = true;
                lbLine.Visible = true;
                cbbLine.Visible = true;
                lbSize.Visible = true;
                cbbSize.Visible = true;


            }
        }
        string Group_work = "";
        private void btSave1_Click(object sender, EventArgs e)
        {
            if (cbbDec.SelectedIndex > -1)
            {

                if (tbQty.Text != "" && tbRemark.Text != "" && lbQRRef.Text != "")
                {

                    if (cbbAdjust.SelectedIndex == 0)
                    {

                        int QTYAdj = int.Parse(gvDis.Rows[0].Cells["QTY"].Value.ToString()) - int.Parse(tbQty.Text);
                        string SD_ListDoc = gvDis.Rows[0].Cells["SD_ListDoc_No"].Value.ToString();
                        string so = gvDis.Rows[0].Cells["SO"].Value.ToString();
                        string delete = "DELETE FROM `a_decrease_qty` WHERE `BD_QRCode_Ref` = '" + lbQRRef.Text +
                                                                   "' AND `Decoration`='" + cbbDec.Text + "'; ";
                        string txtInsert = " INSERT INTO `a_decrease_qty`(`id`, `Decoration`, `BD_QRCode_Ref`, `QTY`, `userID`," +
                            "  `SD_ListDoc_No`, `SO`, `Remark`,`BundleNo`)" +
                            " VALUES (NULL,'" + cbbDec.Text + "','" + lbQRRef.Text + "','" + tbQty.Text + "','" + Login.ins.empID + "'," +
                            "'" + SD_ListDoc + "','" + so + "','" + tbRemark.Text + "','" + tbBundleNo.Text + "')";
                        bool st = ConnectMySQL.MysqlQuery(delete + txtInsert);
                        if (st)
                        {
                            MessageBox.Show("Ok");
                            reset();
                        }
                        else
                        {
                            MessageBox.Show("Can't Not Insert Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    if (cbbAdjust.SelectedIndex == 1 && rowIndexx > -1 && cbbSize.SelectedIndex > -1 && cbbLine.SelectedIndex > -1)
                    {
                        DateTimePicker dtpCreate = new DateTimePicker();
                        dtpCreate.Value = DateTime.Now;
                        string group = Group_work.Substring(0, 1).ToUpper();
                        string startCode = "AJ";
                        string searchFil = startCode + group;
                        string txtGen = "SELECT `sb_qrcodebundle`  FROM `b_scaned_bundle` WHERE `sb_qrcodebundle`LIKE '" + searchFil + "%'  ORDER BY `sb_qrcodebundle` DESC LIMIT 1;";
                        string QrCodeBundle = Calculate.DocNoAutoGen(txtGen, startCode + group, dtpCreate);
                        string SD_ListDoc = gvDis.Rows[rowIndexx].Cells["SD_ListDoc_No"].Value.ToString();

                        string so = gvDis.Rows[rowIndexx].Cells["SO"].Value.ToString();
                        string color = gvDis.Rows[rowIndexx].Cells["Color"].Value.ToString();


                        string txtInsert = "INSERT INTO `b_scaned_bundle`(`sb_id`, `sb_qrcodebundle`, `sb_sdlistdocno`, " +
                            "`sb_bundleno`, `sb_color`, `sb_size`, `sb_clothingpart`, `sb_plies`, `sb_qty`, `sb_deco`, " +
                            "`sb_lineno`, `SupCh`, `FinalCh`, `Operator`, `sb_scantime`, `SO`, `rft_status`, `Remark`)" +
                            " VALUES (NULL,'" + QrCodeBundle + "','" + SD_ListDoc + "','','" + color + "','" + cbbSize.Text + "'," +
                            "'','','" + tbQty.Text + "','','" + cbbLine.Text + "','','','" + Login.ins.empID + "',CURRENT_TIMESTAMP(),'" + so + "','','" + tbRemark.Text + "')";

                        bool st = ConnectMySQL.MysqlQuery(txtInsert);
                        if (st)
                        {
                            MessageBox.Show("Ok");
                            reset();
                        }
                        else
                        {
                            MessageBox.Show("Can't Not Insert Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("---Please Check Data Before Save.---", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please Check Data Before Save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void reset()
        {
            rowIndexx = -1;
            lbQRRef.Text = "";
            cbbDec.SelectedIndex = -1;
            tbQRCode.Text = "";
            tbSO.Text = "";
            gvDis.DataSource = null;
            tbRemark.Text = "";
            cbbLine.SelectedIndex = -1;
            cbbSize.SelectedIndex = -1;
        }
        int rowIndexx = -1;
        private void gvDis_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && cbbAdjust.SelectedIndex == 1)
            {
                rowIndexx = e.RowIndex;
                lbQRRef.Text = gvDis.Rows[e.RowIndex].Cells["SD_ListDoc_No"].Value.ToString();

                string txtsql = "SELECT DISTINCT(`Size`) AS `Size` FROM `a_b1_bundle_tb` WHERE `SD_ListDoc_No` LIKE '" + lbQRRef.Text + "';";
                DataTable dtSize = ConnectMySQL.MySQLtoDataTable(txtsql);
                cbbSize.Items.Clear();
                for (int i = 0; i < dtSize.Rows.Count; i++)
                {
                    cbbSize.Items.Add(dtSize.Rows[i]["Size"].ToString());
                }
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            if (cbbDec.SelectedIndex > -1 && cbbAdjust.SelectedIndex == 0 && tbQRCode.Text != "")
            {
                string txtSql = @"WITH Filtered AS (
                                        SELECT `SD_ListDoc_No`, `BundleNo`
                                        FROM `a_b1_bundle_tb`
                                        WHERE `QRCodeBundle` LIKE '" + tbQRCode.Text + @"'
                                        LIMIT 1
                                    )
                                    SELECT
                                        a.`QRCodeBundle`,
                                        a.`SD_ListDoc_No`,
                                        a.`SO`,
                                        a.`BundleNo`,
                                        (a.QTY - IFNULL(d.QTY, 0)) AS QTY,  
                                        IFNULL(d.QTY, 0) AS DecreaseQTY  
                                    FROM `a_b1_bundle_tb` a
                                    JOIN Filtered f
                                        ON a.`SD_ListDoc_No` = f.`SD_ListDoc_No`
                                        AND a.`BundleNo` = f.`BundleNo` 
                                    LEFT JOIN `a_decrease_qty` d
                                        ON a.`QRCodeBundle` = d.BD_QRCode_Ref AND d.`Decoration`= '" + cbbDec.Text + @"'
                                    WHERE a.`MainPart` = 1;";
                ConnectMySQL.DisplayAndSearch(txtSql, gvDis);
                if (gvDis.Rows.Count > 0)
                {
                    var gv = gvDis.Rows[0];
                    lbQRRef.Text = gv.Cells["QRCodeBundle"].Value.ToString();
                    tbBundleNo.Text = gv.Cells["BundleNo"].Value.ToString();
                    tbQty.Text = gv.Cells["DecreaseQTY"].Value.ToString();
                }

            }
            else if (cbbDec.SelectedIndex > -1 && cbbAdjust.SelectedIndex == 1 && tbSO.Text != "")
            {
                string txt = @"SELECT `a`.`SD_ListDoc_No`,`a`.`Color`,`a`.`SO`  
                        FROM `a_a1_spreading_list_tb` AS `a`
                        JOIN  `a_a3_scandoc_sd_ct_tb` AS `b` ON `b`.`SD_ListDoc_No`=`a`.`SD_ListDoc_No` AND `b`.`Cut_ScanOut`!='0000-00-00 00:00:00.000000'
                        WHERE `a`.`SO` LIKE '" + tbSO.Text + @"' AND `a`.`FabricType` LIKE 'A' AND `a`.`SD_Status`='1'
                        ORDER BY `a`.`SD_ListDoc_No`";

                ConnectMySQL.DisplayAndSearch(txt, gvDis);
            }
        }

        private void btAddRef_Click(object sender, EventArgs e)
        {
            //if(tbQRCode.Text != "" || tbSO.Text != "")
            //{
            //    if(cbbAdjust.SelectedIndex == 0) 
            //    {
            //        lbQRRef.Text = gvDis.Rows[0].Cells["SD_ListDoc_No"].Value.ToString();

            //    }else if(cbbAdjust.SelectedIndex == 1)
            //    {
            //        lbQRRef.Text = gvDis.Rows[0].Cells["SD_ListDoc_No"].Value.ToString();
            //    }
            //}
        }

        private void btSearchSD_Click(object sender, EventArgs e)
        {
            refreshSD();
        }

        private void refreshSD()
        {
            if (tbSDID.Text.Length > 0)
            {
                string sqltxt = @"SELECT `BD_QRCode_Ref`, `QTY`,`BundleNo`,`Decoration` 
                                FROM `a_decrease_qty` WHERE `SD_ListDoc_No` ='" + tbSDID.Text + "' AND `Decoration`='" + cbbDec.Text + "'";
                ConnectMySQL.DisplayAndSearch(sqltxt, gvDisSD);
            }
        }
        int rowSDIndex = -1;
        private void gvDisSD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                rowSDIndex = e.RowIndex;
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {

            if (rowSDIndex > -1)
            {
                string BD = gvDisSD.Rows[rowSDIndex].Cells["BD_QRCode_Ref"].Value.ToString();
                bool st = ConnectMySQL.MysqlQuery("DELETE FROM `a_decrease_qty` WHERE `BD_QRCode_Ref` ='" + BD + "' AND `Decoration`='" + cbbDec.Text + "'");
                if (st)
                {
                    MessageBox.Show("OK");
                    refreshSD();
                }
                else
                {
                    MessageBox.Show("Can't Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tbQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            //bool isEmpty = tbQty.Text.Length == 0;

            //// อนุญาตเฉพาะตัวเลข (0-9), + และ -
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+' && e.KeyChar != '-')
            //{
            //    e.Handled = true; // ป้องกันอักขระที่ไม่ต้องการ
            //}

            //// ถ้าช่องว่าง ต้องเป็น + หรือ - เท่านั้น
            //if (isEmpty && (e.KeyChar != '+' && e.KeyChar != '-'))
            //{
            //    e.Handled = true;
            //}

            //// ถ้าไม่ใช่ช่องว่าง (พิมพ์อะไรมาแล้ว) ห้ามพิมพ์ + หรือ - ซ้ำ
            //if (!isEmpty && (e.KeyChar == '+' || e.KeyChar == '-'))
            //{
            //    e.Handled = true;
            //}
        }
    }
}
