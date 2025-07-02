namespace PTS_For_Cut.Setting
{
    public partial class SettingPage : Form
    {
        public SettingPage()
        {
            InitializeComponent();
        }

        //private void btSaveLagg_Click(object sender, EventArgs e)
        //{
        //    if (cbbLagg.SelectedIndex == 0)
        //    {
        //        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
        //    }
        //    else if (cbbLagg.SelectedIndex == 1)
        //    {
        //        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("th-TH");
        //    }
        //    this.Controls.Clear();
        //    InitializeComponent();
        //}


        private void SettingPage_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.workGroup != "")
            {
                //tbGOW.Text = Properties.Settings.Default.workGroup;
            }
            cbbDirectReport.SelectedIndex = Properties.Settings.Default.DirectReport;
        }

        private void btSaveGOW_Click(object sender, EventArgs e)
        {
            //if (tbGOW.Text.Length == 1)
            //{
            //    Properties.Settings.Default.workGroup = tbGOW.Text;
            //    Properties.Settings.Default.Save();
            //    MessageBox.Show("OK");
            //}
            //else
            //{
            //    MessageBox.Show("Put Text Length Equal To 1");
            //}
        }

        private void btUserPic_Click(object sender, EventArgs e)
        {
            User();
        }

        private void btUser_Click(object sender, EventArgs e)
        {
            User();
        }
        private void User()
        {
            using (User user = new User())
            {
                if (user.ShowDialog() == DialogResult.OK)
                {

                }

            }
        }

        private void cbbDirectReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DirectReport = cbbDirectReport.SelectedIndex;
            Properties.Settings.Default.Save();

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btResetDirectReport_Click(object sender, EventArgs e)
        {
            cbbDirectReport.SelectedIndex = -1;
        }
    }
}
