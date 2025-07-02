using PTS_For_Cut.Myclass;

namespace PTS_For_Cut.myClass
{
    internal class Calculate
    {
        public static string DocNoAutoGen(string sql, string startText, DateTimePicker dtp) //192.168.7.181
        {
            //sql = SELECT `Spreading_List_No`  FROM `a_spreading_list_tb` ORDER BY `Spreading_List_No` DESC LIMIT 1;
            string txt = "";//SDA2308000001
            ConnectMySQL.db = "pts_db";
            string getDocNoDB = ConnectMySQL.Subtext(sql);
            // MessageBox.Show(getDocNoDB);
            string year = DateTime.Now.ToString("yy");
            string mm = DateTime.Now.ToString("MM");
            string dbmm = "";
            if (getDocNoDB != "") { dbmm = getDocNoDB.Substring(5, 2); }

            int numRun = 0;
            //MessageBox.Show(mm.ToString()+"||"+dbmm);
            if (mm != dbmm)
            {
                numRun = 1;
            }
            else
            {
                numRun = int.Parse(getDocNoDB.Substring(7, 6)) + 1;
                // MessageBox.Show(mm + dbmm);
            }

            txt = startText + year + mm + numRun.ToString("######000000");
            return txt;
        }

        public static int BundleAutoGen(string getBundleNoDB)
        {
            //ConnectMySQL.db = "pts_db";
            //string getBundleNoDB = ConnectMySQL.Subtext(sql);
            //MessageBox.Show(getBundleNoDB);
            int numberRun = 0;
            if (getBundleNoDB != "")
            {
                numberRun = int.Parse(getBundleNoDB.Substring(1, getBundleNoDB.Length - 1));

            }
            return numberRun;
        }
    }
}
