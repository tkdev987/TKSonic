using PTS_For_Cut.Myclass;

namespace PTS_For_Cut._6Sewing
{
    public partial class CheckConfirmBD : Form
    {
        public CheckConfirmBD()
        {
            InitializeComponent();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CheckConfirmBD_Load(object sender, EventArgs e)
        {
            lbDate.Text = SewingReport.ins.DateOnly;
            ConnectMySQL.DisplayAndSearch("SELECT `sb_id`,`sb_scantime` AS `Time Scan` , `sb_qrcodebundle`AS `QRCode Bundle`, `sb_bundleno`AS `Bundle No`, `sb_color`AS `Color`, `sb_size`AS `Size`, `sb_qty`AS `QTY`,  `sb_lineno`AS `LINE`," +
                "`SupCh` AS `SupCheck`,`FinalCh` AS `FinalCheck` FROM `b_scaned_bundle` WHERE `sb_qrcodebundle`LIKE '" + SewingReport.ins.BundleNo + "'", gvDis);
            this.ActiveControl = btConfirm;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private string dateConvert(string txt)
        {
            string txtDate = "";
            System.Globalization.CultureInfo _cultureEnInfo = new System.Globalization.CultureInfo("en-US");
            DateTime dateEng = Convert.ToDateTime(txt, _cultureEnInfo);
            txtDate = dateEng.ToString("yyyy-MM-dd", _cultureEnInfo);
            return txtDate;
        }
        private void btConfirm_Click(object sender, EventArgs e)
        {
            string txtColumn = "";
            string txtColumninDB = "";
            if (SewingReport.ins.confirmMode == "supCon")
            {
                txtColumn = "SupCheck";
                txtColumninDB = "SupCh";
            }
            else if (SewingReport.ins.confirmMode == "LastCon")
            {
                txtColumn = "FinalCheck";//FinalCh
                txtColumninDB = "FinalCh";
            }
            int xi = -1;
            if ((RowIndexx > -1) && gvDis.Rows.Count > 1)
            {
                xi = RowIndexx;
            }
            else
            {
                xi = 0;
            }
            //  MessageBox.Show(dateConvert(lbConfirmDate.Text)+"||"+ dateConvert(gvDis.Rows[xi].Cells["Time Scan"].Value.ToString()));
            if (lbDate.Text == dateConvert(gvDis.Rows[xi].Cells["Time Scan"].Value.ToString()))
            {
                if (gvDis.Rows.Count == 1)
                {
                    bool ch = !Convert.ToBoolean(gvDis.Rows[0].Cells[txtColumn].Value.ToString());
                    int x = 0;
                    if (ch)
                    {
                        x = 1;
                    }
                    string no = gvDis.Rows[0].Cells["sb_id"].Value.ToString();
                    ConnectMySQL.MysqlQuery("UPDATE `b_scaned_bundle` SET`" + txtColumninDB + "`='" + x + "' WHERE `sb_id`=" + no);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    if (RowIndexx > -1)
                    {
                        bool ch = !Convert.ToBoolean(gvDis.Rows[RowIndexx].Cells[txtColumn].Value.ToString());
                        int x = 0;
                        if (ch)
                        {
                            x = 1;
                        }
                        string no = gvDis.Rows[RowIndexx].Cells["sb_id"].Value.ToString();
                        ConnectMySQL.MysqlQuery("UPDATE `b_scaned_bundle` SET`" + txtColumninDB + "`='" + x + "' WHERE `sb_id`=" + no);
                        DialogResult = DialogResult.OK;
                    }
                }
            }
            else
            {
                MessageBox.Show("Date Not Same. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        int RowIndexx = -1;
        private void gvDis_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                RowIndexx = e.RowIndex;
            }
        }
    }
}
