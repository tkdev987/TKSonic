namespace PTS_For_Cut._7Packing
{
    partial class PackingDailyOutput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PackingDailyOutput));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            pnlbHeader = new Panel();
            pictureBox1 = new PictureBox();
            lbHeader = new Label();
            dtpDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            toolStrip1 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            cbbReportMode = new ToolStripComboBox();
            btReload = new ToolStripButton();
            btSetUpTarget = new ToolStripButton();
            lbMinute = new ToolStripLabel();
            toolStripLabel5 = new ToolStripLabel();
            toolStripButton1 = new ToolStripSeparator();
            lbTime = new ToolStripLabel();
            toolStripLabel3 = new ToolStripLabel();
            toolStripLabel2 = new ToolStripLabel();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripLabel4 = new ToolStripLabel();
            cbbShow = new ToolStripComboBox();
            timerRefresh = new System.Windows.Forms.Timer(components);
            gvDis2 = new Guna.UI2.WinForms.Guna2DataGridView();
            TimerRefreshFirst = new System.Windows.Forms.Timer(components);
            toolStrip2 = new ToolStrip();
            toolStripLabel6 = new ToolStripLabel();
            tbFontSize = new ToolStripTextBox();
            btSaveFontSize = new ToolStripButton();
            pnlbHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvDis2).BeginInit();
            toolStrip2.SuspendLayout();
            SuspendLayout();
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
            pnlbHeader.Padding = new Padding(0, 5, 0, 0);
            pnlbHeader.Size = new Size(1399, 102);
            pnlbHeader.TabIndex = 2;
            pnlbHeader.Paint += panel1_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1294, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(105, 97);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // lbHeader
            // 
            lbHeader.AutoSize = true;
            lbHeader.Font = new Font("Bahnschrift", 24F, FontStyle.Regular, GraphicsUnit.Point);
            lbHeader.Location = new Point(554, 29);
            lbHeader.Name = "lbHeader";
            lbHeader.Size = new Size(410, 39);
            lbHeader.TabIndex = 0;
            lbHeader.Text = "Packing Productivity Report";
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
            dtpDate.Location = new Point(0, 56);
            dtpDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpDate.Name = "dtpDate";
            dtpDate.ShadowDecoration.CustomizableEdges = customizableEdges2;
            dtpDate.Size = new Size(171, 43);
            dtpDate.TabIndex = 3;
            dtpDate.TextAlign = HorizontalAlignment.Center;
            dtpDate.Value = new DateTime(2024, 3, 6, 16, 47, 10, 859);
            dtpDate.ValueChanged += dtpDate_ValueChanged_1;
            // 
            // toolStrip1
            // 
            toolStrip1.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1, cbbReportMode, btReload, btSetUpTarget, lbMinute, toolStripLabel5, toolStripButton1, lbTime, toolStripLabel3, toolStripLabel2, toolStripSeparator1, toolStripLabel4, cbbShow });
            toolStrip1.Location = new Point(0, 102);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1399, 39);
            toolStrip1.TabIndex = 4;
            toolStrip1.Text = "Last Update >>";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(80, 36);
            toolStripLabel1.Text = "Report By";
            // 
            // cbbReportMode
            // 
            cbbReportMode.BackColor = SystemColors.InactiveCaption;
            cbbReportMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbReportMode.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbReportMode.Items.AddRange(new object[] { "Style", "SO" });
            cbbReportMode.Name = "cbbReportMode";
            cbbReportMode.Size = new Size(150, 39);
            cbbReportMode.SelectedIndexChanged += cbbReportMode_SelectedIndexChanged;
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
            toolStripLabel5.Size = new Size(34, 36);
            toolStripLabel5.Text = "Min";
            // 
            // toolStripButton1
            // 
            toolStripButton1.Alignment = ToolStripItemAlignment.Right;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(6, 39);
            // 
            // lbTime
            // 
            lbTime.Alignment = ToolStripItemAlignment.Right;
            lbTime.Name = "lbTime";
            lbTime.Size = new Size(83, 36);
            lbTime.Text = "HH:mm:ss";
            // 
            // toolStripLabel3
            // 
            toolStripLabel3.Alignment = ToolStripItemAlignment.Right;
            toolStripLabel3.Name = "toolStripLabel3";
            toolStripLabel3.Size = new Size(52, 36);
            toolStripLabel3.Text = "Time :";
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Alignment = ToolStripItemAlignment.Right;
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(113, 36);
            toolStripLabel2.Text = "Last Update >>";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 39);
            // 
            // toolStripLabel4
            // 
            toolStripLabel4.Name = "toolStripLabel4";
            toolStripLabel4.Size = new Size(43, 36);
            toolStripLabel4.Text = "View";
            // 
            // cbbShow
            // 
            cbbShow.BackColor = SystemColors.InactiveCaption;
            cbbShow.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbShow.Items.AddRange(new object[] { "Show All", "Only Output" });
            cbbShow.Name = "cbbShow";
            cbbShow.Size = new Size(150, 39);
            cbbShow.SelectedIndexChanged += cbbShow_SelectedIndexChanged;
            cbbShow.Click += cbbShow_Click;
            // 
            // timerRefresh
            // 
            timerRefresh.Tick += timerRefresh_Tick;
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
            dataGridViewCellStyle2.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            gvDis2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            gvDis2.ColumnHeadersHeight = 80;
            gvDis2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.Orchid;
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            gvDis2.DefaultCellStyle = dataGridViewCellStyle3;
            gvDis2.Dock = DockStyle.Fill;
            gvDis2.GridColor = Color.FromArgb(231, 229, 255);
            gvDis2.Location = new Point(0, 176);
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
            gvDis2.RowTemplate.Height = 60;
            gvDis2.RowTemplate.Resizable = DataGridViewTriState.True;
            gvDis2.SelectionMode = DataGridViewSelectionMode.CellSelect;
            gvDis2.Size = new Size(1399, 544);
            gvDis2.TabIndex = 5;
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
            gvDis2.ThemeStyle.RowsStyle.Height = 60;
            gvDis2.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            gvDis2.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            gvDis2.CellPainting += gvDis2_CellPainting;
            // 
            // TimerRefreshFirst
            // 
            TimerRefreshFirst.Interval = 5;
            TimerRefreshFirst.Tick += TimerRefreshFirst_Tick;
            // 
            // toolStrip2
            // 
            toolStrip2.ImageScalingSize = new Size(28, 28);
            toolStrip2.Items.AddRange(new ToolStripItem[] { toolStripLabel6, tbFontSize, btSaveFontSize });
            toolStrip2.Location = new Point(0, 141);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(1399, 35);
            toolStrip2.TabIndex = 6;
            toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel6
            // 
            toolStripLabel6.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel6.Name = "toolStripLabel6";
            toolStripLabel6.Size = new Size(72, 32);
            toolStripLabel6.Text = "FontSize";
            // 
            // tbFontSize
            // 
            tbFontSize.BackColor = SystemColors.ActiveCaption;
            tbFontSize.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbFontSize.Name = "tbFontSize";
            tbFontSize.Size = new Size(40, 35);
            // 
            // btSaveFontSize
            // 
            btSaveFontSize.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btSaveFontSize.Image = (Image)resources.GetObject("btSaveFontSize.Image");
            btSaveFontSize.ImageTransparentColor = Color.Magenta;
            btSaveFontSize.Name = "btSaveFontSize";
            btSaveFontSize.Size = new Size(32, 32);
            btSaveFontSize.Text = "toolStripButton2";
            btSaveFontSize.Click += btSaveFontSize_Click;
            // 
            // PackingDailyOutput
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1399, 720);
            Controls.Add(gvDis2);
            Controls.Add(toolStrip2);
            Controls.Add(toolStrip1);
            Controls.Add(pnlbHeader);
            Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PackingDailyOutput";
            Text = "PackingDailyOutput";
            Load += PackingDailyOutput_Load;
            pnlbHeader.ResumeLayout(false);
            pnlbHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gvDis2).EndInit();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel pnlbHeader;
        private System.Windows.Forms.Timer timerRefresh;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDate;
        private Label lbHeader;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripComboBox cbbReportMode;
        private ToolStripButton btReload;
        private Guna.UI2.WinForms.Guna2DataGridView gvDis2;
        private ToolStripButton btSetUpTarget;
        private ToolStripLabel toolStripLabel2;
        private ToolStripLabel lbMinute;
        private ToolStripLabel toolStripLabel3;
        private ToolStripLabel toolStripLabel5;
        private ToolStripSeparator toolStripButton1;
        private ToolStripLabel lbTime;
        private ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Timer TimerRefreshFirst;
        private ToolStripComboBox cbbShow;
        private PictureBox pictureBox1;
        private ToolStripLabel toolStripLabel4;
        private ToolStrip toolStrip2;
        private ToolStripLabel toolStripLabel6;
        private ToolStripTextBox tbFontSize;
        private ToolStripButton btSaveFontSize;
    }
}