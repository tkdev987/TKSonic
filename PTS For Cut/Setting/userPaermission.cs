using PTS_For_Cut.Myclass;
using System.Data;

namespace PTS_For_Cut.Setting
{
    public partial class userPaermission : Form
    {
        public userPaermission()
        {
            InitializeComponent();
        }

        private void userPaermission_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = ConnectMySQL.MySQLtoDataTable("SELECT `Permiss_Name` FROM `permission_list` WHERE 1");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    cbbPer.Items.Add(dr[0]);
                }

            }
            ConnectMySQL.DisplayAndSearch("SELECT  `Permiss` FROM `user_match_persmiss` WHERE `EmpID`LIKE '" + User.ins.empIDCross + "';", gvDis);
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (cbbPer.Items.Count > -1)
            {
                DataTable dt = new DataTable();
                dt = (DataTable)gvDis.DataSource;
                dt.Rows.Add(cbbPer.Text);
            }

        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (gvDis.Rows.Count > 0)
            {
                string insertMultiValue = "";

                bool first = false;
                for (int i = 0; i < gvDis.Rows.Count; i++)
                {
                    string Permiss = gvDis.Rows[i].Cells["Permiss"].Value.ToString();
                    if (gvDis.Rows[i].Cells["Permiss"].Value.ToString() != "")
                    {
                        if (!first)
                        {
                            insertMultiValue = "('NULL','" + User.ins.empIDCross + "', '" + Permiss + "')";
                            first = true;
                        }
                        else
                        {
                            insertMultiValue = insertMultiValue + ",('NULL','" + User.ins.empIDCross + "', '" + Permiss + "')";
                        }
                    }
                }
                bool st = false;
                if (insertMultiValue != "")
                {
                    ConnectMySQL.MysqlQuery("DELETE FROM `user_match_persmiss` WHERE `EmpID` ='" + User.ins.empIDCross + "' ");
                    ConnectMySQL.MysqlQuery("ALTER TABLE `user_match_persmiss` auto_increment = 1;");
                    st = ConnectMySQL.MysqlQuery("INSERT INTO `user_match_persmiss`(`id`, `EmpID`, `Permiss`) VALUES" + insertMultiValue + ";");
                    if (st)
                    {
                        DialogResult = DialogResult.OK;
                        MessageBox.Show("OK");
                    }
                    else
                    {
                        MessageBox.Show("!!!!!!!! Can't Insert !!!!!!!!");
                    }
                }
            }
            else
            { MessageBox.Show("!!!!!!!! Don't Have Data !!!!!!!!"); }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (RowIndex > -1)
            {
                gvDis.Rows.RemoveAt(RowIndex);
            }
        }
        int RowIndex = -1;
        private void gvDis_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                RowIndex = e.RowIndex;
                // gvDis.Rows[e.RowIndex].Cells["Permiss"].Value.ToString();
            }
        }
    }
}
