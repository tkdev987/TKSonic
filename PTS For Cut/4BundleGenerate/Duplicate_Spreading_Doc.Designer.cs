namespace PTS_For_Cut._4BundleGenerate
{
    partial class Duplicate_Spreading_Doc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Duplicate_Spreading_Doc));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            tbMaster = new TextBox();
            label1 = new Label();
            tbClone = new TextBox();
            label2 = new Label();
            label3 = new Label();
            btOk = new Guna.UI2.WinForms.Guna2Button();
            btTransfer = new Guna.UI2.WinForms.Guna2Button();
            label4 = new Label();
            SuspendLayout();
            // 
            // tbMaster
            // 
            tbMaster.Font = new Font("Bahnschrift", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            tbMaster.Location = new Point(25, 125);
            tbMaster.Name = "tbMaster";
            tbMaster.Size = new Size(259, 40);
            tbMaster.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(171, 29);
            label1.Name = "label1";
            label1.Size = new Size(445, 42);
            label1.TabIndex = 1;
            label1.Text = "Clone Spreading Document";
            // 
            // tbClone
            // 
            tbClone.Font = new Font("Bahnschrift", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            tbClone.Location = new Point(468, 125);
            tbClone.Name = "tbClone";
            tbClone.Size = new Size(271, 40);
            tbClone.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(25, 97);
            label2.Name = "label2";
            label2.Size = new Size(203, 25);
            label2.TabIndex = 4;
            label2.Text = "Master Spreading ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(468, 97);
            label3.Name = "label3";
            label3.Size = new Size(191, 25);
            label3.TabIndex = 5;
            label3.Text = "Clone Spreading ID";
            // 
            // btOk
            // 
            btOk.CustomizableEdges = customizableEdges1;
            btOk.DisabledState.BorderColor = Color.DarkGray;
            btOk.DisabledState.CustomBorderColor = Color.DarkGray;
            btOk.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btOk.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btOk.Font = new Font("Bahnschrift", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            btOk.ForeColor = Color.White;
            btOk.Location = new Point(25, 182);
            btOk.Name = "btOk";
            btOk.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btOk.Size = new Size(714, 53);
            btOk.TabIndex = 7;
            btOk.Text = "OK";
            btOk.Click += btOk_Click;
            // 
            // btTransfer
            // 
            btTransfer.CustomizableEdges = customizableEdges3;
            btTransfer.DisabledState.BorderColor = Color.DarkGray;
            btTransfer.DisabledState.CustomBorderColor = Color.DarkGray;
            btTransfer.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btTransfer.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btTransfer.FillColor = Color.DarkGray;
            btTransfer.Font = new Font("Bahnschrift", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btTransfer.ForeColor = SystemColors.Control;
            btTransfer.Image = (Image)resources.GetObject("btTransfer.Image");
            btTransfer.ImageAlign = HorizontalAlignment.Right;
            btTransfer.ImageSize = new Size(40, 40);
            btTransfer.Location = new Point(306, 125);
            btTransfer.Name = "btTransfer";
            btTransfer.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btTransfer.Size = new Size(141, 40);
            btTransfer.TabIndex = 8;
            btTransfer.Text = "Transfer";
            btTransfer.TextAlign = HorizontalAlignment.Left;
            btTransfer.Click += btTransfer_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Bottom;
            label4.Location = new Point(0, 283);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 9;
            label4.Text = "ใช้ในกรณี";
            // 
            // Duplicate_Spreading_Doc
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(765, 298);
            Controls.Add(label4);
            Controls.Add(btTransfer);
            Controls.Add(btOk);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(tbClone);
            Controls.Add(label1);
            Controls.Add(tbMaster);
            Name = "Duplicate_Spreading_Doc";
            Text = "Duplicate_Spreading_Doc";
            Load += Duplicate_Spreading_Doc_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbMaster;
        private Label label1;
        private TextBox tbClone;
        private Label label2;
        private Label label3;
        private Guna.UI2.WinForms.Guna2Button btOk;
        private Guna.UI2.WinForms.Guna2Button btTransfer;
        private Label label4;
    }
}