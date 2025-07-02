using PTS_For_Cut.Myclass;
using System.Data;

namespace Production_Tracking_systems.myClass
{
    internal class ConvertTable
    {

        public static void SDconvertDBtoTable(string stMySql, int Plies, DataGridView gv)
        {

            DataTable SizeFromMySql = ConnectMySQL.MySQLtoDataTable(stMySql);

            DataTable dtc = new DataTable();
            DataTable dtr = new DataTable();

            dtc = SizeFromMySql.DefaultView.ToTable(true, "Size");
            DataTable col = new DataTable();
            col.Columns.Add("Size");
            foreach (DataRow row in dtc.Rows)
            {
                col.Columns.Add(row[0].ToString());
            }

            col.Rows.Add("QTY/Plies");
            col.Rows.Add("Total");

            for (int i = 0; i < col.Rows.Count; i++)
            {
                for (int j = 1; j < col.Columns.Count; j++)
                {
                    for (int k = 0; k < SizeFromMySql.Rows.Count; k++)
                    {
                        if (i == 0)
                        {

                            if (SizeFromMySql.Rows[k]["Size"].ToString() == col.Columns[j].ToString())
                            {
                                col.Rows[i][j] = SizeFromMySql.Rows[k]["RatioQTY"];
                            }
                        }
                        else
                        {
                            if (SizeFromMySql.Rows[k]["Size"].ToString() == col.Columns[j].ToString())
                            {
                                col.Rows[i][j] = int.Parse(SizeFromMySql.Rows[k]["RatioQTY"].ToString()) * Plies;
                            }
                        }
                    }
                }
            }
            gv.DataSource = col;

        }
        public static void getQTYBySizeBreakdown(string stMySql, DataGridView gv)
        {
            DataTable SizeFromMySql = ConnectMySQL.MySQLtoDataTable(stMySql);
            DataTable dtc = new DataTable();
            DataTable dtr = new DataTable();

            dtc = SizeFromMySql.DefaultView.ToTable(true, "Size");
            DataTable col = new DataTable();
            col.Columns.Add("Color");
            foreach (DataRow row in dtc.Rows)
            {
                col.Columns.Add(row[0].ToString());
            }
            col.Rows.Add("Ratio");
            dtr = SizeFromMySql.DefaultView.ToTable(true, "Color");
            foreach (DataRow row in dtr.Rows)
            {
                col.Rows.Add(row[0].ToString());
            }

            for (int i = 0; i < col.Rows.Count; i++)
            {
                for (int j = 1; j < col.Columns.Count; j++)
                {

                    for (int k = 0; k < SizeFromMySql.Rows.Count; k++)
                    {
                        if (SizeFromMySql.Rows[k]["Size"].ToString() == col.Columns[j].ColumnName)
                        {
                            col.Rows[0][j] = SizeFromMySql.Rows[k]["Ratio"];
                            col.Rows[1][j] = SizeFromMySql.Rows[k]["QTY"];
                        }
                    }
                }
            }
            gv.DataSource = col;

        }
        public static void getQTYBySizeBreakdownReport(string stMySql, DataGridView gv)
        {
            // MessageBox.Show("676");

            DataTable SizeFromMySql = ConnectMySQL.MySQLtoDataTable(stMySql);

            DataTable dtc = new DataTable();
            DataTable dtr = new DataTable();

            dtc = SizeFromMySql.DefaultView.ToTable(true, "Size");
            DataTable col = new DataTable();
            col.Columns.Add("Color");
            foreach (DataRow row in dtc.Rows)
            {
                col.Columns.Add(row[0].ToString());
            }
            //col.Rows.Add("Ratio");
            dtr = SizeFromMySql.DefaultView.ToTable(true, "Color");
            foreach (DataRow row in dtr.Rows)
            {
                col.Rows.Add(row[0].ToString());
            }

            for (int i = 0; i < col.Rows.Count; i++)
            {
                for (int j = 1; j < col.Columns.Count; j++)
                {

                    for (int k = 0; k < SizeFromMySql.Rows.Count; k++)
                    {

                        if (SizeFromMySql.Rows[k]["Size"].ToString() == col.Columns[j].ColumnName)
                        {
                            // col.Rows[0][j] = SizeFromMySql.Rows[k]["Ratio"];
                            col.Rows[i][j] = SizeFromMySql.Rows[k]["QTY"];
                        }
                    }
                }
            }
            gv.DataSource = col;

        }
        public static void StructrueTableOtherData(string stStructrueMySql, string stDataMySql, DataGridView gv)
        {

            DataTable SizeFromMySql = ConnectMySQL.MySQLtoDataTable(stStructrueMySql);
            DataTable DataMySql = ConnectMySQL.MySQLtoDataTable(stDataMySql);


            DataTable dtc = new DataTable();
            DataTable dtr = new DataTable();

            dtc = SizeFromMySql.DefaultView.ToTable(true, "Size");
            DataTable col = new DataTable();
            col.Columns.Add("Colors");
            foreach (DataRow row in dtc.Rows)
            {
                col.Columns.Add(row[0].ToString());
            }

            dtr = SizeFromMySql.DefaultView.ToTable(true, "Color");
            foreach (DataRow row in dtr.Rows)
            {
                col.Rows.Add(row[0].ToString());
            }
            for (int i = 0; i < col.Rows.Count; i++)
            {
                for (int j = 1; j < col.Columns.Count; j++)
                {
                    for (int k = 0; k < DataMySql.Rows.Count; k++)
                    {
                        if (DataMySql.Rows[k][0].ToString() == col.Columns[j].ToString() && DataMySql.Rows[k][1].ToString() == col.Rows[i][0].ToString())
                        {
                            col.Rows[i][j] = DataMySql.Rows[k][2];
                        }
                    }
                }
            }
            gv.DataSource = col;
            col.Columns.Add("Sum");
            col.Rows.Add("Sum");
            int rowSum = 0;
            for (int i = 0; i < col.Rows.Count - 1; i++)
            {
                for (int j = 1; j < col.Columns.Count - 1; j++)
                {
                    if (col.Rows[i][j] != DBNull.Value)
                    {
                        rowSum += int.Parse(col.Rows[i][j].ToString());
                    }
                }
                col.Rows[i][col.Columns.Count - 1] = rowSum;
                rowSum = 0;
            }
            for (int i = 1; i < col.Columns.Count; i++)
            {
                for (int j = 0; j < col.Rows.Count - 1; j++)
                {
                    if (col.Rows[j][i] != DBNull.Value)
                    {
                        rowSum += int.Parse(col.Rows[j][i].ToString());
                    }
                }
                col.Rows[col.Rows.Count - 1][i] = rowSum;
                rowSum = 0;
            }
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = Color.Gainsboro;
            style.ForeColor = Color.Black;
            gv.Rows[col.Rows.Count - 1].DefaultCellStyle = style;
            gv.Columns[col.Columns.Count - 1].DefaultCellStyle = style;
            gv.Columns[0].DefaultCellStyle = style;
            gv.Columns[0].ReadOnly = true;
            for (int i = 0; i < gv.Columns.Count; i++)
            {
                if (i == 0)
                {
                    gv.Columns[i].Width = 120;
                }
                else
                {
                    gv.Columns[i].Width = 70;
                }
            }
        }
        public static void StructrueTableOnly(string stMySql, DataGridView gv)
        {

            DataTable SizeFromMySql = ConnectMySQL.MySQLtoDataTable(stMySql);

            DataTable dtc = new DataTable();
            DataTable dtr = new DataTable();

            dtc = SizeFromMySql.DefaultView.ToTable(true, "Size");
            DataTable col = new DataTable();
            col.Columns.Add("Colors");
            foreach (DataRow row in dtc.Rows)
            {
                col.Columns.Add(row[0].ToString());
            }
            dtr = SizeFromMySql.DefaultView.ToTable(true, "Color");
            foreach (DataRow row in dtr.Rows)
            {
                col.Rows.Add(row[0].ToString());
            }

            gv.DataSource = col;
            col.Columns.Add("Sum");
            col.Rows.Add("Sum");

            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = Color.Gainsboro;
            style.ForeColor = Color.Black;
            gv.Rows[col.Rows.Count - 1].DefaultCellStyle = style;
            gv.Columns[col.Columns.Count - 1].DefaultCellStyle = style;
            gv.Columns[0].DefaultCellStyle = style;
            gv.Columns[0].ReadOnly = true;
            for (int i = 0; i < gv.Columns.Count; i++)
            {
                if (i == 0)
                {
                    gv.Columns[i].Width = 120;
                }
                else
                {
                    gv.Columns[i].Width = 70;
                }
            }

        }
        public static void CalTable(DataGridView gv)
        {
            DataTable col = new DataTable();
            col = (DataTable)gv.DataSource;
            int rowSum = 0;

            for (int i = 0; i < col.Rows.Count - 1; i++)
            {
                for (int j = 1; j < col.Columns.Count - 1; j++)
                {
                    if (col.Rows[i][j].GetType() == typeof(string))
                    {
                        if (col.Rows[i][j] != "")
                        {

                            rowSum += int.Parse(col.Rows[i][j].ToString());

                        }
                    }
                    else if (col.Rows[i][j].GetType() == typeof(DBNull))
                    {
                        if (col.Rows[i][j] != DBNull.Value)
                        {
                            rowSum += int.Parse(col.Rows[i][j].ToString());
                        }
                    }
                }
                col.Rows[i][col.Columns.Count - 1] = rowSum;
                rowSum = 0;
            }

            for (int i = 1; i < col.Columns.Count; i++)
            {
                for (int j = 0; j < col.Rows.Count - 1; j++)
                {

                    if (col.Rows[j][i].GetType() == typeof(string))
                    {
                        if (col.Rows[j][i] != "")
                        {
                            rowSum += int.Parse(col.Rows[j][i].ToString());
                        }
                    }
                    else if (col.Rows[j][i].GetType() == typeof(DBNull))
                    {
                        if (col.Rows[j][i] != DBNull.Value)
                        {
                            rowSum += int.Parse(col.Rows[j][i].ToString());
                        }
                    }

                }
                col.Rows[col.Rows.Count - 1][i] = rowSum;
                rowSum = 0;
            }
            gv.DataSource = col;
        }
        public static void CopyDataSource(DataGridView gvOle, DataGridView gvNew)
        {
            for (int i = 0; i < gvOle.RowCount; i++)
            {
                for (int j = 1; j < gvOle.ColumnCount; j++)
                {
                    gvNew.Rows[i].Cells[j].Value = gvOle.Rows[i].Cells[j].Value;

                }
            }

        }

    }
}
