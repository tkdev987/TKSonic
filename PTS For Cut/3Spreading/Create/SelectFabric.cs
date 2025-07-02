using PTS_For_Cut.Main;
using PTS_For_Cut.Myclass;
using PTS_For_Cut.Spreading.Create;
using System.ComponentModel;
using System.Data;

namespace PTS_For_Cut._3Spreading.Create
{
    public partial class SelectFabric : Form
    {
        private string so = "";

        private string barcodeSeparate = "";
        private string QTYIg = "";
        private string UnitIg = "";
        private string Length = "";
        private string Unit = "";
        public double PliesSap = 0;
        public double MarkLength = 0;
        public string PliesSep = "";


        private int separateIndex = -1;
        DataTable dtDataUpdate = new DataTable();
        public DataTable dtSelectSeparateFab = new DataTable();
        public static SelectFabric ins;
        private string sp_idsub = "";
        private int ComboColorSelectedIndex = -1;
        public DataTable dtForSeparate = new DataTable();
        public SelectFabric()
        {
            InitializeComponent();
            ins = this;
        }
        private void SelectFabric_Load(object sender, EventArgs e)
        {
            if (HomePage.ins.EditMode == 2)
            {
                tableLayoutPanel2.Enabled = false;
                gvDisStock.Enabled = false;
                gvDisSelected.Enabled = false;
            }
            else
            {
                tableLayoutPanel2.Enabled = true;
                gvDisStock.Enabled = true;
                gvDisSelected.Enabled = true;
            }
            sp_idsub = ImportCutPlan.ins.rDocNo;
            dtForSeparate.Columns.Add(new DataColumn("Barcode", typeof(string)));
            dtForSeparate.Columns.Add(new DataColumn("Igarment QTY", typeof(string)));
            dtForSeparate.Columns.Add(new DataColumn("Igarment Unit", typeof(string)));
            dtForSeparate.Columns.Add(new DataColumn("Length YDS", typeof(string)));
            dtForSeparate.Columns.Add(new DataColumn("Unit", typeof(string)));

            dtDataUpdate.Columns.Add(new DataColumn("Barcode", typeof(string)));
            dtDataUpdate.Columns.Add(new DataColumn("SD_ID", typeof(string)));
            dtDataUpdate.Columns.Add(new DataColumn("Plies", typeof(string)));
            so = ImportCutPlan.ins.rSO;
            lbSD_Color.Text = ImportCutPlan.ins.rColor;
            lbMarkerLengthYard.Text = (double.Parse(ImportCutPlan.ins.rMarkerLengthYard)).ToString("##.####");
            lbPliesSD.Text = ImportCutPlan.ins.rPlies;
            lbFbType.Text = "Fabric Type :: " + ImportCutPlan.ins.rFabricType;
            ConnectMySQL.db = "pts_db";
            cbbColor.Items.Clear();
            ConnectMySQL.ComboboxList("SELECT `A`.`LotNo` FROM `c_warehouse2_so_tb` AS `A` WHERE `So`LIKE '" + so + "';", cbbPO);

            ConnectMySQL.DisplayAndSearch("SELECT `a`.`Barcode`,`a`.`Plies`,`b`.`LotNo`, `c`.`So`, `c`.`Style`,`b`.`DryLot`,`b`.`Color`, `b`.`SizeNet`AS `Width` ," +
                "`a`.`Qty`,`b`.`Unit`,`a`.`YardNet`AS `Total Length YDS`, `a`.`YardNet`AS`Length YDS`,`b`.`StatusResult`AS`Grade`,`b`.`chShad`AS`Shading`,`b`.`LotRemark`,`a`.`SD_ListDoc_No`,`a`.`SeparateStatus` " +
                "FROM `c_wh1_bc_sdactual_tb` AS `a` JOIN `c_warehouse1_bc_tb` AS `b` ON " +
                //"`b`.`StatusResult`!='R' AND " +
                "`a`.`Barcode`= `b`.`Barcode` " +
                "JOIN `c_warehouse2_so_tb` AS `c` ON `c`.`LotNo`=`b`.`LotNo` AND `c`.`So`LIKE '" + so + "' WHERE `a`.`SD_ListDoc_No`= '" + sp_idsub + "';", gvDisSelected);

            gvDisSelected.Columns["Plies"].DisplayIndex = 2;

            //if (gvDisSelected.Rows.Count > 0)
            //{
            //    cbbColor.Text = gvDisSelected.Rows[0].Cells["Color"].Value.ToString();
            //    cbbColor.Enabled = false;
            //}
            //else
            //{
            //    cbbColor.Enabled = true;
            //}
            for (int i = 1; i < gvDisSelected.Columns.Count; i++)
            {
                if (i > 5)
                {
                    gvDisSelected.Columns[i].Width = 60;
                }
            }
            gvDisSelected.Columns["Select2"].Width = 50;
            gvDisSelected.Columns["Select2"].DefaultCellStyle.BackColor = Color.LightGray;
            gvDisSelected.Columns["Barcode"].Width = 80;
            gvDisSelected.Columns["LotNo"].Width = 85;
            gvDisSelected.Columns["So"].Width = 83;
            gvDisSelected.Columns["Style"].Width = 110;
            gvDisSelected.Columns["DryLot"].Width = 80;
            calculatePlies();
            gvDisSelected.Columns["Shading"].ReadOnly = true;
            foreach (DataGridViewColumn column in gvDisSelected.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void gvDisStock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex > -1)
            {

                if (gvDisSelected.Rows.Count < 16)
                {
                    for (int i = 0; i < gvDisSelected.Rows.Count; i++)
                    {
                        if (gvDisStock.Rows[e.RowIndex].Cells["Barcode"].Value.ToString() == gvDisSelected.Rows[i].Cells["Barcode"].Value.ToString())
                        {
                            MessageBox.Show("-- ใน 1 ใบปูบาร์โค๊ดผ้า ห้ามซ้ำกัน --", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            goto jumpOut;
                        }
                    }
                    if (gvDisSelected.Rows.Count > 0)
                    {
                        if (gvDisSelected.Rows[gvDisSelected.Rows.Count - 1].Cells["Grade"].Value.ToString() != "B" && gvDisStock.Rows[e.RowIndex].Cells["Grade"].Value.ToString() == "B")
                        {
                            MessageBox.Show("ผ้าเกรด A และ เกรด B ไม่สามารถรวมกันได้ กรุณาแยกใบปู", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            goto jumpOut;
                        }
                    }


                    if (Convert.ToBoolean(gvDisStock.Rows[e.RowIndex].Cells["Select"].EditedFormattedValue) || !Convert.ToBoolean(gvDisStock.Rows[e.RowIndex].Cells["Select"].EditedFormattedValue))
                    {
                        double fb_Length1 = double.Parse(gvDisStock.Rows[e.RowIndex].Cells["Length YDS"].Value.ToString());
                        double Mark_Length = double.Parse(lbMarkerLengthYard.Text);//`B`.`chTubular`
                        string _fbLength = (fb_Length1 / Mark_Length).ToString("##.##");

                        List<string> AuthorList = new List<string>();
                        for (int i = 1; i < gvDisStock.Columns.Count; i++)
                        {
                            if (i == 2)
                            {
                                AuthorList.Add(_fbLength);
                            }

                            if (i == gvDisStock.ColumnCount - 2)
                            {
                                AuthorList.Add(gvDisStock.Rows[e.RowIndex].Cells[i].Value.ToString());

                            }
                            else if (i == gvDisStock.ColumnCount - 1)
                            {
                                AuthorList.Add("");

                            }
                            else
                            {
                                AuthorList.Add(gvDisStock.Rows[e.RowIndex].Cells[i].Value.ToString());
                            }
                        }
                        DataTable dt = new DataTable();
                        dt = (DataTable)gvDisSelected.DataSource;
                        dt.Rows.Add(AuthorList.ToArray());
                        gvDisSelected.DataSource = dt;
                        if (gvDisStock.Rows[e.RowIndex].Cells["SeparateStatus"].Value.ToString() == "1")
                        {
                            gvDisSelected.Rows[gvDisSelected.Rows.Count - 1].Cells["SeparateStatus"].Value = true;
                        }
                        gvDisStock.Rows.RemoveAt(e.RowIndex);
                        if (gvDisSelected.Rows.Count == 0)
                        {
                            cbbColor.Enabled = true;
                        }
                        else
                        {
                            cbbColor.Enabled = false;
                        }
                        gvDisSelected.Rows[gvDisSelected.Rows.Count - 1].Cells["SD_ListDoc_No"].Value = sp_idsub;
                        // gvDisSelected.Rows[gvDisSelected.Rows.Count - 1].Cells["Plies"].Value = ;
                        calculatePlies();
                    cross:;
                    }
                }
                else
                {
                    MessageBox.Show("Maxinum is 16 Rolls.");
                }
            jumpOut:;
            }
        }
        private void calculatePlies()
        {
            if (gvDisSelected.Rows.Count > 0)
            {
                double pliesSum = 0;
                for (int i = 0; i < gvDisSelected.Rows.Count; i++)
                {
                    if (gvDisSelected.Rows[i].Cells["Plies"].Value.ToString() != "")
                    {
                        pliesSum += double.Parse(gvDisSelected.Rows[i].Cells["Plies"].Value.ToString());
                    }
                }
                lbPliesSelect.Text = pliesSum.ToString();
                double PliesSD = double.Parse(lbPliesSD.Text);
                if (pliesSum > PliesSD)
                {
                    lbOverSD.Text = ((pliesSum - PliesSD) / PliesSD * 100).ToString("##.##");
                    lbOverSD.ForeColor = Color.Red;
                    lbPliesSelect.ForeColor = Color.Red;
                }
                else
                {
                    lbOverSD.Text = "0";
                    lbOverSD.ForeColor = Color.Black;
                    lbPliesSelect.ForeColor = Color.Black;
                }
            }
            else
            {
                lbPliesSelect.Text = "0";
                lbOverSD.Text = "0";
            }
        }
        //private void AddDatatoDtUpdate(DataGridView gvd, int RowIndexAction, bool valueSP_ID, string txt, string fbLength)
        //{

        //    //valueSP_ID = false --sp_id=Null
        //    //valueSP_ID = true --sp_id=sp_idsub

        //    string sp_idValue = "";
        //    string _fbLength = "";
        //    if (valueSP_ID)
        //    {
        //        sp_idValue = sp_idsub;
        //        if (fbLength != "" && lbMarkerLengthYard.Text != "")
        //        {
        //            _fbLength = fbLength;
        //        }
        //    }
        //    //MessageBox.Show(_fbLength);
        //    bool AddST = false;
        //    if (dtDataUpdate.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < dtDataUpdate.Rows.Count; i++)
        //        {
        //            if (dtDataUpdate.Rows[i]["Barcode"].ToString() == txt)
        //            {
        //                dtDataUpdate.Rows[i]["SD_ID"] = sp_idValue;
        //                dtDataUpdate.Rows[i]["Plies"] = _fbLength;
        //                AddST = true;
        //            }
        //        }
        //    }
        //    if (!AddST)
        //    {
        //        dtDataUpdate.Rows.Add(gvd.Rows[RowIndexAction].Cells["Barcode"].Value.ToString(), sp_idValue, _fbLength);
        //    }
        //}
        private void btOk_Click(object sender, EventArgs e)
        {
            save();
        }
        private void save()
        {

            // ConnectMySQL.dttoDB(dtDataUpdate);

            string insertMultiValue = "";

            bool first = false;
            for (int i = 0; i < gvDisSelected.Rows.Count; i++)
            {

                //`B`.`Barcode`,`B`.`Plies`,`A`.`LotNo`, `A`.`So`, `A`.`Style`,`B`.`DryLot`,`B`.`Color`, `B`.`SizeNet`AS `Width` ,`c`.`Qty`,`B`.`Unit`, " +
                //"`c`.`YardNet`AS `Length`,`B`.`StatusResult`AS`Grade`,`B`.`chShad`AS`Shading`,`B`.`LotRemark` ,`B`.`SD_ListDoc_No`,`c`.`SeparateStatus`" +
                string bar = gvDisSelected.Rows[i].Cells["Barcode"].Value.ToString();
                string qty = gvDisSelected.Rows[i].Cells["Qty"].Value.ToString();
                string Length = gvDisSelected.Rows[i].Cells["Length YDS"].Value.ToString();


                string plies = gvDisSelected.Rows[i].Cells["Plies"].Value.ToString();
                string sepStatus = "0";
                if (Convert.ToBoolean(gvDisSelected.Rows[i].Cells["SeparateStatus"].EditedFormattedValue))
                {
                    sepStatus = "1";
                    ConnectMySQL.MysqlQuery("UPDATE `c_warehouse1_bc_tb` SET `SeparateStatus`='1'  WHERE `Barcode` = '" + bar + "'");
                }

                string DateST = setDate();

                //MessageBox.Show(gvSpreading.Rows[i].Cells[j].Value.GetType().ToString());


                if (!first)
                {
                    insertMultiValue = "('NULL', '" + bar + "','" + DateST + "','" + qty + "','" + Length + "','" + sp_idsub + "','" + plies + "','" + sepStatus + "')";
                    first = true;
                }
                else
                {
                    insertMultiValue = insertMultiValue + ",('NULL', '" + bar + "','" + DateST + "','" + qty + "','" + Length + "','" + sp_idsub + "','" + plies + "','" + sepStatus + "')";
                }


            }
            if (insertMultiValue != "")
            {
                ConnectMySQL.MysqlQuery("DELETE FROM `c_wh1_bc_sdactual_tb` WHERE `SD_ListDoc_No`='" + sp_idsub + "' ");
                ConnectMySQL.MysqlQuery("ALTER TABLE `c_wh1_bc_sdactual_tb` auto_increment = 1;");
                ConnectMySQL.MysqlQuery("INSERT INTO `c_wh1_bc_sdactual_tb`( `BcID`, `Barcode`, `CreateDate`, `Qty`, `YardNet`, `SD_ListDoc_No`, `Plies`,`SeparateStatus`) " +
                                                 "VALUES" + insertMultiValue + ";");
            }
            else
            {
                ConnectMySQL.MysqlQuery("DELETE FROM `c_wh1_bc_sdactual_tb` WHERE `SD_ListDoc_No`='" + sp_idsub + "' ");
            }

            ImportCutPlan.ins.StShading = false;
            for (int i = 0; i < gvDisSelected.Rows.Count; i++)
            {
                if (Convert.ToBoolean(gvDisSelected.Rows[i].Cells["Shading"].EditedFormattedValue))
                {
                    ImportCutPlan.ins.StShading = true;
                    break;
                }
            }
            dtDataUpdate.Rows.Clear();
            DialogResult = DialogResult.OK;

        }

        private string setDate()
        {
            string txtDate = "";
            System.Globalization.CultureInfo _cultureEnInfo = new System.Globalization.CultureInfo("en-US");
            DateTime dateEng = Convert.ToDateTime(DateTime.Now, _cultureEnInfo);
            txtDate = dateEng.ToString("yyyy-MM-dd", _cultureEnInfo);
            return txtDate;
        }
        private void gvDisSelected_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex > -1)
            {
                if (Convert.ToBoolean(gvDisSelected.Rows[e.RowIndex].Cells["Select2"].EditedFormattedValue) || !Convert.ToBoolean(gvDisSelected.Rows[e.RowIndex].Cells["Select2"].EditedFormattedValue))
                {
                    List<string> AuthorList = new List<string>();
                    for (int i = 1; i < gvDisSelected.Columns.Count; i++)//`B`.SeparateStatus
                    {
                        if (gvDisSelected.Columns[i].HeaderText == "Plies" || gvDisSelected.Columns[i].HeaderText == "SD_ListDoc_No" || gvDisSelected.Columns[i].HeaderText == "SeparateStatus")
                        {

                        }
                        else
                        {
                            AuthorList.Add(gvDisSelected.Rows[e.RowIndex].Cells[i].Value.ToString());
                        }
                    }
                    //AddDatatoDtUpdate(gvDisSelected, e.RowIndex, false, gvDisSelected.Rows[e.RowIndex].Cells["Barcode"].Value.ToString(), "");

                    DataTable dt = new DataTable();
                    dt = (DataTable)gvDisStock.DataSource;
                    dt.Rows.Add(AuthorList.ToArray());
                    gvDisStock.DataSource = dt;
                    // MessageBox.Show(gvDisSelected.Rows[e.RowIndex].Cells["SeparateStatus"].Value.ToString());
                    if (gvDisSelected.Rows[e.RowIndex].Cells["SeparateStatus"].Value.ToString() == "True")
                    {
                        string query = @"UPDATE `c_warehouse1_bc_tb`
                                        SET `SeparateStatus` = '0'
                                        WHERE `Barcode` LIKE '" + gvDisSelected.Rows[e.RowIndex].Cells["Barcode"].Value.ToString() + @"'
                                        AND (
                                            SELECT COUNT(`Barcode`)
                                            FROM `c_wh1_bc_sdactual_tb`
                                            WHERE `Barcode` LIKE '" + gvDisSelected.Rows[e.RowIndex].Cells["Barcode"].Value.ToString() + @"'
                                        ) = 1;";
                        ConnectMySQL.MysqlQuery(query);

                        //MessageBox.Show("dfdfdfdfdf");


                    }
                    gvDisSelected.Rows.RemoveAt(e.RowIndex);
                    gvDisStock.Sort(gvDisStock.Columns["DryLot"], ListSortDirection.Ascending);
                    if (gvDisSelected.Rows.Count == 0)
                    {
                        cbbColor.Enabled = true;
                    }
                    else
                    {
                        cbbColor.Enabled = false;
                    }

                    calculatePlies();
                }
            }
        }
        private void cbbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbColor.SelectedIndex > -1 && cbbPO.SelectedIndex > -1)
            {
                fabricwithcbb();
                colorOfdrylot();
                SeparateAddUpdateTable();
                foreach (DataGridViewColumn column in gvDisStock.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
        }
        private void colorOfdrylot()
        {
            string checkDryLot = "";
            bool ph = false;
            if (gvDisStock.Rows.Count > 0)
            {
                for (int i = 0; i < gvDisStock.Rows.Count; i++)
                {
                    string drylot = gvDisStock.Rows[i].Cells["DryLot"].Value.ToString();
                    if (checkDryLot != drylot)
                    {
                        if (!ph)
                        {
                            ph = true;
                        }
                        else
                        {
                            ph = false;
                        }
                    }

                    if (ph)
                    {
                        gvDisStock.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                    }
                    else
                    {
                        gvDisStock.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    }


                    checkDryLot = drylot;
                }
            }
        }
        private void fabricwithcbb()
        {
            // ComboColorSelectedIndex = cbbColor.SelectedIndex;
            ConnectMySQL.DisplayAndSearch("SELECT `B`.`Barcode`, `B`.`LotNo`, `A`.`So`, `A`.`Style`, `B`.`DryLot`, `B`.`Color`, `B`.`SizeNet`AS Width , " +
                "IFNULL((`B`.`Qty`-(SELECT SUM(`c`.`Qty`) FROM c_wh1_bc_sdactual_tb AS `c` WHERE`c`.`Barcode`= `B`.`Barcode` GROUP BY `c`.`Barcode`)),`B`.`Qty`)AS Qty ,`B`.`Unit`, " +
                "`B`.`YardNet`AS `Total Length YDS`, " +
                "IFNULL((`B`.`YardNet`-(SELECT SUM(`d`.`YardNet`) FROM c_wh1_bc_sdactual_tb AS `d` WHERE `d`.`Barcode`= `B`.`Barcode` GROUP BY `d`.`Barcode`)),`B`.`YardNet`)AS `Length YDS` , " +
                "`B`.`StatusResult`AS`Grade`, `B`.`chShad`AS Shading ,`B`.`LotRemark`,`B`.`SeparateStatus` FROM c_warehouse2_so_tb AS `A` " +
                "INNER JOIN c_warehouse1_bc_tb AS `B` ON`A`.`LotNo`=`B`.`LotNo`AND `B`.`StatusResult`!='R' AND `B`.`YardNet`!='0.00'AND `B`.`YardNet`!='' AND " +
                "`B`.`Color`='" + cbbColor.Text + "'AND `B`.`LotNo`='" + cbbPO.Text + "' AND `B`.`SD_ListDoc_No`='' AND `FabricType`LIKE '%" + ImportCutPlan.ins.rFabricType + "%' AND `B`.`ReadyUse` = '1' " +
                "WHERE `So`LIKE '" + so + "'" +
                "GROUP BY `B`.`Barcode` " +
                "HAVING `Length YDS` > 0 " +
                "ORDER BY `B`.`DryLot` ASC,`B`.`SizeNet` ASC,`Width` ASC;", gvDisStock);
            if (gvDisStock.ColumnCount > 0)
            {
                bool check = false;
                if (dtSelectSeparateFab.Columns.Count == 0)
                {
                    check = true;
                }
                for (int i = 1; i < gvDisStock.Columns.Count; i++)
                {
                    if (check)
                    {
                        dtSelectSeparateFab.Columns.Add(gvDisStock.Columns[i].HeaderText);
                    }

                    if (i > 0)
                    {
                        if (i > 5)
                        {
                            gvDisStock.Columns[i].Width = 60;
                        }
                    }
                }
                for (int i = 0; i < gvDisStock.Rows.Count; i++)
                {
                    if (gvDisStock.Rows[i].Cells["SeparateStatus"].Value.ToString() == "1")
                    {
                        gvDisStock.Rows[i].Cells["Barcode"].Style.BackColor = Color.Yellow;
                    }
                }
                if (gvDisStock.Columns.Count > 0)
                {
                    gvDisStock.Columns["Select"].Width = 50;
                    gvDisStock.Columns["Select"].DefaultCellStyle.BackColor = Color.LightGray;
                    gvDisStock.Columns["Barcode"].Width = 80;
                    gvDisStock.Columns["LotNo"].Width = 80;
                    gvDisStock.Columns["So"].Width = 80;
                    gvDisStock.Columns["Style"].Width = 110;
                    gvDisStock.Columns["DryLot"].Width = 80;
                    gvDisStock.Columns["Shading"].ReadOnly = true;
                }
            }

        }
        private void gvDisSelected_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            gvDisSelected.Rows[gvDisSelected.Rows.Count - 1].Cells["Select2"].Value = false;
        }
        private void gvDisStock_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            gvDisStock.Rows[gvDisStock.Rows.Count - 1].Cells["Select"].Value = false;
        }
        private void SelectFabric_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dtDataUpdate.Rows.Count > 0)
            {
                if (MessageBox.Show("Want to save the changes?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    save();
                }
            }
        }

        private void btSeparate_Click(object sender, EventArgs e)
        {
            if (barcodeSeparate != "")
            {
                if (QTYIg != "0")
                {
                    dtForSeparate.Rows.Add(barcodeSeparate, QTYIg, UnitIg, Length, Unit);

                    PliesSap = double.Parse(lbPliesSD.Text) - double.Parse(lbPliesSelect.Text);
                    MarkLength = double.Parse(lbMarkerLengthYard.Text);
                    if (PliesSap > 0)
                    {
                        using (SeparateFabric di = new SeparateFabric())
                        {
                            if (di.ShowDialog() == DialogResult.OK)
                            {
                                SeparateAddUpdateTable();
                                calculatePlies();
                                // fabricwithcbb();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Balance of Plies is 0");
                    }
                }
                else
                {
                    MessageBox.Show("Balance of QTY is 0");
                }
            }
            else
            {
                MessageBox.Show("Barcode is Empty");
            }
        }
        private void SeparateAddUpdateTable()
        {
            if (dtSelectSeparateFab.Rows.Count > 0 && gvDisStock.Rows.Count > 0)
            {
                string qtySep = dtSelectSeparateFab.Rows[0]["Qty"].ToString();
                string lengSep = dtSelectSeparateFab.Rows[0]["Length YDS"].ToString();

                for (int i = 0; i < gvDisStock.Rows.Count; i++)
                {
                    if (gvDisStock.Rows[i].Cells["Barcode"].Value.ToString() == dtSelectSeparateFab.Rows[0]["Barcode"].ToString())
                    {
                        gvDisStock.Rows[i].Cells["Qty"].Value = (double.Parse(gvDisStock.Rows[i].Cells["Qty"].Value.ToString()) - double.Parse(qtySep)).ToString();
                        gvDisStock.Rows[i].Cells["Length YDS"].Value = (double.Parse(gvDisStock.Rows[i].Cells["Length YDS"].Value.ToString()) - double.Parse(lengSep)).ToString();
                        for (int k = 1; k < gvDisStock.Columns.Count; k++)
                        {
                            if (k == 8)
                            {
                                // MessageBox.Show(k.ToString() + "||" + gvDisStock.Rows[i].Cells[k].Value.ToString());
                                dtSelectSeparateFab.Rows[0][k - 1] = qtySep;// gvDisStock.Rows[i].Cells[k].Value.ToString();
                            }
                            else if (k == 11)
                            {
                                dtSelectSeparateFab.Rows[0][k - 1] = lengSep;
                            }
                            else
                            {
                                dtSelectSeparateFab.Rows[0][k - 1] = gvDisStock.Rows[i].Cells[k].Value.ToString();
                            }
                        }
                        break;
                    }
                }
                bool checkAddSelectGv = false;
                for (int i = 0; i < gvDisSelected.Rows.Count; i++)
                {
                    if (dtSelectSeparateFab.Rows[0]["Barcode"].ToString() == gvDisSelected.Rows[i].Cells["Barcode"].Value.ToString())
                    {
                        checkAddSelectGv = true;
                    }
                }
                if (!checkAddSelectGv)
                {
                    List<string> AuthorList = new List<string>();
                    for (int i = 0; i < dtSelectSeparateFab.Columns.Count; i++)
                    {
                        if (i == 1)
                        {
                            AuthorList.Add(PliesSep);
                        }
                        AuthorList.Add(dtSelectSeparateFab.Rows[0][i].ToString());
                    }
                    DataTable dt = new DataTable();
                    dt = (DataTable)gvDisSelected.DataSource;
                    dt.Rows.Add(AuthorList.ToArray());
                    gvDisSelected.DataSource = dt;
                    gvDisSelected.Rows[gvDisSelected.Rows.Count - 1].Cells["SD_ListDoc_No"].Value = sp_idsub;
                    gvDisSelected.Rows[gvDisSelected.Rows.Count - 1].Cells["SeparateStatus"].Value = true;
                }
            }
        }
        private void getBarcode()
        {
            string searchText = tbBarcode.Text;

            if (!string.IsNullOrEmpty(searchText))
            {
                if (searchText.Length > 2)
                {
                    gvDisStock.ClearSelection();
                    int indexRow = -1;
                    for (int i = 0; i < gvDisStock.Rows.Count; i++)
                    {
                        if (gvDisStock.Rows[i].Selected)
                        {
                            gvDisStock.Rows[i].Selected = false;

                        }
                        if (gvDisStock.Rows[i].Cells["Barcode"].Value != null && gvDisStock.Rows[i].Cells["Barcode"].Value.ToString().Contains(searchText))
                        {
                            gvDisStock.Rows[i].Selected = true;
                            gvDisStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                            indexRow = i;
                            break;
                        }
                        else
                        {
                            gvDisStock.Rows[i].Selected = false;
                        }

                    }
                    // MessageBox.Show(indexRow.ToString());
                    if (indexRow > -1)
                    {
                        if (gvDisStock.Rows[indexRow].Selected)
                        {
                            barcodeSeparate = gvDisStock.Rows[indexRow].Cells["Barcode"].Value.ToString();

                        }
                    }
                }
            }
        }

        private void tbBarcode_KeyUp(object sender, KeyEventArgs e)
        {

            getBarcode();

        }

        private void btSearch_Click(object sender, EventArgs e)
        {

            getBarcode();

        }

        private void lbSD_Color_Click(object sender, EventArgs e)
        {
            cbbColor.SelectedIndex = ComboColorSelectedIndex;
        }

        private void SelectFabric_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (gvDisSelected.Rows.Count > 0)
            {
                ImportCutPlan.ins.FabricQty = gvDisSelected.Rows.Count.ToString();
            }
            else
            {
                ImportCutPlan.ins.FabricQty = "";
            }
            DialogResult = DialogResult.OK;
        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gvDisStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                barcodeSeparate = gvDisStock.Rows[e.RowIndex].Cells["Barcode"].Value.ToString();
                QTYIg = gvDisStock.Rows[e.RowIndex].Cells["Qty"].Value.ToString();
                //MessageBox.Show(QTYIg);
                UnitIg = gvDisStock.Rows[e.RowIndex].Cells["Unit"].Value.ToString();
                Length = gvDisStock.Rows[e.RowIndex].Cells["Length YDS"].Value.ToString();
                // MessageBox.Show(Length);
                Unit = "YDS";
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btFabricDetail_Click(object sender, EventArgs e)
        {
            FabricDetail fabricDetail = new FabricDetail();
            fabricDetail.Show();
        }

        private void cbbPO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbPO.SelectedIndex > -1)
            {
                cbbColor.Items.Clear();
                ConnectMySQL.ComboboxList("SELECT DISTINCT(`A`.`Color`) AS `Color` FROM `c_warehouse1_bc_tb` AS `A`  WHERE  `A`.`FabricType` LIKE '" + ImportCutPlan.ins.rFabricType + "' AND  `A`.`LotNo` LIKE '" + cbbPO.Text + "';", cbbColor);
            }
        }
    }
}
