using MySql.Data.MySqlClient;
using PTS_For_Cut.Main;
using PTS_For_Cut.Myclass;
using PTS_For_Cut.Spreading.ScanIn;
using System.Data;
using System.IO.Ports;
using System.Net.Sockets;
using System.Text;

namespace PTS_For_Cut._3Spreading.ScanIn
{
    public partial class SpreadingScan : Form
    {
        public static SpreadingScan ins;

        private TcpListener server;
        private Thread listenThread;
        public SpreadingScan()
        {
            InitializeComponent();
            ins = this;
            //if (Properties.Settings.Default.whIP != "")
            //{
            //    tbWhIP.Text = Properties.Settings.Default.whIP;
            //}
            //server = new TcpListener(System.Net.IPAddress.Any, port);

            //listenThread = new Thread(new ThreadStart(ListenForMessages));
            //listenThread.Start();

            DataTable dt = new DataTable();
            dt = Login.ins.Line_dt;
            cbbTable.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["Department"].ToString() == "Cutting")
                {
                    cbbTable.Items.Add(dt.Rows[i]["Line"].ToString());
                }
            }
            ConnectMySQL.DisplayAndSearch("SELECT`Line`, `SO`, `calltime`, `Remark` FROM `a_fabric_call` WHERE `FinishTime` IS NULL", gvDisCall);
            cbbComport.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            cbbComport.Items.AddRange(ports);
        }

        private void ListenForMessages()
        {
            try
            {
                server.Start();
                Console.WriteLine("PC2 is waiting for connection...");

                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    NetworkStream stream = client.GetStream();

                    byte[] data = new byte[256];
                    int bytesRead = stream.Read(data, 0, data.Length);
                    string message = Encoding.ASCII.GetString(data, 0, bytesRead);

                    // Update UI on the form with the received message
                    UpdateLabel(message);

                    Console.WriteLine("Received message from PC1: " + message);

                    // Process the received message here

                    stream.Close();
                    client.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        private void UpdateLabel(string message)
        {
            if (label9.InvokeRequired)
            {
                label9.Invoke(new MethodInvoker(delegate { label9.Text = message; }));
            }
            else
            {
                label9.Text = message;
            }
        }



        private string SetTimeA(DateTimePicker dtpVal)
        {
            string txtDate = "";
            System.Globalization.CultureInfo _cultureEnInfo = new System.Globalization.CultureInfo("en-US");
            DateTime dateEng = Convert.ToDateTime(dtpVal.Value, _cultureEnInfo);
            txtDate = dateEng.ToString("yyyy-MM-dd", _cultureEnInfo);
            return txtDate;
        }





        private void Load()
        {


            int SumQty = 0;

        }


        private void btEditSD1_Click(object sender, EventArgs e)
        {
            if (HomePage.ins.checkPermiss("sd_scanEdit"))
            {
                HomePage.ins.sdDataScan = "EditData";
                using (ScanInSpreading di = new ScanInSpreading())
                {
                    if (di.ShowDialog() == DialogResult.OK)
                    {

                    }
                }
            }
            else
            {
                MessageBox.Show("This Account Don't Have Permission For This Function.");
            }
        }



        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void picScanInSD1_Click(object sender, EventArgs e)
        {
            HomePage.ins.sdDataScan = "ScanInSD";
            using (ScanInSpreading di = new ScanInSpreading())
            {
                if (di.ShowDialog() == DialogResult.OK)
                {
                    // searchF();
                }
            }
            TimerGetData.Start();
        }

        private void picScanOutSD1_Click(object sender, EventArgs e)
        {
            HomePage.ins.sdDataScan = "ScanOutSD";
            using (ScanInSpreading di = new ScanInSpreading())
            {

                if (di.ShowDialog() == DialogResult.OK)
                {
                    // searchF();
                }
            }
        }

        private void picScanInCut1_Click(object sender, EventArgs e)
        {
            HomePage.ins.sdDataScan = "ScanInCut";
            using (ScanInSpreading di = new ScanInSpreading())
            {

                if (di.ShowDialog() == DialogResult.OK)
                {
                    // searchF();
                }
            }
        }

        private void picScanOutCut1_Click(object sender, EventArgs e)
        {
            HomePage.ins.sdDataScan = "ScanOutCut";
            using (ScanInSpreading di = new ScanInSpreading())
            {

                if (di.ShowDialog() == DialogResult.OK)
                {
                    // searchF();
                }
            }
        }

        private string setDate(DateTime dtpVal)
        {
            string txtDate = "";
            System.Globalization.CultureInfo _cultureEnInfo = new System.Globalization.CultureInfo("en-US");
            DateTime dateEng = Convert.ToDateTime(dtpVal, _cultureEnInfo);
            txtDate = dateEng.ToString("yyyy-MM-dd HH:mm", _cultureEnInfo);
            return txtDate;
        }
        private void btCall_Click(object sender, EventArgs e)
        {
            if (cbbComport.SelectedIndex > -1)
            {
                if (cbbTable.SelectedIndex > -1 && tbSO.Text != "")
                {
                    bool checkduplicateInTable = false;
                    for (int i = 0; i < gvDisCall.Rows.Count; i++)
                    {
                        if (cbbTable.Text == gvDisCall.Rows[i].Cells["Line"].Value.ToString())
                        {
                            checkduplicateInTable = true;
                        }
                    }
                    if (!checkduplicateInTable)
                    {
                        //MessageBox.Show("SSs");
                        string checkSoDuplicate = ConnectMySQL.Subtext("SELECT  `So` FROM `so_tb` WHERE `So` LIKE '" + tbSO.Text + "'");
                        if (checkSoDuplicate == tbSO.Text)
                        {
                            if (MessageBox.Show("Are you sure you want to call fabric?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {



                                string DateST = setDate(DateTime.Now);
                                //bool st = ConnectMySQL.MysqlQuery("INSERT INTO `a_fabric_call`(`id`, `Line`, `SO`, `calltime`, `Remark`)" +
                                //    " VALUES (NULL,'" + cbbTable.Text + "','" + tbSO.Text + "','" + DateST + "','" + tbRemark.Text + "')");

                                MySqlParameter[] parameters =
                                   {
                                    new MySqlParameter("@LineIn", cbbTable.Text),
                                    new MySqlParameter("@SOIn", tbSO.Text),
                                    new MySqlParameter("@callTimeIn", DateST),
                                    new MySqlParameter("@RemarkIn", tbRemark.Text),
                                    new MySqlParameter("@InsertStatus", MySqlDbType.Bit) { Direction = ParameterDirection.Output }
                                };
                                bool st = ConnectMySQL.StoredProcedure("insertCallFabricAndgetBack", parameters, CommandType.StoredProcedure);

                                if (st)
                                {
                                    MessageBox.Show("Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //ConnectMySQL.DisplayAndSearch("SELECT`Line`, `SO`, `calltime`, `Remark` FROM `a_fabric_call` WHERE `FinishTime` IS NULL", gvDisCall);
                                    //if (gvDis.Rows.Count > 0)
                                    //{
                                    //    OnOffligth("11");//Turn On
                                    //    picAlert.Visible = true;

                                    //}
                                    //else
                                    //{
                                    //    OnOffligth("00");//Turn On
                                    //    picAlert.Visible = false;
                                    //}
                                    getData();

                                }
                                else
                                {
                                    MessageBox.Show("Error Can't Insert", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                            }
                        }
                        else
                        {
                            MessageBox.Show("Don't Have SO in Database");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Duplicate Can't Insert", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("!!!! Please select Comport !!!!");
            }
        }


        static int port = 8080;


        private async Task<bool> SendDataToPC2Async(string data)
        {
            try
            {
                //using (TcpClient client = new TcpClient(tbWhIP.Text, port)) // PC2's IP address
                //{
                //    using (NetworkStream stream = client.GetStream())
                //    {
                //        byte[] bytesToSend = Encoding.ASCII.GetBytes(data);

                //        for (int i = 0; i < 1; i++)
                //        {
                //            await stream.WriteAsync(bytesToSend, 0, bytesToSend.Length);
                //            // Delay for 2000 milliseconds (2 seconds)
                //        }

                //        // Console.WriteLine("Data sent to PC2: " + data);
                //    }
                //}
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        private void SpreadingScan_FormClosed(object sender, FormClosedEventArgs e)
        {
            TimerGetData.Stop();
            DisconnectComport();
        }

        private void gvDisCall_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (MessageBox.Show("You Want to Close Job?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string xx = gvDisCall.Rows[e.RowIndex].Cells["Line"].Value.ToString();
                    bool st = ConnectMySQL.MysqlQuery("UPDATE `a_fabric_call` SET `FinishTime`=CURRENT_TIMESTAMP() WHERE `Line`LIKE '" + xx + "' AND `AcceptTime` IS NOT NULL AND `FinishTime` IS NULL");
                    if (st)
                    {
                        //SendDataToPC2Async("11").Wait();
                        //if (gvDis.Rows.Count > 0)
                        //{
                        //    OnOffligth("11");//Turn On
                        //    picAlert.Visible = true;

                        //}
                        //else
                        //{
                        //    OnOffligth("00");//Turn On
                        //    picAlert.Visible = false;
                        //}
                        MessageBox.Show(" OK ", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getData();
                        // ConnectMySQL.DisplayAndSearch("SELECT`Line`, `SO`, `calltime`, `Remark` FROM `a_fabric_call` WHERE `FinishTime` IS NULL", gvDisCall);


                    }
                    else
                    {
                        MessageBox.Show(" Can't Update ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }
        }

        private void gvDisCall_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbbComport_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConnectComport(cbbComport.Text);
            getData();
        }
        bool comportStatus = false;
        SerialPort sp;
        private void ConnectComport(string cName)
        {
            if (!string.IsNullOrEmpty(cName) && !comportStatus)
            {
                sp = new SerialPort(cName, 9600, Parity.None, 8, StopBits.One)
                {
                    Handshake = Handshake.None,
                    ReadTimeout = 500,
                    WriteTimeout = 500
                };

                try
                {
                    sp.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                    sp.Open();
                    comportStatus = true;

                    MessageBox.Show("Connected successfully", "Info");
                    TimerGetData.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Comport Error!");
                }
            }
        }
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort sp = (SerialPort)sender;
                string w = sp.ReadExisting();
                if (!string.IsNullOrEmpty(w))
                {
                    Invoke(new Action(() => tbRecieptData.AppendText(w)));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Data Receive Error");
            }
        }
        public void OnOffligth(string idbox)
        {
            // MessageBox.Show(comportStatus.ToString());
            if (comportStatus == true)
            {

                sp.WriteLine(idbox);
                Thread.Sleep(500);
                sp.WriteLine(idbox);
                //MessageBox.Show(idbox);
                //label2.Text = idbox;

            }

        }
        private void DisconnectComport()
        {
            if (comportStatus && sp != null)
            {
                try
                {
                    sp.Close();
                    sp.Dispose();
                    comportStatus = false;
                    MessageBox.Show("Disconnected successfully", "Info");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Disconnection Error");
                }
            }
        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void TimerGetData_Tick(object sender, EventArgs e)
        {
            getData();
        }
        private void getData()
        {
            ConnectMySQL.DisplayAndSearch("SELECT`Line`, `SO`, `calltime`, `Remark` FROM `a_fabric_call` WHERE `FinishTime` IS NULL", gvDisCall);
            if (gvDisCall.Rows.Count > 0)
            {
                OnOffligth("11");//Turn On
                picAlert.Visible = true;

            }
            else
            {
                OnOffligth("00");//Turn On
                picAlert.Visible = false;
            }
        }

        private void cbbComport_Click(object sender, EventArgs e)
        {

        }


    }
}
