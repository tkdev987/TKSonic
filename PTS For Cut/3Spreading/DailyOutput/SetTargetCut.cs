using Guna.UI2.WinForms;
using PTS_For_Cut.Myclass;
using System.Data;

namespace PTS_For_Cut._3Spreading.DailyOutput
{
    public partial class SetTargetCut : Form
    {
        string ddate = "", sso = "", lline = "";
        public SetTargetCut()
        {
            InitializeComponent();
        }

        private string setDate(Guna2DateTimePicker dtpDate)
        {
            string txtDate = "";
            System.Globalization.CultureInfo _cultureEnInfo = new System.Globalization.CultureInfo("en-US");
            DateTime date = Convert.ToDateTime(dtpDate.Value, _cultureEnInfo);
            txtDate = date.ToString("yyyy-MM-dd", _cultureEnInfo);
            return txtDate;
        }

        private void SetTargetCut_Load(object sender, EventArgs e)
        {
            dtpDate.Value = DateTime.Now;
            cbbLine.Items.Clear();

            DataTable dt = new DataTable();
            dt = Login.ins.Line_dt;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["Department"].ToString() == "Cutting")
                {
                    cbbLine.Items.Add(dt.Rows[i]["Line"].ToString());
                }
            }
        }
        private void tbSO_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tbSO.Text.Length > 11)
                {

                    if (tbSO.Text == "")
                    {
                        tbSO.Focus();
                        MessageBox.Show("Please add SO.");
                    }
                    else
                    {
                        tbSam.Focus();
                    }

                }
                else
                {
                    MessageBox.Show("Please Check SO");
                    tbSO.Focus();
                }
            }
        }


        private void tbSam_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tbSam.Text == "")
                {
                    tbSam.Focus();
                    MessageBox.Show("Please add SAM");
                }
                else
                {
                    tbManTarget.Focus();
                }
            }
        }

        private void tbManTarget_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (tbManTarget.Text == "")
                {
                    tbManTarget.Focus();
                    MessageBox.Show("Please add Man Target");
                }
                else
                {
                    tbManAc.Focus();
                }
            }
        }



        private void tbHrsTar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (tbHrsTar.Text == "")
                {
                    tbHrsTar.Focus();
                    MessageBox.Show("Please add Hrs Target");
                }
                else
                {
                    tbHrsAc.Focus();
                }
            }
        }

        private void tbHrsAc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (tbHrsAc.Text == "")
                {
                    tbHrsAc.Focus();
                    MessageBox.Show("Please add Hrs Actual");
                }
                else
                {
                    tbEffPlan.Focus();
                }
            }
        }

        private void tbQtyPlan_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (tbQtyPlan.Text == "")
                {
                    tbQtyPlan.Focus();
                    MessageBox.Show("Please add Qty Plan");
                }
                else
                {
                    tbQtyForecast.Focus();
                }
            }
        }

        private void tbQtyForecast_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (tbQtyForecast.Text == "")
                {
                    tbQtyForecast.Focus();
                    MessageBox.Show("Please add Qty Forecast");
                }
                else
                {
                    SaveData();
                }
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void SaveData()
        {
            if (tbSO.Text != "")
            {
                string txtSo = ConnectMySQL.Subtext("SELECT `So` FROM `so_tb` WHERE `So`LIKE '" + tbSO.Text + "' LIMIT 1;");
                string txtDate = setDate(dtpDate);
                if (txtSo.Length > 0)
                {
                    if (cbbLine.SelectedIndex > -1 && tbManTarget.Text != "" && tbSam.Text != "" && tbManAc.Text != "" && tbHrsTar.Text != ""
                        && tbManTarget.Text != "" && tbHrsTar.Text != "" && tbHrsAc.Text != "" && tbEffPlan.Text != ""
                        && tbEffForecast.Text != "")
                    {
                        string txtCheck = ConnectMySQL.Subtext("SELECT `SO` FROM `a_setuptargetforproduction` WHERE `SO` LIKE '" + tbSO.Text + "' AND DATE(`Date`)='" + txtDate + "' AND `Line` LIKE '" + cbbLine.Text + "' AND Type ='cut';");
                        if (txtCheck == "")
                        {
                            if (MessageBox.Show("Are you sure you want to save?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                ConnectMySQL.MysqlQuery("ALTER TABLE `a_setuptargetforproduction` auto_increment = 1;");
                                bool st = ConnectMySQL.MysqlQuery("INSERT INTO `a_setuptargetforproduction`(`id`, `Date`, `Line`, `SO`, `SAM`, `ManTarget`, `ManActual`," +
                                                                  "`TimeTarget`, `TimeActual`,`EffTargetplan`, `EffTargetForecast`, `Type`) " +
                                                                  "VALUES (NULL,'" + txtDate + "','" + cbbLine.Text + "','" + tbSO.Text + "','" + tbSam.Text + "','" + tbManTarget.Text + "','" + tbManAc.Text + "'," +
                                                                  "'" + tbHrsTar.Text + "','" + tbHrsAc.Text + "','" + tbEffPlan.Text + "','" + tbEffForecast.Text + "','cut')");
                                if (st)
                                {
                                    ConnectMySQL.DisplayAndSearch("SELECT ROW_NUMBER() OVER(ORDER BY `id`)AS `No` , `Date`, `Line`, `SO`, `SAM`, `ManTarget`, `ManActual`, `TimeTarget`, `TimeActual`, " +
                                    "`EffTargetplan`, `EffTargetForecast` FROM `a_setuptargetforproduction` WHERE DATE(`Date`)= '" + txtDate + "' AND `Type` ='cut' ", gvDis);

                                    MessageBox.Show("Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    clearData();
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

        private void btSearch_Click(object sender, EventArgs e)
        {
            string txtDate = setDate(dtpDate);
            ConnectMySQL.DisplayAndSearch("SELECT ROW_NUMBER() OVER(ORDER BY `id`)AS `No` , `Date`, `Line`, `SO`, `SAM`, `ManTarget`, `ManActual`, `TimeTarget`, `TimeActual`, " +
           "`EffTargetplan`, `EffTargetForecast` FROM `a_setuptargetforproduction` WHERE DATE(`Date`)= '" + txtDate + "' AND `Type` ='cut' ", gvDis);
        }
        private void clearData()
        {

            tbSO.Clear();
            cbbLine.SelectedIndex = -1;
            tbSam.Clear();
            tbManTarget.Clear();
            tbManAc.Clear();
            tbHrsTar.Clear();
            tbHrsAc.Clear();
            tbEffPlan.Clear();
            tbEffForecast.Clear();

        }
        private void btClear_Click(object sender, EventArgs e)
        {
            clearData();
        }

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
                tbManTarget.Text = gvDis.Rows[i].Cells["ManTarget"].Value.ToString();
                tbManAc.Text = gvDis.Rows[i].Cells["ManActual"].Value.ToString();
                tbHrsTar.Text = gvDis.Rows[i].Cells["TimeTarget"].Value.ToString();
                tbHrsAc.Text = gvDis.Rows[i].Cells["TimeActual"].Value.ToString();
                tbEffPlan.Text = gvDis.Rows[i].Cells["EffTargetplan"].Value.ToString();
                tbEffForecast.Text = gvDis.Rows[i].Cells["EffTargetForecast"].Value.ToString();

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
                    if (cbbLine.SelectedIndex > -1 && tbManTarget.Text != "" && tbSam.Text != "" && tbManAc.Text != "" && tbHrsTar.Text != ""
                       && tbManTarget.Text != "" && tbHrsTar.Text != "" && tbHrsAc.Text != "" && tbEffPlan.Text != ""
                       && tbEffForecast.Text != "")
                    {
                        if (MessageBox.Show("Are you sure you want to edit data?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            bool st = ConnectMySQL.MysqlQuery("UPDATE `a_setuptargetforproduction` SET `Date`='" + txtDate + "',`Line`='" + cbbLine.Text + "',`SO`='" + tbSO.Text + "'," +
                            "`SAM`='" + tbSam.Text + "',`ManTarget`='" + tbManTarget.Text + "',`ManActual`='" + tbManAc.Text + "'," +
                            "`TimeTarget`='" + tbHrsTar.Text + "',`TimeActual`='" + tbHrsAc.Text + "',`EffTargetplan`='" + tbEffPlan.Text + "',`EffTargetForecast`='" + tbEffForecast.Text + "' " +
                            "WHERE DATE(`Date`) = '" + date + "' AND `Line` ='" + lline + "'AND `SO`='" + sso + "' AND `Type` ='cut' ");
                            if (st)
                            {
                                ConnectMySQL.DisplayAndSearch("SELECT `id`, `Date`, `Line`, `SO`, `SAM`, `ManTarget`, `ManActual`, `TimeTarget`, `TimeActual`, " +
                                                "`EffTargetplan`, `EffTargetForecast` FROM `a_setuptargetforproduction` WHERE DATE(`Date`)= '" + txtDate + "' AND `Type` ='cut' ", gvDis);
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
        private string convertDate(string tDate)
        {
            string txtDate = "";
            System.Globalization.CultureInfo _cultureEnInfo = new System.Globalization.CultureInfo("en-US");
            DateTime date = Convert.ToDateTime(tDate, _cultureEnInfo);
            txtDate = date.ToString("yyyy-MM-dd", _cultureEnInfo);
            return txtDate;
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (ddate != "" && lline != "" && sso != "")
            {
                if (MessageBox.Show("Are you sure you want to delete data?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string date = convertDate(ddate);
                    bool st = ConnectMySQL.MysqlQuery("DELETE FROM `a_setuptargetforproduction` WHERE DATE(`Date`)='" + date + "' AND `Line`='" + lline + "' AND `SO`='" + sso + "' AND `Type` ='cut';");
                    if (st)
                    {
                        string txtDate = setDate(dtpDate);
                        ConnectMySQL.DisplayAndSearch("SELECT `id`, `Date`, `Line`, `SO`, `SAM`, `ManTarget`, `ManActual`, `TimeTarget`, `TimeActual`, " +
                                        "`EffTargetplan`, `EffTargetForecast` FROM `a_setuptargetforproduction` WHERE DATE(`Date`)= '" + txtDate + "' AND `Type` ='cut'", gvDis);
                        MessageBox.Show("Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Can Don't Delete  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Select Data For Delete !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tbSam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void tbManTarget_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void tbEffPlan_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (tbEffPlan.Text == "")
                {
                    tbEffPlan.Focus();
                    MessageBox.Show("Please add Eff Plan");
                }
                else
                {
                    tbEffForecast.Focus();
                }
            }
        }

        private void tbEffForecast_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (tbEffForecast.Text == "")
                {
                    tbEffForecast.Focus();
                    MessageBox.Show("Please add Eff Forecast");
                }
                else
                {
                    SaveData();
                }
            }
        }

        private void tbManAc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (tbManAc.Text == "")
                {
                    tbManAc.Focus();
                    MessageBox.Show("Please add Man Actual");
                }
                else
                {
                    tbHrsTar.Focus();
                }
            }
        }

        private void tbManAc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void tbHrsTar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void tbHrsAc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void tbEffPlan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void tbEffForecast_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }

}
