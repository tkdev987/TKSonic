using ExcelDataReader;
using PTS_For_Cut.Main;
using PTS_For_Cut.myClass;
using PTS_For_Cut.Myclass;
using System.Data;

namespace PTS_For_Cut._4BundleGenerate
{
    public partial class DirecBundle : Form
    {
        public DirecBundle()
        {
            InitializeComponent();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            SearchSD();
        }
        private void SearchSD()
        {
            if (tbSearchSD_ID1.Text.Length > 3)
            {
                //HomePage.ins.ID_for_CreateBundle = "ScanOutSD";
                ConnectMySQL.DisplayAndSearch("SELECT `a`.`SD_ListDoc_No`, `a`.`SO`, `a`.`Style`,`a`.`Color`,`d`.`Customer_Style` " +
                    "FROM `a_a1_spreading_list_tb`AS`a` " +
                    "LEFT JOIN `so_tb` AS `d`ON `d`.`So`= `a`.`SO` WHERE `a`.`SD_ListDoc_No`LIKE '" + tbSearchSD_ID1.Text + "' " +
                    "GROUP BY `a`.`SD_ListDoc_No`;", gvDisBundle);
                BundleGen.ins.dtDirectPrint = ConnectMySQL.MySQLtoDataTable("SELECT ROW_NUMBER() OVER(ORDER BY `Bundle_ID`) AS `No.`, " +
                    "`QRCodeBundle`AS `QRCode Bundle`, `BundleNo`AS `Bundle No.`, `Color`, `Size`,`DyeLot`, `ClothingPart`AS `Clothing Part`, " +
                    "`Deco`AS `Decoration`, `Plies`AS`PliesActual`, `MainPart`, `QTY`,`BarcodeRef`  FROM `a_b1_bundle_tb` WHERE `SD_ListDoc_No`='" + tbSearchSD_ID1.Text + "';");
                gvGenBundle.DataSource = BundleGen.ins.dtDirectPrint;
                if (gvDisBundle.Columns.Count > 0)
                {
                    gvDisBundle.Columns["SD_ListDoc_No"].Width = 150;
                    gvDisBundle.Columns["SO"].Width = 150;
                    gvDisBundle.Columns["Style"].Width = 150;//

                }
                // string selectRowSD_ID = "", selectRowStyle = "";
                if (gvDisBundle.Rows.Count == 1)
                {
                    BundleGen.ins.selectRowSD_ID = gvDisBundle.Rows[0].Cells["SD_ListDoc_No"].Value.ToString();
                    HomePage.ins.ID_for_CreateBundle = BundleGen.ins.selectRowSD_ID;
                    BundleGen.ins.selectRowStyle = gvDisBundle.Rows[0].Cells["Style"].Value.ToString();
                    BundleGen.ins.selectRowSO = gvDisBundle.Rows[0].Cells["SO"].Value.ToString();

                }

                if (BundleGen.ins.selectRowSD_ID != "")
                {
                    ConnectMySQL.DisplayAndSearch("SELECT ROW_NUMBER() OVER(ORDER BY `ClothingPartID`) AS `No.`, `Part`, `QTYPart`,`MainPart`,`Decoration` " +
                       "FROM `a_a0clothing_part` WHERE `Style`LIKE '" + BundleGen.ins.selectRowStyle + "'", gvClothingPart);
                }
            }
        }

        private void btExTamp_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("No.");
            dt.Columns.Add("Size");
            dt.Columns.Add("Bundle No.");
            dt.Columns.Add("QTY");

            Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
            xcelApp.Application.Workbooks.Add(Type.Missing);

            for (int i = 1; i < dt.Columns.Count + 1; i++)
            {
                xcelApp.Cells[1, i] = dt.Columns[i - 1].ColumnName;

            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (dt.Rows[i][j] != null)
                    {
                        xcelApp.Cells[i + 2, j + 1] = dt.Rows[i][j].ToString();
                    }
                }
            }
            xcelApp.Columns.AutoFit();
            xcelApp.Visible = true;
        }
        DataTableCollection tableCollection;
        private void btImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Files|*.xls;*.xlsx;*.xlsm;" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    tbFileName1.Text = openFileDialog.FileName;

                    using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                            });
                            tableCollection = result.Tables;
                            comboBox2.Items.Clear();
                            foreach (DataTable table in tableCollection)
                            {
                                comboBox2.Items.Add(table.TableName);
                            }
                        }
                    }
                    comboBox2.SelectedIndex = 0;
                    DataTable dt = tableCollection[comboBox2.SelectedItem.ToString()];
                    gvData.DataSource = dt;
                }
                else
                {
                    // goto jump;
                }
            }
        }
        private string Group_work = "";
        private void btGen_Click(object sender, EventArgs e)
        {
            //dt.Columns.Add("No.");
            //dt.Columns.Add("Size");
            //dt.Columns.Add("Bundle No.");
            //dt.Columns.Add("QTY");
            string sdID = ConnectMySQL.Subtext("SELECT `SD_ListDoc_No` FROM `a_b1_bundle_to_dec_tb` WHERE `SD_ListDoc_No` ='" + tbSearchSD_ID1.Text + "' ORDER BY `SD_ListDoc_No` ASC LIMIT 1");

            if (sdID != tbSearchSD_ID1.Text && gvDisBundle.Rows.Count > 0)
            {


                if (gvGenBundle.Rows.Count > 0)
                {
                    while (gvGenBundle.Rows.Count > 0)
                    {
                        gvGenBundle.Rows.RemoveAt(0);
                    }
                }
                if (gvData.RowCount > 0 && gvClothingPart.RowCount > 0)
                {
                    DataTable dt = new DataTable();
                    dt = BundleGen.ins.dtDirectPrint;
                    string searchFil = "BD" + Group_work.Substring(0, 1).ToUpper();
                    string QrCodeBundle = Calculate.DocNoAutoGen("SELECT `QRCodeBundle`  FROM `a_b1_bundle_tb` WHERE `QRCodeBundle`LIKE '" + searchFil + "%'  ORDER BY `QRCodeBundle` DESC LIMIT 1;", "BD" + Group_work.Substring(0, 1).ToUpper(), dtpCreate);
                    int numRun = int.Parse(QrCodeBundle.Substring(7, 6)) - 1;
                    //int bundleNo = 0;

                    for (int i = 0; i < gvData.RowCount; i++)
                    {
                        for (int j = 0; j < gvClothingPart.RowCount; j++)
                        {
                            string bundleNo = gvData.Rows[i].Cells["Bundle No."].Value.ToString();
                            string RowNo = (dt.Rows.Count + 1).ToString();
                            string color = gvDisBundle.Rows[0].Cells["Color"].Value.ToString();
                            string size = gvData.Rows[i].Cells["Size"].Value.ToString();
                            string part = gvClothingPart.Rows[j].Cells["Part"].Value.ToString();
                            string Dec = gvClothingPart.Rows[j].Cells["Decoration"].Value.ToString();
                            bool mainPart = Convert.ToBoolean(gvClothingPart.Rows[j].Cells["MainPart"].Value.ToString());
                            numRun += 1;
                            string QR_CodeBundle = "BD" + Group_work.Substring(0, 1).ToUpper() + QrCodeBundle.Substring(3, 4) + numRun.ToString("######000000");
                            string QTY = gvData.Rows[i].Cells["QTY"].Value.ToString();
                            dt.Rows.Add(RowNo, QR_CodeBundle, bundleNo, color, size, "", part, Dec, 0, mainPart, QTY);
                        }
                    }
                    BundleGen.ins.checkGenDirectBD = true;
                    gvGenBundle.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("!!!Please Check Data!!!");
                }
            }else
            {
                MessageBox.Show("Bundle already scanned out. Cannot generate again. || ใบปูนี้สแกนงานออกแล้ว ไม่สามารถ ออกสติ๊กเกอร์ใหม่ไม่ได้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DirecBundle_Load(object sender, EventArgs e)
        {
            Group_work = Properties.Settings.Default.workGroup;
            //  MessageBox.Show(Group_work);
        }

        private void btgoPrint_Click(object sender, EventArgs e)
        {
            string dateText = st();
            bool stSQL = ConnectMySQL.MysqlQuery("INSERT INTO `a_a3_scandoc_sd_ct_tb`(`SD_ListDoc_No`, `wh_scanout`, `SD_ScanIn`, `SD_ScanOut`, `Cut_ScanIn`, `Cut_ScanOut`, `ID_fabric_call`) VALUES ('" + tbSearchSD_ID1.Text + "',CURRENT_TIMESTAMP,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP,'0')");
            BundleGen.ins.dtDirectPrint = (DataTable)gvGenBundle.DataSource;
            if (stSQL)
            {

                DialogResult = DialogResult.OK;
            }
            else
            {
                ConnectMySQL.MysqlQuery("UPDATE `a_a3_scandoc_sd_ct_tb` SET `wh_scanout`=CURRENT_TIMESTAMP,`SD_ScanIn`=CURRENT_TIMESTAMP,`SD_ScanOut`=CURRENT_TIMESTAMP,`Cut_ScanIn`=CURRENT_TIMESTAMP,`Cut_ScanOut`=CURRENT_TIMESTAMP WHERE  `SD_ListDoc_No` LIKE '" + tbSearchSD_ID1.Text + "';");

                DialogResult = DialogResult.OK;
            }
        }
        private string st()
        {
            string txtDate = "";
            System.Globalization.CultureInfo _cultureEnInfo = new System.Globalization.CultureInfo("en-US");
            DateTime dateEng = Convert.ToDateTime(DateTime.Now, _cultureEnInfo);
            txtDate = dateEng.ToString("yyyy-MM-dd HH:mm:ss", _cultureEnInfo);
            return txtDate;
        }
    }
}
