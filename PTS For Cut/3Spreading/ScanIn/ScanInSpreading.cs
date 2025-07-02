using PTS_For_Cut.Main;
using PTS_For_Cut.Myclass;

namespace PTS_For_Cut.Spreading.ScanIn
{
    public partial class ScanInSpreading : Form
    {
        public string DocNo = "";
        public static ScanInSpreading ins;
        public ScanInSpreading()
        {
            InitializeComponent();
            ins = this;
        }
        private void Search()
        {
            pnST.Visible = false;
            ConnectMySQL.db = "pts_db";
            if (HomePage.ins.sdDataScan == "ScanInSD")
            {
                string dbScan = ConnectMySQL.Subtext("SELECT `SD_ListDoc_No` FROM `a_a3_scandoc_sd_ct_tb` " +
                   "WHERE `SD_ListDoc_No`='" + tbScan1.Text + "'AND `wh_scanout` IS NOT NULL AND `SD_ScanIn` IS NULL;");
                string tbS = "xx";
                if (tbScan1.Text != "")
                {
                    tbS = tbScan1.Text;
                }
                if (dbScan == tbS)
                {
                    using (sdShowData di = new sdShowData())
                    {
                        DocNo = tbScan1.Text;
                        if (di.ShowDialog() == DialogResult.OK)
                        {
                            this.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Can't Scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    StatusSD();
                }

            }
            else if (HomePage.ins.sdDataScan == "ScanOutSD")
            {
                string dbScan = ConnectMySQL.Subtext("SELECT `SD_ListDoc_No` FROM `a_a3_scandoc_sd_ct_tb` " +
                    "WHERE `SD_ListDoc_No`='" + tbScan1.Text + "'AND `SD_ScanIn` IS NOT NULL AND `SD_ScanOut` IS NULL;");
                string tbS = "xx";
                if (tbScan1.Text != "")
                {
                    tbS = tbScan1.Text;
                }
                if (dbScan == tbS)
                {
                    using (sdShowData di = new sdShowData())
                    {
                        DocNo = tbScan1.Text;
                        if (di.ShowDialog() == DialogResult.OK)
                        {
                            this.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Can't Scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    StatusSD();
                }
            }
            else if (HomePage.ins.sdDataScan == "ScanInCut")//`Cut_ScanIn`, `Cut_ScanOut` 
            {
                string dbScan = ConnectMySQL.Subtext("SELECT `SD_ListDoc_No` FROM `a_a3_scandoc_sd_ct_tb` WHERE `SD_ListDoc_No`='" + tbScan1.Text + "'" +
                    "AND `SD_ScanIn` IS NOT NULL AND `SD_ScanOut` IS NOT NULL AND `Cut_ScanIn`IS NULL;");
                string tbS = "xx";
                if (tbScan1.Text != "")
                {
                    tbS = tbScan1.Text;
                }
                if (dbScan == tbS)
                {
                    using (sdShowData di = new sdShowData())
                    {
                        DocNo = tbScan1.Text;
                        if (di.ShowDialog() == DialogResult.OK)
                        {
                            this.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Can't Scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    StatusSD();
                }
            }
            else if (HomePage.ins.sdDataScan == "ScanOutCut")
            {
                string dbScan = ConnectMySQL.Subtext("SELECT `SD_ListDoc_No` FROM `a_a3_scandoc_sd_ct_tb` WHERE `SD_ListDoc_No`='" + tbScan1.Text + "'" +
                    "AND `SD_ScanIn` IS NOT NULL AND `SD_ScanOut` IS NOT NULL " +
                    "AND `Cut_ScanIn` IS NOT NULL AND `Cut_ScanOut` IS NULL");
                string tbS = "xx";
                if (tbScan1.Text != "")
                {
                    tbS = tbScan1.Text;
                }
                if (dbScan == tbS)
                {
                    using (sdShowData di = new sdShowData())
                    {
                        DocNo = tbScan1.Text;
                        if (di.ShowDialog() == DialogResult.OK)
                        {
                            this.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Can't Scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    StatusSD();
                }
            }
            else if (HomePage.ins.sdDataScan == "EditData")
            {
                string dbScan = ConnectMySQL.Subtext("SELECT `SD_ListDoc_No` FROM `a_a3_scandoc_sd_ct_tb` WHERE `SD_ListDoc_No`='" + tbScan1.Text + "'");
                if (dbScan != "")
                {
                    using (sdShowData di = new sdShowData())
                    {
                        DocNo = tbScan1.Text;
                        if (di.ShowDialog() == DialogResult.OK)
                        {
                            this.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Don't Have Spreading Document.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void StatusSD()
        {
            pnST.Visible = true;
            ConnectMySQL.DisplayAndSearch("SELECT " +
                   "CASE " +
                        "WHEN `C`.`wh_scanout` IS NOT NULL THEN 'Done' " +
                        "ELSE NULL " +
                    "END AS `WH Scanout`, " +
                    "CASE " +
                        "WHEN `C`.`SD_ScanIn` IS NOT NULL THEN 'Done' " +
                        "ELSE NULL " +
                    "END AS `SD ScanIn`, " +
                    "CASE " +
                        "WHEN `C`.`SD_ScanOut` IS NOT NULL THEN 'Done' " +
                        "ELSE NULL " +
                    "END AS `SD ScanOut`, " +
                    "CASE " +
                        "WHEN `C`.`Cut_ScanIn` IS NOT NULL THEN 'Done' " +
                        "ELSE NULL " +
                    "END AS `Cut ScanIn`, " +
                    "CASE " +
                        "WHEN `C`.`Cut_ScanOut` IS NOT NULL THEN 'Done' " +
                        "ELSE NULL " +
                    "END AS `Cut ScanOut` " +
                 "FROM `a_a3_scandoc_sd_ct_tb` AS `C` WHERE `C`.`SD_ListDoc_No` LIKE '" + tbScan1.Text + "' ", gvSDStatus);
        }
        private void ScanInSpreading_Load(object sender, EventArgs e)
        {
            if (HomePage.ins.sdDataScan == "ScanInSD")
            {
                lbHeadText.Text = "Scan In Spreading";
            }
            else if (HomePage.ins.sdDataScan == "ScanOutSD")
            {
                lbHeadText.Text = "Scan Out Spreading";
            }
            else if (HomePage.ins.sdDataScan == "ScanInCut")//`Cut_ScanIn`, `Cut_ScanOut` 
            {
                lbHeadText.Text = "Scan In Cutting";
            }//EditData
            else if (HomePage.ins.sdDataScan == "ScanOutCut")
            {
                lbHeadText.Text = "Scan Out Cutting";
            }
            else if (HomePage.ins.sdDataScan == "EditData")
            {
                lbHeadText.Text = "Edit Data";
            }
        }
        private void tbScan1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tbScan1.Text != "")
                {
                    Search();
                }
            }
        }
        private void btOk1_Click(object sender, EventArgs e)
        {
            if (tbScan1.Text != "")
            {
                Search();
            }
        }
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
