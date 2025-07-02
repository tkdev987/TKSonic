using PTS_For_Cut.Myclass;
using System.Data;

namespace PTS_For_Cut._3Spreading.Report
{
    public partial class selectColorPrint : Form
    {
        public selectColorPrint()
        {
            InitializeComponent();
        }

        private void selectColorPrint_Load(object sender, EventArgs e)
        {
            cbbReportMode.SelectedIndex = 0;
            chListColorprint.Items.Clear();
            chListSpreading.Items.Clear();
            pnDecTop.Visible = false;


            // dtDecoration = ConnectMySQL.MySQLtoDataTable("SELECT `Dec_ID`, `Dec_Eng`, `Dec_Thai`, `Short_Dec` FROM `a_a0decoration` WHERE 1");
            cbbDec.Items.Clear();

            for (int i = 0; i < Login.ins.dtDecoration.Rows.Count; i++)
            {
                //cbbDec.Items.Add(ClothingPart_dt.Rows[i]["ClothingPart"].ToString());
                cbbDec.Items.Add(Login.ins.dtDecoration.Rows[i]["Dec_Eng"].ToString());
            }
            foreach (var item in CuttingReport.ins.checkedListBox.Items)
            {
                chListColorprint.Items.Add(item);
            }

            //DataTable dtSP = new DataTable();
            //dtSP = CuttingReport.ins.dtSpreadingList;
            //for (int i = 0; i < dtSP.Rows.Count; i++)
            //{
            //    chListSpreading.Items.Add(dtSP.Rows[i]["SD_ListDoc_No"]);
            //}
        }

        private void btPrint_Click(object sender, EventArgs e)
        {//getColortoPrint
            if (cbbReportMode.SelectedIndex == 0)
            {
                if (chListColorprint.CheckedItems.Count > 0)
                {
                    CuttingReport.ins.getColortoPrint.Items.Clear();

                    for (int i = 0; i < chListColorprint.Items.Count; i++)
                    {
                        if (chListColorprint.GetItemChecked(i))
                        {
                            CuttingReport.ins.getColortoPrint.Items.Add(chListColorprint.Items[i].ToString());
                        }
                    }
                    CuttingReport.ins.printMode = cbbReportMode.SelectedIndex;
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Please Select Item.");
                }
            }
            else if (cbbReportMode.SelectedIndex == 1)
            {
                if (chListSpreading.CheckedItems.Count > 0)
                {
                    List<string> checkedItemsList = new List<string>();

                    for (int i = 0; i < chListSpreading.Items.Count; i++)
                    {
                        if (chListSpreading.GetItemChecked(i))
                        {
                            // MessageBox.Show();
                            checkedItemsList.Add("'" + chListSpreading.Items[i].ToString() + "'");
                        }
                    }
                    if (cbbDec.SelectedIndex == -1)
                    {
                        CuttingReport.ins.rHeader = "Bundle Report";
                    }
                    else
                    {
                        CuttingReport.ins.rHeader = cbbDec.Text;
                    }
                    CuttingReport.ins.rClothingPart = tbClothingPart.Text;
                    CuttingReport.ins.rPlace = cbbPlace.Text;
                    string checkedItemsString = string.Join(", ", checkedItemsList);
                    CuttingReport.ins.searchBundle(checkedItemsString);
                    CuttingReport.ins.printMode = cbbReportMode.SelectedIndex;
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Please Select Item.");
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btCheckedAll_Click(object sender, EventArgs e)
        {

        }

        private void btUncheck_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbbReportMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbReportMode.SelectedIndex == 1)
            {
                pnDecTop.Visible = true;
                pnSpreading.Visible = true;
                cbbClothingPart.Items.Clear();

                DataTable ClothingPart_dt = ConnectMySQL.MySQLtoDataTable("SELECT  DISTINCT(`ClothingPart`) FROM `a_b1_bundle_tb` WHERE `SO`LIKE '" + CuttingReport.ins.rSO + "'");

                if (ClothingPart_dt.Rows.Count > 0)
                {
                    for (int i = 0; i < ClothingPart_dt.Rows.Count; i++)
                    {
                        //  cbbClothingPart.Items.Add("");

                        cbbClothingPart.Items.Add(ClothingPart_dt.Rows[i]["ClothingPart"].ToString());
                    }
                }
            }

        }

        private void cbbDec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbDec.SelectedIndex > -1)
            {
                pnDetailInDectop.Visible = true;
                cbbPlace.Items.Clear();
                DataTable dtDecshop = ConnectMySQL.MySQLtoDataTable("SELECT `supplier` FROM `a_a0dec_supplier` WHERE `DecGroup`LIKE '" + cbbDec.Text + "'");
                foreach (DataRow dr in dtDecshop.Rows)
                {
                    cbbPlace.Items.Add(dr[0].ToString());
                }
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (tbClothingPart.Text != "")
            {
                tbClothingPart.Text = tbClothingPart.Text + "," + cbbClothingPart.Text;
            }
            else
            {
                tbClothingPart.Text = cbbClothingPart.Text;
            }

        }

        private void btColorCh_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chListColorprint.Items.Count; i++)
            {
                chListColorprint.SetItemChecked(i, true); // Uncheck all items initially
            }
        }

        private void btColorUnCh_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chListColorprint.Items.Count; i++)
            {
                chListColorprint.SetItemChecked(i, false); // Uncheck all items initially
            }
        }

        private void btSpCh_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chListSpreading.Items.Count; i++)
            {
                chListSpreading.SetItemChecked(i, true); // Uncheck all items initially
            }
        }

        private void btSPUnCh_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chListSpreading.Items.Count; i++)
            {
                chListSpreading.SetItemChecked(i, false); // Uncheck all items initially
            }
        }

        private void chListColorprint_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke((Action)functionA);


        }
        private void functionA()
        {
            DataTable dtSP = new DataTable();
            dtSP = CuttingReport.ins.dtSpreadingList;
            chListSpreading.Items.Clear();
            for (int k = 0; k < chListColorprint.Items.Count; k++)
            {
                if (chListColorprint.GetItemChecked(k))
                {
                    for (int i = 0; i < dtSP.Rows.Count; i++)
                    {
                        if (dtSP.Rows[i]["Color"].ToString() == chListColorprint.Items[k].ToString())
                        {
                            // MessageBox.Show(dtSP.Rows[i]["Color"].ToString());
                            bool chHave = false;
                            for (int j = 0; j < chListSpreading.Items.Count; j++)
                            {
                                if (dtSP.Rows[i]["SD_ListDoc_No"].ToString() == chListSpreading.Items[j].ToString())
                                {
                                    chHave = true;
                                }
                            }
                            if (!chHave)
                            {
                                chListSpreading.Items.Add(dtSP.Rows[i]["SD_ListDoc_No"]);
                            }
                        }
                    }
                }
            }
        }

        private void cbbDec_Click(object sender, EventArgs e)
        {

        }

        private void cbbClothingPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbClothingPart.SelectedIndex > -1)
            {
                if (CuttingReport.ins.fabricType != "A")
                {
                    CuttingReport.ins.selectpartToPrint = "`a`.`ClothingPart` ='" + cbbClothingPart.Text + "'";
                }
                CuttingReport.ins.rClothingPart = cbbClothingPart.Text;
            }
        }
    }
}
