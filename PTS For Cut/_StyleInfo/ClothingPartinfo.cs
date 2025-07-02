using PTS_For_Cut.Myclass;
using System.Data;

namespace PTS_For_Cut._StyleInfo
{
    public partial class ClothingPartinfo : Form
    {

        private bool AddRow = false;
        DataTable Doc_dt = new DataTable();
        private int rowIndex = -1;
        private int cbbIndex = -1;
        public ClothingPartinfo()
        {
            InitializeComponent();
        }

        private void ClothingPartinfo_Load(object sender, EventArgs e)
        {
            gvDis.Columns.Clear();
            AddRow = true;
            lbStyle.Text = StyleInfo.ins.OldStyle;
            //this.gvDis.Columns.Add(Login.ins.cc);
            getData();
            // gvDis.Columns["Decoration"].DisplayIndex = 4;
            // gvDis.Columns.foreach (c => c.DisplayIndex = c.Index) ;
            AddRow = false;
        }
        private void getData()
        {
            ConnectMySQL.db = "pts_db";
            ConnectMySQL.DisplayAndSearch("SELECT ROW_NUMBER() OVER(ORDER BY `ClothingPartID`)AS NO , `Part`, `MainPart`, `QTYPart`, `Decoration` " +
                "FROM `a_a0clothing_part` WHERE `Style`LIKE'" + lbStyle.Text + "'", gvDis);
            cbbDecoration.Items.Clear();
            for (int i = 0; i < Login.ins.dtDecoration.Rows.Count; i++)
            {
                cbbDecoration.Items.Add(Login.ins.dtDecoration.Rows[i]["Dec_Eng"].ToString());
            }
            gvDis.Columns["Decoration"].Width = 300;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            bool checkMainPart = false;
            if (gvDis.Rows.Count > 0 && lbStyle.Text != "")
            {
                for (int i = 0; i < gvDis.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(gvDis.Rows[i].Cells["MainPart"].EditedFormattedValue))
                    {
                        checkMainPart = true;
                    }
                }
                if (checkMainPart)
                {
                    if (MessageBox.Show("Are you sure you want to save data?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ConnectMySQL.db = "pts_db";
                        string insertMultiValue = "";
                        bool first = false;

                        for (int i = 0; i < gvDis.Rows.Count - 1; i++)
                        {
                            string style = lbStyle.Text;
                            string part = gvDis.Rows[i].Cells["Part"].Value.ToString();
                            string QTYPart = gvDis.Rows[i].Cells["QTYPart"].Value.ToString();
                            string Deco = gvDis.Rows[i].Cells["Decoration"].Value.ToString();
                            int mainPart = 0;
                            if (Convert.ToBoolean(gvDis.Rows[i].Cells["MainPart"].EditedFormattedValue))
                            {
                                mainPart = 1;
                            }
                            if (part != "" && QTYPart != "")
                            {
                                if (!first)
                                {
                                    insertMultiValue = "('NULL', '" + style + "','" + part + "','" + mainPart + "','" + QTYPart + "','" + Deco + "')";
                                    first = true;
                                }
                                else
                                {
                                    insertMultiValue = insertMultiValue + ",('NULL', '" + style + "','" + part + "','" + mainPart + "','" + QTYPart + "','" + Deco + "')";
                                }
                            }
                        }
                        bool statusDelete = ConnectMySQL.MysqlQuery("DELETE FROM `a_a0clothing_part` WHERE `Style`LIKE '" + lbStyle + "'");
                        ConnectMySQL.MysqlQuery("ALTER TABLE `a_a0clothing_part` auto_increment = 1;");
                        bool statusInsert = ConnectMySQL.MysqlQuery("INSERT INTO `a_a0clothing_part`(`ClothingPartID`, `Style`, `Part`, `MainPart`, `QTYPart`, `Decoration`)" +
                            " VALUES" + insertMultiValue + ";");
                        if (statusDelete && statusInsert)
                        {
                            MessageBox.Show("Successfully");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Can't Save Because You did't Select Main Part.");
                }
            }
        }

        private void gvDis_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (!AddRow)
            {
                //  MessageBox.Show(gvDis.Rows.Count.ToString());
                if (gvDis.Rows.Count > 2)
                {
                    gvDis.Rows[gvDis.Rows.Count - 2].Cells["No"].Value = (gvDis.Rows.Count - 1).ToString();
                }
                else
                {
                    gvDis.Rows[0].Cells["No"].Value = "1";
                }

            }
        }

        private void gvDis_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //if (e.Control is DataGridViewComboBoxEditingControl)
            //{
            //    ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
            //    ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
            //    ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            //}
            //ComboBox combo = e.Control as ComboBox;
            //if (combo != null)
            //{
            //    combo.SelectedIndexChanged -= new EventHandler(ComboBox_SelectedIndexChanged);
            //    combo.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
            //}
        }

        private void gvDis_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (gvDis.Rows.Count > 0)
                {
                    rowIndex = e.RowIndex;
                    cbbIndex = e.RowIndex;

                }
            }
        }

        private void gvDis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                //Loop and uncheck all other CheckBoxes.
                //MessageBox.Show("DD");
                foreach (DataGridViewRow row in gvDis.Rows)
                {
                    if (row.Index == e.RowIndex)
                    {
                        row.Cells["MainPart"].Value = !Convert.ToBoolean(row.Cells["MainPart"].EditedFormattedValue);
                    }
                    else
                    {
                        row.Cells["MainPart"].Value = false;
                    }
                }


            }
        }

        private void cbbDecoration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbIndex > -1)
            {
                string dec = gvDis.Rows[cbbIndex].Cells["Decoration"].Value.ToString();
                if (dec != "")
                {
                    string authors = dec;
                    string[] authorsList = authors.Split("/");
                    bool st = false;
                    for (int i = 0; i < authorsList.Count(); i++)
                    {
                        if (authorsList[i] == cbbDecoration.Text)
                        {
                            st = true;
                        }
                    }
                    if (!st)
                    {
                        gvDis.Rows[cbbIndex].Cells["Decoration"].Value = dec + "/" + cbbDecoration.Text;
                    }
                }
                else
                {
                    gvDis.Rows[cbbIndex].Cells["Decoration"].Value = cbbDecoration.Text;
                }
            }
        }

        private void btClearText_Click(object sender, EventArgs e)
        {
            if (cbbIndex > -1)
            {
                gvDis.Rows[cbbIndex].Cells["Decoration"].Value = "";
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
