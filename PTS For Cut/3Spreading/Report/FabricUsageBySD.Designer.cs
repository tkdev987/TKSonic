namespace PTS_For_Cut._3Spreading.Report
{
    partial class FabricUsageBySD
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FabricUsageBySD));
            gvFBUsage = new Guna.UI2.WinForms.Guna2DataGridView();
            tbSOSearch = new TextBox();
            panel1 = new Panel();
            toolStrip2 = new ToolStrip();
            toolStripLabel2 = new ToolStripLabel();
            cbbSeparateBy2 = new ToolStripComboBox();
            btSearchSO = new ToolStripButton();
            btExcel = new ToolStripButton();
            panel2 = new Panel();
            pnDate = new Panel();
            dtpEnd1 = new DateTimePicker();
            label4 = new Label();
            dtpStart1 = new DateTimePicker();
            label3 = new Label();
            cbbSearchBy = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)gvFBUsage).BeginInit();
            panel1.SuspendLayout();
            toolStrip2.SuspendLayout();
            panel2.SuspendLayout();
            pnDate.SuspendLayout();
            SuspendLayout();
            // 
            // gvFBUsage
            // 
            gvFBUsage.AllowUserToAddRows = false;
            gvFBUsage.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            gvFBUsage.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            gvFBUsage.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            gvFBUsage.ColumnHeadersHeight = 40;
            gvFBUsage.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            gvFBUsage.DefaultCellStyle = dataGridViewCellStyle3;
            gvFBUsage.Dock = DockStyle.Fill;
            gvFBUsage.GridColor = Color.FromArgb(231, 229, 255);
            gvFBUsage.Location = new Point(0, 218);
            gvFBUsage.Name = "gvFBUsage";
            gvFBUsage.ReadOnly = true;
            gvFBUsage.RowHeadersVisible = false;
            gvFBUsage.RowHeadersWidth = 5;
            gvFBUsage.RowTemplate.Height = 25;
            gvFBUsage.Size = new Size(1456, 384);
            gvFBUsage.TabIndex = 0;
            gvFBUsage.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            gvFBUsage.ThemeStyle.AlternatingRowsStyle.Font = null;
            gvFBUsage.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            gvFBUsage.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            gvFBUsage.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            gvFBUsage.ThemeStyle.BackColor = Color.White;
            gvFBUsage.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            gvFBUsage.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            gvFBUsage.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            gvFBUsage.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            gvFBUsage.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            gvFBUsage.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            gvFBUsage.ThemeStyle.HeaderStyle.Height = 40;
            gvFBUsage.ThemeStyle.ReadOnly = true;
            gvFBUsage.ThemeStyle.RowsStyle.BackColor = Color.White;
            gvFBUsage.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gvFBUsage.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            gvFBUsage.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            gvFBUsage.ThemeStyle.RowsStyle.Height = 25;
            gvFBUsage.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            gvFBUsage.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // tbSOSearch
            // 
            tbSOSearch.CharacterCasing = CharacterCasing.Upper;
            tbSOSearch.Dock = DockStyle.Top;
            tbSOSearch.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbSOSearch.Location = new Point(0, 83);
            tbSOSearch.Multiline = true;
            tbSOSearch.Name = "tbSOSearch";
            tbSOSearch.Size = new Size(1456, 96);
            tbSOSearch.TabIndex = 2;
            tbSOSearch.KeyUp += tbSOSearch_KeyUp;
            // 
            // panel1
            // 
            panel1.Controls.Add(gvFBUsage);
            panel1.Controls.Add(toolStrip2);
            panel1.Controls.Add(tbSOSearch);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1456, 602);
            panel1.TabIndex = 3;
            // 
            // toolStrip2
            // 
            toolStrip2.ImageScalingSize = new Size(32, 32);
            toolStrip2.Items.AddRange(new ToolStripItem[] { toolStripLabel2, cbbSeparateBy2, btSearchSO, btExcel });
            toolStrip2.Location = new Point(0, 179);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(1456, 39);
            toolStrip2.TabIndex = 4;
            toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(98, 36);
            toolStripLabel2.Text = "Separate By";
            // 
            // cbbSeparateBy2
            // 
            cbbSeparateBy2.BackColor = SystemColors.ActiveCaption;
            cbbSeparateBy2.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbSeparateBy2.Items.AddRange(new object[] { "PO", "Spreading List", "By Roll" });
            cbbSeparateBy2.Name = "cbbSeparateBy2";
            cbbSeparateBy2.Size = new Size(180, 39);
            // 
            // btSearchSO
            // 
            btSearchSO.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btSearchSO.Image = (Image)resources.GetObject("btSearchSO.Image");
            btSearchSO.ImageTransparentColor = Color.Magenta;
            btSearchSO.Margin = new Padding(20, 1, 20, 2);
            btSearchSO.Name = "btSearchSO";
            btSearchSO.Size = new Size(36, 36);
            btSearchSO.Text = "Search";
            btSearchSO.Click += tbSearchSO_Click;
            // 
            // btExcel
            // 
            btExcel.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btExcel.Image = (Image)resources.GetObject("btExcel.Image");
            btExcel.ImageTransparentColor = Color.Magenta;
            btExcel.Name = "btExcel";
            btExcel.Size = new Size(36, 36);
            btExcel.Text = "Excel";
            btExcel.Click += btExcel_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(pnDate);
            panel2.Controls.Add(cbbSearchBy);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 43);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(0, 10, 0, 0);
            panel2.Size = new Size(1456, 40);
            panel2.TabIndex = 5;
            // 
            // pnDate
            // 
            pnDate.Controls.Add(dtpEnd1);
            pnDate.Controls.Add(label4);
            pnDate.Controls.Add(dtpStart1);
            pnDate.Controls.Add(label3);
            pnDate.Dock = DockStyle.Left;
            pnDate.Location = new Point(263, 10);
            pnDate.Name = "pnDate";
            pnDate.Size = new Size(376, 30);
            pnDate.TabIndex = 0;
            // 
            // dtpEnd1
            // 
            dtpEnd1.Dock = DockStyle.Left;
            dtpEnd1.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dtpEnd1.Format = DateTimePickerFormat.Short;
            dtpEnd1.Location = new Point(217, 0);
            dtpEnd1.Name = "dtpEnd1";
            dtpEnd1.Size = new Size(131, 27);
            dtpEnd1.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Left;
            label4.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(189, 0);
            label4.Name = "label4";
            label4.Padding = new Padding(5, 0, 0, 0);
            label4.Size = new Size(28, 19);
            label4.TabIndex = 4;
            label4.Text = "to";
            // 
            // dtpStart1
            // 
            dtpStart1.Dock = DockStyle.Left;
            dtpStart1.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dtpStart1.Format = DateTimePickerFormat.Short;
            dtpStart1.Location = new Point(48, 0);
            dtpStart1.Name = "dtpStart1";
            dtpStart1.Size = new Size(141, 27);
            dtpStart1.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Left;
            label3.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Padding = new Padding(5, 0, 0, 0);
            label3.Size = new Size(48, 19);
            label3.TabIndex = 2;
            label3.Text = "Date";
            // 
            // cbbSearchBy
            // 
            cbbSearchBy.Dock = DockStyle.Left;
            cbbSearchBy.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbSearchBy.FormattingEnabled = true;
            cbbSearchBy.Items.AddRange(new object[] { "SO", "Date" });
            cbbSearchBy.Location = new Point(88, 10);
            cbbSearchBy.Name = "cbbSearchBy";
            cbbSearchBy.Size = new Size(175, 27);
            cbbSearchBy.TabIndex = 2;
            cbbSearchBy.SelectedIndexChanged += cbbSearchBy_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Left;
            label2.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(0, 10);
            label2.Name = "label2";
            label2.Padding = new Padding(5, 0, 0, 0);
            label2.Size = new Size(88, 19);
            label2.TabIndex = 1;
            label2.Text = "Search By";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Bahnschrift", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(500, 10, 0, 0);
            label1.Size = new Size(673, 43);
            label1.TabIndex = 3;
            label1.Text = "Fabric Usage";
            // 
            // FabricUsageBySD
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1456, 602);
            Controls.Add(panel1);
            Name = "FabricUsageBySD";
            Text = "FabricUsageBySD";
            WindowState = FormWindowState.Maximized;
            Load += FabricUsageBySD_Load;
            ((System.ComponentModel.ISupportInitialize)gvFBUsage).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            pnDate.ResumeLayout(false);
            pnDate.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView gvFBUsage;
        private TextBox tbSOSearch;
        private Panel panel1;
        private ToolStrip toolStrip2;
        private ToolStripButton btSearchSO;
        private Label label1;
        private ToolStripButton btExcel;
        private ToolStripLabel toolStripLabel2;
        private Panel panel2;
        private ComboBox cbbSearchBy;
        private Label label2;
        private Panel pnDate;
        private DateTimePicker dtpEnd1;
        private Label label4;
        private DateTimePicker dtpStart1;
        private Label label3;
        private ToolStripComboBox cbbSeparateBy2;
    }
}