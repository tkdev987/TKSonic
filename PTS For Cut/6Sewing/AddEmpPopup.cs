using PTS_For_Cut.Myclass;
using System.Data;

namespace PTS_For_Cut._6Sewing
{
    public partial class AddEmpPopup : Form
    {
        public AddEmpPopup()
        {
            InitializeComponent();
        }

        private void AddEmpPopup_Load(object sender, EventArgs e)
        {
            string eemp = EmpSkillofEachgarment.ins.emp;
            string empPath = MutiSkill.ins.empImgPath;
            DataTable dtOper = EmpSkillofEachgarment.ins.dtOperation;
            cbbOperation.Items.Clear();
            for (int i = 0; i < dtOper.Rows.Count; i++)
            {
                cbbOperation.Items.Add(dtOper.Rows[i]["OperationName"].ToString());
            }

            if (eemp != "")
            {
                ConnectMySQL.db = "emp_leave";
                DataTable dt = ConnectMySQL.MySQLtoDataTable("SELECT `e_id`,`employee_name`,`isActive`,`employee_photo` FROM `employee` WHERE `e_id` LIKE '" + eemp + "';");
                ConnectMySQL.db = "pts_db";
                if (dt.Rows.Count > 0)
                {
                    tbEmpIDName.Text = dt.Rows[0]["e_id"].ToString() + " - " + dt.Rows[0]["employee_name"].ToString();
                    if (dt.Rows[0]["isActive"].ToString() == "True")
                    {
                        tbStatus.Text = "Active";
                        btAddEmp.Enabled = true;
                    }
                    else
                    {
                        tbStatus.Text = "Resign";
                        btAddEmp.Enabled = false;
                    }
                    string imgName = dt.Rows[0]["employee_name"].ToString();
                    string sPath = Path.Combine(empPath, imgName);

                    // Check if the file exists
                    if (File.Exists(sPath))
                    {
                        ptb1.Image = System.Drawing.Image.FromFile(sPath);
                    }
                    else
                    {
                        MessageBox.Show($"The file '{sPath}' was not found.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show($"Don't have data", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                }
            }

        }

        private void btAddEmp_Click(object sender, EventArgs e)
        {
            if (cbbOperation.SelectedIndex > -1)
            {
                EmpSkillofEachgarment.ins.selectIndexOfOption = cbbOperation.SelectedIndex + 1;
                DialogResult = DialogResult.OK;
            }

        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
