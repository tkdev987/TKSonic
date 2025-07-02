using Production_Tracking_systems.myClass;
using PTS_For_Cut.Myclass;

namespace PTS_For_Cut.ImportSO
{
    public partial class ucImportSO : UserControl
    {
        public static ucImportSO ins;
        private static ucImportSO _instance;

        public static ucImportSO Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucImportSO();
                return _instance;
            }
        }
        public ucImportSO()
        {
            InitializeComponent();
            ins = this;
        }


        private void btImport_Click(object sender, EventArgs e)
        {
            myExcel.importExcel(tbFileName1, gvExcel);

        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (gvExcel.Rows.Count > 0)
            {
                string oldSo = "";
                ConnectMySQL.db = "pts_db";

                string DeleteMultiValue = "";
                string InsertMultiValue = "";

                for (int i = 0; i < gvExcel.Rows.Count; i++)
                {
                    DataGridViewRow sel = gvExcel.Rows[i];

                    string so = sel.Cells[0].Value.ToString();
                    string Date = sel.Cells[1].Value.ToString();
                    string st = "TKM-" + sel.Cells[2].Value.ToString();
                    string stDec = sel.Cells[3].Value.ToString();
                    string color = sel.Cells[4].Value.ToString();
                    string size = sel.Cells[5].Value.ToString();
                    string qty = sel.Cells[6].Value.ToString();
                    string uPrice = sel.Cells[7].Value.ToString();
                    string unit = sel.Cells[8].Value.ToString();
                    string ccode = sel.Cells[9].Value.ToString();
                    string cname = sel.Cells[10].Value.ToString();
                    string cst = sel.Cells[11].Value.ToString();
                    string cAddr = sel.Cells[12].Value.ToString() + sel.Cells[13].Value.ToString() + sel.Cells[14].Value.ToString() + sel.Cells[15].Value.ToString();

                    if (i == 0)
                    {
                        DeleteMultiValue = "('" + so + "'";

                        InsertMultiValue = "('null', '" + so + "', '" + Date + "', '" + st + "', '" + stDec + "', '" + color + "', '" + size + "', '" + qty + "', '" + uPrice + "', " +
                         "'" + unit + "','" + ccode + "','" + cname + "','" + cst + "','" + cAddr + "')";
                    }
                    else
                    {
                        if (oldSo != so)
                        {
                            DeleteMultiValue = DeleteMultiValue + ",'" + so + "'";
                        }
                        InsertMultiValue = InsertMultiValue + ",('null', '" + so + "', '" + Date + "', '" + st + "', '" + stDec + "', '" + color + "', '" + size + "', '" + qty + "', '" + uPrice + "', " +
                                                "'" + unit + "','" + ccode + "','" + cname + "','" + cst + "','" + cAddr + "')";
                    }

                    oldSo = so;
                }

                ConnectMySQL.MysqlQuery("DELETE FROM `so_tb` WHERE `So`IN" + DeleteMultiValue + ");");

                // MessageBox.Show(DeleteMultiValue);
                ConnectMySQL.MysqlQuery("ALTER TABLE `so_tb` auto_increment = 1;");//StyleDesc
                bool statusSQL = ConnectMySQL.MysqlQuery("INSERT INTO `so_tb`(`ID_So`, `So`,`Date`, `Style`, `StyleDesc`, `Color`, `Size`, `Qty`, `Unit_Price`, `Unit`, " +
                             "`Customer_Code`, `Customer_Name`, `Customer_Style`,`CusAddr`) " +
                             "VALUES" + InsertMultiValue + ";");
                if (statusSQL) { MessageBox.Show("Import Data Successfully"); }
                InsertMultiValue = "";
            }
        }
    }
}
