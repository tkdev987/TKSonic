namespace PTS_For_Cut._9Report
{
    partial class ReportCompareNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportCompareNew));
            gvDis = new DataGridView();
            toolStrip1 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            tbSO = new ToolStripTextBox();
            btSearchSO = new ToolStripButton();
            btExporttoExcel = new ToolStripButton();
            btDefectRecord = new ToolStripButton();
            btAddDefect = new ToolStripButton();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)gvDis).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // gvDis
            // 
            gvDis.AllowUserToAddRows = false;
            gvDis.AllowUserToDeleteRows = false;
            gvDis.BackgroundColor = Color.White;
            gvDis.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvDis.Dock = DockStyle.Fill;
            gvDis.Location = new Point(0, 106);
            gvDis.Name = "gvDis";
            gvDis.ReadOnly = true;
            gvDis.RowHeadersWidth = 15;
            gvDis.RowTemplate.Height = 25;
            gvDis.Size = new Size(1362, 530);
            gvDis.TabIndex = 0;
            gvDis.CellClick += gvDis_CellClick;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1, tbSO, btSearchSO, btExporttoExcel, btDefectRecord, btAddDefect });
            toolStrip1.Location = new Point(0, 67);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1362, 39);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(37, 36);
            toolStripLabel1.Text = "SO :";
            // 
            // tbSO
            // 
            tbSO.BackColor = SystemColors.ActiveCaption;
            tbSO.CharacterCasing = CharacterCasing.Upper;
            tbSO.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbSO.Name = "tbSO";
            tbSO.Size = new Size(250, 39);
            tbSO.KeyUp += tbSO_KeyUp;
            // 
            // btSearchSO
            // 
            btSearchSO.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btSearchSO.Image = (Image)resources.GetObject("btSearchSO.Image");
            btSearchSO.ImageTransparentColor = Color.Magenta;
            btSearchSO.Name = "btSearchSO";
            btSearchSO.Size = new Size(36, 36);
            btSearchSO.Text = "Search";
            btSearchSO.Click += btSearchSO_Click;
            // 
            // btExporttoExcel
            // 
            btExporttoExcel.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btExporttoExcel.Image = (Image)resources.GetObject("btExporttoExcel.Image");
            btExporttoExcel.ImageTransparentColor = Color.Magenta;
            btExporttoExcel.Margin = new Padding(20, 1, 0, 2);
            btExporttoExcel.Name = "btExporttoExcel";
            btExporttoExcel.Size = new Size(155, 36);
            btExporttoExcel.Text = "Export to Excel";
            btExporttoExcel.Click += btExporttoExcel_Click;
            // 
            // btDefectRecord
            // 
            btDefectRecord.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btDefectRecord.Image = (Image)resources.GetObject("btDefectRecord.Image");
            btDefectRecord.ImageTransparentColor = Color.Magenta;
            btDefectRecord.Margin = new Padding(20, 1, 0, 2);
            btDefectRecord.Name = "btDefectRecord";
            btDefectRecord.Size = new Size(148, 36);
            btDefectRecord.Text = "Defect Record";
            btDefectRecord.Click += btDefectRecord_Click;
            // 
            // btAddDefect
            // 
            btAddDefect.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btAddDefect.Image = (Image)resources.GetObject("btAddDefect.Image");
            btAddDefect.ImageTransparentColor = Color.Magenta;
            btAddDefect.Margin = new Padding(20, 1, 0, 2);
            btAddDefect.Name = "btAddDefect";
            btAddDefect.Size = new Size(154, 36);
            btAddDefect.Text = "Add Defect List";
            btAddDefect.Click += btAddDefect_Click;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1362, 67);
            panel1.TabIndex = 2;
            // 
            // ReportCompareNew
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1362, 636);
            Controls.Add(gvDis);
            Controls.Add(toolStrip1);
            Controls.Add(panel1);
            Name = "ReportCompareNew";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ReportCompareNew";
            WindowState = FormWindowState.Maximized;
            Load += ReportCompareNew_Load;
            ((System.ComponentModel.ISupportInitialize)gvDis).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView gvDis;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripTextBox tbSO;
        private ToolStripButton btSearchSO;
        private ToolStripButton btExporttoExcel;
        private Panel panel1;
        private ToolStripButton btDefectRecord;
        private ToolStripButton btAddDefect;
    }
}