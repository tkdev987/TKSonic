using PTS_For_Cut.Main;
using PTS_For_Cut.myClass;
using PTS_For_Cut.Myclass;
using Application = System.Windows.Forms.Application;
using DataTable = System.Data.DataTable;

namespace PTS_For_Cut._9_1Inc
{
    public partial class Inc_Break : Form
    {
        public static Inc_Break ins;
        public string Style { set; get; }
        public string ReStyle { set; get; }
        public string ReGroup { set; get; }
        public string ReDoc { set; get; }
        public string ReCus { set; get; }
        public string ReCusType { set; get; }
        public string ReProType { set; get; }
        public string ReUrlImg { set; get; }
        public string RePrice { set; get; }
        public string ReIncPrice { set; get; }
        public string ReSAM { set; get; }
        public string ReEffSale { set; get; }
        public string ReOperator { set; get; }
        public string ReOutput { set; get; }
        public string ReEmpInc { set; get; }
        public string ReLineLeadInc { set; get; }
        public string ReSupInc { set; get; }


        public Inc_Break()
        {
            InitializeComponent();
            ins = this;
        }

        private void btSearchStyle_Click(object sender, EventArgs e)
        {
            GetDataSearchStyle();
        }
        private void GetDataSearchStyle()
        {

        }
        public void UpdateLabel()
        {
            ConnectMySQL.db = "pts_db";
            lbGroupBy.Text = "Incentive Breaks : " + HomePage.ins.inc_header;
            lbGroupBy.Refresh();

        }

        private void Inc_Break_Load(object sender, EventArgs e)
        {
            ConnectMySQL.db = "pts_db";
            UpdateLabel();
            lbURLimgPath.Text = Login.ins.imgPath;
            lbFac.Text = Properties.Settings.Default.Factory;
            lbDoc.Text = ConnectMySQL.Subtext("SELECT `Doc_code` FROM `doc_regis` WHERE `Factory` = '" + lbFac.Text + "' AND `Function` = 'IncentiveReport'");
            ConnectMySQL.DisplayAndSearch("SELECT `Style` FROM `i_inc_break_tb` WHERE  `GroupInc` LIKE '%" + HomePage.ins.inc_header + "%' ", gvStyle);
            
        }

        private void btShStyle_Click(object sender, EventArgs e)
        {
            ConnectMySQL.db = "pts_db";
            ConnectMySQL.DisplayAndSearch("SELECT `Style` FROM `i_inc_break_tb` WHERE `Style` LIKE '" + tbStyle.Text + "' AND `GroupInc` LIKE '%" + HomePage.ins.inc_header + "%' ", gvStyle);
        }

        private void btAddBreak_Click(object sender, EventArgs e)
        {
            if (tbStyle.Text.Length > 10)
            {
                Style = tbStyle.Text;
                Inc_Break_Calculate inc_Break_Cal = new Inc_Break_Calculate();
                inc_Break_Cal.Show();
            }
            else
            {
                tbStyle.Focus();
                tbStyle.Text = "";
                MessageBox.Show("Please add Style !!!!");
            }

        }

        private void gvDis_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (gvStyle.Rows.Count > 0)
                {
                    int d = e.RowIndex;
                    DataGridViewRow sel = gvStyle.Rows[d];
                    tbStyle.Text = sel.Cells["Style"].Value.ToString();
                    tbStyleSh.Text = sel.Cells["Style"].Value.ToString();
                    getDataH();
                    getDataStyle();
                    GetDataReport();

                    if (gvStyleDetail.Columns.Count == 0)
                    {
                        Calculate();
                    }
                    else
                    {
                        gvStyleDetail.DataSource = null;
                        if (gvStyleDetail.Columns.Count == 0)
                        {
                            Calculate();
                        }
                    }
                }
            }
        }



        private void getDataH()
        {


            ConnectMySQL.db = "pts_db";
            string DataHeader = "SELECT  `Price`, `IncPrice`, `SAM`, `EffSale`, `Operator`, `Output`, `EmpInc`, `LineLeadInc`, `SupInc`, `GroupInc` FROM `i_inc_break_tb`  WHERE `Style` LIKE '%" + tbStyleSh.Text + "%' AND `GroupInc` LIKE '%" + HomePage.ins.inc_header + "%' ";
            DataTable dtHeader = ConnectMySQL.MySQLtoDataTable(DataHeader);
            gvStyleH.DataSource = dtHeader;

            for (int i = 0; i < dtHeader.Rows.Count; i++)
            {
                RePrice = (dtHeader.Rows[i]["Price"].ToString());
                ReIncPrice = (dtHeader.Rows[i]["IncPrice"].ToString());
                ReSAM = (dtHeader.Rows[i]["SAM"].ToString());
                ReEffSale = (dtHeader.Rows[i]["EffSale"].ToString());
                ReOperator = (dtHeader.Rows[i]["Operator"].ToString());
                ReOutput = (dtHeader.Rows[i]["Output"].ToString());
                ReEmpInc = (dtHeader.Rows[i]["EmpInc"].ToString());
                ReLineLeadInc = (dtHeader.Rows[i]["LineLeadInc"].ToString());
                ReSupInc = (dtHeader.Rows[i]["SupInc"].ToString());

            }
        }

        private void getDataStyle()
        {
            ConnectMySQL.db = "similarity_db"; // เปลี่ยนฐานข้อมูล  
            string DataStyle = "SELECT `CusStyle`, `Customer` , `Product_type` ,`ImgPath`  FROM `style_tb` WHERE `Style` LIKE '" + tbStyle.Text + "'; ";
            DataTable dtStyle = ConnectMySQL.MySQLtoDataTable(DataStyle); ConnectMySQL.db = "pts_db";
            ConnectMySQL.db = "pts_db";
            for (int i = 0; i < dtStyle.Rows.Count; i++)
            {
                lbpathimg.Text = (dtStyle.Rows[i]["ImgPath"].ToString());
                ReCus = (dtStyle.Rows[i]["Customer"].ToString());
                ReCusType = (dtStyle.Rows[i]["CusStyle"].ToString());
                ReProType = (dtStyle.Rows[i]["Product_type"].ToString());
                lbCus.Text = (dtStyle.Rows[i]["Customer"].ToString());
                lbCusStlye.Text = (dtStyle.Rows[i]["CusStyle"].ToString());
                lbProType.Text = (dtStyle.Rows[i]["Product_type"].ToString());
            }

            // แสดงภาพ
            if (string.IsNullOrEmpty(lbpathimg.Text))
            {
                lbpathimg.Text = "";
                ptImage.Image = null;
            }
            else
            {
                try
                {
                    string UrlImg = lbURLimgPath.Text + lbpathimg.Text;
                    ptImage.Image = System.Drawing.Image.FromFile(UrlImg);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message);
                }
            }

        }
        private void Calculate()
        {
            //  if (gvStyleH.Rows.Count == 0) return; // ป้องกันข้อผิดพลาดหากไม่มีข้อมูล

            // ดึงแถวแรกของ gvStyleH
            DataGridViewRow firstRow = gvStyleH.Rows[0];

            // กำหนดคอลัมน์ให้ gvStyleDetail ถ้ายังไม่มี
            if (gvStyleDetail.Columns.Count == 0)
            {
                gvStyleDetail.Columns.Add("No.", "No.");
                gvStyleDetail.Columns.Add("Eff%", "Eff%");
                gvStyleDetail.Columns.Add("THB", "THB");
                gvStyleDetail.Columns.Add("QTY", "QTY");
                gvStyleDetail.Columns.Add("Profit %", "Profit %");
                gvStyleDetail.Columns.Add("Emp. Inc. %", "Emp. Inc. %");
                gvStyleDetail.Columns.Add("Line Lead Inc. %", "Line Lead Inc. %");
                gvStyleDetail.Columns.Add("Sup. Inc %", "Sup. Inc %");
            }

            gvStyleDetail.DataSource = null;

            // ใช้เมธอด GetCellValue
            string ts = CalculateInc.stepEff(GetCellValue(firstRow, "EffSale"), 5);
            double Eff = double.Parse(ts);
            double sam = double.Parse(GetCellValue(firstRow, "SAM"));
            double Oper = double.Parse(GetCellValue(firstRow, "Operator"));
            double price = double.Parse(GetCellValue(firstRow, "Price"));
            double priceInc = double.Parse(GetCellValue(firstRow, "IncPrice"));
            double OH = double.Parse(lbOverhead.Text);
            double wage = double.Parse(lbWage.Text);

            for (int i = 1; i < 14; i++)
            {
                double eff = (i == 1) ? Eff : double.Parse(gvStyleDetail.Rows[i - 2].Cells[1].Value.ToString()) + 10;
                double QTY = ((eff / 100) * 8 * 60 * Oper) / sam;
                double income = QTY * price;
                double expenses = Oper * wage * OH;
                double balance = income - expenses;
                double profitPer = (balance / income) * 100;
                double THB = (income - (priceInc * QTY)) / Oper;

                double EmpInc = THB * double.Parse(GetCellValue(firstRow, "EmpInc")) / 100;
                double LineLead = THB * double.Parse(GetCellValue(firstRow, "LineLeadInc")) / 100;
                double Super = THB * double.Parse(GetCellValue(firstRow, "SupInc")) / 100;

                gvStyleDetail.Rows.Add(i, eff.ToString("0.00"), THB.ToString("0.00"), QTY.ToString("0.00"), profitPer.ToString("0.00"),
                                       EmpInc.ToString("0.00"), LineLead.ToString("0.00"), Super.ToString("0.00"));
            }
        }

        // เมธอดสำหรับดึงค่าจาก DataGridView และตรวจสอบ null
        private string GetCellValue(DataGridViewRow row, string columnName)
        {
            return row.Cells[columnName]?.Value?.ToString() ?? "0";
        }

        private void GetDataReport()
        {

            //  SELECT `Doc_code` FROM `doc_regis` WHERE `Factory` = '" + HomePage.ins.Regis_SD_ID + "' AND `Function` = 'IncentiveReport'; "
        }
        private void btPrint_Click(object sender, EventArgs e)
        {

            ReStyle = tbStyleSh.Text;
            ReGroup = HomePage.ins.inc_header;
            ReDoc = lbDoc.Text;
            ReUrlImg = lbURLimgPath.Text + lbpathimg.Text;
            
            dataSet12.Clear();
            for (int i = 0; i < gvStyleDetail.Rows.Count; i++)
            {
                for (int j = 0; j < gvStyleDetail.Columns.Count; j++)
                {
                    string ColumnName = gvStyleDetail.Columns[j].HeaderText;
                    int RowId = i;

                    // ตรวจสอบค่า null ในเซลล์ก่อน
                    object cellValue = gvStyleDetail.Rows[i].Cells[j].Value;
                    string Value = cellValue != null ? cellValue.ToString() : string.Empty;

                    // เพิ่มข้อมูลในตาราง
                    dataSet12.IncRateTable.AddIncRateTableRow(ColumnName, RowId, Value);
                }
            }

            using (IncBreakReport pf = new IncBreakReport(dataSet12.IncRateTable))
            {
                pf.ShowDialog();
            }
            File.Delete(Application.StartupPath + "\\test.PNG");

        }

        private void tbStyle_TextChanged(object sender, EventArgs e)
        {
            cleartText();
        }
        private void cleartText()
        {
            lbpathimg.Text = "";
            ptImage.Image = null;
            lbCusStlye.Text = "";
            lbCus.Text = "";
            lbProType.Text = "";
            gvStyleH.DataSource = null;
            gvStyleDetail.Columns.Clear();
            // gvStyle.DataSource = null;
            tbStyleSh.Text = "";
        }

        private void tbStyle_KeyUp(object sender, KeyEventArgs e)
        {
            string searchText = tbStyle.Text;

            if (!string.IsNullOrEmpty(searchText))
            {
                foreach (DataGridViewRow row in gvStyle.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null && cell.Value.ToString().Contains(searchText))
                        {
                            gvStyle.CurrentCell = cell;

                            gvStyle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                            return; // Stop searching after finding the first match.
                        }
                    }
                }
            }
        }
    }
}
