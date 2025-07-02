using PTS_For_Cut.Main;
using PTS_For_Cut.myClass;
using PTS_For_Cut.Myclass;
using System.Data;

namespace PTS_For_Cut._4BundleGenerate
{
    public partial class BDSeparate : Form
    {
        public BDSeparate()
        {
            InitializeComponent();
        }
        string Group_work = "";
        DateTimePicker dtpCreate = new DateTimePicker();
        private void BDSeparate_Load(object sender, EventArgs e)
        {
            dtpCreate.Value = DateTime.Now;
            Group_work = Properties.Settings.Default.workGroup;
            lbHeader.Text = lbHeader.Text + " : " + HomePage.ins.BundleNo_Adjust;
            SetUpPosition.CenterLabelInPanel(lbHeader, pnHeader);
            //
            string txtSQL = @"SELECT  `QRCodeBundle`, `SD_ListDoc_No`, `SO`,`BundleNo`, `Color`, `Size`, `ClothingPart`, `MainPart`, `Deco`,  `QTY`
                            FROM `a_b1_bundle_tb` WHERE `SD_ListDoc_No`= '" + HomePage.ins.ID_for_CreateBundle + "' AND `BundleNo` = '" + HomePage.ins.BundleNo_Adjust + "'";

            ConnectMySQL.DisplayAndSearch(txtSQL, gvOld);
            gvOld.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gvNew.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        private void btcreateNew_Click(object sender, EventArgs e)
        {
            if (gvOld.Rows.Count > 0)
            {
                if (tbQTY.Text.Length > 0)
                {
                    int qtyOld = int.Parse(gvOld.Rows[0].Cells["QTY"].Value.ToString());
                    int qtyAdj = int.Parse(tbQTY.Text);

                    if (qtyAdj > 0)
                    {
                        if (qtyOld > 0)
                        {
                            if (qtyAdj <= qtyOld)
                            {

                                string group = Group_work.Substring(0, 1).ToUpper();
                                string searchFil = "BD" + group;
                                string QrCodeBundle = Calculate.DocNoAutoGen("SELECT `QRCodeBundle`  FROM `a_b1_bundle_tb` WHERE `QRCodeBundle`LIKE '" + searchFil + "%'  ORDER BY `QRCodeBundle` DESC LIMIT 1;", "BD" + Group_work.Substring(0, 1).ToUpper(), dtpCreate);
                                int numRun = int.Parse(QrCodeBundle.Substring(7, 6)) - 1;

                                int xx = qtyOld - qtyAdj;

                                foreach (DataGridViewRow row in gvOld.Rows)
                                {
                                    if (!row.IsNewRow)
                                    {
                                        row.Cells["QTY"].Value = xx;


                                    }
                                }

                                gvNew.Columns.Clear();
                                gvNew.DataSource = null;

                                DataTable dt = new DataTable();
                                int columnCount = gvOld.Columns.Count;

                                // Create columns (same as gvOld)
                                for (int i = 0; i < columnCount; i++)
                                {
                                    dt.Columns.Add(gvOld.Columns[i].Name, gvOld.Columns[i].ValueType);
                                }


                                string query1 = @"
                                    SELECT a.BundleNo
                                    FROM a_b1_bundle_tb a
                                    JOIN a_a1_spreading_list_tb b ON b.SD_ListDoc_No = a.SD_ListDoc_No
                                    AND b.SO LIKE '"+ gvOld.Rows[0].Cells["SO"].Value.ToString() + @"'
                                    WHERE MainPart = '1' 
                                    ORDER BY                                      
                                      a.BundleNo DESC
                                    LIMIT 1;";

                        

                                string BD_NO_FromDB = ConnectMySQL.Subtext(query1);
                                int bundleNo = Calculate.BundleAutoGen(BD_NO_FromDB);
                                bundleNo++;
                                foreach (DataGridViewRow row in gvOld.Rows)
                                {
                                    if (!row.IsNewRow)
                                    {
                                        object[] rowData = new object[columnCount];

                                        // Set new values for first and last column
                                        numRun += 1;
                                        string QR_CodeBundle = "BD" + Group_work.Substring(0, 1).ToUpper() + QrCodeBundle.Substring(3, 4) + numRun.ToString("######000000");
                                        rowData[0] = QR_CodeBundle;  // First column (custom value)
                                        rowData[^1] = tbQTY.Text;  // Last column (custom value)

                                        // Copy data for the middle columns (excluding first and last)
                                        for (int i = 1; i < columnCount - 1; i++)
                                        {
                                            if (gvOld.Columns[i].HeaderText == "BundleNo")
                                            {
                                                rowData[i] = group + bundleNo; //group
                                            }
                                            else
                                            {
                                                rowData[i] = row.Cells[i].Value;
                                            }
                                        }

                                        dt.Rows.Add(rowData);
                                    }
                                }

                                gvNew.DataSource = dt;

                            }
                            else
                            {
                                MessageBox.Show("The new QTY must be lower than the old QTY.", "Imformation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("The old QTY must be more than zero.", "Imformation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        MessageBox.Show("The separated QTY must be more than zero.", "Imformation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Should enter a value.", "Imformation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Data not available.", "Imformation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void tbQTY_KeyPress(object sender, KeyPressEventArgs e)
        {
            // อนุญาตเฉพาะตัวเลข (0-9), + และ -
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // ป้องกันอักขระที่ไม่ต้องการ
            }

        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (gvNew.Rows.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to save data?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    string insertMultiValue = "";
                    bool first = false;
                    for (int i = 0; i < gvNew.Rows.Count; i++) //`QRCodeBundle`, `SD_ListDoc_No`, `SO`,`BundleNo`, `Color`, `Size`, `ClothingPart`, `MainPart`, `Deco`,  `QTY`
                    {
                        var gv = gvNew.Rows[i];
                        string QRcodeBundle = gv.Cells["QRCodeBundle"].Value.ToString();
                        string SD_ListDoc_No = gv.Cells["SD_ListDoc_No"].Value.ToString();
                        string so = gv.Cells["SO"].Value.ToString();
                        string bundleNo = gv.Cells["BundleNo"].Value.ToString();
                        string Color = gv.Cells["Color"].Value.ToString();
                        string Size = gv.Cells["Size"].Value.ToString();
                        string Clothing_Part = gv.Cells["ClothingPart"].Value.ToString();
                        string Plies = "";
                        string QTY = gv.Cells["QTY"].Value.ToString();//,`BarcodeRef`                       
                        string MainPart = gv.Cells["MainPart"].Value.ToString();

                        //if (Convert.ToBoolean(gvNew.Rows[i].Cells["MainPart"].Value.ToString()))
                        //{
                        //    MainPart = "1";
                        //}
                        string Dec = "NULL";
                        if (gvNew.Rows[i].Cells["Deco"].Value.ToString() != "")
                        {
                            Dec = gvNew.Rows[i].Cells["Deco"].Value.ToString() ;
                        }
                        if (!first)
                        {
                            insertMultiValue = "('NULL', '" + QRcodeBundle + "','" + SD_ListDoc_No + "','" + bundleNo + "','" + Color + "','" + Size + "','" + Clothing_Part + "','" + Plies + "','" + QTY + "','" + MainPart + "','" + Dec + "','" + so + "')";//selectFabricType
                            first = true;
                        }
                        else
                        {
                            insertMultiValue = insertMultiValue + ",('NULL', '" + QRcodeBundle + "','" + SD_ListDoc_No + "','" + bundleNo + "','" + Color + "','" + Size + "','" + Clothing_Part + "','" + Plies + "','" + QTY + "','" + MainPart + "','" + Dec + "','" + so + "')";
                        }
                    }
                    if (insertMultiValue != "")
                    {
                        string sqlUpdateQty = @"
                                         UPDATE a_b1_bundle_tb
                                        SET QTY = QTY - '" + tbQTY.Text + @"'
                                        WHERE SD_ListDoc_No = '" + HomePage.ins.ID_for_CreateBundle + @"' 
                                                AND BundleNo = '" + HomePage.ins.BundleNo_Adjust + "'; ";

                        string sqlInsert = "INSERT INTO `a_b1_bundle_tb`(`Bundle_ID`, `QRCodeBundle`, `SD_ListDoc_No`,`BundleNo`, `Color`,`Size`, `ClothingPart`, `Plies`, `QTY`,`MainPart`,`Deco`,`SO`)" +//BarcodeRef
                             "VALUES" + insertMultiValue + "; ";

                        bool state = ConnectMySQL.MysqlQuery(sqlInsert + sqlUpdateQty);     
                        if (state)
                        {
                           
                            DialogResult = DialogResult.OK;

                        }
                        else
                        {
                            MessageBox.Show("Bundle Can't Save Data to DB", "Can't Save",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Generate Bundle Before Save Data.");
            }
        }
    }
}
