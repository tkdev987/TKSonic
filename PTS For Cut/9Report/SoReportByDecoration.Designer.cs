namespace PTS_For_Cut._9Report
{
    partial class SoReportByDecoration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoReportByDecoration));
            toolStrip1 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            cbbDepartment = new ToolStripComboBox();
            btSearch = new ToolStripButton();
            btExportToExcel = new ToolStripButton();
            panel1 = new Panel();
            panel2 = new Panel();
            label1 = new Label();
            tbSo = new TextBox();
            gvDis = new DataGridView();
            toolStrip1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvDis).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1, cbbDepartment, btSearch, btExportToExcel });
            toolStrip1.Location = new Point(0, 208);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1066, 39);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(146, 36);
            toolStripLabel1.Text = "Select Department";
            // 
            // cbbDepartment
            // 
            cbbDepartment.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbDepartment.Items.AddRange(new object[] { "Order", "Cutting", "SMK", "Sewing", "Packing" });
            cbbDepartment.Name = "cbbDepartment";
            cbbDepartment.Size = new Size(200, 39);
            // 
            // btSearch
            // 
            btSearch.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btSearch.Image = (Image)resources.GetObject("btSearch.Image");
            btSearch.ImageTransparentColor = Color.Magenta;
            btSearch.Name = "btSearch";
            btSearch.Size = new Size(36, 36);
            btSearch.Text = "Search";
            btSearch.Click += btSearch_Click;
            // 
            // btExportToExcel
            // 
            btExportToExcel.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btExportToExcel.Image = (Image)resources.GetObject("btExportToExcel.Image");
            btExportToExcel.ImageTransparentColor = Color.Magenta;
            btExportToExcel.Margin = new Padding(20, 1, 0, 2);
            btExportToExcel.Name = "btExportToExcel";
            btExportToExcel.Size = new Size(36, 36);
            btExportToExcel.Text = "Export to Excel";
            btExportToExcel.Click += btExportToExcel_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(toolStrip1);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1066, 247);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Controls.Add(tbSo);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(0, 10, 0, 0);
            panel2.Size = new Size(1066, 208);
            panel2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Left;
            label1.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(0, 10);
            label1.Margin = new Padding(3, 3, 3, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(5, 3, 0, 0);
            label1.Size = new Size(98, 22);
            label1.TabIndex = 1;
            label1.Text = "Search SO :";
            // 
            // tbSo
            // 
            tbSo.Dock = DockStyle.Bottom;
            tbSo.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbSo.Location = new Point(0, 35);
            tbSo.Multiline = true;
            tbSo.Name = "tbSo";
            tbSo.Size = new Size(1066, 173);
            tbSo.TabIndex = 4;
            // 
            // gvDis
            // 
            gvDis.AllowUserToAddRows = false;
            gvDis.AllowUserToDeleteRows = false;
            gvDis.BackgroundColor = Color.White;
            gvDis.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvDis.Dock = DockStyle.Fill;
            gvDis.Location = new Point(0, 247);
            gvDis.Name = "gvDis";
            gvDis.ReadOnly = true;
            gvDis.RowTemplate.Height = 25;
            gvDis.Size = new Size(1066, 395);
            gvDis.TabIndex = 2;
            // 
            // SoReportByDecoration
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1066, 642);
            Controls.Add(gvDis);
            Controls.Add(panel1);
            Name = "SoReportByDecoration";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SoReportByDecoration";
            WindowState = FormWindowState.Maximized;
            Load += SoReportByDecoration_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gvDis).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripComboBox cbbDepartment;
        private ToolStripButton btSearch;
        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private TextBox tbSo;
        private ToolStripButton btExportToExcel;
        private DataGridView gvDis;
    }
}