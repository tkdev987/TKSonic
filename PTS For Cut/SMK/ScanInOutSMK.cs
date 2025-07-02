using PTS_For_Cut.Myclass;
using System.Data;

namespace PTS_For_Cut.SMK
{
    public partial class ScanInOutSMK : Form
    {
        DataTable dtQrCodeBundleRef = new DataTable();
        public ScanInOutSMK()
        {
            InitializeComponent();
        }

        private void btAddBD_Click(object sender, EventArgs e)
        {
            if (gvBundleDetail.Rows.Count == 0)
            {
                //dtQrCodeBundleRef = ConnectMySQL.MySQLtoDataTable("SELECT ROW_NUMBER() OVER(ORDER BY  `Bundle_ID`) AS `No`, `QRCodeBundle`, `SD_ListDoc_No`, `BundleNo`, `Color`, " +
                //    "`Size`, `ClothingPart`, `MainPart`, `QTY`, `Deco` FROM `a_b1_bundle_tb` WHERE `QRCodeBundle`='" + tbQrBundle.Text + "';");
                //CreateColumn();
                //bundleScanIn();
            }
            else
            {
                // bundleScanIn();
            }
        }
        private void CreateColumn()
        {
            gvBundleDetail.Columns.Add("No", "No");
            gvBundleDetail.Columns.Add("Bundle ID", "Bundle ID");
            gvBundleDetail.Columns.Add("Color", "Color");
            gvBundleDetail.Columns.Add("Size", "Size");//
            gvBundleDetail.Columns.Add("ClothingPart", "ClothingPart");
            gvBundleDetail.Columns.Add("Main Part", "Main Part");
            gvBundleDetail.Columns.Add("QTY", "QTY");
            gvBundleDetail.Columns.Add("Decoration", "Decoration");
            gvBundleDetail.Columns.Add("Location", "Location");
            //  gvBundleDetail.Columns.Add("No", "No");
            // gvBundleDetail.Columns.Add("No", "No");

        }
        private void bundleScanIn()
        {
            if (dtQrCodeBundleRef.Rows.Count > 0)
            {
                ////DataRow[] dr = dtQrCodeBundleRef.Select("QRCodeBundle = " + tbQrBundle.Text);
                //DataRow[] dr = dtQrCodeBundleRef.Select(string.Format("QRCodeBundle ='{0}' ", tbQrBundle.Text));
                //DataTable dt = new DataTable();
                //dt = (DataTable)gvBundleDetail.DataSource;
                ////object[] arr1 = dt.Rows[RowFabIndex].ItemArray;
                //dt.Rows.Add(dr);
            }

        }
        private void gvBundleDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ScanInOutSMK_Load(object sender, EventArgs e)
        {
            cbbDec1.Items.Clear();
            for (int i = 0; i < Login.ins.dtDecoration.Rows.Count; i++)
            {
                cbbDec1.Items.Add(Login.ins.dtDecoration.Rows[i]["Dec_Eng"].ToString());
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbbDec1_Click(object sender, EventArgs e)
        {

        }

        private void btScan_Click(object sender, EventArgs e)
        {
            if (gvBundleDetail.Rows.Count == 0)
            {
                ConnectMySQL.DisplayAndSearch("WITH CountedBundles AS ( " +
                    "SELECT " +
                    "`QrcodeBD`," +
                            " COUNT(*) AS `BundleCount`" +
                        " FROM " +
                            " `a_b1_bundle_to_dec_tb`" +
                        " GROUP BY " +
                            " `QrcodeBD`" +
                    " )," +
                    " LastDecoration AS (" +
                        " SELECT " +
                            " `QrcodeBD`," +
                            " `QTY` AS `QTY_Decoration`" +
                        " FROM (" +
                            " SELECT " +
                                " `QrcodeBD`, " +
                                " `QTY`, " +
                                " ROW_NUMBER() OVER (PARTITION BY `QrcodeBD` ORDER BY `TimeScan` DESC) AS `rn`" +
                            " FROM " +
                                " `a_b1_bundle_to_dec_tb`" +
                            " WHERE " +
                                " `Decoration` LIKE 'Printing' " +
                                " AND `stINOUT` = 0" +
                        " ) AS sub" +
                        " WHERE `sub`.`rn` = 1" +
                   "  )," +
                    " LastDecorationIN AS (" +
                        " SELECT " +
                            " `QrcodeBD`," +
                            " `QTY` AS `QTY_DecorationIN`" +
                        " FROM (" +
                            " SELECT " +
                                " `QrcodeBD`, " +
                                " `QTY`, " +
                                " ROW_NUMBER() OVER (PARTITION BY `QrcodeBD` ORDER BY `TimeScan` DESC) AS `rn`" +
                           "  FROM " +
                                " `a_b1_bundle_to_dec_tb`" +
                            " WHERE " +
                                " `Decoration` LIKE 'Printing' " +
                                " AND `stINOUT` = 1" +
                        " ) AS sub" +
                        " WHERE `sub`.`rn` = 1" +
                    " )" +
                    " SELECT " +
                        " `a`.`QRCodeBundle`, " +
                        " `a`.`SD_ListDoc_No`, " +
                        " `b`.`SO`, " +
                        " `a`.`BundleNo`, " +
                        " `a`.`Color`, " +
                        " `a`.`Size`, " +
                        " `a`.`ClothingPart`, " +
                        " `a`.`QTY`, " +
                        " `a`.`Deco`, " +
                        " `a`.`SMKcheck`," +
                       "  IF(`cb`.`BundleCount` % 2 = 0, IFNULL(`ld`.`QTY_Decoration`, 0), 0) AS `QTY_Decoration`," +
                        " IF(`cb`.`BundleCount` % 2 = 1, IFNULL(`ldi`.`QTY_DecorationIN`, 0), IFNULL(`ldi`.`QTY_DecorationIN`, 0)) AS `QTY_DecorationIN`" +
                    " FROM " +
                        " `a_b1_bundle_tb` AS `a`" +
                    " JOIN " +
                        " `a_a1_spreading_list_tb` AS `b`" +
                       " ON `a`.`SD_ListDoc_No` = `b`.`SD_ListDoc_No`" +
                    " LEFT JOIN " +
                        " `CountedBundles` AS `cb`" +
                        " ON `a`.`QRCodeBundle` = `cb`.`QrcodeBD`" +
                    " LEFT JOIN " +
                        " `LastDecoration` AS `ld`" +
                       "  ON `a`.`QRCodeBundle` = `ld`.`QrcodeBD`" +
                    " LEFT JOIN " +
                        " `LastDecorationIN` AS `ldi`" +
                        " ON `a`.`QRCodeBundle` = `ldi`.`QrcodeBD`" +
                    " WHERE " +
                        " `a`.`SD_ListDoc_No` LIKE (" +
                            " SELECT " +
                             "    `c`.`SD_ListDoc_No`" +
                           "  FROM " +
                            "     `a_b1_bundle_tb` AS `c`" +
                           "  WHERE " +
                                " `c`.`QRCodeBundle` LIKE 'BDD2403000019'" +
                        " );", gvBundleDetail);

                searchInGV();
            }
            else
            {
                searchInGV();
            }
        }
        int indexRow = -1;
        private void searchInGV()
        {
            if (gvBundleDetail.Rows.Count > 0)
            {
                gvBundleDetail.ClearSelection();
                int countScanned = 0;
                for (int i = 0; i < gvBundleDetail.Rows.Count; i++)
                {
                    if (gvBundleDetail.Rows[i].Selected)
                    {
                        gvBundleDetail.Rows[i].Selected = false;
                    }
                    if (gvBundleDetail.Rows[i].Cells["QRCodeBundle"].Value != null && gvBundleDetail.Rows[i].Cells["QRCodeBundle"].Value.ToString().Contains(tbQrCode.Text))
                    {
                        gvBundleDetail.Rows[i].Selected = true;
                        gvBundleDetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        gvBundleDetail.FirstDisplayedScrollingRowIndex = i;
                        gvBundleDetail.Rows[i].Cells["SMKcheck"].Value = true;

                        indexRow = i;

                    }
                    else
                    {
                        gvBundleDetail.Rows[i].Selected = false;
                    }
                    if (Convert.ToBoolean(gvBundleDetail.Rows[i].Cells["SMKcheck"].Value.ToString()))
                    {
                        countScanned++;

                    }
                }
                if (indexRow > -1)
                {
                    if (gvBundleDetail.Rows[indexRow].Selected)
                    {
                        lbClothingPart.Text = gvBundleDetail.Rows[indexRow].Cells["ClothingPart"].Value.ToString();
                        numQTY.Value = int.Parse(gvBundleDetail.Rows[indexRow].Cells["QTY"].Value.ToString());

                    }
                }
                lbAllBundle.Text = gvBundleDetail.Rows.Count.ToString();
                lbBundleScanned.Text = countScanned.ToString();
            }
        }
        private void cbbDec1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbDec1.SelectedIndex == 0)
            {
                DataTable Loc = ConnectMySQL.MySQLtoDataTable("SELECT  `Location` FROM `location_tb` WHERE `LocationGroup` LIKE '" + cbbDec1.Text + "';");
                for (int i = 0; i < Loc.Rows.Count; i++)
                {
                    cbbLocation1.Items.Add(Loc.Rows[i]["Location"].ToString());
                }
            }
        }

        private void btQty_Click(object sender, EventArgs e)
        {
            if (numQTY.Value > -1)
            {
                gvBundleDetail.Rows[indexRow].Cells["QTY"].Value = numQTY.Value;
                tbQrCode.Focus();
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {

        }
    }
}
