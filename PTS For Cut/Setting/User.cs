using PTS_For_Cut.Myclass;
using System.Data;

namespace PTS_For_Cut.Setting
{
    public partial class User : Form
    {
        public static User ins;
        public User()
        {
            InitializeComponent();
            ins = this;
        }
        public bool EditData = false;
        public string empIDCross = "";
        private void User_Load(object sender, EventArgs e)
        {
            cbbSeachType.SelectedIndex = 0;
        }

        private void cbbSeachType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbSeachType.SelectedIndex == 2)
            {
                cbbDepartmentSearch.Visible = true;
                tbSearch.Visible = false;
                DataTable dt = new DataTable();
                dt = ConnectMySQL.MySQLtoDataTable("SELECT DISTINCT(`Department`) FROM `user_tb` WHERE 1");
                cbbDepartmentSearch.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    cbbDepartmentSearch.Items.Add(dr[0]);
                }
            }
            else
            {

                tbSearch.Visible = true;
                cbbDepartmentSearch.Visible = false;
            }
        }

        private void btLoadAll_Click(object sender, EventArgs e)
        {
            ConnectMySQL.DisplayAndSearch("SELECT `empID`, `Name`,`Department`,`UserGroup`, `login`, `Active`, `LastActive` FROM `user_tb` WHERE 1", gvDis);
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            search();
        }

        private void search()
        {
            string search = "";
            if (cbbSeachType.SelectedIndex == 0)//ID
            {
                search = "`empID` LIKE '" + tbSearch.Text + "'";
            }
            else if (cbbSeachType.SelectedIndex == 1)//Name
            {
                search = "`Name` LIKE '" + tbSearch.Text + "'";
            }
            else if (cbbSeachType.SelectedIndex == 2)//Depart
            {
                search = "`Department` LIKE '" + cbbDepartmentSearch.Text + "'";
            }
            if (cbbSeachType.SelectedIndex > -1)
            {
                ConnectMySQL.DisplayAndSearch("SELECT `empID`, `Name`,`Department`,`UserGroup`, `login`, `Active`, `LastActive` FROM `user_tb` WHERE " + search, gvDis);
            }
        }

        private void btAddUser_Click(object sender, EventArgs e)
        {
            EditData = false;
            using (AddUser addUser = new AddUser())
            {
                if (addUser.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (empIDCross != "")
            {
                EditData = true;
                using (AddUser addUser = new AddUser())
                {
                    if (addUser.ShowDialog() == DialogResult.OK)
                    {

                    }
                }
            }
            else
            {
                MessageBox.Show("Please Select User.");
            }
        }

        private void gvDis_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                empIDCross = gvDis.Rows[e.RowIndex].Cells["empID"].Value.ToString();
            }

        }

        private void tbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                search();
            }
        }

        private void btPermission_Click(object sender, EventArgs e)
        {
            if (empIDCross != "")
            {
                EditData = true;
                using (userPaermission addUser = new userPaermission())
                {
                    if (addUser.ShowDialog() == DialogResult.OK)
                    {

                    }
                }
            }
            else
            {
                MessageBox.Show("Please Select User.");
            }
        }
    }
}
