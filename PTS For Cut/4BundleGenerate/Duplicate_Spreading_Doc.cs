using PTS_For_Cut.Myclass;

namespace PTS_For_Cut._4BundleGenerate
{
    public partial class Duplicate_Spreading_Doc : Form
    {
        public Duplicate_Spreading_Doc()
        {
            InitializeComponent();
        }

        private void Duplicate_Spreading_Doc_Load(object sender, EventArgs e)
        {
            btOk.Enabled = false;
        }

        private void btTransfer_Click(object sender, EventArgs e)
        {
            if (tbMaster.Text.Length > 10 && tbClone.Text.Length > 10)
            {
                bool st = ConnectMySQL.MysqlQuery(@" DELETE FROM `a_a3_scandoc_sd_ct_tb` WHERE `SD_ListDoc_No` LIKE '" + tbClone.Text + @"' ;
            INSERT INTO `a_a3_scandoc_sd_ct_tb`(`SD_ListDoc_No`, `wh_scanout`, `SD_ScanIn`, `SD_ScanOut`, `Cut_ScanIn`, `Cut_ScanOut`, `ID_fabric_call`) 
            SELECT '" + tbClone.Text + @"', `wh_scanout`, `SD_ScanIn`, `SD_ScanOut`, `Cut_ScanIn`, `Cut_ScanOut`,NULL FROM `a_a3_scandoc_sd_ct_tb` 
            WHERE `SD_ListDoc_No` LIKE '" + tbMaster.Text + @"';

            DELETE FROM `a_a4_sd_scanout_qty_tb` WHERE `SD_ListDoc_No` LIKE '" + tbClone.Text + @"';
            INSERT INTO `a_a4_sd_scanout_qty_tb`(`No`, `SD_ListDoc_No`, `Line`, `Plies`, `Size`, `RatioQTY`, `QTY`) 
            SELECT NULL,'" + tbClone.Text + @"' , `Line`, `Plies`, `Size`, `RatioQTY`, `QTY` FROM `a_a4_sd_scanout_qty_tb` WHERE `SD_ListDoc_No` LIKE '" + tbMaster.Text + @"';

            DELETE FROM `c_wh1_bc_sdactual_tb` WHERE `SD_ListDoc_No` LIKE '" + tbClone.Text + @"';
            INSERT INTO `c_wh1_bc_sdactual_tb`(`BcID`, `Barcode`, `CreateDate`, `Qty`, `QtyNet`, `YardNet`, `SD_ListDoc_No`, `Plies`, `PliesActual`, 
            `RestFabric`, `Defect`, `LappingFabric`, `ShortageInRoll`, `IndexSort`, `SeparateStatus`, `LastActive`, `Remark`, `Not_Calculate`) 
            SELECT NULL, `Barcode`, `CreateDate`, `Qty`, `QtyNet`, `YardNet`,'" + tbClone.Text + @"' , `Plies`, `PliesActual`, `RestFabric`, `Defect`, `LappingFabric`, 
            `ShortageInRoll`, `IndexSort`, `SeparateStatus`, `LastActive`, `Remark`, `Not_Calculate` FROM `c_wh1_bc_sdactual_tb` WHERE `SD_ListDoc_No` LIKE '" + tbMaster.Text + @"';");
                if (st)
                {
                    btOk.Enabled = true;
                    btTransfer.BackColor = Color.Green;
                    MessageBox.Show("OK");
                }
                else
                    MessageBox.Show("!!!!!!!!!!! Error !!!!!!!!!!!!");

            }
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            btTransfer.BackColor = Color.DarkGray;
            this.Close();
        }
    }
}
