using PTS_For_Cut.Main;
using PTS_For_Cut.Myclass;
using System.Data;

namespace PTS_For_Cut._9_1Inc
{
    public partial class IncentiveReport : Form
    {
        public static IncentiveReport ins;
        public IncentiveReport()
        {
            InitializeComponent();
            //  this.Activated += IncentiveReport_Activated;
            ins = this;
        }

        private void btIncBreak_Click(object sender, EventArgs e)
        {
            Inc_Break inc_Break = new Inc_Break();
            inc_Break.Show();
        }
        public string Overhead = "";
        public string Wage = "";
        private void IncentiveReport_Load(object sender, EventArgs e)
        {
            DataTable dt = ConnectMySQL.MySQLtoDataTable("SELECT `ParaValue` FROM `i_inc_parameter` WHERE `ParaList`IN ('OverHead','Wage');");
            Overhead = dt.Rows[0][0].ToString();
            Wage = dt.Rows[1][0].ToString();

            dtpDateSt.Value = DateTime.Now;
            dtpDateEn.Value = DateTime.Now;
            UpdateLabel();
        }
        public void UpdateLabel()
        {
            lbGroupBy.Text = "Incentive : " + HomePage.ins.inc_header;
            lbGroupBy.Refresh();
        }

        private void btDataEmp_Click(object sender, EventArgs e)
        {
            Inc_Emp inc_Emp = new Inc_Emp();
            inc_Emp.Show();
        }
    }
}
