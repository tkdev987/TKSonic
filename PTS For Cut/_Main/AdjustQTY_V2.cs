using PTS_For_Cut._4BundleGenerate;
using PTS_For_Cut.Main;
using PTS_For_Cut.myClass;
using PTS_For_Cut.Myclass;
using PTS_For_Cut.ScanBundle;
using System.Data;



namespace PTS_For_Cut._Main
{
    public partial class AdjustQTY_V2 : Form
    {
        public AdjustQTY_V2()
        {
            InitializeComponent();
        }

        private void AdjustQTY_V2_Load(object sender, EventArgs e)
        {
            if (!HomePage.ins.Adjust_Show_Mode)
            {
                panel1.Visible = true;

                panel1.Dock = DockStyle.Fill;
                panel2.Visible = false;
                panel2.Dock = DockStyle.None;
            }
            else
            {
                tbSearchHis.Text = BundleGen.ins.selectRowSD_ID;
                panel1.Visible = false;
                panel1.Dock = DockStyle.None;
                panel2.Visible = true;
                panel2.Dock = DockStyle.Fill;
            }
            SetUpPosition.CenterLabelInPanel(lbHeader, pnlbHeader);
            SetUpPosition.CenterLabelInPanel(lbHeader2, pnlbHeader2);
            HomePage.ins.qtyDecrease = 0;
            DataTable dtLine = new DataTable();
            dtLine = Login.ins.Line_dt;
            cbbLine.Items.Clear();
            for (int i = 0; i < dtLine.Rows.Count; i++)
            {

                cbbLine.Items.Add(dtLine.Rows[i]["Line"].ToString());
            }
            cbbDepartment.Items.Clear();
            for (int i = 0; i < Login.ins.dtDecoration.Rows.Count; i++)
            {
                cbbDepartment.Items.Add(Login.ins.dtDecoration.Rows[i]["Dec_Eng"].ToString());

            }

            if (HomePage.ins.departAdjustQTY != string.Empty)
            {
                cbbDepartment.Text = HomePage.ins.departAdjustQTY;
            }

            tbQrCode1.Text = HomePage.ins.QRCODE_Adjust;
            cbbDepartment.Text = HomePage.ins.departAdjustQTY;


            if (cbbDepartment.SelectedIndex > -1 && tbQrCode1.Text != "")
            {
                btSearch1.PerformClick();
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {

        }

        private void pnlbHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tbQTY_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool isEmpty = tbQTY.Text.Length == 0;

            // อนุญาตเฉพาะตัวเลข (0-9), + และ -
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+' && e.KeyChar != '-')
            {
                e.Handled = true; // ป้องกันอักขระที่ไม่ต้องการ
            }
            // ถ้าช่องว่าง ต้องเป็น + หรือ - เท่านั้น
            if (isEmpty && (e.KeyChar != '+' && e.KeyChar != '-'))
            {
                e.Handled = true;
            }
            // ถ้าไม่ใช่ช่องว่าง (พิมพ์อะไรมาแล้ว) ห้ามพิมพ์ + หรือ - ซ้ำ
            if (!isEmpty && (e.KeyChar == '+' || e.KeyChar == '-'))
            {
                e.Handled = true;
            }
        }

        private void btSearch1_Click(object sender, EventArgs e)
        {

            if (cbbDepartment.SelectedIndex > -1 && tbQrCode1.Text != "")
            {
                string txtSql = string.Empty;
                string txtError = string.Empty;

                if (cbbDepartment.Text == "Cutting")
                {
                    string checkBD = ConnectMySQL.Subtext("SELECT `QrcodeBD`FROM `a_b1_bundle_to_dec_tb` WHERE `QrcodeBD`='" + tbQrCode1.Text + "' ORDER BY `QrcodeBD` ASC LIMIT 1");
                    if (checkBD == "")
                    {
                        txtSql = @"SELECT
                                        a.`QRCodeBundle`,
                                        a.`SD_ListDoc_No`,
                                        a.`SO`,
                                        a.`BundleNo`,
                                        (a.QTY ) AS QTY
                                    FROM `a_b1_bundle_tb` a
                                    WHERE a.`MainPart` = 1 AND a.`QRCodeBundle` LIKE '" + tbQrCode1.Text + "';";

                    }
                    else
                    {
                        txtError = "This bundle has already been scanned for decoration.";
                        this.Close();
                    }
                    if (txtSql.Length > 0)
                    {
                        ConnectMySQL.DisplayAndSearch(txtSql, gvDis);


                    }

                    else
                    {
                        MessageBox.Show("Can't Adjust Qty " + txtError);
                    }
                }
                else if (cbbDepartment.Text != "Cutting" && cbbDepartment.Text != "Sewing")
                {
                    //dtQRData
                    gvDis.DataSource = ScanInOutWithSummery.ins.dtQRData;
                }
                if (gvDis.Rows.Count > 0)
                {
                    HomePage.ins.QRCODE_Adjust = "";
                    HomePage.ins.BundleNo_Adjust = "";
                    HomePage.ins.QRCODE_Adjust = gvDis.Rows[gvDis.Rows.Count - 1].Cells["QRCodeBundle"].Value.ToString();
                    HomePage.ins.BundleNo_Adjust = gvDis.Rows[gvDis.Rows.Count - 1].Cells["BundleNo"].Value.ToString();
                }
            }
        }

        private void cbbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbDepartment.Text == "Sewing")
            {
                toolStrip2.Visible = true;
            }
            else
            {
                toolStrip2.Visible = false;
            }

        }

        private void btSave2_Click(object sender, EventArgs e)
        {
            if (tbQTY.Text.Length > 1)
            {
                if (MessageBox.Show("Are you sure you want to save data?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    // int QTYAdj = int.Parse(gvDis.Rows[0].Cells["QTY"].Value.ToString()) - int.Parse(tbQty.Text);
                    string SD_ListDoc = gvDis.Rows[0].Cells["SD_ListDoc_No"].Value.ToString();
                    string so = gvDis.Rows[0].Cells["SO"].Value.ToString();
                    string lbQRRef = gvDis.Rows[0].Cells["SD_ListDoc_No"].Value.ToString();
                    string BundleNo = gvDis.Rows[0].Cells["BundleNo"].Value.ToString();
                    //string delete = "DELETE FROM `a_decrease_qty` WHERE `BD_QRCode_Ref` = '" + lbQRRef.Text +
                    //                                           "' AND `Decoration`='" + cbbDec.Text + "'; ";

                    string txtInsert = " INSERT INTO `a_decrease_qty`(`id`, `Decoration`, `BD_QRCode_Ref`, `QTY`, `userID`," +
                    "  `SD_ListDoc_No`, `SO`, `Remark`,`BundleNo`)" +
                        " VALUES (NULL,'" + cbbDepartment.Text + "','" + tbQrCode1.Text + "','" + tbQTY.Text + "','" + Login.ins.empID + "'," +
                        "'" + SD_ListDoc + "','" + so + "','" + tbRemark.Text + "','" + BundleNo + "')";
                    bool st = ConnectMySQL.MysqlQuery(txtInsert);
                    if (st)
                    {
                        MessageBox.Show("Ok");
                        HomePage.ins.qtyDecrease = int.Parse(tbQTY.Text);
                        HomePage.ins.BundleNo_Adjust = gvDis.Rows[0].Cells["BundleNo"].Value.ToString();
                        DialogResult = DialogResult.OK;

                    }
                    else
                    {
                        MessageBox.Show("Can't Not Insert Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
            }
            else
            {
                MessageBox.Show("Please add QTY.");
            }

        }



        private void AdjustQTY_V2_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void tbQTY_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(tbQTY.Text, out int result))
            {
                int LeftQtyRef = -HomePage.ins.qtyDecreaseRef;
                if (result < LeftQtyRef)
                {
                    tbQTY.Text = LeftQtyRef.ToString(); // หากเกิน 20 ให้เปลี่ยนเป็น 20
                    tbQTY.SelectionStart = tbQTY.Text.Length; // เคอร์เซอร์ไปอยู่ที่ท้ายข้อความ
                    MessageBox.Show(LeftQtyRef.ToString() + " is the maximum value that can be decreased.");
                }
            }
        }

        private void btSearchHistory_Click(object sender, EventArgs e)
        {
            if (tbSearchHis.Text.Length > 0)
            {
                string txtWhere = "";
                if (tbSearchHis.Text.Substring(0, 2) == "SD")
                {
                    txtWhere = "`SD_ListDoc_No` LIKE '" + tbSearchHis.Text + "'";
                }
                else if (tbSearchHis.Text.Substring(0, 2) == "SO")
                {
                    txtWhere = "`SO` LIKE '" + tbSearchHis.Text + "'";
                }
                string sqltxt = @"SELECT `Decoration`, `BD_QRCode_Ref` AS QRCode, `QTY`, `userID`, `DateTime`, `SD_ListDoc_No`, 
                                `SO`, `Remark`, `BundleNo` 
                                FROM `a_decrease_qty` WHERE `Decoration` LIKE '" + cbbDepartment.Text + "' AND " + txtWhere + ";";
                ConnectMySQL.DisplayAndSearch(sqltxt, gvDisList);
            }
        }
    }
}
