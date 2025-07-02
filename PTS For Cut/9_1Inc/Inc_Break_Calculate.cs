using MySql.Data.MySqlClient;
using PTS_For_Cut.Main;
using PTS_For_Cut.myClass;
using PTS_For_Cut.Myclass;
using System.Data;

namespace PTS_For_Cut._9_1Inc
{
    public partial class Inc_Break_Calculate : Form
    {
        MySqlConnection connection = ConnectMySQL.GetConnection();
        MySqlCommand command;

        public Inc_Break_Calculate()
        {
            InitializeComponent();
        }

        private void Inc_Break_Calculate_Load(object sender, EventArgs e)
        {
            tbStyle.Text = Inc_Break.ins.Style;
            lbGroupBy.Text = HomePage.ins.inc_header;
            lbURLimgPath.Text = Login.ins.imgPath;
            lbHeader.Text = "Incentive Break " + lbGroupBy.Text;
            getDataStyle();
            getDataSAM();
            tbOverhead.Text = ConnectMySQL.Subtext("SELECT para_Value  FROM i_inc_parameter WHERE  para_Name = 'Overhead' AND para_Group = '" + lbGroupBy.Text + "'");
            tbWage.Text = ConnectMySQL.Subtext("SELECT para_Value  FROM i_inc_parameter WHERE  para_Name = 'Wage' AND para_Group = '" + lbGroupBy.Text + "'");
            getDataInc();
            tbPrice.Focus();

        }
        private void getDataSAM()
        {
            ConnectMySQL.db = "costings_db"; // เปลี่ยนฐานข้อมูล  
            string DataSAM = "SELECT `press_smv`, `inspec_smv`, `samcut`, `samsew`, `sampack`, `samheat`  FROM `style_tb` WHERE `Style` LIKE '" + tbStyle.Text + "'; ";
            DataTable dtSAM = ConnectMySQL.MySQLtoDataTable(DataSAM); ConnectMySQL.db = "pts_db";
            for (int i = 0; i < dtSAM.Rows.Count; i++)
            {
                string groupBy = lbGroupBy.Text;
                switch (groupBy)
                {
                    case "Cutting":
                        tbSAM.Text = (dtSAM.Rows[i]["samcut"].ToString());
                        break;
                    case "Sewing":
                        tbSAM.Text = (dtSAM.Rows[i]["samsew"].ToString());
                        break;
                    case "Pressing":
                        tbSAM.Text = (dtSAM.Rows[i]["press_smv"].ToString());
                        break;
                    case "Inspection":
                        tbSAM.Text = (dtSAM.Rows[i]["inspec_smv"].ToString());
                        break;
                    case "Packing":
                        tbSAM.Text = (dtSAM.Rows[i]["sampack"].ToString());
                        break;
                    case "Heat":
                        tbSAM.Text = (dtSAM.Rows[i]["samheat"].ToString());
                        break;
                    default:
                        tbSAM.Text = "N/A"; // In case lbGroupBy.Text doesn't match any category
                        break;
                }
            }
        }
        private void getDataStyle()
        {
            ConnectMySQL.db = "similarity_db"; // เปลี่ยนฐานข้อมูล  
            string DataStyle = "SELECT `CusStyle`, `Customer` , `Product_type` ,`ImgPath`  FROM `style_tb` WHERE `Style` LIKE '" + tbStyle.Text + "'; ";
            DataTable dtStyle = ConnectMySQL.MySQLtoDataTable(DataStyle); ConnectMySQL.db = "pts_db";
            for (int i = 0; i < dtStyle.Rows.Count; i++)
            {

                lbCusStlye.Text = (dtStyle.Rows[i]["CusStyle"].ToString());
                lbCus.Text = (dtStyle.Rows[i]["Customer"].ToString());
                lbProType.Text = (dtStyle.Rows[i]["Product_type"].ToString());
                lbpathimg.Text = (dtStyle.Rows[i]["ImgPath"].ToString());
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
                    string sPath = lbURLimgPath.Text + lbpathimg.Text;
                    ptImage.Image = System.Drawing.Image.FromFile(sPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message);
                }
            }
        }

        private void Calculate()
        {
            // Ensure columns are defined first
            if (gvDis.Columns.Count == 0)
            {
                gvDis.Columns.Add("Index", "Index");
                gvDis.Columns.Add("Efficiency", "Efficiency");
                gvDis.Columns.Add("THB", "THB");
                gvDis.Columns.Add("QTY", "QTY");
                gvDis.Columns.Add("Profit Percentage", "Profit Percentage");
                gvDis.Columns.Add("Employee Income", "Employee Income");
                gvDis.Columns.Add("Line Leader", "Line Leader");
                gvDis.Columns.Add("Supervisor Income", "Supervisor Income");
            }

            if (tbStyle.Text != "" && tbPrice.Text != "" && tbPrIncPer.Text != "" && tbSAM.Text != "" && tbEff.Text != "" && tbOperator.Text != ""
                 && tbEmpInc.Text != "" && tbLineLeader.Text != "" && tbSuperInc.Text != "" && tbWage.Text != "" && tbOverhead.Text != "")
            {
                gvDis.DataSource = null;
                string ts = CalculateInc.stepEff(tbEff.Text, 5);
                double Eff = double.Parse(ts);
                double sam = double.Parse(tbSAM.Text);
                double Oper = double.Parse(tbOperator.Text);
                double price = double.Parse(tbPrice.Text);
                double priceInc = double.Parse(tbPrIncPer.Text);

                double OH = double.Parse(tbOverhead.Text);
                double wage = double.Parse(tbWage.Text);

                for (int i = 1; i < 14; i++)
                {
                    if (i == 1)
                    {
                        double QTY = ((Eff / 100) * 8 * 60 * Oper) / sam;
                        double income = QTY * price;
                        double expenses = Oper * wage * OH;
                        double balance = income - expenses;
                        double profitPer = (balance / income) * 100;
                        double THB = (income - (priceInc * QTY)) / Oper;
                        string sTHB = THB.ToString("0.00");
                        string sQTY = QTY.ToString("0.00");
                        string sprofitPer = profitPer.ToString("0.00");
                        double EmpInc = double.Parse(sTHB) * double.Parse(tbEmpInc.Text) / 100;
                        double LineLead = double.Parse(sTHB) * double.Parse(tbLineLeader.Text) / 100;
                        double Super = double.Parse(sTHB) * double.Parse(tbSuperInc.Text) / 100;
                        gvDis.Rows.Add(i, ts, sTHB, sQTY, sprofitPer, EmpInc.ToString("0.00"), LineLead.ToString("0.00"), Super.ToString("0.00"));
                    }
                    else
                    {
                        double eff = double.Parse(gvDis.Rows[i - 2].Cells[1].Value.ToString()) + 10;
                        double QTY = (eff / 100 * 8 * 60 * Oper) / sam;
                        double income = QTY * price;
                        double expenses = Oper * wage * OH;
                        double balance = income - expenses;
                        double profitPer = (balance / income) * 100;
                        double THB = (income - (priceInc * QTY)) / Oper;
                        string sTHB = THB.ToString("0.00");
                        string sQTY = QTY.ToString("0.00");
                        string sprofitPer = profitPer.ToString("0.00");

                        double EmpInc = double.Parse(sTHB) * double.Parse(tbEmpInc.Text) / 100;
                        double LineLead = double.Parse(sTHB) * double.Parse(tbLineLeader.Text) / 100;
                        double Super = double.Parse(sTHB) * double.Parse(tbSuperInc.Text) / 100;

                        gvDis.Rows.Add(i, eff.ToString(), sTHB, sQTY, sprofitPer, EmpInc.ToString("0.00"), LineLead.ToString("0.00"), Super.ToString("0.00"));
                    }
                }

            }
        }


        private void tbPrice_Leave(object sender, EventArgs e)
        {
            if (tbPrice.Text != "")
            {
                tbPrIncPer.Text = (double.Parse(tbPrice.Text) * 0.9).ToString("0.00");
            }
            else
            {
                tbPrice.Text = "0";
                tbPrIncPer.Text = "0";
            }
        }

        private void btSettingValue_Click(object sender, EventArgs e)
        {
            FormSetting formSetting = new FormSetting();
            formSetting.Show();
        }

        private void btReF_Click(object sender, EventArgs e)
        {
            tbOverhead.Text = ConnectMySQL.Subtext("SELECT para_Value  FROM i_inc_parameter WHERE  para_Name = 'Overhead' AND para_Group = '" + lbGroupBy.Text + "'");
            tbWage.Text = ConnectMySQL.Subtext("SELECT para_Value  FROM i_inc_parameter WHERE  para_Name = 'Wage' AND para_Group = '" + lbGroupBy.Text + "'");
        }

        private void btCalculate_Click(object sender, EventArgs e)
        {
            if (gvDis.Columns.Count == 0)
            {
                Calculate();
            }
            else
            {
                gvDis.DataSource = null;
                if (gvDis.Columns.Count == 0)
                {
                    Calculate();
                }
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            AddData();
        }
        private void AddData()
        {
            if (MessageBox.Show("Are you sure want to Add", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (tbStyle.Text != "" && tbPrice.Text != "" && tbPrIncPer.Text != "" && tbSAM.Text != "" && tbEff.Text != "" && tbOperator.Text != "" && tbEmpInc.Text != "" && tbLineLeader.Text != "" && tbSuperInc.Text != "")
                {
                    ConnectMySQL.db = "pts_db";
                    ConnectMySQL.MysqlQuery("DELETE FROM i_inc_break_tb WHERE `Style` = '" + tbStyle.Text + "' AND `GroupInc` = '" + lbGroupBy.Text + "' ");
                    ConnectMySQL.MysqlQuery("ALTER TABLE `i_inc_break_tb` auto_increment = 1;");
                    bool statusAdd = ConnectMySQL.MysqlQuery("INSERT INTO `i_inc_break_tb`(`No`, `Style`, `Price`, `IncPrice`, `SAM`, `EffSale`, `Operator`, `EmpInc`, `LineLeadInc`, `SupInc`, `GroupInc`) " +
                                            "VALUES (NULL,'" + tbStyle.Text + "','" + tbPrice.Text + "','" + tbPrIncPer.Text + "','" + tbSAM.Text + "','" + tbEff.Text + "','" + tbOperator.Text + "'," +
                                            "'" + tbEmpInc.Text + "','" + tbLineLeader.Text + "','" + tbSuperInc.Text + "','" + lbGroupBy.Text + "')");
                    if (statusAdd)
                    {
                        MessageBox.Show("Add Successfully", "Imformation", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Insertion failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void getDataInc()
        {
            ConnectMySQL.db = "pts_db";
            string DataStyle = "SELECT  `Price`, `IncPrice`, `SAM`, `EffSale`, `Operator`, `EmpInc`, `LineLeadInc`, `SupInc`  FROM `i_inc_break_tb` WHERE `Style` LIKE '" + tbStyle.Text + "' AND `GroupInc` LIKE '" + lbGroupBy.Text + "'  ; ";
            DataTable dtStyle = ConnectMySQL.MySQLtoDataTable(DataStyle);
            for (int i = 0; i < dtStyle.Rows.Count; i++)
            {

                tbPrice.Text = (dtStyle.Rows[i]["Price"].ToString());
                tbPrIncPer.Text = (dtStyle.Rows[i]["IncPrice"].ToString());
                tbSAM.Text = (dtStyle.Rows[i]["SAM"].ToString());
                tbEff.Text = (dtStyle.Rows[i]["EffSale"].ToString());
                tbOperator.Text = (dtStyle.Rows[i]["Operator"].ToString());
                tbEmpInc.Text = (dtStyle.Rows[i]["EmpInc"].ToString());
                tbLineLeader.Text = (dtStyle.Rows[i]["LineLeadInc"].ToString());
                tbSuperInc.Text = (dtStyle.Rows[i]["SupInc"].ToString());

            }
        }

        private void pbSh_Click(object sender, EventArgs e)
        {
            getDataStyle();
            getDataSAM();
            getDataInc();

        }

        private void tbPrice_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tbPrice.Text == "")
                {
                    tbPrice.Focus();
                    MessageBox.Show("Please add Price");
                }
                else
                {
                    tbSAM.Focus();
                }
            }
        }

        private void tbPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void tbSAM_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tbSAM.Text == "")
                {
                    tbSAM.Focus();
                    MessageBox.Show("Please add SAM");
                }
                else
                {
                    tbEff.Focus();
                }
            }
        }

        private void tbSAM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void tbEff_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tbEff.Text == "")
                {
                    tbEff.Focus();
                    MessageBox.Show("Please add EFF For Sale(%)");
                }
                else
                {
                    tbOperator.Focus();
                }
            }
        }
        private void tbEff_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void tbOperator_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tbOperator.Text == "")
                {
                    tbOperator.Focus();
                    MessageBox.Show("Please add Operator");
                }
                else
                {
                    tbEmpInc.Focus();
                }
            }
        }

        private void tbOperator_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void tbEmpInc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tbEmpInc.Text == "")
                {
                    tbEmpInc.Focus();
                    MessageBox.Show("Please add Employee Inc(%)");
                }
                else
                {
                    tbLineLeader.Focus();
                }
            }
        }

        private void tbEmpInc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void tbLineLeader_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tbLineLeader.Text == "")
                {
                    tbLineLeader.Focus();
                    MessageBox.Show("Please add Line Leader Inc(%)");
                }
                else
                {
                    tbSuperInc.Focus();
                }
            }
        }

        private void tbLineLeader_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void tbSuperInc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tbSuperInc.Text == "")
                {
                    tbSuperInc.Focus();
                    MessageBox.Show("Please add Superviser Inc(%)");
                }
            }
        }

        private void tbSuperInc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void tbStyle_TextChanged(object sender, EventArgs e)
        {
            tbPrice.Text = "";
            tbPrIncPer.Text = "";
            tbSAM.Text = "";
            tbEff.Text = "";
            tbOperator.Text = "";
            tbEmpInc.Text = "";
            tbLineLeader.Text = "";
            tbSuperInc.Text = "";
            lbpathimg.Text = "";
            ptImage.Image = null;
        }

        private void tbStyle_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tbStyle.Text.Length > 13)
                {
                    getDataStyle();
                    getDataSAM();
                    getDataInc();
                }
                else
                {
                    tbStyle.Text = "";
                }
            }

        }
    }
}
