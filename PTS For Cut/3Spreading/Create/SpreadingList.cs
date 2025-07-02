using PTS_For_Cut.Main;
using PTS_For_Cut.Myclass;
using PTS_For_Cut.Spreading.Create;

namespace PTS_For_Cut._3Spreading.Create
{
    public partial class SpreadingList : Form
    {

        public static SpreadingList ins;
        private static SpreadingList _instance;
        //  public bool status = false;
        private bool Active_status = false;

        public static SpreadingList Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SpreadingList();
                return _instance;
            }
        }
        public SpreadingList()
        {
            InitializeComponent();
            ins = this;
        }


        private void SpreadingList_Load(object sender, EventArgs e)
        {
            cbbTypeOfSearch.SelectedIndex = 0;
        }

        private void btCreateSDDoc_Click(object sender, EventArgs e)
        {
            if (HomePage.ins.checkPermiss("sd_add"))
            {
                HomePage.ins.EditMode = 0;
                using (ImportCutPlan di = new ImportCutPlan())
                {
                    if (di.ShowDialog() == DialogResult.OK)
                    {
                        // status = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("This Account Don't Have Permission For This Function.");
            }
        }
        int index_r = -1;
        private void btEdit_Click(object sender, EventArgs e)
        {

            if (HomePage.ins.checkPermiss("sd_edit"))
            {
                if (HomePage.ins.DocNo != "")
                {
                    if (gvDis.Rows[index_r].Cells["WH Scanout"].Value.ToString() != "Done" || HomePage.ins.checkPermiss("superUser"))
                    {
                        HomePage.ins.EditMode = 1;
                        using (ImportCutPlan di = new ImportCutPlan())
                        {
                            if (di.ShowDialog() == DialogResult.OK)
                            {
                                ser();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Can't Edit Because HW Scan Out's Done.");
                    }

                }
                else
                {
                    MessageBox.Show("Please Select item");
                }
            }
            else
            {
                MessageBox.Show("This Account Don't Have Permission For This Function.");
            }
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            if (HomePage.ins.checkPermiss("sd_print"))
            {
                if (HomePage.ins.DocNo != "")
                {
                    if (Active_status)
                    {
                        HomePage.ins.EditMode = 2;
                        using (ImportCutPlan di = new ImportCutPlan())
                        {
                            if (di.ShowDialog() == DialogResult.OK)
                            {

                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("This Item Not Confirm.");
                    }
                }
                else
                {
                    MessageBox.Show("Please Select item");
                }

            }
            else
            {
                MessageBox.Show("This Account Don't Have Permission For This Function.");
            }
        }

        private void btClearFabric_Click(object sender, EventArgs e)
        {//sd_AddFabric
            if (HomePage.ins.checkPermiss("sd_AddFabric"))
            {
                if (HomePage.ins.DocNo != "")
                {
                    if (gvDis.Rows[index_r].Cells["WH Scanout"].Value.ToString() != "Done")
                    {
                        if (Login.ins.userName == gvDis.Rows[index_r].Cells["User"].Value.ToString())
                        {
                            if (MessageBox.Show("Want to clear fabric in this ducument?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {

                                ConnectMySQL.MysqlQuery("DELETE FROM `c_wh1_bc_sdactual_tb` WHERE `SD_ListDoc_No`='" + HomePage.ins.DocNo + "' ");
                            }
                        }
                        else
                        {
                            MessageBox.Show("User : " + gvDis.Rows[index_r].Cells["User"].Value.ToString() + "Can Edit Only.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("This Document Start to Use Can't Clear Fabric.");
                    }
                }
                else
                {
                    MessageBox.Show("Please Select item");
                }
            }
            else
            {
                MessageBox.Show("This Account Don't Have Permission For This Function.");
            }
        }

        private void btSaveStatus_Click(object sender, EventArgs e)
        {
            if (HomePage.ins.checkPermiss("sd_StatusSD"))
            {
                if (HomePage.ins.DocNo != "")
                {
                    if (gvDis.Rows[index_r].Cells["WH Scanout"].Value.ToString() != "Done")
                    {
                        if (Login.ins.userName == gvDis.Rows[index_r].Cells["User"].Value.ToString() || HomePage.ins.checkPermiss("superUser"))
                        {
                            if (MessageBox.Show("You Want to Cancel in this ducument?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                if (cbbSDstatus.SelectedIndex > -1)
                                {
                                    if (cbbSDstatus.SelectedIndex == 2)
                                    {
                                        string CountFabric = ConnectMySQL.Subtext("SELECT COUNT(`Barcode`) FROM `c_wh1_bc_sdactual_tb` WHERE `SD_ListDoc_No`='" + HomePage.ins.DocNo + "';");
                                        if (CountFabric != "0")
                                        {
                                            MessageBox.Show("Can't Save Need to Clear Fabric Before Cancel Document.");
                                        }
                                        else
                                        {
                                            // 
                                            bool st = ConnectMySQL.MysqlQuery("UPDATE `a_a1_spreading_list_tb` SET `SD_Status`= '2' WHERE `SD_ListDoc_No`='" + HomePage.ins.DocNo + "'");
                                            if (st)
                                            {
                                                MessageBox.Show("OK");
                                                ser();
                                            }
                                            else
                                            {
                                                MessageBox.Show("!!!!!!! Can't Update !!!!!!!!!");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        bool st = ConnectMySQL.MysqlQuery("UPDATE `a_a1_spreading_list_tb` SET `SD_Status`= '" + cbbSDstatus.SelectedIndex + "' WHERE `SD_ListDoc_No`='" + HomePage.ins.DocNo + "'");
                                        if (st)
                                        {
                                            MessageBox.Show("OK");
                                        }
                                        else
                                        {
                                            MessageBox.Show("!!!!!!! Can't Update !!!!!!!!!");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                cbbSDstatus.SelectedIndex = -1;
                            }
                        }
                        else
                        {
                            MessageBox.Show("User : " + gvDis.Rows[index_r].Cells["User"].Value.ToString() + "Can Edit Only.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("This Document Start to Use Can't Change Status.");
                    }
                }
                else
                {
                    MessageBox.Show("Please Select item");
                }
            }
            else
            {
                MessageBox.Show("This Account Don't Have Permission For This Function.");
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            ser();
        }

        private void tbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ser();
            }
        }
        private void ser()
        {
            if (tbSearch.Text.Length > 0)
            {
                if (tbSearch.Text.Substring(0, 2) == "SO")
                {
                    cbbTypeOfSearch.SelectedIndex = 1;
                }
                else if (tbSearch.Text.Substring(0, 2) == "SD")
                {
                    cbbTypeOfSearch.SelectedIndex = 0;
                }

                if (cbbTypeOfSearch.SelectedIndex > -1)
                {
                    string SD_DOC_NO = "";
                    string SO = "";
                    string Style = "";
                    if (cbbTypeOfSearch.SelectedIndex == 0)
                    {
                        SD_DOC_NO = tbSearch.Text;
                        SO = "";
                        Style = "";
                    }
                    else if (cbbTypeOfSearch.SelectedIndex == 1)
                    {
                        SO = tbSearch.Text;
                        Style = "";
                        SD_DOC_NO = "";
                    }
                    else if (cbbTypeOfSearch.SelectedIndex == 2)
                    {
                        Style = tbSearch.Text;

                        SD_DOC_NO = "";
                        SO = "";
                    }
                    ConnectMySQL.DisplayAndSearch("SELECT `a`.`SD_ListDoc_No`AS `Doc No` , `a`.`SO`, `a`.`Style`, `a`.`Mark_ID`AS`Mark ID`,`a`.`FabricType`, (SELECT COUNT(`w`.`Barcode`) FROM `c_wh1_bc_sdactual_tb` AS `w` WHERE `w`.`SD_ListDoc_No`=`a`.`SD_ListDoc_No` )AS `Fabric In Doc.`, `a`.`Table_No`AS`Table No`, " +
                 " `a`.`DateCreate`, " +
                 "`a`.`Color`,`a`.`User`, " +
                 "CASE " +
                        "WHEN `a`.`SD_Status` = 0 THEN 'Draft' " +
                        "WHEN `a`.`SD_Status` = 1 THEN 'Confirm' " +
                        "WHEN `a`.`SD_Status` = 2 THEN 'Cancel' " +
                         "ELSE 'Error' " +
                    "END AS `Status`, " +
                   "CASE " +
                        "WHEN `C`.`wh_scanout` IS NOT NULL THEN 'Done' " +
                        "ELSE NULL " +
                    "END AS `WH Scanout`, " +
                    "CASE " +
                        "WHEN `C`.`SD_ScanIn` !='0000-00-00 00:00:00.000000' THEN 'Done' " +
                        "ELSE NULL " +
                    "END AS `SD ScanIn`, " +
                    "CASE " +
                        "WHEN `C`.`SD_ScanOut` !='0000-00-00 00:00:00.000000' THEN 'Done' " +
                        "ELSE NULL " +
                    "END AS `SD ScanOut`, " +
                    "CASE " +
                        "WHEN `C`.`Cut_ScanIn` !='0000-00-00 00:00:00.000000' THEN 'Done' " +
                        "ELSE NULL " +
                    "END AS `Cut ScanIn`, " +
                    "CASE " +
                        "WHEN `C`.`Cut_ScanOut` !='0000-00-00 00:00:00.000000' THEN `C`.`Cut_ScanOut` " +
                        "ELSE NULL " +
                    "END AS `Cut ScanOut` " +

                 "FROM `a_a1_spreading_list_tb` AS `a`  " +
                 "LEFT JOIN `a_a2_spreading_detail_tb` AS `b` ON `a`.`SD_ListDoc_No`=`b`.`SD_ListDoc_No` " +
                 "LEFT JOIN `a_a3_scandoc_sd_ct_tb` AS `C` ON `a`.`SD_ListDoc_No`=`C`.`SD_ListDoc_No` " +
                 "WHERE `a`.`SD_ListDoc_No`LIKE '%" + SD_DOC_NO + "%' AND `a`.`SO` LIKE '%" + SO + "%' " +
                 "AND `a`.`Style` LIKE '%" + Style + "%' GROUP BY `a`.`SD_ListDoc_No`;", gvDis);

                    gvDis.Columns["Doc No"].Width = 55;
                    gvDis.Columns["SO"].Width = 50;
                    gvDis.Columns["Style"].Width = 55;
                    gvDis.Columns["Mark ID"].Width = 90;
                    gvDis.Columns["Fabric In Doc."].Width = 55;
                    gvDis.Columns["FabricType"].Width = 40;
                    gvDis.Columns["Table No"].Width = 50;//DateCreate    "`a`.`Color`,`a`.`User`, " +
                    gvDis.Columns["DateCreate"].Width = 50;
                    gvDis.Columns["Color"].Width = 100;
                    gvDis.Columns["User"].Width = 35;
                    gvDis.Columns["Status"].Width = 35;
                    gvDis.Columns["WH Scanout"].Width = 60;
                    gvDis.Columns["SD ScanIn"].Width = 60;
                    gvDis.Columns["SD ScanOut"].Width = 60;
                    gvDis.Columns["Cut ScanIn"].Width = 60;
                    gvDis.Columns["Cut ScanOut"].Width = 90;

                    for (int i = 0; i < gvDis.Rows.Count; i++)
                    {
                        if (gvDis.Rows[i].Cells["Status"].Value.ToString() == "Cancel")
                        {
                            gvDis.Rows[i].Cells["Status"].ReadOnly = false;
                        }
                    }
                }
            }
        }

        private void gvDis_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (gvDis.Rows.Count > 0)
                {

                    int d = e.RowIndex;
                    index_r = e.RowIndex;
                    DataGridViewRow sel = gvDis.Rows[d];
                    HomePage.ins.DocNo = sel.Cells["Doc No"].Value.ToString();
                    if (sel.Cells["Status"].Value.ToString() == "Confirm")
                    {
                        Active_status = true;
                    }
                    else
                    {
                        Active_status = false;
                    }
                    // HomePage.ins.ActiveRow =Convert.ToBoolean();
                }
            }
        }

        private void btCopy_Click(object sender, EventArgs e)
        {
            if (HomePage.ins.checkPermiss("sd_edit"))
            {
                if (HomePage.ins.DocNo != "")
                {
                    HomePage.ins.EditMode = 3;
                    using (ImportCutPlan di = new ImportCutPlan())
                    {
                        if (di.ShowDialog() == DialogResult.OK)
                        {
                            ser();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please Select item");
                }
            }
            else
            {
                MessageBox.Show("This Account Don't Have Permission For This Function.");
            }
        }
    }
}
