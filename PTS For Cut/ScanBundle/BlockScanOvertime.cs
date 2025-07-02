using PTS_For_Cut.myClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTS_For_Cut.ScanBundle
{
    public partial class BlockScanOvertime : Form
    {
        public static BlockScanOvertime ins;
        public BlockScanOvertime()
        {
            InitializeComponent();
            ins = this;
        }

        private void BlockScanOvertime_Load(object sender, EventArgs e)
        {
            SetUpPosition.CenterLabelInPanel(label1, panel1);
            gvDis.DataSource = ScanInOutWithSummery.ins.dn_Over4hour_dt;
            gvDis.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Visible = !pictureBox1.Visible;
        }

        private void gvDis_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                var gv = gvDis.Rows[e.RowIndex];
                ScanInOutWithSummery.ins.DN_ID = gv.Cells["DeliveryNoteID"].Value.ToString();
                DN_detail dN_Detail = new DN_detail();
                dN_Detail.Show();
            }
        }
    }
}
