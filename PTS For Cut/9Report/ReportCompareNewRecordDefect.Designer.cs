namespace PTS_For_Cut._9Report
{
    partial class ReportCompareNewRecordDefect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportCompareNewRecordDefect));
            toolStrip1 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            cbbDev = new ToolStripComboBox();
            toolStripLabel2 = new ToolStripLabel();
            cbbColor = new ToolStripComboBox();
            toolStripLabel3 = new ToolStripLabel();
            cbbSize = new ToolStripComboBox();
            btSearch = new ToolStripButton();
            toolStrip2 = new ToolStrip();
            toolStripLabel4 = new ToolStripLabel();
            tbQTY = new ToolStripTextBox();
            btSave = new ToolStripButton();
            btUpdate = new ToolStripButton();
            btDelete = new ToolStripButton();
            panel1 = new Panel();
            label1 = new Label();
            toolStrip3 = new ToolStrip();
            toolStripLabel5 = new ToolStripLabel();
            cbbDefect = new ToolStripComboBox();
            gvDis = new DataGridView();
            toolStrip1.SuspendLayout();
            toolStrip2.SuspendLayout();
            panel1.SuspendLayout();
            toolStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvDis).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1, cbbDev, toolStripLabel2, cbbColor, toolStripLabel3, cbbSize, btSearch });
            toolStrip1.Location = new Point(0, 63);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1101, 39);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Margin = new Padding(100, 1, 0, 2);
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(96, 36);
            toolStripLabel1.Text = "Department";
            // 
            // cbbDev
            // 
            cbbDev.BackColor = SystemColors.InactiveCaption;
            cbbDev.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbDev.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbDev.Name = "cbbDev";
            cbbDev.Size = new Size(200, 39);
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(49, 36);
            toolStripLabel2.Text = "Color";
            // 
            // cbbColor
            // 
            cbbColor.BackColor = SystemColors.InactiveCaption;
            cbbColor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbColor.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbColor.Name = "cbbColor";
            cbbColor.Size = new Size(200, 39);
            // 
            // toolStripLabel3
            // 
            toolStripLabel3.Name = "toolStripLabel3";
            toolStripLabel3.Size = new Size(40, 36);
            toolStripLabel3.Text = "Size";
            // 
            // cbbSize
            // 
            cbbSize.BackColor = SystemColors.InactiveCaption;
            cbbSize.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbSize.DropDownWidth = 85;
            cbbSize.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbSize.Name = "cbbSize";
            cbbSize.Size = new Size(75, 39);
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
            // toolStrip2
            // 
            toolStrip2.ImageScalingSize = new Size(42, 42);
            toolStrip2.Items.AddRange(new ToolStripItem[] { toolStripLabel4, tbQTY, btSave, btUpdate, btDelete });
            toolStrip2.Location = new Point(0, 127);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(1101, 61);
            toolStrip2.TabIndex = 1;
            toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel4
            // 
            toolStripLabel4.Font = new Font("Bahnschrift", 36F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel4.Margin = new Padding(300, 1, 0, 2);
            toolStripLabel4.Name = "toolStripLabel4";
            toolStripLabel4.Size = new Size(107, 58);
            toolStripLabel4.Text = "QTY";
            // 
            // tbQTY
            // 
            tbQTY.BackColor = SystemColors.ControlLight;
            tbQTY.Font = new Font("Bahnschrift", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            tbQTY.Name = "tbQTY";
            tbQTY.Size = new Size(150, 61);
            tbQTY.KeyPress += tbQTY_KeyPress;
            // 
            // btSave
            // 
            btSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btSave.Image = (Image)resources.GetObject("btSave.Image");
            btSave.ImageTransparentColor = Color.Magenta;
            btSave.Margin = new Padding(20, 1, 0, 2);
            btSave.Name = "btSave";
            btSave.Size = new Size(46, 58);
            btSave.Text = "toolStripButton1";
            btSave.Click += btSave_Click;
            // 
            // btUpdate
            // 
            btUpdate.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btUpdate.Image = (Image)resources.GetObject("btUpdate.Image");
            btUpdate.ImageTransparentColor = Color.Magenta;
            btUpdate.Margin = new Padding(20, 1, 0, 2);
            btUpdate.Name = "btUpdate";
            btUpdate.Size = new Size(46, 58);
            btUpdate.Text = "update";
            btUpdate.Click += btUpdate_Click;
            // 
            // btDelete
            // 
            btDelete.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btDelete.Image = (Image)resources.GetObject("btDelete.Image");
            btDelete.ImageTransparentColor = Color.Magenta;
            btDelete.Margin = new Padding(20, 1, 0, 2);
            btDelete.Name = "btDelete";
            btDelete.Size = new Size(46, 58);
            btDelete.Text = "Delete";
            btDelete.Click += btDelete_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1101, 63);
            panel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Bahnschrift", 36F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(100, 0, 3, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(350, 0, 0, 0);
            label1.Size = new Size(678, 58);
            label1.TabIndex = 0;
            label1.Text = "Defect Record";
            // 
            // toolStrip3
            // 
            toolStrip3.Items.AddRange(new ToolStripItem[] { toolStripLabel5, cbbDefect });
            toolStrip3.Location = new Point(0, 102);
            toolStrip3.Name = "toolStrip3";
            toolStrip3.Size = new Size(1101, 25);
            toolStrip3.TabIndex = 3;
            toolStrip3.Text = "toolStrip3";
            // 
            // toolStripLabel5
            // 
            toolStripLabel5.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel5.Margin = new Padding(100, 1, 0, 2);
            toolStripLabel5.Name = "toolStripLabel5";
            toolStripLabel5.Size = new Size(86, 22);
            toolStripLabel5.Text = "Defect List";
            // 
            // cbbDefect
            // 
            cbbDefect.BackColor = SystemColors.InactiveCaption;
            cbbDefect.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbDefect.Font = new Font("Bahnschrift", 9F, FontStyle.Regular, GraphicsUnit.Point);
            cbbDefect.Margin = new Padding(12, 0, 1, 0);
            cbbDefect.Name = "cbbDefect";
            cbbDefect.Size = new Size(570, 25);
            // 
            // gvDis
            // 
            gvDis.AllowUserToAddRows = false;
            gvDis.AllowUserToDeleteRows = false;
            gvDis.BackgroundColor = Color.White;
            gvDis.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvDis.Dock = DockStyle.Fill;
            gvDis.Location = new Point(0, 188);
            gvDis.Name = "gvDis";
            gvDis.ReadOnly = true;
            gvDis.RowTemplate.Height = 25;
            gvDis.Size = new Size(1101, 384);
            gvDis.TabIndex = 4;
            gvDis.CellDoubleClick += gvDis_CellDoubleClick;
            // 
            // ReportCompareNewRecordDefect
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1101, 572);
            Controls.Add(gvDis);
            Controls.Add(toolStrip2);
            Controls.Add(toolStrip3);
            Controls.Add(toolStrip1);
            Controls.Add(panel1);
            Name = "ReportCompareNewRecordDefect";
            Text = "ReportCompareNewRecordDefect";
            FormClosed += ReportCompareNewRecordDefect_FormClosed;
            Load += ReportCompareNewRecordDefect_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            toolStrip3.ResumeLayout(false);
            toolStrip3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gvDis).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripComboBox cbbDev;
        private ToolStripLabel toolStripLabel2;
        private ToolStripComboBox cbbColor;
        private ToolStripLabel toolStripLabel3;
        private ToolStripComboBox cbbSize;
        private ToolStrip toolStrip2;
        private ToolStripLabel toolStripLabel4;
        private ToolStripTextBox tbQTY;
        private ToolStripButton btSave;
        private Panel panel1;
        private Label label1;
        private ToolStrip toolStrip3;
        private ToolStripLabel toolStripLabel5;
        private ToolStripComboBox cbbDefect;
        private ToolStripButton btSearch;
        private ToolStripButton btUpdate;
        private ToolStripButton btDelete;
        private DataGridView gvDis;
    }
}