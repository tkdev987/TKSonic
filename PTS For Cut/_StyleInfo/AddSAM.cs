using PTS_For_Cut.Myclass;

namespace PTS_For_Cut._StyleInfo
{
    public partial class AddSAM : Form
    {
        string smvCut, smvSew;
        public AddSAM()
        {
            InitializeComponent();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (StyleInfo.ins.OldStyle != "")
            {
                if (MessageBox.Show("Are you sure you want to update data?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ConnectMySQL.db = "pts_db";
                    bool status = ConnectMySQL.MysqlQuery("UPDATE `a_a0sam_cut_sew` SET `SAM_Cut`='" + tbSmvCut.Text + "',`SAM_Sew`='" + tbSmvSew.Text + "'" +
                           " WHERE `Style`LIKE '" + StyleInfo.ins.OldStyle + "'");
                    if (status)
                    {
                        MessageBox.Show("OK");
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("!!! Can't Update !!!");
                    }


                }
            }
            else
            {
                MessageBox.Show("Please Check Style.");
            }
        }

        private void AddSAM_Load(object sender, EventArgs e)
        {
            lbHeader.Text = "SMV of Style " + StyleInfo.ins.OldStyle;
            tbSmvCut.Text = StyleInfo.ins.smvCut;
            tbSmvSew.Text = StyleInfo.ins.smvSew;

        }

    }
}
