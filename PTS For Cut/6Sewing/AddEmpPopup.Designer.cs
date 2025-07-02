namespace PTS_For_Cut._6Sewing
{
    partial class AddEmpPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEmpPopup));
            appData1 = new _Main.AppData();
            ptb1 = new PictureBox();
            panel1 = new Panel();
            toolStrip1 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            tbEmpIDName = new ToolStripTextBox();
            toolStrip2 = new ToolStrip();
            toolStripLabel2 = new ToolStripLabel();
            tbStatus = new ToolStripTextBox();
            toolStrip3 = new ToolStrip();
            toolStripLabel3 = new ToolStripLabel();
            cbbOperation = new ToolStripComboBox();
            toolStrip4 = new ToolStrip();
            btAddEmp = new ToolStripButton();
            btClose = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)appData1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ptb1).BeginInit();
            panel1.SuspendLayout();
            toolStrip1.SuspendLayout();
            toolStrip2.SuspendLayout();
            toolStrip3.SuspendLayout();
            toolStrip4.SuspendLayout();
            SuspendLayout();
            // 
            // appData1
            // 
            appData1.DataSetName = "AppData";
            appData1.Namespace = "http://tempuri.org/AppData.xsd";
            appData1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ptb1
            // 
            ptb1.Location = new Point(92, 0);
            ptb1.Name = "ptb1";
            ptb1.Size = new Size(203, 218);
            ptb1.SizeMode = PictureBoxSizeMode.StretchImage;
            ptb1.TabIndex = 0;
            ptb1.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(ptb1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(402, 218);
            panel1.TabIndex = 1;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1, tbEmpIDName });
            toolStrip1.Location = new Point(0, 218);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(402, 27);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(42, 24);
            toolStripLabel1.Text = "Emp";
            // 
            // tbEmpIDName
            // 
            tbEmpIDName.BackColor = SystemColors.InactiveCaption;
            tbEmpIDName.Enabled = false;
            tbEmpIDName.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbEmpIDName.Name = "tbEmpIDName";
            tbEmpIDName.Size = new Size(300, 27);
            // 
            // toolStrip2
            // 
            toolStrip2.ImageScalingSize = new Size(32, 32);
            toolStrip2.Items.AddRange(new ToolStripItem[] { toolStripLabel2, tbStatus });
            toolStrip2.Location = new Point(0, 245);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(402, 29);
            toolStrip2.TabIndex = 3;
            toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(55, 26);
            toolStripLabel2.Text = "Status";
            // 
            // tbStatus
            // 
            tbStatus.BackColor = SystemColors.InactiveCaption;
            tbStatus.Enabled = false;
            tbStatus.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            tbStatus.Name = "tbStatus";
            tbStatus.Size = new Size(100, 29);
            // 
            // toolStrip3
            // 
            toolStrip3.ImageScalingSize = new Size(32, 32);
            toolStrip3.Items.AddRange(new ToolStripItem[] { toolStripLabel3, cbbOperation });
            toolStrip3.Location = new Point(0, 274);
            toolStrip3.Name = "toolStrip3";
            toolStrip3.Size = new Size(402, 27);
            toolStrip3.TabIndex = 4;
            toolStrip3.Text = "toolStrip3";
            // 
            // toolStripLabel3
            // 
            toolStripLabel3.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel3.Name = "toolStripLabel3";
            toolStripLabel3.Size = new Size(80, 24);
            toolStripLabel3.Text = "Operation";
            // 
            // cbbOperation
            // 
            cbbOperation.BackColor = SystemColors.InactiveCaption;
            cbbOperation.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbOperation.Name = "cbbOperation";
            cbbOperation.Size = new Size(200, 27);
            // 
            // toolStrip4
            // 
            toolStrip4.ImageScalingSize = new Size(84, 84);
            toolStrip4.Items.AddRange(new ToolStripItem[] { btAddEmp, btClose });
            toolStrip4.Location = new Point(0, 301);
            toolStrip4.Name = "toolStrip4";
            toolStrip4.Size = new Size(402, 140);
            toolStrip4.TabIndex = 5;
            toolStrip4.Text = "toolStrip4";
            // 
            // btAddEmp
            // 
            btAddEmp.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btAddEmp.Image = (Image)resources.GetObject("btAddEmp.Image");
            btAddEmp.ImageTransparentColor = Color.Magenta;
            btAddEmp.Margin = new Padding(80, 50, 0, 2);
            btAddEmp.Name = "btAddEmp";
            btAddEmp.Size = new Size(88, 88);
            btAddEmp.Text = "AddEmp";
            btAddEmp.Click += btAddEmp_Click;
            // 
            // btClose
            // 
            btClose.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btClose.Image = (Image)resources.GetObject("btClose.Image");
            btClose.ImageTransparentColor = Color.Magenta;
            btClose.Margin = new Padding(30, 50, 0, 2);
            btClose.Name = "btClose";
            btClose.Size = new Size(88, 88);
            btClose.Text = "Close";
            btClose.Click += btClose_Click;
            // 
            // AddEmpPopup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonShadow;
            ClientSize = new Size(402, 591);
            Controls.Add(toolStrip4);
            Controls.Add(toolStrip3);
            Controls.Add(toolStrip2);
            Controls.Add(toolStrip1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddEmpPopup";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddEmpPopup";
            Load += AddEmpPopup_Load;
            ((System.ComponentModel.ISupportInitialize)appData1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ptb1).EndInit();
            panel1.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            toolStrip3.ResumeLayout(false);
            toolStrip3.PerformLayout();
            toolStrip4.ResumeLayout(false);
            toolStrip4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private _Main.AppData appData1;
        private PictureBox ptb1;
        private Panel panel1;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripTextBox tbEmpIDName;
        private ToolStrip toolStrip2;
        private ToolStripLabel toolStripLabel2;
        private ToolStripTextBox tbStatus;
        private ToolStrip toolStrip3;
        private ToolStripLabel toolStripLabel3;
        private ToolStripComboBox cbbOperation;
        private ToolStrip toolStrip4;
        private ToolStripButton btAddEmp;
        private ToolStripButton btClose;
    }
}