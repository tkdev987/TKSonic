namespace PTS_For_Cut._Main
{
    partial class passUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(passUser));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panel1 = new Panel();
            label1 = new Label();
            btClose = new PictureBox();
            tbUsername1 = new Guna.UI2.WinForms.Guna2TextBox();
            btGo = new Guna.UI2.WinForms.Guna2Button();
            tbPassword1 = new Guna.UI2.WinForms.Guna2TextBox();
            label2 = new Label();
            label3 = new Label();
            guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btClose).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkGray;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btClose);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(613, 45);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift SemiCondensed", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(216, 9);
            label1.Name = "label1";
            label1.Size = new Size(144, 23);
            label1.TabIndex = 1;
            label1.Text = "User Management";
            // 
            // btClose
            // 
            btClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btClose.Image = (Image)resources.GetObject("btClose.Image");
            btClose.Location = new Point(570, 3);
            btClose.Name = "btClose";
            btClose.Size = new Size(36, 36);
            btClose.SizeMode = PictureBoxSizeMode.StretchImage;
            btClose.TabIndex = 0;
            btClose.TabStop = false;
            btClose.Click += btClose_Click;
            // 
            // tbUsername1
            // 
            tbUsername1.BorderColor = Color.Gray;
            tbUsername1.BorderRadius = 8;
            tbUsername1.BorderThickness = 2;
            tbUsername1.CustomizableEdges = customizableEdges1;
            tbUsername1.DefaultText = "";
            tbUsername1.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbUsername1.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbUsername1.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbUsername1.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbUsername1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbUsername1.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbUsername1.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbUsername1.IconLeft = (Image)resources.GetObject("tbUsername1.IconLeft");
            tbUsername1.Location = new Point(160, 84);
            tbUsername1.Margin = new Padding(3, 4, 3, 4);
            tbUsername1.Name = "tbUsername1";
            tbUsername1.PasswordChar = '\0';
            tbUsername1.PlaceholderText = "User ID";
            tbUsername1.SelectedText = "";
            tbUsername1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            tbUsername1.Size = new Size(200, 35);
            tbUsername1.TabIndex = 0;
            tbUsername1.KeyUp += tbempID_KeyUp;
            // 
            // btGo
            // 
            btGo.BackColor = Color.Transparent;
            btGo.BorderColor = Color.DimGray;
            btGo.BorderRadius = 8;
            btGo.BorderThickness = 2;
            btGo.CustomizableEdges = customizableEdges3;
            btGo.DisabledState.BorderColor = Color.DarkGray;
            btGo.DisabledState.CustomBorderColor = Color.DarkGray;
            btGo.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btGo.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btGo.FillColor = SystemColors.Control;
            btGo.Font = new Font("Bahnschrift Condensed", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            btGo.ForeColor = Color.DimGray;
            btGo.Image = (Image)resources.GetObject("btGo.Image");
            btGo.ImageAlign = HorizontalAlignment.Right;
            btGo.Location = new Point(379, 84);
            btGo.Name = "btGo";
            btGo.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btGo.Size = new Size(121, 78);
            btGo.TabIndex = 2;
            btGo.Text = "Go";
            btGo.Click += btGo_Click;
            // 
            // tbPassword1
            // 
            tbPassword1.BorderColor = Color.Gray;
            tbPassword1.BorderRadius = 8;
            tbPassword1.BorderThickness = 2;
            tbPassword1.CustomizableEdges = customizableEdges5;
            tbPassword1.DefaultText = "";
            tbPassword1.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbPassword1.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbPassword1.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbPassword1.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbPassword1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbPassword1.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbPassword1.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbPassword1.IconLeft = (Image)resources.GetObject("tbPassword1.IconLeft");
            tbPassword1.Location = new Point(160, 127);
            tbPassword1.Margin = new Padding(3, 4, 3, 4);
            tbPassword1.Name = "tbPassword1";
            tbPassword1.PasswordChar = '*';
            tbPassword1.PlaceholderText = "Password";
            tbPassword1.SelectedText = "";
            tbPassword1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            tbPassword1.Size = new Size(200, 35);
            tbPassword1.TabIndex = 1;
            tbPassword1.KeyUp += tbempID_KeyUp;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(87, 91);
            label2.Name = "label2";
            label2.Size = new Size(33, 19);
            label2.TabIndex = 1;
            label2.Text = "User";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(87, 132);
            label3.Name = "label3";
            label3.Size = new Size(61, 19);
            label3.TabIndex = 1;
            label3.Text = "Password";
            // 
            // guna2Elipse1
            // 
            guna2Elipse1.BorderRadius = 20;
            guna2Elipse1.TargetControl = this;
            // 
            // passUser
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.Silver;
            ClientSize = new Size(613, 197);
            Controls.Add(btGo);
            Controls.Add(tbPassword1);
            Controls.Add(label3);
            Controls.Add(tbUsername1);
            Controls.Add(label2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "passUser";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "passUser";
            Load += passUser_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btClose).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox btClose;
        private Label label1;
        private Guna.UI2.WinForms.Guna2TextBox tbUsername1;
        private Guna.UI2.WinForms.Guna2Button btGo;
        private Guna.UI2.WinForms.Guna2TextBox tbPassword1;
        private Label label2;
        private Label label3;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
    }
}