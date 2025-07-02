using PTS_For_Cut.Myclass;
using System.Data;

namespace PTS_For_Cut._9Report
{
    public partial class ReportCompareNewRecordDefect : Form
    {
        public ReportCompareNewRecordDefect()
        {
            InitializeComponent();
        }

        private void ReportCompareNewRecordDefect_Load(object sender, EventArgs e)
        {

            //col.Rows.Add(row[0].ToString(), "Cutting");
            //col.Rows.Add(row[0].ToString(), "SMK");
            //col.Rows.Add(row[0].ToString(), "Sewing");
            //col.Rows.Add(row[0].ToString(), "Packing");
            //col.Rows.Add(row[0].ToString(), "FG");
            //col.Rows.Add(row[0].ToString(), "Printing"); //EMBROIDERY
            //col.Rows.Add(row[0].ToString(), "Embroidery");

            cbbDev.Items.Clear();
            cbbDev.Items.Add("Cutting");

            cbbDev.Items.Add("Printing");
            cbbDev.Items.Add("Embroidery");
            cbbDev.Items.Add("SMK");
            cbbDev.Items.Add("Sewing");
            cbbDev.Items.Add("Packing");
            cbbDev.Items.Add("FG");
            cbbDev.Items.Add("Shipping");

            cbbColor.Items.Clear();
            foreach (DataRow row in ReportCompareNew.Ins.dt_Color.Rows)
            {
                cbbColor.Items.Add(row[0].ToString());
            }
            cbbSize.Items.Clear();
            foreach (DataRow row in ReportCompareNew.Ins.dt_Size.Rows)
            {
                cbbSize.Items.Add(row[0].ToString());
            }
            cbbDefect.Items.Clear();
            foreach (DataRow row in ReportCompareNew.Ins.defect_dt.Rows)
            {
                cbbDefect.Items.Add(row[0].ToString());
            }
            string dev = ReportCompareNew.Ins.Depart_;
            string color = ReportCompareNew.Ins.Color_;
            string size = ReportCompareNew.Ins.Size_;
            if (dev != "" && color != "" && size != "")
            {
                cbbSize.Text = size;
                cbbDev.Text = dev;
                cbbColor.Text = color;
            }// defect_dt

        }

        bool ch = false;
        private void btSave_Click(object sender, EventArgs e)
        {
            if (cbbColor.SelectedIndex > -1 && cbbDev.SelectedIndex > -1 && cbbSize.SelectedIndex > -1 && tbQTY.Text.Trim().Length > 0)
            {
                bool st = ConnectMySQL.MysqlQuery("ALTER TABLE `a_defect_so_report` auto_increment = 1; INSERT INTO `a_defect_so_report`(`id`, `DefectList`, `Color`, `Size`, `Department`, `QTY`,`SO`) " +
                       "VALUES (NULL,'" + cbbDefect.Text + "','" + cbbColor.Text + "','" + cbbSize.Text + "','" + cbbDev.Text + "','" + tbQTY.Text + "','" + ReportCompareNew.Ins.so_ + "');");
                if (st)
                {
                    MessageBox.Show("OK");
                    idRowDB = "";
                    ch = true;
                    search();
                    clear();
                }
                else
                {
                    MessageBox.Show("Can't Insert", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Can't Save Please Check Data");
            }
        }

        private void tbQTY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            // Allow digits only
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Suppress the key press
            }
        }

        private void ReportCompareNewRecordDefect_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ch)
            {


                DialogResult = DialogResult.OK;
            }
        }
        string idRowDB = "";
        private void gvDis_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                idRowDB = gvDis.Rows[e.RowIndex].Cells["id"].Value.ToString();
                cbbColor.Text = gvDis.Rows[e.RowIndex].Cells["Color"].Value.ToString();
                cbbDefect.Text = gvDis.Rows[e.RowIndex].Cells["DefectList"].Value.ToString();
                cbbDev.Text = gvDis.Rows[e.RowIndex].Cells["Department"].Value.ToString();
                cbbSize.Text = gvDis.Rows[e.RowIndex].Cells["Size"].Value.ToString();
                tbQTY.Text = gvDis.Rows[e.RowIndex].Cells["QTY"].Value.ToString();

            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            search();
        }
        private void clear()
        {
            cbbColor.SelectedIndex = -1;
            cbbDefect.SelectedIndex = -1;
            cbbDev.SelectedIndex = -1;
            cbbDefect.SelectedIndex = -1;
            tbQTY.Text = string.Empty;
        }
        private void search()
        {
            if (cbbColor.SelectedIndex > -1 && cbbDev.SelectedIndex > -1 && cbbSize.SelectedIndex > -1)
            {
                ConnectMySQL.DisplayAndSearch("SELECT `id`, `DefectList`, `Color`, `Size`, `Department`, `QTY` FROM `a_defect_so_report` " +
                    "WHERE `Color` LIKE '" + cbbColor.Text + "' AND `Department` LIKE '" + cbbDev.Text + "' AND `Size` LIKE '" + cbbSize.Text + "' AND `SO` LIKE '" + ReportCompareNew.Ins.so_ + "'", gvDis);

            }
            else
            {
                MessageBox.Show("Can't Search Please Select Data.");
            }
        }
        private void btUpdate_Click(object sender, EventArgs e)
        {
            //UPDATE `a_defect_so_report` SET `id`='[value-1]',`DefectList`='[value-2]',`Color`='[value-3]',`Size`='[value-4]',`Department`='[value-5]',`QTY`='[value-6]',`SO`='[value-7]' WHERE 1
            if (cbbColor.SelectedIndex > -1 && cbbDev.SelectedIndex > -1 && cbbSize.SelectedIndex > -1)
            {
                if (idRowDB != "")
                {
                    if (MessageBox.Show("Are you sure you want update data?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        bool st = ConnectMySQL.MysqlQuery("UPDATE `a_defect_so_report` SET `DefectList`='" + cbbDefect.Text + "',`Color`='" + cbbColor.Text + "'," +
                               "`Size`='" + cbbSize.Text + "',`Department`='" + cbbDev.Text + "',`QTY`='" + tbQTY.Text + "' WHERE `id`='" + idRowDB + "'");
                        if (st)
                        {
                            MessageBox.Show("OK");
                            idRowDB = "";
                            ch = true;
                            search();
                            clear();
                        }
                        else
                        {
                            MessageBox.Show("Can't Update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Can't Search Please Select Data.");
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (idRowDB != "")
            {
                if (MessageBox.Show("Are you sure you want update data?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    bool st = ConnectMySQL.MysqlQuery("DELETE FROM `a_defect_so_report` WHERE `id`='" + idRowDB + "'; ");
                    if (st)
                    {
                        MessageBox.Show("OK");
                        idRowDB = "";
                        ch = true;
                        search();
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("Can't Update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Select Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
