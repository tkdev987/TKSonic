namespace PTS_For_Cut.Main
{
    partial class ConnectionSetting
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionSetting));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label2 = new Label();
            label1 = new Label();
            panel1 = new Panel();
            btClose = new Guna.UI2.WinForms.Guna2PictureBox();
            tbIP = new Guna.UI2.WinForms.Guna2TextBox();
            btSave1 = new Guna.UI2.WinForms.Guna2Button();
            guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btClose).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bahnschrift SemiCondensed", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(183, 4);
            label2.Name = "label2";
            label2.Size = new Size(149, 23);
            label2.TabIndex = 10;
            label2.Text = "Connection Setting";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift SemiCondensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(30, 64);
            label1.Name = "label1";
            label1.Size = new Size(73, 19);
            label1.TabIndex = 12;
            label1.Text = "IP Server :";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gray;
            panel1.Controls.Add(btClose);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(509, 32);
            panel1.TabIndex = 16;
            // 
            // btClose
            // 
            btClose.CustomizableEdges = customizableEdges1;
            btClose.Image = (Image)resources.GetObject("btClose.Image");
            btClose.ImageRotate = 0F;
            btClose.Location = new Point(478, 1);
            btClose.Name = "btClose";
            btClose.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btClose.Size = new Size(28, 28);
            btClose.SizeMode = PictureBoxSizeMode.StretchImage;
            btClose.TabIndex = 0;
            btClose.TabStop = false;
            btClose.Click += btClose_Click;
            // 
            // tbIP
            // 
            tbIP.BorderRadius = 6;
            tbIP.CustomizableEdges = customizableEdges3;
            tbIP.DefaultText = "";
            tbIP.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbIP.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbIP.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbIP.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbIP.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbIP.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            tbIP.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbIP.IconLeft = (Image)resources.GetObject("tbIP.IconLeft");
            tbIP.Location = new Point(109, 60);
            tbIP.Name = "tbIP";
            tbIP.PasswordChar = '\0';
            tbIP.PlaceholderText = "IP";
            tbIP.SelectedText = "";
            tbIP.ShadowDecoration.CustomizableEdges = customizableEdges4;
            tbIP.Size = new Size(244, 32);
            tbIP.TabIndex = 17;
            tbIP.KeyUp += tbIP_KeyUp;
            // 
            // btSave1
            // 
            btSave1.BackColor = Color.Transparent;
            btSave1.BorderRadius = 4;
            btSave1.BorderThickness = 2;
            btSave1.CustomizableEdges = customizableEdges5;
            btSave1.DisabledState.BorderColor = Color.DarkGray;
            btSave1.DisabledState.CustomBorderColor = Color.DarkGray;
            btSave1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btSave1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btSave1.FillColor = Color.Transparent;
            btSave1.Font = new Font("Bahnschrift SemiCondensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btSave1.ForeColor = Color.DimGray;
            btSave1.Location = new Point(359, 60);
            btSave1.Name = "btSave1";
            btSave1.ShadowDecoration.Color = Color.DarkGray;
            btSave1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btSave1.ShadowDecoration.Enabled = true;
            btSave1.Size = new Size(102, 32);
            btSave1.TabIndex = 18;
            btSave1.Text = "Save";
            btSave1.Click += btSave1_Click;
            // 
            // guna2Elipse1
            // 
            guna2Elipse1.BorderRadius = 12;
            guna2Elipse1.TargetControl = this;
            // 
            // ConnectionSetting
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(509, 127);
            Controls.Add(btSave1);
            Controls.Add(tbIP);
            Controls.Add(panel1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ConnectionSetting";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ConnectionSetting";
            Load += ConnectionSetting_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btClose).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Label label1;
        private Panel panel1;
        private Guna.UI2.WinForms.Guna2PictureBox btClose;
        private Guna.UI2.WinForms.Guna2TextBox tbIP;
        private Guna.UI2.WinForms.Guna2Button btSave1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
    }
}