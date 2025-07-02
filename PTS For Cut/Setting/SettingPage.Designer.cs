namespace PTS_For_Cut.Setting
{
    partial class SettingPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingPage));
            tableLayoutPanel1 = new TableLayoutPanel();
            btUserPic = new PictureBox();
            btUser = new Button();
            panel1 = new Panel();
            toolStrip1 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            cbbDirectReport = new ToolStripComboBox();
            btResetDirectReport = new ToolStripButton();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btUserPic).BeginInit();
            panel1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(tableLayoutPanel1, "tableLayoutPanel1");
            tableLayoutPanel1.Controls.Add(btUserPic, 0, 0);
            tableLayoutPanel1.Controls.Add(btUser, 0, 1);
            tableLayoutPanel1.Controls.Add(panel1, 1, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // btUserPic
            // 
            resources.ApplyResources(btUserPic, "btUserPic");
            btUserPic.Name = "btUserPic";
            btUserPic.TabStop = false;
            btUserPic.Click += btUserPic_Click;
            // 
            // btUser
            // 
            resources.ApplyResources(btUser, "btUser");
            btUser.Name = "btUser";
            btUser.UseVisualStyleBackColor = true;
            btUser.Click += btUser_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(toolStrip1);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1, cbbDirectReport, btResetDirectReport });
            resources.ApplyResources(toolStrip1, "toolStrip1");
            toolStrip1.Name = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            resources.ApplyResources(toolStripLabel1, "toolStripLabel1");
            toolStripLabel1.Name = "toolStripLabel1";
            // 
            // cbbDirectReport
            // 
            cbbDirectReport.BackColor = SystemColors.ActiveCaption;
            resources.ApplyResources(cbbDirectReport, "cbbDirectReport");
            cbbDirectReport.Items.AddRange(new object[] { resources.GetString("cbbDirectReport.Items"), resources.GetString("cbbDirectReport.Items1"), resources.GetString("cbbDirectReport.Items2") });
            cbbDirectReport.Name = "cbbDirectReport";
            cbbDirectReport.SelectedIndexChanged += cbbDirectReport_SelectedIndexChanged;
            // 
            // btResetDirectReport
            // 
            resources.ApplyResources(btResetDirectReport, "btResetDirectReport");
            btResetDirectReport.Name = "btResetDirectReport";
            btResetDirectReport.Click += btResetDirectReport_Click;
            // 
            // SettingPage
            // 
            AutoScaleMode = AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SettingPage";
            Load += SettingPage_Load;
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btUserPic).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox btUserPic;
        private Button btUser;
        private Panel panel1;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripComboBox cbbDirectReport;
        private ToolStripButton btResetDirectReport;
    }
}