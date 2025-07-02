using Guna.UI2.WinForms;
using PTS_For_Cut.Main;
using PTS_For_Cut.Myclass;

namespace PTS_For_Cut._6Sewing
{
    public partial class SewingReport : Form
    {
        public static SewingReport ins;
        public SewingReport()
        {
            InitializeComponent();
            ins = this;
        }

        private void btbundleSearch_Click(object sender, EventArgs e)
        {

        }

        private void btSpreadingSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
        private void tbSpreadingSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }

        }
        private void Search()
        {
            if (tbBundleSearch.Text != "")
            {
                if (confirmMode != "")
                {

                    string searchText = tbBundleSearch.Text;

                    if (!string.IsNullOrEmpty(searchText))
                    {
                        if (searchText.Length > 2)
                        {
                            //gvSD.ClearSelection();
                            //int indexRow = -1;
                            //for (int i = 0; i < gvSD.Rows.Count; i++)
                            //{
                            //    if (gvSD.Rows[i].Selected)
                            //    {
                            //        gvSD.Rows[i].Selected = false;

                            //    }
                            //    if (gvSD.Rows[i].Cells["QRCodeBundle"].Value != null && gvSD.Rows[i].Cells["QRCodeBundle"].Value.ToString().Contains(searchText))
                            //    {
                            //        gvSD.Rows[i].Selected = true;
                            //        gvSD.SelectionMode = DataGridViewSelectionMode.CellSelect;
                            //        indexRow = i;
                            //        break;
                            //    }
                            //    else
                            //    {
                            //        gvSD.Rows[i].Selected = false;
                            //    }
                            //}
                            // MessageBox.Show(indexRow.ToString());
                            //if (indexRow > -1)
                            //{
                            using (CheckConfirmBD confirm = new CheckConfirmBD())
                            {
                                BundleNo = tbBundleSearch.Text;
                                DateOnly = SetTimeA(dtpStart);
                                if (confirm.ShowDialog() == DialogResult.OK)
                                {
                                    tbBundleSearch.Text = "";
                                    tbBundleSearch.Focus();
                                    // MessageBox.Show(RowindexLine.ToString());
                                    searchDundleInLine();
                                }
                            }
                            //}
                            //else
                            //{
                            //    MessageBox.Show("Don't Have Data in This Table");
                            //}
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Confirm Mode.");
                }
            }

        }
        private void countAndChangcolor()
        {
            if (gvSD.Rows.Count > 0)
            {
                int cut = 0;
                int sew = 0;
                for (int i = 0; i < gvSD.Rows.Count; i++)
                {
                    int cutQty = int.Parse(gvSD.Rows[i].Cells["Cut QTY"].Value.ToString());
                    int sewQty = int.Parse(gvSD.Rows[i].Cells["Sew QTY"].Value.ToString());
                    cut += cutQty;
                    sew += sewQty;
                    if (cutQty > sewQty)
                    {
                        gvSD.Rows[i].Cells["Sew QTY"].Style.ForeColor = Color.Red;//SelectionForeColor = Color.Red;
                        gvSD.Rows[i].Cells["Sew QTY"].Style.SelectionForeColor = Color.Red;
                    }
                }
                //lbTotalCutQty.Text = cut.ToString();
                //lbSewQty.Text = sew.ToString();
            }
        }
        private void gvSD_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                //lbbdID.Text = gvSD.Rows[e.RowIndex].Cells["QRCodeBundle"].Value.ToString();
                //lbCutQty.Text = gvSD.Rows[e.RowIndex].Cells["Cut QTY"].Value.ToString();
                //tbSewEdit.Text = gvSD.Rows[e.RowIndex].Cells["Sew QTY"].Value.ToString();
            }
        }

        private void btSaveEdit_Click(object sender, EventArgs e)
        {
            //if (HomePage.ins.checkPermiss("rp_editQtySewScanOut"))
            //{
            //    if (chSewEdit && tbSewEdit.Text.Length > 0)
            //    {
            //        if (MessageBox.Show("Are you sure you want to save program?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //        {
            //            ConnectMySQL.MysqlQuery("UPDATE `b_scaned_bundle` SET `sb_qty`='" + tbSewEdit.Text + "' WHERE `sb_qrcodebundle`LIKE '" + lbbdID.Text + "';");
            //            Search();
            //            MessageBox.Show("OK");
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("This Account Don't Have Permission For This Function.");
            //}
        }
        bool chSewEdit = false;
        private void tbSewEdit_TextChanged(object sender, EventArgs e)
        {
            chSewEdit = true;
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            if (cbbSearchType.SelectedIndex == 0)
            {
                ConnectMySQL.DisplayAndSearch("SELECT   `c`.`SO`,SUM(`a`.`sb_qty`) AS `QTY`" +
                            "FROM `b_scaned_bundle` AS `a`" +
                            "JOIN `a_a1_spreading_list_tb` AS `c` ON `a`.`sb_sdlistdocno`=`c`.`SD_ListDoc_No` AND `c`.`FabricType` LIKE 'A' AND `c`.`SD_Status` LIKE '1' " +
                            "WHERE DATE(`a`.`sb_scantime`) = '" + SetTimeA(dtpStart) + "'" +
                            "GROUP BY `c`.`SO`;", gvDaily);

            }
            else if (cbbSearchType.SelectedIndex == 1)
            {
                ConnectMySQL.DisplayAndSearch("SELECT `a`.`sb_lineno` AS `LINE`,SUM(`a`.`sb_qty`) AS `QTY`" +
               "FROM `b_scaned_bundle` AS `a`" +
               "JOIN `a_a1_spreading_list_tb` AS `c` ON `a`.`sb_sdlistdocno`=`c`.`SD_ListDoc_No` AND `c`.`FabricType` LIKE 'A' AND `c`.`SD_Status` LIKE '1' " +
                "WHERE DATE(`a`.`sb_scantime`) = '" + SetTimeA(dtpStart) + "'" +
               "GROUP BY `a`.`sb_lineno`;", gvDaily);
            }

        }
        private string SetTimeA(Guna2DateTimePicker dtpVal)
        {
            string txtDate = "";
            System.Globalization.CultureInfo _cultureEnInfo = new System.Globalization.CultureInfo("en-US");
            DateTime dateEng = Convert.ToDateTime(dtpVal.Value, _cultureEnInfo);
            txtDate = dateEng.ToString("yyyy-MM-dd", _cultureEnInfo);
            return txtDate;
        }
        public string BundleNo = "";
        public string DateOnly = "";
        public string confirmMode = "";
        private void SewingReport_Load(object sender, EventArgs e)
        {
            cbbSearchType.SelectedIndex = 0;
            dtpStart.Value = DateTime.Now;
            // cbbTypeCh.SelectedIndex = 0;
        }
        int RowindexLine = -1;
        private void gvDaily_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (cbbSearchType.SelectedIndex == 1)
                {
                    RowindexLine = e.RowIndex;
                    searchDundleInLine();
                }
                else
                {
                    RowindexLine = -1;
                }
            }
        }
        private void searchDundleInLine()
        {
            if (RowindexLine > -1)
            {
                string line = gvDaily.Rows[RowindexLine].Cells["LINE"].Value.ToString();

                ConnectMySQL.DisplayAndSearch("SELECT `c`.`SO`,`a`.`sb_sdlistdocno` AS `Spreading ID`,`a`.`sb_qrcodebundle` AS `QRCodeBundle`," +
                    "(`a`.`sb_bundleno`) AS `Bundle No`,`a`.`sb_size` AS Size,SUM(`a`.`sb_qty`)AS `Sew QTY`,`a`.`SupCh` AS `Sup Check` ,`a`.`FinalCh` AS `Final Check`,`a`.`sb_scantime` AS `Scantime`" +
                    "FROM `b_scaned_bundle` AS `a` " +
                    "JOIN `a_a1_spreading_list_tb` AS `c` ON `c`.`SD_ListDoc_No`=`a`.`sb_sdlistdocno` AND `c`.`FabricType` LIKE 'A' AND `c`.`SD_Status` LIKE '1'" +
                    "WHERE `a`.`sb_lineno` LIKE '" + line + "' AND  DATE(`a`.`sb_scantime`) = '" + SetTimeA(dtpStart) + "'" +
                    "GROUP BY `a`.`sb_qrcodebundle` ORDER BY `c`.`SO`,`a`.`sb_sdlistdocno`,`a`.`sb_bundleno`;", gvSD);


                if (gvSD.RowCount > 0)
                {
                    int totalAll = 0;
                    int supcheckQty = 0;
                    int finalcheckQty = 0;
                    for (int i = 0; i < gvSD.RowCount; i++)
                    {
                        if (gvSD.Rows[i].Cells["Sew QTY"].Value.ToString() != "")
                        {
                            totalAll += int.Parse(gvSD.Rows[i].Cells["Sew QTY"].Value.ToString());
                            if (Convert.ToBoolean(gvSD.Rows[i].Cells["Sup Check"].Value.ToString()))
                            {
                                supcheckQty += int.Parse(gvSD.Rows[i].Cells["Sew QTY"].Value.ToString());
                            }
                            if (Convert.ToBoolean(gvSD.Rows[i].Cells["Final Check"].Value.ToString()))
                            {
                                finalcheckQty += int.Parse(gvSD.Rows[i].Cells["Sew QTY"].Value.ToString());
                            }
                        }
                    }
                    tbTotalqty.Text = totalAll.ToString();
                    tbSupcheck.Text = supcheckQty.ToString();
                    tbFinalcheck.Text = finalcheckQty.ToString();
                }
            }
            else
            {
                MessageBox.Show("Please Select Item.");
            }
        }
        private void btExcel_Click(object sender, EventArgs e)
        {
            if (gvDaily.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                xcelApp.Application.Workbooks.Add(Type.Missing);

                for (int i = 1; i < gvDaily.Columns.Count + 1; i++)
                {
                    xcelApp.Cells[1, i] = gvDaily.Columns[i - 1].HeaderText;

                }
                for (int i = 0; i < gvDaily.Rows.Count; i++)
                {
                    for (int j = 0; j < gvDaily.Columns.Count; j++)
                    {
                        if (gvDaily.Rows[i].Cells[j].Value != null)
                        {

                            xcelApp.Cells[i + 2, j + 1] = gvDaily.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }
                xcelApp.Columns.AutoFit();
                xcelApp.Visible = true;
            }
        }

        private void cbbTypeCh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbTypeCh.SelectedIndex == 0)
            {
                if (HomePage.ins.checkPermiss("bd_supCh"))
                {
                    confirmMode = "supCon";
                }
                else
                {
                    confirmMode = "";
                    cbbTypeCh.SelectedIndex = -1;
                    MessageBox.Show("This Account Don't Have Permission For This Function.");
                }
            }
            else if (cbbTypeCh.SelectedIndex == 1)
            {
                if (HomePage.ins.checkPermiss("bd_LastCh"))
                {
                    confirmMode = "LastCon";
                }
                else
                {
                    confirmMode = "";
                    cbbTypeCh.SelectedIndex = -1;
                    MessageBox.Show("This Account Don't Have Permission For This Function.");
                }
            }
        }
        public string BundleEditMode = "";
        public string BundleID = "";
        public string BundleQtyCross = "";
        private void btScan_Click(object sender, EventArgs e)
        {
            scan();
        }
        private void scan()
        {
            if (HomePage.ins.checkPermiss("bd_supEdit"))
            {
                if (tbScan.Text != "")
                {
                    string chBund = ConnectMySQL.Subtext("SELECT (`a`.`QTY`- IFNULL((SELECT SUM(`b`.`sb_qty`) FROM `b_scaned_bundle` AS `b` " +
                        "WHERE `a`.`QRCodeBundle` = `b`.`sb_qrcodebundle` GROUP BY `b`.`sb_qrcodebundle` ),0)) AS `Diff QTY` " +
                        "FROM `a_b1_bundle_tb` AS `a` WHERE `a`.`MainPart`=1 AND `a`.`QRCodeBundle`LIKE '" + tbScan.Text + "'");
                    if (chBund != "")
                    {

                        if (int.Parse(chBund) > 0)
                        {
                            BundleQtyCross = chBund;
                            BundleEditMode = "scan";
                            BundleID = tbScan.Text;
                            using (EditAndScanBD scan = new EditAndScanBD())
                            {
                                if (scan.ShowDialog() == DialogResult.OK)
                                {

                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("This Bundle Scan Finished.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Don't Have Data in Database");
                    }
                }
                else
                {
                    MessageBox.Show("Textbox is Empty.");
                }
            }
            else
            {
                MessageBox.Show("This Account Don't Have Permission For This Function.");
            }
        }
        private void btEdit_Click(object sender, EventArgs e)
        {
            edit();
        }
        private void edit()
        {
            if (HomePage.ins.checkPermiss("bd_supEdit"))
            {

                //edit
                if (tbBDEdit.Text != "")
                {               //getData()
                    BundleEditMode = "edit";
                    BundleID = tbBDEdit.Text;
                    using (EditAndScanBD scan = new EditAndScanBD())
                    {
                        if (scan.ShowDialog() == DialogResult.OK)
                        {

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Textbox is Empty.");
                }
            }
            else
            {
                MessageBox.Show("This Account Don't Have Permission For This Function.");
            }
        }
        private void btCheckSD_Click(object sender, EventArgs e)
        {
            //checkBundleinSD

        }
        private void checkSD()
        {
            if (btCheckSD.Text != "")
            {               //getData()
                BundleEditMode = "checkBundleinSD";
                BundleID = tbCheckSD.Text;
                using (EditAndScanBD scan = new EditAndScanBD())
                {
                    if (scan.ShowDialog() == DialogResult.OK)
                    {

                    }
                }
            }
            else
            {
                MessageBox.Show("Textbox is Empty.");
            }
        }
        private void tbScan_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                scan();
            }
        }

        private void tbBDEdit_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                edit();
            }
        }

        private void tbCheckSD_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                checkSD();
            }
        }

        private void btExcel2_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
            xcelApp.Application.Workbooks.Add(Type.Missing);

            for (int i = 1; i < gvSD.Columns.Count + 1; i++)
            {
                xcelApp.Cells[1, i] = gvSD.Columns[i - 1].HeaderText;

            }
            for (int i = 0; i < gvSD.Rows.Count; i++)
            {
                for (int j = 0; j < gvSD.Columns.Count; j++)
                {
                    if (gvSD.Rows[i].Cells[j].Value != null)
                    {

                        xcelApp.Cells[i + 2, j + 1] = gvSD.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            xcelApp.Columns.AutoFit();
            xcelApp.Visible = true;
        }
    }
}
