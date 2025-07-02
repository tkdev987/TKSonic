using Guna.UI2.WinForms;
using PTS_For_Cut.Myclass;
using System.Data;

namespace PTS_For_Cut._7Packing
{
    public partial class SetTargetPack : Form
    {
        public SetTargetPack()
        {
            InitializeComponent();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            LoadNew();
        }
        private string setDate(Guna2DateTimePicker dtpDate)
        {
            string txtDate = "";
            System.Globalization.CultureInfo _cultureEnInfo = new System.Globalization.CultureInfo("en-US");
            DateTime date = Convert.ToDateTime(dtpDate.Value, _cultureEnInfo);
            txtDate = date.ToString("yyyy-MM-dd", _cultureEnInfo);
            return txtDate;
        }
        private void LoadNew()
        {
            string txtDate = setDate(dtpDate);
            ConnectMySQL.DisplayAndSearch("SELECT ROW_NUMBER() OVER(ORDER BY `id`)AS `No`, `Date`, `Line`, `SO`, `SAM`, `ManActual`, " +
                "`TimeActual`, `QtyTargetForecast`  FROM `a_setuptargetforproduction` WHERE DATE(`Date`)='" + txtDate + "' AND `Type` = 'pack' ;", gvDis);
        }

        private void SetTargetPack_Load(object sender, EventArgs e)
        {
            dtpDate.Value = DateTime.Now;
            LoadNew();

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
        private string convertDate(string tDate)
        {
            string txtDate = "";
            System.Globalization.CultureInfo _cultureEnInfo = new System.Globalization.CultureInfo("en-US");
            DateTime date = Convert.ToDateTime(tDate, _cultureEnInfo);
            txtDate = date.ToString("yyyy-MM-dd", _cultureEnInfo);
            return txtDate;
        }
        string ddate = "", sso = "", lline = "";
        private void gvDis_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                int i = e.RowIndex;

                dtpDate.Value = Convert.ToDateTime(gvDis.Rows[i].Cells["Date"].Value.ToString());
                ddate = gvDis.Rows[i].Cells["Date"].Value.ToString();
                cbbLine.Text = gvDis.Rows[i].Cells["Line"].Value.ToString();
                lline = cbbLine.Text;
                tbSO.Text = gvDis.Rows[i].Cells["SO"].Value.ToString();
                sso = tbSO.Text;
                tbSam.Text = gvDis.Rows[i].Cells["SAM"].Value.ToString();//`RunDate`, 
                tbManAc.Text = gvDis.Rows[i].Cells["ManActual"].Value.ToString();
                tbHrsAc.Text = gvDis.Rows[i].Cells["TimeActual"].Value.ToString();
                tbTTPCS.Text = gvDis.Rows[i].Cells["QtyTargetForecast"].Value.ToString();
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (tbSO.Text != "")
            {
                string txtSo = ConnectMySQL.Subtext("SELECT `So` FROM `so_tb` WHERE `So`LIKE '" + tbSO.Text + "' LIMIT 1;");
                string txtDate = setDate(dtpDate);
                string date = convertDate(ddate);
                if (txtSo.Length > 0)
                {
                    if (cbbLine.SelectedIndex > -1 && tbSO.Text != "" && tbSam.Text != "" && tbManAc.Text != "" && cbbLine.SelectedIndex > -1)
                    {
                        if (MessageBox.Show("Are you sure you want to edit data?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            bool st = ConnectMySQL.MysqlQuery("UPDATE `a_setuptargetforproduction` SET `Date`='" + txtDate + "',`Line`='" + cbbLine.Text + "',`SO`='" + tbSO.Text + "'," +
                            "`SAM`='" + tbSam.Text + "',`ManActual`='" + tbManAc.Text + "'," +
                            "`TimeActual`='" + tbHrsAc.Text + "',`QtyTargetForecast` ='" + tbTTPCS.Text + "'" + // //AND a.Type = 'pack'
                            "WHERE DATE(`Date`) = '" + date + "' AND `Line` ='" + lline + "'AND `SO`='" + sso + "' AND Type = 'pack'");
                            if (st)
                            {
                                LoadNew();
                                MessageBox.Show("Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Can Don't Edit  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("Please Check Data");
                    }
                }
                else
                {
                    MessageBox.Show("Don't Have SO in Database");
                }
            }
            else
            {
                MessageBox.Show("SO is Empty");
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {

            if (tbSO.Text != "")
            {
                string txtSo = ConnectMySQL.Subtext("SELECT `So` FROM `so_tb` WHERE `So`LIKE '" + tbSO.Text + "' LIMIT 1;");
                string txtDate = setDate(dtpDate);
                if (txtSo.Length > 0)
                {
                    if (cbbLine.SelectedIndex > -1 && tbSam.Text != "" && tbManAc.Text != "" && tbHrsAc.Text != "")
                    {
                        string txtCheck = ConnectMySQL.Subtext("SELECT `SO` FROM `a_setuptargetforproduction` WHERE `SO` LIKE '" + tbSO.Text + "' AND DATE(`Date`)='" + txtDate + "' AND `Line` LIKE '" + cbbLine.Text + "'AND `Type` LIKE 'pack';");
                        if (txtCheck == "")
                        {
                            if (MessageBox.Show("Are you sure you want to save?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                ConnectMySQL.MysqlQuery("ALTER TABLE `a_setuptargetforproduction` auto_increment = 1;"); //a.`Line`, b.`Style`, a.`SAM`, a.`ManActual`, a.`TimeActual`, a.`QtyTargetForecast` 
                                bool st = ConnectMySQL.MysqlQuery("INSERT INTO `a_setuptargetforproduction`(`id`, `Date`, `Line`, `SO`, `SAM`," +
                                    "`ManActual`, `TimeActual`, `QtyTargetForecast`,`Type` ) " +
                                    "VALUES (NULL,'" + txtDate + "','" + cbbLine.Text + "','" + tbSO.Text + "','" + tbSam.Text + "','" + tbManAc.Text + "', '" + tbHrsAc.Text + "', '" + tbTTPCS.Text + "','pack')");
                                if (st)
                                {
                                    LoadNew();
                                    MessageBox.Show("Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Can Don't Save: ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Can Don't Save Item is Duplicate ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Check Data");
                    }
                }
                else
                {
                    MessageBox.Show("Don't Have SO in Database");
                }
            }
            else
            {
                MessageBox.Show("SO is Empty");
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (ddate != "" && lline != "" && sso != "")
            {
                if (MessageBox.Show("Are you sure you want to delete data?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string date = convertDate(ddate);
                    bool st = ConnectMySQL.MysqlQuery("DELETE FROM `a_setuptargetforproduction` WHERE DATE(`Date`)='" + date + "' AND `Line`='" + lline + "' AND `SO`='" + sso + "' AND Type = 'pack';");
                    if (st)
                    {
                        LoadNew();
                        MessageBox.Show("Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Can Don't Edit  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Select Data For Delete !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear data?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                tbSO.Clear();
                cbbLine.SelectedIndex = -1;
                tbSam.Clear();
                tbManAc.Clear();
                tbTTPCS.Clear();
                tbHrsAc.Clear();

            }
        }
    }
}
