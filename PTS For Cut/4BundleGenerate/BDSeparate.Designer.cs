namespace PTS_For_Cut._4BundleGenerate
{
    partial class BDSeparate
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
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BDSeparate));
            pnHeader = new Panel();
            lbHeader = new Label();
            gvNew = new DataGridView();
            panel2 = new Panel();
            gvOld = new DataGridView();
            toolStrip1 = new ToolStrip();
            btcreateNew = new ToolStripButton();
            toolStripLabel2 = new ToolStripLabel();
            tbQTY = new ToolStripTextBox();
            toolStripLabel1 = new ToolStripLabel();
            toolStripLabel3 = new ToolStripLabel();
            panel1 = new Panel();
            panel5 = new Panel();
            toolStrip2 = new ToolStrip();
            btSave = new ToolStripButton();
            toolStripLabel5 = new ToolStripLabel();
            toolStripLabel6 = new ToolStripLabel();
            panel3 = new Panel();
            splitContainer1 = new SplitContainer();
            pnHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvNew).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvOld).BeginInit();
            toolStrip1.SuspendLayout();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // pnHeader
            // 
            pnHeader.Controls.Add(lbHeader);
            pnHeader.Dock = DockStyle.Top;
            pnHeader.Location = new Point(0, 0);
            pnHeader.Name = "pnHeader";
            pnHeader.Size = new Size(1263, 62);
            pnHeader.TabIndex = 0;
            // 
            // lbHeader
            // 
            lbHeader.AutoSize = true;
            lbHeader.Font = new Font("Bahnschrift", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbHeader.Location = new Point(488, 9);
            lbHeader.Name = "lbHeader";
            lbHeader.Size = new Size(298, 45);
            lbHeader.TabIndex = 0;
            lbHeader.Text = "Separate Bundle";
            // 
            // gvNew
            // 
            gvNew.AllowUserToAddRows = false;
            gvNew.AllowUserToDeleteRows = false;
            dataGridViewCellStyle13.BackColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle13.ForeColor = Color.Black;
            gvNew.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            gvNew.BackgroundColor = SystemColors.Window;
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = SystemColors.Control;
            dataGridViewCellStyle14.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle14.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = DataGridViewTriState.True;
            gvNew.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            gvNew.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = SystemColors.Window;
            dataGridViewCellStyle15.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle15.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = DataGridViewTriState.False;
            gvNew.DefaultCellStyle = dataGridViewCellStyle15;
            gvNew.Dock = DockStyle.Fill;
            gvNew.Location = new Point(5, 47);
            gvNew.Name = "gvNew";
            gvNew.ReadOnly = true;
            gvNew.RowHeadersWidth = 20;
            gvNew.RowTemplate.Height = 50;
            gvNew.Size = new Size(629, 314);
            gvNew.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.Controls.Add(gvOld);
            panel2.Controls.Add(toolStrip1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(625, 361);
            panel2.TabIndex = 6;
            // 
            // gvOld
            // 
            gvOld.AllowUserToAddRows = false;
            gvOld.AllowUserToDeleteRows = false;
            dataGridViewCellStyle16.BackColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle16.ForeColor = Color.Black;
            gvOld.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16;
            gvOld.BackgroundColor = SystemColors.Window;
            dataGridViewCellStyle17.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = SystemColors.Control;
            dataGridViewCellStyle17.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle17.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = DataGridViewTriState.True;
            gvOld.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            gvOld.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle18.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = SystemColors.Window;
            dataGridViewCellStyle18.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle18.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle18.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = DataGridViewTriState.False;
            gvOld.DefaultCellStyle = dataGridViewCellStyle18;
            gvOld.Dock = DockStyle.Fill;
            gvOld.Location = new Point(0, 47);
            gvOld.Name = "gvOld";
            gvOld.ReadOnly = true;
            gvOld.RowHeadersWidth = 20;
            gvOld.RowTemplate.Height = 50;
            gvOld.Size = new Size(625, 314);
            gvOld.TabIndex = 4;
            // 
            // toolStrip1
            // 
            toolStrip1.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            toolStrip1.ImageScalingSize = new Size(40, 40);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btcreateNew, toolStripLabel2, tbQTY, toolStripLabel1, toolStripLabel3 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(625, 47);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // btcreateNew
            // 
            btcreateNew.Alignment = ToolStripItemAlignment.Right;
            btcreateNew.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btcreateNew.Image = (Image)resources.GetObject("btcreateNew.Image");
            btcreateNew.ImageTransparentColor = Color.Magenta;
            btcreateNew.Margin = new Padding(20, 1, 0, 2);
            btcreateNew.Name = "btcreateNew";
            btcreateNew.Size = new Size(44, 44);
            btcreateNew.Text = "toolStripButton1";
            btcreateNew.Click += btcreateNew_Click;
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Alignment = ToolStripItemAlignment.Right;
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(55, 44);
            toolStripLabel2.Text = "PCS.";
            // 
            // tbQTY
            // 
            tbQTY.Alignment = ToolStripItemAlignment.Right;
            tbQTY.BackColor = SystemColors.ActiveCaption;
            tbQTY.Font = new Font("Bahnschrift", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            tbQTY.Name = "tbQTY";
            tbQTY.Size = new Size(55, 47);
            tbQTY.KeyPress += tbQTY_KeyPress;
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Alignment = ToolStripItemAlignment.Right;
            toolStripLabel1.Margin = new Padding(0, 0, 0, 2);
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(144, 45);
            toolStripLabel1.Text = "Separate QTY ";
            // 
            // toolStripLabel3
            // 
            toolStripLabel3.Name = "toolStripLabel3";
            toolStripLabel3.Size = new Size(126, 44);
            toolStripLabel3.Text = "Old Bundles";
            // 
            // panel1
            // 
            panel1.Controls.Add(gvNew);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(634, 361);
            panel1.TabIndex = 5;
            // 
            // panel5
            // 
            panel5.Controls.Add(toolStrip2);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(5, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(629, 47);
            panel5.TabIndex = 6;
            // 
            // toolStrip2
            // 
            toolStrip2.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            toolStrip2.ImageScalingSize = new Size(40, 40);
            toolStrip2.Items.AddRange(new ToolStripItem[] { btSave, toolStripLabel5, toolStripLabel6 });
            toolStrip2.Location = new Point(0, 0);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(629, 47);
            toolStrip2.TabIndex = 1;
            toolStrip2.Text = "toolStrip2";
            // 
            // btSave
            // 
            btSave.Alignment = ToolStripItemAlignment.Right;
            btSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btSave.Image = (Image)resources.GetObject("btSave.Image");
            btSave.ImageTransparentColor = Color.Magenta;
            btSave.Margin = new Padding(5, 1, 0, 2);
            btSave.Name = "btSave";
            btSave.Size = new Size(44, 44);
            btSave.Text = "toolStripButton1";
            btSave.Click += btSave_Click;
            // 
            // toolStripLabel5
            // 
            toolStripLabel5.Alignment = ToolStripItemAlignment.Right;
            toolStripLabel5.Margin = new Padding(0, 0, 0, 2);
            toolStripLabel5.Name = "toolStripLabel5";
            toolStripLabel5.Size = new Size(82, 45);
            toolStripLabel5.Text = "Save >>";
            // 
            // toolStripLabel6
            // 
            toolStripLabel6.Name = "toolStripLabel6";
            toolStripLabel6.Size = new Size(137, 44);
            toolStripLabel6.Text = "New Bundles";
            // 
            // panel3
            // 
            panel3.BackColor = Color.Gray;
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(5, 361);
            panel3.TabIndex = 7;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 62);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panel2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Size = new Size(1263, 361);
            splitContainer1.SplitterDistance = 625;
            splitContainer1.TabIndex = 6;
            // 
            // BDSeparate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1263, 423);
            Controls.Add(splitContainer1);
            Controls.Add(pnHeader);
            Name = "BDSeparate";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BDSeparate";
            WindowState = FormWindowState.Maximized;
            Load += BDSeparate_Load;
            pnHeader.ResumeLayout(false);
            pnHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gvNew).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gvOld).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnHeader;
        private Label lbHeader;
        private DataGridView gvNew;
        private Panel panel1;
        private Panel panel2;
        private DataGridView gvOld;
        private Panel panel5;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripLabel toolStripLabel2;
        private ToolStripButton btcreateNew;
        private SplitContainer splitContainer1;
        private ToolStripTextBox tbQTY;
        private ToolStripLabel toolStripLabel3;
        private Panel panel3;
        private ToolStrip toolStrip2;
        private ToolStripButton btSave;
        private ToolStripLabel toolStripLabel5;
        private ToolStripLabel toolStripLabel6;
    }
}