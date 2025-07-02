namespace PTS_For_Cut._9Report
{
    partial class SoBundleReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoBundleReport));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            toolStrip1 = new ToolStrip();
            toolStripLabel2 = new ToolStripLabel();
            tbSO = new ToolStripTextBox();
            btSearch = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            lbSO = new ToolStripLabel();
            toolStripLabel1 = new ToolStripLabel();
            cbbStatusScan = new ToolStripComboBox();
            btExcel = new ToolStripButton();
            lbSewQTY = new ToolStripLabel();
            lbCutQTY = new ToolStripLabel();
            lbBundleQTY = new ToolStripLabel();
            gvDis = new Guna.UI2.WinForms.Guna2DataGridView();
            toolStripTextBox1 = new ToolStripTextBox();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvDis).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { lbSO, toolStripLabel1, cbbStatusScan, btExcel, lbSewQTY, lbCutQTY, lbBundleQTY, toolStripSeparator1, toolStripTextBox1, toolStripLabel2, tbSO, btSearch });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1471, 39);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(61, 36);
            toolStripLabel2.Text = "Search";
            // 
            // tbSO
            // 
            tbSO.BackColor = SystemColors.ActiveCaption;
            tbSO.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbSO.Name = "tbSO";
            tbSO.Size = new Size(200, 39);
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
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 39);
            // 
            // lbSO
            // 
            lbSO.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbSO.Name = "lbSO";
            lbSO.Size = new Size(33, 36);
            lbSO.Text = "xxxx";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(0, 36);
            // 
            // cbbStatusScan
            // 
            cbbStatusScan.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbStatusScan.Items.AddRange(new object[] { "On Process.", "Fully Not Scan Yet." });
            cbbStatusScan.Name = "cbbStatusScan";
            cbbStatusScan.Size = new Size(200, 39);
            cbbStatusScan.SelectedIndexChanged += cbbStatusScan_SelectedIndexChanged;
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
            // lbSewQTY
            // 
            lbSewQTY.Alignment = ToolStripItemAlignment.Right;
            lbSewQTY.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbSewQTY.Name = "lbSewQTY";
            lbSewQTY.Size = new Size(31, 36);
            lbSewQTY.Text = "Sew";
            // 
            // lbCutQTY
            // 
            lbCutQTY.Alignment = ToolStripItemAlignment.Right;
            lbCutQTY.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbCutQTY.Name = "lbCutQTY";
            lbCutQTY.Size = new Size(27, 36);
            lbCutQTY.Text = "Cut";
            // 
            // lbBundleQTY
            // 
            lbBundleQTY.Alignment = ToolStripItemAlignment.Right;
            lbBundleQTY.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbBundleQTY.Name = "lbBundleQTY";
            lbBundleQTY.Size = new Size(75, 36);
            lbBundleQTY.Text = "Bundle QTY :";
            // 
            // gvDis
            // 
            gvDis.AllowUserToAddRows = false;
            gvDis.AllowUserToDeleteRows = false;
            gvDis.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle1.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(157, 149, 255);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(71, 69, 94);
            gvDis.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Gray;
            dataGridViewCellStyle2.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.Gray;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            gvDis.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            gvDis.ColumnHeadersHeight = 35;
            gvDis.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(157, 149, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            gvDis.DefaultCellStyle = dataGridViewCellStyle3;
            gvDis.Dock = DockStyle.Fill;
            gvDis.GridColor = Color.FromArgb(231, 229, 255);
            gvDis.Location = new Point(0, 39);
            gvDis.Name = "gvDis";
            gvDis.ReadOnly = true;
            gvDis.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.White;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            gvDis.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            gvDis.RowHeadersVisible = false;
            gvDis.RowTemplate.Height = 25;
            gvDis.SelectionMode = DataGridViewSelectionMode.CellSelect;
            gvDis.Size = new Size(1471, 493);
            gvDis.TabIndex = 1;
            gvDis.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(224, 224, 224);
            gvDis.ThemeStyle.AlternatingRowsStyle.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            gvDis.ThemeStyle.AlternatingRowsStyle.ForeColor = SystemColors.ControlText;
            gvDis.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.FromArgb(157, 149, 255);
            gvDis.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            gvDis.ThemeStyle.BackColor = Color.White;
            gvDis.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            gvDis.ThemeStyle.HeaderStyle.BackColor = Color.Gray;
            gvDis.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            gvDis.ThemeStyle.HeaderStyle.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            gvDis.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            gvDis.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            gvDis.ThemeStyle.HeaderStyle.Height = 35;
            gvDis.ThemeStyle.ReadOnly = true;
            gvDis.ThemeStyle.RowsStyle.BackColor = Color.White;
            gvDis.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gvDis.ThemeStyle.RowsStyle.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            gvDis.ThemeStyle.RowsStyle.ForeColor = Color.Black;
            gvDis.ThemeStyle.RowsStyle.Height = 25;
            gvDis.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(157, 149, 255);
            gvDis.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // toolStripTextBox1
            // 
            toolStripTextBox1.Name = "toolStripTextBox1";
            toolStripTextBox1.Size = new Size(20, 39);
            // 
            // SoBundleReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1471, 532);
            Controls.Add(gvDis);
            Controls.Add(toolStrip1);
            Name = "SoBundleReport";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SoBundleReport";
            WindowState = FormWindowState.Maximized;
            Load += SoBundleReport_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gvDis).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripLabel lbSO;
        private ToolStripButton btExcel;
        private Guna.UI2.WinForms.Guna2DataGridView gvDis;
        private ToolStripLabel lbBundleQTY;
        private ToolStripLabel lbCutQTY;
        private ToolStripLabel lbSewQTY;
        private ToolStripLabel toolStripLabel1;
        private ToolStripComboBox cbbStatusScan;
        private ToolStripLabel toolStripLabel2;
        private ToolStripTextBox tbSO;
        private ToolStripButton btSearch;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripTextBox toolStripTextBox1;
    }
}