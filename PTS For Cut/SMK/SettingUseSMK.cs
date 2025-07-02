using System.Data;
using System.IO.Ports;

namespace PTS_For_Cut.SMK
{
    public partial class SettingUseSMK : Form
    {
        public SettingUseSMK()
        {
            InitializeComponent();
        }

        private void btGo_Click(object sender, EventArgs e)
        {
            if (cbbSMK.SelectedIndex > -1 && cbbComport.SelectedIndex > -1)
            {
                Login.ins.SMKBuilding = cbbSMK.Text;
                Login.ins.comport = cbbComport.Text;
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Please Select Items.");
            }
        }

        private void SettingUseSMK_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = Login.ins.dtBuilding;
            if (cbbSMK.Items.Count == 0)
            {
                cbbSMK.Items.Add(dt.Rows[0]["bldsmk_smk"].ToString());
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bool xx = false;
                foreach (var item in cbbSMK.Items)
                {
                    if (item.ToString() == dt.Rows[i]["bldsmk_smk"].ToString())
                    {
                        xx = true;
                    }
                }
                if (!xx)
                {
                    cbbSMK.Items.Add(dt.Rows[i]["bldsmk_smk"].ToString());
                }
            }
            cbbComport.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            cbbComport.Items.AddRange(ports);
        }

        private void cbbSMK_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbSMK.SelectedIndex != -1)
            {
                Login.ins.buildingGroup = "(";

                DataTable dt = new DataTable();
                dt = Login.ins.dtBuilding;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (cbbSMK.Text == dt.Rows[i]["bldsmk_smk"].ToString())
                    {

                        Login.ins.buildingGroup += dt.Rows[i]["bldsmk_bld"].ToString();
                        Login.ins.buildingGroup += ",";
                    }

                }
                Login.ins.buildingGroup = Login.ins.buildingGroup.Substring(0, Login.ins.buildingGroup.Length - 1);
                Login.ins.buildingGroup += ")";
                //  MessageBox.Show(Login.ins.buildingGroup);
            }
        }

        private void btReport_Click(object sender, EventArgs e)
        {
            
        }

        private void btLetgoWithout_Click(object sender, EventArgs e)
        {
            Login.ins.comport = "";
            DialogResult = DialogResult.OK;
            // DialogResult = DialogResult.OK;
            //ScanInOutSMK scanInOutSMK = new ScanInOutSMK();
            // scanInOutSMK.Show();

        }
    }
}
