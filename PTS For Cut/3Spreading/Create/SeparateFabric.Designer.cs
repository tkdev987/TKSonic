namespace PTS_For_Cut._3Spreading.Create
{
    partial class SeparateFabric
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeparateFabric));
            gvDis = new DataGridView();
            toolStrip1 = new ToolStrip();
            btSave = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btSaveEdit = new ToolStripButton();
            toolStripLabel2 = new ToolStripLabel();
            lbMarklength = new ToolStripLabel();
            toolStripLabel3 = new ToolStripLabel();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripLabel1 = new ToolStripLabel();
            tbPlies = new ToolStripTextBox();
            btConfirm = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)gvDis).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // gvDis
            // 
            gvDis.AllowUserToAddRows = false;
            gvDis.AllowUserToDeleteRows = false;
            gvDis.BackgroundColor = SystemColors.Control;
            gvDis.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvDis.GridColor = SystemColors.ControlDarkDark;
            gvDis.Location = new Point(12, 42);
            gvDis.Name = "gvDis";
            gvDis.RowTemplate.Height = 25;
            gvDis.Size = new Size(776, 396);
            gvDis.TabIndex = 0;
            gvDis.CellEndEdit += gvDis_CellEndEdit;
            gvDis.EditingControlShowing += gvDis_EditingControlShowing;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btSave, toolStripSeparator1, btSaveEdit, toolStripLabel2, lbMarklength, toolStripLabel3, toolStripSeparator2, toolStripLabel1, tbPlies, btConfirm });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(799, 39);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            toolStrip1.ItemClicked += toolStrip1_ItemClicked;
            // 
            // btSave
            // 
            btSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btSave.Image = (Image)resources.GetObject("btSave.Image");
            btSave.ImageTransparentColor = Color.Magenta;
            btSave.Name = "btSave";
            btSave.Size = new Size(36, 36);
            btSave.Text = "Save";
            btSave.Click += btSave_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 39);
            // 
            // btSaveEdit
            // 
            btSaveEdit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btSaveEdit.Image = (Image)resources.GetObject("btSaveEdit.Image");
            btSaveEdit.ImageTransparentColor = Color.Magenta;
            btSaveEdit.Name = "btSaveEdit";
            btSaveEdit.Size = new Size(36, 36);
            btSaveEdit.Text = "Edit";
            btSaveEdit.Visible = false;
            btSaveEdit.Click += btSaveEdit_Click;
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(105, 36);
            toolStripLabel2.Text = "Mark Length :";
            // 
            // lbMarklength
            // 
            lbMarklength.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbMarklength.Name = "lbMarklength";
            lbMarklength.Size = new Size(31, 36);
            lbMarklength.Text = "xxx";
            // 
            // toolStripLabel3
            // 
            toolStripLabel3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel3.Name = "toolStripLabel3";
            toolStripLabel3.Size = new Size(39, 36);
            toolStripLabel3.Text = "YDS";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 39);
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(106, 36);
            toolStripLabel1.Text = "Plies Balance :";
            // 
            // tbPlies
            // 
            tbPlies.BackColor = SystemColors.ScrollBar;
            tbPlies.BorderStyle = BorderStyle.None;
            tbPlies.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbPlies.Name = "tbPlies";
            tbPlies.Size = new Size(70, 39);
            // 
            // btConfirm
            // 
            btConfirm.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btConfirm.Image = (Image)resources.GetObject("btConfirm.Image");
            btConfirm.ImageTransparentColor = Color.Magenta;
            btConfirm.Name = "btConfirm";
            btConfirm.Size = new Size(36, 36);
            btConfirm.Text = "btCal";
            btConfirm.Click += btConfirm_Click;
            // 
            // SeparateFabric
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(799, 450);
            Controls.Add(toolStrip1);
            Controls.Add(gvDis);
            Name = "SeparateFabric";
            Text = "SeparateFabric";
            FormClosed += SeparateFabric_FormClosed;
            Load += SeparateFabric_Load;
            ((System.ComponentModel.ISupportInitialize)gvDis).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView gvDis;
        private ToolStrip toolStrip1;
        private ToolStripButton btSave;
        private ToolStripButton btSaveEdit;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripTextBox tbPlies;
        private ToolStripButton btConfirm;
        private ToolStripLabel toolStripLabel2;
        private ToolStripLabel lbMarklength;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripLabel toolStripLabel3;
    }
}