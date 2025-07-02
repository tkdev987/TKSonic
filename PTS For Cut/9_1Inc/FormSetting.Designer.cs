namespace PTS_For_Cut._9_1Inc
{
    partial class FormSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSetting));
            toolStrip1 = new ToolStrip();
            btSave = new ToolStripButton();
            lbGroupBy = new Label();
            tbOverhead = new TextBox();
            lbWage = new Label();
            lbOverhead = new Label();
            tbWage = new TextBox();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btSave });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(526, 39);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // btSave
            // 
            btSave.Alignment = ToolStripItemAlignment.Right;
            btSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btSave.Image = (Image)resources.GetObject("btSave.Image");
            btSave.ImageTransparentColor = Color.Magenta;
            btSave.Name = "btSave";
            btSave.Size = new Size(36, 36);
            btSave.Text = "toolStripButton1";
            btSave.Click += btSave_Click;
            // 
            // lbGroupBy
            // 
            lbGroupBy.AutoSize = true;
            lbGroupBy.Location = new Point(12, 165);
            lbGroupBy.Name = "lbGroupBy";
            lbGroupBy.Size = new Size(17, 15);
            lbGroupBy.TabIndex = 38;
            lbGroupBy.Text = "xx";
            lbGroupBy.Visible = false;
            // 
            // tbOverhead
            // 
            tbOverhead.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            tbOverhead.Location = new Point(233, 55);
            tbOverhead.Name = "tbOverhead";
            tbOverhead.Size = new Size(124, 30);
            tbOverhead.TabIndex = 42;
            // 
            // lbWage
            // 
            lbWage.AutoSize = true;
            lbWage.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbWage.Location = new Point(122, 100);
            lbWage.Name = "lbWage";
            lbWage.Padding = new Padding(0, 8, 0, 0);
            lbWage.Size = new Size(44, 31);
            lbWage.TabIndex = 41;
            lbWage.Text = "Wage";
            // 
            // lbOverhead
            // 
            lbOverhead.AutoSize = true;
            lbOverhead.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbOverhead.Location = new Point(122, 54);
            lbOverhead.Name = "lbOverhead";
            lbOverhead.Padding = new Padding(0, 8, 0, 0);
            lbOverhead.Size = new Size(70, 31);
            lbOverhead.TabIndex = 39;
            lbOverhead.Text = "Overhead";
            // 
            // tbWage
            // 
            tbWage.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            tbWage.Location = new Point(233, 101);
            tbWage.Name = "tbWage";
            tbWage.Size = new Size(124, 30);
            tbWage.TabIndex = 43;
            // 
            // FormSetting
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(526, 189);
            Controls.Add(tbWage);
            Controls.Add(toolStrip1);
            Controls.Add(lbGroupBy);
            Controls.Add(tbOverhead);
            Controls.Add(lbWage);
            Controls.Add(lbOverhead);
            Name = "FormSetting";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormSetting";
            Load += FormSetting_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolStrip toolStrip1;
        private ToolStripButton btSave;
        private Label lbGroupBy;
        private Label lbOverhead;
        private TextBox tbOverhead;
        private Label lbWage;
        private TextBox tbWage;
    }
}