namespace PTS_For_Cut._6Sewing
{
    partial class EmpSkillofEachgarment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmpSkillofEachgarment));
            toolStrip1 = new ToolStrip();
            toolStripLabel3 = new ToolStripLabel();
            tbEmp = new ToolStripTextBox();
            btAddEmp = new ToolStripButton();
            btDeleteEmp = new ToolStripButton();
            btSave = new ToolStripButton();
            panel1 = new Panel();
            gvDis = new DataGridView();
            panel2 = new Panel();
            label1 = new Label();
            toolStrip6 = new ToolStrip();
            btDelete = new ToolStripButton();
            btShowOn = new ToolStripButton();
            btClearAll = new ToolStripButton();
            panel5 = new Panel();
            toolStrip2 = new ToolStrip();
            toolStripLabel2 = new ToolStripLabel();
            cbbGarmentTypeNumber = new ToolStripComboBox();
            btAdd = new ToolStripButton();
            toolStrip4 = new ToolStrip();
            toolStripLabel4 = new ToolStripLabel();
            cbbGarmentType = new ToolStripComboBox();
            toolStrip3 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            cbbLine = new ToolStripComboBox();
            panel3 = new Panel();
            toolStrip7 = new ToolStrip();
            btOperation1 = new ToolStripButton();
            ptb1 = new PictureBox();
            gvDisDetail = new DataGridView();
            toolStrip5 = new ToolStrip();
            btUp = new ToolStripButton();
            btDown = new ToolStripButton();
            panel4 = new Panel();
            toolStrip1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvDis).BeginInit();
            panel2.SuspendLayout();
            toolStrip6.SuspendLayout();
            toolStrip2.SuspendLayout();
            toolStrip4.SuspendLayout();
            toolStrip3.SuspendLayout();
            panel3.SuspendLayout();
            toolStrip7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptb1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvDisDetail).BeginInit();
            toolStrip5.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel3, tbEmp, btAddEmp, btDeleteEmp, btSave });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1334, 39);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            toolStrip1.ItemClicked += toolStrip1_ItemClicked;
            // 
            // toolStripLabel3
            // 
            toolStripLabel3.Name = "toolStripLabel3";
            toolStripLabel3.Size = new Size(61, 36);
            toolStripLabel3.Text = "Emp ID";
            // 
            // tbEmp
            // 
            tbEmp.BackColor = SystemColors.InactiveCaption;
            tbEmp.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbEmp.Name = "tbEmp";
            tbEmp.Size = new Size(150, 39);
            // 
            // btAddEmp
            // 
            btAddEmp.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btAddEmp.Image = (Image)resources.GetObject("btAddEmp.Image");
            btAddEmp.ImageTransparentColor = Color.Magenta;
            btAddEmp.Name = "btAddEmp";
            btAddEmp.Size = new Size(36, 36);
            btAddEmp.Text = "Add Emp";
            btAddEmp.Click += btAddEmp_Click;
            // 
            // btDeleteEmp
            // 
            btDeleteEmp.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btDeleteEmp.Image = (Image)resources.GetObject("btDeleteEmp.Image");
            btDeleteEmp.ImageTransparentColor = Color.Magenta;
            btDeleteEmp.Name = "btDeleteEmp";
            btDeleteEmp.Size = new Size(36, 36);
            btDeleteEmp.Text = "DeleteEmp";
            btDeleteEmp.Click += btDeleteEmp_Click;
            // 
            // btSave
            // 
            btSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btSave.Image = (Image)resources.GetObject("btSave.Image");
            btSave.ImageTransparentColor = Color.Magenta;
            btSave.Margin = new Padding(10, 1, 0, 2);
            btSave.Name = "btSave";
            btSave.Size = new Size(36, 36);
            btSave.Text = "Save";
            btSave.Click += btSave_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(gvDis);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(0, 0, 5, 0);
            panel1.Size = new Size(397, 799);
            panel1.TabIndex = 1;
            // 
            // gvDis
            // 
            gvDis.AllowUserToAddRows = false;
            gvDis.AllowUserToDeleteRows = false;
            gvDis.BackgroundColor = Color.White;
            gvDis.ColumnHeadersHeight = 40;
            gvDis.Dock = DockStyle.Fill;
            gvDis.Location = new Point(0, 413);
            gvDis.Name = "gvDis";
            gvDis.ReadOnly = true;
            gvDis.RowTemplate.Height = 25;
            gvDis.Size = new Size(392, 386);
            gvDis.TabIndex = 2;
            gvDis.CellClick += gvDis_CellClick;
            gvDis.CellDoubleClick += gvDis_CellDoubleClick;
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Controls.Add(toolStrip6);
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(toolStrip2);
            panel2.Controls.Add(toolStrip4);
            panel2.Controls.Add(toolStrip3);
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(392, 413);
            panel2.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Bahnschrift", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(0, 385);
            label1.Margin = new Padding(3, 5, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(171, 14);
            label1.TabIndex = 5;
            label1.Text = "***Double-click to view details.";
            // 
            // toolStrip6
            // 
            toolStrip6.ImageScalingSize = new Size(32, 32);
            toolStrip6.Items.AddRange(new ToolStripItem[] { btDelete, btShowOn, btClearAll });
            toolStrip6.Location = new Point(0, 346);
            toolStrip6.Name = "toolStrip6";
            toolStrip6.Size = new Size(392, 39);
            toolStrip6.TabIndex = 7;
            toolStrip6.Text = "toolStrip6";
            // 
            // btDelete
            // 
            btDelete.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btDelete.Image = (Image)resources.GetObject("btDelete.Image");
            btDelete.ImageTransparentColor = Color.Magenta;
            btDelete.Name = "btDelete";
            btDelete.Size = new Size(93, 36);
            btDelete.Text = "Delete";
            btDelete.Click += btDelete_Click;
            // 
            // btShowOn
            // 
            btShowOn.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btShowOn.Image = (Image)resources.GetObject("btShowOn.Image");
            btShowOn.ImageTransparentColor = Color.Magenta;
            btShowOn.Margin = new Padding(5, 1, 0, 2);
            btShowOn.Name = "btShowOn";
            btShowOn.Size = new Size(161, 36);
            btShowOn.Text = "Show On Report";
            btShowOn.Click += btShowOn_Click;
            // 
            // btClearAll
            // 
            btClearAll.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btClearAll.Image = (Image)resources.GetObject("btClearAll.Image");
            btClearAll.ImageTransparentColor = Color.Magenta;
            btClearAll.Name = "btClearAll";
            btClearAll.Size = new Size(36, 36);
            btClearAll.Text = "Clear All";
            btClearAll.Click += btClearAll_Click;
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 317);
            panel5.Name = "panel5";
            panel5.Size = new Size(392, 29);
            panel5.TabIndex = 9;
            // 
            // toolStrip2
            // 
            toolStrip2.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStrip2.ImageScalingSize = new Size(32, 32);
            toolStrip2.Items.AddRange(new ToolStripItem[] { toolStripLabel2, cbbGarmentTypeNumber, btAdd });
            toolStrip2.Location = new Point(0, 278);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(392, 39);
            toolStrip2.TabIndex = 8;
            toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(135, 36);
            toolStripLabel2.Text = "Garment Number";
            // 
            // cbbGarmentTypeNumber
            // 
            cbbGarmentTypeNumber.BackColor = SystemColors.InactiveCaption;
            cbbGarmentTypeNumber.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbGarmentTypeNumber.Margin = new Padding(5, 0, 1, 0);
            cbbGarmentTypeNumber.Name = "cbbGarmentTypeNumber";
            cbbGarmentTypeNumber.Size = new Size(140, 39);
            cbbGarmentTypeNumber.SelectedIndexChanged += cbbGarmentTypeNumber_SelectedIndexChanged;
            // 
            // btAdd
            // 
            btAdd.Alignment = ToolStripItemAlignment.Right;
            btAdd.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btAdd.Image = (Image)resources.GetObject("btAdd.Image");
            btAdd.ImageTransparentColor = Color.Magenta;
            btAdd.Margin = new Padding(10, 1, 0, 2);
            btAdd.Name = "btAdd";
            btAdd.Size = new Size(36, 36);
            btAdd.Text = "Add";
            btAdd.Click += btAdd_Click;
            // 
            // toolStrip4
            // 
            toolStrip4.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStrip4.ImageScalingSize = new Size(32, 32);
            toolStrip4.Items.AddRange(new ToolStripItem[] { toolStripLabel4, cbbGarmentType });
            toolStrip4.Location = new Point(0, 251);
            toolStrip4.Name = "toolStrip4";
            toolStrip4.Size = new Size(392, 27);
            toolStrip4.TabIndex = 4;
            toolStrip4.Text = "toolStrip4";
            // 
            // toolStripLabel4
            // 
            toolStripLabel4.Name = "toolStripLabel4";
            toolStripLabel4.Size = new Size(105, 24);
            toolStripLabel4.Text = "GarmentType";
            // 
            // cbbGarmentType
            // 
            cbbGarmentType.BackColor = SystemColors.InactiveCaption;
            cbbGarmentType.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbGarmentType.Margin = new Padding(5, 0, 1, 0);
            cbbGarmentType.Name = "cbbGarmentType";
            cbbGarmentType.Size = new Size(150, 27);
            cbbGarmentType.SelectedIndexChanged += cbbGarmentType_SelectedIndexChanged;
            // 
            // toolStrip3
            // 
            toolStrip3.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStrip3.ImageScalingSize = new Size(32, 32);
            toolStrip3.Items.AddRange(new ToolStripItem[] { toolStripLabel1, cbbLine });
            toolStrip3.Location = new Point(0, 224);
            toolStrip3.Name = "toolStrip3";
            toolStrip3.Size = new Size(392, 27);
            toolStrip3.TabIndex = 3;
            toolStrip3.Text = "toolStrip3";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(40, 24);
            toolStripLabel1.Text = "Line";
            // 
            // cbbLine
            // 
            cbbLine.BackColor = SystemColors.InactiveCaption;
            cbbLine.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbLine.Margin = new Padding(70, 0, 1, 0);
            cbbLine.Name = "cbbLine";
            cbbLine.Size = new Size(150, 27);
            cbbLine.SelectedIndexChanged += cbbLine_SelectedIndexChanged;
            // 
            // panel3
            // 
            panel3.Controls.Add(toolStrip7);
            panel3.Controls.Add(ptb1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(392, 224);
            panel3.TabIndex = 7;
            // 
            // toolStrip7
            // 
            toolStrip7.ImageScalingSize = new Size(32, 32);
            toolStrip7.Items.AddRange(new ToolStripItem[] { btOperation1 });
            toolStrip7.Location = new Point(0, 0);
            toolStrip7.Name = "toolStrip7";
            toolStrip7.Size = new Size(392, 39);
            toolStrip7.TabIndex = 7;
            toolStrip7.Text = "toolStrip7";
            // 
            // btOperation1
            // 
            btOperation1.Alignment = ToolStripItemAlignment.Right;
            btOperation1.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btOperation1.Image = (Image)resources.GetObject("btOperation1.Image");
            btOperation1.ImageTransparentColor = Color.Magenta;
            btOperation1.Name = "btOperation1";
            btOperation1.Size = new Size(116, 36);
            btOperation1.Text = "Operation";
            btOperation1.Click += btOperation1_Click;
            // 
            // ptb1
            // 
            ptb1.Location = new Point(115, 39);
            ptb1.Name = "ptb1";
            ptb1.Size = new Size(155, 182);
            ptb1.TabIndex = 6;
            ptb1.TabStop = false;
            // 
            // gvDisDetail
            // 
            gvDisDetail.AllowUserToAddRows = false;
            gvDisDetail.AllowUserToDeleteRows = false;
            gvDisDetail.BackgroundColor = Color.White;
            gvDisDetail.ColumnHeadersHeight = 40;
            gvDisDetail.Dock = DockStyle.Fill;
            gvDisDetail.Location = new Point(0, 39);
            gvDisDetail.Name = "gvDisDetail";
            gvDisDetail.RowTemplate.Height = 25;
            gvDisDetail.Size = new Size(1334, 760);
            gvDisDetail.TabIndex = 2;
            gvDisDetail.CellClick += gvDisDetail_CellClick;
            // 
            // toolStrip5
            // 
            toolStrip5.Dock = DockStyle.Left;
            toolStrip5.ImageScalingSize = new Size(32, 32);
            toolStrip5.Items.AddRange(new ToolStripItem[] { btUp, btDown });
            toolStrip5.Location = new Point(397, 0);
            toolStrip5.Name = "toolStrip5";
            toolStrip5.Size = new Size(37, 799);
            toolStrip5.TabIndex = 3;
            toolStrip5.Text = "toolStrip5";
            // 
            // btUp
            // 
            btUp.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btUp.Image = (Image)resources.GetObject("btUp.Image");
            btUp.ImageTransparentColor = Color.Magenta;
            btUp.Margin = new Padding(0, 40, 0, 2);
            btUp.Name = "btUp";
            btUp.Size = new Size(34, 36);
            btUp.Text = "Up";
            btUp.Click += btUp_Click;
            // 
            // btDown
            // 
            btDown.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btDown.Image = (Image)resources.GetObject("btDown.Image");
            btDown.ImageTransparentColor = Color.Magenta;
            btDown.Margin = new Padding(0, 10, 0, 2);
            btDown.Name = "btDown";
            btDown.Size = new Size(34, 36);
            btDown.Text = "Down";
            btDown.Click += btDown_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(gvDisDetail);
            panel4.Controls.Add(toolStrip1);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(434, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(1334, 799);
            panel4.TabIndex = 4;
            // 
            // EmpSkillofEachgarment
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1768, 799);
            Controls.Add(panel4);
            Controls.Add(toolStrip5);
            Controls.Add(panel1);
            Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "EmpSkillofEachgarment";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EmpSkillofEachgarment";
            WindowState = FormWindowState.Maximized;
            Load += EmpSkillofEachgarment_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gvDis).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            toolStrip6.ResumeLayout(false);
            toolStrip6.PerformLayout();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            toolStrip4.ResumeLayout(false);
            toolStrip4.PerformLayout();
            toolStrip3.ResumeLayout(false);
            toolStrip3.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            toolStrip7.ResumeLayout(false);
            toolStrip7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ptb1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvDisDetail).EndInit();
            toolStrip5.ResumeLayout(false);
            toolStrip5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private Panel panel1;
        private DataGridView gvDis;
        private ToolStrip toolStrip3;
        private DataGridView gvDisDetail;
        private ToolStripLabel toolStripLabel1;
        private ToolStripComboBox cbbLine;
        private ToolStrip toolStrip4;
        private ToolStripLabel toolStripLabel4;
        private ToolStripComboBox cbbGarmentType;
        private Label label1;
        private ToolStripButton btLoad;
        private Panel panel2;
        private PictureBox ptb1;
        private Panel panel3;
        private ToolStrip toolStrip2;
        private ToolStripLabel toolStripLabel2;
        private ToolStripComboBox cbbGarmentTypeNumber;
        private ToolStripButton btAdd;
        private ToolStripButton btSave;
        private ToolStrip toolStrip5;
        private ToolStripButton btUp;
        private ToolStripButton btDown;
        private ToolStrip toolStrip6;
        private ToolStripButton btDelete;
        private ToolStripButton btShowOn;
        private Panel panel4;
        private ToolStrip toolStrip7;
        private ToolStripButton btOperation1;
        private ToolStripLabel toolStripLabel3;
        private ToolStripTextBox tbEmp;
        private ToolStripButton btAddEmp;
        private Panel panel5;
        private ToolStripButton btDeleteEmp;
        private ToolStripButton btClearAll;
    }
}