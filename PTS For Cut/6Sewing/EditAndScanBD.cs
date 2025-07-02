using PTS_For_Cut.Myclass;
using System.Data;

namespace PTS_For_Cut._6Sewing
{
    public partial class EditAndScanBD : Form
    {
        public EditAndScanBD()
        {
            InitializeComponent();
        }

        private void EditAndScanBD_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void LoadForm()
        {
            dtpDate.Value = DateTime.Now;
            dtpTime.Value = DateTime.Now;
            if (SewingReport.ins.BundleEditMode == "scan")
            {
                pnScan.Visible = true;
                pnScan.Dock = DockStyle.Fill;
                pnSD.Visible = false;
                pnSD.Dock = DockStyle.None;
                lbEditAndScan.Text = "Bundle Scan Out";
                lbBDid.Text = "Bundle QRCode";
                ConnectMySQL.DisplayAndSearch("SELECT `a`.`sb_id`, `a`.`sb_qrcodebundle`AS `QRCode Bundle`, `a`.`sb_bundleno`AS `Bundle No`, `a`.`sb_color`AS `Color`, `a`.`sb_size`AS `Size`, " +
                    "`b`.`QTY`AS `CUT QTY` , `a`.`sb_qty`AS `SEW QTY`, `a`.`sb_lineno`AS `Line` , `a`.`sb_scantime` AS `Time` " +
                    "FROM `b_scaned_bundle` AS `a` JOIN `a_b1_bundle_tb` AS `b` ON `b`.`QRCodeBundle`= `a`.`sb_qrcodebundle` " +
                    "WHERE `a`.`sb_qrcodebundle` LIKE '" + SewingReport.ins.BundleID + "' ORDER BY `a`.`sb_id` ASC;", gvScan);
                if (gvScan.Rows.Count == 0)
                {
                    tbQtyCut.Text = SewingReport.ins.BundleQtyCross;
                    tbQtyOut.Text = tbQtyCut.Text;
                }
                else
                {
                    tbQtyCut.Text = gvScan.Rows[0].Cells["CUT QTY"].Value.ToString();
                    int outt = 0;
                    for (int i = 0; i < gvScan.Rows.Count; i++)
                    {
                        gvScan.Rows[i].Cells["CUT QTY"].Value = DBNull.Value;
                        outt += int.Parse(gvScan.Rows[i].Cells["SEW QTY"].Value.ToString());
                    }
                    tbQtyOut.Text = (int.Parse(tbQtyCut.Text) - outt).ToString();
                }
                tbBundleID.Text = SewingReport.ins.BundleID;

                DataTable dt = new DataTable();
                dt = Login.ins.Line_dt;
                cbbLine.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["Department"].ToString() == "Sewing")
                    {
                        cbbLine.Items.Add(dt.Rows[i]["Line"].ToString());
                    }
                }
            }
            else if (SewingReport.ins.BundleEditMode == "edit")
            {
                pnScan.Visible = true;
                pnScan.Dock = DockStyle.Fill;
                pnSD.Visible = false;
                pnSD.Dock = DockStyle.None;
                lbBDid.Text = "Bundle ID";
                lbEditAndScan.Text = "Bundle Edit";
                DataTable dtEdit = ConnectMySQL.MySQLtoDataTable("SELECT `a`.`sb_id`,  `a`.`sb_qrcodebundle`AS `QRCode Bundle`, `a`.`sb_bundleno`AS `Bundle No`, `a`.`sb_color`AS `Color`, `a`.`sb_size`AS `Size`, " +
                   "`b`.`QTY`AS `CUT QTY` , `a`.`sb_qty`AS `SEW QTY`, `a`.`sb_lineno` AS `Line` , `a`.`sb_scantime` AS `Time`" +
                   "FROM `b_scaned_bundle` AS `a` JOIN `a_b1_bundle_tb` AS `b` ON `b`.`QRCodeBundle`= `a`.`sb_qrcodebundle` " +
                   "WHERE `a`.`sb_qrcodebundle` LIKE '" + SewingReport.ins.BundleID + "' ORDER BY `a`.`sb_id` ASC;");
                gvScan.DataSource = dtEdit;
                if (gvScan.Rows.Count == 0)
                {
                    MessageBox.Show("Don't Have Data.");
                    this.Close();
                }
                else if (gvScan.Rows.Count > 0)
                {
                    tbQtyCut.Text = gvScan.Rows[0].Cells["CUT QTY"].Value.ToString();

                    for (int i = 0; i < gvScan.Rows.Count; i++)
                    {
                        gvScan.Rows[i].Cells["CUT QTY"].Value = DBNull.Value;

                    }

                }


                DataTable dt = new DataTable();
                dt = Login.ins.Line_dt;
                cbbLine.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["Department"].ToString() == "Sewing")
                    {
                        cbbLine.Items.Add(dt.Rows[i]["Line"].ToString());
                    }
                }

            }
            else if (SewingReport.ins.BundleEditMode == "checkBundleinSD")
            {
                pnScan.Visible = false;
                pnScan.Dock = DockStyle.None;
                pnSD.Visible = true;
                pnSD.Dock = DockStyle.Fill;
                ConnectMySQL.DisplayAndSearch("SELECT `Bundle_ID`, `QRCodeBundle`, `SD_ListDoc_No` AS `Spreading Document`, `BundleNo`, `Color`, `Size`, `QTY` FROM `a_b1_bundle_tb` WHERE `SD_ListDoc_No`='" + SewingReport.ins.BundleID + "'AND `MainPart`=1;", gvCut);
                ConnectMySQL.DisplayAndSearch("SELECT `sb_id`, `sb_qrcodebundle`AS `QRCode Bundle` , `sb_sdlistdocno`AS `Spreading Document`, `sb_bundleno`AS `Bundle No`, `sb_color`AS `Color`, `sb_size`AS `Size`, `sb_qty`AS `QTY`, `sb_lineno`AS `Line`, `Operator`, `sb_scantime` FROM `b_scaned_bundle` WHERE `sb_sdlistdocno`LIKE '" + SewingReport.ins.BundleID + "'", gvSew);
            }
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            if (cbbLine.SelectedIndex > -1 && tbQtyOut.Text.Length > 0 && int.Parse(tbQtyOut.Text) > 0)
            {

                string DateST = setDate(dtpDate, dtpTime);

                if (SewingReport.ins.BundleEditMode == "scan")
                {
                    if (cbbLine.SelectedIndex > -1)
                    {
                        bool checkBeforeSave = false;

                        if (gvScan.RowCount == 0)
                        {
                            if (int.Parse(tbQtyOut.Text) > int.Parse(tbQtyCut.Text))
                            {
                                checkBeforeSave = true;
                            }
                        }
                        else
                        {
                            int qtyOut = 0;
                            for (int i = 0; i < gvScan.Rows.Count; i++)
                            {
                                if (gvScan.Rows[i].Cells["SEW QTY"].Value.ToString() != "")
                                {
                                    qtyOut += int.Parse(gvScan.Rows[i].Cells["SEW QTY"].Value.ToString());
                                }
                            }
                            qtyOut = qtyOut + int.Parse(tbQtyOut.Text);
                            if (qtyOut > int.Parse(tbQtyCut.Text))
                            {
                                checkBeforeSave = true;
                            }
                        }

                        if (!checkBeforeSave)
                        {
                            if (MessageBox.Show("Are you sure you want to save data?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                bool st = ConnectMySQL.MysqlQuery("INSERT INTO `b_scaned_bundle`(`sb_id`, `sb_qrcodebundle`, `sb_sdlistdocno`, `sb_bundleno`," +
                                    " `sb_color`, `sb_size`, `sb_qty` ,`sb_lineno`, `sb_scantime`,`Operator`) " +
                                      "SELECT NULL, `QRCodeBundle`, `SD_ListDoc_No`, `BundleNo`, `Color`, `Size`, '" + tbQtyOut.Text + "','" + cbbLine.Text + "'," +
                                      "'" + DateST + "','" + Login.ins.empID + "' FROM `a_b1_bundle_tb` WHERE `QRCodeBundle` LIKE '" + tbBundleID.Text + "'");
                                if (st)
                                {
                                    LoadForm();
                                    MessageBox.Show("OK");
                                }
                                else
                                {
                                    // MessageBox.Show("... Can Not Save ...");
                                    MessageBox.Show("Can Don't Save: ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Sew QTY Over Cut QTY Can Not Save.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select Line");
                    }
                }
                else if (SewingReport.ins.BundleEditMode == "edit")
                {
                    if (cbbLine.SelectedIndex > -1)
                    {
                        bool checkBeforeSave = false;

                        int qtyOut = 0;
                        for (int i = 0; i < gvScan.Rows.Count; i++)
                        {
                            if (gvScan.Rows[i].Cells["SEW QTY"].Value.ToString() != "" && gvScan.Rows[i].Cells["sb_id"].Value.ToString() != tbBundleID.Text)
                            {
                                qtyOut += int.Parse(gvScan.Rows[i].Cells["SEW QTY"].Value.ToString());
                            }
                        }
                        qtyOut = qtyOut + int.Parse(tbQtyOut.Text);
                        if (qtyOut > int.Parse(tbQtyCut.Text))
                        {
                            checkBeforeSave = true;
                        }
                        if (!checkBeforeSave)
                        {
                            if (MessageBox.Show("Are you sure you want to update data?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                bool st = ConnectMySQL.MysqlQuery("UPDATE `b_scaned_bundle` SET `sb_qty`='" + tbQtyOut.Text + "',`sb_lineno`='" + cbbLine.Text + "'," +
                                    "`sb_scantime`='" + DateST + "' , `Operator`='" + Login.ins.empID + "' WHERE `sb_id`='" + tbBundleID.Text + "'");
                                if (st)
                                {
                                    LoadForm();

                                    MessageBox.Show("OK");
                                }
                                else
                                {
                                    MessageBox.Show("... Can Not Update ...");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Sew QTY Over Cut QTY Can Not Save.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select Line");
                    }
                }


            }
            else
            {
                MessageBox.Show("Please Check Data");
            }
        }
        private string setDate(DateTimePicker dtpDate, DateTimePicker dtpTime)
        {
            string txtDate = "", txtTime = "";
            System.Globalization.CultureInfo _cultureEnInfo = new System.Globalization.CultureInfo("en-US");
            DateTime date = Convert.ToDateTime(dtpDate.Value, _cultureEnInfo);
            DateTime time = Convert.ToDateTime(dtpTime.Value, _cultureEnInfo);
            txtDate = date.ToString("yyyy-MM-dd", _cultureEnInfo);
            txtTime = time.ToString("HH:mm:ss", _cultureEnInfo);
            return txtDate + " " + txtTime + ".000000";
        }

        private void tbQtyOut_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void gvScan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (SewingReport.ins.BundleEditMode == "edit")
                {
                    // SELECT `a`.`sb_id`, `a`.`sb_qrcodebundle`, `a`.`sb_bundleno`, `a`.`sb_color`, `a`.`sb_size`, " +
                    //"`b`.`QTY`AS `CUT QTY` , `a`.`sb_qty`AS `SEW QTY`, `a`.`sb_lineno`, `a`.`sb_scantime` 

                    tbBundleID.Text = gvScan.Rows[e.RowIndex].Cells["sb_id"].Value.ToString();
                    tbQtyOut.Text = gvScan.Rows[e.RowIndex].Cells["SEW QTY"].Value.ToString();
                    cbbLine.Text = gvScan.Rows[e.RowIndex].Cells["Line"].Value.ToString();

                }
            }
        }

        private void tbQtyOut_Click(object sender, EventArgs e)
        {

        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete data", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool st = ConnectMySQL.MysqlQuery("DELETE FROM `b_scaned_bundle` WHERE `sb_id`='" + tbBundleID.Text + "'");
                if (st)
                {
                    MessageBox.Show("OK");
                }
                else
                {
                    MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
