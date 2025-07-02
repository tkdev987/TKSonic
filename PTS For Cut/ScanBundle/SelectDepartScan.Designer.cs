namespace PTS_For_Cut.ScanBundle
{
    partial class SelectDepartScan
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectDepartScan));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            cbbDec1 = new Guna.UI2.WinForms.Guna2ComboBox();
            label1 = new Label();
            label2 = new Label();
            cbbMode = new Guna.UI2.WinForms.Guna2ComboBox();
            btConfirm = new Guna.UI2.WinForms.Guna2Button();
            guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(components);
            label3 = new Label();
            btClose = new Guna.UI2.WinForms.Guna2PictureBox();
            label4 = new Label();
            label5 = new Label();
            cbbDecOut = new Guna.UI2.WinForms.Guna2ComboBox();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel6 = new Panel();
            cbbLocation2 = new ComboBox();
            panel4 = new Panel();
            panel5 = new Panel();
            ((System.ComponentModel.ISupportInitialize)btClose).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel6.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // cbbDec1
            // 
            cbbDec1.BackColor = Color.Transparent;
            cbbDec1.BorderRadius = 2;
            cbbDec1.CustomizableEdges = customizableEdges1;
            cbbDec1.DrawMode = DrawMode.OwnerDrawFixed;
            cbbDec1.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbDec1.FocusedColor = Color.FromArgb(94, 148, 255);
            cbbDec1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbbDec1.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbDec1.ForeColor = Color.FromArgb(68, 88, 112);
            cbbDec1.ItemHeight = 30;
            cbbDec1.Location = new Point(3, 31);
            cbbDec1.Name = "cbbDec1";
            cbbDec1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cbbDec1.Size = new Size(164, 36);
            cbbDec1.TabIndex = 0;
            cbbDec1.SelectedIndexChanged += cbbDec1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(3, 9);
            label1.Name = "label1";
            label1.Size = new Size(89, 19);
            label1.TabIndex = 1;
            label1.Text = "Decoration";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 2);
            label2.Name = "label2";
            label2.Size = new Size(48, 19);
            label2.TabIndex = 3;
            label2.Text = "Mode";
            // 
            // cbbMode
            // 
            cbbMode.BackColor = Color.Transparent;
            cbbMode.BorderRadius = 2;
            cbbMode.CustomizableEdges = customizableEdges3;
            cbbMode.DrawMode = DrawMode.OwnerDrawFixed;
            cbbMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbMode.FocusedColor = Color.FromArgb(94, 148, 255);
            cbbMode.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbbMode.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbMode.ForeColor = Color.FromArgb(68, 88, 112);
            cbbMode.ItemHeight = 30;
            cbbMode.Items.AddRange(new object[] { "Scan In", "Scan Out" });
            cbbMode.Location = new Point(6, 31);
            cbbMode.Name = "cbbMode";
            cbbMode.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cbbMode.Size = new Size(129, 36);
            cbbMode.TabIndex = 2;
            cbbMode.SelectedIndexChanged += cbbMode_SelectedIndexChanged;
            // 
            // btConfirm
            // 
            btConfirm.BorderRadius = 6;
            btConfirm.CustomizableEdges = customizableEdges5;
            btConfirm.DisabledState.BorderColor = Color.DarkGray;
            btConfirm.DisabledState.CustomBorderColor = Color.DarkGray;
            btConfirm.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btConfirm.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btConfirm.Dock = DockStyle.Right;
            btConfirm.FillColor = Color.DodgerBlue;
            btConfirm.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btConfirm.ForeColor = Color.Black;
            btConfirm.Image = (Image)resources.GetObject("btConfirm.Image");
            btConfirm.ImageAlign = HorizontalAlignment.Right;
            btConfirm.ImageSize = new Size(40, 40);
            btConfirm.Location = new Point(3, 0);
            btConfirm.Name = "btConfirm";
            btConfirm.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btConfirm.Size = new Size(164, 49);
            btConfirm.TabIndex = 4;
            btConfirm.Text = "Go to Scan";
            btConfirm.Click += bt_Click;
            // 
            // guna2Elipse1
            // 
            guna2Elipse1.BorderRadius = 20;
            guna2Elipse1.TargetControl = this;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Bahnschrift", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(328, 9);
            label3.Name = "label3";
            label3.Size = new Size(270, 39);
            label3.TabIndex = 5;
            label3.Text = "Select Decoration";
            // 
            // btClose
            // 
            btClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btClose.CustomizableEdges = customizableEdges9;
            btClose.Image = (Image)resources.GetObject("btClose.Image");
            btClose.ImageRotate = 0F;
            btClose.InitialImage = null;
            btClose.Location = new Point(912, 9);
            btClose.Name = "btClose";
            btClose.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btClose.Size = new Size(36, 36);
            btClose.SizeMode = PictureBoxSizeMode.StretchImage;
            btClose.TabIndex = 6;
            btClose.TabStop = false;
            btClose.Click += btClose_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(3, 9);
            label4.Name = "label4";
            label4.Size = new Size(71, 19);
            label4.TabIndex = 8;
            label4.Text = "Location";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(3, 7);
            label5.Name = "label5";
            label5.Size = new Size(117, 19);
            label5.TabIndex = 10;
            label5.Text = "Decoration Out";
            // 
            // cbbDecOut
            // 
            cbbDecOut.BackColor = Color.Transparent;
            cbbDecOut.BorderRadius = 2;
            cbbDecOut.CustomizableEdges = customizableEdges7;
            cbbDecOut.DrawMode = DrawMode.OwnerDrawFixed;
            cbbDecOut.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbDecOut.FocusedColor = Color.FromArgb(94, 148, 255);
            cbbDecOut.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbbDecOut.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbDecOut.ForeColor = Color.FromArgb(68, 88, 112);
            cbbDecOut.ItemHeight = 30;
            cbbDecOut.Location = new Point(3, 29);
            cbbDecOut.Name = "cbbDecOut";
            cbbDecOut.ShadowDecoration.CustomizableEdges = customizableEdges8;
            cbbDecOut.Size = new Size(164, 36);
            cbbDecOut.TabIndex = 9;
            cbbDecOut.SelectedIndexChanged += cbbDecOut_SelectedIndexChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(btConfirm);
            panel1.Location = new Point(764, 74);
            panel1.Name = "panel1";
            panel1.Size = new Size(167, 49);
            panel1.TabIndex = 11;
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Controls.Add(cbbDec1);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(173, 75);
            panel2.TabIndex = 12;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(panel2);
            panel3.Location = new Point(42, 61);
            panel3.Name = "panel3";
            panel3.Size = new Size(699, 75);
            panel3.TabIndex = 13;
            // 
            // panel6
            // 
            panel6.Controls.Add(cbbLocation2);
            panel6.Controls.Add(label4);
            panel6.Dock = DockStyle.Left;
            panel6.Location = new Point(502, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(178, 75);
            panel6.TabIndex = 15;
            // 
            // cbbLocation2
            // 
            cbbLocation2.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbbLocation2.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbbLocation2.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            cbbLocation2.FormattingEnabled = true;
            cbbLocation2.ItemHeight = 25;
            cbbLocation2.Location = new Point(6, 29);
            cbbLocation2.MaxDropDownItems = 20;
            cbbLocation2.Name = "cbbLocation2";
            cbbLocation2.Size = new Size(163, 33);
            cbbLocation2.TabIndex = 14;
            cbbLocation2.SelectedIndexChanged += cbbLocation2_SelectedIndexChanged;
            // 
            // panel4
            // 
            panel4.Controls.Add(label5);
            panel4.Controls.Add(cbbDecOut);
            panel4.Dock = DockStyle.Left;
            panel4.Location = new Point(317, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(185, 75);
            panel4.TabIndex = 14;
            // 
            // panel5
            // 
            panel5.Controls.Add(label2);
            panel5.Controls.Add(cbbMode);
            panel5.Dock = DockStyle.Left;
            panel5.Location = new Point(173, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(144, 75);
            panel5.TabIndex = 15;
            // 
            // SelectDepartScan
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(970, 160);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(btClose);
            Controls.Add(label3);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SelectDepartScan";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SelectDepartScan";
            Load += SelectDepartScan_Load;
            ((System.ComponentModel.ISupportInitialize)btClose).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox cbbDec1;
        private Label label1;
        private Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox cbbMode;
        private Guna.UI2.WinForms.Guna2Button btConfirm;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Label label3;
        private Guna.UI2.WinForms.Guna2PictureBox btClose;
        private Label label4;
        private Label label5;
        private Guna.UI2.WinForms.Guna2ComboBox cbbDecOut;
        private Panel panel1;
        private Panel panel3;
        private Panel panel2;
        private Panel panel6;
        private Panel panel5;
        private Panel panel4;
        private ComboBox cbbLocation2;
    }
}