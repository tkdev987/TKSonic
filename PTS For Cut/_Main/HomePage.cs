using PTS_For_Cut._0Datatransfer;
using PTS_For_Cut._3Spreading.Create;
using PTS_For_Cut._3Spreading.DailyOutput;
using PTS_For_Cut._3Spreading.Report;
using PTS_For_Cut._3Spreading.ScanIn;
using PTS_For_Cut._4BundleGenerate;
using PTS_For_Cut._6Sewing;
using PTS_For_Cut._7Packing;
using PTS_For_Cut._9_1Inc;
using PTS_For_Cut._9Report;
using PTS_For_Cut._Main;
using PTS_For_Cut._StyleInfo;
using PTS_For_Cut.Myclass;
using PTS_For_Cut.ScanBundle;
using PTS_For_Cut.Setting;
using PTS_For_Cut.SMK;
using System.Data;
using Panel = System.Windows.Forms.Panel;
using TabControl = System.Windows.Forms.TabControl;

namespace PTS_For_Cut.Main
{
    public partial class HomePage : Form
    {
        public string departAdjustQTY = string.Empty;
        public string QRCODE_Adjust = string.Empty;
        public string BundleNo_Adjust = string.Empty;
        public bool Adjust_Show_Mode = false;
        public int qtyDecrease = 0;
        public int qtyDecreaseRef = 0;
        public string DocNo = "";
        public string sdDataScan = "";
        public string ID_for_CreateBundle = "";
        public int EditMode = -1;
        public static HomePage ins { get; private set; }
        public bool SMKorScanCut = false;
        public DataTable Factory_dt = new DataTable();
        private Dictionary<string, Form> formInstances = new Dictionary<string, Form>();
        public HomePage()
        {
            InitializeComponent();
            ins = this;
        }
        public DataTable dtLocation = new DataTable();
        List<Guna.UI2.WinForms.Guna2Button> gunaButtonList = new List<Guna.UI2.WinForms.Guna2Button>();
        public string Regis_SD_ID = "";
        public bool DeliveryNoteStatus = false;
        private void HomePage_Load(object sender, EventArgs e)
        {
            lbIP.Text = "IP: " + ConnectMySQL.ip;
            lbUser.Text = "EmpID: " + Login.ins.empID + " || " + "User: " + Login.ins.empName;
            //ip_Network
            Factory_dt = ConnectMySQL.MySQLtoDataTable(@"
                            SELECT a.`sc_Code` AS FactoryCode ,b.Doc_code  AS sd_register_no,a.ip_Network
                            FROM `sup_cus_tb` a 
                            LEFT JOIN `doc_regis` b ON a.sc_Code=b.Factory 
                            WHERE `group_Fac` LIKE 'TK' AND b.Function='SpreadingDoc' 
                            ORDER BY `sc_Code` ASC;");

            cbbFactory.Items.Clear();
            for (int i = 0; i < Factory_dt.Rows.Count; i++)
            {
                cbbFactory.Items.Add(Factory_dt.Rows[i]["FactoryCode"].ToString());
            }
            if (Properties.Settings.Default.Factory != "")
            {
                cbbFactory.Text = Properties.Settings.Default.Factory;
                for (int i = 0; i < Factory_dt.Rows.Count; i++)
                {
                    if (cbbFactory.Text == Factory_dt.Rows[i]["FactoryCode"].ToString())
                    {
                        Regis_SD_ID = Factory_dt.Rows[i]["sd_register_no"].ToString();
                    }

                }

            }
            tabform.Controls.Clear();
            IntroProgram introProgram = new IntroProgram();
            themtabpage(introProgram, tabName: "Standby");
            tabform.Font = new Font("Bahnschrift", 14, FontStyle.Regular);
            tabform.DrawMode = TabDrawMode.OwnerDrawFixed;
            AddButtonsToList();
            btShowMenu.Visible = false;

            if (Properties.Settings.Default.DirectReport == 2)
            {
                ToggleMenu(false);
                btSewDailyReport_Click(btSewDailyReport, EventArgs.Empty);
            }

        }
        public void txtQuery(string txtQuery)
        {
            tbQuery.Text = txtQuery;
        }
        private void AddButtonsToList(Control parentControl)
        {
            foreach (Control control in parentControl.Controls)
            {
                if (control is Guna.UI2.WinForms.Guna2Button gunaButton)
                {
                    gunaButtonList.Add(gunaButton);
                }
                else if (control is Button regularButton)
                {
                    MessageBox.Show("Found Button: " + regularButton.Name + " in Panel: " + parentControl.Name);
                }

                // Recursively call the method to check nested controls
                if (control.HasChildren)
                {
                    AddButtonsToList(control);
                }
            }
        }

        private void AddButtonsToList()
        {

            AddButtonsToList(this);
        }
        public string Decoration = "";
        public string DecOut = "";
        public string DecMode = "";
        public string Declocation = "";
        private void changeColorguna2button(string buttonName)
        {
            foreach (Guna.UI2.WinForms.Guna2Button button in gunaButtonList)
            {
                if (button.Name != buttonName)
                {
                    button.FillColor = Color.Empty; //Default color
                }
                else
                {
                    button.FillColor = Color.FromArgb(255, 180, 0); //Active Color
                }

            }
        }
        private void HomePage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit program?", "Information", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        private void HomePage_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConnectMySQL.MysqlQuery("UPDATE `user_tb` SET `login`='0' WHERE `empID`='" + Login.ins.empID + "';");
            Application.Exit();
        }
        private void picSetting_Click(object sender, EventArgs e)
        {
            using (SettingPage di = new SettingPage())
            {
                if (di.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        private void btCut_Click(object sender, EventArgs e)
        {
            showSubMenu(pnCut);
            changeColorguna2button(btCut.Name);

        }
        private void btSMK_Click(object sender, EventArgs e)
        {
            showSubMenu(pnSMK);
            changeColorguna2button(btSMK.Name);
        }
        private void btReport_Click(object sender, EventArgs e)
        {
            showSubMenu(pnReport);
            changeColorguna2button(btReport.Name);
        }
        public void themtabpage(Form frm, string tabName)
        {

            bool checktabpageDuplicate = false;
            for (int i = 0; i < tabform.TabPages.Count; i++)
            {
                if (tabform.TabPages[i].Text.Trim() == tabName.Trim())
                {
                    tabform.SelectedIndex = i;
                    checktabpageDuplicate = true;
                }
            }

            if (!checktabpageDuplicate)
            {

                int index = kiemtratontai(tabform, tabName);
                // MessageBox.Show(index.ToString());
                if (index >= 0)
                {
                    tabform.TabIndex = index;
                }
                else
                {
                    TabPage tabpage = new TabPage { Text = "    " + tabName + "       " };
                    tabpage.BorderStyle = BorderStyle.None;
                    tabform.TabPages.Add(tabpage);
                    frm.TopLevel = false;
                    frm.Parent = tabpage;
                    frm.Dock = DockStyle.Fill;
                    frm.Show();
                    frm.AutoScaleMode = AutoScaleMode.None;
                }
            }
            //else
            //{

            //}


        }
        public int kiemtratontai(TabControl tabForm, string frm)
        {
            for (int i = 0; i < tabForm.TabPages.Count; i++)
            {
                if (tabForm.TabPages[i].Text.Trim() == frm.Trim())
                {
                    return i;
                }
            }
            return -1;
        }
        Rectangle closeX = Rectangle.Empty;
        private void tabform_DrawItem_1(object sender, DrawItemEventArgs e)
        {
            if (tabform.TabPages[e.Index].Text.Trim() != "Standby")
            {
                System.Drawing.Image img = new Bitmap(Properties.Resources.closeTab2);
                Size xSize = new Size(32, 32);
                TabPage tp = tabform.TabPages[e.Index];
                e.DrawBackground();
                using (SolidBrush brush = new SolidBrush(e.ForeColor))
                    e.Graphics.DrawString(tp.Text + "   ", e.Font, brush,
                                          e.Bounds.X + 3, e.Bounds.Y + 11);
                if (e.State == DrawItemState.Selected)
                {
                    closeX = new Rectangle(e.Bounds.Right - xSize.Width,
                                           e.Bounds.Top + 3, xSize.Width, xSize.Height);
                    e.Graphics.DrawImage(img, closeX,
                                         new Rectangle(0, 0, 32, 32), GraphicsUnit.Pixel);
                }
            }
        }
        private void tabform_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (closeX.Contains(e.Location))
                tabform.TabPages.Remove(tabform.SelectedTab);

            if (tabform.TabCount == 0)
            {
                IntroProgram introProgram = new IntroProgram();
                themtabpage(introProgram, tabName: "Standby");
            }
        }
        private void btSpreading_Click(object sender, EventArgs e)
        {
            if (checkPermiss("cut"))
            {
                string tabName = "Spreading";
                Form form;
                if (formInstances.ContainsKey(tabName))
                {
                    form = formInstances[tabName];
                }
                else
                {
                    form = new SpreadingList();
                    formInstances[tabName] = form;
                }
                themtabpage(form, tabName);
                TabPageShowAgain(tabform, tabName);
                changeColorguna2button(btSpreading.Name);
            }
            else
            {
                MessageBox.Show("This Account Don't Have Permission For This Function.");
            }
        }
        public bool checkPermiss(string perMissinFunc)
        {
            DataTable dt = Login.ins.dtPermissList;
            if (dt.Rows.Count > 0)
            {
                bool st = false;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][0].ToString() == perMissinFunc || dt.Rows[i][0].ToString() == "superUser")
                    {
                        st = true;
                    }
                }
                if (st)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private void TabPageShowAgain(TabControl tabForm, string frm)
        {
            int indexStandby = -1;
            for (int i = 0; i < tabForm.TabPages.Count; i++)
            {
                if (tabForm.TabPages[i].Text.Trim() == "Standby")
                {
                    indexStandby = i;
                    break;
                }
            }
            if (indexStandby > -1)
                tabform.TabPages.Remove(tabform.TabPages[indexStandby]);
            for (int i = 0; i < tabForm.TabPages.Count; i++)
            {
                if (tabForm.TabPages[i].Text.Trim() == frm.Trim())
                {
                    tabForm.SelectedIndex = i;
                }
            }
        }
        private void btScanSpreading_Click(object sender, EventArgs e)
        {//
            if (checkPermiss("sd_scan"))
            {
                string tabName = "Scan Spreading Doc.";
                Form form;
                if (formInstances.ContainsKey(tabName))
                {
                    form = formInstances[tabName];
                }
                else
                {
                    form = new SpreadingScan();
                    formInstances[tabName] = form;
                }
                themtabpage(form, tabName);
                TabPageShowAgain(tabform, tabName);
                changeColorguna2button(btScanSpreading.Name);
            }
            else
            {
                MessageBox.Show("This Account Don't Have Permission For This Function.");
            }
        }
        bool sideBar_Expand = true;

        private void btCutReport_Click(object sender, EventArgs e)
        {
            string tabName = "Cutting Report";
            Form form;
            if (formInstances.ContainsKey(tabName))
            {
                form = formInstances[tabName];
            }
            else
            {
                form = new CuttingReport();
                formInstances[tabName] = form;
            }
            themtabpage(form, tabName);
            TabPageShowAgain(tabform, tabName);
            changeColorguna2button(btCutReport.Name);
        }

        private void btGenBundle_Click(object sender, EventArgs e)
        {
            if (checkPermiss("bd_gen"))
            {
                string tabName = "Generate Bundle";
                Form form;
                if (formInstances.ContainsKey(tabName))
                {
                    form = formInstances[tabName];
                }
                else
                {
                    form = new BundleGen();
                    formInstances[tabName] = form;
                }
                themtabpage(form, tabName);
                TabPageShowAgain(tabform, tabName);
                changeColorguna2button(btGenBundle.Name);
            }
            else
            {
                MessageBox.Show("This Account Don't Have Permission For This Function.");
            }
        }

        private void btStyleInfo_Click(object sender, EventArgs e)
        {
            if (checkPermiss("style_info"))
            {
                string tabName = "Style Info";
                Form form;

                if (formInstances.ContainsKey(tabName))
                {
                    form = formInstances[tabName];
                }
                else
                {
                    form = new StyleInfo();
                    formInstances[tabName] = form;
                }
                themtabpage(form, tabName);
                TabPageShowAgain(tabform, tabName);
                changeColorguna2button(btStyleInfo.Name);
            }
            else
            {
                MessageBox.Show("This Account Don't Have Permission For This Function.");
            }
        }
        private void btSewDailyReport_Click(object sender, EventArgs e)
        {
            string tabName = "Sewing Daily Report";
            Form form;
            if (formInstances.ContainsKey(tabName))
            {
                form = formInstances[tabName];
            }
            else
            {
                form = new ReportSewingDaily();
                formInstances[tabName] = form;
            }
            themtabpage(form, tabName);
            TabPageShowAgain(tabform, tabName);
            changeColorguna2button(btSewDailyReport.Name);
        }
        private void btSoReport_Click(object sender, EventArgs e)
        {//ReportCompare

            string tabName = "SO Report";
            Form form;
            if (formInstances.ContainsKey(tabName))
            {
                form = formInstances[tabName];
            }
            else
            {
                form = new SoReportV2();
                formInstances[tabName] = form;
            }
            themtabpage(form, tabName);
            TabPageShowAgain(tabform, tabName);
            changeColorguna2button(btSoReport.Name);
        }

        private void HomePage_Resize(object sender, EventArgs e)
        {
            pnCut.Visible = false;
            pnSMK.Visible = false;
            pnReport.Visible = false;
            pnSew.Visible = false;
        }

        private void HomePage_MinimumSizeChanged(object sender, EventArgs e)
        {

        }

        private void btSetting_Click(object sender, EventArgs e)
        {
            if (checkPermiss("superUser"))
            {
                string tabName = "Setting";
                Form form;
                if (formInstances.ContainsKey(tabName))
                {
                    form = formInstances[tabName];
                }
                else
                {
                    form = new SettingPage();
                    formInstances[tabName] = form;
                }
                themtabpage(form, tabName);
                TabPageShowAgain(tabform, tabName);
                changeColorguna2button(btSetting.Name);
            }
            else
            {
                MessageBox.Show("This Account Don't Have Permission For This Function.");
            }
        }

        private void btBDReport_Click(object sender, EventArgs e)
        {


        }

        private void btSMK1_Click(object sender, EventArgs e)
        {
            if (checkPermiss("smk"))
            {

                using (SettingUseSMK di = new SettingUseSMK())
                {
                    if (di.ShowDialog() == DialogResult.OK)
                    {

                        string tabName = "SMK";
                        Form form;
                        if (formInstances.ContainsKey(tabName))
                        {
                            form = formInstances[tabName];
                        }
                        else
                        {
                            form = new MainSMK();
                            formInstances[tabName] = form;
                        }
                        themtabpage(form, tabName);
                        TabPageShowAgain(tabform, tabName);
                        changeColorguna2button(btSMK1.Name);
                    }
                }
            }
            else
            {
                MessageBox.Show("This Account Don't Have Permission For This Function.");
            }
        }

        private void btChBudle_Click(object sender, EventArgs e)
        {

            string tabName = "Bundle Report";
            Form form;
            if (formInstances.ContainsKey(tabName))
            {
                form = formInstances[tabName];
            }
            else
            {
                form = new SewingReport();
                formInstances[tabName] = form;
            }
            themtabpage(form, tabName);
            TabPageShowAgain(tabform, tabName);
            changeColorguna2button(btChBudle.Name);
        }

        private void btSewing_Click(object sender, EventArgs e)
        { //
            showSubMenu(pnSew);
            changeColorguna2button(btSewing.Name);
        }
        public void ToggleMenu(bool show)
        {
            pnSideMenu1.Visible = show;
            pnSideMenu0.Size = new Size(show ? 186 : 32, this.ClientSize.Height);
            btHideMenu.Visible = show;
            btShowMenu.Visible = !show;
        }

        private void btHideMenu_Click(object sender, EventArgs e)
        {

            ToggleMenu(false);
        }

        private void btShowMenu_Click(object sender, EventArgs e)
        {
            ToggleMenu(true);
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {

        }

        private void ScanDec_Click(object sender, EventArgs e)
        {
            if (checkPermiss("Decoration"))
            {
                //changeColorguna2button(ScanDec.Name);
                //using (SelectDepartScan di = new SelectDepartScan())
                //{
                //    if (di.ShowDialog() == DialogResult.OK)
                //    {
                //        using (ScanInOut scaninout = new ScanInOut())
                //        {
                //            if (scaninout.ShowDialog() == DialogResult.OK)
                //            {

                //            }
                //        }
                //    }
                //}

                changeColorguna2button(ScanDec.Name);
                DeliveryNoteStatus = false;
                using (SelectDepartScan di = new SelectDepartScan())
                {
                    if (di.ShowDialog() == DialogResult.OK)
                    {
                        using (ScanInOutWithSummery scanInOutWithSummery = new ScanInOutWithSummery())
                        {
                            if (scanInOutWithSummery.ShowDialog() == DialogResult.OK)
                            {

                            }
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("This Account Don't Have Permission For This Function.");
            }



        }

        private void btDecoration_Click(object sender, EventArgs e)
        {
            showSubMenu(pnDec);
            changeColorguna2button(btDecoration.Name);
        }

        private void btDecReport_Click(object sender, EventArgs e)
        {
            string tabName = "Decoration Report";
            Form form;
            if (formInstances.ContainsKey(tabName))
            {
                form = formInstances[tabName];
            }
            else
            {
                form = new DecorationReport();
                formInstances[tabName] = form;
            }
            themtabpage(form, tabName);
            TabPageShowAgain(tabform, tabName);
            changeColorguna2button(btDecReport.Name);
        }

        private void cbbFactory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbFactory.SelectedIndex > -1)
            {
                Properties.Settings.Default.Factory = cbbFactory.Text;
                Properties.Settings.Default.Save();

                for (int i = 0; i < Factory_dt.Rows.Count; i++)
                {
                    if (cbbFactory.Text == Factory_dt.Rows[i]["FactoryCode"].ToString())
                    {
                        Regis_SD_ID = Factory_dt.Rows[i]["sd_register_no"].ToString();
                    }

                }
            }
        }

        private void btDailyTarget_Click(object sender, EventArgs e)
        {

        }

        private void btDatatransfer_Click(object sender, EventArgs e)
        {//DataTransfer
            if (checkPermiss("datatransfer"))
            {
                string tabName = "Data Transfer";
                Form form;

                if (formInstances.ContainsKey(tabName))
                {
                    form = formInstances[tabName];
                }
                else
                {
                    form = new DataTransfer();
                    formInstances[tabName] = form;
                }
                themtabpage(form, tabName);
                TabPageShowAgain(tabform, tabName);
                changeColorguna2button(btDatatransfer.Name);
            }
            else
            {
                MessageBox.Show("This Account Don't Have Permission For This Function.");
            }
        }

        private void btMultiskill_Click(object sender, EventArgs e)
        {
            // \\12.0.100.251\ImgSimilarity\GarmentTypeImg\

            string tabName = "Multi Skill";
            Form form;
            if (formInstances.ContainsKey(tabName))
            {
                form = formInstances[tabName];
            }
            else
            {
                form = new MutiSkill();
                formInstances[tabName] = form;
            }
            themtabpage(form, tabName);
            TabPageShowAgain(tabform, tabName);
            changeColorguna2button(btMultiskill.Name);
        }

        private void btPackingEndLine_Click(object sender, EventArgs e)
        {//PackingDailyOutput
            string tabName = "Packing Daily Output";
            Form form;
            if (formInstances.ContainsKey(tabName))
            {
                form = formInstances[tabName];
            }
            else
            {
                form = new PackingDailyOutput();
                formInstances[tabName] = form;
            }
            themtabpage(form, tabName);
            TabPageShowAgain(tabform, tabName);
            changeColorguna2button(btPackingEndLine.Name);
        }

        private void btPack_Click(object sender, EventArgs e)
        {
            showSubMenu(pnPack);
            changeColorguna2button(btPack.Name);
        }

        private void btTargetPack_Click(object sender, EventArgs e)
        {

        }
        public string inc_header = "";
        private void btInc_Cut_Click(object sender, EventArgs e)
        {
            inc_header = "Cutting";
            string tabName = "Incentive";
            Form form;
            if (formInstances.ContainsKey(tabName))
            {
                form = formInstances[tabName];
            }
            else
            {
                form = new IncentiveReport();
                formInstances[tabName] = form;
            }
            themtabpage(form, tabName);
            TabPageShowAgain(tabform, tabName);
            changeColorguna2button(btInc_Cut.Name);
        }

        private void btIncentineSewing_Click(object sender, EventArgs e)
        {
            inc_header = "Sewing";
            string tabName = "Incentive";
            Form form;
            if (formInstances.ContainsKey(tabName))
            {
                form = formInstances[tabName];
            }
            else
            {
                form = new IncentiveReport();
                formInstances[tabName] = form;
            }
            themtabpage(form, tabName);
            TabPageShowAgain(tabform, tabName);
            changeColorguna2button(btIncentineSewing.Name);
        }

        private void btPackingDailyReport_Click(object sender, EventArgs e)
        {
            string tabName = "Packing Daily Output";
            Form form;
            if (formInstances.ContainsKey(tabName))
            {
                form = formInstances[tabName];
            }
            else
            {
                form = new PackingDailyOutput();
                formInstances[tabName] = form;
            }
            themtabpage(form, tabName);
            TabPageShowAgain(tabform, tabName);
            changeColorguna2button(btPackingDailyReport.Name);
        }

        private void btCutDailyReport_Click(object sender, EventArgs e)
        {
            string tabName = "Cutting Daily Output";
            Form form;
            if (formInstances.ContainsKey(tabName))
            {
                form = formInstances[tabName];
            }
            else
            {
                form = new ReportCuttingDaily();
                formInstances[tabName] = form;
            }
            themtabpage(form, tabName);
            TabPageShowAgain(tabform, tabName);
            changeColorguna2button(btCutDailyReport.Name);
        }

        private void btSewDailyReportinSew_Click(object sender, EventArgs e)
        {
            string tabName = "Sewing Daily Report";
            Form form;
            if (formInstances.ContainsKey(tabName))
            {
                form = formInstances[tabName];
            }
            else
            {
                form = new ReportSewingDaily();
                formInstances[tabName] = form;
            }
            themtabpage(form, tabName);
            TabPageShowAgain(tabform, tabName);
            changeColorguna2button(btSewDailyReport.Name);
        }

        private void btCuttingProductivity_Click(object sender, EventArgs e)
        {
            string tabName = "Cutting Daily Output";
            Form form;
            if (formInstances.ContainsKey(tabName))
            {
                form = formInstances[tabName];
            }
            else
            {
                form = new ReportCuttingDaily();
                formInstances[tabName] = form;
            }
            themtabpage(form, tabName);
            TabPageShowAgain(tabform, tabName);
            changeColorguna2button(btCuttingProductivity.Name);
        }

        private void btScanTest_Click(object sender, EventArgs e)
        {
            if (checkPermiss("superUser"))
            {
                if (checkPermiss("Decoration"))
                {
                    changeColorguna2button(ScanDec.Name);
                    DeliveryNoteStatus = false;
                    using (SelectDepartScan di = new SelectDepartScan())
                    {
                        if (di.ShowDialog() == DialogResult.OK)
                        {
                            using (ScanInOutWithSummery scanInOutWithSummery = new ScanInOutWithSummery())
                            {
                                if (scanInOutWithSummery.ShowDialog() == DialogResult.OK)
                                {

                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("This Account Don't Have Permission For This Function.");
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AdjustQTY_V2 adjustQTY_V2 = new AdjustQTY_V2();
            adjustQTY_V2.Show();
        }

        private void btDeliveryNote_Click(object sender, EventArgs e)
        {

            changeColorguna2button(btDeliveryNote.Name);
            DeliveryNoteStatus = true;

            using (ScanInOutWithSummery scanInOutWithSummery = new ScanInOutWithSummery())
            {
                if (scanInOutWithSummery.ShowDialog() == DialogResult.OK)
                {

                }
            }



        }
    }
}
