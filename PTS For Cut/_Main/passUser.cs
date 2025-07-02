using PTS_For_Cut.Myclass;
using PTS_For_Cut.Setting;
using System.Data;

namespace PTS_For_Cut._Main
{
    public partial class passUser : Form
    {
        public passUser()
        {
            InitializeComponent();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void passUser_Load(object sender, EventArgs e)
        {

        }
        private bool checkPermiss(string perMissinFunc)
        {
            ConnectMySQL.db = "pts_db";
            DataTable dt = ConnectMySQL.MySQLtoDataTable("SELECT `b`.`Permiss` " +
                "FROM `user_tb` AS `a` " +
                "JOIN `user_match_persmiss` AS `b` ON `a`.`empID`=`b`.`empID`" +
                "WHERE `a`.`userName`='" + tbUsername1.Text + "'AND `a`.`Password`='" + tbPassword1.Text + "' AND `a`.`Active` = 1;");

            if (dt.Rows.Count > 0)
            {
                bool st = false;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["Permiss"].ToString() == perMissinFunc || dt.Rows[i]["Permiss"].ToString() == "superUser")
                    {
                        st = true;
                    }
                }
                if (st)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void btGo_Click(object sender, EventArgs e)
        {
            checkID();
        }

        private void tbempID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                checkID();
            }
        }
        private void checkID()
        {
            if (tbUsername1.Text.Length > 0)
            {

                if (checkPermiss("superUser"))
                {
                    User user = new User();
                    user.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("This Account Don't Have Permission For This Function.");
                }

            }
            else
            {
                MessageBox.Show("Textbox is Empty.");
            }
        }
    }
}
