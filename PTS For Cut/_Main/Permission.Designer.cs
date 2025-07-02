namespace PTS_For_Cut._Main
{
    partial class Permission
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Permission));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            tbuser = new Guna.UI2.WinForms.Guna2TextBox();
            btok = new Guna.UI2.WinForms.Guna2Button();
            guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            picClose = new PictureBox();
            label3 = new Label();
            tbpass = new Guna.UI2.WinForms.Guna2TextBox();
            label1 = new Label();
            label2 = new Label();
            guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picClose).BeginInit();
            SuspendLayout();
            // 
            // tbuser
            // 
            tbuser.CustomizableEdges = customizableEdges1;
            tbuser.DefaultText = "";
            tbuser.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbuser.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbuser.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbuser.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbuser.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbuser.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            tbuser.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbuser.Location = new Point(137, 102);
            tbuser.Name = "tbuser";
            tbuser.PasswordChar = '\0';
            tbuser.PlaceholderText = "";
            tbuser.SelectedText = "";
            tbuser.ShadowDecoration.CustomizableEdges = customizableEdges2;
            tbuser.Size = new Size(227, 39);
            tbuser.TabIndex = 0;
            // 
            // btok
            // 
            btok.CustomizableEdges = customizableEdges3;
            btok.DisabledState.BorderColor = Color.DarkGray;
            btok.DisabledState.CustomBorderColor = Color.DarkGray;
            btok.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btok.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btok.FillColor = Color.Gray;
            btok.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            btok.ForeColor = Color.White;
            btok.Location = new Point(375, 102);
            btok.Name = "btok";
            btok.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btok.Size = new Size(104, 84);
            btok.TabIndex = 1;
            btok.Text = "OK";
            btok.Click += btok_Click;
            // 
            // guna2GradientPanel1
            // 
            guna2GradientPanel1.BackColor = Color.Gray;
            guna2GradientPanel1.Controls.Add(picClose);
            guna2GradientPanel1.Controls.Add(label3);
            guna2GradientPanel1.CustomizableEdges = customizableEdges5;
            guna2GradientPanel1.Dock = DockStyle.Top;
            guna2GradientPanel1.Location = new Point(0, 0);
            guna2GradientPanel1.Name = "guna2GradientPanel1";
            guna2GradientPanel1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2GradientPanel1.Size = new Size(544, 40);
            guna2GradientPanel1.TabIndex = 2;
            // 
            // picClose
            // 
            picClose.Image = (Image)resources.GetObject("picClose.Image");
            picClose.Location = new Point(501, 5);
            picClose.Name = "picClose";
            picClose.Size = new Size(32, 32);
            picClose.SizeMode = PictureBoxSizeMode.StretchImage;
            picClose.TabIndex = 5;
            picClose.TabStop = false;
            picClose.Click += picClose_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(231, 10);
            label3.Name = "label3";
            label3.Size = new Size(94, 21);
            label3.TabIndex = 4;
            label3.Text = "Permission";
            // 
            // tbpass
            // 
            tbpass.CustomizableEdges = customizableEdges7;
            tbpass.DefaultText = "";
            tbpass.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbpass.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbpass.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbpass.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbpass.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbpass.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            tbpass.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbpass.Location = new Point(137, 147);
            tbpass.Name = "tbpass";
            tbpass.PasswordChar = '\0';
            tbpass.PlaceholderText = "";
            tbpass.SelectedText = "";
            tbpass.ShadowDecoration.CustomizableEdges = customizableEdges8;
            tbpass.Size = new Size(227, 39);
            tbpass.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(48, 108);
            label1.Name = "label1";
            label1.Size = new Size(49, 21);
            label1.TabIndex = 3;
            label1.Text = "User :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(48, 156);
            label2.Name = "label2";
            label2.Size = new Size(83, 21);
            label2.TabIndex = 3;
            label2.Text = "Password :";
            // 
            // Permission
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(544, 245);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(guna2GradientPanel1);
            Controls.Add(btok);
            Controls.Add(tbpass);
            Controls.Add(tbuser);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Permission";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Permission";
            guna2GradientPanel1.ResumeLayout(false);
            guna2GradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picClose).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox tbuser;
        private Guna.UI2.WinForms.Guna2Button btok;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2TextBox tbpass;
        private Label label1;
        private Label label2;
        private PictureBox picClose;
        private Label label3;
    }
}