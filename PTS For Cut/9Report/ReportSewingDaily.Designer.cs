namespace PTS_For_Cut._9Report
{
    partial class ReportSewingDaily
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportSewingDaily));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            toolStrip1 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            cbbReportMode = new ToolStripComboBox();
            toolStripLabel2 = new ToolStripLabel();
            cbbBuilding = new ToolStripComboBox();
            toolStripLabel4 = new ToolStripLabel();
            cbbShow = new ToolStripComboBox();
            btLoad = new ToolStripButton();
            btExcel = new ToolStripButton();
            btDataReport = new ToolStripButton();
            lbMinute = new ToolStripLabel();
            toolStripLabel5 = new ToolStripLabel();
            toolStripLabel6 = new ToolStripSeparator();
            lbTime = new ToolStripLabel();
            toolStripLabel7 = new ToolStripLabel();
            toolStripLabel8 = new ToolStripLabel();
            toolStripLabel3 = new ToolStripLabel();
            btAdjustOutput = new ToolStripButton();
            btInc = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            dtpDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            timerRefresh = new System.Windows.Forms.Timer(components);
            pnlbHeader = new Panel();
            pictureBox1 = new PictureBox();
            lbHeader = new Label();
            gvDis2 = new Guna.UI2.WinForms.Guna2DataGridView();
            TimerRefreshFirst = new System.Windows.Forms.Timer(components);
            toolStrip2 = new ToolStrip();
            toolStripLabel10 = new ToolStripLabel();
            tbFontSize = new ToolStripTextBox();
            btSaveFontSize = new ToolStripButton();
            toolStrip1.SuspendLayout();
            pnlbHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvDis2).BeginInit();
            toolStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1, cbbReportMode, toolStripLabel2, cbbBuilding, toolStripLabel4, cbbShow, btLoad, btExcel, btDataReport, lbMinute, toolStripLabel5, toolStripLabel6, lbTime, toolStripLabel7, toolStripLabel8, toolStripLabel3, btAdjustOutput, btInc, toolStripSeparator1 });
            toolStrip1.Location = new Point(0, 75);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1393, 39);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(79, 36);
            toolStripLabel1.Text = "Report by";
            // 
            // cbbReportMode
            // 
            cbbReportMode.BackColor = SystemColors.ActiveCaption;
            cbbReportMode.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbReportMode.Items.AddRange(new object[] { "Style", "SO" });
            cbbReportMode.Name = "cbbReportMode";
            cbbReportMode.Size = new Size(121, 39);
            cbbReportMode.SelectedIndexChanged += cbbReportMode_SelectedIndexChanged_1;
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(52, 36);
            toolStripLabel2.Text = "Building";
            // 
            // cbbBuilding
            // 
            cbbBuilding.BackColor = SystemColors.ActiveCaption;
            cbbBuilding.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbBuilding.Items.AddRange(new object[] { "ALL", "TK1", "TK2" });
            cbbBuilding.Name = "cbbBuilding";
            cbbBuilding.Size = new Size(121, 39);
            cbbBuilding.SelectedIndexChanged += cbbBuilding_SelectedIndexChanged;
            // 
            // toolStripLabel4
            // 
            toolStripLabel4.Name = "toolStripLabel4";
            toolStripLabel4.Size = new Size(43, 36);
            toolStripLabel4.Text = "View";
            // 
            // cbbShow
            // 
            cbbShow.BackColor = SystemColors.ActiveCaption;
            cbbShow.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbShow.Items.AddRange(new object[] { "Show All", "Only Output" });
            cbbShow.Name = "cbbShow";
            cbbShow.Size = new Size(180, 39);
            cbbShow.SelectedIndexChanged += cbbShow_SelectedIndexChanged;
            // 
            // btLoad
            // 
            btLoad.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btLoad.Image = (Image)resources.GetObject("btLoad.Image");
            btLoad.ImageTransparentColor = Color.Magenta;
            btLoad.Name = "btLoad";
            btLoad.Size = new Size(86, 36);
            btLoad.Text = "Refresh";
            btLoad.Click += btLoad_Click;
            // 
            // btExcel
            // 
            btExcel.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btExcel.Image = (Image)resources.GetObject("btExcel.Image");
            btExcel.ImageTransparentColor = Color.Magenta;
            btExcel.Name = "btExcel";
            btExcel.Size = new Size(36, 36);
            btExcel.Text = "Export to Excel";
            btExcel.Click += btExcel_Click;
            // 
            // btDataReport
            // 
            btDataReport.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btDataReport.Image = (Image)resources.GetObject("btDataReport.Image");
            btDataReport.ImageTransparentColor = Color.Magenta;
            btDataReport.Name = "btDataReport";
            btDataReport.Size = new Size(36, 36);
            btDataReport.Text = "Add Data";
            btDataReport.Click += btDataReport_Click;
            // 
            // lbMinute
            // 
            lbMinute.Alignment = ToolStripItemAlignment.Right;
            lbMinute.Name = "lbMinute";
            lbMinute.Size = new Size(33, 36);
            lbMinute.Text = "xxx";
            // 
            // toolStripLabel5
            // 
            toolStripLabel5.Alignment = ToolStripItemAlignment.Right;
            toolStripLabel5.Name = "toolStripLabel5";
            toolStripLabel5.Size = new Size(65, 36);
            toolStripLabel5.Text = "Minute :";
            // 
            // toolStripLabel6
            // 
            toolStripLabel6.Alignment = ToolStripItemAlignment.Right;
            toolStripLabel6.Name = "toolStripLabel6";
            toolStripLabel6.Size = new Size(6, 39);
            // 
            // lbTime
            // 
            lbTime.Alignment = ToolStripItemAlignment.Right;
            lbTime.Name = "lbTime";
            lbTime.Size = new Size(83, 36);
            lbTime.Text = "HH:mm:ss";
            // 
            // toolStripLabel7
            // 
            toolStripLabel7.Alignment = ToolStripItemAlignment.Right;
            toolStripLabel7.Name = "toolStripLabel7";
            toolStripLabel7.Size = new Size(52, 36);
            toolStripLabel7.Text = "Time :";
            // 
            // toolStripLabel8
            // 
            toolStripLabel8.Alignment = ToolStripItemAlignment.Right;
            toolStripLabel8.Name = "toolStripLabel8";
            toolStripLabel8.Size = new Size(0, 36);
            // 
            // toolStripLabel3
            // 
            toolStripLabel3.Alignment = ToolStripItemAlignment.Right;
            toolStripLabel3.Name = "toolStripLabel3";
            toolStripLabel3.Size = new Size(113, 36);
            toolStripLabel3.Text = "Last Update >>";
            // 
            // btAdjustOutput
            // 
            btAdjustOutput.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btAdjustOutput.Image = (Image)resources.GetObject("btAdjustOutput.Image");
            btAdjustOutput.ImageTransparentColor = Color.Magenta;
            btAdjustOutput.Name = "btAdjustOutput";
            btAdjustOutput.Size = new Size(36, 36);
            btAdjustOutput.Text = "Adjust Output";
            btAdjustOutput.Click += btAdjustOutput_Click;
            // 
            // btInc
            // 
            btInc.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btInc.Image = (Image)resources.GetObject("btInc.Image");
            btInc.ImageTransparentColor = Color.Magenta;
            btInc.Margin = new Padding(10, 1, 0, 2);
            btInc.Name = "btInc";
            btInc.Size = new Size(36, 36);
            btInc.Text = "Incentive";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 39);
            // 
            // dtpDate
            // 
            dtpDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            dtpDate.BorderColor = Color.White;
            dtpDate.BorderRadius = 4;
            dtpDate.BorderThickness = 1;
            dtpDate.Checked = true;
            dtpDate.CustomizableEdges = customizableEdges1;
            dtpDate.FillColor = Color.WhiteSmoke;
            dtpDate.FocusedColor = Color.White;
            dtpDate.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDate.ForeColor = Color.Black;
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(3, 34);
            dtpDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpDate.Name = "dtpDate";
            dtpDate.ShadowDecoration.CustomizableEdges = customizableEdges2;
            dtpDate.Size = new Size(147, 38);
            dtpDate.TabIndex = 2;
            dtpDate.TextAlign = HorizontalAlignment.Center;
            dtpDate.Value = new DateTime(2024, 3, 6, 16, 47, 10, 859);
            dtpDate.ValueChanged += dtpDate_ValueChanged;
            // 
            // timerRefresh
            // 
            timerRefresh.Interval = 600000;
            timerRefresh.Tick += timerRefresh_Tick;
            // 
            // pnlbHeader
            // 
            pnlbHeader.BackColor = Color.White;
            pnlbHeader.Controls.Add(pictureBox1);
            pnlbHeader.Controls.Add(lbHeader);
            pnlbHeader.Controls.Add(dtpDate);
            pnlbHeader.Dock = DockStyle.Top;
            pnlbHeader.Location = new Point(0, 0);
            pnlbHeader.Name = "pnlbHeader";
            pnlbHeader.Size = new Size(1393, 75);
            pnlbHeader.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1313, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(80, 75);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // lbHeader
            // 
            lbHeader.AutoSize = true;
            lbHeader.Font = new Font("Bahnschrift", 24F, FontStyle.Regular, GraphicsUnit.Point);
            lbHeader.Location = new Point(502, 21);
            lbHeader.Name = "lbHeader";
            lbHeader.Size = new Size(402, 39);
            lbHeader.TabIndex = 3;
            lbHeader.Text = "Sewing Productivity Report";
            // 
            // gvDis2
            // 
            gvDis2.AllowUserToAddRows = false;
            gvDis2.AllowUserToDeleteRows = false;
            gvDis2.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            gvDis2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            gvDis2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            gvDis2.ColumnHeadersHeight = 60;
            gvDis2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Bahnschrift", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.Orchid;
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            gvDis2.DefaultCellStyle = dataGridViewCellStyle3;
            gvDis2.Dock = DockStyle.Fill;
            gvDis2.GridColor = Color.FromArgb(231, 229, 255);
            gvDis2.Location = new Point(0, 145);
            gvDis2.Name = "gvDis2";
            gvDis2.ReadOnly = true;
            gvDis2.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.White;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            gvDis2.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            gvDis2.RowHeadersVisible = false;
            gvDis2.RowHeadersWidth = 15;
            gvDis2.RowTemplate.Height = 25;
            gvDis2.SelectionMode = DataGridViewSelectionMode.CellSelect;
            gvDis2.Size = new Size(1393, 545);
            gvDis2.TabIndex = 4;
            gvDis2.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            gvDis2.ThemeStyle.AlternatingRowsStyle.Font = null;
            gvDis2.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            gvDis2.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            gvDis2.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            gvDis2.ThemeStyle.BackColor = Color.White;
            gvDis2.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            gvDis2.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            gvDis2.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            gvDis2.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            gvDis2.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            gvDis2.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            gvDis2.ThemeStyle.HeaderStyle.Height = 60;
            gvDis2.ThemeStyle.ReadOnly = true;
            gvDis2.ThemeStyle.RowsStyle.BackColor = Color.White;
            gvDis2.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gvDis2.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            gvDis2.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            gvDis2.ThemeStyle.RowsStyle.Height = 25;
            gvDis2.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            gvDis2.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            gvDis2.CellClick += gvDis2_CellClick;
            gvDis2.CellPainting += gvDis2_CellPainting;
            // 
            // TimerRefreshFirst
            // 
            TimerRefreshFirst.Tick += TimerRefreshFirst_Tick;
            // 
            // toolStrip2
            // 
            toolStrip2.ImageScalingSize = new Size(24, 24);
            toolStrip2.Items.AddRange(new ToolStripItem[] { toolStripLabel10, tbFontSize, btSaveFontSize });
            toolStrip2.Location = new Point(0, 114);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(1393, 31);
            toolStrip2.TabIndex = 5;
            toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel10
            // 
            toolStripLabel10.Font = new Font("Bahnschrift", 9F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel10.Name = "toolStripLabel10";
            toolStripLabel10.Size = new Size(54, 28);
            toolStripLabel10.Text = "FontSize";
            // 
            // tbFontSize
            // 
            tbFontSize.BackColor = SystemColors.ActiveCaption;
            tbFontSize.Font = new Font("Bahnschrift", 9F, FontStyle.Regular, GraphicsUnit.Point);
            tbFontSize.Name = "tbFontSize";
            tbFontSize.Size = new Size(40, 31);
            tbFontSize.KeyPress += tbFontSize_KeyPress;
            // 
            // btSaveFontSize
            // 
            btSaveFontSize.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btSaveFontSize.Image = (Image)resources.GetObject("btSaveFontSize.Image");
            btSaveFontSize.ImageTransparentColor = Color.Magenta;
            btSaveFontSize.Name = "btSaveFontSize";
            btSaveFontSize.Size = new Size(28, 28);
            btSaveFontSize.Text = "toolStripButton1";
            btSaveFontSize.Click += btSaveFontSize_Click;
            // 
            // ReportSewingDaily
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1393, 690);
            Controls.Add(gvDis2);
            Controls.Add(toolStrip2);
            Controls.Add(toolStrip1);
            Controls.Add(pnlbHeader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ReportSewingDaily";
            Text = "ReportSewingDaily";
            Load += ReportSewingDaily_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            pnlbHeader.ResumeLayout(false);
            pnlbHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvDis2).EndInit();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton btDataReport;
        private ToolStripButton btLoad;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDate;
        private System.Windows.Forms.Timer timerRefresh;
        private ToolStripButton btExcel;
        private Panel pnlbHeader;
        private ToolStripLabel toolStripLabel2;
        private ToolStripComboBox cbbBuilding;
        private Guna.UI2.WinForms.Guna2DataGridView gvDis2;
        private System.Windows.Forms.Timer TimerRefreshFirst;
        private Guna.UI2.WinForms.Guna2ComboBox cbbReportMode1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripComboBox cbbReportMode;
        private ToolStripLabel lbMinute;
        private ToolStripLabel toolStripLabel5;
        private ToolStripSeparator toolStripLabel6;
        private ToolStripLabel toolStripLabel7;
        private ToolStripLabel toolStripLabel8;
        private ToolStripLabel lbTime;
        private ToolStripLabel toolStripLabel3;
        private ToolStripButton btAdjustOutput;
        private ToolStripButton btInc;
        private Label lbHeader;
        private PictureBox pictureBox1;
        private ToolStripLabel toolStripLabel4;
        private ToolStripComboBox cbbShow;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStrip toolStrip2;
        private ToolStripLabel toolStripLabel10;
        private ToolStripTextBox tbFontSize;
        private ToolStripButton btSaveFontSize;
    }
}