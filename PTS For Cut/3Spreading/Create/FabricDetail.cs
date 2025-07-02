using PTS_For_Cut.Myclass;
using PTS_For_Cut.Spreading.Create;

namespace PTS_For_Cut._3Spreading.Create
{
    public partial class FabricDetail : Form
    {
        public FabricDetail()
        {
            InitializeComponent();
        }
        string so = "";
        private void FabricDetail_Load(object sender, EventArgs e)
        {
            so = ImportCutPlan.ins.rSO;
            lbLabelHeader.Text = "Detail Fabric Of " + so;
            ConnectMySQL.DisplayAndSearch("SELECT `a`.`LotNo`, (`b`.`DirectionIQC`) AS `Relax` , `a`.`FabricType` , (SELECT COUNT(`w`.`Barcode`) FROM `c_warehouse1_bc_tb` AS `w` " +
                "WHERE `a`.`LotNo`=`w`.`LotNo` ) AS `Total (ROLL)` , (SELECT SUM(`m`.`Qty`) FROM `c_warehouse1_bc_tb` AS `m` WHERE `a`.`LotNo`=`m`.`LotNo` ) AS ` Total Length` " +
                ",`a`.`Unit`, (SELECT COUNT(`q`.`Barcode`) FROM `c_warehouse1_bc_tb` AS `q` WHERE `a`.`LotNo`=`q`.`LotNo` AND `q`.`YardNet` !=0 ) AS `Inspect (ROLL)` , " +
                "COUNT(`c`.`Barcode`) AS `Usage (ROLL)` , (SELECT SUM(`n`.`YardNet`) FROM `c_warehouse1_bc_tb` AS `n` WHERE `a`.`LotNo`=`n`.`LotNo` ) AS `Length Usage (YDS)` " +
                "FROM `c_warehouse1_bc_tb` AS `a` JOIN `c_warehouse2_so_tb` AS `b` ON `a`.`LotNo`=`b`.`LotNo` AND `b`.`So`='" + so + "'" +
                "LEFT JOIN `c_wh1_bc_sdactual_tb` AS `c` ON `c`.`Barcode`=`a`.`Barcode` GROUP BY `a`.`FabricType`,`a`.`LotNo`;", gvDis);

        }
    }
}
