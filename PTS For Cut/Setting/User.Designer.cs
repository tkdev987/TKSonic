namespace PTS_For_Cut.Setting
{
    partial class User
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(User));
            gvDis = new Guna.UI2.WinForms.Guna2DataGridView();
            toolStrip1 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripLabel2 = new ToolStripLabel();
            cbbSeachType = new ToolStripComboBox();
            cbbDepartmentSearch = new ToolStripComboBox();
            tbSearch = new ToolStripTextBox();
            btSearch = new ToolStripButton();
            btLoadAll = new ToolStripButton();
            btAddUser = new ToolStripButton();
            btEdit = new ToolStripButton();
            btPermission = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)gvDis).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // gvDis
            // 
            gvDis.AllowUserToAddRows = false;
            gvDis.AllowUserToDeleteRows = false;
            gvDis.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(213, 213, 234);
            dataGridViewCellStyle1.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(184, 184, 220);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(71, 69, 94);
            gvDis.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(128, 128, 192);
            dataGridViewCellStyle2.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(128, 128, 192);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            gvDis.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            gvDis.ColumnHeadersHeight = 35;
            gvDis.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(245, 245, 250);
            dataGridViewCellStyle3.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(184, 184, 220);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            gvDis.DefaultCellStyle = dataGridViewCellStyle3;
            gvDis.Dock = DockStyle.Fill;
            gvDis.GridColor = Color.FromArgb(231, 229, 255);
            gvDis.Location = new Point(0, 39);
            gvDis.Name = "gvDis";
            gvDis.ReadOnly = true;
            gvDis.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(245, 245, 250);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(245, 245, 250);
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            gvDis.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            gvDis.RowHeadersVisible = false;
            gvDis.RowTemplate.Height = 25;
            gvDis.SelectionMode = DataGridViewSelectionMode.CellSelect;
            gvDis.Size = new Size(939, 581);
            gvDis.TabIndex = 0;
            gvDis.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(213, 213, 234);
            gvDis.ThemeStyle.AlternatingRowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            gvDis.ThemeStyle.AlternatingRowsStyle.ForeColor = SystemColors.ControlText;
            gvDis.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.FromArgb(255, 128, 128);
            gvDis.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            gvDis.ThemeStyle.BackColor = Color.White;
            gvDis.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            gvDis.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(128, 128, 192);
            gvDis.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            gvDis.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            gvDis.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            gvDis.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            gvDis.ThemeStyle.HeaderStyle.Height = 35;
            gvDis.ThemeStyle.ReadOnly = true;
            gvDis.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(245, 245, 250);
            gvDis.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gvDis.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            gvDis.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            gvDis.ThemeStyle.RowsStyle.Height = 25;
            gvDis.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(255, 128, 128);
            gvDis.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            gvDis.CellClick += gvDis_CellClick;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1, toolStripSeparator1, toolStripLabel2, cbbSeachType, cbbDepartmentSearch, tbSearch, btSearch, btLoadAll, btAddUser, btEdit, btPermission });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(939, 39);
            toolStrip1.TabIndex = 3;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(64, 36);
            toolStripLabel1.Text = "User Table";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 39);
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(47, 36);
            toolStripLabel2.Text = "Search";
            // 
            // cbbSeachType
            // 
            cbbSeachType.BackColor = SystemColors.ActiveCaption;
            cbbSeachType.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbSeachType.Items.AddRange(new object[] { "ID", "Name", "Department" });
            cbbSeachType.Name = "cbbSeachType";
            cbbSeachType.Size = new Size(121, 39);
            cbbSeachType.SelectedIndexChanged += cbbSeachType_SelectedIndexChanged;
            // 
            // cbbDepartmentSearch
            // 
            cbbDepartmentSearch.BackColor = SystemColors.ActiveCaption;
            cbbDepartmentSearch.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbDepartmentSearch.Name = "cbbDepartmentSearch";
            cbbDepartmentSearch.Size = new Size(160, 39);
            cbbDepartmentSearch.Visible = false;
            // 
            // tbSearch
            // 
            tbSearch.BackColor = SystemColors.ActiveCaption;
            tbSearch.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbSearch.Name = "tbSearch";
            tbSearch.Size = new Size(200, 39);
            tbSearch.KeyUp += tbSearch_KeyUp;
            // 
            // btSearch
            // 
            btSearch.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btSearch.Image = (Image)resources.GetObject("btSearch.Image");
            btSearch.ImageTransparentColor = Color.Magenta;
            btSearch.Name = "btSearch";
            btSearch.Size = new Size(36, 36);
            btSearch.Text = "Search";
            btSearch.Click += btSearch_Click;
            // 
            // btLoadAll
            // 
            btLoadAll.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btLoadAll.Image = (Image)resources.GetObject("btLoadAll.Image");
            btLoadAll.ImageTransparentColor = Color.Magenta;
            btLoadAll.Name = "btLoadAll";
            btLoadAll.Size = new Size(36, 36);
            btLoadAll.Text = "Load All";
            btLoadAll.Click += btLoadAll_Click;
            // 
            // btAddUser
            // 
            btAddUser.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btAddUser.Image = (Image)resources.GetObject("btAddUser.Image");
            btAddUser.ImageTransparentColor = Color.Magenta;
            btAddUser.Name = "btAddUser";
            btAddUser.Size = new Size(36, 36);
            btAddUser.Text = "Add User";
            btAddUser.Click += btAddUser_Click;
            // 
            // btEdit
            // 
            btEdit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btEdit.Image = (Image)resources.GetObject("btEdit.Image");
            btEdit.ImageTransparentColor = Color.Magenta;
            btEdit.Name = "btEdit";
            btEdit.Size = new Size(36, 36);
            btEdit.Text = "Edit";
            btEdit.Click += btEdit_Click;
            // 
            // btPermission
            // 
            btPermission.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btPermission.Image = (Image)resources.GetObject("btPermission.Image");
            btPermission.ImageTransparentColor = Color.Magenta;
            btPermission.Name = "btPermission";
            btPermission.Size = new Size(36, 36);
            btPermission.Text = "Permission";
            btPermission.Click += btPermission_Click;
            // 
            // User
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(939, 620);
            Controls.Add(gvDis);
            Controls.Add(toolStrip1);
            Name = "User";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "User";
            Load += User_Load;
            ((System.ComponentModel.ISupportInitialize)gvDis).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView gvDis;
        private Panel panel1;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel toolStripLabel2;
        private ToolStripComboBox cbbSeachType;
        private ToolStripComboBox cbbDepartmentSearch;
        private ToolStripTextBox tbSearch;
        private ToolStripButton btSearch;
        private ToolStrip toolStrip2;
        private ToolStripButton toolStripButton2;
        private TableLayoutPanel tableLayoutPanel1;
        private ToolStripButton btEdit;
        private ToolStripButton btAddUser;
        private ToolStripButton btPermission;
        private ToolStripButton btLoadAll;
    }
}