namespace PTS_For_Cut._StyleInfo
{
    partial class AddSAM
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSAM));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            elipseForm = new Guna.UI2.WinForms.Guna2Elipse(components);
            pnHead = new Guna.UI2.WinForms.Guna2Panel();
            btClose = new Guna.UI2.WinForms.Guna2PictureBox();
            lbHeader = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            toolStrip2 = new ToolStrip();
            toolStripLabel2 = new ToolStripLabel();
            tbSmvSew = new ToolStripTextBox();
            toolStrip1 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            tbSmvCut = new ToolStripTextBox();
            btSave = new ToolStripButton();
            pnHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btClose).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            toolStrip2.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // elipseForm
            // 
            elipseForm.BorderRadius = 20;
            elipseForm.TargetControl = this;
            // 
            // pnHead
            // 
            pnHead.BackColor = Color.Gray;
            pnHead.Controls.Add(btClose);
            pnHead.Controls.Add(lbHeader);
            pnHead.CustomizableEdges = customizableEdges7;
            pnHead.Dock = DockStyle.Top;
            pnHead.Location = new Point(0, 0);
            pnHead.Name = "pnHead";
            pnHead.ShadowDecoration.CustomizableEdges = customizableEdges8;
            pnHead.Size = new Size(515, 36);
            pnHead.TabIndex = 0;
            // 
            // btClose
            // 
            btClose.CustomizableEdges = customizableEdges5;
            btClose.Image = (Image)resources.GetObject("btClose.Image");
            btClose.ImageRotate = 0F;
            btClose.Location = new Point(480, 1);
            btClose.Name = "btClose";
            btClose.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btClose.Size = new Size(32, 32);
            btClose.SizeMode = PictureBoxSizeMode.StretchImage;
            btClose.TabIndex = 1;
            btClose.TabStop = false;
            btClose.Click += btClose_Click;
            // 
            // lbHeader
            // 
            lbHeader.AutoSize = true;
            lbHeader.Font = new Font("Bahnschrift Condensed", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbHeader.ForeColor = Color.White;
            lbHeader.Location = new Point(224, 4);
            lbHeader.Name = "lbHeader";
            lbHeader.Size = new Size(45, 29);
            lbHeader.TabIndex = 0;
            lbHeader.Text = "SMV";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panel1, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 36);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(515, 131);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(toolStrip2);
            panel1.Controls.Add(toolStrip1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(135, 3);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(0, 35, 0, 0);
            panel1.Size = new Size(244, 125);
            panel1.TabIndex = 0;
            // 
            // toolStrip2
            // 
            toolStrip2.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStrip2.ImageScalingSize = new Size(32, 32);
            toolStrip2.Items.AddRange(new ToolStripItem[] { toolStripLabel2, tbSmvSew });
            toolStrip2.Location = new Point(0, 66);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(244, 27);
            toolStrip2.TabIndex = 1;
            toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Padding = new Padding(0, 0, 7, 0);
            toolStripLabel2.Size = new Size(80, 24);
            toolStripLabel2.Text = "SMV SEWING";
            // 
            // tbSmvSew
            // 
            tbSmvSew.BackColor = SystemColors.ActiveCaption;
            tbSmvSew.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbSmvSew.Name = "tbSmvSew";
            tbSmvSew.Size = new Size(100, 27);
            // 
            // toolStrip1
            // 
            toolStrip1.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1, tbSmvCut, btSave });
            toolStrip1.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            toolStrip1.Location = new Point(0, 35);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(244, 31);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Padding = new Padding(0, 0, 2, 0);
            toolStripLabel1.Size = new Size(80, 28);
            toolStripLabel1.Text = "SMV CUTTING";
            // 
            // tbSmvCut
            // 
            tbSmvCut.BackColor = SystemColors.ActiveCaption;
            tbSmvCut.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbSmvCut.Name = "tbSmvCut";
            tbSmvCut.Size = new Size(100, 31);
            // 
            // btSave
            // 
            btSave.Alignment = ToolStripItemAlignment.Right;
            btSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btSave.Image = (Image)resources.GetObject("btSave.Image");
            btSave.ImageTransparentColor = Color.Magenta;
            btSave.Name = "btSave";
            btSave.Size = new Size(28, 28);
            btSave.Text = "toolStripButton1";
            btSave.Click += btSave_Click;
            // 
            // AddSAM
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(515, 167);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(pnHead);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddSAM";
            Text = "AddSAM";
            Load += AddSAM_Load;
            pnHead.ResumeLayout(false);
            pnHead.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btClose).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse elipseForm;
        private Guna.UI2.WinForms.Guna2Panel pnHead;
        private Guna.UI2.WinForms.Guna2PictureBox btClose;
        private Label lbHeader;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripTextBox tbSmvCut;
        private ToolStrip toolStrip2;
        private ToolStripLabel toolStripLabel2;
        private ToolStripTextBox tbSmvSew;
        private ToolStripButton btSave;
    }
}