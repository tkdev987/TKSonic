using PTS_For_Cut.Myclass;
using System.Data;
using static PTS_For_Cut._6Sewing.EmpSkillofEachgarment;

namespace PTS_For_Cut._6Sewing
{
    public partial class MutiSkill : Form
    {
        public static MutiSkill ins;
        public MutiSkill()
        {
            InitializeComponent();
            ins = this;
        }

        private void btUpdateSkill_Click(object sender, EventArgs e)
        {

        }
        public string PathImg = "";
        public string empImgPath = "";
        private void MutiSkill_Load(object sender, EventArgs e)
        {
            gvDisLine.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gvDis.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            if (Properties.Settings.Default.PathSkillImg != null)
            {
                tbPathImg.Text = Properties.Settings.Default.PathSkillImg;
                PathImg = tbPathImg.Text;
            }
            if (Properties.Settings.Default.empPicPath != null)
            {
                tbEmpPicPath.Text = Properties.Settings.Default.empPicPath;
                empImgPath = tbEmpPicPath.Text;
            }



        }
        DataTable getRowData = new DataTable();
        List<string> empIDList = new List<string>();
        private void LoadDataAlltoShow()
        {
            if (getRowData.Rows.Count > 0)
            {
                string SubLine = "";
                string SubGarmentType = "";
                string SubEmp = "";
                string SubMain = "";
                DataTable dtRenewData = new DataTable();
                dtRenewData.Columns.Add("Line");
                dtRenewData.Columns.Add("GarmentTypeNumber");
                dtRenewData.Columns.Add("MultiSkill");
                int CountEmp = 0;
                int MultiSkillCount = 0;
                empIDList = new List<string>();
                for (int i = 0; i < getRowData.Rows.Count; i++)
                {
                    string Line = getRowData.Rows[i]["Line"].ToString();
                    string GarmentType = getRowData.Rows[i]["GarmentTypeNumber"].ToString();
                    string Emp = getRowData.Rows[i]["EmpID"].ToString();
                    string Main = getRowData.Rows[i]["MainOperation"].ToString();


                    if (i > 0 && SubEmp != Emp) CountEmp++;
                    if (Main == "1")
                    {
                        // MessageBox.Show(Main);

                        int Value_beforeMain = 0;
                        if (i > 0)
                        {
                            if (getRowData.Rows[i - 1]["Eff_Emp"].ToString() != "" && Emp == getRowData.Rows[i - 1]["EmpID"].ToString())
                                Value_beforeMain = int.Parse(getRowData.Rows[i - 1]["Eff_Emp"].ToString());
                        }
                        int Value_Main = 0;
                        if (getRowData.Rows[i]["Eff_Emp"].ToString() != "")
                        {
                            Value_Main = int.Parse(getRowData.Rows[i]["Eff_Emp"].ToString());
                        }
                        int Value_After_Main = 0;
                        if (i < getRowData.Rows.Count)
                        {
                            if (i < getRowData.Rows.Count - 1)
                            {


                                if (getRowData.Rows[i + 1]["Eff_Emp"].ToString() != "" && Emp == getRowData.Rows[i + 1]["EmpID"].ToString())
                                    Value_After_Main = int.Parse(getRowData.Rows[i + 1]["Eff_Emp"].ToString());
                            }
                        }
                        //MessageBox.Show(Emp + " || " + Value_beforeMain.ToString() + " || " + Value_Main.ToString() + " || " + Value_After_Main.ToString());
                        if (Value_beforeMain > 74 && Value_Main > 74 && Value_After_Main > 74)
                        {
                            MultiSkillCount++;
                            empIDList.Add(Line + Emp);
                        }
                    }



                    if ((Line != SubLine && i > 0) || (i == getRowData.Rows.Count - 1))
                    {
                        //MessageBox.Show(MultiSkillCount + "||" + CountEmp);
                        double PerMulti = (double)MultiSkillCount / (double)CountEmp * 100;
                        dtRenewData.Rows.Add(SubLine, GarmentType, PerMulti.ToString("##.#"));
                        MultiSkillCount = 0;
                        CountEmp = 0;
                    }

                    SubLine = Line;
                    SubGarmentType = GarmentType;
                    SubEmp = Emp;
                    SubMain = Main;
                }
                gvDisLine.DataSource = dtRenewData;

            }
        }
        private void LoadOnly()
        {
            getRowData = ConnectMySQL.MySQLtoDataTable(
                @"SELECT  a.`EmpID`, a.`Line`, b.OperationName, a.`GarmentTypeNumber`, a.`Eff_Emp`, a.`Seq`,a.Opt_Code , a.`ST_Appear`, a.`MainOperation` 
                                    FROM `a_emp_multi_skill_tb` AS a 
                                    LEFT JOIN `a_operation_garment_type` AS b ON b.Opt_Code=a.Opt_Code 
                                    WHERE a.`ST_Appear` =1 
                                    ORDER BY a.`Line`,a.`GarmentTypeNumber`,a.`Seq`;");
        }

        private void btSavePath_Click(object sender, EventArgs e)
        {
            if (tbPathImg.Text.Length > 0)
            {
                Properties.Settings.Default.PathSkillImg = tbPathImg.Text;
                Properties.Settings.Default.empPicPath = tbEmpPicPath.Text;
                Properties.Settings.Default.Save();
            }
        }

        private void btLoadAll_Click(object sender, EventArgs e)
        {
            LoadOnly();
            LoadDataAlltoShow();
        }
        private void setUpColumnS(string garmentNumber)
        {

            if (gvDis.Columns.Count > 0)
            {
                // Iterate through columns in reverse order to safely remove each column
                for (int i = gvDis.Columns.Count - 1; i >= 0; i--)
                {
                    gvDis.Columns.RemoveAt(i);
                }
            }
            dtClonegvDis = new DataTable();
            DataTable dt = new DataTable();
            dtOperation = ConnectMySQL.MySQLtoDataTable("SELECT `OperationName`,`Opt_Code`  FROM `a_operation_garment_type` WHERE `GarmentTypeCode` LIKE '" + garmentNumber + "' ORDER BY `Seq` ASC;");
            dt.Columns.Add("EmpID");
            //gvDisDetail.Columns.Add("Emp", "Emp");

            for (int i = 0; i < dtOperation.Rows.Count; i++)
            {
                string columnName = dtOperation.Rows[i]["OperationName"].ToString();
                // gvDisDetail.Columns.Add(columnName, columnName);
                dt.Columns.Add(columnName);
            }
            dtClonegvDis = dt;
        }
        int indexRows_gvDis = -1;
        // DataTable getDataEmp = new DataTable();
        DataTable dtOperation = new DataTable();
        List<IndexedValue> indexedList = new List<IndexedValue>();
        DataTable dtClonegvDis = new DataTable();
        //dt = (DataTable) gvDis.DataSource;
        string LineClick = "";
        private void gvDisLine_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                indexRows_gvDis = e.RowIndex;
                string gmNumber = gvDisLine.Rows[e.RowIndex].Cells["GarmentTypeNumber"].Value.ToString();
                LineClick = gvDisLine.Rows[e.RowIndex].Cells["Line"].Value.ToString();

                dtClonegvDis = new DataTable();
                setUpColumnS(gmNumber);

                //getDataEmp = ConnectMySQL.MySQLtoDataTable(@"
                //    SELECT`EmpID`, `Opt_Code`, `Eff_Emp`, `MainOperation` FROM `a_emp_multi_skill_tb` 
                //    WHERE `GarmentTypeNumber` LIKE '" + gmNumber + "' AND `Line`LIKE '" + Line + "' ORDER BY `Seq` ASC;");
                //getRowData
                // dtOperation = ConnectMySQL.MySQLtoDataTable("SELECT `OperationName`,`Opt_Code`  FROM `a_operation_garment_type` WHERE `GarmentTypeCode` LIKE '" + gmNumber + "' ORDER BY `Seq` ASC;");
                if (getRowData.Rows.Count > 0)
                {
                    indexedList = new List<IndexedValue>();
                    string checkAddNewRow = "";
                    string checkAddNewRow_Sub = "";
                    string checkAddNewRow_Sub2 = "";

                    //dt = (DataTable)gvDis.DataSource;
                    for (int i = 0; i < getRowData.Rows.Count; i++)
                    {
                        if (getRowData.Rows[i]["Line"].ToString() == LineClick)
                        {
                            checkAddNewRow = getRowData.Rows[i]["EmpID"].ToString();

                            for (int j = 0; j < dtOperation.Rows.Count; j++)
                            {
                                if (checkAddNewRow_Sub != checkAddNewRow)
                                {
                                    if (checkAddNewRow_Sub2 != checkAddNewRow)
                                    {
                                        dtClonegvDis.Rows.Add(checkAddNewRow);
                                        checkAddNewRow_Sub2 = checkAddNewRow;
                                    }
                                }//Line
                                //MessageBox.Show(getRowData.Rows[i]["Opt_Code"].ToString() + "||" + dtOperation.Rows[j]["Opt_Code"].ToString() + "||" + getRowData.Rows[i]["Line"].ToString());
                                if (getRowData.Rows[i]["Opt_Code"].ToString() == dtOperation.Rows[j]["Opt_Code"].ToString()
                                    && getRowData.Rows[i]["Line"].ToString() == LineClick)

                                {
                                    dtClonegvDis.Rows[dtClonegvDis.Rows.Count - 1][j + 1] = getRowData.Rows[i]["Eff_Emp"].ToString();
                                    if (getRowData.Rows[i]["MainOperation"].ToString() == "1" && getRowData.Rows[i]["Line"].ToString() == LineClick)
                                    {

                                        indexedList.Add(new IndexedValue
                                        {
                                            RowIndex = dtClonegvDis.Rows.Count - 1,  // Row index from DataGridView (or the relevant index for your data)
                                            ColIndex = j + 1,  // Column index from the inner loop
                                            Value = dtClonegvDis.Rows[dtClonegvDis.Rows.Count - 1][j + 1].ToString() // Value from the DataTable (or DataGridView)
                                        });
                                    }

                                }

                            }
                            checkAddNewRow_Sub = checkAddNewRow;
                        }
                    }
                    gvDis.DataSource = dtClonegvDis;

                    // Set color for indexed positions in DataGridView
                    SetCellColorToSilver();
                    lbHeader.Text = LineClick + " : " + gmNumber;
                    if (!string.IsNullOrEmpty(tbPathImg.Text) && gmNumber.Length > 0)
                    {
                        string sPath = Path.Combine(tbPathImg.Text, gmNumber + ".jpg");

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

                }
            }
        }
        private void SetCellColorToSilver()
        {

            ConvertColumnsToImageColumns();
            ReplaceValuesWithImages();

            // Iterate through indexedList and set the color to Silver
            foreach (var indexedValue in indexedList)
            {
                int rowIndex = indexedValue.RowIndex;
                int colIndex = indexedValue.ColIndex;

                // Assuming gvDisDetail is your DataGridView
                if (rowIndex < gvDis.Rows.Count && colIndex < gvDis.Columns.Count)
                {
                    gvDis.Rows[rowIndex].Cells[colIndex].Style.BackColor = System.Drawing.Color.Silver;

                }
            }
            CompareEmpIDWithList(gvDis, empIDList);
        }

        private void CompareEmpIDWithList(DataGridView gvDis, List<string> empIDList)
        {
            foreach (DataGridViewRow row in gvDis.Rows)
            {
                if (row.Cells["EmpID"]?.Value != null) // Ensure the cell value is not null
                {
                    string empID = row.Cells["EmpID"].Value.ToString();

                    // Check if the EmpID exists in the list
                    if (empIDList.Contains(LineClick + empID))
                    {
                        // Highlight only the EmpID cell
                        row.Cells["EmpID"].Style.BackColor = Color.LightGreen;
                        Console.WriteLine($"EmpID {empID} found in the list.");
                    }
                    else
                    {
                        // Highlight only the EmpID cell
                        // row.Cells["EmpID"].Style.BackColor = Color.LightCoral;
                        Console.WriteLine($"EmpID {empID} not found in the list.");
                    }
                }
            }
        }
        private void ConvertColumnsToImageColumns()
        {
            for (int i = 1; i < gvDis.Columns.Count; i++) // Start from index 1
            {
                string columnName = gvDis.Columns[i].Name; // Save column name
                gvDis.Columns.RemoveAt(i); // Remove the column

                DataGridViewImageColumn imgColumn = new DataGridViewImageColumn
                {
                    Name = columnName,
                    HeaderText = columnName,
                    ImageLayout = DataGridViewImageCellLayout.Zoom, // Optional: Adjust image layout
                };

                gvDis.Columns.Insert(i, imgColumn); // Insert the image column
            }
        }
        private void ReplaceValuesWithImages()
        {
            for (int i = 0; i < dtClonegvDis.Rows.Count; i++)
            {
                for (int j = 1; j < dtClonegvDis.Columns.Count; j++) // Start from index 1
                {
                    // DataGridViewCell cell = row.Cells[col];

                    var value_dt = dtClonegvDis.Rows[i][j];
                    var value_gv = gvDis.Rows[i].Cells[j];

                    if (value_dt == null || string.IsNullOrWhiteSpace(value_dt.ToString()))
                    {
                        value_gv.Value = img0.Image; // Empty image
                        //cell.Value = img100.Image;
                    }
                    else if (int.TryParse(value_dt.ToString(), out int value))
                    {
                        if (value >= 0 && value <= 24)
                        {
                            value_gv.Value = img0.Image; // Empty image
                        }
                        else if (value >= 25 && value <= 49)
                        {
                            value_gv.Value = img25.Image;
                        }
                        else if (value >= 50 && value <= 74)
                        {
                            value_gv.Value = img50.Image;
                        }
                        else if (value >= 75 && value <= 99)
                        {
                            value_gv.Value = img75.Image;
                        }
                        else if (value == 100)
                        {
                            value_gv.Value = img100.Image;
                        }

                    }
                }
            }

        }
        private void ConvertColumnsToImageColumnsPreservingData()
        {
            for (int i = 1; i < gvDis.Columns.Count; i++) // Start from index 1
            {
                string columnName = gvDis.Columns[i].Name; // Save column name
                string headerText = gvDis.Columns[i].HeaderText; // Save header text

                // Create a new Image Column
                DataGridViewImageColumn imgColumn = new DataGridViewImageColumn
                {
                    Name = columnName,
                    HeaderText = headerText,
                    ImageLayout = DataGridViewImageCellLayout.Zoom, // Optional: Adjust image layout
                };

                // Insert the new column
                gvDis.Columns.Insert(i + 1, imgColumn);

                // Copy data from the original column to the new column
                foreach (DataGridViewRow row in gvDis.Rows)
                {
                    if (row.Cells[i].Value != null)
                    {
                        int.TryParse(row.Cells[i].Value.ToString(), out int value);

                        // Determine the image based on the value
                        if (value >= 25 && value <= 49)
                            row.Cells[i + 1].Value = img25.Image;
                        else if (value >= 50 && value <= 74)
                            row.Cells[i + 1].Value = img50.Image;
                        else if (value >= 75 && value <= 99)
                            row.Cells[i + 1].Value = img75.Image;
                        else if (value == 100)
                            row.Cells[i + 1].Value = img100.Image;
                        else
                            row.Cells[i + 1].Value = null; // Empty image for other values
                    }
                }

                // Remove the original column
                gvDis.Columns.RemoveAt(i);

                // Adjust the index to account for the removed column
                i--;
            }
        }

        private void gvDis_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (e.ColumnIndex == yourImageColumnIndex) // Replace with your image column index
            //{
            //    if (e.Value == null || string.IsNullOrWhiteSpace(e.Value.ToString()))
            //    {
            //        e.Value = null; // Empty image
            //    }
            //    else if (int.TryParse(e.Value.ToString(), out int value))
            //    {
            //        if (value >= 0 && value <= 24) e.Value = null; // Empty image
            //        else if (value >= 25 && value <= 49) e.Value = PictureBox1.Image;
            //        else if (value >= 50 && value <= 74) e.Value = PictureBox2.Image;
            //        else if (value >= 75 && value <= 99) e.Value = PictureBox3.Image;
            //        else if (value == 100) e.Value = PictureBox4.Image;
            //    }
            //}
        }

        private void btUpdateSkill2_Click(object sender, EventArgs e)
        {
            EmpSkillofEachgarment emp = new EmpSkillofEachgarment();
            emp.Show();
        }
    }
}
