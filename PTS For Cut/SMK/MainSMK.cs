using PTS_For_Cut.Main;
using PTS_For_Cut.Myclass;
using PTS_For_Cut.ScanBundle;
using System.Data;
using System.IO.Ports;

namespace PTS_For_Cut.SMK
{
    public partial class MainSMK : Form
    {

        private DataTable dtMatCall = new DataTable();
        private DataTable dtMatAccepted = new DataTable();
        public string DbID = "";
        private bool stateLight = false;
        SerialPort sp;
        public bool comportStatus = false;
        public static MainSMK ins;
        public string UserID = "";
        public MainSMK()
        {
            InitializeComponent();
            ins = this;
        }

        private void picAlert_Paint(object sender, PaintEventArgs e)
        {
            int a = picAlert.Width - picAlert.Image.Width;
            int b = picAlert.Height - picAlert.Image.Height;
            Padding p = panel1.Padding;
            p.Left = a / 2;
            p.Top = b / 2;
            picAlert.Padding = p;
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            picAlert.Width = panel1.Height;
            if (picAlert.Width == picAlert.Height) return;

            if (picAlert.Width > picAlert.Height)
            {
                picAlert.Height = picAlert.Width;
            }
            else
            {
                picAlert.Width = picAlert.Height;
            }
        }

        private void lbAlert_Paint(object sender, PaintEventArgs e)
        {
            int a = panel2.Width - lbAlert.Width;
            int b = panel2.Height - lbAlert.Height;

            lbAlert.Left = a / 2;
            lbAlert.Top = b / 2;
        }

        private void panel2_Resize(object sender, EventArgs e)
        {
            int a = panel2.Width - lbAlert.Width;
            int b = panel2.Height - lbAlert.Height;

            lbAlert.Left = a / 2;
            lbAlert.Top = b / 2;
        }

        private void MainSMK_Load(object sender, EventArgs e)
        {
            AddColumn();
            ConnectComport(Login.ins.comport);
            LoadInUc();
        }
        private void AddColumn()
        {
            dtMatCall.Columns.Add("Line");
            dtMatCall.Columns.Add("Request Reason");
            dtMatCall.Columns.Add("Time");
            dtMatCall.Columns.Add("Database ID");

            dtMatAccepted.Columns.Add("Line");
            dtMatAccepted.Columns.Add("Request Reason");
            dtMatAccepted.Columns.Add("Time");
            dtMatAccepted.Columns.Add("Deliver");
            dtMatAccepted.Columns.Add("Database ID");
        }
        private void ConnectComport(string cName)
        {
            if ((cName != "") && (comportStatus == false))
            {
                // MessageBox.Show(cName);
                sp = new SerialPort(cName, 9600, Parity.None, 8, StopBits.One);
                sp.Handshake = Handshake.None;
                sp.ReadTimeout = 500;
                sp.WriteTimeout = 500;


                //label7.Text = x.ToString();
                try
                {
                    sp.Open();
                    comportStatus = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Comport Error!");
                }
                //cbbComport.Text = cName;
                sp.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            }
        }
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string w = sp.ReadExisting();
            if (w != String.Empty)
            {
                Invoke(new Action(() => tbRecieptData.AppendText(w)));
            }
        }

        private void lbAlert_TextChanged(object sender, EventArgs e)
        {
            if (gvDisCall.Rows.Count > 0)
            {
                if (!stateLight)
                {
                    Thread.Sleep(500);
                    sp.WriteLine("11");
                    Thread.Sleep(500);
                    sp.WriteLine("11");
                    // label2.Text = idbox;
                    stateLight = true;
                    picAlert.Visible = true;
                }
            }
            else
            {
                if (stateLight)
                {
                    Thread.Sleep(500);
                    sp.WriteLine("00");
                    Thread.Sleep(500);
                    sp.WriteLine("00");
                    stateLight = false;
                    picAlert.Visible = false;
                }

            }
        }
        public void OnOffligth(string idbox)
        {
            // MessageBox.Show(comportStatus.ToString());
            if (comportStatus == true)
            {
                Thread.Sleep(500);
                sp.WriteLine(idbox);
                Thread.Sleep(500);
                sp.WriteLine(idbox);
                //label2.Text = idbox;

            }

        }
        public void LoadInUc()
        {
            getDaata();
            if (gvDisCall.Rows.Count > 0)
            {
                lbAlert.Text = gvDisCall.Rows[0].Cells["Line"].Value.ToString();
                DbID = gvDisCall.Rows[0].Cells["Database ID"].Value.ToString();
                picAlert.Visible = true;
            }
            else
            {
                lbAlert.Text = "";
                picAlert.Visible = false;
            }

            getDataTimer.Start();
        }
        public void CloseForm()
        {

            getDataTimer.Stop();
            // MessageBox.Show("Stop");
        }

        private void getDataTimer_Tick(object sender, EventArgs e)
        {
            getDaata();
        }
        private void getDaata()
        {
            dtMatCall.Rows.Clear();
            dtMatAccepted.Rows.Clear();
            DataTable dt = new DataTable();//`b_type_token_tb`.`t_id`

            dt = ConnectMySQL.MySQLtoDataTable("SELECT `b`.`call_id`,`b`.`call_line`,`b`.`call_problem`,`b`.`call_calltime`, `b`.`call_accepttime`, " +
                "`b`.`call_mechanic` FROM `b_bldsmk` AS `a` JOIN `b_call_tb` AS `b` ON `a`.`bldsmk_bld`=SUBSTRING(`b`.`call_line`,1,3) AND " +
                "`b`.`call_type`='3' AND DATE(`b`.`call_calltime`)=current_date() AND `b`.`call_fixtime`IS NULL WHERE`a`.`bldsmk_smk`='" + Login.ins.SMKBuilding + "';");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string DatabaseID = dt.Rows[i]["call_id"].ToString();
                string line = dt.Rows[i]["call_line"].ToString();
                string Reason = dt.Rows[i]["call_problem"].ToString();
                string calltime = dt.Rows[i]["call_calltime"].ToString();
                string deliverA = dt.Rows[i]["call_mechanic"].ToString();

                if (dt.Rows[i]["call_accepttime"] == DBNull.Value)
                {
                    dtMatCall.Rows.Add(line, Reason, calltime, DatabaseID);
                    // MessageBox.Show(dt.Rows[i]["call_accepttime"].ToString());
                }
                else if (dt.Rows[i]["call_accepttime"] != DBNull.Value)
                {
                    dtMatAccepted.Rows.Add(line, Reason, calltime, deliverA, DatabaseID);//
                }
            }
            gvDisCall.DataSource = dtMatCall;
            gvDisCall.Columns["Line"].Width = 70;
            gvDisCall.Columns["Request Reason"].Width = 330;
            gvDisCall.Columns["Time"].Width = 180;
            gvDisCall.Columns["Database ID"].Width = 120;

            gvDisAccept.DataSource = dtMatAccepted;
            gvDisAccept.Columns["Line"].Width = 70;
            gvDisAccept.Columns["Request Reason"].Width = 330;
            gvDisAccept.Columns["Time"].Width = 180;
            gvDisAccept.Columns["Database ID"].Width = 120;
            if (lbAlert.Text == "" && gvDisCall.Rows.Count > 0)
            {
                int d = 0;
                DataGridViewRow sel = gvDisCall.Rows[d];
                lbAlert.Text = sel.Cells["Line"].Value.ToString();
                DbID = sel.Cells["Database ID"].Value.ToString();
                picAlert.Visible = true;
            }
        }

        private void gvDisCall_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (gvDisCall.Rows.Count > 0)
                {
                    // status = true;
                    int d = e.RowIndex;
                    DataGridViewRow sel = gvDisCall.Rows[d];
                    lbAlert.Text = sel.Cells["Line"].Value.ToString();
                    DbID = sel.Cells["Database ID"].Value.ToString();

                }
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (tbUserID.Text != "")
            {
                string userID = ConnectMySQL.Subtext("SELECT `empID` FROM `user_tb` WHERE `empID`='" + tbUserID.Text + "'AND `Active`=1;");
                if (userID != "")
                {
                    //  MessageBox.Show(userID);
                    UserID = userID;
                    HomePage.ins.Decoration = "SMK";
                    HomePage.ins.DecMode = "Scan Out";
                    HomePage.ins.Declocation = lbAlert.Text;
                    HomePage.ins.DecOut = "Sewing";

                    //ScanInOut scaninout = new ScanInOut();
                    //scaninout.Show();

                    HomePage.ins.dtLocation = ConnectMySQL.MySQLtoDataTable("SELECT `Location` FROM `location_tb` WHERE `LocationGroup` LIKE 'SMK';");
                    using (ScanInOutWithSummery di = new ScanInOutWithSummery())
                    {
                        if (di.ShowDialog() == DialogResult.OK)
                        {
                            string DateAc = Date_Now();
                            ConnectMySQL.MysqlQuery("UPDATE `b_call_tb` SET `call_accepttime`='" + DateAc + "',`call_mechanic`='" + UserID + "' WHERE `call_id`='" + DbID + "'");
                            getDaata();
                            lbAlert.Text = "";
                            DbID = "";
                            tbUserID.Text = "";
                        }
                    }
                    UserID = "";
                }
                else
                {
                    MessageBox.Show("Employee ID Incorrect");
                }
            }
            else
            {
                MessageBox.Show("Please Enter Employee ID");
            }
        }
        private string Date_Now()
        {
            string txtDate = "";
            System.Globalization.CultureInfo _cultureEnInfo = new System.Globalization.CultureInfo("en-US");
            DateTime dateEng = Convert.ToDateTime(DateTime.Now, _cultureEnInfo);
            txtDate = dateEng.ToString("yyyy-MM-dd HH:mm:ss", _cultureEnInfo);
            return txtDate;
        }
        private void btReport_Click(object sender, EventArgs e)
        {
           
        }

        private void tbTextTest_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OnOffligth(tbTextTest.Text);
            }
        }

        private void btScanIn_Click(object sender, EventArgs e)
        {
            using (SelectDepartScan di = new SelectDepartScan())
            {
                if (di.ShowDialog() == DialogResult.OK)
                {
                    ScanInOutWithSummery scaninout = new ScanInOutWithSummery();
                    scaninout.Show();
                }
            }
        }
    }
}
