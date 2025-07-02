using PTS_For_Cut._Main;
using PTS_For_Cut.Main;
using PTS_For_Cut.Myclass;
using System.Globalization;
using Application = System.Windows.Forms.Application;
using DataTable = System.Data.DataTable;

namespace PTS_For_Cut
{
    public partial class Login : Form
    {
        public string comport = "";
        public string SMKBuilding = "";
        public string buildingGroup = "";

        public string empID, empName, userName, password, department, Permiss, UserGroup = "";

        public DataTable dtBuilding;

        public DataTable userCompare_tb;
        public DataTable userLogin_tb;
        public DataTable Line_dt;
        public static Login ins;
        public DataTable dtDecoration;
        public DataTable dtPermissList;
        public string imgPath = "";
        public string Factory = "";
        // public DataGridViewComboBoxColumn cc = new DataGridViewComboBoxColumn();
        public Login()
        {
            InitializeComponent();
            ins = this;
        }
        private void Login_Load(object sender, EventArgs e)
        {
            ConnectMySQL.IPport = "3306";

            if (Properties.Settings.Default.WiFi_ip != "")
            {
                ConnectMySQL.ip = Properties.Settings.Default.WiFi_ip;
                lbCurrentID.Text = "IP: " + ConnectMySQL.ip;
                tbUsername1.Text = Properties.Settings.Default.userName;
                tbPassword1.Text = Properties.Settings.Default.userPassword;
            }
            if (Properties.Settings.Default.Factory != "")
            {
                Factory = Properties.Settings.Default.Factory;
            }
            CultureInfo info = new CultureInfo("en-US");
            info.NumberFormat.NumberDecimalSeparator = ".";
            Thread.CurrentThread.CurrentCulture = info;
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;


            if (Properties.Settings.Default.DirectReport != -1)
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    btSignin1_Click(btSignin1, EventArgs.Empty);
                });
            }
        }
        private void signIn()
        {

            if (tbUsername1.Text != "" && tbPassword1.Text != "")
            {
                ConnectMySQL.db = "pts_db";
                getData();
                if (tbUsername1.Text == userName)
                {
                    if (tbPassword1.Text == password)
                    {
                        if (Permiss == "login")
                        {//

                            Properties.Settings.Default.userName = tbUsername1.Text;
                            Properties.Settings.Default.userPassword = tbPassword1.Text;
                            Properties.Settings.Default.Save();
                            imgPath = ConnectMySQL.Subtext("SELECT `Parameter` FROM `parameterseting` WHERE `Name` LIKE 'PathImgStyle';");

                            Line_dt = ConnectMySQL.MySQLtoDataTable("SELECT `Location` AS 'Line', `LocationGroup`AS 'Department' FROM `location_tb` WHERE `LocationGroup`IN('Sewing','Cutting');");



                            dtBuilding = ConnectMySQL.MySQLtoDataTable("SELECT `bldsmk_bld`, `bldsmk_smk` FROM `b_bldsmk` WHERE 1");
                            dtDecoration = ConnectMySQL.MySQLtoDataTable("SELECT `Dec_ID`, `Dec_Eng`, `Dec_Thai`, `Short_Dec` FROM `a_a0decoration` WHERE 1");
                            dtPermissList = ConnectMySQL.MySQLtoDataTable("SELECT  `Permiss` FROM `user_match_persmiss` WHERE `EmpID`='" + empID + "';");
                            ConnectMySQL.MysqlQuery("UPDATE `user_tb` SET `login`='1' WHERE `empID`='" + empID + "';");

                            HomePage homePage = new HomePage();
                            homePage.Show();
                            this.Hide();

                        }
                        else
                        {
                            MessageBox.Show("Check Your Access Right Please.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Password Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("User ID Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void getData()
        {

            string sql = "SELECT `a`.`empID`, `a`.`Username`, `a`.`Password`, `a`.`Name`, `a`.`Department`, `b`.`Permiss`,`a`.`UserGroup` " +
                "FROM `user_tb` AS `a` " +
                "LEFT JOIN `user_match_persmiss` AS `b` ON `a`.`empID`=`b`.`empID` AND `b`.`Permiss` ='login' " +
                "WHERE `a`.`userName`='" + tbUsername1.Text + "'AND `a`.`Password`='" + tbPassword1.Text + "' AND `a`.`Active` = 1;";
            DataTable dtUser = ConnectMySQL.MySQLtoDataTable(sql);

            empID = dtUser.Rows[0]["empID"].ToString();
            userName = dtUser.Rows[0]["Username"].ToString();
            password = dtUser.Rows[0]["Password"].ToString();
            empName = dtUser.Rows[0]["Name"].ToString();
            department = dtUser.Rows[0]["Department"].ToString();
            Permiss = dtUser.Rows[0]["Permiss"].ToString();
            UserGroup = dtUser.Rows[0]["UserGroup"].ToString();

            if (UserGroup != "")
            {
                Properties.Settings.Default.workGroup = UserGroup;
                Properties.Settings.Default.Save();
            }

        }



        private void tbUsername1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                signIn();
            }
        }

        private void tbPassword1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                signIn();
            }
        }

        private void btSignin1_Click(object sender, EventArgs e)
        {
            signIn();
        }

        private void btSetIP1_Click(object sender, EventArgs e)
        {
            using (ConnectionSetting con = new ConnectionSetting())
            {

                if (DialogResult.OK == con.ShowDialog())
                {
                    tbUsername1.Focus();
                }
            }
        }

        private void btCloseApp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Visible)
            {
                if (MessageBox.Show("Are you sure you want to exit program?", "Information", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btUser_Click(object sender, EventArgs e)
        {
            passUser user = new passUser();
            user.Show();
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}