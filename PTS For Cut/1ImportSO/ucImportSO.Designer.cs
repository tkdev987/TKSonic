namespace PTS_For_Cut.ImportSO
{
    partial class ucImportSO
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucImportSO));
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            gvExcel = new DataGridView();
            toolStrip1 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            tbFileName1 = new ToolStripTextBox();
            btImport = new ToolStripButton();
            btSave = new ToolStripButton();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvExcel).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(toolStrip1);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1352, 119);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(521, 0);
            label1.Name = "label1";
            label1.Size = new Size(246, 40);
            label1.TabIndex = 0;
            label1.Text = "Import Sale Order";
            // 
            // panel2
            // 
            panel2.Controls.Add(gvExcel);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 119);
            panel2.Name = "panel2";
            panel2.Size = new Size(1352, 612);
            panel2.TabIndex = 2;
            // 
            // gvExcel
            // 
            gvExcel.AllowUserToAddRows = false;
            gvExcel.AllowUserToDeleteRows = false;
            gvExcel.BackgroundColor = SystemColors.Control;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.Gainsboro;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            gvExcel.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            gvExcel.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            gvExcel.DefaultCellStyle = dataGridViewCellStyle4;
            gvExcel.Dock = DockStyle.Fill;
            gvExcel.EnableHeadersVisualStyles = false;
            gvExcel.Location = new Point(0, 0);
            gvExcel.Name = "gvExcel";
            gvExcel.ReadOnly = true;
            gvExcel.RowHeadersWidth = 15;
            gvExcel.RowTemplate.Height = 35;
            gvExcel.Size = new Size(1352, 612);
            gvExcel.TabIndex = 9;
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.Bottom;
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1, tbFileName1, btImport, btSave });
            toolStrip1.Location = new Point(0, 80);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1352, 39);
            toolStrip1.TabIndex = 14;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(57, 36);
            toolStripLabel1.Text = "Search";
            // 
            // tbFileName1
            // 
            tbFileName1.Name = "tbFileName1";
            tbFileName1.Size = new Size(200, 39);
            // 
            // btImport
            // 
            btImport.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btImport.Image = (Image)resources.GetObject("btImport.Image");
            btImport.ImageTransparentColor = Color.Magenta;
            btImport.Name = "btImport";
            btImport.Size = new Size(36, 36);
            btImport.Text = "Import";
            btImport.Click += btImport_Click;
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
            // ucImportSO
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ucImportSO";
            Size = new Size(1352, 731);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gvExcel).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private DataGridView gvExcel;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripTextBox tbFileName1;
        private ToolStripButton btImport;
        private ToolStripButton btSave;
    }
}
