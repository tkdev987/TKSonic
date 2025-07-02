using PTS_For_Cut.Myclass;
using System.Data;
using System.Drawing.Drawing2D;


namespace PTS_For_Cut._6Sewing
{
    public partial class Add_Operation : Form
    {
        public Add_Operation()
        {
            InitializeComponent();
        }

        private void toolStripComboBox2_Click(object sender, EventArgs e)
        {

        }
        string path = "";
        private void Add_Operation_Load(object sender, EventArgs e)
        {
            Loadcbb();
            path = MutiSkill.ins.PathImg;
        }
        private void Loadcbb()
        {
            DataTable dt = new DataTable();
            dt = EmpSkillofEachgarment.ins.dtgarmentTypeList;
            cbbGarmentType.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbbGarmentType.Items.Add(dt.Rows[i]["GarmentType"].ToString());
            }
        }
        string garmentType_txt = "";
        private void cbbGarmentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ptb1.Image = null;
            checkSave = false;
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

        private void cbbGarmentTypeNumber_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            LoadData();
            checkAddNewForSave = true;
            if (!string.IsNullOrEmpty(path) && cbbGarmentTypeNumber.SelectedIndex > -1)
            {
                string sPath = Path.Combine(path, cbbGarmentTypeNumber.Text + ".jpg");

                // Check if the file exists
                if (File.Exists(sPath))
                {
                    using (FileStream fs = new FileStream(sPath, FileMode.Open, FileAccess.Read))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            fs.CopyTo(ms);
                            ptb1.Image = System.Drawing.Image.FromStream(ms); // Clone image
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"The file '{sPath}' was not found.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a valid garment type and ensure the path is set.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }
        private void LoadData()
        {
            if (cbbGarmentTypeNumber.SelectedIndex > -1)
            {
                ConnectMySQL.DisplayAndSearch("SELECT `Opt_Code`, `OperationName`, `GarmentTypeCode` FROM `a_operation_garment_type` WHERE `GarmentTypeCode` LIKE '" + cbbGarmentTypeNumber.Text + "'", gvDis);
                gvDis.Columns["OperationName"].Width = 300;
                gvDis.Columns["GarmentTypeCode"].Width = 200;
                indexRow_id = -1;
            }
        }

        bool checkAddNewForSave = false;
        private void btNew_Click(object sender, EventArgs e)
        {

        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (cbbGarmentTypeNumber.SelectedIndex > -1 && cbbGarmentType.SelectedIndex > -1 && tbOperation.Text.Length > 2)
            {
                bool checkduplicate = false;
                for (int i = 0; i < gvDis.Rows.Count; i++)
                {
                    if (tbOperation.Text.Trim() == gvDis.Rows[i].Cells["OperationName"].Value.ToString().Trim())
                    {
                        checkduplicate = true;
                        break;

                    }

                }
                if (checkAddNewForSave)
                {
                    if (!checkduplicate)
                    {

                        // Fetch the max Opt_id from the database
                        string getMaxCode = ConnectMySQL.Subtext("SELECT `Opt_id` FROM `a_operation_garment_type` WHERE 1 ORDER BY `Opt_id` DESC LIMIT 1;");
                        int max_Code = 0;

                        if (!string.IsNullOrEmpty(getMaxCode))
                        {
                            max_Code = int.Parse(getMaxCode);
                        }

                        // Check the last row in the GridView, if available
                        int CodeinGv = 0;
                        if (gvDis.Rows.Count > 0)
                        {
                            CodeinGv = int.Parse(gvDis.Rows[gvDis.Rows.Count - 1].Cells["Opt_Code"].Value.ToString());
                        }

                        if (CodeinGv > max_Code)
                        {
                            max_Code = CodeinGv;
                        }

                        max_Code++; // Increment for the new row

                        // Initialize or retrieve the DataTable
                        DataTable dt;
                        if (gvDis.DataSource == null)
                        {
                            // Create a new DataTable with the required columns
                            dt = new DataTable();
                            dt.Columns.Add("Opt_Code");
                            dt.Columns.Add("OperationName");
                            dt.Columns.Add("GarmentTypeCode");

                            // Set the DataTable as the GridView's DataSource
                            gvDis.DataSource = dt;
                        }
                        else
                        {
                            dt = (DataTable)gvDis.DataSource;
                        }

                        // Add a new row to the DataTable
                        dt.Rows.Add(max_Code.ToString(), tbOperation.Text, cbbGarmentTypeNumber.Text);

                        // Update the GridView's DataSource
                        gvDis.DataSource = dt;

                        // Refresh the GridView
                        gvDis.Refresh();
                        tbOperation.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("Cannot add duplicate values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please click on a new garment number or load the data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Please check data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        int indexRow_id = -1;

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (indexRow_id > -1)
            {
                gvDis.Rows.RemoveAt(indexRow_id);
                //if (MessageBox.Show("You want to delete data?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                //{

                //    bool st = ConnectMySQL.MysqlQuery("DELETE FROM `a_operation_garment_type` WHERE `Opt_id` = '" + indexRow_id + "';");
                //    if (st)
                //    {
                //        MessageBox.Show("OK");
                //        LoadData();

                //    }
                //    else
                //    {
                //        MessageBox.Show("Can't delete data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }

                //}
            }
            else
            {
                MessageBox.Show("Please select row.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void gvDis_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                indexRow_id = e.RowIndex;
                tbOperation.Text = gvDis.Rows[e.RowIndex].Cells["OperationName"].Value.ToString();
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (indexRow_id > -1)
            {
                gvDis.Rows[indexRow_id].Cells["OperationName"].Value = tbOperation.Text;
                //if (MessageBox.Show("You want to delete data?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                //{

                //    bool st = ConnectMySQL.MysqlQuery("UPDATE `a_operation_garment_type` SET `OperationName`='" + tbOperation.Text + "' WHERE `Opt_id` LIKE  '" + indexRow_id + "';");
                //    if (st)
                //    {
                //        MessageBox.Show("OK");
                //        LoadData();

                //    }
                //    else
                //    {
                //        MessageBox.Show("Can't delete data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }

                //}
            }
            else
            {
                MessageBox.Show("Please select row.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        Image img;
        private void btAddPic_Click(object sender, EventArgs e)
        {





        }
        private static System.Drawing.Image ResizeImage(System.Drawing.Image imgToResize, Size size)
        {
            // Get the image current width
            int sourceWidth = imgToResize.Width;
            // Get the image current height
            int sourceHeight = imgToResize.Height;
            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            // Calculate width and height with new desired size
            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);
            nPercent = Math.Min(nPercentW, nPercentH);
            // New Width and Height
            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);
            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((System.Drawing.Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            // Draw image with new width and height
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            return (System.Drawing.Image)b;
        }

        private void btNew1_Click(object sender, EventArgs e)
        {
            if (cbbGarmentType.SelectedIndex > -1 && !checkSave)
            {
                checkSave = true;
                checkAddNewForSave = true;
                gvDis.DataSource = null;
                if (cbbGarmentTypeNumber.Items.Count == 0)
                {
                    cbbGarmentTypeNumber.Items.Clear();
                    cbbGarmentTypeNumber.Items.Add(garmentType_txt + "0001");
                    cbbGarmentTypeNumber.SelectedIndex = cbbGarmentTypeNumber.Items.Count - 1;
                }
                else
                {
                    int xx = int.Parse(cbbGarmentTypeNumber.Items[cbbGarmentTypeNumber.Items.Count - 1].ToString().Substring(3, 4)) + 1;

                    cbbGarmentTypeNumber.Items.Add(garmentType_txt + xx.ToString("####0000"));
                    cbbGarmentTypeNumber.SelectedIndex = cbbGarmentTypeNumber.Items.Count - 1;
                }

            }
            else
            {
                MessageBox.Show("Can't add New.");
            }
        }


        bool stAddnewImg = false;
        private void btImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.jpg; *.png;)|*.jpg; *.png;";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                //tbUpload.Text = opf.SafeFileName;
                img = Image.FromFile(opf.FileName);
                ptb1.Image = img;
                stAddnewImg = true;
            }
        }
        bool checkSave = false;
        private void btSave_Click_1(object sender, EventArgs e)
        {
            if (ptb1.Image != null)
            {

                if (stAddnewImg)
                {
                    try
                    {
                        // Resize the image and save it
                        System.Drawing.Image i = ResizeImage(ptb1.Image, new Size(140, 180));
                        string fullPath = Path.Combine(path, cbbGarmentTypeNumber.Text + ".jpg");
                        i.Save(fullPath);

                        // If no exception, the save operation was successful
                        checkAddNewForSave = false;
                        // MessageBox.Show("Image saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // Handle any errors that occur during the save operation
                        MessageBox.Show($"Error saving image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }



                if (gvDis.Rows.Count > 0)
                {
                    string insertMultiValue = "";

                    bool first = false;

                    if (gvDis.IsCurrentCellDirty)
                    {
                        gvDis.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    }

                    for (int i = 0; i < gvDis.Rows.Count; i++)
                    {
                        //string color = gvSpreading.Rows[i].Cells[0].Value.ToString();// IsNullOrWhiteSpace


                        //MessageBox.Show(gvSpreading.Rows[i].Cells[j].Value.GetType().ToString());


                        string Opt_Code = gvDis.Rows[i].Cells["Opt_Code"].Value.ToString();
                        string OperationName = gvDis.Rows[i].Cells["OperationName"].Value.ToString();
                        string seq = (i + 1).ToString();
                        if (!first)
                        {
                            insertMultiValue = "(NULL, '" + Opt_Code + "','" + OperationName + "','" + cbbGarmentTypeNumber.Text + "','" + seq + "')";
                            first = true;
                        }
                        else
                        {
                            insertMultiValue = insertMultiValue + ",(NULL, '" + Opt_Code + "','" + OperationName + "','" + cbbGarmentTypeNumber.Text + "','" + seq + "')";
                        }


                    }
                    if (insertMultiValue != "")
                    {
                        ConnectMySQL.MysqlQuery("DELETE FROM `a_operation_garment_type` WHERE `GarmentTypeCode`='" + cbbGarmentTypeNumber.Text + "' ");
                        //ConnectMySQL.MysqlQuery("ALTER TABLE `a_a2_spreading_detail_tb` auto_increment = 1;");
                        bool st = ConnectMySQL.MysqlQuery("INSERT INTO `a_operation_garment_type` (`Opt_id`, `Opt_Code`, `OperationName`, `GarmentTypeCode`, `Seq`)" +
                                                         "VALUES" + insertMultiValue + ";");
                        if (st)
                        {
                            MessageBox.Show("OK");
                            checkSave = false;
                        }
                        else { MessageBox.Show("Can't save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
                else
                {
                    MessageBox.Show("Please Add Operations", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please Add Image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //goto jumpOut;
            }

        }

        private void btUp_Click(object sender, EventArgs e)
        {
            if (indexRow_id > -1)
            {
                DataTable dt = new DataTable();
                dt = (DataTable)gvDis.DataSource;
                object[] arr0 = dt.Rows[indexRow_id - 1].ItemArray;
                object[] arr1 = dt.Rows[indexRow_id].ItemArray;
                dt.Rows[indexRow_id - 1].ItemArray = arr1;
                dt.Rows[indexRow_id].ItemArray = arr0;
                indexRow_id--;
            }
        }

        private void btDown_Click(object sender, EventArgs e)
        {
            if (indexRow_id > -1)
            {
                DataTable dt = new DataTable();
                dt = (DataTable)gvDis.DataSource;
                object[] arr0 = dt.Rows[indexRow_id + 1].ItemArray;
                object[] arr1 = dt.Rows[indexRow_id].ItemArray;
                dt.Rows[indexRow_id + 1].ItemArray = arr1;
                dt.Rows[indexRow_id].ItemArray = arr0;
                indexRow_id++;
            }
        }

        private void cbbGarmentType_Click(object sender, EventArgs e)
        {

        }

        private void btDeleteGarmentNumber_Click(object sender, EventArgs e)
        {
            if (cbbGarmentTypeNumber.SelectedIndex > -1)
            {
                if (MessageBox.Show("You want to delete garment type number?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bool st = ConnectMySQL.MysqlQuery("DELETE FROM `a_operation_garment_type` WHERE `GarmentTypeCode` ='" + cbbGarmentTypeNumber.Text + "'");
                }
            }
            else
            {
                MessageBox.Show("Please Select garment type number");
            }
        }
    }
}
