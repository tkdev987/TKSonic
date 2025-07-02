using MySql.Data.MySqlClient;
using PTS_For_Cut.Myclass;
using System.Data;

namespace PTS_For_Cut.Setting
{
    public partial class AddUser : Form
    {

        public AddUser()
        {
            InitializeComponent();

        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            DataTable dtuserGroup = new DataTable();
            dtuserGroup = ConnectMySQL.MySQLtoDataTable("SELECT `userGroup` FROM `user_group` WHERE 1");
            cbbUserGroup.Items.Clear();

            for (int i = 0; i < dtuserGroup.Rows.Count; i++)
            {
                cbbUserGroup.Items.Add(dtuserGroup.Rows[i]["userGroup"].ToString());
            }//
            DataTable dtDepart = new DataTable();
            dtDepart = ConnectMySQL.MySQLtoDataTable("SELECT  `Department` FROM `department_tb` WHERE 1");
            cbbDep.Items.Clear();

            for (int i = 0; i < dtDepart.Rows.Count; i++)
            {
                cbbDep.Items.Add(dtDepart.Rows[i]["Department"].ToString());
            }

            if (!User.ins.EditData)//Add
            {
                btAdd.Visible = true;
                btEdit.Visible = false;

            }
            else//eit
            {
                btAdd.Visible = false;
                btEdit.Visible = true;
                getData();

            }
        }
        private void getData()
        {//`UserGroup`, `login`, `Active`, `LastActive` 
            string sql = "SELECT `a`.`empID`, `a`.`Name`, `a`.`Username`, `a`.`Password`, `a`.`Department`, `a`.`UserGroup`,`a`.`Active` " +
               "FROM `user_tb` AS `a` " +
               "WHERE `a`.`empID`='" + User.ins.empIDCross + "'";

            MySqlConnection connection = ConnectMySQL.GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            MySqlDataReader myReder;
            try
            {
                myReder = cmd.ExecuteReader();
                while (myReder.Read())
                {
                    tbID.Text = myReder.GetString(0);
                    tbName.Text = myReder.GetString(1);
                    tbUserName.Text = myReder.GetString(2);
                    tbPassword.Text = myReder.GetString(3);
                    cbbDep.Text = myReder.GetString(4);
                    cbbUserGroup.Text = myReder.GetString(5);
                    cbbActive.Text = myReder.GetString(6);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (tbID.Text != "" && tbName.Text != "" && tbUserName.Text != "" && tbPassword.Text != "" && cbbUserGroup.SelectedIndex != -1 && cbbDep.SelectedIndex != -1 && cbbActive.SelectedIndex != -1)
            {
                if (MessageBox.Show("You Want to Edit Data?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bool st = ConnectMySQL.MysqlQuery("UPDATE `user_tb` SET `empID`='" + tbID.Text + "',`Name`='" + tbName.Text + "',`Username`='" + tbUserName.Text + "',`Password`='" + tbPassword.Text + "'," +
                      "`Department`='" + cbbDep.Text + "',`UserGroup`='" + cbbUserGroup.Text + "',`Active`='" + cbbActive.Text + "' WHERE `empID`Like'" + User.ins.empIDCross + "'");
                    if (st)
                    {
                        MessageBox.Show("OK");
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("!!!! Error Can't Update !!!!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Check Data");
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (tbID.Text != "" && tbName.Text != "" && tbUserName.Text != "" && tbPassword.Text != "" && cbbUserGroup.SelectedIndex != -1 && cbbDep.SelectedIndex != -1 && cbbActive.SelectedIndex != -1)
            {
                if (MessageBox.Show("You Want to Save Data?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bool st = ConnectMySQL.MysqlQuery("INSERT INTO `user_tb`( `empID`, `Name`, `Username`, `Password`, `Department`, `UserGroup`,  `Active`) " +
                        "VALUES ('" + tbID.Text + "','" + tbName.Text + "','" + tbUserName.Text + "','" + tbPassword.Text + "','" + cbbDep.Text + "','" + cbbUserGroup.Text + "','" + cbbActive.Text + "')");
                    if (st)
                    {
                        MessageBox.Show("OK");
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("!!!! Error Can't Update !!!!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Check Data");
            }

        }
    }
}
