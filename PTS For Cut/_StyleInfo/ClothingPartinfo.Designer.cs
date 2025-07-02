namespace PTS_For_Cut._StyleInfo
{
    partial class ClothingPartinfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClothingPartinfo));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            panel1 = new Panel();
            btClose = new Guna.UI2.WinForms.Guna2PictureBox();
            label1 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            toolStrip1 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            lbStyle = new ToolStripLabel();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripLabel3 = new ToolStripLabel();
            cbbDecoration = new ToolStripComboBox();
            btClearText = new ToolStripButton();
            btSave = new ToolStripButton();
            guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(components);
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            gvDis = new Guna.UI2.WinForms.Guna2DataGridView();
            No = new DataGridViewTextBoxColumn();
            Part = new DataGridViewTextBoxColumn();
            MainPart = new DataGridViewCheckBoxColumn();
            QTY = new DataGridViewTextBoxColumn();
            Decoration = new DataGridViewTextBoxColumn();
            guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btClose).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            guna2Panel3.SuspendLayout();
            toolStrip1.SuspendLayout();
            guna2Panel1.SuspendLayout();
            guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvDis).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gray;
            panel1.Controls.Add(btClose);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(5, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1190, 49);
            panel1.TabIndex = 0;
            // 
            // btClose
            // 
            btClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btClose.CustomizableEdges = customizableEdges1;
            btClose.Image = (Image)resources.GetObject("btClose.Image");
            btClose.ImageRotate = 0F;
            btClose.Location = new Point(1143, 3);
            btClose.Name = "btClose";
            btClose.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btClose.Size = new Size(40, 40);
            btClose.SizeMode = PictureBoxSizeMode.StretchImage;
            btClose.TabIndex = 1;
            btClose.TabStop = false;
            btClose.Click += btClose_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift Condensed", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(452, 8);
            label1.Name = "label1";
            label1.Size = new Size(142, 35);
            label1.TabIndex = 0;
            label1.Text = "Clothing Part";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 125F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel1.Controls.Add(pictureBox1, 1, 0);
            tableLayoutPanel1.Controls.Add(guna2Panel3, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(10, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1170, 192);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(421, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(119, 186);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // guna2Panel3
            // 
            guna2Panel3.Controls.Add(toolStrip1);
            guna2Panel3.CustomizableEdges = customizableEdges3;
            guna2Panel3.Dock = DockStyle.Fill;
            guna2Panel3.Location = new Point(546, 3);
            guna2Panel3.Name = "guna2Panel3";
            guna2Panel3.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Panel3.Size = new Size(621, 186);
            guna2Panel3.TabIndex = 1;
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.Bottom;
            toolStrip1.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1, lbStyle, toolStripSeparator1, toolStripLabel3, cbbDecoration, btClearText, btSave });
            toolStrip1.Location = new Point(0, 147);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(621, 39);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(39, 36);
            toolStripLabel1.Text = "Style:";
            // 
            // lbStyle
            // 
            lbStyle.Name = "lbStyle";
            lbStyle.Size = new Size(105, 36);
            lbStyle.Text = "XXXXXXXXXXXXXXXX";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 39);
            // 
            // toolStripLabel3
            // 
            toolStripLabel3.Name = "toolStripLabel3";
            toolStripLabel3.Size = new Size(66, 36);
            toolStripLabel3.Text = "Decoration";
            // 
            // cbbDecoration
            // 
            cbbDecoration.BackColor = SystemColors.ActiveCaption;
            cbbDecoration.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbDecoration.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbDecoration.Name = "cbbDecoration";
            cbbDecoration.Size = new Size(150, 39);
            cbbDecoration.SelectedIndexChanged += cbbDecoration_SelectedIndexChanged;
            // 
            // btClearText
            // 
            btClearText.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btClearText.Image = (Image)resources.GetObject("btClearText.Image");
            btClearText.ImageTransparentColor = Color.Magenta;
            btClearText.Name = "btClearText";
            btClearText.Size = new Size(36, 36);
            btClearText.Text = "Clear";
            btClearText.Click += btClearText_Click;
            // 
            // btSave
            // 
            btSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btSave.Image = (Image)resources.GetObject("btSave.Image");
            btSave.ImageTransparentColor = Color.Magenta;
            btSave.Name = "btSave";
            btSave.Size = new Size(36, 36);
            btSave.Text = "Save";
            btSave.Click += btSave_Click;
            // 
            // guna2Elipse1
            // 
            guna2Elipse1.BorderRadius = 30;
            guna2Elipse1.TargetControl = this;
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.Gray;
            guna2Panel1.Controls.Add(guna2Panel2);
            guna2Panel1.Controls.Add(panel1);
            guna2Panel1.CustomizableEdges = customizableEdges7;
            guna2Panel1.Dock = DockStyle.Fill;
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.Padding = new Padding(5);
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2Panel1.Size = new Size(1200, 689);
            guna2Panel1.TabIndex = 2;
            // 
            // guna2Panel2
            // 
            guna2Panel2.BackColor = Color.FromArgb(255, 255, 237);
            guna2Panel2.Controls.Add(gvDis);
            guna2Panel2.Controls.Add(tableLayoutPanel1);
            guna2Panel2.CustomizableEdges = customizableEdges5;
            guna2Panel2.Dock = DockStyle.Fill;
            guna2Panel2.Location = new Point(5, 54);
            guna2Panel2.Name = "guna2Panel2";
            guna2Panel2.Padding = new Padding(10, 0, 10, 10);
            guna2Panel2.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2Panel2.Size = new Size(1190, 630);
            guna2Panel2.TabIndex = 0;
            // 
            // gvDis
            // 
            gvDis.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(164, 164, 164);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(65, 63, 86);
            gvDis.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            gvDis.BackgroundColor = Color.FromArgb(255, 255, 237);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Gray;
            dataGridViewCellStyle2.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.Gray;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            gvDis.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            gvDis.ColumnHeadersHeight = 35;
            gvDis.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            gvDis.Columns.AddRange(new DataGridViewColumn[] { No, Part, MainPart, QTY, Decoration });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.Silver;
            dataGridViewCellStyle3.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(164, 164, 164);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(65, 63, 86);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            gvDis.DefaultCellStyle = dataGridViewCellStyle3;
            gvDis.Dock = DockStyle.Fill;
            gvDis.GridColor = Color.FromArgb(231, 229, 255);
            gvDis.Location = new Point(10, 192);
            gvDis.Name = "gvDis";
            gvDis.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.Silver;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.Silver;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            gvDis.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            gvDis.RowHeadersVisible = false;
            gvDis.RowTemplate.Height = 25;
            gvDis.Size = new Size(1170, 428);
            gvDis.TabIndex = 2;
            gvDis.ThemeStyle.AlternatingRowsStyle.BackColor = Color.LightGray;
            gvDis.ThemeStyle.AlternatingRowsStyle.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            gvDis.ThemeStyle.AlternatingRowsStyle.ForeColor = SystemColors.ControlText;
            gvDis.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.FromArgb(198, 193, 255);
            gvDis.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.FromArgb(65, 63, 86);
            gvDis.ThemeStyle.BackColor = Color.FromArgb(255, 255, 237);
            gvDis.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            gvDis.ThemeStyle.HeaderStyle.BackColor = Color.Gray;
            gvDis.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            gvDis.ThemeStyle.HeaderStyle.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            gvDis.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            gvDis.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            gvDis.ThemeStyle.HeaderStyle.Height = 35;
            gvDis.ThemeStyle.ReadOnly = false;
            gvDis.ThemeStyle.RowsStyle.BackColor = Color.White;
            gvDis.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gvDis.ThemeStyle.RowsStyle.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            gvDis.ThemeStyle.RowsStyle.ForeColor = Color.Black;
            gvDis.ThemeStyle.RowsStyle.Height = 25;
            gvDis.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(198, 193, 255);
            gvDis.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(65, 63, 86);
            gvDis.CellClick += gvDis_CellClick;
            gvDis.CellContentClick += gvDis_CellContentClick;
            gvDis.EditingControlShowing += gvDis_EditingControlShowing;
            gvDis.RowsAdded += gvDis_RowsAdded;
            // 
            // No
            // 
            No.FillWeight = 40F;
            No.HeaderText = "No";
            No.Name = "No";
            No.ReadOnly = true;
            // 
            // Part
            // 
            Part.FillWeight = 90F;
            Part.HeaderText = "Part";
            Part.Name = "Part";
            // 
            // MainPart
            // 
            MainPart.FillWeight = 40F;
            MainPart.HeaderText = "Main Part";
            MainPart.Name = "MainPart";
            MainPart.Resizable = DataGridViewTriState.True;
            MainPart.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // QTY
            // 
            QTY.FillWeight = 40F;
            QTY.HeaderText = "QTY";
            QTY.Name = "QTY";
            // 
            // Decoration
            // 
            Decoration.FillWeight = 78.92789F;
            Decoration.HeaderText = "Decoration";
            Decoration.Name = "Decoration";
            Decoration.ReadOnly = true;
            // 
            // guna2Elipse2
            // 
            guna2Elipse2.BorderRadius = 100;
            guna2Elipse2.TargetControl = guna2Panel2;
            // 
            // ClothingPartinfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 255, 237);
            ClientSize = new Size(1200, 689);
            Controls.Add(guna2Panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ClothingPartinfo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ClothingPart";
            Load += ClothingPartinfo_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btClose).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            guna2Panel3.ResumeLayout(false);
            guna2Panel3.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            guna2Panel1.ResumeLayout(false);
            guna2Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gvDis).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Guna.UI2.WinForms.Guna2PictureBox btClose;
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private Guna.UI2.WinForms.Guna2DataGridView gvDis;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private ToolStrip toolStrip1;
        private ToolStripButton btClearText;
        private ToolStripLabel toolStripLabel1;
        private ToolStripLabel lbStyle;
        private ToolStripComboBox cbbDecoration;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel toolStripLabel3;
        private ToolStripButton btSave;
        private DataGridViewTextBoxColumn No;
        private DataGridViewTextBoxColumn Part;
        private DataGridViewCheckBoxColumn MainPart;
        private DataGridViewTextBoxColumn QTY;
        private DataGridViewTextBoxColumn Decoration;
    }
}