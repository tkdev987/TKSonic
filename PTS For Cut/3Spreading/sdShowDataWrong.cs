using PTS_For_Cut.Myclass;
using PTS_For_Cut.Spreading;

namespace PTS_For_Cut._3Spreading
{
    public partial class sdShowDataWrong : Form
    {
        public sdShowDataWrong()
        {
            InitializeComponent();
        }

        private void sdShowDataWrong_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(sdShowData.ins.BarCodeScan);
            lbheader.Text = lbheader.Text + sdShowData.ins.BarCodeScan;
            gvDisGetData.DataSource = sdShowData.ins.checkFabric;
            if (gvDisGetData.DataSource != null)
            {
                if (gvDisGetData.Rows[0].Cells["ReadyUse"].Value.ToString() == "No Ready")
                {
                    gvDisGetData.Rows[0].Cells["ReadyUse"].Style.BackColor = Color.Red;
                }
                else
                {
                    if (gvDisGetData.Rows[0].Cells["StatusResult"].Value.ToString() == "R")
                    {
                        gvDisGetData.Rows[0].Cells["StatusResult"].Style.BackColor = Color.Red;
                    }
                    else
                    {
                        if (gvDisGetData.Rows[0].Cells["Balance Length YDS"].Value.ToString() != "")
                        {
                            double x = double.Parse(gvDisGetData.Rows[0].Cells["Balance Length YDS"].Value.ToString());
                            if (x <= 0)
                            {
                                gvDisGetData.Rows[0].Cells["Balance Length YDS"].Style.BackColor = Color.Red;
                            }
                        }
                        else
                        {
                            gvDisGetData.Rows[0].Cells["Balance Length YDS"].Style.BackColor = Color.Red;
                        }
                    }

                }
            }
            ConnectMySQL.DisplayAndSearch("SELECT  `Barcode`, `Qty`, `YardNet`, `SD_ListDoc_No` FROM `c_wh1_bc_sdactual_tb` WHERE `Barcode`LIKE '" + sdShowData.ins.BarCodeScan + "'", gvDis);
        }
    }
}
