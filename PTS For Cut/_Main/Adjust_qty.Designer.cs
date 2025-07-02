namespace PTS_For_Cut._Main
{
    partial class Adjust_qty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Adjust_qty));
            toolStrip1 = new ToolStrip();
            lbScan = new ToolStripLabel();
            tbQRCode = new ToolStripTextBox();
            lbSO = new ToolStripLabel();
            tbSO = new ToolStripTextBox();
            btSearch = new ToolStripButton();
            toolStrip2 = new ToolStrip();
            toolStripLabel8 = new ToolStripLabel();
            cbbAdjust = new ToolStripComboBox();
            toolStripLabel2 = new ToolStripLabel();
            cbbDec = new ToolStripComboBox();
            toolStrip3 = new ToolStrip();
            lbHeader = new ToolStripLabel();
            toolStrip4 = new ToolStrip();
            lbNameQR_Ref = new ToolStripLabel();
            lbQRRef = new ToolStripLabel();
            lbBundleNo = new ToolStripLabel();
            tbBundleNo = new ToolStripTextBox();
            lbSize = new ToolStripLabel();
            cbbSize = new ToolStripComboBox();
            lbLine = new ToolStripLabel();
            cbbLine = new ToolStripComboBox();
            toolStripLabel6 = new ToolStripLabel();
            tbQty = new ToolStripTextBox();
            gvDis = new DataGridView();
            toolStrip5 = new ToolStrip();
            toolStripLabel5 = new ToolStripLabel();
            toolStripLabel10 = new ToolStripLabel();
            tbRemark = new ToolStripTextBox();
            btSave1 = new ToolStripButton();
            panel1 = new Panel();
            gvDisSD = new DataGridView();
            toolStrip7 = new ToolStrip();
            toolStripLabel3 = new ToolStripLabel();
            tbSDID = new ToolStripTextBox();
            btSearchSD = new ToolStripButton();
            btDelete = new ToolStripButton();
            toolStrip6 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            panel2 = new Panel();
            toolStrip1.SuspendLayout();
            toolStrip2.SuspendLayout();
            toolStrip3.SuspendLayout();
            toolStrip4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvDis).BeginInit();
            toolStrip5.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvDisSD).BeginInit();
            toolStrip7.SuspendLayout();
            toolStrip6.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { lbScan, tbQRCode, lbSO, tbSO, btSearch });
            toolStrip1.Location = new Point(360, 89);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(969, 39);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // lbScan
            // 
            lbScan.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbScan.Name = "lbScan";
            lbScan.Size = new Size(85, 36);
            lbScan.Text = "Scan Here";
            // 
            // tbQRCode
            // 
            tbQRCode.BackColor = SystemColors.InactiveCaption;
            tbQRCode.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbQRCode.Margin = new Padding(0, 0, 1, 0);
            tbQRCode.Name = "tbQRCode";
            tbQRCode.Size = new Size(200, 39);
            // 
            // lbSO
            // 
            lbSO.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbSO.Name = "lbSO";
            lbSO.Size = new Size(29, 36);
            lbSO.Text = "SO";
            // 
            // tbSO
            // 
            tbSO.BackColor = SystemColors.InactiveCaption;
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
            btSearch.Text = "Search";
            btSearch.Click += btSearch_Click;
            // 
            // toolStrip2
            // 
            toolStrip2.ImageScalingSize = new Size(45, 45);
            toolStrip2.Items.AddRange(new ToolStripItem[] { toolStripLabel8, cbbAdjust, toolStripLabel2, cbbDec });
            toolStrip2.Location = new Point(360, 48);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(969, 41);
            toolStrip2.TabIndex = 1;
            toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel8
            // 
            toolStripLabel8.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel8.Name = "toolStripLabel8";
            toolStripLabel8.Size = new Size(97, 38);
            toolStripLabel8.Text = "Adjust Mode";
            // 
            // cbbAdjust
            // 
            cbbAdjust.BackColor = SystemColors.ActiveCaption;
            cbbAdjust.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbAdjust.Enabled = false;
            cbbAdjust.Font = new Font("Bahnschrift Condensed", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            cbbAdjust.Items.AddRange(new object[] { "Decrease", "Increase" });
            cbbAdjust.Name = "cbbAdjust";
            cbbAdjust.Size = new Size(180, 41);
            cbbAdjust.SelectedIndexChanged += cbbAdjust_SelectedIndexChanged;
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(89, 38);
            toolStripLabel2.Text = "Decoration";
            // 
            // cbbDec
            // 
            cbbDec.BackColor = SystemColors.InactiveCaption;
            cbbDec.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbDec.Enabled = false;
            cbbDec.Font = new Font("Bahnschrift", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            cbbDec.Name = "cbbDec";
            cbbDec.Size = new Size(300, 41);
            // 
            // toolStrip3
            // 
            toolStrip3.Items.AddRange(new ToolStripItem[] { lbHeader });
            toolStrip3.Location = new Point(360, 0);
            toolStrip3.Name = "toolStrip3";
            toolStrip3.Size = new Size(969, 48);
            toolStrip3.TabIndex = 2;
            toolStrip3.Text = "toolStrip3";
            // 
            // lbHeader
            // 
            lbHeader.Font = new Font("Bahnschrift", 27.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbHeader.Margin = new Padding(300, 1, 0, 2);
            lbHeader.Name = "lbHeader";
            lbHeader.Size = new Size(199, 45);
            lbHeader.Text = "Adjust QTY";
            // 
            // toolStrip4
            // 
            toolStrip4.Dock = DockStyle.Bottom;
            toolStrip4.ImageScalingSize = new Size(32, 32);
            toolStrip4.Items.AddRange(new ToolStripItem[] { lbNameQR_Ref, lbQRRef, lbBundleNo, tbBundleNo, lbSize, cbbSize, lbLine, cbbLine, toolStripLabel6, tbQty });
            toolStrip4.Location = new Point(360, 429);
            toolStrip4.Name = "toolStrip4";
            toolStrip4.Size = new Size(969, 37);
            toolStrip4.TabIndex = 3;
            toolStrip4.Text = "toolStrip4";
            // 
            // lbNameQR_Ref
            // 
            lbNameQR_Ref.Font = new Font("Bahnschrift", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbNameQR_Ref.Name = "lbNameQR_Ref";
            lbNameQR_Ref.Size = new Size(160, 34);
            lbNameQR_Ref.Text = "Number Ref : ";
            // 
            // lbQRRef
            // 
            lbQRRef.Font = new Font("Bahnschrift", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbQRRef.Name = "lbQRRef";
            lbQRRef.Size = new Size(0, 34);
            // 
            // lbBundleNo
            // 
            lbBundleNo.Font = new Font("Bahnschrift", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbBundleNo.Name = "lbBundleNo";
            lbBundleNo.Size = new Size(139, 34);
            lbBundleNo.Text = "Bundle No. :";
            // 
            // tbBundleNo
            // 
            tbBundleNo.BackColor = SystemColors.InactiveCaption;
            tbBundleNo.Enabled = false;
            tbBundleNo.Font = new Font("Bahnschrift", 18F, FontStyle.Regular, GraphicsUnit.Point);
            tbBundleNo.Name = "tbBundleNo";
            tbBundleNo.Size = new Size(70, 37);
            // 
            // lbSize
            // 
            lbSize.Font = new Font("Bahnschrift", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbSize.Name = "lbSize";
            lbSize.Size = new Size(59, 34);
            lbSize.Text = "Size";
            // 
            // cbbSize
            // 
            cbbSize.BackColor = SystemColors.InactiveCaption;
            cbbSize.Font = new Font("Bahnschrift", 18F, FontStyle.Regular, GraphicsUnit.Point);
            cbbSize.Name = "cbbSize";
            cbbSize.Size = new Size(100, 37);
            // 
            // lbLine
            // 
            lbLine.Font = new Font("Bahnschrift", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbLine.Name = "lbLine";
            lbLine.Size = new Size(59, 34);
            lbLine.Text = "Line";
            // 
            // cbbLine
            // 
            cbbLine.BackColor = SystemColors.InactiveCaption;
            cbbLine.Font = new Font("Bahnschrift", 18F, FontStyle.Regular, GraphicsUnit.Point);
            cbbLine.Name = "cbbLine";
            cbbLine.Size = new Size(121, 37);
            // 
            // toolStripLabel6
            // 
            toolStripLabel6.Font = new Font("Bahnschrift", 18F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel6.Margin = new Padding(10, 1, 0, 2);
            toolStripLabel6.Name = "toolStripLabel6";
            toolStripLabel6.Size = new Size(54, 34);
            toolStripLabel6.Text = "QTY";
            // 
            // tbQty
            // 
            tbQty.BackColor = SystemColors.InactiveCaption;
            tbQty.Font = new Font("Bahnschrift", 18F, FontStyle.Regular, GraphicsUnit.Point);
            tbQty.Name = "tbQty";
            tbQty.Size = new Size(100, 37);
            tbQty.KeyPress += tbQty_KeyPress;
            // 
            // gvDis
            // 
            gvDis.AllowUserToAddRows = false;
            gvDis.AllowUserToDeleteRows = false;
            gvDis.BackgroundColor = Color.White;
            gvDis.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvDis.Dock = DockStyle.Fill;
            gvDis.Location = new Point(360, 128);
            gvDis.Name = "gvDis";
            gvDis.ReadOnly = true;
            gvDis.RowTemplate.Height = 25;
            gvDis.Size = new Size(969, 301);
            gvDis.TabIndex = 4;
            gvDis.CellClick += gvDis_CellClick;
            // 
            // toolStrip5
            // 
            toolStrip5.Dock = DockStyle.Bottom;
            toolStrip5.ImageScalingSize = new Size(32, 32);
            toolStrip5.Items.AddRange(new ToolStripItem[] { toolStripLabel5, toolStripLabel10, tbRemark, btSave1 });
            toolStrip5.Location = new Point(360, 466);
            toolStrip5.Name = "toolStrip5";
            toolStrip5.Size = new Size(969, 39);
            toolStrip5.TabIndex = 5;
            toolStrip5.Text = "toolStrip5";
            // 
            // toolStripLabel5
            // 
            toolStripLabel5.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel5.ForeColor = Color.Red;
            toolStripLabel5.Name = "toolStripLabel5";
            toolStripLabel5.Size = new Size(30, 36);
            toolStripLabel5.Text = "***";
            // 
            // toolStripLabel10
            // 
            toolStripLabel10.Font = new Font("Bahnschrift", 18F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel10.Name = "toolStripLabel10";
            toolStripLabel10.Size = new Size(121, 36);
            toolStripLabel10.Text = "Remark :: ";
            // 
            // tbRemark
            // 
            tbRemark.BackColor = SystemColors.InactiveCaption;
            tbRemark.Font = new Font("Bahnschrift", 18F, FontStyle.Regular, GraphicsUnit.Point);
            tbRemark.Name = "tbRemark";
            tbRemark.Size = new Size(600, 39);
            // 
            // btSave1
            // 
            btSave1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btSave1.Image = (Image)resources.GetObject("btSave1.Image");
            btSave1.ImageTransparentColor = Color.Magenta;
            btSave1.Name = "btSave1";
            btSave1.Size = new Size(36, 36);
            btSave1.Text = "Save";
            btSave1.Click += btSave1_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(gvDisSD);
            panel1.Controls.Add(toolStrip7);
            panel1.Controls.Add(toolStrip6);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(360, 505);
            panel1.TabIndex = 6;
            // 
            // gvDisSD
            // 
            gvDisSD.AllowUserToAddRows = false;
            gvDisSD.AllowUserToDeleteRows = false;
            gvDisSD.BackgroundColor = Color.White;
            gvDisSD.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvDisSD.Dock = DockStyle.Fill;
            gvDisSD.Location = new Point(0, 87);
            gvDisSD.Name = "gvDisSD";
            gvDisSD.ReadOnly = true;
            gvDisSD.RowTemplate.Height = 25;
            gvDisSD.Size = new Size(355, 418);
            gvDisSD.TabIndex = 5;
            gvDisSD.CellClick += gvDisSD_CellClick;
            // 
            // toolStrip7
            // 
            toolStrip7.ImageScalingSize = new Size(32, 32);
            toolStrip7.Items.AddRange(new ToolStripItem[] { toolStripLabel3, tbSDID, btSearchSD, btDelete });
            toolStrip7.Location = new Point(0, 48);
            toolStrip7.Name = "toolStrip7";
            toolStrip7.Size = new Size(355, 39);
            toolStrip7.TabIndex = 1;
            toolStrip7.Text = "toolStrip7";
            // 
            // toolStripLabel3
            // 
            toolStripLabel3.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel3.Name = "toolStripLabel3";
            toolStripLabel3.Size = new Size(120, 36);
            toolStripLabel3.Text = "Spreading Doc.";
            // 
            // tbSDID
            // 
            tbSDID.BackColor = SystemColors.InactiveCaption;
            tbSDID.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbSDID.Name = "tbSDID";
            tbSDID.Size = new Size(130, 39);
            // 
            // btSearchSD
            // 
            btSearchSD.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btSearchSD.Image = (Image)resources.GetObject("btSearchSD.Image");
            btSearchSD.ImageTransparentColor = Color.Magenta;
            btSearchSD.Name = "btSearchSD";
            btSearchSD.Size = new Size(36, 36);
            btSearchSD.Text = "Search SD";
            btSearchSD.Click += btSearchSD_Click;
            // 
            // btDelete
            // 
            btDelete.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btDelete.Image = (Image)resources.GetObject("btDelete.Image");
            btDelete.ImageTransparentColor = Color.Magenta;
            btDelete.Name = "btDelete";
            btDelete.Size = new Size(36, 36);
            btDelete.Text = "Delete";
            btDelete.Click += btDelete_Click;
            // 
            // toolStrip6
            // 
            toolStrip6.Items.AddRange(new ToolStripItem[] { toolStripLabel1 });
            toolStrip6.Location = new Point(0, 0);
            toolStrip6.Name = "toolStrip6";
            toolStrip6.Size = new Size(355, 48);
            toolStrip6.TabIndex = 0;
            toolStrip6.Text = "toolStrip6";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Font = new Font("Bahnschrift", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(314, 45);
            toolStripLabel1.Text = "Delete Adjust List";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Gold;
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(355, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(5, 505);
            panel2.TabIndex = 2;
            // 
            // Adjust_qty
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1329, 525);
            Controls.Add(gvDis);
            Controls.Add(toolStrip4);
            Controls.Add(toolStrip1);
            Controls.Add(toolStrip2);
            Controls.Add(toolStrip3);
            Controls.Add(toolStrip5);
            Controls.Add(panel1);
            Name = "Adjust_qty";
            Padding = new Padding(0, 0, 0, 20);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Adjust_qty";
            Load += Adjust_qty_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            toolStrip3.ResumeLayout(false);
            toolStrip3.PerformLayout();
            toolStrip4.ResumeLayout(false);
            toolStrip4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gvDis).EndInit();
            toolStrip5.ResumeLayout(false);
            toolStrip5.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gvDisSD).EndInit();
            toolStrip7.ResumeLayout(false);
            toolStrip7.PerformLayout();
            toolStrip6.ResumeLayout(false);
            toolStrip6.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripLabel lbScan;
        private ToolStripTextBox tbQRCode;
        private ToolStrip toolStrip2;
        private ToolStripLabel toolStripLabel2;
        private ToolStripComboBox cbbDec;
        private ToolStrip toolStrip3;
        private ToolStripLabel lbHeader;
        private ToolStrip toolStrip4;
        private ToolStripLabel lbNameQR_Ref;
        private ToolStripLabel lbQRRef;
        private ToolStripLabel toolStripLabel6;
        private ToolStripTextBox tbQty;
        private ToolStripLabel lbSO;
        private ToolStripTextBox tbSO;
        private ToolStripLabel toolStripLabel8;
        private ToolStripComboBox cbbAdjust;
        private DataGridView gvDis;
        private ToolStrip toolStrip5;
        private ToolStripLabel toolStripLabel10;
        private ToolStripTextBox tbRemark;
        private ToolStripLabel toolStripLabel5;
        private ToolStripButton btSave1;
        private ToolStripButton btSearch;
        private ToolStrip toolStrip6;
        private ToolStripButton btAddRef;
        private ToolStripLabel lbSize;
        private ToolStripComboBox cbbSize;
        private ToolStripLabel lbLine;
        private ToolStripComboBox cbbLine;
        private ToolStripLabel lbBundleNo;
        private ToolStripTextBox tbBundleNo;
        private Panel panel1;
        private ToolStrip toolStrip7;
        private ToolStripLabel toolStripLabel1;
        private ToolStripLabel toolStripLabel3;
        private ToolStripTextBox tbSDID;
        private ToolStripButton btSearchSD;
        private Panel panel2;
        private ToolStripButton btDelete;
        private DataGridView gvDisSD;
    }
}