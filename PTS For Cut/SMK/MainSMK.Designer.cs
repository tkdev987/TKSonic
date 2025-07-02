namespace PTS_For_Cut.SMK
{
    partial class MainSMK
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainSMK));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            toolStrip1 = new ToolStrip();
            btScanIn = new ToolStripButton();
            btReport = new ToolStripButton();
            tlpAlert = new TableLayoutPanel();
            panel1 = new Panel();
            picAlert = new PictureBox();
            panel2 = new Panel();
            lbAlert = new Label();
            panel3 = new Panel();
            tbTextTest = new Guna.UI2.WinForms.Guna2TextBox();
            tbRecieptData = new TextBox();
            tlpCallAndAccept = new TableLayoutPanel();
            panel4 = new Panel();
            gvDisCall = new DataGridView();
            toolStrip2 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            tbUserID = new ToolStripTextBox();
            btSave = new ToolStripButton();
            toolStripLabel2 = new ToolStripLabel();
            btTest = new ToolStripButton();
            panel5 = new Panel();
            gvDisAccept = new DataGridView();
            toolStrip3 = new ToolStrip();
            toolStripLabel3 = new ToolStripLabel();
            toolStripButton3 = new ToolStripButton();
            getDataTimer = new System.Windows.Forms.Timer(components);
            toolStrip1.SuspendLayout();
            tlpAlert.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAlert).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            tlpCallAndAccept.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvDisCall).BeginInit();
            toolStrip2.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvDisAccept).BeginInit();
            toolStrip3.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btScanIn, btReport });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1401, 31);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // btScanIn
            // 
            btScanIn.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btScanIn.Image = (Image)resources.GetObject("btScanIn.Image");
            btScanIn.ImageTransparentColor = Color.Magenta;
            btScanIn.Name = "btScanIn";
            btScanIn.Size = new Size(90, 28);
            btScanIn.Text = "Scan In";
            btScanIn.Click += btScanIn_Click;
            // 
            // btReport
            // 
            btReport.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btReport.Image = (Image)resources.GetObject("btReport.Image");
            btReport.ImageTransparentColor = Color.Magenta;
            btReport.Name = "btReport";
            btReport.Size = new Size(86, 28);
            btReport.Text = "Report";
            btReport.Click += btReport_Click;
            // 
            // tlpAlert
            // 
            tlpAlert.BackColor = Color.White;
            tlpAlert.ColumnCount = 3;
            tlpAlert.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 400F));
            tlpAlert.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 650F));
            tlpAlert.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpAlert.Controls.Add(panel1, 0, 0);
            tlpAlert.Controls.Add(panel2, 1, 0);
            tlpAlert.Controls.Add(panel3, 2, 0);
            tlpAlert.Dock = DockStyle.Top;
            tlpAlert.Location = new Point(0, 31);
            tlpAlert.Name = "tlpAlert";
            tlpAlert.RowCount = 1;
            tlpAlert.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpAlert.Size = new Size(1401, 222);
            tlpAlert.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(picAlert);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(394, 216);
            panel1.TabIndex = 0;
            panel1.Resize += panel1_Resize;
            // 
            // picAlert
            // 
            picAlert.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            picAlert.Image = (Image)resources.GetObject("picAlert.Image");
            picAlert.Location = new Point(57, 0);
            picAlert.Name = "picAlert";
            picAlert.Size = new Size(252, 213);
            picAlert.SizeMode = PictureBoxSizeMode.StretchImage;
            picAlert.TabIndex = 0;
            picAlert.TabStop = false;
            picAlert.Paint += picAlert_Paint;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(lbAlert);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(403, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(644, 216);
            panel2.TabIndex = 1;
            panel2.Resize += panel2_Resize;
            // 
            // lbAlert
            // 
            lbAlert.AutoSize = true;
            lbAlert.BackColor = Color.White;
            lbAlert.Font = new Font("Arial Rounded MT Bold", 129.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbAlert.ForeColor = Color.FromArgb(230, 0, 14);
            lbAlert.Location = new Point(0, 4);
            lbAlert.Name = "lbAlert";
            lbAlert.Size = new Size(629, 200);
            lbAlert.TabIndex = 1;
            lbAlert.Text = "TK000";
            lbAlert.TextChanged += lbAlert_TextChanged;
            lbAlert.Paint += lbAlert_Paint;
            // 
            // panel3
            // 
            panel3.Controls.Add(tbTextTest);
            panel3.Controls.Add(tbRecieptData);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(1053, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(345, 216);
            panel3.TabIndex = 2;
            // 
            // tbTextTest
            // 
            tbTextTest.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            tbTextTest.BorderRadius = 5;
            tbTextTest.BorderThickness = 2;
            tbTextTest.CustomizableEdges = customizableEdges1;
            tbTextTest.DefaultText = "";
            tbTextTest.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbTextTest.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbTextTest.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbTextTest.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbTextTest.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbTextTest.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbTextTest.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbTextTest.Location = new Point(116, 173);
            tbTextTest.Margin = new Padding(4, 4, 4, 4);
            tbTextTest.Name = "tbTextTest";
            tbTextTest.PasswordChar = '\0';
            tbTextTest.PlaceholderText = "Test Lamp 00,11 >>Enter";
            tbTextTest.SelectedText = "";
            tbTextTest.ShadowDecoration.CustomizableEdges = customizableEdges2;
            tbTextTest.Size = new Size(225, 39);
            tbTextTest.TabIndex = 6;
            tbTextTest.KeyUp += tbTextTest_KeyUp;
            // 
            // tbRecieptData
            // 
            tbRecieptData.Location = new Point(12, 13);
            tbRecieptData.Name = "tbRecieptData";
            tbRecieptData.Size = new Size(173, 23);
            tbRecieptData.TabIndex = 5;
            tbRecieptData.Visible = false;
            // 
            // tlpCallAndAccept
            // 
            tlpCallAndAccept.ColumnCount = 2;
            tlpCallAndAccept.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpCallAndAccept.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpCallAndAccept.Controls.Add(panel4, 0, 0);
            tlpCallAndAccept.Controls.Add(panel5, 1, 0);
            tlpCallAndAccept.Dock = DockStyle.Fill;
            tlpCallAndAccept.Location = new Point(0, 253);
            tlpCallAndAccept.Name = "tlpCallAndAccept";
            tlpCallAndAccept.RowCount = 1;
            tlpCallAndAccept.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpCallAndAccept.Size = new Size(1401, 415);
            tlpCallAndAccept.TabIndex = 4;
            // 
            // panel4
            // 
            panel4.Controls.Add(gvDisCall);
            panel4.Controls.Add(toolStrip2);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(3, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(694, 409);
            panel4.TabIndex = 1;
            // 
            // gvDisCall
            // 
            gvDisCall.AllowUserToAddRows = false;
            gvDisCall.AllowUserToDeleteRows = false;
            gvDisCall.BackgroundColor = SystemColors.Control;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            gvDisCall.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gvDisCall.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            gvDisCall.DefaultCellStyle = dataGridViewCellStyle2;
            gvDisCall.Dock = DockStyle.Fill;
            gvDisCall.Location = new Point(0, 31);
            gvDisCall.Name = "gvDisCall";
            gvDisCall.ReadOnly = true;
            gvDisCall.RowTemplate.Height = 25;
            gvDisCall.Size = new Size(694, 378);
            gvDisCall.TabIndex = 0;
            gvDisCall.CellClick += gvDisCall_CellClick;
            // 
            // toolStrip2
            // 
            toolStrip2.ImageScalingSize = new Size(24, 24);
            toolStrip2.Items.AddRange(new ToolStripItem[] { toolStripLabel1, tbUserID, btSave, toolStripLabel2, btTest });
            toolStrip2.Location = new Point(0, 0);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(694, 31);
            toolStrip2.TabIndex = 1;
            toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(60, 28);
            toolStripLabel1.Text = "Emp ID";
            // 
            // tbUserID
            // 
            tbUserID.BackColor = SystemColors.ScrollBar;
            tbUserID.BorderStyle = BorderStyle.None;
            tbUserID.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbUserID.Name = "tbUserID";
            tbUserID.Size = new Size(150, 31);
            // 
            // btSave
            // 
            btSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btSave.Image = (Image)resources.GetObject("btSave.Image");
            btSave.ImageTransparentColor = Color.Magenta;
            btSave.Name = "btSave";
            btSave.Size = new Size(28, 28);
            btSave.Text = "Save";
            btSave.Click += btSave_Click;
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Alignment = ToolStripItemAlignment.Right;
            toolStripLabel2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(75, 28);
            toolStripLabel2.Text = "Call Table";
            // 
            // btTest
            // 
            btTest.Alignment = ToolStripItemAlignment.Right;
            btTest.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btTest.Image = (Image)resources.GetObject("btTest.Image");
            btTest.ImageTransparentColor = Color.Magenta;
            btTest.Name = "btTest";
            btTest.Size = new Size(28, 28);
            // 
            // panel5
            // 
            panel5.Controls.Add(gvDisAccept);
            panel5.Controls.Add(toolStrip3);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(703, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(695, 409);
            panel5.TabIndex = 2;
            // 
            // gvDisAccept
            // 
            gvDisAccept.AllowUserToAddRows = false;
            gvDisAccept.AllowUserToDeleteRows = false;
            gvDisAccept.BackgroundColor = SystemColors.Control;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            gvDisAccept.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            gvDisAccept.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            gvDisAccept.DefaultCellStyle = dataGridViewCellStyle4;
            gvDisAccept.Dock = DockStyle.Fill;
            gvDisAccept.Location = new Point(0, 31);
            gvDisAccept.Name = "gvDisAccept";
            gvDisAccept.ReadOnly = true;
            gvDisAccept.RowTemplate.Height = 25;
            gvDisAccept.Size = new Size(695, 378);
            gvDisAccept.TabIndex = 0;
            // 
            // toolStrip3
            // 
            toolStrip3.ImageScalingSize = new Size(24, 24);
            toolStrip3.Items.AddRange(new ToolStripItem[] { toolStripLabel3, toolStripButton3 });
            toolStrip3.Location = new Point(0, 0);
            toolStrip3.Name = "toolStrip3";
            toolStrip3.Size = new Size(695, 31);
            toolStrip3.TabIndex = 0;
            toolStrip3.Text = "toolStrip3";
            // 
            // toolStripLabel3
            // 
            toolStripLabel3.Alignment = ToolStripItemAlignment.Right;
            toolStripLabel3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel3.Name = "toolStripLabel3";
            toolStripLabel3.Size = new Size(95, 28);
            toolStripLabel3.Text = "Accept Table";
            // 
            // toolStripButton3
            // 
            toolStripButton3.Alignment = ToolStripItemAlignment.Right;
            toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton3.Image = (Image)resources.GetObject("toolStripButton3.Image");
            toolStripButton3.ImageTransparentColor = Color.Magenta;
            toolStripButton3.Name = "toolStripButton3";
            toolStripButton3.Size = new Size(28, 28);
            // 
            // getDataTimer
            // 
            getDataTimer.Interval = 6000;
            getDataTimer.Tick += getDataTimer_Tick;
            // 
            // MainSMK
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1401, 668);
            Controls.Add(tlpCallAndAccept);
            Controls.Add(tlpAlert);
            Controls.Add(toolStrip1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainSMK";
            Text = "MainSMK";
            Load += MainSMK_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            tlpAlert.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picAlert).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            tlpCallAndAccept.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gvDisCall).EndInit();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gvDisAccept).EndInit();
            toolStrip3.ResumeLayout(false);
            toolStrip3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton btScanIn;
        private ToolStripButton btReport;
        private TableLayoutPanel tlpAlert;
        private Panel panel1;
        private PictureBox picAlert;
        private Panel panel2;
        private Label lbAlert;
        private TableLayoutPanel tlpCallAndAccept;
        private Panel panel4;
        private DataGridView gvDisCall;
        private ToolStrip toolStrip2;
        private ToolStripLabel toolStripLabel1;
        private ToolStripTextBox tbUserID;
        private ToolStripButton btSave;
        private ToolStripLabel toolStripLabel2;
        private ToolStripButton btTest;
        private Panel panel5;
        private DataGridView gvDisAccept;
        private ToolStrip toolStrip3;
        private ToolStripLabel toolStripLabel3;
        private ToolStripButton toolStripButton3;
        private System.Windows.Forms.Timer getDataTimer;
        private Panel panel3;
        private TextBox tbRecieptData;
        private Guna.UI2.WinForms.Guna2TextBox tbTextTest;
    }
}