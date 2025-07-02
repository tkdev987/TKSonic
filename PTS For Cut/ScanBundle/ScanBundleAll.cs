using PTS_For_Cut.myClass;

namespace PTS_For_Cut.ScanBundle
{
    public partial class ScanBundleAll : Form
    {
        public ScanBundleAll()
        {
            InitializeComponent();
        }

        private void ScanBundleAll_Load(object sender, EventArgs e)
        {
            SetUpPosition.CenterLabelInPanel(lbHeader, pnHeader);
        }
    }
}
