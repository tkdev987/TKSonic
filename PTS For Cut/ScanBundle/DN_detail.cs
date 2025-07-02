using PTS_For_Cut.Myclass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTS_For_Cut.ScanBundle
{
    public partial class DN_detail : Form
    {
        public DN_detail()
        {
            InitializeComponent();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            search();
        }

        private void search()
        {
            if (tbSearch.Text.Length > 5)
            {

                string dn = "";
                string bd = "";
                if (tbSearch.Text.Substring(0, 2) == "DN")
                {
                    dn = tbSearch.Text;
                }
                else if (tbSearch.Text.Substring(0, 2) == "BD")
                {
                    bd = tbSearch.Text;
                }
                if (dn.Length > 0 || bd.Length > 0)
                {
                    string sql = @"
                            SELECT `DeliveryNoteID`, `QrcodeBD`, `Decoration`, `Dec_Out`, `Location`, `TimeScan`, `QTY`, 
                            `stINOUT`, `SD_ListDoc_No`, `ClothingPart`, `MainPart`, `SO`, `FabricType`, `ch_accept` 
                            FROM `a_b1_bundle_to_dec_tb` 
                            WHERE `QrcodeBD`IN (
                            SELECT `QrcodeBD` WHERE `DeliveryNoteID` LIKE '%" + dn + @"%' AND `QrcodeBD` LIKE '%" + bd + @"%'
                            ) ORDER BY `QrcodeBD`,`TimeScan` ASC;";

                    ConnectMySQL.DisplayAndSearch(sql, gvDis);

                }
            }

        }

        private void DN_detail_Load(object sender, EventArgs e)
        {
            tbSearch.Text = ScanInOutWithSummery.ins.DN_ID;
            search();
        }

        private void tbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                search();
            }
        }
    }
}
