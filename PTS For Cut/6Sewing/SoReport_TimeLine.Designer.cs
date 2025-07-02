namespace PTS_For_Cut._6Sewing
{
    partial class SoReport_TimeLine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoReport_TimeLine));
            toolStrip1 = new ToolStrip();
            btSearch = new ToolStripButton();
            pnlbHeader = new Panel();
            lbHeader = new Label();
            toolStripTextBox1 = new ToolStripTextBox();
            toolStripLabel1 = new ToolStripLabel();
            toolStripLabel2 = new ToolStripLabel();
            toolStripComboBox1 = new ToolStripComboBox();
            toolStrip1.SuspendLayout();
            pnlbHeader.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.Bottom;
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1, toolStripTextBox1, btSearch, toolStripLabel2, toolStripComboBox1 });
            toolStrip1.Location = new Point(0, 75);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1509, 39);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // btSearch
            // 
            btSearch.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btSearch.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btSearch.Image = (Image)resources.GetObject("btSearch.Image");
            btSearch.ImageTransparentColor = Color.Magenta;
            btSearch.Name = "btSearch";
            btSearch.Size = new Size(36, 36);
            btSearch.Text = "toolStripButton1";
            // 
            // pnlbHeader
            // 
            pnlbHeader.Controls.Add(lbHeader);
            pnlbHeader.Controls.Add(toolStrip1);
            pnlbHeader.Dock = DockStyle.Top;
            pnlbHeader.Location = new Point(0, 0);
            pnlbHeader.Name = "pnlbHeader";
            pnlbHeader.Size = new Size(1509, 114);
            pnlbHeader.TabIndex = 1;
            // 
            // lbHeader
            // 
            lbHeader.AutoSize = true;
            lbHeader.Font = new Font("Bahnschrift", 36F, FontStyle.Regular, GraphicsUnit.Point);
            lbHeader.Location = new Point(600, 0);
            lbHeader.Name = "lbHeader";
            lbHeader.Size = new Size(388, 58);
            lbHeader.TabIndex = 1;
            lbHeader.Text = "Time Line Output";
            // 
            // toolStripTextBox1
            // 
            toolStripTextBox1.BackColor = SystemColors.ActiveCaption;
            toolStripTextBox1.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripTextBox1.Name = "toolStripTextBox1";
            toolStripTextBox1.Size = new Size(200, 39);
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(85, 36);
            toolStripLabel1.Text = "Search SO";
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel2.Margin = new Padding(20, 1, 0, 2);
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(99, 36);
            toolStripLabel2.Text = "Select Color";
            // 
            // toolStripComboBox1
            // 
            toolStripComboBox1.BackColor = SystemColors.ActiveCaption;
            toolStripComboBox1.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripComboBox1.Name = "toolStripComboBox1";
            toolStripComboBox1.Size = new Size(200, 39);
            // 
            // SoReport_TimeLine
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1509, 642);
            Controls.Add(pnlbHeader);
            Name = "SoReport_TimeLine";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SoReport_TimeLine";
            WindowState = FormWindowState.Maximized;
            Load += SoReport_TimeLine_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            pnlbHeader.ResumeLayout(false);
            pnlbHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ToolStrip toolStrip1;
        private Panel pnlbHeader;
        private Label lbHeader;
        private ToolStripButton btSearch;
        private ToolStripLabel toolStripLabel1;
        private ToolStripTextBox toolStripTextBox1;
        private ToolStripLabel toolStripLabel2;
        private ToolStripComboBox toolStripComboBox1;
    }
}