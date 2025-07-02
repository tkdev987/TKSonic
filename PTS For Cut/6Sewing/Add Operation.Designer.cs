namespace PTS_For_Cut._6Sewing
{
    partial class Add_Operation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add_Operation));
            ptb1 = new PictureBox();
            panel1 = new Panel();
            panel2 = new Panel();
            label1 = new Label();
            toolStrip1 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            cbbGarmentType = new ToolStripComboBox();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripLabel2 = new ToolStripLabel();
            cbbGarmentTypeNumber = new ToolStripComboBox();
            toolStripSeparator2 = new ToolStripSeparator();
            btNew1 = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            btLoad = new ToolStripButton();
            btSave = new ToolStripButton();
            btDeleteGarmentNumber = new ToolStripButton();
            toolStrip4 = new ToolStrip();
            toolStripLabel5 = new ToolStripLabel();
            tbOperation = new ToolStripTextBox();
            btAdd = new ToolStripButton();
            btEdit = new ToolStripButton();
            btDelete = new ToolStripButton();
            gvDis = new DataGridView();
            toolStrip2 = new ToolStrip();
            btImg = new ToolStripButton();
            btUp = new ToolStripButton();
            btDown = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)ptb1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            toolStrip1.SuspendLayout();
            toolStrip4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvDis).BeginInit();
            toolStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // ptb1
            // 
            ptb1.Dock = DockStyle.Left;
            ptb1.Location = new Point(0, 0);
            ptb1.Margin = new Padding(4);
            ptb1.Name = "ptb1";
            ptb1.Size = new Size(153, 189);
            ptb1.SizeMode = PictureBoxSizeMode.StretchImage;
            ptb1.TabIndex = 0;
            ptb1.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(toolStrip1);
            panel1.Controls.Add(ptb1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(0, 0, 0, 10);
            panel1.Size = new Size(1309, 199);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(label1);
            panel2.Location = new Point(153, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(951, 79);
            panel2.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift Condensed", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(326, 9);
            label1.Name = "label1";
            label1.Size = new Size(356, 45);
            label1.TabIndex = 0;
            label1.Text = "Operations of Garment Type";
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.Bottom;
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1, cbbGarmentType, toolStripSeparator1, toolStripLabel2, cbbGarmentTypeNumber, toolStripSeparator2, btNew1, toolStripSeparator3, btLoad, btSave, btDeleteGarmentNumber });
            toolStrip1.Location = new Point(153, 150);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1156, 39);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(109, 36);
            toolStripLabel1.Text = "Garment Type";
            // 
            // cbbGarmentType
            // 
            cbbGarmentType.BackColor = SystemColors.InactiveCaption;
            cbbGarmentType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbGarmentType.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbGarmentType.Name = "cbbGarmentType";
            cbbGarmentType.Size = new Size(168, 39);
            cbbGarmentType.SelectedIndexChanged += cbbGarmentType_SelectedIndexChanged;
            cbbGarmentType.Click += cbbGarmentType_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 39);
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel2.Margin = new Padding(10, 1, 0, 2);
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(172, 36);
            toolStripLabel2.Text = "Garment Type Number";
            // 
            // cbbGarmentTypeNumber
            // 
            cbbGarmentTypeNumber.BackColor = SystemColors.InactiveCaption;
            cbbGarmentTypeNumber.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbGarmentTypeNumber.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbGarmentTypeNumber.Name = "cbbGarmentTypeNumber";
            cbbGarmentTypeNumber.Size = new Size(168, 39);
            cbbGarmentTypeNumber.SelectedIndexChanged += cbbGarmentTypeNumber_SelectedIndexChanged;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Margin = new Padding(10, 0, 0, 0);
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 39);
            // 
            // btNew1
            // 
            btNew1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btNew1.Image = (Image)resources.GetObject("btNew1.Image");
            btNew1.ImageTransparentColor = Color.Magenta;
            btNew1.Margin = new Padding(10, 1, 0, 2);
            btNew1.Name = "btNew1";
            btNew1.Size = new Size(36, 36);
            btNew1.Text = "New Garment Number";
            btNew1.Click += btNew1_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Margin = new Padding(10, 0, 0, 0);
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 39);
            // 
            // btLoad
            // 
            btLoad.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btLoad.Image = (Image)resources.GetObject("btLoad.Image");
            btLoad.ImageTransparentColor = Color.Magenta;
            btLoad.Margin = new Padding(10, 1, 0, 2);
            btLoad.Name = "btLoad";
            btLoad.Size = new Size(119, 36);
            btLoad.Text = "Load Data";
            btLoad.Click += btLoad_Click;
            // 
            // btSave
            // 
            btSave.Alignment = ToolStripItemAlignment.Right;
            btSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btSave.Image = (Image)resources.GetObject("btSave.Image");
            btSave.ImageTransparentColor = Color.Magenta;
            btSave.Name = "btSave";
            btSave.Size = new Size(36, 36);
            btSave.Text = "Save";
            btSave.Click += btSave_Click_1;
            // 
            // btDeleteGarmentNumber
            // 
            btDeleteGarmentNumber.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btDeleteGarmentNumber.Image = (Image)resources.GetObject("btDeleteGarmentNumber.Image");
            btDeleteGarmentNumber.ImageTransparentColor = Color.Magenta;
            btDeleteGarmentNumber.Margin = new Padding(10, 1, 0, 2);
            btDeleteGarmentNumber.Name = "btDeleteGarmentNumber";
            btDeleteGarmentNumber.Size = new Size(223, 36);
            btDeleteGarmentNumber.Text = "Delete Garment Number";
            btDeleteGarmentNumber.Click += btDeleteGarmentNumber_Click;
            // 
            // toolStrip4
            // 
            toolStrip4.ImageScalingSize = new Size(32, 32);
            toolStrip4.Items.AddRange(new ToolStripItem[] { toolStripLabel5, tbOperation, btAdd, btEdit, btDelete });
            toolStrip4.Location = new Point(37, 199);
            toolStrip4.Margin = new Padding(0, 20, 0, 0);
            toolStrip4.Name = "toolStrip4";
            toolStrip4.Size = new Size(1272, 39);
            toolStrip4.TabIndex = 4;
            toolStrip4.Text = "toolStrip4";
            // 
            // toolStripLabel5
            // 
            toolStripLabel5.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel5.Name = "toolStripLabel5";
            toolStripLabel5.Size = new Size(127, 36);
            toolStripLabel5.Text = "Operation Name";
            // 
            // tbOperation
            // 
            tbOperation.BackColor = SystemColors.InactiveCaption;
            tbOperation.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbOperation.Name = "tbOperation";
            tbOperation.Size = new Size(350, 39);
            // 
            // btAdd
            // 
            btAdd.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btAdd.Image = (Image)resources.GetObject("btAdd.Image");
            btAdd.ImageTransparentColor = Color.Magenta;
            btAdd.Margin = new Padding(20, 1, 0, 2);
            btAdd.Name = "btAdd";
            btAdd.Size = new Size(36, 36);
            btAdd.Text = "Add";
            btAdd.Click += btAdd_Click;
            // 
            // btEdit
            // 
            btEdit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btEdit.Image = (Image)resources.GetObject("btEdit.Image");
            btEdit.ImageTransparentColor = Color.Magenta;
            btEdit.Margin = new Padding(20, 1, 0, 2);
            btEdit.Name = "btEdit";
            btEdit.Size = new Size(36, 36);
            btEdit.Text = "Edit";
            btEdit.Click += btEdit_Click;
            // 
            // btDelete
            // 
            btDelete.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btDelete.Image = (Image)resources.GetObject("btDelete.Image");
            btDelete.ImageTransparentColor = Color.Magenta;
            btDelete.Margin = new Padding(10, 1, 0, 2);
            btDelete.Name = "btDelete";
            btDelete.Size = new Size(36, 36);
            btDelete.Text = "Delete";
            btDelete.Click += btDelete_Click;
            // 
            // gvDis
            // 
            gvDis.AllowUserToAddRows = false;
            gvDis.AllowUserToDeleteRows = false;
            gvDis.BackgroundColor = Color.White;
            gvDis.ColumnHeadersHeight = 40;
            gvDis.Dock = DockStyle.Fill;
            gvDis.Location = new Point(37, 238);
            gvDis.Name = "gvDis";
            gvDis.ReadOnly = true;
            gvDis.RowTemplate.Height = 25;
            gvDis.Size = new Size(1272, 571);
            gvDis.TabIndex = 2;
            gvDis.CellClick += gvDis_CellClick;
            // 
            // toolStrip2
            // 
            toolStrip2.Dock = DockStyle.Left;
            toolStrip2.ImageScalingSize = new Size(32, 32);
            toolStrip2.Items.AddRange(new ToolStripItem[] { btImg, btUp, btDown });
            toolStrip2.Location = new Point(0, 199);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(37, 610);
            toolStrip2.TabIndex = 3;
            toolStrip2.Text = "toolStrip2";
            // 
            // btImg
            // 
            btImg.BackColor = SystemColors.ScrollBar;
            btImg.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btImg.Image = (Image)resources.GetObject("btImg.Image");
            btImg.ImageTransparentColor = Color.Magenta;
            btImg.Name = "btImg";
            btImg.Size = new Size(34, 36);
            btImg.Text = "Upload Image";
            btImg.Click += btImg_Click;
            // 
            // btUp
            // 
            btUp.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btUp.Image = (Image)resources.GetObject("btUp.Image");
            btUp.ImageTransparentColor = Color.Magenta;
            btUp.Margin = new Padding(0, 10, 0, 2);
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
            btDown.Margin = new Padding(0, 20, 0, 2);
            btDown.Name = "btDown";
            btDown.Size = new Size(34, 36);
            btDown.Text = "Down";
            btDown.Click += btDown_Click;
            // 
            // Add_Operation
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1309, 809);
            Controls.Add(gvDis);
            Controls.Add(toolStrip4);
            Controls.Add(toolStrip2);
            Controls.Add(panel1);
            Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "Add_Operation";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add_Operation";
            Load += Add_Operation_Load;
            ((System.ComponentModel.ISupportInitialize)ptb1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            toolStrip4.ResumeLayout(false);
            toolStrip4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gvDis).EndInit();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox ptb1;
        private Panel panel1;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripComboBox cbbGarmentType;
        private ToolStripLabel toolStripLabel2;
        private ToolStripComboBox cbbGarmentTypeNumber;
        private ToolStripButton btLoad;
        private ToolStrip toolStrip4;
        private ToolStripLabel toolStripLabel5;
        private ToolStripTextBox tbOperation;
        private ToolStripButton btAdd;
        private DataGridView gvDis;
        private ToolStripButton btDelete;
        private ToolStripButton btEdit;
        private ToolStripButton btNew1;
        private ToolStripButton btAddPic1;
        private Panel panel2;
        private Label label1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStrip toolStrip2;
        private ToolStripButton btUp;
        private ToolStripButton btDown;
        private ToolStripButton btSave;
        private ToolStripButton btImg;
        private ToolStripButton btDeleteGarmentNumber;
    }
}