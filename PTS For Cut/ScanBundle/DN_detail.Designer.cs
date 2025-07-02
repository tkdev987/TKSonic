namespace PTS_For_Cut.ScanBundle
{
    partial class DN_detail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DN_detail));
            panel1 = new Panel();
            label1 = new Label();
            toolStrip1 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            tbSearch = new ToolStripTextBox();
            btSearch = new ToolStripButton();
            gvDis = new DataGridView();
            panel1.SuspendLayout();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvDis).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(toolStrip1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1386, 116);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(586, 9);
            label1.Name = "label1";
            label1.Size = new Size(232, 45);
            label1.TabIndex = 1;
            label1.Text = "Transactions";
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.Bottom;
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1, tbSearch, btSearch });
            toolStrip1.Location = new Point(0, 77);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1386, 39);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(61, 36);
            toolStripLabel1.Text = "Search";
            // 
            // tbSearch
            // 
            tbSearch.BackColor = SystemColors.ActiveCaption;
            tbSearch.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbSearch.Name = "tbSearch";
            tbSearch.Size = new Size(180, 39);
            tbSearch.KeyUp += tbSearch_KeyUp;
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
            // gvDis
            // 
            gvDis.AllowUserToAddRows = false;
            gvDis.AllowUserToDeleteRows = false;
            gvDis.BackgroundColor = SystemColors.Control;
            gvDis.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvDis.Dock = DockStyle.Fill;
            gvDis.Location = new Point(0, 116);
            gvDis.Name = "gvDis";
            gvDis.ReadOnly = true;
            gvDis.RowTemplate.Height = 25;
            gvDis.SelectionMode = DataGridViewSelectionMode.CellSelect;
            gvDis.Size = new Size(1386, 435);
            gvDis.TabIndex = 2;
            // 
            // DN_detail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1386, 551);
            Controls.Add(gvDis);
            Controls.Add(panel1);
            Name = "DN_detail";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DN_detail";
            WindowState = FormWindowState.Maximized;
            Load += DN_detail_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gvDis).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private DataGridView gvDis;
        private ToolStrip toolStrip1;
        private ToolStripTextBox tbSearch;
        private ToolStripButton btSearch;
        private Label label1;
        private ToolStripLabel toolStripLabel1;
    }
}