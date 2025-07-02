using PTS_For_Cut.Myclass;
using System.Data;

namespace PTS_For_Cut._3Spreading.Report
{
    public partial class FabricUsage : Form
    {
        public FabricUsage()
        {
            InitializeComponent();
        }


        DataTable dtDataFabric = new DataTable();
        //private void getData()
        //{

        //        dtDataFabric = ConnectMySQL.MySQLtoDataTable("SELECT `LotNo`,`Unit` FROM `c_warehouse1_bc_tb` WHERE `Barcode` LIKE '" + tbbarcodeFabric.Text + "';");
        //        tbPO.Text = dtDataFabric.Rows[0]["LotNo"].ToString();
        //        lbUnit1.Text = dtDataFabric.Rows[0]["Unit"].ToString();
        //        lbUnit2.Text = lbUnit1.Text;

        //        lbUnit4.Text = lbUnit1.Text;
        //        lbUnit5.Text = lbUnit1.Text;



        //} DataTable dtStructureRoW = new DataTable();

        private DataTable dtStructureRoW = new DataTable();

        private void FabricUsage_Load(object sender, EventArgs e)
        {
            dtpEnd.Value = DateTime.Now;
            dtpStart2.Value = DateTime.Now;
            tbColor2.Text = CuttingReport.ins.color;
            tbPO.Text = CuttingReport.ins.po;
            tbFBType.Text = CuttingReport.ins.fabricType;
            lbUnit1.Text = CuttingReport.ins.Unit;
            lbUnit2.Text = lbUnit1.Text;

            lbUnit4.Text = lbUnit1.Text;
            lbUnit5.Text = lbUnit1.Text;

            DataTable dt = new DataTable();
            dt = ConnectMySQL.MySQLtoDataTable("SELECT `Color`, `PO`, `startDate`, `endDate`, `FabricType`, `FBReplatement`, " +
                "`FBSpare`, `FBOffcut`, `HemFB`, `Remark` FROM `a_fabric_usage` " +
                "WHERE `SO`LIKE '" + CuttingReport.ins.rSO + "' AND `Color` LIKE '" + tbColor2.Text + "' " +
                "AND `PO` LIKE '" + tbPO.Text + "' AND `FabricType` LIKE '" + tbFBType.Text + "' ");
            tbReplatement.Text = dt.Rows[0]["FBReplatement"].ToString();
            tbSpare.Text = dt.Rows[0]["FBSpare"].ToString();
            tboffcut.Text = dt.Rows[0]["FBOffcut"].ToString();
            dtpStart2.Text = dt.Rows[0]["startDate"].ToString();
            dtpEnd.Text = dt.Rows[0]["endDate"].ToString();
            tbBinding.Text = dt.Rows[0]["HemFB"].ToString();
            tbRemark.Text = dt.Rows[0]["Remark"].ToString();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (tbColor2.Text.Length > 0)
            {
                string startD = setDate(dtpStart2);
                string endD = setDate(dtpEnd);
                ConnectMySQL.MysqlQuery("DELETE FROM `a_fabric_usage` WHERE `So` LIKE '" + CuttingReport.ins.rSO + "' AND `Color` LIKE '" + tbColor2.Text + "' AND `PO` LIKE '" + tbPO.Text + "';");
                ConnectMySQL.MysqlQuery("ALTER TABLE `a_fabric_usage` auto_increment = 1;");
                bool st = ConnectMySQL.MysqlQuery("INSERT INTO `a_fabric_usage`(`id`, `SO`, `Color`, `PO`, `startDate`, `endDate`, `FabricType`, `FBReplatement`, " +
                    "`FBSpare`, `HemFB`, `FBOffcut`,`Remark`) VALUES (NULL,'" + CuttingReport.ins.rSO + "','" + tbColor2.Text + "','" + tbPO.Text + "','" + startD + "'," +
                    "'" + endD + "','" + tbFBType.Text + "','" + tbReplatement.Text + "','" + tbSpare.Text + "','" + tbBinding.Text + "'" +
                    ",'" + tboffcut.Text + "' ,'" + tbRemark.Text + "');");

                if (st)
                {
                    MessageBox.Show("OK", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("!!! Can't save data !!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toolStrip11_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {





        }

        private string setDate(DateTimePicker dtpVal)
        {
            string txtDate = "";
            System.Globalization.CultureInfo _cultureEnInfo = new System.Globalization.CultureInfo("en-US");
            DateTime dateEng = Convert.ToDateTime(dtpVal.Value, _cultureEnInfo);
            txtDate = dateEng.ToString("yyyy-MM-dd", _cultureEnInfo);
            return txtDate;
        }

    }
}
