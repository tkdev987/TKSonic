using MySql.Data.MySqlClient;
using System.Data;

namespace PTS_For_Cut.Myclass
{
    internal class ConnectMySQL
    {
        public static string ip = "", db = "", IPport = "";


        public static MySqlConnection GetConnection() //192.168.7.181
        {
            //MessageBox.Show("datasource=" + ip + ";port=" + IPport + ";username=root1;password='88888888';database=" + db + ";convert zero datetime=True");
            MySqlConnection con = new MySqlConnection("datasource=" + ip + ";port=" + IPport + ";username=root1;password='88888888';database=" + db + ";convert zero datetime=True;Connect Timeout=30;");
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
            }
            catch (MySqlException ex)
            {
                con.Close();
                MessageBox.Show("My Connection! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return con;
        }
        public static string Subtext(string query)
        {
            string txt = "";
            string sql = query;
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            MySqlDataReader myReder;

            try
            {
                myReder = cmd.ExecuteReader();
                while (myReder.Read())
                {
                    txt = myReder.GetString(0);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                // lb.Text = "ไม่เจอ";
            }
            con.Close();
            return txt;
        }
        public static void textTolable(string query, Label lb)
        {
            if (GetConnection().State != ConnectionState.Closed)
            {
                string sql = query;
                MySqlConnection con = GetConnection();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                MySqlDataReader myReder;

                try
                {
                    myReder = cmd.ExecuteReader();
                    while (myReder.Read())
                    {
                        lb.Text = myReder.GetString(0);
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    // lb.Text = "ไม่เจอ";
                }

                con.Close();
            }
        }
        public static void ComboBoxListInGV(string query, DataGridViewComboBoxColumn cbb)
        {
            if (GetConnection().State != ConnectionState.Closed)
            {
                cbb.Items.Add("");
                string sql = query;
                MySqlConnection con = GetConnection();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                MySqlDataReader myReder;
                try
                {
                    myReder = cmd.ExecuteReader();
                    while (myReder.Read())
                    {
                        string itemCombo = myReder.GetString(0);
                        cbb.Items.Add(itemCombo);
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                con.Close();
            }
        }
        //public static bool MysqlQuery(string sql)
        //{
        //    bool status = false;

        //    using (MySqlConnection con = GetConnection())
        //    {
        //        if (con.State != ConnectionState.Closed)
        //        {
        //            MySqlCommand cmd = new MySqlCommand(sql, con);
        //            try
        //            {
        //                int affectedRows = cmd.ExecuteNonQuery();
        //                status = affectedRows > 0;
        //            }
        //            catch (MySqlException ex)
        //            {
        //                // Handle exception
        //                MessageBox.Show(ex.Message);
        //                status = false;
        //            }
        //            finally
        //            {
        //                con.Close();
        //            }
        //        }
        //    }
        //    return status;
        //}
        public static bool MysqlQuery(string sql)
        {
            bool status = false;

            using (MySqlConnection con = GetConnection())
            {
                try
                {
                    // Open the connection if it's not already open
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        int affectedRows = cmd.ExecuteNonQuery();
                        status = affectedRows > 0; // True if rows are affected
                    }
                }
                catch (MySqlException ex)
                {
                    // Show the error message in case of an exception
                    MessageBox.Show($"Error: {ex.Message}", "MySQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    status = false;
                }
                finally
                {
                    // Ensure the connection is closed
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }

            return status;
        }


        public static void DisplayAndSearch(string query, DataGridView dgv)
        {
            if (GetConnection().State != ConnectionState.Closed)
            {
                string sql = query;
                MySqlConnection con = GetConnection();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dgv.DataSource = dt;
                con.Close();
            }
        }
        public static DataTable MySQLtoDataTable(string query)
        {
            if (GetConnection().State != ConnectionState.Closed)
            {
                DataTable dt = new DataTable();
                string sql = query;
                using (MySqlConnection con = GetConnection())
                {

                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        using (MySqlDataAdapter adp = new MySqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = con;
                            adp.SelectCommand = cmd;
                            adp.Fill(dt);
                            return dt;
                        }
                    }

                }
            }
            return null;
        }

        public static void ComboboxList(string query, ComboBox cbb)
        {
            if (GetConnection().State != ConnectionState.Closed)
            {
                string sql = query;
                MySqlConnection con = GetConnection();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                MySqlDataReader myReder;
                try
                {
                    myReder = cmd.ExecuteReader();
                    while (myReder.Read())
                    {
                        string itemCombo = myReder.GetString(0);
                        cbb.Items.Add(itemCombo);
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                con.Close();
            }
        }

        public static bool AddgvtoDBplies(string sql, string sdidRef, DataGridView gv)
        {
            try
            {
                // เปิดการเชื่อมต่อกับ MySQL
                MySqlConnection con = GetConnection();
                // เริ่มการทำงานของ Transaction
                MySqlTransaction transaction = con.BeginTransaction();
                try
                {
                    for (int i = 0; i < gv.Rows.Count; i++)
                    {
                        string cell1 = gv.Rows[i].Cells[2].Value.ToString();
                        string cell2 = gv.Rows[i].Cells[3].Value.ToString();
                        string cell3 = gv.Rows[i].Cells[4].Value.ToString();
                        string cell4 = gv.Rows[i].Cells[5].Value.ToString();
                        string cell5 = gv.Rows[i].Cells[6].Value.ToString();
                        string condition = gv.Rows[i].Cells[1].Value.ToString();//
                        //MessageBox.Show(newPlies);
                        MySqlCommand command = con.CreateCommand();
                        command.Transaction = transaction;
                        command.CommandText = sql;// "UPDATE ชื่อตาราง SET ชื่อคอลัมน์ = @newValue WHERE เงื่อนไข = @condition";

                        command.Parameters.AddWithValue("@Cell1", cell1);
                        command.Parameters.AddWithValue("@Cell2", cell2);
                        command.Parameters.AddWithValue("@Cell3", cell3);
                        command.Parameters.AddWithValue("@Cell4", cell4);
                        command.Parameters.AddWithValue("@Cell5", cell5);
                        command.Parameters.AddWithValue("@condition", condition);
                        command.ExecuteNonQuery();
                    }
                    // ถ้าไม่มีปัญหา ทำการ Commit Transaction
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    // ถ้าเกิดข้อผิดพลาด ทำการ Rollback Transaction
                    transaction.Rollback();
                    throw ex;

                }
                finally
                {
                    // ปิดการเชื่อมต่อ MySQL เมื่อทำการอัปเดตแล้ว
                    // MessageBox.Show("OK");

                    con.Close();

                }
            }
            catch (Exception ex)
            {
                // จัดการกับข้อผิดพลาดที่เกิดขึ้น
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message);
                return false;

            }
        }
        public static void UpdateIndexSort(DataGridView gv)
        {//string sql, string sdidRef,  ConnectMySQL.AddgvtoDBplies("UPDATE `c_warehouse1_bc_tb` SET `SD_ListDoc_No`=@SDIDREF,`PliesActual`=@Cell1,`RestFabric`=@Cell2,`Defect`=@Cell3,`LappingFabric`=@Cell4 WHERE `Barcode`=@condition;", tbSDid.Text, gvFabric);

            string sql = "UPDATE `c_warehouse1_bc_tb` SET `IndexSort`=@Index WHERE `Barcode`=@condition;";
            try
            {
                // เปิดการเชื่อมต่อกับ MySQL
                MySqlConnection con = GetConnection();
                // เริ่มการทำงานของ Transaction
                MySqlTransaction transaction = con.BeginTransaction();
                try
                {
                    for (int i = 0; i < gv.Rows.Count; i++)
                    {
                        string RowIndex = i.ToString();
                        string condition = gv.Rows[i].Cells["Barcode"].Value.ToString();
                        MySqlCommand command = con.CreateCommand();
                        command.Transaction = transaction;
                        command.CommandText = sql;// "UPDATE ชื่อตาราง SET ชื่อคอลัมน์ = @newValue WHERE เงื่อนไข = @condition"; 
                        command.Parameters.AddWithValue("@Index", RowIndex);
                        command.Parameters.AddWithValue("@condition", condition);
                        command.ExecuteNonQuery();
                    }
                    // ถ้าไม่มีปัญหา ทำการ Commit Transaction
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // ถ้าเกิดข้อผิดพลาด ทำการ Rollback Transaction
                    transaction.Rollback();
                    throw ex;
                    /// return true;
                }
                finally
                {
                    // ปิดการเชื่อมต่อ MySQL เมื่อทำการอัปเดตแล้ว
                    // MessageBox.Show("OK");
                    con.Close();
                    //return true;
                }
            }
            catch (Exception ex)
            {
                // จัดการกับข้อผิดพลาดที่เกิดขึ้น
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message);
                //  return false;

            }
        }
        public static void addColumnDBtoTB(string query, DataGridView gv)
        {
            if (GetConnection().State != ConnectionState.Closed)
            {
                string sql = query + "ORDER BY FIELD(size, 'XXS', 'XS', 'S', 'M', 'L', 'XL', 'XXL', 'XXXL'), size";
                MySqlConnection con = GetConnection();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                MySqlDataReader myReder;
                DataTable dt = new DataTable();
                try
                {
                    myReder = cmd.ExecuteReader();
                    while (myReder.Read())
                    {
                        string itemCombo = myReder.GetString(0);
                        dt.Columns.Add(itemCombo, typeof(System.String));
                        // cbb.Items.Add(itemCombo);
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //adp.Fill(dt);
                gv.DataSource = dt;
                con.Close();
            }
        }



        public static void GetDataToStringArray(string sql, string[] textS)
        {
            if (GetConnection().State != ConnectionState.Closed)
            {
                MySqlConnection con = GetConnection();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                // MessageBox.Show(dt.Rows.Count.ToString());
                try
                {
                    foreach (DataRow dr in dt.Rows)
                    // for (int i = 0; i < dt.Columns.Count; i++)
                    {

                        // textS[] = dt.Rows[i];
                        textS = textS.Concat(new string[] { dr.ToString() }).ToArray();


                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                con.Close();
            }
        }
        public static void insertImg(PictureBox pictureBox1)
        {
            if (GetConnection().State != ConnectionState.Closed)
            {
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] img = ms.ToArray();

                String insertQuery = "INSERT INTO `info_style_tb`(`styleID`, `img`,`date`) VALUES(@id,@img,@date)";


                MySqlConnection con = GetConnection();
                MySqlCommand command = new MySqlCommand(insertQuery, con);
                command.Parameters.Add("@id", MySqlDbType.VarChar, 20);
                command.Parameters.Add("@date", MySqlDbType.Date);
                command.Parameters.Add("@img", MySqlDbType.LongBlob);
                command.Parameters["@id"].Value = "1";
                command.Parameters["@date"].Value = "2022-12-17";
                command.Parameters["@img"].Value = img;

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Data Inserted");
                }

                con.Close();
            }
        }
        public static bool StoredProcedure(string query, MySqlParameter[] parameters, CommandType commandType)
        {
            bool status = false;

            using (MySqlConnection connection = GetConnection())
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.CommandType = commandType; // Set the CommandType

                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            status = reader.GetBoolean("InsertStatus");

                        }
                    }
                }
            }

            return status;
        }

    }
}
