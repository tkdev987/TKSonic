using Guna.UI2.WinForms;
using PTS_For_Cut.myClass;
using PTS_For_Cut.Myclass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTS_For_Cut._3Spreading.Report
{
    public partial class Recut : Form
    {
        public Recut()
        {
            InitializeComponent();
        }

        private void Recut_Load(object sender, EventArgs e)
        {

            SetUpPosition.CenterLabelInPanel(lbHeader, pnHeader);
            cbbDep.Items.Clear();
            cbbDep.Items.Add("-");
            for (int i = 0; i < Login.ins.dtDecoration.Rows.Count; i++)
            {
                cbbDep.Items.Add(Login.ins.dtDecoration.Rows[i]["Dec_Eng"].ToString());
            }

            cbbStatus.SelectedIndex = 0;
            cbbDep.SelectedIndex = 0;
            cbbGroupby.SelectedIndex = 0;
            dtpStart.Value = DateTime.Now;
            dtpEnd.Value = DateTime.Now;
            dtpStart.Visible = false;
            dtpEnd.Visible = false;
        }

        private void cbUsedate_CheckedChanged(object sender, EventArgs e)
        {
            if (cbUsedate.Checked)
            {
                dtpStart.Visible = true;
                dtpEnd.Visible = true;
            }
            else
            {
                dtpStart.Visible = false;
                dtpEnd.Visible = false;
            }

        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            search();
        }
        private void search()
        {
            string sql = "";
            string Dep = "";
            string Status = "";
            if (cbbStatus.SelectedIndex == 0)
            {
                Status = " AND dr_cf = 0";
            }
            else if (cbbStatus.SelectedIndex == 1)
            {
                Status = " AND dr_cf = 1";
            }

            if (cbbDep.SelectedIndex > 0)
            {
                Dep = " AND dr_place LIKE '" + cbbDep.Text + "'";
            }
            string dateSearch = "";
            if (cbUsedate.Checked)
            {
                dateSearch = " AND DATE(dr_datetime) BETWEEN '" + datesetUpFormat(dtpStart).ToString("yyyy-MM-dd") + "' AND '" + datesetUpFormat(dtpEnd).ToString("yyyy-MM-dd") + "' ";
            }//SELECT  `dr_place`, `dr_opt`, `dr_color`, `dr_size`, `dr_so`, SUM(`dr_qty`) AS 'QTY' FROM `b_defect_record` WHERE 1;

            string ColumnSQL = "";
            string GroupBy = "";
            if (cbbGroupby.SelectedIndex == 0)
            {
                ColumnSQL = "`dr_place` AS 'Department',`dr_bdno`AS 'BundleNo',`dr_color`AS 'Color', `dr_size` AS 'Size', `dr_so` AS 'SO', SUM(`dr_qty`) AS 'QTY'";
                GroupBy = " GROUP BY `dr_place`,`dr_opt`,`dr_color`,`dr_size`,`dr_so`";
            }
            else if (cbbGroupby.SelectedIndex == 1)
            {
                ColumnSQL = @"`dr_place` AS 'Department' , `dr_qr`AS 'QR_Code', `dr_opt` AS 'Fix Category', `dr_def` AS 'Defect', 
                                    `dr_bdno`AS 'BundleNo', `dr_color`AS 'Color', `dr_size` AS 'Size', `dr_sdno` AS 'SD_ID', 
                                    `dr_style` AS 'Style', `dr_so` AS 'SO', `dr_datetime`AS 'Date_Time', `dr_qty` AS 'QTY', 
                                    `dr_cf` AS 'Status' , `dr_user` AS 'UserReg' ";
                GroupBy = "";
            }
            sql = " SELECT " + ColumnSQL + " FROM b_defect_record WHERE dr_so LIKE '%" + tbSearch.Text + "%' " + Status + Dep + dateSearch + GroupBy + " ORDER BY `dr_so` ;";
            ConnectMySQL.DisplayAndSearch(sql, gvDis);
            if (gvDis.Rows.Count > 0)
            {
                int tt = 0;

                for (int i = 0; i < gvDis.Rows.Count; i++)
                {
                    tt += int.Parse(gvDis.Rows[i].Cells["QTY"].Value.ToString());
                }
                lbtt.Text = tt.ToString();
            }
        }
        private DateTime datesetUpFormat(Guna2DateTimePicker dtp)
        {
            string txtDate = "";
            System.Globalization.CultureInfo _cultureEnInfo = new System.Globalization.CultureInfo("en-US");
            DateTime date = Convert.ToDateTime(dtp.Value, _cultureEnInfo);
            txtDate = date.ToString("yyyy-MM-dd", _cultureEnInfo);
            return DateTime.Parse(txtDate);
        }
    }
}
