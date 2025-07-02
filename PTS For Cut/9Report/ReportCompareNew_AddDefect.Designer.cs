namespace PTS_For_Cut._9Report
{
    partial class ReportCompareNew_AddDefect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportCompareNew_AddDefect));
            gvDis = new DataGridView();
            toolStrip1 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            tbDefect = new ToolStripTextBox();
            btadd = new ToolStripButton();
            btEdit = new ToolStripButton();
            btDelete = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)gvDis).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // gvDis
            // 
            gvDis.AllowUserToAddRows = false;
            gvDis.AllowUserToDeleteRows = false;
            gvDis.BackgroundColor = Color.White;
            gvDis.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvDis.Dock = DockStyle.Fill;
            gvDis.Location = new Point(0, 39);
            gvDis.Name = "gvDis";
            gvDis.ReadOnly = true;
            gvDis.RowTemplate.Height = 25;
            gvDis.Size = new Size(771, 545);
            gvDis.TabIndex = 0;
            gvDis.CellContentClick += gvDis_CellContentClick;
            gvDis.CellDoubleClick += gvDis_CellDoubleClick;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1, tbDefect, btadd, btEdit, btDelete });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(771, 39);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(56, 36);
            toolStripLabel1.Text = "Defect";
            // 
            // tbDefect
            // 
            tbDefect.BackColor = SystemColors.ActiveCaption;
            tbDefect.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbDefect.Name = "tbDefect";
            tbDefect.Size = new Size(400, 39);
            // 
            // btadd
            // 
            btadd.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btadd.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btadd.Image = (Image)resources.GetObject("btadd.Image");
            btadd.ImageTransparentColor = Color.Magenta;
            btadd.Margin = new Padding(10, 1, 0, 2);
            btadd.Name = "btadd";
            btadd.Size = new Size(36, 36);
            btadd.Text = "Add";
            btadd.Click += btadd_Click;
            // 
            // btEdit
            // 
            btEdit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btEdit.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btEdit.Image = (Image)resources.GetObject("btEdit.Image");
            btEdit.ImageTransparentColor = Color.Magenta;
            btEdit.Margin = new Padding(10, 1, 0, 2);
            btEdit.Name = "btEdit";
            btEdit.Size = new Size(36, 36);
            btEdit.Text = "toolStripButton2";
            btEdit.Visible = false;
            btEdit.Click += btEdit_Click;
            // 
            // btDelete
            // 
            btDelete.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btDelete.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btDelete.Image = (Image)resources.GetObject("btDelete.Image");
            btDelete.ImageTransparentColor = Color.Magenta;
            btDelete.Margin = new Padding(10, 1, 0, 2);
            btDelete.Name = "btDelete";
            btDelete.Size = new Size(36, 36);
            btDelete.Text = "toolStripButton1";
            btDelete.Click += btDelete_Click;
            // 
            // ReportCompareNew_AddDefect
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(771, 584);
            Controls.Add(gvDis);
            Controls.Add(toolStrip1);
            Name = "ReportCompareNew_AddDefect";
            Text = "ReportCompareNew_AddDefect";
            FormClosed += ReportCompareNew_AddDefect_FormClosed;
            Load += ReportCompareNew_AddDefect_Load;
            ((System.ComponentModel.ISupportInitialize)gvDis).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView gvDis;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripTextBox tbDefect;
        private ToolStripButton btadd;
        private ToolStripButton btEdit;
        private ToolStripButton btDelete;
    }
}