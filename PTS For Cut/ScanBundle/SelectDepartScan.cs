using PTS_For_Cut.Main;
using PTS_For_Cut.Myclass;
using System.Data;

namespace PTS_For_Cut.ScanBundle
{
    public partial class SelectDepartScan : Form
    {
        public static SelectDepartScan ins;
        public SelectDepartScan()
        {
            InitializeComponent();
            //cbbLocation.DropDownStyle = ComboBoxStyle.DropDown;
            ins = this;
        }

        private void SelectDepartScan_Load(object sender, EventArgs e)
        {
            //cbbLocation.DropDownStyle = ComboBoxStyle.DropDown;
            //cbbLocation.AutoCompleteMode = AutoCompleteMode.Suggest;
            //cbbLocation.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbbDec1.Items.Clear();
            for (int i = 0; i < Login.ins.dtDecoration.Rows.Count; i++)
            {
                cbbDec1.Items.Add(Login.ins.dtDecoration.Rows[i]["Dec_Eng"].ToString());
            }

        }

        private void bt_Click(object sender, EventArgs e)
        {
            if (cbbDec1.SelectedIndex > -1 && cbbMode.SelectedIndex > -1 && cbbLocation2.SelectedIndex > -1)
            {

                if (MessageBox.Show("Decoration :" + cbbDec1.Text + "  " + cbbMode.Text + " Decoration Out :" + cbbDecOut.Text, "Your Decoration", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    HomePage.ins.Decoration = cbbDec1.Text;
                    HomePage.ins.DecOut = cbbDecOut.Text;
                    HomePage.ins.DecMode = cbbMode.Text;
                    HomePage.ins.Declocation = cbbLocation2.Text;
                    DialogResult = DialogResult.OK;
                }
            }
            else
            {
                MessageBox.Show("Please Select All.");
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public DataTable dtLocation = HomePage.ins.dtLocation;
        private void cbbMode_SelectedIndexChanged(object sender, EventArgs e)
        {

            //if (Properties.Settings.Default.Factory != "")
            //{
            //    cbbLocation2.Text = Properties.Settings.Default.Factory;
            //}
            if (cbbMode.SelectedIndex == 1)
            {


                label5.Visible = true;
                cbbDecOut.Visible = true;
                cbbDecOut.Items.Clear();
                for (int i = 0; i < Login.ins.dtDecoration.Rows.Count; i++)
                {
                    bool checkAdd = false;
                    //if (cbbDec1.Text == "Cutting" && Login.ins.dtDecoration.Rows[i]["Dec_Eng"].ToString() == "SMK")
                    //{
                    //    checkAdd = true;
                    //}
                    //else if (cbbDec1.Text == "Cutting" && Login.ins.dtDecoration.Rows[i]["Dec_Eng"].ToString() == "Buffer")
                    //{
                    //    checkAdd = true;
                    //}
                    //else if (Login.ins.dtDecoration.Rows[i]["Dec_Eng"].ToString() != "SMK"
                    //    && cbbDec1.Text != Login.ins.dtDecoration.Rows[i]["Dec_Eng"].ToString())
                    //{
                    //    checkAdd = true;
                    //}
                    string valuedt = Login.ins.dtDecoration.Rows[i]["Dec_Eng"].ToString();
                    if (cbbDec1.Text == "Cutting")
                    {
                        if (cbbDec1.Text == valuedt)
                        {
                            checkAdd = false;
                        }
                        else if (valuedt == "Sewing")
                        {
                            checkAdd = false;
                        }
                        else
                        {
                            checkAdd = true;
                        }
                    }
                    else if (cbbDec1.Text == "SMK")
                    {
                        if (cbbDec1.Text == valuedt)
                        {
                            checkAdd = false;
                        }
                        else if (valuedt == "Cutting")
                        {
                            checkAdd = false;
                        }
                        else if (valuedt == "Buffer")
                        {
                            checkAdd = false;
                        }
                        else
                        {
                            checkAdd = true;
                        }

                    }
                    else
                    {
                        if (cbbDec1.Text == valuedt)
                        {
                            checkAdd = false;
                        }
                        else if (valuedt == "Cutting")
                        {
                            checkAdd = false;
                        }
                        else if (valuedt == "SMK")
                        {
                            checkAdd = false;
                        }
                        else if (valuedt == "Sewing")
                        {
                            checkAdd = false;
                        }
                        else
                        {
                            checkAdd = true;
                        }
                    }


                    if (checkAdd)
                    {
                        cbbDecOut.Items.Add(Login.ins.dtDecoration.Rows[i]["Dec_Eng"].ToString());
                    }
                }

            }
            else if (cbbMode.SelectedIndex == 0)
            {
                dtLocation = ConnectMySQL.MySQLtoDataTable("SELECT `Location` FROM `location_tb` WHERE `LocationGroup` LIKE '" + cbbDec1.Text + "';");
                cbbLocation2.Items.Clear();
                for (int i = 0; i < dtLocation.Rows.Count; i++)
                {
                    cbbLocation2.Items.Add(dtLocation.Rows[i]["Location"].ToString());
                }
                label5.Visible = false;
                cbbDecOut.Visible = false;
            }
        }

        private void cbbLocation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbbDec1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbDecOut.SelectedIndex = -1;
            cbbMode.SelectedIndex = -1;
            cbbLocation2.SelectedIndex = -1;
            cbbMode.Enabled = true;
            if (cbbDec1.SelectedIndex > -1)
            {
                if (cbbDec1.Text == "Cutting")
                {
                    cbbMode.SelectedIndex = 1;
                    cbbMode.Enabled = false;
                }
                if (cbbDec1.Text == "Buffer")
                {
                    cbbMode.SelectedIndex = 0;
                    cbbMode.Enabled = false;
                }
            }
        }

        private void cbbLocation2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbbDecOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbDecOut.SelectedIndex > -1)
            {
                dtLocation = ConnectMySQL.MySQLtoDataTable("SELECT `Location` FROM `location_tb` WHERE `LocationGroup` LIKE '" + cbbDecOut.Text + "';");
                cbbLocation2.Items.Clear();
                for (int i = 0; i < dtLocation.Rows.Count; i++)
                {
                    cbbLocation2.Items.Add(dtLocation.Rows[i]["Location"].ToString());
                }
            }
        }
    }
}
