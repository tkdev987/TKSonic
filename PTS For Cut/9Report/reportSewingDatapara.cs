using Guna.UI2.WinForms;
using PTS_For_Cut.Myclass;
using System.Data;

namespace PTS_For_Cut._9Report
{
    public partial class reportSewingDatapara : Form
    {
        public reportSewingDatapara()
        {
            InitializeComponent();
        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Loadagain()
        {
            string txtDate = setDate(dtpDate);
            ConnectMySQL.DisplayAndSearch("SELECT ROW_NUMBER() OVER(ORDER BY `id`)AS `No` , `Date`, `Line`, `SO`, `SAM`,`RunDate`, `ManTarget`, `ManActual`, `Jupper`, `TimeTarget`, `TimeActual`, " +
           "`EffTargetplan`, `EffTargetForecast` FROM `a_setuptargetforproduction` WHERE DATE(`Date`)= '" + txtDate + "' AND `Type`='sew'", gvDis);

        }


        private void reportSewingDatapara_Load(object sender, EventArgs e)
        {
            dtpDate.Value = DateTime.Now;
            Loadagain();
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
        private string setDate(Guna2DateTimePicker dtpDate)
        {
            string txtDate = "";
            System.Globalization.CultureInfo _cultureEnInfo = new System.Globalization.CultureInfo("en-US");
            DateTime date = Convert.ToDateTime(dtpDate.Value, _cultureEnInfo);
            txtDate = date.ToString("yyyy-MM-dd", _cultureEnInfo);
            return txtDate;
        }
        private string convertDate(string tDate)
        {
            string txtDate = "";
            System.Globalization.CultureInfo _cultureEnInfo = new System.Globalization.CultureInfo("en-US");
            DateTime date = Convert.ToDateTime(tDate, _cultureEnInfo);
            txtDate = date.ToString("yyyy-MM-dd", _cultureEnInfo);
            return txtDate;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (tbSO.Text != "")
            {
                string txtSo = ConnectMySQL.Subtext("SELECT `So` FROM `so_tb` WHERE `So`LIKE '" + tbSO.Text + "' LIMIT 1;");
                string txtDate = setDate(dtpDate);
                if (txtSo.Length > 0)
                {
                    if (cbbLine.SelectedIndex > -1 && tbManTarget.Text != "" && tbSam.Text != "" && tbManAc.Text != "" && tbHrsTar.Text != ""
                        && tbManTarget.Text != "" && tbJumper.Text != "" && tbHrsTar.Text != "" && tbHrsAc.Text != "" && tbEffPlan.Text != ""
                        && tbEffForecast.Text != "" && tbRunDate.Text != "")
                    {
                        string txtCheck = ConnectMySQL.Subtext("SELECT `SO` FROM `a_setuptargetforproduction` WHERE `SO` LIKE '" + tbSO.Text + "' AND DATE(`Date`)='" + txtDate + "' AND `Line` LIKE '" + cbbLine.Text + "' AND `Type` = 'sew';");
                        if (txtCheck == "")
                        {
                            if (MessageBox.Show("Are you sure you want to save?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                ConnectMySQL.MysqlQuery("ALTER TABLE `a_setuptargetforproduction` auto_increment = 1;");
                                bool st = ConnectMySQL.MysqlQuery("INSERT INTO `a_setuptargetforproduction`(`id`, `Date`, `Line`, `SO`, `SAM`,`RunDate`, `ManTarget`, `ManActual`, `Jupper`," +
                                    " `TimeTarget`, `TimeActual`, `EffTargetplan`, `EffTargetForecast`, `Type`) " +
                                    "VALUES (NULL,'" + txtDate + "','" + cbbLine.Text + "','" + tbSO.Text + "','" + tbSam.Text + "','" + tbRunDate.Text + "','" + tbManTarget.Text + "','" + tbManAc.Text + "'," +
                                    "'" + tbJumper.Text + "','" + tbHrsTar.Text + "','" + tbHrsAc.Text + "','" + tbEffPlan.Text + "','" + tbEffForecast.Text + "','sew')");
                                if (st)
                                {
                                    Loadagain();
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

        private void btSearch_Click_1(object sender, EventArgs e)
        {
            Loadagain();
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
                tbRunDate.Text = gvDis.Rows[i].Cells["RunDate"].Value.ToString();
                tbManTarget.Text = gvDis.Rows[i].Cells["ManTarget"].Value.ToString();
                tbManAc.Text = gvDis.Rows[i].Cells["ManActual"].Value.ToString();
                tbJumper.Text = gvDis.Rows[i].Cells["Jupper"].Value.ToString();
                tbHrsTar.Text = gvDis.Rows[i].Cells["TimeTarget"].Value.ToString();
                tbHrsAc.Text = gvDis.Rows[i].Cells["TimeActual"].Value.ToString();
                tbEffPlan.Text = gvDis.Rows[i].Cells["EffTargetplan"].Value.ToString();
                tbEffForecast.Text = gvDis.Rows[i].Cells["EffTargetForecast"].Value.ToString();
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            //

            if (tbSO.Text != "")
            {
                string txtSo = ConnectMySQL.Subtext("SELECT `So` FROM `so_tb` WHERE `So`LIKE '" + tbSO.Text + "' LIMIT 1;");
                string txtDate = setDate(dtpDate);
                string date = convertDate(ddate);
                if (txtSo.Length > 0)
                {
                    if (cbbLine.SelectedIndex > -1 && tbManTarget.Text != "" && tbSam.Text != "" && tbManAc.Text != "" && tbHrsTar.Text != ""
                       && tbManTarget.Text != "" && tbJumper.Text != "" && tbHrsTar.Text != "" && tbHrsAc.Text != "" && tbEffPlan.Text != ""
                       && tbEffForecast.Text != "" && tbRunDate.Text != "")
                    {
                        if (MessageBox.Show("Are you sure you want to edit data?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            bool st = ConnectMySQL.MysqlQuery("UPDATE `a_setuptargetforproduction` SET `Date`='" + txtDate + "',`Line`='" + cbbLine.Text + "',`SO`='" + tbSO.Text + "'," +
                            "`SAM`='" + tbSam.Text + "',`RunDate`='" + tbRunDate.Text + "',`ManTarget`='" + tbManTarget.Text + "',`ManActual`='" + tbManAc.Text + "',`Jupper`='" + tbJumper.Text + "'," +
                            "`TimeTarget`='" + tbHrsTar.Text + "',`TimeActual`='" + tbHrsAc.Text + "',`EffTargetplan`='" + tbEffPlan.Text + "',`EffTargetForecast`='" + tbEffForecast.Text + "' " +
                            "WHERE DATE(`Date`) = '" + date + "' AND `Line` ='" + lline + "'AND `SO`='" + sso + "' AND `Type`='sew'");
                            if (st)
                            {
                                Loadagain();
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

        private void tbManAc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void tbJumper_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbHrsAc_KeyDown(object sender, KeyEventArgs e)
        {

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

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (ddate != "" && lline != "" && sso != "")
            {
                if (MessageBox.Show("Are you sure you want to delete data?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string date = convertDate(ddate);
                    bool st = ConnectMySQL.MysqlQuery("DELETE FROM `a_setuptargetforproduction` WHERE DATE(`Date`)='" + date + "' AND `Line`='" + lline + "' AND `SO`='" + sso + "' AND `Type`='sew' ;");
                    if (st)
                    {
                        Loadagain();
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

                tbRunDate.Clear();
                tbManTarget.Clear();
                tbManAc.Clear();
                tbJumper.Clear();
                tbHrsTar.Clear();
                tbHrsAc.Clear();
                tbEffPlan.Clear();
                tbEffForecast.Clear();
            }
        }

        private void tbRunDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }


    }
}
