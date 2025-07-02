namespace PTS_For_Cut.SMK
{
    partial class SettingUseSMK
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingUseSMK));
            label1 = new Label();
            cbbSMK = new ComboBox();
            label2 = new Label();
            cbbComport = new ComboBox();
            btGo = new Button();
            toolStrip1 = new ToolStrip();
            btReport = new ToolStripButton();
            btLetgoWithout = new ToolStripButton();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(119, 68);
            label1.Name = "label1";
            label1.Size = new Size(244, 37);
            label1.TabIndex = 0;
            label1.Text = "Select Supermarket";
            // 
            // cbbSMK
            // 
            cbbSMK.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbSMK.FormattingEnabled = true;
            cbbSMK.Location = new Point(380, 78);
            cbbSMK.Name = "cbbSMK";
            cbbSMK.Size = new Size(164, 29);
            cbbSMK.TabIndex = 1;
            cbbSMK.SelectedIndexChanged += cbbSMK_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(119, 114);
            label2.Name = "label2";
            label2.Size = new Size(200, 37);
            label2.TabIndex = 0;
            label2.Text = "Select Comport";
            // 
            // cbbComport
            // 
            cbbComport.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbComport.FormattingEnabled = true;
            cbbComport.Location = new Point(380, 124);
            cbbComport.Name = "cbbComport";
            cbbComport.Size = new Size(164, 29);
            cbbComport.TabIndex = 1;
            // 
            // btGo
            // 
            btGo.BackColor = Color.Gray;
            btGo.Image = (Image)resources.GetObject("btGo.Image");
            btGo.Location = new Point(12, 175);
            btGo.Name = "btGo";
            btGo.Size = new Size(694, 144);
            btGo.TabIndex = 2;
            btGo.UseVisualStyleBackColor = false;
            btGo.Click += btGo_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btReport, btLetgoWithout });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(718, 39);
            toolStrip1.TabIndex = 3;
            toolStrip1.Text = "toolStrip1";
            // 
            // btReport
            // 
            btReport.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btReport.Image = (Image)resources.GetObject("btReport.Image");
            btReport.ImageTransparentColor = Color.Magenta;
            btReport.Name = "btReport";
            btReport.Size = new Size(36, 36);
            btReport.Text = "Report";
            btReport.Click += btReport_Click;
            // 
            // btLetgoWithout
            // 
            btLetgoWithout.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btLetgoWithout.Image = (Image)resources.GetObject("btLetgoWithout.Image");
            btLetgoWithout.ImageTransparentColor = Color.Magenta;
            btLetgoWithout.Name = "btLetgoWithout";
            btLetgoWithout.Size = new Size(36, 36);
            btLetgoWithout.Text = "Login with out Communicate";
            btLetgoWithout.Click += btLetgoWithout_Click;
            // 
            // SettingUseSMK
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(718, 331);
            Controls.Add(toolStrip1);
            Controls.Add(btGo);
            Controls.Add(cbbComport);
            Controls.Add(cbbSMK);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SettingUseSMK";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SettingUseSMK";
            Load += SettingUseSMK_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cbbSMK;
        private Label label2;
        private ComboBox cbbComport;
        private Button btGo;
        private ToolStrip toolStrip1;
        private ToolStripButton btReport;
        private ToolStripButton btLetgoWithout;
    }
}