namespace PTS_For_Cut._3Spreading.DailyOutput
{
    partial class ReportCuttingDaily
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportCuttingDaily));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            lbHeader = new Label();
            timerRefresh = new System.Windows.Forms.Timer(components);
            dtpDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripLabel2 = new ToolStripLabel();
            lbTime = new ToolStripLabel();
            toolStripButton1 = new ToolStripSeparator();
            lbMinute = new ToolStripLabel();
            btSetUpTarget = new ToolStripButton();
            btReload = new ToolStripButton();
            cbbReportMode = new ToolStripComboBox();
            toolStripLabel1 = new ToolStripLabel();
            toolStrip1 = new ToolStrip();
            toolStripLabel5 = new ToolStripLabel();
            toolStripLabel3 = new ToolStripLabel();
            toolStripLabel4 = new ToolStripLabel();
            cbbBuilding = new ToolStripComboBox();
            toolStripButton2 = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripLabel6 = new ToolStripLabel();
            cbbShowData = new ToolStripComboBox();
            toolStripLabel7 = new ToolStripLabel();
            cbbWorkshift = new ToolStripComboBox();
            pnlbHeader = new Panel();
            pictureBox1 = new PictureBox();
            TimerRefreshFirst = new System.Windows.Forms.Timer(components);
            gvDis2 = new Guna.UI2.WinForms.Guna2DataGridView();
            toolStrip2 = new ToolStrip();
            toolStripLabel8 = new ToolStripLabel();
            tbFontSize = new ToolStripTextBox();
            btSaveFontSize = new ToolStripButton();
            toolStrip1.SuspendLayout();
            pnlbHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvDis2).BeginInit();
            toolStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // lbHeader
            // 
            lbHeader.AutoSize = true;
            lbHeader.Font = new Font("Bahnschrift", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbHeader.Location = new Point(517, 23);
            lbHeader.Name = "lbHeader";
            lbHeader.Size = new Size(465, 45);
            lbHeader.TabIndex = 0;
            lbHeader.Text = "Cutting Productivity Report";
            // 
            // timerRefresh
            // 
            timerRefresh.Tick += timerRefresh_Tick;
            // 
            // dtpDate
            // 
            dtpDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            dtpDate.BorderColor = Color.White;
            dtpDate.BorderRadius = 4;
            dtpDate.BorderThickness = 1;
            dtpDate.Checked = true;
            dtpDate.CustomizableEdges = customizableEdges1;
            dtpDate.FillColor = SystemColors.Control;
            dtpDate.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDate.ForeColor = Color.Black;
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(3, 52);
            dtpDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpDate.Name = "dtpDate";
            dtpDate.ShadowDecoration.CustomizableEdges = customizableEdges2;
            dtpDate.Size = new Size(171, 38);
            dtpDate.TabIndex = 3;
            dtpDate.TextAlign = HorizontalAlignment.Center;
            dtpDate.Value = new DateTime(2024, 3, 6, 16, 47, 10, 859);
            dtpDate.ValueChanged += dtpDate_ValueChanged;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 39);
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Alignment = ToolStripItemAlignment.Right;
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(113, 36);
            toolStripLabel2.Text = "Last Update >>";
            // 
            // lbTime
            // 
            lbTime.Alignment = ToolStripItemAlignment.Right;
            lbTime.Name = "lbTime";
            lbTime.Size = new Size(83, 36);
            lbTime.Text = "HH:mm:ss";
            // 
            // toolStripButton1
            // 
            toolStripButton1.Alignment = ToolStripItemAlignment.Right;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(6, 39);
            // 
            // lbMinute
            // 
            lbMinute.Alignment = ToolStripItemAlignment.Right;
            lbMinute.Name = "lbMinute";
            lbMinute.Size = new Size(33, 36);
            lbMinute.Text = "xxx";
            // 
            // btSetUpTarget
            // 
            btSetUpTarget.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btSetUpTarget.Image = (Image)resources.GetObject("btSetUpTarget.Image");
            btSetUpTarget.ImageTransparentColor = Color.Magenta;
            btSetUpTarget.Margin = new Padding(10, 1, 0, 2);
            btSetUpTarget.Name = "btSetUpTarget";
            btSetUpTarget.Size = new Size(142, 36);
            btSetUpTarget.Text = "Set Up Target";
            btSetUpTarget.Click += btSetUpTarget_Click;
            // 
            // btReload
            // 
            btReload.Image = (Image)resources.GetObject("btReload.Image");
            btReload.ImageTransparentColor = Color.Magenta;
            btReload.Name = "btReload";
            btReload.Size = new Size(102, 36);
            btReload.Text = "Refresh";
            btReload.Click += btReload_Click;
            // 
            // cbbReportMode
            // 
            cbbReportMode.BackColor = SystemColors.ActiveCaption;
            cbbReportMode.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbReportMode.Items.AddRange(new object[] { "Style", "SO" });
            cbbReportMode.Name = "cbbReportMode";
            cbbReportMode.Size = new Size(150, 39);
            cbbReportMode.SelectedIndexChanged += cbbReportMode_SelectedIndexChanged;
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(80, 36);
            toolStripLabel1.Text = "Report By";
            // 
            // toolStrip1
            // 
            toolStrip1.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1, cbbReportMode, lbMinute, toolStripLabel5, toolStripButton1, lbTime, toolStripLabel3, toolStripLabel4, cbbBuilding, btReload, toolStripLabel2, toolStripSeparator1, btSetUpTarget, toolStripButton2, toolStripSeparator2, toolStripLabel6, cbbShowData, toolStripLabel7, cbbWorkshift });
            toolStrip1.Location = new Point(0, 93);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1543, 39);
            toolStrip1.TabIndex = 4;
            toolStrip1.Text = "Last Update >>";
            // 
            // toolStripLabel5
            // 
            toolStripLabel5.Alignment = ToolStripItemAlignment.Right;
            toolStripLabel5.Name = "toolStripLabel5";
            toolStripLabel5.Size = new Size(34, 36);
            toolStripLabel5.Text = "Min";
            // 
            // toolStripLabel3
            // 
            toolStripLabel3.Alignment = ToolStripItemAlignment.Right;
            toolStripLabel3.Name = "toolStripLabel3";
            toolStripLabel3.Size = new Size(52, 36);
            toolStripLabel3.Text = "Time :";
            // 
            // toolStripLabel4
            // 
            toolStripLabel4.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel4.Name = "toolStripLabel4";
            toolStripLabel4.Size = new Size(68, 36);
            toolStripLabel4.Text = "Building";
            // 
            // cbbBuilding
            // 
            cbbBuilding.BackColor = SystemColors.ActiveCaption;
            cbbBuilding.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbBuilding.Items.AddRange(new object[] { "ALL", "TK1", "TK2" });
            cbbBuilding.Name = "cbbBuilding";
            cbbBuilding.Size = new Size(121, 39);
            cbbBuilding.TextChanged += cbbBuilding_TextChanged;
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(36, 36);
            toolStripButton2.Text = "Export to Excel";
            toolStripButton2.Click += toolStripButton2_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 39);
            // 
            // toolStripLabel6
            // 
            toolStripLabel6.Name = "toolStripLabel6";
            toolStripLabel6.Size = new Size(43, 36);
            toolStripLabel6.Text = "View";
            // 
            // cbbShowData
            // 
            cbbShowData.BackColor = SystemColors.ActiveCaption;
            cbbShowData.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbShowData.Items.AddRange(new object[] { "Show All", "Only Output" });
            cbbShowData.Name = "cbbShowData";
            cbbShowData.Size = new Size(121, 39);
            cbbShowData.SelectedIndexChanged += cbbShowData_SelectedIndexChanged;
            // 
            // toolStripLabel7
            // 
            toolStripLabel7.Name = "toolStripLabel7";
            toolStripLabel7.Size = new Size(83, 36);
            toolStripLabel7.Text = "Work Shift";
            // 
            // cbbWorkshift
            // 
            cbbWorkshift.BackColor = SystemColors.ActiveCaption;
            cbbWorkshift.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbWorkshift.Items.AddRange(new object[] { "Two Shifts", "Three Shifts" });
            cbbWorkshift.Name = "cbbWorkshift";
            cbbWorkshift.Size = new Size(140, 39);
            cbbWorkshift.SelectedIndexChanged += cbbWorkshift_SelectedIndexChanged;
            // 
            // pnlbHeader
            // 
            pnlbHeader.BackColor = Color.White;
            pnlbHeader.Controls.Add(pictureBox1);
            pnlbHeader.Controls.Add(dtpDate);
            pnlbHeader.Controls.Add(lbHeader);
            pnlbHeader.Dock = DockStyle.Top;
            pnlbHeader.Location = new Point(0, 0);
            pnlbHeader.Name = "pnlbHeader";
            pnlbHeader.Size = new Size(1543, 93);
            pnlbHeader.TabIndex = 7;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1442, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(101, 93);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // TimerRefreshFirst
            // 
            TimerRefreshFirst.Interval = 200;
            TimerRefreshFirst.Tick += TimerRefreshFirst_Tick;
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
            gvDis2.ColumnHeadersHeight = 80;
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
            gvDis2.Location = new Point(0, 171);
            gvDis2.Name = "gvDis2";
            gvDis2.ReadOnly = true;
            gvDis2.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.White;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            gvDis2.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            gvDis2.RowHeadersVisible = false;
            gvDis2.RowHeadersWidth = 15;
            gvDis2.RowTemplate.Height = 25;
            gvDis2.SelectionMode = DataGridViewSelectionMode.CellSelect;
            gvDis2.Size = new Size(1543, 590);
            gvDis2.TabIndex = 8;
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
            gvDis2.ThemeStyle.HeaderStyle.Height = 80;
            gvDis2.ThemeStyle.ReadOnly = true;
            gvDis2.ThemeStyle.RowsStyle.BackColor = Color.White;
            gvDis2.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gvDis2.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            gvDis2.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            gvDis2.ThemeStyle.RowsStyle.Height = 25;
            gvDis2.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            gvDis2.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // toolStrip2
            // 
            toolStrip2.ImageScalingSize = new Size(32, 32);
            toolStrip2.Items.AddRange(new ToolStripItem[] { toolStripLabel8, tbFontSize, btSaveFontSize });
            toolStrip2.Location = new Point(0, 132);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(1543, 39);
            toolStrip2.TabIndex = 9;
            toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel8
            // 
            toolStripLabel8.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel8.Name = "toolStripLabel8";
            toolStripLabel8.Size = new Size(72, 36);
            toolStripLabel8.Text = "FontSize";
            // 
            // tbFontSize
            // 
            tbFontSize.BackColor = SystemColors.ActiveCaption;
            tbFontSize.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbFontSize.Name = "tbFontSize";
            tbFontSize.Size = new Size(40, 39);
            tbFontSize.KeyPress += btFontsize_KeyPress;
            // 
            // btSaveFontSize
            // 
            btSaveFontSize.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btSaveFontSize.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btSaveFontSize.Image = (Image)resources.GetObject("btSaveFontSize.Image");
            btSaveFontSize.ImageTransparentColor = Color.Magenta;
            btSaveFontSize.Name = "btSaveFontSize";
            btSaveFontSize.Size = new Size(36, 36);
            btSaveFontSize.Text = "toolStripButton3";
            btSaveFontSize.Click += btSaveFontSize_Click;
            // 
            // ReportCuttingDaily
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1543, 761);
            Controls.Add(gvDis2);
            Controls.Add(toolStrip2);
            Controls.Add(toolStrip1);
            Controls.Add(pnlbHeader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ReportCuttingDaily";
            Text = "ReportCuttingDaily";
            Load += ReportCuttingDaily_Load;
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

        private Label lbHeader;
        private System.Windows.Forms.Timer timerRefresh;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDate;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel toolStripLabel2;
        private ToolStripLabel lbTime;
        private ToolStripSeparator toolStripButton1;
        private ToolStripLabel lbMinute;
        private ToolStripButton btSetUpTarget;
        private ToolStripButton btReload;
        private ToolStripComboBox cbbReportMode;
        private ToolStripLabel toolStripLabel1;
        private ToolStrip toolStrip1;
        private Panel pnlbHeader;
        private ToolStripLabel toolStripLabel5;
        private ToolStripLabel toolStripLabel3;
        private ToolStripLabel toolStripLabel4;
        private ToolStripComboBox cbbBuilding;
        private System.Windows.Forms.Timer TimerRefreshFirst;
        private ToolStripButton toolStripButton2;
        private ToolStripComboBox cbbShowData;
        private Guna.UI2.WinForms.Guna2DataGridView gvDis2;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripLabel toolStripLabel6;
        private PictureBox pictureBox1;
        private ToolStripLabel toolStripLabel7;
        private ToolStripComboBox cbbWorkshift;
        private ToolStrip toolStrip2;
        private ToolStripLabel toolStripLabel8;
        private ToolStripTextBox tbFontSize;
        private ToolStripButton btSaveFontSize;
    }
}