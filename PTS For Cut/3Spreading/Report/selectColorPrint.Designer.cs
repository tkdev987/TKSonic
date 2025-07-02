namespace PTS_For_Cut._3Spreading.Report
{
    partial class selectColorPrint
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(selectColorPrint));
            chListColorprint = new CheckedListBox();
            panel1 = new Panel();
            toolStrip1 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            cbbReportMode = new ToolStripComboBox();
            label1 = new Label();
            btPrint = new Guna.UI2.WinForms.Guna2Button();
            chListSpreading = new CheckedListBox();
            pnSpreading = new Panel();
            toolStrip5 = new ToolStrip();
            btSpCh = new ToolStripButton();
            btSPUnCh = new ToolStripButton();
            label3 = new Label();
            tbClothingPart = new TextBox();
            toolStrip3 = new ToolStrip();
            toolStripLabel4 = new ToolStripLabel();
            cbbPlace = new ToolStripComboBox();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripLabel2 = new ToolStripLabel();
            cbbClothingPart = new ToolStripComboBox();
            btAdd = new ToolStripButton();
            pnDecTop = new Panel();
            pnDetailInDectop = new Panel();
            toolStrip2 = new ToolStrip();
            toolStripLabel3 = new ToolStripLabel();
            cbbDec = new ToolStripComboBox();
            pnColor = new Panel();
            toolStrip4 = new ToolStrip();
            btColorCh = new ToolStripButton();
            btColorUnCh = new ToolStripButton();
            label2 = new Label();
            panel1.SuspendLayout();
            toolStrip1.SuspendLayout();
            pnSpreading.SuspendLayout();
            toolStrip5.SuspendLayout();
            toolStrip3.SuspendLayout();
            pnDecTop.SuspendLayout();
            pnDetailInDectop.SuspendLayout();
            toolStrip2.SuspendLayout();
            pnColor.SuspendLayout();
            toolStrip4.SuspendLayout();
            SuspendLayout();
            // 
            // chListColorprint
            // 
            chListColorprint.Dock = DockStyle.Fill;
            chListColorprint.Font = new Font("Bahnschrift SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            chListColorprint.FormattingEnabled = true;
            chListColorprint.Location = new Point(0, 55);
            chListColorprint.Name = "chListColorprint";
            chListColorprint.Size = new Size(433, 368);
            chListColorprint.TabIndex = 0;
            chListColorprint.ItemCheck += chListColorprint_ItemCheck;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(toolStrip1);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(934, 73);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.Bottom;
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1, cbbReportMode });
            toolStrip1.Location = new Point(0, 46);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(934, 27);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(101, 24);
            toolStripLabel1.Text = "Report Mode";
            // 
            // cbbReportMode
            // 
            cbbReportMode.BackColor = SystemColors.ActiveCaption;
            cbbReportMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbReportMode.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbReportMode.Items.AddRange(new object[] { "Actual Cut Report", "Bundle Report" });
            cbbReportMode.Name = "cbbReportMode";
            cbbReportMode.Size = new Size(180, 27);
            cbbReportMode.SelectedIndexChanged += cbbReportMode_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(317, 9);
            label1.Name = "label1";
            label1.Size = new Size(225, 27);
            label1.TabIndex = 0;
            label1.Text = "Select Color For Print";
            // 
            // btPrint
            // 
            btPrint.CustomizableEdges = customizableEdges1;
            btPrint.DisabledState.BorderColor = Color.DarkGray;
            btPrint.DisabledState.CustomBorderColor = Color.DarkGray;
            btPrint.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btPrint.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btPrint.Dock = DockStyle.Bottom;
            btPrint.FillColor = Color.FromArgb(128, 128, 255);
            btPrint.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            btPrint.ForeColor = Color.White;
            btPrint.Location = new Point(0, 596);
            btPrint.Name = "btPrint";
            btPrint.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btPrint.Size = new Size(934, 44);
            btPrint.TabIndex = 2;
            btPrint.Text = "Print";
            btPrint.Click += btPrint_Click;
            // 
            // chListSpreading
            // 
            chListSpreading.Dock = DockStyle.Fill;
            chListSpreading.Font = new Font("Bahnschrift SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            chListSpreading.FormattingEnabled = true;
            chListSpreading.Location = new Point(0, 55);
            chListSpreading.Name = "chListSpreading";
            chListSpreading.Size = new Size(501, 368);
            chListSpreading.TabIndex = 3;
            // 
            // pnSpreading
            // 
            pnSpreading.Controls.Add(chListSpreading);
            pnSpreading.Controls.Add(toolStrip5);
            pnSpreading.Controls.Add(label3);
            pnSpreading.Dock = DockStyle.Right;
            pnSpreading.Location = new Point(433, 173);
            pnSpreading.Name = "pnSpreading";
            pnSpreading.Size = new Size(501, 423);
            pnSpreading.TabIndex = 4;
            pnSpreading.Visible = false;
            // 
            // toolStrip5
            // 
            toolStrip5.ImageScalingSize = new Size(24, 24);
            toolStrip5.Items.AddRange(new ToolStripItem[] { btSpCh, btSPUnCh });
            toolStrip5.Location = new Point(0, 24);
            toolStrip5.Name = "toolStrip5";
            toolStrip5.Size = new Size(501, 31);
            toolStrip5.TabIndex = 5;
            toolStrip5.Text = "toolStrip5";
            // 
            // btSpCh
            // 
            btSpCh.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btSpCh.Image = (Image)resources.GetObject("btSpCh.Image");
            btSpCh.ImageTransparentColor = Color.Magenta;
            btSpCh.Name = "btSpCh";
            btSpCh.Size = new Size(105, 28);
            btSpCh.Text = "Check All";
            btSpCh.Click += btSpCh_Click;
            // 
            // btSPUnCh
            // 
            btSPUnCh.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btSPUnCh.Image = (Image)resources.GetObject("btSPUnCh.Image");
            btSPUnCh.ImageTransparentColor = Color.Magenta;
            btSPUnCh.Name = "btSPUnCh";
            btSPUnCh.Size = new Size(98, 28);
            btSPUnCh.Text = "Uncheck";
            btSPUnCh.Click += btSPUnCh_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Padding = new Padding(5, 5, 0, 0);
            label3.Size = new Size(125, 24);
            label3.TabIndex = 4;
            label3.Text = "Spreading Doc.";
            // 
            // tbClothingPart
            // 
            tbClothingPart.Dock = DockStyle.Fill;
            tbClothingPart.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbClothingPart.Location = new Point(0, 31);
            tbClothingPart.Multiline = true;
            tbClothingPart.Name = "tbClothingPart";
            tbClothingPart.Size = new Size(934, 44);
            tbClothingPart.TabIndex = 1;
            // 
            // toolStrip3
            // 
            toolStrip3.ImageScalingSize = new Size(24, 24);
            toolStrip3.Items.AddRange(new ToolStripItem[] { toolStripLabel4, cbbPlace, toolStripSeparator3, toolStripLabel2, cbbClothingPart, btAdd });
            toolStrip3.Location = new Point(0, 0);
            toolStrip3.Name = "toolStrip3";
            toolStrip3.Size = new Size(934, 31);
            toolStrip3.TabIndex = 2;
            toolStrip3.Text = "toolStrip3";
            // 
            // toolStripLabel4
            // 
            toolStripLabel4.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel4.Name = "toolStripLabel4";
            toolStripLabel4.Size = new Size(50, 28);
            toolStripLabel4.Text = "Place";
            // 
            // cbbPlace
            // 
            cbbPlace.BackColor = SystemColors.ActiveCaption;
            cbbPlace.Name = "cbbPlace";
            cbbPlace.Size = new Size(121, 31);
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 31);
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Padding = new Padding(15, 0, 0, 0);
            toolStripLabel2.Size = new Size(123, 28);
            toolStripLabel2.Text = "Clothing Part:";
            // 
            // cbbClothingPart
            // 
            cbbClothingPart.BackColor = SystemColors.ActiveCaption;
            cbbClothingPart.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbClothingPart.Name = "cbbClothingPart";
            cbbClothingPart.Size = new Size(150, 31);
            cbbClothingPart.SelectedIndexChanged += cbbClothingPart_SelectedIndexChanged;
            // 
            // btAdd
            // 
            btAdd.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btAdd.Image = (Image)resources.GetObject("btAdd.Image");
            btAdd.ImageTransparentColor = Color.Magenta;
            btAdd.Name = "btAdd";
            btAdd.Size = new Size(28, 28);
            btAdd.Text = "toolStripButton1";
            btAdd.Click += btAdd_Click;
            // 
            // pnDecTop
            // 
            pnDecTop.Controls.Add(pnDetailInDectop);
            pnDecTop.Controls.Add(toolStrip2);
            pnDecTop.Dock = DockStyle.Top;
            pnDecTop.Location = new Point(0, 73);
            pnDecTop.Name = "pnDecTop";
            pnDecTop.Size = new Size(934, 100);
            pnDecTop.TabIndex = 5;
            // 
            // pnDetailInDectop
            // 
            pnDetailInDectop.Controls.Add(tbClothingPart);
            pnDetailInDectop.Controls.Add(toolStrip3);
            pnDetailInDectop.Dock = DockStyle.Fill;
            pnDetailInDectop.Location = new Point(0, 25);
            pnDetailInDectop.Name = "pnDetailInDectop";
            pnDetailInDectop.Size = new Size(934, 75);
            pnDetailInDectop.TabIndex = 1;
            pnDetailInDectop.Visible = false;
            pnDetailInDectop.Paint += panel5_Paint;
            // 
            // toolStrip2
            // 
            toolStrip2.ImageScalingSize = new Size(24, 24);
            toolStrip2.Items.AddRange(new ToolStripItem[] { toolStripLabel3, cbbDec });
            toolStrip2.Location = new Point(0, 0);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(934, 25);
            toolStrip2.TabIndex = 0;
            toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel3
            // 
            toolStripLabel3.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel3.Name = "toolStripLabel3";
            toolStripLabel3.Padding = new Padding(0, 0, 5, 0);
            toolStripLabel3.Size = new Size(102, 22);
            toolStripLabel3.Text = "Docoration :";
            // 
            // cbbDec
            // 
            cbbDec.BackColor = SystemColors.ActiveCaption;
            cbbDec.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbDec.Name = "cbbDec";
            cbbDec.Size = new Size(180, 25);
            cbbDec.SelectedIndexChanged += cbbDec_SelectedIndexChanged;
            cbbDec.Click += cbbDec_Click;
            // 
            // pnColor
            // 
            pnColor.Controls.Add(chListColorprint);
            pnColor.Controls.Add(toolStrip4);
            pnColor.Controls.Add(label2);
            pnColor.Dock = DockStyle.Fill;
            pnColor.Location = new Point(0, 173);
            pnColor.Name = "pnColor";
            pnColor.Size = new Size(433, 423);
            pnColor.TabIndex = 4;
            // 
            // toolStrip4
            // 
            toolStrip4.ImageScalingSize = new Size(24, 24);
            toolStrip4.Items.AddRange(new ToolStripItem[] { btColorCh, btColorUnCh });
            toolStrip4.Location = new Point(0, 24);
            toolStrip4.Name = "toolStrip4";
            toolStrip4.Size = new Size(433, 31);
            toolStrip4.TabIndex = 2;
            toolStrip4.Text = "toolStrip4";
            // 
            // btColorCh
            // 
            btColorCh.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btColorCh.Image = (Image)resources.GetObject("btColorCh.Image");
            btColorCh.ImageTransparentColor = Color.Magenta;
            btColorCh.Name = "btColorCh";
            btColorCh.Size = new Size(105, 28);
            btColorCh.Text = "Check All";
            btColorCh.Click += btColorCh_Click;
            // 
            // btColorUnCh
            // 
            btColorUnCh.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btColorUnCh.Image = (Image)resources.GetObject("btColorUnCh.Image");
            btColorUnCh.ImageTransparentColor = Color.Magenta;
            btColorUnCh.Name = "btColorUnCh";
            btColorUnCh.Size = new Size(98, 28);
            btColorUnCh.Text = "Uncheck";
            btColorUnCh.Click += btColorUnCh_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Padding = new Padding(5, 5, 0, 0);
            label2.Size = new Size(54, 24);
            label2.TabIndex = 1;
            label2.Text = "Color";
            // 
            // selectColorPrint
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(934, 640);
            Controls.Add(pnColor);
            Controls.Add(pnSpreading);
            Controls.Add(pnDecTop);
            Controls.Add(btPrint);
            Controls.Add(panel1);
            Name = "selectColorPrint";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "selectColorPrint";
            Load += selectColorPrint_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            pnSpreading.ResumeLayout(false);
            pnSpreading.PerformLayout();
            toolStrip5.ResumeLayout(false);
            toolStrip5.PerformLayout();
            toolStrip3.ResumeLayout(false);
            toolStrip3.PerformLayout();
            pnDecTop.ResumeLayout(false);
            pnDecTop.PerformLayout();
            pnDetailInDectop.ResumeLayout(false);
            pnDetailInDectop.PerformLayout();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            pnColor.ResumeLayout(false);
            pnColor.PerformLayout();
            toolStrip4.ResumeLayout(false);
            toolStrip4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private CheckedListBox chListColorprint;
        private Panel panel1;
        private Label label1;
        private Guna.UI2.WinForms.Guna2Button btPrint;
        private ToolStrip toolStrip1;
        private CheckedListBox chListSpreading;
        private Panel pnSpreading;
        private Label label3;
        private Panel pnColor;
        private Label label2;
        private Panel pnDecTop;
        private ToolStrip toolStrip2;
        private ToolStripLabel toolStripLabel3;
        private ToolStripComboBox cbbDec;
        private ToolStripLabel toolStripLabel1;
        private ToolStripComboBox cbbReportMode;
        private TextBox tbClothingPart;
        private ToolStrip toolStrip3;
        private ToolStripLabel toolStripLabel2;
        private ToolStripComboBox cbbClothingPart;
        private ToolStripButton btAdd;
        private ToolStripSeparator toolStripSeparator3;
        private Panel pnDetailInDectop;
        private ToolStripLabel toolStripLabel4;
        private ToolStripComboBox cbbPlace;
        private ToolStrip toolStrip5;
        private ToolStripButton btSpCh;
        private ToolStrip toolStrip4;
        private ToolStripButton btColorCh;
        private ToolStripButton btColorUnCh;
        private ToolStripButton btSPUnCh;
    }
}