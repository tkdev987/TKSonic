namespace PTS_For_Cut.SMK
{
    partial class ScanInOutSMK
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScanInOutSMK));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel3 = new Panel();
            gvBundleDetail = new DataGridView();
            tableLayoutPanel5 = new TableLayoutPanel();
            panel1 = new Panel();
            lbClothingPart = new Label();
            label2 = new Label();
            panel4 = new Panel();
            panel2 = new Panel();
            numQTY = new Guna.UI2.WinForms.Guna2NumericUpDown();
            btQty = new Guna.UI2.WinForms.Guna2PictureBox();
            label1 = new Label();
            panel6 = new Panel();
            lbAllBundle = new Label();
            label5 = new Label();
            panel5 = new Panel();
            lbBundleScanned = new Label();
            label4 = new Label();
            panel7 = new Panel();
            toolStrip1 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            cbbScnaMode1 = new ToolStripComboBox();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripLabel2 = new ToolStripLabel();
            cbbDec1 = new ToolStripComboBox();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripLabel3 = new ToolStripLabel();
            cbbLocation1 = new ToolStripComboBox();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripLabel4 = new ToolStripLabel();
            tbQrCode = new ToolStripTextBox();
            toolStripSeparator5 = new ToolStripSeparator();
            btScan = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            btSave = new ToolStripButton();
            tableLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvBundleDetail).BeginInit();
            tableLayoutPanel5.SuspendLayout();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQTY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btQty).BeginInit();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel3, 0, 1);
            tableLayoutPanel1.Controls.Add(toolStrip1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 39F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1419, 640);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(gvBundleDetail);
            panel3.Controls.Add(tableLayoutPanel5);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 42);
            panel3.Name = "panel3";
            panel3.Size = new Size(1413, 595);
            panel3.TabIndex = 0;
            // 
            // gvBundleDetail
            // 
            gvBundleDetail.AllowUserToAddRows = false;
            gvBundleDetail.AllowUserToDeleteRows = false;
            gvBundleDetail.BackgroundColor = SystemColors.Control;
            gvBundleDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            gvBundleDetail.DefaultCellStyle = dataGridViewCellStyle1;
            gvBundleDetail.Dock = DockStyle.Fill;
            gvBundleDetail.Location = new Point(0, 100);
            gvBundleDetail.Name = "gvBundleDetail";
            gvBundleDetail.ReadOnly = true;
            gvBundleDetail.RowTemplate.Height = 25;
            gvBundleDetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gvBundleDetail.Size = new Size(1413, 495);
            gvBundleDetail.TabIndex = 0;
            gvBundleDetail.CellContentClick += gvBundleDetail_CellContentClick;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 5;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel5.Controls.Add(panel1, 2, 0);
            tableLayoutPanel5.Controls.Add(panel4, 3, 0);
            tableLayoutPanel5.Controls.Add(panel6, 1, 0);
            tableLayoutPanel5.Dock = DockStyle.Top;
            tableLayoutPanel5.Location = new Point(0, 0);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Size = new Size(1413, 100);
            tableLayoutPanel5.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(lbClothingPart);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(496, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(417, 94);
            panel1.TabIndex = 0;
            // 
            // lbClothingPart
            // 
            lbClothingPart.AutoSize = true;
            lbClothingPart.Dock = DockStyle.Fill;
            lbClothingPart.Font = new Font("Bahnschrift", 39.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbClothingPart.ForeColor = Color.Blue;
            lbClothingPart.Location = new Point(0, 24);
            lbClothingPart.Name = "lbClothingPart";
            lbClothingPart.Padding = new Padding(8, 0, 0, 0);
            lbClothingPart.Size = new Size(158, 64);
            lbClothingPart.TabIndex = 0;
            lbClothingPart.Text = "XXXX";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.HotTrack;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Padding = new Padding(15, 5, 0, 0);
            label2.Size = new Size(119, 24);
            label2.TabIndex = 1;
            label2.Text = "Clothing Part";
            // 
            // panel4
            // 
            panel4.Controls.Add(panel2);
            panel4.Controls.Add(label1);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(919, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(276, 94);
            panel4.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(numQTY);
            panel2.Controls.Add(btQty);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 24);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(15);
            panel2.Size = new Size(276, 70);
            panel2.TabIndex = 1;
            // 
            // numQTY
            // 
            numQTY.BackColor = Color.Transparent;
            numQTY.CustomizableEdges = customizableEdges1;
            numQTY.Dock = DockStyle.Fill;
            numQTY.FillColor = SystemColors.ControlLight;
            numQTY.Font = new Font("Bahnschrift", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            numQTY.ForeColor = SystemColors.HotTrack;
            numQTY.Location = new Point(15, 15);
            numQTY.Margin = new Padding(8, 9, 8, 9);
            numQTY.Name = "numQTY";
            numQTY.Padding = new Padding(0, 0, 20, 0);
            numQTY.ShadowDecoration.CustomizableEdges = customizableEdges2;
            numQTY.Size = new Size(206, 40);
            numQTY.TabIndex = 2;
            numQTY.UpDownButtonFillColor = SystemColors.ActiveCaption;
            // 
            // btQty
            // 
            btQty.CustomizableEdges = customizableEdges3;
            btQty.Dock = DockStyle.Right;
            btQty.Image = (Image)resources.GetObject("btQty.Image");
            btQty.ImageRotate = 0F;
            btQty.Location = new Point(221, 15);
            btQty.Name = "btQty";
            btQty.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btQty.Size = new Size(40, 40);
            btQty.SizeMode = PictureBoxSizeMode.StretchImage;
            btQty.TabIndex = 3;
            btQty.TabStop = false;
            btQty.Click += btQty_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.HotTrack;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(15, 5, 0, 0);
            label1.Size = new Size(52, 24);
            label1.TabIndex = 0;
            label1.Text = "QTY";
            // 
            // panel6
            // 
            panel6.Controls.Add(lbAllBundle);
            panel6.Controls.Add(label5);
            panel6.Controls.Add(panel5);
            panel6.Location = new Point(214, 3);
            panel6.Name = "panel6";
            panel6.Size = new Size(276, 94);
            panel6.TabIndex = 4;
            // 
            // lbAllBundle
            // 
            lbAllBundle.AutoSize = true;
            lbAllBundle.Dock = DockStyle.Fill;
            lbAllBundle.Font = new Font("Bahnschrift", 39.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbAllBundle.ForeColor = Color.Blue;
            lbAllBundle.Location = new Point(0, 24);
            lbAllBundle.Name = "lbAllBundle";
            lbAllBundle.Padding = new Padding(8, 0, 0, 0);
            lbAllBundle.Size = new Size(127, 64);
            lbAllBundle.TabIndex = 0;
            lbAllBundle.Text = "XXX";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Top;
            label5.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.HotTrack;
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Padding = new Padding(15, 5, 0, 0);
            label5.Size = new Size(99, 24);
            label5.TabIndex = 1;
            label5.Text = "All Bundle";
            // 
            // panel5
            // 
            panel5.Controls.Add(lbBundleScanned);
            panel5.Controls.Add(label4);
            panel5.Controls.Add(panel7);
            panel5.Dock = DockStyle.Right;
            panel5.Location = new Point(133, 0);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(0, 5, 0, 5);
            panel5.Size = new Size(143, 94);
            panel5.TabIndex = 3;
            // 
            // lbBundleScanned
            // 
            lbBundleScanned.AutoSize = true;
            lbBundleScanned.Dock = DockStyle.Left;
            lbBundleScanned.Font = new Font("Bahnschrift", 39.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbBundleScanned.ForeColor = Color.Blue;
            lbBundleScanned.Location = new Point(5, 24);
            lbBundleScanned.Name = "lbBundleScanned";
            lbBundleScanned.Size = new Size(119, 64);
            lbBundleScanned.TabIndex = 0;
            lbBundleScanned.Text = "XXX";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Top;
            label4.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.HotTrack;
            label4.Location = new Point(5, 5);
            label4.Name = "label4";
            label4.Padding = new Padding(5, 0, 0, 0);
            label4.Size = new Size(132, 19);
            label4.TabIndex = 1;
            label4.Text = "Bundle Scanned";
            // 
            // panel7
            // 
            panel7.BackColor = SystemColors.HotTrack;
            panel7.Dock = DockStyle.Left;
            panel7.Location = new Point(0, 5);
            panel7.Name = "panel7";
            panel7.Size = new Size(5, 84);
            panel7.TabIndex = 2;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1, cbbScnaMode1, toolStripSeparator1, toolStripLabel2, cbbDec1, toolStripSeparator2, toolStripLabel3, cbbLocation1, toolStripSeparator3, toolStripLabel4, tbQrCode, toolStripSeparator5, btScan, toolStripSeparator4, btSave });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1419, 39);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(88, 36);
            toolStripLabel1.Text = "Scan Mode";
            // 
            // cbbScnaMode1
            // 
            cbbScnaMode1.BackColor = SystemColors.ActiveCaption;
            cbbScnaMode1.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbScnaMode1.Items.AddRange(new object[] { "ScanIn", "ScanOut" });
            cbbScnaMode1.Name = "cbbScnaMode1";
            cbbScnaMode1.Size = new Size(150, 39);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 39);
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(89, 36);
            toolStripLabel2.Text = "Decoration";
            // 
            // cbbDec1
            // 
            cbbDec1.BackColor = SystemColors.ActiveCaption;
            cbbDec1.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbDec1.Name = "cbbDec1";
            cbbDec1.Size = new Size(150, 39);
            cbbDec1.SelectedIndexChanged += cbbDec1_SelectedIndexChanged;
            cbbDec1.Click += cbbDec1_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 39);
            // 
            // toolStripLabel3
            // 
            toolStripLabel3.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel3.Name = "toolStripLabel3";
            toolStripLabel3.Size = new Size(71, 36);
            toolStripLabel3.Text = "Location";
            // 
            // cbbLocation1
            // 
            cbbLocation1.BackColor = SystemColors.ActiveCaption;
            cbbLocation1.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbLocation1.Name = "cbbLocation1";
            cbbLocation1.Size = new Size(150, 39);
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 39);
            // 
            // toolStripLabel4
            // 
            toolStripLabel4.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel4.Name = "toolStripLabel4";
            toolStripLabel4.Size = new Size(100, 36);
            toolStripLabel4.Text = "Scan Bundle";
            // 
            // tbQrCode
            // 
            tbQrCode.BackColor = SystemColors.ActiveCaption;
            tbQrCode.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbQrCode.Name = "tbQrCode";
            tbQrCode.Size = new Size(180, 39);
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 39);
            // 
            // btScan
            // 
            btScan.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btScan.Image = (Image)resources.GetObject("btScan.Image");
            btScan.ImageTransparentColor = Color.Magenta;
            btScan.Name = "btScan";
            btScan.Padding = new Padding(30, 0, 0, 0);
            btScan.Size = new Size(119, 36);
            btScan.Text = "Check";
            btScan.Click += btScan_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 39);
            // 
            // btSave
            // 
            btSave.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btSave.Image = (Image)resources.GetObject("btSave.Image");
            btSave.ImageTransparentColor = Color.Magenta;
            btSave.Name = "btSave";
            btSave.Padding = new Padding(30, 0, 0, 0);
            btSave.Size = new Size(111, 36);
            btSave.Text = "Save";
            btSave.Click += btSave_Click;
            // 
            // ScanInOutSMK
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1419, 640);
            Controls.Add(tableLayoutPanel1);
            Name = "ScanInOutSMK";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ScanInOutSMK";
            WindowState = FormWindowState.Maximized;
            Load += ScanInOutSMK_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gvBundleDetail).EndInit();
            tableLayoutPanel5.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numQTY).EndInit();
            ((System.ComponentModel.ISupportInitialize)btQty).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel3;
        private DataGridView gvBundleDetail;
        private TableLayoutPanel tableLayoutPanel5;
        private ToolStrip toolStrip1;
        private ToolStripButton btScan;
        private ToolStripLabel toolStripLabel1;
        private ToolStripComboBox cbbScnaMode1;
        private ToolStripLabel toolStripLabel2;
        private ToolStripComboBox cbbDec1;
        private ToolStripLabel toolStripLabel3;
        private ToolStripLabel toolStripLabel4;
        private ToolStripComboBox cbbLocation1;
        private ToolStripTextBox tbQrCode;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton btSave;
        private Panel panel1;
        private Label lbClothingPart;
        private Panel panel2;
        private Guna.UI2.WinForms.Guna2PictureBox btQty;
        private Guna.UI2.WinForms.Guna2NumericUpDown numQTY;
        private Panel panel4;
        private Label label1;
        private Label label2;
        private Panel panel6;
        private Label lbAllBundle;
        private Label label5;
        private Panel panel5;
        private Label lbBundleScanned;
        private Label label4;
        private Panel panel7;
        private ToolStripSeparator toolStripSeparator5;
    }
}