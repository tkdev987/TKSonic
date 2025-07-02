namespace PTS_For_Cut._Main
{
    partial class AdjustQTY_V2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdjustQTY_V2));
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            pnlbHeader = new Panel();
            lbHeader = new Label();
            toolStrip1 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            cbbDepartment = new ToolStripComboBox();
            gvDis = new DataGridView();
            toolStrip2 = new ToolStrip();
            toolStripLabel3 = new ToolStripLabel();
            cbbLine = new ToolStripComboBox();
            toolStrip3 = new ToolStrip();
            toolStripLabel4 = new ToolStripLabel();
            tbQTY = new ToolStripTextBox();
            toolStripLabel8 = new ToolStripLabel();
            toolStrip4 = new ToolStrip();
            toolStripLabel6 = new ToolStripLabel();
            tbQrCode1 = new ToolStripTextBox();
            btSearch1 = new ToolStripButton();
            panel1 = new Panel();
            toolStrip7 = new ToolStrip();
            toolStripLabel7 = new ToolStripLabel();
            tbRemark = new ToolStripTextBox();
            btSave2 = new ToolStripButton();
            panel2 = new Panel();
            gvDisList = new DataGridView();
            toolStrip6 = new ToolStrip();
            toolStripLabel5 = new ToolStripLabel();
            toolStripButton1 = new ToolStripButton();
            toolStrip5 = new ToolStrip();
            toolStripLabel2 = new ToolStripLabel();
            tbSearchHis = new ToolStripTextBox();
            btSearchHistory = new ToolStripButton();
            pnlbHeader2 = new Panel();
            lbHeader2 = new Label();
            panel3 = new Panel();
            pnlbHeader.SuspendLayout();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvDis).BeginInit();
            toolStrip2.SuspendLayout();
            toolStrip3.SuspendLayout();
            toolStrip4.SuspendLayout();
            panel1.SuspendLayout();
            toolStrip7.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvDisList).BeginInit();
            toolStrip6.SuspendLayout();
            toolStrip5.SuspendLayout();
            pnlbHeader2.SuspendLayout();
            SuspendLayout();
            // 
            // pnlbHeader
            // 
            pnlbHeader.Controls.Add(lbHeader);
            pnlbHeader.Dock = DockStyle.Top;
            pnlbHeader.Location = new Point(0, 0);
            pnlbHeader.Name = "pnlbHeader";
            pnlbHeader.Size = new Size(880, 51);
            pnlbHeader.TabIndex = 0;
            pnlbHeader.Paint += pnlbHeader_Paint;
            // 
            // lbHeader
            // 
            lbHeader.AutoSize = true;
            lbHeader.Font = new Font("Bahnschrift", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbHeader.Location = new Point(141, 0);
            lbHeader.Name = "lbHeader";
            lbHeader.Size = new Size(186, 42);
            lbHeader.TabIndex = 0;
            lbHeader.Text = "Adjust QTY";
            // 
            // toolStrip1
            // 
            toolStrip1.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1, cbbDepartment });
            toolStrip1.Location = new Point(0, 51);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(880, 27);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(96, 24);
            toolStripLabel1.Text = "Department";
            // 
            // cbbDepartment
            // 
            cbbDepartment.BackColor = SystemColors.ActiveCaption;
            cbbDepartment.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbDepartment.MaxDropDownItems = 10;
            cbbDepartment.Name = "cbbDepartment";
            cbbDepartment.Size = new Size(180, 27);
            cbbDepartment.SelectedIndexChanged += cbbDepartment_SelectedIndexChanged;
            // 
            // gvDis
            // 
            gvDis.AllowUserToAddRows = false;
            gvDis.AllowUserToDeleteRows = false;
            gvDis.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            gvDis.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gvDis.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            gvDis.DefaultCellStyle = dataGridViewCellStyle2;
            gvDis.Dock = DockStyle.Fill;
            gvDis.Location = new Point(0, 210);
            gvDis.Name = "gvDis";
            gvDis.ReadOnly = true;
            gvDis.RowTemplate.Height = 25;
            gvDis.Size = new Size(880, 457);
            gvDis.TabIndex = 5;
            // 
            // toolStrip2
            // 
            toolStrip2.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStrip2.ImageScalingSize = new Size(32, 32);
            toolStrip2.Items.AddRange(new ToolStripItem[] { toolStripLabel3, cbbLine });
            toolStrip2.Location = new Point(0, 117);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(880, 27);
            toolStrip2.TabIndex = 6;
            toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel3
            // 
            toolStripLabel3.Name = "toolStripLabel3";
            toolStripLabel3.Padding = new Padding(0, 0, 55, 0);
            toolStripLabel3.Size = new Size(95, 24);
            toolStripLabel3.Text = "Line";
            // 
            // cbbLine
            // 
            cbbLine.BackColor = SystemColors.ActiveCaption;
            cbbLine.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbLine.Name = "cbbLine";
            cbbLine.Size = new Size(120, 27);
            // 
            // toolStrip3
            // 
            toolStrip3.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStrip3.ImageScalingSize = new Size(32, 32);
            toolStrip3.Items.AddRange(new ToolStripItem[] { toolStripLabel4, tbQTY, toolStripLabel8 });
            toolStrip3.Location = new Point(0, 144);
            toolStrip3.Name = "toolStrip3";
            toolStrip3.Size = new Size(880, 27);
            toolStrip3.TabIndex = 7;
            toolStrip3.Text = "toolStrip3";
            // 
            // toolStripLabel4
            // 
            toolStripLabel4.Name = "toolStripLabel4";
            toolStripLabel4.Padding = new Padding(0, 0, 59, 0);
            toolStripLabel4.Size = new Size(96, 24);
            toolStripLabel4.Text = "QTY";
            // 
            // tbQTY
            // 
            tbQTY.BackColor = SystemColors.ActiveCaption;
            tbQTY.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbQTY.Name = "tbQTY";
            tbQTY.Size = new Size(105, 27);
            tbQTY.KeyPress += tbQTY_KeyPress;
            tbQTY.TextChanged += tbQTY_TextChanged;
            // 
            // toolStripLabel8
            // 
            toolStripLabel8.Font = new Font("Bahnschrift", 9F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel8.Name = "toolStripLabel8";
            toolStripLabel8.Size = new Size(96, 24);
            toolStripLabel8.Text = "*** Start With -,+";
            // 
            // toolStrip4
            // 
            toolStrip4.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStrip4.ImageScalingSize = new Size(32, 32);
            toolStrip4.Items.AddRange(new ToolStripItem[] { toolStripLabel6, tbQrCode1, btSearch1 });
            toolStrip4.Location = new Point(0, 78);
            toolStrip4.Name = "toolStrip4";
            toolStrip4.Size = new Size(880, 39);
            toolStrip4.TabIndex = 8;
            toolStrip4.Text = "toolStrip4";
            // 
            // toolStripLabel6
            // 
            toolStripLabel6.Name = "toolStripLabel6";
            toolStripLabel6.Padding = new Padding(0, 0, 1, 0);
            toolStripLabel6.Size = new Size(96, 36);
            toolStripLabel6.Text = "QRCode No.";
            // 
            // tbQrCode1
            // 
            tbQrCode1.BackColor = SystemColors.ActiveCaption;
            tbQrCode1.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbQrCode1.Name = "tbQrCode1";
            tbQrCode1.Size = new Size(167, 39);
            // 
            // btSearch1
            // 
            btSearch1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btSearch1.Image = (Image)resources.GetObject("btSearch1.Image");
            btSearch1.ImageTransparentColor = Color.Magenta;
            btSearch1.Name = "btSearch1";
            btSearch1.Size = new Size(36, 36);
            btSearch1.Text = "Search";
            btSearch1.Click += btSearch1_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(gvDis);
            panel1.Controls.Add(toolStrip7);
            panel1.Controls.Add(toolStrip3);
            panel1.Controls.Add(toolStrip2);
            panel1.Controls.Add(toolStrip4);
            panel1.Controls.Add(toolStrip1);
            panel1.Controls.Add(pnlbHeader);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(880, 667);
            panel1.TabIndex = 9;
            // 
            // toolStrip7
            // 
            toolStrip7.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStrip7.ImageScalingSize = new Size(32, 32);
            toolStrip7.Items.AddRange(new ToolStripItem[] { toolStripLabel7, tbRemark, btSave2 });
            toolStrip7.Location = new Point(0, 171);
            toolStrip7.Name = "toolStrip7";
            toolStrip7.Size = new Size(880, 39);
            toolStrip7.TabIndex = 9;
            toolStrip7.Text = "toolStrip7";
            // 
            // toolStripLabel7
            // 
            toolStripLabel7.Name = "toolStripLabel7";
            toolStripLabel7.Padding = new Padding(0, 0, 30, 0);
            toolStripLabel7.Size = new Size(96, 36);
            toolStripLabel7.Text = "Remark";
            // 
            // tbRemark
            // 
            tbRemark.BackColor = SystemColors.ActiveCaption;
            tbRemark.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbRemark.Name = "tbRemark";
            tbRemark.Size = new Size(400, 39);
            // 
            // btSave2
            // 
            btSave2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btSave2.Image = (Image)resources.GetObject("btSave2.Image");
            btSave2.ImageTransparentColor = Color.Magenta;
            btSave2.Margin = new Padding(10, 1, 0, 2);
            btSave2.Name = "btSave2";
            btSave2.Size = new Size(36, 36);
            btSave2.Text = "Save";
            btSave2.Click += btSave2_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(gvDisList);
            panel2.Controls.Add(toolStrip6);
            panel2.Controls.Add(toolStrip5);
            panel2.Controls.Add(pnlbHeader2);
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(880, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(551, 667);
            panel2.TabIndex = 10;
            // 
            // gvDisList
            // 
            gvDisList.AllowUserToAddRows = false;
            gvDisList.AllowUserToDeleteRows = false;
            gvDisList.BackgroundColor = Color.White;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            gvDisList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            gvDisList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            gvDisList.DefaultCellStyle = dataGridViewCellStyle4;
            gvDisList.Dock = DockStyle.Fill;
            gvDisList.Location = new Point(4, 121);
            gvDisList.Name = "gvDisList";
            gvDisList.ReadOnly = true;
            gvDisList.RowTemplate.Height = 25;
            gvDisList.Size = new Size(547, 546);
            gvDisList.TabIndex = 6;
            // 
            // toolStrip6
            // 
            toolStrip6.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStrip6.ImageScalingSize = new Size(24, 24);
            toolStrip6.Items.AddRange(new ToolStripItem[] { toolStripLabel5, toolStripButton1 });
            toolStrip6.Location = new Point(4, 90);
            toolStrip6.Name = "toolStrip6";
            toolStrip6.Size = new Size(547, 31);
            toolStrip6.TabIndex = 11;
            toolStrip6.Text = "toolStrip6";
            // 
            // toolStripLabel5
            // 
            toolStripLabel5.Font = new Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel5.Name = "toolStripLabel5";
            toolStripLabel5.Size = new Size(155, 28);
            toolStripLabel5.Text = "Can Search with SO or SD";
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(28, 28);
            toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStrip5
            // 
            toolStrip5.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStrip5.ImageScalingSize = new Size(32, 32);
            toolStrip5.Items.AddRange(new ToolStripItem[] { toolStripLabel2, tbSearchHis, btSearchHistory });
            toolStrip5.Location = new Point(4, 51);
            toolStrip5.Name = "toolStrip5";
            toolStrip5.Size = new Size(547, 39);
            toolStrip5.TabIndex = 9;
            toolStrip5.Text = "toolStrip5";
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(61, 36);
            toolStripLabel2.Text = "Search";
            // 
            // tbSearchHis
            // 
            tbSearchHis.BackColor = SystemColors.ActiveCaption;
            tbSearchHis.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbSearchHis.Name = "tbSearchHis";
            tbSearchHis.Size = new Size(200, 39);
            // 
            // btSearchHistory
            // 
            btSearchHistory.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btSearchHistory.Image = (Image)resources.GetObject("btSearchHistory.Image");
            btSearchHistory.ImageTransparentColor = Color.Magenta;
            btSearchHistory.Name = "btSearchHistory";
            btSearchHistory.Size = new Size(36, 36);
            btSearchHistory.Text = "Search";
            btSearchHistory.Click += btSearchHistory_Click;
            // 
            // pnlbHeader2
            // 
            pnlbHeader2.Controls.Add(lbHeader2);
            pnlbHeader2.Dock = DockStyle.Top;
            pnlbHeader2.Location = new Point(4, 0);
            pnlbHeader2.Name = "pnlbHeader2";
            pnlbHeader2.Size = new Size(547, 51);
            pnlbHeader2.TabIndex = 1;
            // 
            // lbHeader2
            // 
            lbHeader2.AutoSize = true;
            lbHeader2.Font = new Font("Bahnschrift", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbHeader2.Location = new Point(213, 0);
            lbHeader2.Name = "lbHeader2";
            lbHeader2.Size = new Size(184, 42);
            lbHeader2.TabIndex = 0;
            lbHeader2.Text = "Adjust List";
            // 
            // panel3
            // 
            panel3.BackColor = Color.Gold;
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(4, 667);
            panel3.TabIndex = 10;
            // 
            // AdjustQTY_V2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1431, 667);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "AdjustQTY_V2";
            Text = "AdjustQTY_V2";
            FormClosed += AdjustQTY_V2_FormClosed;
            Load += AdjustQTY_V2_Load;
            pnlbHeader.ResumeLayout(false);
            pnlbHeader.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gvDis).EndInit();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            toolStrip3.ResumeLayout(false);
            toolStrip3.PerformLayout();
            toolStrip4.ResumeLayout(false);
            toolStrip4.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            toolStrip7.ResumeLayout(false);
            toolStrip7.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gvDisList).EndInit();
            toolStrip6.ResumeLayout(false);
            toolStrip6.PerformLayout();
            toolStrip5.ResumeLayout(false);
            toolStrip5.PerformLayout();
            pnlbHeader2.ResumeLayout(false);
            pnlbHeader2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlbHeader;
        private Label lbHeader;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripComboBox cbbDepartment;
        private DataGridView gvDis;
        private ToolStrip toolStrip2;
        private ToolStripLabel toolStripLabel3;
        private ToolStripComboBox cbbLine;
        private ToolStrip toolStrip3;
        private ToolStripLabel toolStripLabel4;
        private ToolStripTextBox tbQTY;
        private ToolStrip toolStrip4;
        private ToolStripLabel toolStripLabel6;
        private ToolStripTextBox tbQrCode1;
        private ToolStripButton btSearch1;
        private Panel panel1;
        private Panel panel2;
        private Panel pnlbHeader2;
        private Label lbHeader2;
        private DataGridView gvDisList;
        private ToolStrip toolStrip5;
        private ToolStripLabel toolStripLabel2;
        private ToolStripTextBox tbSearchHis;
        private ToolStripButton btSearchHistory;
        private Panel panel3;
        private ToolStrip toolStrip6;
        private ToolStripLabel toolStripLabel5;
        private ToolStrip toolStrip7;
        private ToolStripLabel toolStripLabel7;
        private ToolStripTextBox tbRemark;
        private ToolStripButton btSave2;
        private ToolStripLabel toolStripLabel8;
        private ToolStripButton toolStripButton1;
    }
}