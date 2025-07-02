using PTS_For_Cut.Myclass;

namespace PTS_For_Cut.Main
{
    public partial class ConnectionSetting : Form
    {
        public ConnectionSetting()
        {
            InitializeComponent();
        }



        private void ConnectionSetting_Load(object sender, EventArgs e)
        {


            if (Properties.Settings.Default.WiFi_ip != "")
            {
                tbIP.Text = Properties.Settings.Default.WiFi_ip;
            }

        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSave1_Click(object sender, EventArgs e)
        {
            save();
        }
        private void save()
        {
            if (tbIP.Text != "")
            {
                Properties.Settings.Default.WiFi_ip = tbIP.Text;
                ConnectMySQL.ip = tbIP.Text;
                Properties.Settings.Default.Save();
                MessageBox.Show("OK.");
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("!!!!Check your IP!!!!");
            }
        }

        private void btUser_Click(object sender, EventArgs e)
        {

        }

        private void tbIP_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                save();
            }
        }
    }
}
