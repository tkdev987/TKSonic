using PTS_For_Cut.Myclass;
using MessageBox = System.Windows.Forms.MessageBox;

namespace PTS_For_Cut.SMK
{
    public partial class ScanOutMaterial : Form
    {
        public ScanOutMaterial()
        {
            InitializeComponent();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (gvDis.Rows.Count > 0)
            {
                string insertMultiValue = "";
                bool first = false;

                ConnectMySQL.db = "pts_db";
                for (int i = 0; i < gvDis.Rows.Count - 1; i++)
                {
                    string so = gvDis.Rows[i].Cells["SO"].Value.ToString();
                    string style = gvDis.Rows[i].Cells["Style"].Value.ToString();
                    string color = gvDis.Rows[i].Cells["Color"].Value.ToString();
                    string Size = gvDis.Rows[i].Cells["Size"].Value.ToString();
                    string Qty = gvDis.Rows[i].Cells["Qty"].Value.ToString();

                    if (!first)
                    {
                        insertMultiValue = "('NULL', '" + so + "','" + style + "','" + color + "','" + Size + "','" + Qty + "','" + MainSMK.ins.DbID + "')";
                        first = true;
                    }
                    else
                    {
                        insertMultiValue = insertMultiValue + ",('NULL', '" + so + "','" + style + "','" + color + "','" + Size + "','" + Qty + "','" + MainSMK.ins.DbID + "')";
                    }
                }
                ConnectMySQL.MysqlQuery("ALTER TABLE `a_smk_scanin_tempo` auto_increment = 1;");
                bool status = ConnectMySQL.MysqlQuery("INSERT INTO `a_smk_scanin_tempo`(`smkScaninId`, `SO`, `Style`, `Color`, `Size`, `Qty`, `ID_Call`) " +
                    "VALUES " + insertMultiValue + ";");
                if (status)
                {
                    string DateAc = Date_Now();
                    ConnectMySQL.MysqlQuery("UPDATE `b_call_tb` SET `call_accepttime`='" + DateAc + "',`call_mechanic`='" + MainSMK.ins.UserID + "' WHERE `call_id`='" + MainSMK.ins.DbID + "'");
                    MessageBox.Show("Successfully.");
                    DialogResult = DialogResult.OK;
                }
            }
        }
        private string Date_Now()
        {
            string txtDate = "";
            System.Globalization.CultureInfo _cultureEnInfo = new System.Globalization.CultureInfo("en-US");
            DateTime dateEng = Convert.ToDateTime(DateTime.Now, _cultureEnInfo);
            txtDate = dateEng.ToString("yyyy-MM-dd HH:mm:ss", _cultureEnInfo);
            return txtDate;
        }
    }
}
