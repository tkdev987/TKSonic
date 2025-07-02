namespace PTS_For_Cut._3Spreading.Report
{
    partial class Recut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Recut));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            panel1 = new Panel();
            toolStrip1 = new ToolStrip();
            toolStripLabel3 = new ToolStripLabel();
            cbbDep = new ToolStripComboBox();
            toolStripLabel2 = new ToolStripLabel();
            cbbStatus = new ToolStripComboBox();
            toolStripLabel1 = new ToolStripLabel();
            tbSearch = new ToolStripTextBox();
            btSearch = new ToolStripButton();
            btExcel = new ToolStripButton();
            panel3 = new Panel();
            cbUsedate = new CheckBox();
            dtpEnd = new Guna.UI2.WinForms.Guna2DateTimePicker();
            panel2 = new Panel();
            dtpStart = new Guna.UI2.WinForms.Guna2DateTimePicker();
            pnHeader = new Panel();
            lbHeader = new Label();
            panel4 = new Panel();
            cbbGroupby = new ComboBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            lbtt = new Label();
            label1 = new Label();
            gvDis = new DataGridView();
            appData1 = new _Main.AppData();
            panel1.SuspendLayout();
            toolStrip1.SuspendLayout();
            panel3.SuspendLayout();
            pnHeader.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvDis).BeginInit();
            ((System.ComponentModel.ISupportInitialize)appData1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(toolStrip1);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(pnHeader);
            panel1.Controls.Add(panel4);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1286, 113);
            panel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel3, cbbDep, toolStripLabel2, cbbStatus, toolStripLabel1, tbSearch, btSearch, btExcel });
            toolStrip1.Location = new Point(393, 47);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(893, 39);
            toolStrip1.TabIndex = 3;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel3
            // 
            toolStripLabel3.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel3.Name = "toolStripLabel3";
            toolStripLabel3.Size = new Size(96, 36);
            toolStripLabel3.Text = "Department";
            // 
            // cbbDep
            // 
            cbbDep.BackColor = Color.FromArgb(192, 192, 255);
            cbbDep.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbDep.Name = "cbbDep";
            cbbDep.Size = new Size(160, 39);
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(55, 36);
            toolStripLabel2.Text = "Status";
            // 
            // cbbStatus
            // 
            cbbStatus.BackColor = Color.FromArgb(192, 192, 255);
            cbbStatus.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbStatus.Items.AddRange(new object[] { "Pending (รอ)", "Done (เสร็จ)", "", "", "All (เสร็จ)" });
            cbbStatus.Name = "cbbStatus";
            cbbStatus.Size = new Size(121, 39);
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(29, 36);
            toolStripLabel1.Text = "SO";
            // 
            // tbSearch
            // 
            tbSearch.BackColor = Color.FromArgb(192, 192, 255);
            tbSearch.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbSearch.Name = "tbSearch";
            tbSearch.Size = new Size(200, 39);
            // 
            // btSearch
            // 
            btSearch.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btSearch.Image = (Image)resources.GetObject("btSearch.Image");
            btSearch.ImageTransparentColor = Color.Magenta;
            btSearch.Name = "btSearch";
            btSearch.Size = new Size(36, 36);
            btSearch.Text = "toolStripButton1";
            btSearch.Click += btSearch_Click;
            // 
            // btExcel
            // 
            btExcel.Alignment = ToolStripItemAlignment.Right;
            btExcel.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btExcel.Image = (Image)resources.GetObject("btExcel.Image");
            btExcel.ImageTransparentColor = Color.Magenta;
            btExcel.Name = "btExcel";
            btExcel.Size = new Size(36, 36);
            btExcel.Text = "toolStripButton1";
            // 
            // panel3
            // 
            panel3.Controls.Add(cbUsedate);
            panel3.Controls.Add(dtpEnd);
            panel3.Controls.Add(panel2);
            panel3.Controls.Add(dtpStart);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 47);
            panel3.Name = "panel3";
            panel3.Size = new Size(393, 40);
            panel3.TabIndex = 2;
            // 
            // cbUsedate
            // 
            cbUsedate.AutoSize = true;
            cbUsedate.Dock = DockStyle.Right;
            cbUsedate.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbUsedate.Location = new Point(292, 0);
            cbUsedate.Name = "cbUsedate";
            cbUsedate.Padding = new Padding(10, 0, 0, 0);
            cbUsedate.Size = new Size(101, 40);
            cbUsedate.TabIndex = 3;
            cbUsedate.Text = "Use date";
            cbUsedate.UseVisualStyleBackColor = true;
            cbUsedate.CheckedChanged += cbUsedate_CheckedChanged;
            // 
            // dtpEnd
            // 
            dtpEnd.Checked = true;
            dtpEnd.CustomizableEdges = customizableEdges5;
            dtpEnd.Dock = DockStyle.Left;
            dtpEnd.FillColor = Color.FromArgb(192, 192, 255);
            dtpEnd.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dtpEnd.Format = DateTimePickerFormat.Short;
            dtpEnd.Location = new Point(146, 0);
            dtpEnd.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpEnd.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.ShadowDecoration.CustomizableEdges = customizableEdges6;
            dtpEnd.Size = new Size(132, 40);
            dtpEnd.TabIndex = 1;
            dtpEnd.Value = new DateTime(2025, 6, 24, 17, 14, 45, 219);
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(136, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(10, 40);
            panel2.TabIndex = 2;
            // 
            // dtpStart
            // 
            dtpStart.Checked = true;
            dtpStart.CustomizableEdges = customizableEdges7;
            dtpStart.Dock = DockStyle.Left;
            dtpStart.FillColor = Color.FromArgb(192, 192, 255);
            dtpStart.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dtpStart.Format = DateTimePickerFormat.Short;
            dtpStart.Location = new Point(0, 0);
            dtpStart.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpStart.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpStart.Name = "dtpStart";
            dtpStart.ShadowDecoration.CustomizableEdges = customizableEdges8;
            dtpStart.Size = new Size(136, 40);
            dtpStart.TabIndex = 0;
            dtpStart.Value = new DateTime(2025, 6, 24, 17, 14, 45, 219);
            // 
            // pnHeader
            // 
            pnHeader.Controls.Add(lbHeader);
            pnHeader.Dock = DockStyle.Top;
            pnHeader.Location = new Point(0, 0);
            pnHeader.Name = "pnHeader";
            pnHeader.Size = new Size(1286, 47);
            pnHeader.TabIndex = 4;
            // 
            // lbHeader
            // 
            lbHeader.AutoSize = true;
            lbHeader.Font = new Font("Bahnschrift SemiBold", 24F, FontStyle.Bold, GraphicsUnit.Point);
            lbHeader.Location = new Point(471, 0);
            lbHeader.Name = "lbHeader";
            lbHeader.Size = new Size(474, 39);
            lbHeader.TabIndex = 0;
            lbHeader.Text = "Report of Defective Fabric Parts";
            // 
            // panel4
            // 
            panel4.Controls.Add(cbbGroupby);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(lbtt);
            panel4.Controls.Add(label1);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(0, 87);
            panel4.Name = "panel4";
            panel4.Size = new Size(1286, 26);
            panel4.TabIndex = 2;
            // 
            // cbbGroupby
            // 
            cbbGroupby.Dock = DockStyle.Left;
            cbbGroupby.FormattingEnabled = true;
            cbbGroupby.Items.AddRange(new object[] { "SO,Colors,Size", "Detail" });
            cbbGroupby.Location = new Point(188, 0);
            cbbGroupby.Name = "cbbGroupby";
            cbbGroupby.Size = new Size(155, 23);
            cbbGroupby.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Left;
            label5.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(113, 0);
            label5.Name = "label5";
            label5.Size = new Size(75, 19);
            label5.TabIndex = 5;
            label5.Text = "Group By";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Left;
            label4.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Padding = new Padding(0, 0, 20, 0);
            label4.Size = new Size(113, 19);
            label4.TabIndex = 3;
            label4.Text = "Recut Table";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Right;
            label3.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(1138, 0);
            label3.Name = "label3";
            label3.Size = new Size(56, 19);
            label3.TabIndex = 2;
            label3.Text = "Total : ";
            // 
            // lbtt
            // 
            lbtt.AutoSize = true;
            lbtt.Dock = DockStyle.Right;
            lbtt.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbtt.Location = new Point(1194, 0);
            lbtt.Name = "lbtt";
            lbtt.Size = new Size(49, 19);
            lbtt.TabIndex = 1;
            lbtt.Text = "xxxxx";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Right;
            label1.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(1243, 0);
            label1.Name = "label1";
            label1.Size = new Size(43, 19);
            label1.TabIndex = 0;
            label1.Text = "PCS.";
            // 
            // gvDis
            // 
            gvDis.AllowUserToAddRows = false;
            gvDis.AllowUserToDeleteRows = false;
            gvDis.BackgroundColor = Color.White;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            gvDis.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            gvDis.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            gvDis.DefaultCellStyle = dataGridViewCellStyle4;
            gvDis.Dock = DockStyle.Fill;
            gvDis.Location = new Point(0, 113);
            gvDis.Name = "gvDis";
            gvDis.ReadOnly = true;
            gvDis.RowHeadersWidth = 15;
            gvDis.RowTemplate.Height = 25;
            gvDis.Size = new Size(1286, 396);
            gvDis.TabIndex = 1;
            // 
            // appData1
            // 
            appData1.DataSetName = "AppData";
            appData1.Namespace = "http://tempuri.org/AppData.xsd";
            appData1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Recut
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1286, 509);
            Controls.Add(gvDis);
            Controls.Add(panel1);
            Name = "Recut";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Recut";
            WindowState = FormWindowState.Maximized;
            Load += Recut_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            pnHeader.ResumeLayout(false);
            pnHeader.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gvDis).EndInit();
            ((System.ComponentModel.ISupportInitialize)appData1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpStart;
        private DataGridView gvDis;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpEnd;
        private Panel panel2;
        private ToolStrip toolStrip1;
        private ToolStripTextBox tbSearch;
        private ToolStripButton btSearch;
        private Panel panel3;
        private ToolStripLabel toolStripLabel1;
        private CheckBox cbUsedate;
        private Panel pnHeader;
        private ToolStripLabel toolStripLabel2;
        private ToolStripComboBox cbbStatus;
        private ToolStripButton btExcel;
        private Label lbHeader;
        private Panel panel4;
        private Label label4;
        private Label label3;
        private Label lbtt;
        private Label label1;
        private ToolStripLabel toolStripLabel3;
        private ToolStripComboBox cbbDep;
        private ComboBox cbbGroupby;
        private Label label5;
        private _Main.AppData appData1;
    }
}