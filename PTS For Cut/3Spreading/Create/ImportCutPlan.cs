using ExcelDataReader;
using Production_Tracking_systems.myClass;
using PTS_For_Cut._3Spreading.Create;
using PTS_For_Cut.Main;
using PTS_For_Cut.myClass;
using PTS_For_Cut.Myclass;
using System.Data;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;

namespace PTS_For_Cut.Spreading.Create
{
    public partial class ImportCutPlan : Form
    {
        public string FabricQty { set; get; }
        public string rDocNo { set; get; }
        public string rSO { set; get; }//Program /
        public string rFabricType { set; get; }//Program /
        public string rStyle { set; get; } //Program /
        public string rMarkID { set; get; } //DB 
        public string rPlies { set; get; } //DB
        public string rTableNo { set; get; } //Program
        public string rCombo { set; get; }//Program
        public string rItem { set; get; } //select Form
        public string rColor { set; get; } //select Form
        public string rMarkerWidth { set; get; } //select Form
        public string rMarkerLengthCm { set; get; } //select Form
        public string rMarkerLengthYard { set; get; }
        public string rDtp { set; get; } //select Form rAutoCutCode
        public string rCountry { set; get; }
        public string rShading { set; get; }
        public string rAutoCutCode { set; get; }

        private bool stSave = false;
        public bool StShading = false;
        private int RowsIndex = -1;
        private int ColorRowsIndex = -1;
        private int ColumnSizeIndexGvDis = -1;
        private int ColumnsDisForDelete = -1;
        private int ColumnSizeIndexGvSotb = -1;
        public string soC, styleC, lengthMarkC, widthC, PliesNumberC, colorC;
        public DataTable dtMarkRatio = new DataTable();
        private bool textChange = false;
        public static ImportCutPlan ins;
        public DataTable DataFabric;
        DataTableCollection tableCollection;
        public ImportCutPlan()
        {
            InitializeComponent();
            ins = this;
        }

        private void btImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Files|*.xls;*.xlsx;*.xlsm;" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    tbFileName1.Text = openFileDialog.FileName;

                    using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                            });
                            tableCollection = result.Tables;
                            comboBox2.Items.Clear();
                            foreach (DataTable table in tableCollection)
                            {
                                comboBox2.Items.Add(table.TableName);
                            }
                        }
                    }
                    comboBox2.SelectedIndex = 0;
                    DataTable dt = tableCollection[comboBox2.SelectedItem.ToString()];
                    gvExcel.DataSource = dt;
                }
                else
                {
                    goto jump;
                }
            }
            if (gvExcel.Rows[0].Cells[1].Value.ToString() != "")
            {
                bool checkConvert = false;
                string txt = gvExcel.Rows[0].Cells[1].Value.ToString();
                List<int> termsList = new List<int>();

                for (int i = 0; i < txt.Length; i++)
                {
                    // MessageBox.Show(txt[i].ToString());
                    if (txt[i].ToString() == "-")
                    {
                        termsList.Add(i);
                    }
                }
                int[] ai = termsList.ToArray();
                if (ai.Count() > 0)
                {
                    if (ai.Count() == 2)
                    {
                        tbSO.Text = gvExcel.Rows[0].Cells[1].Value.ToString().Substring(0, ai[0]) + "/" + gvExcel.Rows[0].Cells[1].Value.ToString().Substring(ai[0] + 1, ai[1] - 1 - ai[0]);
                        tbFabricType.Text = gvExcel.Rows[0].Cells[1].Value.ToString().Substring(ai[1] + 1, txt.Length - 1 - ai[1]);
                    }
                    else if (ai.Count() == 1)
                    {
                        tbSO.Text = gvExcel.Rows[0].Cells[1].Value.ToString().Substring(0, ai[0]);
                        tbFabricType.Text = gvExcel.Rows[0].Cells[1].Value.ToString().Substring(ai[0] + 1, txt.Length - 1 - ai[0]);
                    }
                }
            }

            ConnectMySQL.db = "pts_db";

            ConvertTable.StructrueTableOnly("SELECT `Color`, `Size`FROM `so_tb` WHERE `So`LIKE'" + tbSO.Text + "';", gvSOtb);
            tbStyle.Text = ConnectMySQL.Subtext("SELECT `Style` FROM `so_tb` WHERE `So`LIKE'" + tbSO.Text + "' ORDER BY `Style` ASC  LIMIT 1;");

            if (gvSOtb.Rows.Count > 0)
            {
                FilterFromExcel();
            }
            else
            {
                //btTranferData2.Visible = false;
                tbSO.Text = "";
                MessageBox.Show(
                         "So Don't have data in So Table",
                         "Data is Wrong",
                         MessageBoxButtons.OK,
                //  MessageBoxIcon.Warning // for Warning
                MessageBoxIcon.Error // for Error 

            );
            }

            foreach (DataGridViewColumn column in gvSOtb.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            clearColumn();
            colorAlert(true);
        jump:;
        }
        bool checkMultiColor = false;
        private void FilterFromExcel()
        {
            if (gvExcel.Rows.Count > 0)
            {
                bool canGet = false;
                bool canGetMarkID = false;
                bool canGetMarkID2 = false;
                bool checkMark = false;
                bool columnAdded = false;
                bool RetioColumnAdded = false;
                bool getRatio = false;
                bool getRatioMark = false;
                bool columnStatus = false;

                DataTable dtGetSizeForSp = new DataTable();
                DataTable dtRatio = new DataTable();
                DataTable dtMarkID = new DataTable();
                dtMarkID.Columns.Add("MarkID", typeof(System.String));
                int markRound = 1;
                int countMartfile = 0;

                for (int i = 0; i < gvExcel.Rows.Count; i++)
                {
                    //MessageBox.Show(i.ToString() + "||" + gvExcel.Rows[i].Cells[0].Value.ToString());
                    if (gvExcel.Rows[i].Cells[0].Value.ToString() == "Spreading Plies")
                    {

                        canGet = true;
                    }//Marker Ratio
                    if (gvExcel.Rows[i].Cells[0].Value.ToString() == "Marker Ratio")
                    {
                        canGetMarkID = true;
                    }//Marker Ratio

                    if (canGetMarkID2 && dtMarkID.Rows.Count > 0 && gvExcel.Rows[i].Cells[0].Value.ToString() == "")
                    {
                        canGetMarkID = false;
                        canGetMarkID2 = false;
                    }
                    if (canGetMarkID2)
                    {
                        int lastBaclSlashPosition = 0;
                        for (int mk = 0; mk < gvExcel.Rows[i].Cells[1].Value.ToString().Length; mk++)
                        {
                            if (gvExcel.Rows[i].Cells[1].Value.ToString().Substring(mk, 1) == lbBackSlash.Text)
                            {
                                lastBaclSlashPosition = mk;
                            }
                        }
                        if (lastBaclSlashPosition > 0)
                        {
                            int startSub = lastBaclSlashPosition + 1;
                            int QtyOfsub = gvExcel.Rows[i].Cells[1].Value.ToString().Length - startSub;
                            dtMarkID.Rows.Add(gvExcel.Rows[i].Cells[1].Value.ToString().Substring(startSub, QtyOfsub));
                        }
                    }
                    if (canGetMarkID && gvExcel.Rows[i].Cells[0].Value.ToString() == "")
                    {
                        canGetMarkID2 = true;
                    }
                    if (gvExcel.Rows[i].Cells[0].Value.ToString().Length > 5)
                    {
                        if (gvExcel.Rows[i].Cells[0].Value.ToString().Length > 10)
                        {
                            string str = gvExcel.Rows[i].Cells[0].Value.ToString();
                            bool getStart = false;
                            string strMarkRound = "";

                            for (int t = 6; t < str.Length; t++)
                            {
                                if (str[t].ToString() == "T")
                                {
                                    break;
                                }
                                if (getStart)
                                {
                                    strMarkRound += str[t].ToString();
                                }
                                if (str.Substring(0, 6) == "Marker" && str[t].ToString() == "-")
                                {
                                    getStart = true;
                                }
                            }
                            if (strMarkRound != "")
                            {
                                markRound = int.Parse(strMarkRound);
                            }
                        }
                        if (canGet && gvExcel.Rows[i].Cells[0].Value.ToString().Substring(0, 6) == "Marker")
                        {
                            checkMark = true;
                        }

                        if (canGet && checkMark && gvExcel.Rows[i].Cells[0].Value.ToString().Substring(0, 6) == "Colors")
                        {

                            List<String> ar = new List<String>();
                            if (!columnAdded) //
                            {
                                for (int k = 0; k < gvExcel.Columns.Count; k++)
                                {
                                    if (gvExcel.Rows[i].Cells[k].Value.ToString() != "")
                                    {
                                        dtGetSizeForSp.Columns.Add(gvExcel.Rows[i].Cells[k].Value.ToString(), typeof(System.String));
                                    }
                                    else
                                    {
                                        dtGetSizeForSp.Columns.Add(gvExcel.Rows[i - 1].Cells[k].Value.ToString(), typeof(System.String));
                                    }

                                }
                                dtGetSizeForSp.Columns.Add("MarkID", typeof(System.String));
                                columnAdded = true;
                            }
                            if (columnAdded)
                            {
                                // MessageBox.Show(markRound.ToString());
                                for (int p = 0; p < markRound; p++)
                                {
                                    for (int k = 0; k < gvExcel.Columns.Count; k++)
                                    {
                                        ar.Add(gvExcel.Rows[i + 1].Cells[k].Value.ToString());
                                    }

                                    ar.Add(dtMarkID.Rows[countMartfile][0].ToString());
                                    checkMark = false;
                                    dtGetSizeForSp.Rows.Add(ar.ToArray());
                                    ar.Clear();
                                }
                                markRound = 1;
                            }
                            countMartfile++;
                        }
                    }
                }
                gvDis.DataSource = dtGetSizeForSp;
                string txtColor = "";
                for (int i = 0; i < gvDis.Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        txtColor = gvDis.Rows[i].Cells[0].Value.ToString();

                    }
                    if (txtColor != gvDis.Rows[i].Cells[0].Value.ToString())
                    {
                        checkMultiColor = true;
                    }
                }
            }
        }
        private void clearColumn()
        {
            bool x1 = false;
            for (int j = 0; j < gvDis.Columns.Count; j++)
            {
                if (gvDis.Columns[j].HeaderText == "Fabric Length,m")//Fabric Length,m
                {
                    x1 = false;
                    goto crossCode;
                }

                if (x1)
                {
                    bool cSt = false;
                    for (int i = 0; i < gvDis.Rows.Count; i++)
                    {
                        if (gvDis.Rows[i].Cells[j].Value.ToString() != "")
                        {
                            cSt = true;
                        }
                    }
                    if (!cSt)
                    {
                        gvDis.Columns.RemoveAt(j);
                    }
                }
                if (gvDis.Columns[j].HeaderText == "Plies number")//Fabric Length,m
                {
                    x1 = true;
                }
            }
        crossCode:;
        }
        private void colorAlert(bool ColorWay)
        {
            if (ColorWay)
            {
                bool colorStatusForGen = false;
                bool SizeStatusForGen = false;
                if (gvDis.Rows.Count > 0 && gvSOtb.Rows.Count > 0)
                {

                    for (int i = 0; i < gvDis.RowCount; i++)
                    {
                        bool changeColorA = false;
                        for (int j = 0; j < gvSOtb.RowCount; j++)
                        {
                            string Dis = gvDis.Rows[i].Cells["Colors"].Value.ToString();
                            string sotb = gvSOtb.Rows[j].Cells["Colors"].Value.ToString();
                            if (Dis == sotb)
                            {
                                changeColorA = true;
                                break;
                            }
                        }
                        if (!changeColorA)
                        {
                            gvDis.Rows[i].Cells[0].Style.ForeColor = Color.White;
                            gvDis.Rows[i].Cells[0].Style.BackColor = Color.Red;
                            colorStatusForGen = true;
                        }
                        else
                        {
                            gvDis.Rows[i].Cells[0].Style.ForeColor = Color.Black;
                            gvDis.Rows[i].Cells[0].Style.BackColor = Color.White;

                        }
                    }


                    bool x1 = false;
                    for (int i = 0; i < gvDis.Columns.Count; i++)
                    {
                        gvDis.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                        // MessageBox.Show(gvDis.Columns[i].HeaderText);

                        if (gvDis.Columns[i].HeaderText == "Fabric Length,m")//Fabric Length,m
                        {
                            x1 = false;
                            goto crossCode;
                        }
                        // MessageBox.Show(x1.ToString());
                        if (x1)
                        {
                            //MessageBox.Show(x1.ToString());
                            bool changeColor = false;
                            for (int j = 0; j < gvSOtb.Columns.Count; j++)
                            {
                                string cDis = gvDis.Columns[i].HeaderText;
                                string csotb = gvSOtb.Columns[j].HeaderText;
                                if (cDis == csotb)
                                {
                                    changeColor = true;
                                }
                            }
                            if (!changeColor)
                            {
                                gvDis.Columns[i].DefaultCellStyle.ForeColor = Color.Black;
                                gvDis.Columns[i].DefaultCellStyle.BackColor = Color.Yellow;
                                SizeStatusForGen = true;
                            }
                            else
                            {
                                gvDis.Columns[i].DefaultCellStyle.ForeColor = Color.Black;
                                gvDis.Columns[i].DefaultCellStyle.BackColor = Color.White;
                            }
                        }

                        if (gvDis.Columns[i].HeaderText == "Plies number")//Fabric Length,m
                        {
                            x1 = true;
                        }
                    }
                crossCode:;
                    if (colorStatusForGen == true || SizeStatusForGen == true)
                    {
                        btTranferData2.Visible = false;
                    }
                    else
                    {
                        btTranferData2.Visible = true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < gvDis.Columns.Count; i++)
                {
                    gvDis.Columns[i].DefaultCellStyle.ForeColor = Color.Black;
                    gvDis.Columns[i].DefaultCellStyle.BackColor = Color.White;
                }
                for (int i = 0; i < gvDis.Rows.Count; i++)
                {
                    gvDis.Rows[i].Cells["Colors"].Style.ForeColor = Color.Black;
                    gvDis.Rows[i].Cells["Colors"].Style.BackColor = Color.White;
                }
            }
        }
        private void btTranferData_Click(object sender, EventArgs e)
        {

        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                checkBeforeSave();
            }
        }

        private void checkBeforeSave()
        {
            if (!chDoNotStyle.Checked)
            {


                ConnectMySQL.db = "pts_db";//`so_tb` WHERE `So`
                string chStyle = ConnectMySQL.Subtext("SELECT DISTINCT(`Style`) FROM `so_tb` WHERE `So`LIKE '" + tbSO.Text + "';");


                if (cbbStatus.SelectedIndex == 2)
                {
                    string CountFabric = ConnectMySQL.Subtext("SELECT COUNT(`Barcode`) FROM `c_wh1_bc_sdactual_tb` WHERE `SD_ListDoc_No`='" + tbDocNo.Text + "';");
                    if (CountFabric != "0")
                    {
                        MessageBox.Show("Can't Save Need to Clear Fabric Before Cancel Document.");
                        goto jumpOut;
                    }
                }

                if (chStyle == tbStyle.Text)
                {

                    if (HomePage.ins.EditMode == 1)
                    {
                        SaveEdit();
                    }
                    else
                    {
                        SaveAdd();
                    }
                    stSave = true;
                    btAddFabric.Visible = true;
                }
                else
                {
                    MessageBox.Show("Can't not Save Please Check Style.");
                }
            }
            else
            {
                if (HomePage.ins.EditMode == 1)
                {
                    SaveEdit();
                }
                else
                {
                    SaveAdd();
                }
                stSave = true;
                btAddFabric.Visible = true;

            }
        jumpOut:;
        }
        private void SaveEdit()
        {
            //if (tableLayoutPanel7.BackColor != Color.IndianRed)
            //{
            if (tbDocNo.Text != "" && tbColor.Text != "" && tbMarkerLengthCm.Text != "" && tbMarkerLengthYard.Text != "" && numPlies.Value != 0
        && tbSO.Text != "" && tbStyle.Text != "" && tbMarkID.Text != "" && tbMarkerWidth.Text != "" && tbFabricType.Text != "")
            {
                bool bSave = false;
                bool aSave = false;
                ConnectMySQL.db = "pts_db";
                string insertMultiValue = "";

                bool first = false;
                for (int i = 0; i < gvSpreading.Rows.Count - 1; i++)
                {
                    for (int j = 1; j < gvSpreading.Columns.Count; j++)
                    {
                        //string color = gvSpreading.Rows[i].Cells[0].Value.ToString();// IsNullOrWhiteSpace
                        string size = gvSpreading.Columns[j].Name;
                        string RatioQty = "";
                        //MessageBox.Show(gvSpreading.Rows[i].Cells[j].Value.GetType().ToString());
                        if (gvSpreading.Rows[i].Cells[j].Value.ToString() != "") //`Style`='" + lbStyle.Text + "'
                        {
                            RatioQty = gvSpreading.Rows[i].Cells[j].Value.ToString();//`Plies`
                            if (!first)
                            {
                                insertMultiValue = "('NULL', '" + tbDocNo.Text + "','" + numPlies.Value.ToString() + "','" + size + "','" + RatioQty + "')";
                                first = true;
                            }
                            else
                            {
                                insertMultiValue = insertMultiValue + ",('NULL', '" + tbDocNo.Text + "','" + numPlies.Value.ToString() + "','" + size + "','" + RatioQty + "')";
                            }
                        }
                    }
                }
                if (insertMultiValue != "")
                {
                    ConnectMySQL.MysqlQuery("DELETE FROM `a_a2_spreading_detail_tb` WHERE `SD_ListDoc_No`='" + tbDocNo.Text + "' ");
                    ConnectMySQL.MysqlQuery("ALTER TABLE `a_a2_spreading_detail_tb` auto_increment = 1;");
                    aSave = ConnectMySQL.MysqlQuery("INSERT INTO `a_a2_spreading_detail_tb`( `No`, `SD_ListDoc_No`,`Plies`, `Size`, `RatioQTY`) " +
                                                     "VALUES" + insertMultiValue + ";");
                }
                string x = "0";
                if (cbShad.Checked)
                {
                    x = "1";
                }
                string DateST = setDate(dtpCreate);
                ConnectMySQL.MysqlQuery("DELETE FROM `a_a1_spreading_list_tb` WHERE `SD_ListDoc_No`='" + tbDocNo.Text + "' ");
                bSave = ConnectMySQL.MysqlQuery("INSERT INTO `a_a1_spreading_list_tb`(`SD_ListDoc_No`, `SO`,`FabricType`, `Style`, `Mark_ID`, `Table_No`, " +
                     "`DateCreate`, `SD_Status`, `Color`, `Marker_Width`, `Marker_LengthCm`, `Marker_LengthYard`, `User`,`chShad`,`FabricPerPCS`,`UnitCons`,`auto_cut_code`) " +
                     "VALUES ('" + tbDocNo.Text + "','" + tbSO.Text + "','" + tbFabricType.Text + "','" + tbStyle.Text + "','" + tbMarkID.Text + "','" + cbbLine.Text + "'," +
                     "'" + DateST + "','" + cbbStatus.SelectedIndex.ToString() + "','" + tbColor.Text + "','" + tbMarkerWidth.Text + "'," +
                     "'" + tbMarkerLengthCm.Text + "','" + tbMarkerLengthYard.Text + "','" + lbUser.Text + "','" + x + "','" + tbFabricPerPCS.Text + "','" + lbFBPerPCS.Text + "','" + tbAutoCutCode.Text + "')");
                if (aSave && bSave)
                {
                    MessageBox.Show("Successfully");
                    Clear(true);

                    Datachange = false;
                    cbbStatus.SelectedIndex = 0;
                    FabricQty = "";
                    updateQTYFabric();
                    if (gvDis.Rows.Count == 0)
                    {
                        DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    MessageBox.Show("Can Not Insert.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Check Data Again");
            }
            //}
            //else
            //{
            //    MessageBox.Show("!!!!!!! Don't have fabric in this spreading !!!!!!!!!");
            //}
        }
        private void SaveAdd()
        {
            //if (tableLayoutPanel7.BackColor != Color.IndianRed)
            //{
            if (tbDocNo.Text != "" && tbColor.Text != "" && tbMarkerLengthCm.Text != "" && tbMarkerLengthYard.Text != "" && numPlies.Value != 0
            && tbSO.Text != "" && tbStyle.Text != "" && tbMarkID.Text != "" && tbMarkerWidth.Text != "" && tbFabricType.Text != "")
            {
                bool bSave = false;
                bool aSave = false;
                ConnectMySQL.db = "pts_db";
                string insertMultiValue = "";

                bool first = false;
                for (int i = 0; i < gvSpreading.Rows.Count - 1; i++)
                {
                    for (int j = 1; j < gvSpreading.Columns.Count; j++)
                    {
                        //string color = gvSpreading.Rows[i].Cells[0].Value.ToString();// IsNullOrWhiteSpace
                        string size = gvSpreading.Columns[j].Name;
                        string RatioQty = "";
                        //MessageBox.Show(gvSpreading.Rows[i].Cells[j].Value.GetType().ToString());
                        if (gvSpreading.Rows[i].Cells[j].Value.ToString() != "") //`Style`='" + lbStyle.Text + "'
                        {
                            RatioQty = gvSpreading.Rows[i].Cells[j].Value.ToString();//`Plies`
                            if (!first)
                            {
                                insertMultiValue = "('NULL', '" + tbDocNo.Text + "','" + numPlies.Value.ToString() + "','" + size + "','" + RatioQty + "')";
                                first = true;
                            }
                            else
                            {
                                insertMultiValue = insertMultiValue + ",('NULL', '" + tbDocNo.Text + "','" + numPlies.Value.ToString() + "','" + size + "','" + RatioQty + "')";
                            }
                        }
                    }
                }
                if (insertMultiValue != "")
                {
                    // ConnectMySQL.MysqlQuery("DELETE FROM `a_a2_spreading_detail_tb` WHERE `SD_ListDoc_No`='" + tbDocNo.Text + "' ");
                    ConnectMySQL.MysqlQuery("ALTER TABLE `a_a2_spreading_detail_tb` auto_increment = 1;");
                    aSave = ConnectMySQL.MysqlQuery("INSERT INTO `a_a2_spreading_detail_tb`( `No`, `SD_ListDoc_No`,`Plies`, `Size`, `RatioQTY`) " +
                                                     "VALUES" + insertMultiValue + ";");
                }
                string x = "0";
                if (cbShad.Checked)
                {
                    x = "1";
                }
                if (aSave)
                {
                    string DateST = setDate(dtpCreate);
                    ConnectMySQL.MysqlQuery("DELETE FROM `a_a1_spreading_list_tb` WHERE `SD_ListDoc_No`='" + tbDocNo.Text + "' ");
                    bSave = ConnectMySQL.MysqlQuery("INSERT INTO `a_a1_spreading_list_tb`(`SD_ListDoc_No`, `SO`,`FabricType`, `Style`, `Mark_ID`, `Table_No`, " +
                         "`DateCreate`, `SD_Status`, `Color`, `Marker_Width`, `Marker_LengthCm`, `Marker_LengthYard`, `User`,`chShad`,`FabricPerPCS`,`UnitCons`,`auto_cut_code`) " +
                         "VALUES ('" + tbDocNo.Text + "','" + tbSO.Text + "','" + tbFabricType.Text + "','" + tbStyle.Text + "','" + tbMarkID.Text + "','" + cbbLine.Text + "'," +
                         "'" + DateST + "','" + cbbStatus.SelectedIndex.ToString() + "','" + tbColor.Text + "','" + tbMarkerWidth.Text + "'," +
                         "'" + tbMarkerLengthCm.Text + "','" + tbMarkerLengthYard.Text + "','" + lbUser.Text + "','" + x + "','" + tbFabricPerPCS.Text + "','" + lbFBPerPCS.Text + "','" + tbAutoCutCode.Text + "')");
                }
                else
                {
                    MessageBox.Show("!!! Can't Save !!!");
                }
                if (aSave && bSave)
                {
                    MessageBox.Show("Successfully");
                    Clear(true);

                    Datachange = false;
                    cbbStatus.SelectedIndex = 0;
                    FabricQty = "";
                    updateQTYFabric();
                    if (gvDis.Rows.Count == 0)
                    {
                        DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    MessageBox.Show("Can Not Insert.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Check Data Again");
            }
            //}
            //else
            //{
            //    MessageBox.Show("!!!!!!! Don't have fabric in this spreading !!!!!!!!!");
            //}
        }
        private void Clear(bool clear)
        {
            tbDocNo.Text = "";
            tbMarkID.Text = "";
            numPlies.Value = 0;
            cbbLine.SelectedIndex = -1;

            tbColor.Text = "";
            tbMarkerWidth.Text = "";
            tbMarkerLengthCm.Text = "";
            tbMarkerLengthYard.Text = "";
            gvSpreading.DataSource = null;
            if (clear)
            {
                if (gvDis.Rows.Count > 0)
                {
                    gvDis.Rows.RemoveAt(RowsIndex);
                }
            }
            for (int i = gvSpreading.Rows.Count - 1; i >= 0; i--)
            {
                gvSpreading.Rows.RemoveAt(i);
            }
            for (int i = gvSpreading.ColumnCount - 1; i >= 0; i--)
            {
                gvSpreading.Columns.RemoveAt(i);
            }
            RowsIndex = -1;
        }
        private string setDate(DateTimePicker dtpVal)
        {
            string txtDate = "";
            System.Globalization.CultureInfo _cultureEnInfo = new System.Globalization.CultureInfo("en-US");
            DateTime dateEng = Convert.ToDateTime(dtpVal.Value, _cultureEnInfo);
            txtDate = dateEng.ToString("yyyy-MM-dd", _cultureEnInfo);
            return txtDate;
        }
        public int LangSelectIndex = -1;
        private void ImportCutPlan_Load(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            dt = Login.ins.Line_dt;
            cbbLine.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["Department"].ToString() == "Cutting")
                {
                    cbbLine.Items.Add(dt.Rows[i]["Line"].ToString());
                }
            }

            cbbStatus.SelectedIndex = 0;
            dtpCreate.Value = DateTime.Now;
            cbShad.Checked = StShading;
            lbUser.Text = Login.ins.userName;
            if (Properties.Settings.Default.workGroup != null)
            {
                tbGroup.Text = Properties.Settings.Default.workGroup;
            }
            if (HomePage.ins.EditMode == 2) //print
            {

                cbbLangSelectIndex.Visible = true;
                lbLangSelectIndex.Visible = true;
                if (Properties.Settings.Default.LangSelectIndex != -1)
                {

                    cbbLangSelectIndex.SelectedIndex = Properties.Settings.Default.LangSelectIndex;
                }
                btAddFabric.Visible = false;
                this.Size = new Size(966, 864);
                tlpMain.ColumnStyles[0].SizeType = SizeType.Percent;
                tlpMain.ColumnStyles[0].Width = 0;
                tlpMain.ColumnStyles[1].SizeType = SizeType.Percent;
                tlpMain.ColumnStyles[1].Width = 100;
                btPrint.Visible = true;
                GetDataFromDB();
                lbFabricQty.Text = ConnectMySQL.Subtext("SELECT COUNT(`SD_ListDoc_No`) FROM `c_warehouse1_bc_tb` WHERE `SD_ListDoc_No`='" + tbDocNo.Text + "'");

                btClear.Visible = false;
                btSave.Visible = false;
                tableLayoutPanel1.Enabled = false;
                tableLayoutPanel5.Enabled = false;
                gvSpreading.Enabled = false;
                cbbLine.Visible = true;
                label9.Visible = true;
                cbbStatus.Visible = false;
            }
            else if (HomePage.ins.EditMode == 1) //edit
            {
                cbbLangSelectIndex.Visible = false;
                lbLangSelectIndex.Visible = false;
                this.Size = new Size(966, 864);
                tlpMain.ColumnStyles[0].SizeType = SizeType.Percent;
                tlpMain.ColumnStyles[0].Width = 0;
                tlpMain.ColumnStyles[1].SizeType = SizeType.Percent;
                tlpMain.ColumnStyles[1].Width = 100;
                GetDataFromDB();
                lbFabricQty.Text = ConnectMySQL.Subtext("SELECT COUNT(`Barcode`) FROM `c_wh1_bc_sdactual_tb` WHERE `SD_ListDoc_No`='" + tbDocNo.Text + "'");
                btClear.Visible = false;
                btPrint.Visible = false;
                btSave.Visible = true;
                tableLayoutPanel1.Enabled = true;
                tableLayoutPanel5.Enabled = true;
                gvSpreading.Enabled = true;
                cbbLine.Visible = false;
                label9.Visible = false;
                cbbStatus.Visible = true;
                if (cbbStatus.SelectedIndex == 2)
                {
                    btAddFabric.Visible = false;
                }
                else
                {
                    btAddFabric.Visible = true;
                }
            }
            else if (HomePage.ins.EditMode == 3) //Copy
            {
                cbbLangSelectIndex.Visible = false;
                lbLangSelectIndex.Visible = false;
                this.Size = new Size(966, 864);
                tlpMain.ColumnStyles[0].SizeType = SizeType.Percent;
                tlpMain.ColumnStyles[0].Width = 0;
                tlpMain.ColumnStyles[1].SizeType = SizeType.Percent;
                tlpMain.ColumnStyles[1].Width = 100;
                GetDataFromDB();
                tableLayoutPanel7.Visible = false;
                //lbFabricQty.Text = ConnectMySQL.Subtext("SELECT COUNT(`Barcode`) FROM `c_wh1_bc_sdactual_tb` WHERE `SD_ListDoc_No`='" + tbDocNo.Text + "'");
                btClear.Visible = false;
                btPrint.Visible = false;
                btSave.Visible = true;
                tableLayoutPanel1.Enabled = true;
                tableLayoutPanel5.Enabled = true;
                gvSpreading.Enabled = true;
                cbbLine.Visible = false;
                label9.Visible = false;
                cbbStatus.Visible = true;
                if (cbbStatus.SelectedIndex == 2)
                {
                    btAddFabric.Visible = false;
                }
                else
                {
                    btAddFabric.Visible = true;
                }
                tbDocNo.Text = "";
                dtpCreate.Value = DateTime.Now;
                string searchFil = "SD" + tbGroup.Text.Substring(0, 1).ToUpper();
                tbDocNo.Text = Calculate.DocNoAutoGen("SELECT `SD_ListDoc_No`  FROM `a_a1_spreading_list_tb` WHERE `SD_ListDoc_No`LIKE '" + searchFil + "%'  ORDER BY `SD_ListDoc_No` DESC LIMIT 1;", "SD" + tbGroup.Text.Substring(0, 1).ToUpper(), dtpCreate);
                HomePage.ins.EditMode = 0;
                tbColor.Enabled = true;

            }

            else if (HomePage.ins.EditMode == 0) //Add
            {
                cbbLangSelectIndex.Visible = false;
                lbLangSelectIndex.Visible = false;
                btAddFabric.Visible = false;
                btSave.Visible = true;
                btPrint.Visible = false;
                btClear.Visible = true;
                this.Size = new Size(1635, 864);
                tlpMain.ColumnStyles[0].SizeType = SizeType.Percent;
                tlpMain.ColumnStyles[0].Width = 50;
                tlpMain.ColumnStyles[1].SizeType = SizeType.Percent;
                tlpMain.ColumnStyles[1].Width = 50;
                tableLayoutPanel1.Enabled = true;
                tableLayoutPanel5.Enabled = true;
                gvSpreading.Enabled = true;
                cbbLine.Visible = false;
                label9.Visible = false;
                cbbStatus.Visible = true;
            }

            //ConnectMySQL.Subtext("");
            if (lbFabricQty.Text == "xxx" || lbFabricQty.Text == "")
            {
                tableLayoutPanel7.BackColor = Color.IndianRed;
            }
            else
            {
                tableLayoutPanel7.BackColor = SystemColors.Control;
            }
        }
        private void gvDis_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                if (gvDis.Rows.Count > 0)
                {
                    RowsIndex = e.RowIndex;
                }

                int IndexStartColumn = 0;
                int IndexEndColumn = 0;
                for (int j = 0; j < gvDis.Columns.Count; j++)
                {
                    if (gvDis.Columns[j].HeaderText == "Fabric Length,m")//Fabric Length,m
                    {
                        IndexEndColumn = j;
                        goto crossCode;
                    }

                    if (gvDis.Columns[j].HeaderText == "Plies number")//Fabric Length,m
                    {
                        IndexStartColumn = j;
                    }
                }
            crossCode:;
                if (e.ColumnIndex > IndexStartColumn && e.ColumnIndex < IndexEndColumn)
                {
                    ColumnSizeIndexGvDis = e.ColumnIndex;

                }
            }
            // MessageBox.Show(e.ColumnIndex.ToString());  ColumnsDisForDelete
            if (e.ColumnIndex > -1)
            {
                ColumnsDisForDelete = e.ColumnIndex;
            }
        }
        private void GetDataFromDB()//
        {
            DataTable dt = new DataTable();
            dt = ConnectMySQL.MySQLtoDataTable("SELECT `a`.`SD_ListDoc_No`, `a`.`SO`,`FabricType`, `a`.`Style`, `a`.`Mark_ID`, `b`.`Plies`, `a`.`Table_No`, " + //	
                "`a`.`DateCreate`, " +
                "`a`.`SD_Status` AS `Status`, " +
                "`a`.`Color`, `a`.`Marker_Width`, `a`.`Marker_LengthCm`, `a`.`Marker_LengthYard`,`a`.`chShad`, `a`.`User` ,`FabricPerPCS`,`UnitCons`,`auto_cut_code`" +
                "FROM `a_a1_spreading_list_tb` AS `a`  " +
                "LEFT JOIN `a_a2_spreading_detail_tb` AS `b` ON `a`.`SD_ListDoc_No`=`b`.`SD_ListDoc_No` " +
                "WHERE `a`.`SD_ListDoc_No`='" + HomePage.ins.DocNo + "' GROUP BY `a`.`SD_ListDoc_No`");

            if (dt.Rows.Count > 0)
            {
                tbDocNo.Text = dt.Rows[0]["SD_ListDoc_No"].ToString();
                tbSO.Text = dt.Rows[0]["SO"].ToString();
                tbFabricType.Text = dt.Rows[0]["FabricType"].ToString();
                tbStyle.Text = dt.Rows[0]["Style"].ToString();
                tbMarkID.Text = dt.Rows[0]["Mark_ID"].ToString();

                //MessageBox.Show(dt.Rows[0]["Plies"].ToString());
                if (dt.Rows[0]["Plies"].ToString() == "")
                {
                    numPlies.Value = 0;
                }
                else
                {
                    numPlies.Value = int.Parse(dt.Rows[0]["Plies"].ToString());
                }
                cbbLine.Text = dt.Rows[0]["Table_No"].ToString();
                cbbStatus.SelectedIndex = int.Parse(dt.Rows[0]["Status"].ToString());
                tbColor.Text = dt.Rows[0]["Color"].ToString();
                tbMarkerWidth.Text = dt.Rows[0]["Marker_Width"].ToString();
                tbMarkerLengthCm.Text = dt.Rows[0]["Marker_LengthCm"].ToString();
                tbMarkerLengthYard.Text = dt.Rows[0]["Marker_LengthYard"].ToString();


                dtpCreate.Text = dt.Rows[0]["DateCreate"].ToString();

                lbUser.Text = dt.Rows[0]["User"].ToString();
                cbShad.Checked = Convert.ToBoolean(dt.Rows[0]["chShad"]);//,`FabricPerPCS`
                tbFabricPerPCS.Text = dt.Rows[0]["FabricPerPCS"].ToString();
                lbFBPerPCS.Text = dt.Rows[0]["UnitCons"].ToString();
                tbAutoCutCode.Text = dt.Rows[0]["auto_cut_code"].ToString();
                ConvertTable.SDconvertDBtoTable(@"SELECT a.`Size`, a.`RatioQTY` 
                                                FROM `a_a2_spreading_detail_tb` a 
                                                LEFT JOIN sizes_tb s ON a.`Size`= s.Size 
                                                WHERE `SD_ListDoc_No`='" + HomePage.ins.DocNo + "' ORDER BY s.SeqNo ASC;", int.Parse(numPlies.Value.ToString()), gvSpreading);


            }

        }
        private void btClear_Click(object sender, EventArgs e)
        {
            Clear(false);
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            if (tbDocNo.Text != "" && tbColor.Text != "" && tbMarkerLengthCm.Text != "" && tbMarkerLengthYard.Text != "" && numPlies.Value != 0
                 && tbSO.Text != "" && tbFabricType.Text != "" && tbStyle.Text != "" && cbbLine.SelectedIndex > -1 && tbMarkID.Text != "" && tbMarkerWidth.Text != "")
            {
                if (cbbLangSelectIndex.SelectedIndex > -1)
                {
                    Properties.Settings.Default.LangSelectIndex = cbbLangSelectIndex.SelectedIndex;
                    Properties.Settings.Default.Save();

                    if (cbShad.Checked)
                    {
                        rShading = "✅";
                    }
                    else
                    {
                        rShading = "❎";
                    }
                    rDocNo = tbDocNo.Text;
                    rSO = tbSO.Text;
                    rFabricType = tbFabricType.Text;
                    rStyle = tbStyle.Text;
                    rMarkID = tbMarkID.Text;
                    rPlies = numPlies.Value.ToString();
                    rTableNo = cbbLine.Text;
                    rColor = tbColor.Text;
                    rMarkerWidth = tbMarkerWidth.Text;
                    rMarkerLengthCm = tbMarkerLengthCm.Text;
                    rMarkerLengthYard = tbMarkerLengthYard.Text;
                    rDtp = setDate(dtpCreate);
                    rAutoCutCode = tbAutoCutCode.Text;
                    dataSet11.Clear();
                    bool stateUpdate = ConnectMySQL.MysqlQuery("UPDATE `a_a1_spreading_list_tb` SET `Table_No`='" + cbbLine.Text + "' WHERE `SD_ListDoc_No`='" + tbDocNo.Text + "'");
                    if (stateUpdate)
                    {
                        for (int i = 0; i < gvSpreading.Rows.Count; i++)
                        {
                            for (int j = 0; j < gvSpreading.Columns.Count; j++)
                            {
                                string ColumnName = gvSpreading.Columns[j].HeaderText;
                                int RowId = gvSpreading.Rows.IndexOf(gvSpreading.Rows[i]);
                                string Value = gvSpreading.Rows[i].Cells[j].Value.ToString();
                                dataSet11.dtRetio.AdddtRetioRow(ColumnName, RowId, Value);
                            }
                        }

                        using (SDPreviweReport pf = new SDPreviweReport(dataSet11.dtRetio))
                        {
                            pf.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("!!! Can't Update Data in Database  !!!");
                    }
                }
                else
                {
                    MessageBox.Show("!!! Please check report language !!!");
                }
            }
            else
            {
                MessageBox.Show("!!! Can't Print Please Select Line !!!");
            }
        }

        private void btAddSize_Click(object sender, EventArgs e)
        {
            manualAdd_new();
        }
        //private void manualAdd()
        //{
        //    bool statusAdd = false;
        //    if (gvSpreading.Rows.Count > 0 && cbbSizeManual.Text != "")
        //    {
        //        for (int i = 0; i < gvSpreading.Columns.Count; i++)
        //        {
        //            if (gvSpreading.Columns[i].HeaderText == cbbSizeManual.Text)
        //            {
        //                statusAdd = true;
        //            }
        //        }
        //        if (!statusAdd)
        //        {
        //            gvSpreading.Columns.Add(cbbSizeManual.Text, cbbSizeManual.Text);
        //            gvSpreading.Columns[cbbSizeManual.Text].Width = 70;
        //            cbbSizeManual.Focus();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Can Not Add Your Size is Duplicate.");
        //        }
        //    }
        //    if (gvSpreading.Rows.Count == 0 && cbbSizeManual.Text != "")
        //    {
        //        string searchFil = "SD" + tbGroup.Text.Substring(0, 1).ToUpper();
        //        tbDocNo.Text = Calculate.DocNoAutoGen("SELECT `SD_ListDoc_No`  FROM `a_a1_spreading_list_tb` WHERE `SD_ListDoc_No`LIKE '" + searchFil + "%'  ORDER BY `SD_ListDoc_No` DESC LIMIT 1;", "SD" + tbGroup.Text.Substring(0, 1).ToUpper(), dtpCreate);
        //        gvSpreading.Columns.Add("Size", "Size");
        //        gvSpreading.Rows.Add("QTY/Plies");
        //        gvSpreading.Rows.Add("Total");
        //        gvSpreading.Columns.Add(cbbSizeManual.Text, cbbSizeManual.Text);
        //        gvSpreading.Columns[cbbSizeManual.Text].Width = 70;
        //        cbbSizeManual.Focus();
        //    }
        //    else if (cbbSizeManual.Text == "")
        //    {
        //        MessageBox.Show("Can Not Add Your Size is Empty.");
        //    }
        //}

        private void btUpdateSize_Click(object sender, EventArgs e)
        {
            if (ColumnSizeIndexGvSotb > -1)
            {
                if (!ManualCreate)
                {
                    if (ColumnSizeIndexGvDis > -1)
                    {
                        if (MessageBox.Show("Are you sure you want to update size?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            gvDis.Columns[ColumnSizeIndexGvDis].HeaderText = gvSOtb.Columns[ColumnSizeIndexGvSotb].HeaderText;
                            gvDis.Columns[ColumnSizeIndexGvDis].Name = gvSOtb.Columns[ColumnSizeIndexGvSotb].HeaderText;
                            ColumnSizeIndexGvDis = -1;
                            ColumnSizeIndexGvSotb = -1;
                            colorAlert(true);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select Column.");
                    }

                }
                else
                {
                    manualAdd_new();
                }

            }
            else
            {
                MessageBox.Show("Please Select Column.");
            }
        }

        private void btUpdateColor_Click(object sender, EventArgs e)
        {
            if (ColorRowsIndex > -1)
            {
                if (!ManualCreate)
                {
                    if (MessageBox.Show("Are you sure you want to Update Color?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (!checkMultiColor)
                        {
                            for (int i = 0; i < gvDis.RowCount; i++)
                            {
                                gvDis.Rows[i].Cells["Colors"].Value = gvSOtb.Rows[ColorRowsIndex].Cells["Colors"].Value;

                            }
                        }
                        else
                        {
                            //ColumnSizeIndexGvDis
                            if (RowsIndex > -1)
                            {
                                gvDis.Rows[RowsIndex].Cells["Colors"].Value = gvSOtb.Rows[ColorRowsIndex].Cells["Colors"].Value;
                            }
                            else
                            {
                                MessageBox.Show("Select Cutplan Color Before Update");
                            }
                        }
                        RowsIndex = -1;
                        ColorRowsIndex = -1;
                        colorAlert(true);
                    }
                }
                else
                {
                    tbColor.Text = gvSOtb.Rows[ColorRowsIndex].Cells["Colors"].Value.ToString();
                }
            }
            else
            {
                MessageBox.Show("Select SO Color Before Update");
            }
        }

        private void gvSOtb_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                if (gvDis.Rows.Count > 0 || ManualCreate)
                {
                    ColorRowsIndex = e.RowIndex;
                }

                if (e.ColumnIndex > 0 && e.ColumnIndex < gvSOtb.Columns.Count - 1)
                {
                    ColumnSizeIndexGvSotb = e.ColumnIndex;
                }
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void btConfirmData_Click(object sender, EventArgs e)
        {
            //btTranferData.Visible = true;
            colorAlert(false);
            //MessageBox.Show("DD");
        }

        private void btDeleteColumn_Click(object sender, EventArgs e)
        {
            if (ColumnsDisForDelete != -1)
            {
                if (MessageBox.Show("Are you sure you want to Delete Column Size?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    gvDis.Columns.RemoveAt(ColumnsDisForDelete);
                    colorAlert(true);
                }
            }
            else
            {
                MessageBox.Show("!!!!Can't Delete Column!!!!");
            }
        }

        private void btAddFabric_Click(object sender, EventArgs e)
        {
            if (HomePage.ins.checkPermiss("sd_AddFabric"))
            {
                TimeSpan currentTime = DateTime.Now.TimeOfDay;

                // Define 08:30 as a TimeSpan
                TimeSpan limitTime = new TimeSpan(8, 30, 0);

                // Check if the current time is not over 08:30
                if (currentTime <= limitTime)
                {
                    ConnectMySQL.MysqlQuery("DELETE FROM `c_wh1_bc_sdactual_tb` WHERE `SD_ListDoc_No`=''");
                    //Console.WriteLine("The time is not over 08:30.");
                }


                if (tbSO.Text != "" && tbDocNo.Text != "" && tbColor.Text != "")
                {
                    rSO = tbSO.Text;
                    rDocNo = tbDocNo.Text;
                    rColor = tbColor.Text;
                    rMarkerLengthYard = tbMarkerLengthYard.Text;
                    rPlies = numPlies.Value.ToString();
                    rFabricType = tbFabricType.Text;
                    using (SelectFabric di = new SelectFabric())
                    {
                        if (di.ShowDialog() == DialogResult.OK)
                        {
                            updateQTYFabric();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("!!!!!Please Ckeck SO.!!!!!!");
                }
            }
            else
            {
                MessageBox.Show("This Account Don't Have Permission For This Function.");
            }
        }
        private void updateQTYFabric()
        {
            lbFabricQty.Text = FabricQty;
            if (lbFabricQty.Text == "xxx" || lbFabricQty.Text == "" || lbFabricQty.Text == "0")
            {
                tableLayoutPanel7.BackColor = Color.IndianRed;
            }
            else
            {
                tableLayoutPanel7.BackColor = SystemColors.Control;
                cbShad.Checked = StShading;
            }
        }
        bool checkWeight = false;
        private void btTranferData2_Click(object sender, EventArgs e)
        {
            if (RowsIndex > -1)
            {
                if (gvSpreading.Rows.Count == 0)
                {
                    if (tbGroup.Text != "")
                    {

                        if (tbGroup.Text != Properties.Settings.Default.workGroup)
                        {
                            Properties.Settings.Default.workGroup = tbGroup.Text;
                            Properties.Settings.Default.Save();
                        }
                        // tbStyle.Text = gvExcel.Rows[2].Cells[1].Value.ToString();
                        ConnectMySQL.db = "pts_db";
                        string searchFil = "SD" + tbGroup.Text.Substring(0, 1).ToUpper();
                        tbDocNo.Text = Calculate.DocNoAutoGen("SELECT `SD_ListDoc_No`  FROM `a_a1_spreading_list_tb` WHERE `SD_ListDoc_No`LIKE '" + searchFil + "%'  ORDER BY `SD_ListDoc_No` DESC LIMIT 1;", "SD" + tbGroup.Text.Substring(0, 1).ToUpper(), dtpCreate);
                        tbMarkerWidth.Text = gvExcel.Rows[19].Cells[3].Value.ToString();
                        bool StartGetData = false;
                        if (tbFabricType.Text != "A")
                        {
                            tbColor.Enabled = true;
                        }
                        else
                        {
                            tbColor.Enabled = false;
                        }
                        gvSpreading.Columns.Add("Size", "Size");
                        gvSpreading.Rows.Add("QTY/Plies");
                        gvSpreading.Rows.Add("Total");
                        double totalQTY = 0;
                        double Fabric_L_W = 0;
                        for (int k = 0; k < gvDis.Columns.Count; k++)
                        {
                            if (gvDis.Columns[k].HeaderText.Length > 12)
                            {
                                if (gvDis.Columns[k].HeaderText.Substring(0, 13) == "Fabric Length")
                                {
                                    StartGetData = false;
                                }
                                //Fabric Length,m
                                if ((gvDis.Columns[k - 1].HeaderText == "Fabric Length,m") && (gvDis.Columns[k].HeaderText == "Fabric Weight,kg"))
                                {
                                    checkWeight = true;
                                }
                            }
                            if (StartGetData)
                            {
                                if (gvDis.Rows[RowsIndex].Cells[k].Value.ToString() != "" && gvDis.Rows[RowsIndex].Cells[k].Value.ToString() != "0")
                                {

                                    string txt = gvDis.Columns[k].HeaderText;
                                    gvSpreading.Columns.Add(txt, txt);
                                    gvSpreading.Rows[0].Cells[txt].Value = (int.Parse(gvDis.Rows[RowsIndex].Cells[txt].Value.ToString())
                                                                                                            /
                                                               int.Parse(gvDis.Rows[RowsIndex].Cells["Plies number"].Value.ToString())).ToString();
                                    gvSpreading.Rows[1].Cells[txt].Value = gvDis.Rows[RowsIndex].Cells[txt].Value;
                                    totalQTY += int.Parse(gvSpreading.Rows[1].Cells[txt].Value.ToString());

                                }
                            }
                            if (gvDis.Columns[k].HeaderText == "Plies number")
                            {
                                StartGetData = true;
                            }
                        }
                        if (checkWeight)
                        {
                            //MessageBox.Show(gvDis.Rows[RowsIndex].Cells["Fabric Weight,kg"].Value.ToString());
                            Fabric_L_W = double.Parse(gvDis.Rows[RowsIndex].Cells["Fabric Weight,kg"].Value.ToString());
                            lbFBPerPCS.Text = "KGS/PCS"; //
                            tbFabricPerPCS.Text = (Fabric_L_W / totalQTY).ToString("0.000");

                        }
                        else
                        {//gvDis.Rows[RowsIndex].Cells["Fabric Weight,kg"].Value.ToString() Fabric Length,m
                            Fabric_L_W = double.Parse(gvDis.Rows[RowsIndex].Cells["Fabric Length,m"].Value.ToString());
                            lbFBPerPCS.Text = "YDS/PCS";
                            tbFabricPerPCS.Text = (Fabric_L_W * 1.0936 / totalQTY).ToString("0.000");
                        }

                        tbColor.Text = gvDis.Rows[RowsIndex].Cells[0].Value.ToString();
                        numPlies.Value = int.Parse(gvDis.Rows[RowsIndex].Cells[1].Value.ToString());
                        tbMarkerLengthCm.Text = double.Parse(gvDis.Rows[RowsIndex].Cells["Marker Length,cm"].Value.ToString()).ToString("0.00");
                        tbMarkerLengthYard.Text = (double.Parse(tbMarkerLengthCm.Text) / 91.44).ToString("0.00");
                        tbMarkerWidth.Text = gvExcel.Rows[18].Cells[3].Value.ToString();
                        tbMarkID.Text = gvDis.Rows[RowsIndex].Cells[gvDis.ColumnCount - 1].Value.ToString();
                        btAddFabric.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Please Set Group Parameter");
                    }
                }
                else
                {
                    MessageBox.Show("Save Data Before Create New Spreading Document.");
                }
            }
            else
            {
                MessageBox.Show("Please Select Data.");
            }
        }

        private void ImportCutPlan_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Datachange)
            {
                if (MessageBox.Show("Want to save the changes?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    checkBeforeSave();

                }
            }
        }

        private void updateStatusSD(string x)
        {
            if (cbbStatus.SelectedIndex > -1 && cbbClick)
            {
                if (MessageBox.Show("Need to Change Status?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ConnectMySQL.MysqlQuery("UPDATE `a_a1_spreading_list_tb` SET `SD_Status`='" + x + "' WHERE `SD_ListDoc_No`='" + tbDocNo.Text + "'");
                }
            }
        }

        bool cbbClick = false;
        private void cbbStatus_Click(object sender, EventArgs e)
        {
            Datachange = true;
        }
        bool Datachange = false;


        private void cbbLine_Click(object sender, EventArgs e)
        {
            Datachange = false;
        }

        private void tbSO_Click(object sender, EventArgs e)
        {
            Datachange = false;
        }

        private void tbStyle_Click(object sender, EventArgs e)
        {
            Datachange = false;
        }

        private void tbMarkID_Click(object sender, EventArgs e)
        {
            Datachange = false;
        }

        private void numPlies_Click(object sender, EventArgs e)
        {
            Datachange = false;
        }

        private void tbColor_Click(object sender, EventArgs e)
        {
            Datachange = false;
        }

        private void gvSpreading_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Datachange = false;
            if (e.ColumnIndex > -1)
            {
                ColumnIndexGvManual = e.ColumnIndex;
            }
        }
        private int ColumnIndexGvManual = -1;
        private void btUpdateSizeManual_Click(object sender, EventArgs e)
        {
            if (ColumnIndexGvManual > -1 && (cbbSizeManual.SelectedIndex > -1))
            {
                if (MessageBox.Show("Are you sure you want to update size?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    gvSpreading.Columns[ColumnIndexGvManual].HeaderText = cbbSizeManual.Text;
                    gvSpreading.Columns[ColumnIndexGvManual].Name = cbbSizeManual.Text;
                    ColumnIndexGvManual = -1;
                }
            }
            else
            {
                MessageBox.Show("!!! Please Select Size and column for update !!!");
            }
        }

        private void cbbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbStatus.SelectedIndex == 2)
            {
                btAddFabric.Visible = false;
            }
            else
            {
                btAddFabric.Visible = true;
            }
        }

        private void cbbSizeManual_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //  manualAdd();
            }
        }

        private void btCopy_Click(object sender, EventArgs e)
        {

        }

        private void btDeColumn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete size?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (ColumnIndexGvManual > -1)
                {
                    gvSpreading.Columns.RemoveAt(ColumnIndexGvManual);
                    ColumnIndexGvManual = -1;
                }
            }
        }

        private void cbbLangSelectIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbLangSelectIndex.SelectedIndex > -1)
            {
                LangSelectIndex = cbbLangSelectIndex.SelectedIndex;

            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
        bool ManualCreate = false;
        private void btLoadStyle_Click(object sender, EventArgs e)
        {
            //tbStyle.Text = ConnectMySQL.Subtext("SELECT `Style` FROM `so_tb` WHERE `So`LIKE'" + tbSO.Text + "' ORDER BY `Style` ASC  LIMIT 1;");
            ConvertTable.StructrueTableOnly("SELECT `Color`, `Size`FROM `so_tb` WHERE `So`LIKE'" + tbSO.Text + "';", gvSOtb);
            tbStyle.Text = ConnectMySQL.Subtext("SELECT `Style` FROM `so_tb` WHERE `So`LIKE'" + tbSO.Text + "' ORDER BY `Style` ASC  LIMIT 1;");
            string searchFil = "SD" + tbGroup.Text.Substring(0, 1).ToUpper();
            tbDocNo.Text = Calculate.DocNoAutoGen("SELECT `SD_ListDoc_No`  FROM `a_a1_spreading_list_tb` WHERE `SD_ListDoc_No`LIKE '" + searchFil + "%'  ORDER BY `SD_ListDoc_No` DESC LIMIT 1;", "SD" + tbGroup.Text.Substring(0, 1).ToUpper(), dtpCreate);

            ManualCreate = true;
        }
        private void manualAdd_new()
        {
            bool statusAdd = false;
            string getSizeFormSotb = gvSOtb.Columns[ColumnSizeIndexGvSotb].HeaderText;
            if (gvSpreading.Rows.Count > 0)
            {
                for (int i = 0; i < gvSpreading.Columns.Count; i++)
                {
                    if (gvSpreading.Columns[i].HeaderText == getSizeFormSotb)
                    {
                        statusAdd = true;
                    }
                }
                if (!statusAdd)
                {
                    gvSpreading.Columns.Add(getSizeFormSotb, getSizeFormSotb);
                    gvSpreading.Columns[getSizeFormSotb].Width = 70;
                    //cbbSizeManual.Focus();
                }
                else
                {
                    MessageBox.Show("Can Not Add Your Size is Duplicate.");
                }
            }
            if (gvSpreading.Rows.Count == 0)
            {

                gvSpreading.Columns.Add("Size", "Size");
                gvSpreading.Rows.Add("QTY/Plies");
                gvSpreading.Rows.Add("Total");
                gvSpreading.Columns.Add(getSizeFormSotb, getSizeFormSotb);
                gvSpreading.Columns[getSizeFormSotb].Width = 70;

            }
        }

        private void tbFabricType_TextChanged(object sender, EventArgs e)
        {
            if (tbFabricType.Text != "A")
            {
                tbColor.Enabled = true;
            }
            else
            {
                tbColor.Enabled = false;
            }
        }
    }
}
