namespace PTS_For_Cut.myClass
{
    internal class SetUpPosition
    {
        public static void CenterLabelInPanel(Label lb, Panel pn)
        {
            lb.Left = (pn.Width - lb.Width) / 2;
            lb.Top = (pn.Height - lb.Height) / 2;
        }
    }
}
