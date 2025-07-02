using PTS_For_Cut.Main;
using PTS_For_Cut.Myclass;

namespace PTS_For_Cut._StyleInfo
{
    public partial class StyleInfo : Form
    {
        public string OldStyle = "";
        public string smvCut = "";
        public string smvSew = "";
        public static StyleInfo ins { get; private set; }

        public StyleInfo()
        {
            InitializeComponent();
            ins = this;
        }




        private void btSearch_Click(object sender, EventArgs e)
        {
            search();
        }
        private void search()
        {
            if (tbSearch.Text.Length > 2)
            {
                ConnectMySQL.db = "pts_db";//SELECT `St_SAM_ID`, `Style`, `SAM_Cut`, `SAM_Sew` FROM `a_a0sam_cut_sew` WHERE 1
                ConnectMySQL.DisplayAndSearch("SELECT `a`.`Style`, `a`.`SAM_Cut`, `a`.`SAM_Sew`, " +
                    "CASE WHEN `b`.`Style` IS NULL THEN FALSE ELSE TRUE END AS `Part Status` " +
                    "FROM `a_a0sam_cut_sew` AS `a` LEFT JOIN `a_a0clothing_part`AS `b` ON `b`.`Style`=`a`.`Style` " +
                    "WHERE `a`.`Style` LIKE '" + tbSearch.Text + "' GROUP BY `a`.`Style`;", gvDis);

            }
        }

        private void tbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                search();
            }
        }
        private bool checkStyle()
        {
            ConnectMySQL.db = "similarity_db"; //tbNewStyle.Text
            string st = "";
            st = ConnectMySQL.Subtext("SELECT `Style` FROM `style_tb` WHERE `Style` LIKE '" + tbNewStyle.Text + "' LIMIT 1;");
            ConnectMySQL.db = "pts_db";

            if (tbNewStyle.Text == st)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btClothing_Click(object sender, EventArgs e)
        {
            if (HomePage.ins.checkPermiss("style_clothingPart"))
            {
                if (OldStyle != "")
                {
                    using (ClothingPartinfo di = new ClothingPartinfo())
                    {
                        if (di.ShowDialog() == DialogResult.OK)
                        {
                            search();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("...Please Select Style...");
                }
            }
            else
            {
                MessageBox.Show("This Account Don't Have Permission For This Function.");
            }
        }

        private void btSMV_Click(object sender, EventArgs e)
        {
            if (HomePage.ins.checkPermiss("style_info"))
            {
                using (AddSAM di = new AddSAM())
                {
                    if (di.ShowDialog() == DialogResult.OK)
                    {
                        search();
                    }
                }
            }
            else
            {
                MessageBox.Show("This Account Don't Have Permission For This Function.");
            }
        }

        private void gvDis_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (gvDis.Rows.Count > 0)
                {
                    // status = true;
                    int d = e.RowIndex;
                    DataGridViewRow sel = gvDis.Rows[d];
                    OldStyle = sel.Cells[0].Value.ToString();
                    smvCut = sel.Cells[1].Value.ToString();
                    smvSew = sel.Cells[2].Value.ToString();
                }
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (tbNewStyle.Text != "")
            {

                if (checkStyle() && cbbNotChStyle.SelectedIndex == -1)
                {

                    InsertStyle();
                }
                else if (cbbNotChStyle.SelectedIndex == 0)
                {
                    InsertStyle();
                }
                else
                {
                    MessageBox.Show("Don't Have This Style in Similarity Program");
                }
            }
            else
            {
                MessageBox.Show("Text Box is Empty");
            }
        }

        private void InsertStyle()
        {
            if (MessageBox.Show("Are You Sure You Want to Save Data ?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ConnectMySQL.db = "pts_db";//
                bool status = ConnectMySQL.MysqlQuery("INSERT INTO `a_a0sam_cut_sew`(`St_SAM_ID`, `Style`, `SAM_Cut`, `SAM_Sew`) VALUES (NULL,'" + tbNewStyle.Text + "','','');");
                if (status)
                {
                    tbSearch.Text = tbNewStyle.Text;
                    search();
                    MessageBox.Show("OK");
                    tbNewStyle.Text = "";
                    cbbNotChStyle.SelectedIndex = -1;
                }

            }
        }
    }
}
