using PTS_For_Cut.myClass;

namespace PTS_For_Cut._6Sewing
{
    public partial class SoReport_TimeLine : Form
    {
        public SoReport_TimeLine()
        {
            InitializeComponent();
        }

        private void SoReport_TimeLine_Load(object sender, EventArgs e)
        {
            SetUpPosition.CenterLabelInPanel(lbHeader, pnlbHeader);
        }
    }
}
