using PTS_For_Cut.Main;
using PTS_For_Cut.Myclass;

namespace PTS_For_Cut._9_1Inc
{
    public partial class FormSetting : Form
    {
        public FormSetting()
        {
            InitializeComponent();
        }

        private void FormSetting_Load(object sender, EventArgs e)
        {
            lbGroupBy.Text = HomePage.ins.inc_header;
            tbOverhead.Text = ConnectMySQL.Subtext("SELECT para_Value  FROM i_inc_parameter WHERE  para_Name = 'Overhead' AND para_Group = '" + lbGroupBy.Text + "'");
            tbWage.Text = ConnectMySQL.Subtext("SELECT para_Value  FROM i_inc_parameter WHERE  para_Name = 'Wage' AND para_Group = '" + lbGroupBy.Text + "'");
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            InsertData();
        }

        private void InsertData()
        {
            if (MessageBox.Show("Are you sure want to Add", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (string.IsNullOrWhiteSpace(tbOverhead.Text) || string.IsNullOrWhiteSpace(tbWage.Text))
                {
                    MessageBox.Show("Please fill in information!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // ข้อมูลที่ต้องการบันทึก
                string lb1 = "Overhead";
                string text1 = tbOverhead.Text;
                string lb2 = "Wage";
                string text2 = tbWage.Text;


                ConnectMySQL.db = "pts_db";
                ConnectMySQL.MysqlQuery("DELETE FROM i_inc_parameter WHERE para_Name IN ('" + lb1 + "', '" + lb2 + "') AND para_Group = '" + lbGroupBy.Text + "'");
                ConnectMySQL.MysqlQuery("ALTER TABLE i_inc_parameter auto_increment = 1;");

                bool statusAdd = ConnectMySQL.MysqlQuery("INSERT INTO i_inc_parameter (para_Name, para_Value, para_Group) " +
                                          "VALUES ('" + lb1 + "', '" + tbOverhead.Text + "', '" + lbGroupBy.Text + "'),('" + lb2 + "', '" + tbWage.Text + "', '" + lbGroupBy.Text + "')");


                if (statusAdd)
                {
                    MessageBox.Show("Add Successfully", "Imformation", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Insertion failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }
    }
}
