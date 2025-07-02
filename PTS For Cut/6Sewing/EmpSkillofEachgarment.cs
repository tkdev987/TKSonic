using PTS_For_Cut.Myclass;
using System.Data;

namespace PTS_For_Cut._6Sewing
{
    public partial class EmpSkillofEachgarment : Form
    {
        public static EmpSkillofEachgarment ins;
        public EmpSkillofEachgarment()
        {
            InitializeComponent();
            ins = this;
        }


        public DataTable dtgarmentTypeList = new DataTable();
        private void EmpSkillofEachgarment_Load(object sender, EventArgs e)
        {
            gvDis.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gvDisDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            path = MutiSkill.ins.PathImg;
            DataTable dt = new DataTable();
            dt = Login.ins.Line_dt;
            cbbLine.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbbLine.Items.Add(dt.Rows[i]["Line"].ToString());
            }
            dtgarmentTypeList = ConnectMySQL.MySQLtoDataTable("SELECT CONCAT( `GarmentTypeCode`,'-',`GarmentType` ) AS 'GarmentType' FROM `garmenttype_tb` WHERE 1;");
            cbbGarmentType.Items.Clear();
            for (int i = 0; i < dtgarmentTypeList.Rows.Count; i++)
            {
                cbbGarmentType.Items.Add(dtgarmentTypeList.Rows[i]["GarmentType"].ToString());
            }
        }

        private void LoadLine()
        {
            if (cbbLine.SelectedIndex != -1)
            {
                ConnectMySQL.DisplayAndSearch("SELECT `GarmentTypeNumber`, `ST_Appear`  FROM `a_emp_multi_skill_tb` " +
                    "WHERE `Line` LIKE '" + cbbLine.Text + "' GROUP BY `GarmentTypeNumber`,`Line`", gvDis);
            }
        }
        private void cbbLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLine();
        }
        string garmentType_txt = "";
        private void cbbGarmentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbGarmentTypeNumber.SelectedIndex = -1;
            garmentType_txt = cbbGarmentType.Text.Split('-')[0];
            string txtSql = @"SELECT DISTINCT(`GarmentTypeCode`) AS `GarmentTypeCode` FROM `a_operation_garment_type` 
                            WHERE SUBSTRING(`GarmentTypeCode`,1,3) LIKE '" + garmentType_txt + "' ORDER BY `GarmentTypeCode` ASC;";
            DataTable dtGarmentTypeCode = ConnectMySQL.MySQLtoDataTable(txtSql);
            cbbGarmentTypeNumber.Items.Clear();
            for (int i = 0; i < dtGarmentTypeCode.Rows.Count; i++)
            {
                cbbGarmentTypeNumber.Items.Add(dtGarmentTypeCode.Rows[i]["GarmentTypeCode"].ToString());
            }
        }

        private void btUp_Click(object sender, EventArgs e)
        {
            //MoveRow(false, gvDisDetail, ref IndexRowgv_DisDetail); // Move Up
            if (IndexRowgv_DisDetail > -1)
            {
                DataTable dt = new DataTable();
                dt = (DataTable)gvDisDetail.DataSource;
                MessageBox.Show(dt.Rows.Count.ToString());
                object[] arr0 = dt.Rows[IndexRowgv_DisDetail - 1].ItemArray;
                object[] arr1 = dt.Rows[IndexRowgv_DisDetail].ItemArray;
                dt.Rows[IndexRowgv_DisDetail - 1].ItemArray = arr1;
                dt.Rows[IndexRowgv_DisDetail].ItemArray = arr0;
                IndexRowgv_DisDetail--;
            }
        }


        private void btDown_Click(object sender, EventArgs e)
        {
            if (IndexRowgv_DisDetail > -1)
            {
                DataTable dt = new DataTable();
                dt = (DataTable)gvDis.DataSource;
                object[] arr0 = dt.Rows[IndexRowgv_DisDetail + 1].ItemArray;
                object[] arr1 = dt.Rows[IndexRowgv_DisDetail].ItemArray;
                dt.Rows[IndexRowgv_DisDetail + 1].ItemArray = arr1;
                dt.Rows[IndexRowgv_DisDetail].ItemArray = arr0;
                IndexRowgv_DisDetail++;
            }
        }
        public DataTable dtOperation = new DataTable();
        private void btAdd_Click(object sender, EventArgs e)
        {
            if (cbbLine.SelectedIndex > -1 && cbbGarmentTypeNumber.SelectedIndex > -1 && ckeckClickcbb)
            {
                setUpColumnS(cbbGarmentTypeNumber.Text);
                ckeckClickcbb = false;
            }
            else
            {
                MessageBox.Show("Please Select Combobox.");
            }
        }
        private void setUpColumnS(string garmentNumber)
        {

            if (gvDisDetail.Columns.Count > 0)
            {
                // Iterate through columns in reverse order to safely remove each column
                for (int i = gvDisDetail.Columns.Count - 1; i >= 0; i--)
                {
                    gvDisDetail.Columns.RemoveAt(i);
                }
            }
            DataTable dt = new DataTable();
            dtOperation = ConnectMySQL.MySQLtoDataTable("SELECT `OperationName`,`Opt_Code`  FROM `a_operation_garment_type` WHERE `GarmentTypeCode` LIKE '" + garmentNumber + "' ORDER BY `Seq` ASC;");
            dt.Columns.Add("Emp");
            //gvDisDetail.Columns.Add("Emp", "Emp");

            for (int i = 0; i < dtOperation.Rows.Count; i++)
            {
                string columnName = dtOperation.Rows[i]["OperationName"].ToString();
                // gvDisDetail.Columns.Add(columnName, columnName);
                dt.Columns.Add(columnName);
            }
            gvDisDetail.DataSource = dt;
        }
        private void toolStrip6_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btOperation1_Click(object sender, EventArgs e)
        {

            Add_Operation add_Operation = new Add_Operation();
            add_Operation.Show();
        }
        public string emp = "";
        public int selectIndexOfOption = -1;
        private void btAddEmp_Click(object sender, EventArgs e)
        {
            if (cbbLine.SelectedIndex > -1 && cbbGarmentTypeNumber.SelectedIndex > -1 && cbbGarmentType.SelectedIndex > -1)
            {

                emp = "";
                if (tbEmp.Text.Trim() != "")
                {
                    emp = tbEmp.Text.Trim();
                    using (AddEmpPopup di = new AddEmpPopup())
                    {
                        if (di.ShowDialog() == DialogResult.OK)
                        {
                            int indexRowS = 0;
                            if (gvDisDetail.RowCount > 0)
                            { indexRowS = gvDisDetail.RowCount; }

                            bool st = SetValueForCell(gvDisDetail, indexRowS, selectIndexOfOption, emp, "0");
                            if (!st)
                            {
                                MessageBox.Show("Status is not finished yet.");
                            }
                            else
                            {
                                tbEmp.Text = "";
                            }

                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Select Combobox.");
            }


        }
        //private void AutoAddColumns(DataGridView dataGridView, int columnQuantity)
        //{
        //    // Ensure we only add the necessary number of columns
        //    for (int i = 0; i < columnQuantity; i++)
        //    {
        //        string columnNameAndHeader = $"Column{i + 1}";

        //        // Add a new column with the same name and header
        //        dataGridView.Columns.Add(columnNameAndHeader, columnNameAndHeader);
        //    }
        //}

        private bool SetValueForCell(DataGridView dataGridView, int rowIndex, int columnIndex, string empID, string value)
        {
            // Assume the DataGridView is bound to a DataTable
            var dataSource = dataGridView.DataSource as DataTable;

            if (dataSource == null)
            {
                MessageBox.Show("DataGridView is not bound to a valid DataTable.");
                return false;
            }

            // Check for duplicate EmpID
            bool checkDuplicate = dataSource.AsEnumerable().Any(row => row["Emp"].ToString() == empID);

            if (string.IsNullOrEmpty(value) || checkDuplicate)
            {
                if (checkDuplicate)
                {
                    MessageBox.Show("Value Duplicate Can't insert.");
                }
                else
                {
                    MessageBox.Show("Status is not finished yet.");
                }

                return false;
            }
            else
            {
                // Add a new row to the DataTable if necessary
                if (rowIndex >= dataSource.Rows.Count)
                {
                    DataRow newRow = dataSource.NewRow();
                    newRow["Emp"] = empID;
                    newRow[columnIndex] = value;
                    dataSource.Rows.Add(newRow);
                }
                else
                {
                    // Update an existing row
                    DataRow existingRow = dataSource.Rows[rowIndex];
                    existingRow["Emp"] = empID;
                    existingRow[columnIndex] = value;
                }

                // Update DataGridView cell style
                dataGridView.Rows[rowIndex].Cells[columnIndex].Style.BackColor = System.Drawing.Color.Silver;
                return true;
            }
        }

        string path = "";
        bool ckeckClickcbb = false;
        private void cbbGarmentTypeNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            ckeckClickcbb = true;
            if (!string.IsNullOrEmpty(path) && cbbGarmentTypeNumber.SelectedIndex > -1)
            {
                string sPath = Path.Combine(path, cbbGarmentTypeNumber.Text + ".jpg");

                // Check if the file exists
                if (File.Exists(sPath))
                {
                    ptb1.Image = System.Drawing.Image.FromFile(sPath);
                }
                else
                {
                    MessageBox.Show($"The file '{sPath}' was not found.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (cbbGarmentTypeNumber.SelectedIndex > -1)
                    MessageBox.Show("Please select a valid garment type and ensure the path is set.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (cbbLine.SelectedIndex > -1 && cbbGarmentTypeNumber.SelectedIndex > -1 && cbbGarmentType.SelectedIndex > -1)
            {
                string insertMultiValue = "";

                bool first = false;
                int seq = 0;
                if (gvDisDetail.IsCurrentCellDirty)
                {
                    gvDisDetail.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                for (int i = 0; i < gvDisDetail.Rows.Count; i++)
                {
                    for (int j = 0; j < gvDisDetail.Columns.Count; j++)
                    {
                        //MessageBox.Show(gvDisDetail.Rows[i].Cells[j].Value.GetType().ToString());
                        //MessageBox.Show(gvDisDetail.Rows[i].Cells[j].Value.ToString());
                        if (gvDisDetail.Rows[i].Cells[j].Value.ToString() != "" && j > 0)
                        {

                            int MainOperation = 0;
                            if (gvDisDetail.Rows[i].Cells[j].Style.BackColor == Color.Silver)
                            {
                                MainOperation = 1;
                            }
                            string txtValue = gvDisDetail.Rows[i].Cells[j].Value.ToString();
                            int valuetxt = 0;
                            if (txtValue.Trim() != "")
                            {
                                if (txtValue != "0")
                                {

                                    valuetxt = int.Parse(txtValue.Trim());
                                }

                            }

                            string empId = gvDisDetail.Rows[i].Cells[0].Value.ToString();
                            string opt = dtOperation.Rows[j - 1]["Opt_Code"].ToString();

                            if (!first)
                            {
                                insertMultiValue = "(NULL, '" + empId + "','" + cbbLine.Text + "','" + opt + "','" + cbbGarmentTypeNumber.Text + "','" + valuetxt + "','" + seq.ToString() + "','" + st_show_on_mainpage + "','" + MainOperation.ToString() + "')";
                                first = true;
                            }
                            else
                            {
                                insertMultiValue = insertMultiValue + ",(NULL, '" + empId + "','" + cbbLine.Text + "','" + opt + "','" + cbbGarmentTypeNumber.Text + "','" + valuetxt + "','" + seq.ToString() + "','" + st_show_on_mainpage + "','" + MainOperation.ToString() + "')";
                            }
                            seq++;


                        }
                    }
                }



                if (insertMultiValue != "")
                {
                    string deletesql = "DELETE FROM `a_emp_multi_skill_tb` WHERE `Line` LIKE '" + cbbLine.Text + "' AND  `GarmentTypeNumber`='" + cbbGarmentTypeNumber.Text + "'; ";
                    string re = "ALTER TABLE `a_emp_multi_skill_tb` auto_increment = 1;";
                    string txtSql = deletesql + re + "INSERT INTO `a_emp_multi_skill_tb`(`id`, `EmpID`, `Line`, `Opt_Code`, `GarmentTypeNumber`, `Eff_Emp`, `Seq`, `ST_Appear`, `MainOperation`) " +
                                                     "VALUES" + insertMultiValue + ";";

                    bool st = ConnectMySQL.MysqlQuery(txtSql);
                    if (st)
                    {
                        MessageBox.Show("Ok.");
                        LoadLine();
                    }
                    else
                    {
                        MessageBox.Show("Can't Save.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Select Combobox.");
            }
        }
        int indexRows_gvDis = -1;
        DataTable getDataEmp = new DataTable();
        List<IndexedValue> indexedList = new List<IndexedValue>();
        int st_show_on_mainpage = -1;
        private void gvDis_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                st_show_on_mainpage = 0;
                if (gvDis.Rows[e.RowIndex].Cells["ST_Appear"].Value.ToString() == "True")
                {
                    st_show_on_mainpage = 1;
                }
                indexRows_gvDis = e.RowIndex;
                string gmNumber = gvDis.Rows[e.RowIndex].Cells[0].Value.ToString();
                for (int i = 0; i < cbbGarmentType.Items.Count; i++)
                {

                    if (cbbGarmentType.Items[i].ToString().Split('-')[0] == gmNumber.Substring(0, 3))
                    {
                        cbbGarmentType.SelectedIndex = i;
                        break;
                    }
                }
                cbbGarmentTypeNumber.Text = gmNumber;

                setUpColumnS(gmNumber);

                getDataEmp = ConnectMySQL.MySQLtoDataTable(@"
                    SELECT`EmpID`, `Opt_Code`, `Eff_Emp`, `MainOperation` FROM `a_emp_multi_skill_tb` 
                    WHERE `GarmentTypeNumber` LIKE '" + gmNumber + "' AND `Line`LIKE '" + cbbLine.Text + "' ORDER BY `Seq` ASC;");
                if (getDataEmp.Rows.Count > 0)
                {
                    indexedList = new List<IndexedValue>();
                    string checkAddNewRow = "";
                    string checkAddNewRow_Sub = "";
                    string checkAddNewRow_Sub2 = "";
                    DataTable dt = new DataTable();
                    dt = (DataTable)gvDisDetail.DataSource;
                    for (int i = 0; i < getDataEmp.Rows.Count; i++)
                    {
                        checkAddNewRow = getDataEmp.Rows[i]["EmpID"].ToString();
                        for (int j = 0; j < dtOperation.Rows.Count; j++)
                        {
                            if (checkAddNewRow_Sub != checkAddNewRow)
                            {
                                if (checkAddNewRow_Sub2 != checkAddNewRow)
                                {
                                    dt.Rows.Add(checkAddNewRow);
                                    checkAddNewRow_Sub2 = checkAddNewRow;
                                }

                            }

                            if (getDataEmp.Rows[i]["Opt_Code"].ToString() == dtOperation.Rows[j]["Opt_Code"].ToString())

                            {
                                dt.Rows[dt.Rows.Count - 1][j + 1] = getDataEmp.Rows[i]["Eff_Emp"].ToString();
                                if (getDataEmp.Rows[i]["MainOperation"].ToString() == "1")
                                {

                                    indexedList.Add(new IndexedValue
                                    {
                                        RowIndex = gvDisDetail.Rows.Count - 1,  // Row index from DataGridView (or the relevant index for your data)
                                        ColIndex = j + 1,  // Column index from the inner loop
                                        Value = dt.Rows[dt.Rows.Count - 1][j + 1].ToString() // Value from the DataTable (or DataGridView)
                                    });
                                }

                            }

                        }
                        checkAddNewRow_Sub = checkAddNewRow;
                    }
                    gvDisDetail.DataSource = dt;

                    // Set color for indexed positions in DataGridView
                    SetCellColorToSilver();
                }
            }
        }

        private void SetCellColorToSilver()
        {
            // Iterate through indexedList and set the color to Silver
            foreach (var indexedValue in indexedList)
            {
                int rowIndex = indexedValue.RowIndex;
                int colIndex = indexedValue.ColIndex;

                // Assuming gvDisDetail is your DataGridView
                if (rowIndex < gvDisDetail.Rows.Count && colIndex < gvDisDetail.Columns.Count)
                {
                    gvDisDetail.Rows[rowIndex].Cells[colIndex].Style.BackColor = System.Drawing.Color.Silver;
                }
            }
        }

        public class IndexedValue
        {
            public int RowIndex { get; set; }
            public int ColIndex { get; set; }
            public string Value { get; set; }
        }
        private void btDelete_Click(object sender, EventArgs e)
        {
            if (cbbLine.SelectedIndex > -1)
            {
                if (MessageBox.Show("You want to delete data right?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string gmNumber = gvDis.Rows[indexRows_gvDis].Cells["GarmentTypeNumber"].Value.ToString();
                    bool st = ConnectMySQL.MysqlQuery("DELETE FROM `a_emp_multi_skill_tb` WHERE `Line` '" + cbbLine.Text + "' LIKE AND`GarmentTypeNumber`LIKE '" + gmNumber + "'; ");
                    if (st)
                    {
                        MessageBox.Show("OK");
                    }
                    else
                    {
                        MessageBox.Show("Can't Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        //private void gvDis_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.ColumnIndex == gvDis.Columns["ST_Appear"].Index)
        //    {
        //        gvDis.CellValueChanged -= gvDis_CellValueChanged;
        //        foreach (DataGridViewRow row in gvDis.Rows)
        //        {
        //            if (row.Index != e.RowIndex)
        //            {
        //                row.Cells["ST_Appear"].Value = false;
        //            }
        //        }
        //        gvDis.CellValueChanged += gvDis_CellValueChanged;
        //        string gmNumber = gvDis.Rows[e.RowIndex].Cells[0].Value.ToString();
        //        ConnectMySQL.MysqlQuery("UPDATE `a_emp_multi_skill_tb` SET `ST_Appear`='0' WHERE `Line` LIKE '" + cbbLine.Text + "' ; UPDATE `a_emp_multi_skill_tb` SET `ST_Appear`='1' WHERE `Line` LIKE '" + cbbLine.Text + "' AND `GarmentTypeNumber` LIKE '" + gmNumber + "';");
        //        LoadLine();
        //    }
        //}

        //private void gvDis_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        //{
        //    if (gvDis.CurrentCell is DataGridViewCheckBoxCell)
        //    {
        //        gvDis.CommitEdit(DataGridViewDataErrorContexts.Commit);
        //    }
        //}

        private void btShowOn_Click(object sender, EventArgs e)
        {
            if (indexRows_gvDis > -1)
            {
                foreach (DataGridViewRow row in gvDis.Rows)
                {
                    if (row.Index != indexRows_gvDis)
                    {
                        row.Cells["ST_Appear"].Value = false;
                    }
                }
                gvDis.Rows[indexRows_gvDis].Cells["ST_Appear"].Value = true;
                string gmNumber = gvDis.Rows[indexRows_gvDis].Cells[0].Value.ToString();
                ConnectMySQL.MysqlQuery("UPDATE `a_emp_multi_skill_tb` SET `ST_Appear`='0' WHERE `Line` LIKE '" + cbbLine.Text + "' ; UPDATE `a_emp_multi_skill_tb` SET `ST_Appear`='1' WHERE `Line` LIKE '" + cbbLine.Text + "' AND `GarmentTypeNumber` LIKE '" + gmNumber + "';");
                LoadLine();
            }
        }

        private void gvDis_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                indexRows_gvDis = e.RowIndex;
                // MessageBox.Show(gvDis.Rows[e.RowIndex].Cells["ST_Appear"].Value.ToString());

            }
        }
        int IndexRowgv_DisDetail = -1;
        private void gvDisDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                IndexRowgv_DisDetail = e.RowIndex;
            }
        }

        private void btDeleteEmp_Click(object sender, EventArgs e)
        {
            if (IndexRowgv_DisDetail > -1)
            {
                if (MessageBox.Show("Are you sure you want to delete data?", "Information", MessageBoxButtons.YesNo) == DialogResult.OK)
                {
                    gvDisDetail.Rows.RemoveAt(IndexRowgv_DisDetail);
                    MessageBox.Show("OK");
                }
            }
        }

        private void btClearAll_Click(object sender, EventArgs e)
        {
            ConnectMySQL.MysqlQuery("UPDATE `a_emp_multi_skill_tb` SET `ST_Appear`='0' WHERE `Line` LIKE '" + cbbLine.Text + "' ; ");
            LoadLine();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
