using PTS_For_Cut.Myclass;
using System.Data;
using MessageBox = System.Windows.Forms.MessageBox;

namespace PTS_For_Cut._3Spreading.Create
{
    public partial class SeparateFabric : Form
    {
        DataTable dtData = new DataTable();
        public SeparateFabric()
        {
            InitializeComponent();
        }
        private void SeparateFabric_Load(object sender, EventArgs e)
        {
            dtData = SelectFabric.ins.dtForSeparate;
            lbMarklength.Text = SelectFabric.ins.MarkLength.ToString("##.##");
            tbPlies.Text = SelectFabric.ins.PliesSap.ToString("##.##");

            if (dtData.Rows.Count > 0)
            {
                gvDis.DataSource = dtData;
            }
            // ConnectMySQL.DisplayAndSearch("SELECT `Barcode`,`YardNet`,`Unit`, `IssueID`, `ReturnID` FROM `c_warehouse1_bc_tb` WHERE `Barcode`='" + SelectFabric.ins.barcodeSeparate + "'", gvDis);
            if (gvDis.Rows.Count > 0)
            {
                List<string> AuthorList = new List<string>();
                for (int i = 0; i < gvDis.Columns.Count; i++)
                {
                    if (i == 1 || i == 3)
                    {
                        AuthorList.Add("0");
                    }
                    else if (i == 4)
                    {
                        AuthorList.Add("YDS");
                    }
                    else
                    {
                        AuthorList.Add(gvDis.Rows[0].Cells[i].Value.ToString());
                    }
                }

                DataTable dt = new DataTable();
                dt = (DataTable)gvDis.DataSource;
                dt.Rows.Add(AuthorList.ToArray());
                for (int i = 0; i < dt.Rows.Count - 1; i++)
                {
                    dt.Rows[i]["Unit"] = "YDS";
                }
                gvDis.DataSource = dt;
                calPlies();

                gvDis.Rows[0].ReadOnly = true;
                gvDis.Rows[0].DefaultCellStyle.BackColor = Color.DarkGray;
                gvDis.Columns[0].ReadOnly = true;
                gvDis.Columns[1].ReadOnly = true;
                gvDis.Columns[2].ReadOnly = true;
                gvDis.Columns[4].ReadOnly = true;
            }
        }

        private void gvDis_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // MessageBox.Show(gvDis.CurrentCell.ColumnIndex.ToString());
            if (gvDis.CurrentCell.ColumnIndex > -1)
            {
                e.Control.KeyPress += new KeyPressEventHandler(gvNumber_KeyPress);
                // gvDis.Rows[gvDis.RowCount-1].Cells["Unit"].Value = "YDS";
            }

        }
        private void calPlies()
        {
            if (tbPlies.Text.Length > 0)
            {
                double length = double.Parse(tbPlies.Text) * double.Parse(lbMarklength.Text);
                double fabric = double.Parse(gvDis.Rows[0].Cells[3].Value.ToString());
                if (length <= fabric)
                {

                    gvDis.Rows[1].Cells[3].Value = Math.Ceiling(length).ToString("##.##");
                    double perc = Math.Ceiling(length) / fabric;
                    double dfd = double.Parse(gvDis.Rows[0].Cells[1].Value.ToString());
                    gvDis.Rows[1].Cells[1].Value = (dfd * perc).ToString("##.##");

                }
                else
                {
                    MessageBox.Show("!!!! Fabric is Over. !!!!");

                }

            }
        }

        private void gvNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // MessageBox.Show("ddsss");
            if (gvDis.CurrentCell.ColumnIndex == 1)
            {
                if (e.KeyChar == '.')
                {
                    e.Handled = false;
                }
                else if ((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
                {
                    e.Handled = true;
                }
                else { e.Handled = false; }
            }
            else if (gvDis.CurrentCell.ColumnIndex == 0)
            {
                if (e.KeyChar == '.' || e.KeyChar == ' ')
                {
                    e.Handled = true;
                }
                else if ((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
                {
                    e.Handled = false;
                }
            }

        }

        private void gvDis_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //  MessageBox.Show("DDDD");
            double sumLength = 0;
            for (int i = 1; i < gvDis.Rows.Count - 1; i++)
            {
                if (gvDis.Rows[i].Cells[3].Value.ToString() != "")
                {
                    sumLength += double.Parse(gvDis.Rows[i].Cells[3].Value.ToString());
                }
                if (sumLength > double.Parse(gvDis.Rows[0].Cells[3].Value.ToString()))
                {
                    gvDis.Rows[i].Cells[3].Value = 0;
                    MessageBox.Show(" Over ");
                }
                //if (sumLength == double.Parse(gvDis.Rows[0].Cells[3].Value.ToString()))
                //{
                //    Same = true;
                //}
            }
            double Total = double.Parse(gvDis.Rows[0].Cells[3].Value.ToString());
            double result = sumLength / Total;
            gvDis.Rows[1].Cells[1].Value = (double.Parse(gvDis.Rows[0].Cells[3].Value.ToString()) * result).ToString("##.##");
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save data?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (tbPlies.Text.Length > 0 && gvDis.Rows.Count > 0)
                {
                    bool st1 = false;
                    string BarcodeMain = gvDis.Rows[0].Cells[0].Value.ToString();
                    double Total = double.Parse(gvDis.Rows[0].Cells["Length YDS"].Value.ToString());
                    double SepYDS = double.Parse(gvDis.Rows[1].Cells["Length YDS"].Value.ToString());
                    double result = SepYDS / Total;
                    string Qtynew = gvDis.Rows[1].Cells["Igarment QTY"].Value.ToString();

                    //if (gvDis.Rows[1].Cells[1].Value.ToString() != "" && gvDis.Rows[1].Cells[1].Value.ToString() != "0") //`Style`='" + lbStyle.Text + "'
                    //{
                    //    st1 = ConnectMySQL.MysqlQuery("INSERT INTO `c_wh1_bc_sdactual_tb`(`BcID`, `Barcode`, `CreateDate`, `Qty`, `QtyNet`, `YardNet`)" +
                    //      "SELECT NULL,'" + BarcodeMain + "', CURRENT_TIMESTAMP,  '" + Qtynew + "',`QtyNet`* " + result + ",'" + SepYDS.ToString() + "' " +
                    //      "FROM `c_warehouse1_bc_tb` WHERE `Barcode` ='" + BarcodeMain + "';");
                    //}
                    //if (st1)
                    //{

                    SelectFabric.ins.dtSelectSeparateFab.Rows.Clear();
                    List<string> AuthorList = new List<string>();
                    for (int i = 0; i < SelectFabric.ins.dtSelectSeparateFab.Columns.Count; i++)
                    {
                        // MessageBox.Show(SelectFabric.ins.dtSelectSeparateFab.Columns.Count.ToString());
                        // MessageBox.Show(i.ToString() + "||" + SelectFabric.ins.dtSelectSeparateFab.Columns[i].ColumnName);
                        if (i == 0)
                        {
                            AuthorList.Add(BarcodeMain);
                        }
                        else if (i == 7)
                        {
                            AuthorList.Add(Qtynew);
                        }
                        else if (i == 10)
                        {
                            AuthorList.Add(SepYDS.ToString());
                        }
                        else
                        {
                            AuthorList.Add("");
                        }
                    }
                    SelectFabric.ins.dtSelectSeparateFab.Rows.Add(AuthorList.ToArray());
                    SelectFabric.ins.PliesSep = tbPlies.Text;
                    MessageBox.Show("OK");
                    DialogResult = DialogResult.OK;
                    //}
                    //else
                    //{
                    //    MessageBox.Show("!!!!! Error !!!!!");
                    //}
                }
                else
                {
                    MessageBox.Show("Plies of fabric don't have data ");
                }
            }
        }

        private void btSaveEdit_Click(object sender, EventArgs e)
        {
            if (gvDis.Rows.Count > 0)
            {
                for (int i = 0; i < gvDis.Rows.Count; i++)
                {
                    ConnectMySQL.MysqlQuery("UPDATE `c_warehouse1_bc_tb` SET `IssueID`='" + gvDis.Rows[i].Cells["IssueID"].Value.ToString() + "',`ReturnID`='" + gvDis.Rows[i].Cells["ReturnID"].Value.ToString() + "' WHERE `Barcode` LIKE '" + gvDis.Rows[i].Cells["Barcode"].Value.ToString() + "'");

                }
                MessageBox.Show("OK");
            }



        }

        private void SeparateFabric_FormClosed(object sender, FormClosedEventArgs e)
        {
            SelectFabric.ins.dtForSeparate.Rows.Clear();
        }

        private void btConfirm_Click(object sender, EventArgs e)
        {
            calPlies();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
