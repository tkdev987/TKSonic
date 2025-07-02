using PTS_For_Cut.Myclass;

namespace PTS_For_Cut._9Report
{
    public partial class ReportCompareNew_AddDefect : Form
    {
        public ReportCompareNew_AddDefect()
        {
            InitializeComponent();
        }

        private void ReportCompareNew_AddDefect_Load(object sender, EventArgs e)
        {
            reload();
        }
        private void reload()
        {
            ConnectMySQL.DisplayAndSearch("SELECT `id`, `DefectList` FROM `a_defect_list_so_report` WHERE 1", gvDis);
        }
        string iddb = "";
        private void gvDis_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                tbDefect.Text = gvDis.Rows[e.RowIndex].Cells["DefectList"].Value.ToString();
                iddb = gvDis.Rows[e.RowIndex].Cells["id"].Value.ToString();
            }

        }

        private void gvDis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btadd_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want add data?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool st = ConnectMySQL.MysqlQuery("INSERT INTO `a_defect_list_so_report`(`id`, `DefectList`) VALUES (NULL,'" + tbDefect.Text + "')");
                if (st)
                {
                    MessageBox.Show("OK.");
                    iddb = "";
                    reload();
                    checkChangeStatus = false;
                }
                else
                {
                    MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (iddb != "")
            {
                if (MessageBox.Show("Are you sure you want update data?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bool st = ConnectMySQL.MysqlQuery("UPDATE `a_defect_list_so_report` SET `DefectList`='" + tbDefect.Text + "' WHERE `id`='" + iddb + "'");
                    if (st)
                    {
                        MessageBox.Show("OK.");
                        iddb = "";
                        reload();
                        checkChangeStatus = false;
                    }
                    else
                    {
                        MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Select Row", "Imformation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (iddb != "")
            {


                if (MessageBox.Show("Are you sure you want delete data?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bool st = ConnectMySQL.MysqlQuery("DELETE FROM `a_defect_list_so_report` WHERE `id`='" + iddb + "'");
                    if (st)
                    {
                        MessageBox.Show("OK.");
                        iddb = "";
                        reload();
                        checkChangeStatus = false;
                    }
                    else
                    {
                        MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Select Row", "Imformation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        bool checkChangeStatus = false;
        private void ReportCompareNew_AddDefect_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (checkChangeStatus)
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
