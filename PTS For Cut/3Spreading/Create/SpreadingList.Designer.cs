namespace PTS_For_Cut._3Spreading.Create
{
    partial class SpreadingList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpreadingList));
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            btSearch = new ToolStripButton();
            tbSearch = new ToolStripTextBox();
            cbbTypeOfSearch = new ToolStripComboBox();
            toolStripLabel1 = new ToolStripLabel();
            toolStripSeparator1 = new ToolStripSeparator();
            btSaveStatus = new ToolStripButton();
            cbbSDstatus = new ToolStripComboBox();
            toolStripLabel2 = new ToolStripLabel();
            toolStripSeparator2 = new ToolStripSeparator();
            btClearFabric = new ToolStripButton();
            btPrint = new ToolStripButton();
            btEdit = new ToolStripButton();
            btCreateSDDoc = new ToolStripButton();
            toolStrip1 = new ToolStrip();
            panel2 = new Panel();
            gvDis = new Guna.UI2.WinForms.Guna2DataGridView();
            btCopy = new ToolStripButton();
            toolStrip1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvDis).BeginInit();
            SuspendLayout();
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
            // tbSearch
            // 
            tbSearch.BackColor = SystemColors.ScrollBar;
            tbSearch.CharacterCasing = CharacterCasing.Upper;
            tbSearch.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbSearch.Name = "tbSearch";
            tbSearch.Size = new Size(140, 39);
            tbSearch.KeyUp += tbSearch_KeyUp;
            // 
            // cbbTypeOfSearch
            // 
            cbbTypeOfSearch.BackColor = SystemColors.ScrollBar;
            cbbTypeOfSearch.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbTypeOfSearch.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbTypeOfSearch.Items.AddRange(new object[] { "Spreading Doc No", "SO", "Style" });
            cbbTypeOfSearch.Name = "cbbTypeOfSearch";
            cbbTypeOfSearch.Size = new Size(180, 39);
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(47, 36);
            toolStripLabel1.Text = "Search";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 39);
            // 
            // btSaveStatus
            // 
            btSaveStatus.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btSaveStatus.Image = (Image)resources.GetObject("btSaveStatus.Image");
            btSaveStatus.ImageTransparentColor = Color.Magenta;
            btSaveStatus.Name = "btSaveStatus";
            btSaveStatus.Size = new Size(36, 36);
            btSaveStatus.Text = "Save Edit";
            btSaveStatus.Click += btSaveStatus_Click;
            // 
            // cbbSDstatus
            // 
            cbbSDstatus.BackColor = SystemColors.ScrollBar;
            cbbSDstatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbSDstatus.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbSDstatus.Items.AddRange(new object[] { "Draft", "Comfirm", "Cancel" });
            cbbSDstatus.Name = "cbbSDstatus";
            cbbSDstatus.Size = new Size(80, 39);
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(100, 36);
            toolStripLabel2.Text = "Spreading Status";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 39);
            // 
            // btClearFabric
            // 
            btClearFabric.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btClearFabric.Image = (Image)resources.GetObject("btClearFabric.Image");
            btClearFabric.ImageTransparentColor = Color.Magenta;
            btClearFabric.Name = "btClearFabric";
            btClearFabric.Size = new Size(36, 36);
            btClearFabric.Text = "Clear Fabric";
            btClearFabric.Click += btClearFabric_Click;
            // 
            // btPrint
            // 
            btPrint.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btPrint.Image = (Image)resources.GetObject("btPrint.Image");
            btPrint.ImageTransparentColor = Color.Magenta;
            btPrint.Name = "btPrint";
            btPrint.Size = new Size(36, 36);
            btPrint.Text = "Print";
            btPrint.Click += btPrint_Click;
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
            // btCreateSDDoc
            // 
            btCreateSDDoc.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btCreateSDDoc.Image = (Image)resources.GetObject("btCreateSDDoc.Image");
            btCreateSDDoc.ImageTransparentColor = Color.Magenta;
            btCreateSDDoc.Name = "btCreateSDDoc";
            btCreateSDDoc.Size = new Size(36, 36);
            btCreateSDDoc.Text = "Create Spreading";
            btCreateSDDoc.Click += btCreateSDDoc_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btCreateSDDoc, btEdit, btCopy, btPrint, btClearFabric, toolStripSeparator2, toolStripLabel1, cbbTypeOfSearch, tbSearch, btSearch, toolStripSeparator1, toolStripLabel2, cbbSDstatus, btSaveStatus });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1405, 39);
            toolStrip1.TabIndex = 5;
            toolStrip1.Text = "toolStrip1";
            // 
            // panel2
            // 
            panel2.Controls.Add(gvDis);
            panel2.Controls.Add(toolStrip1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1405, 626);
            panel2.TabIndex = 1;
            // 
            // gvDis
            // 
            gvDis.AllowUserToAddRows = false;
            gvDis.AllowUserToDeleteRows = false;
            gvDis.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(229, 229, 229);
            dataGridViewCellStyle5.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(202, 198, 255);
            dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(71, 69, 94);
            gvDis.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.Gray;
            dataGridViewCellStyle6.Font = new Font("Bahnschrift Condensed", 12.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = Color.White;
            dataGridViewCellStyle6.SelectionBackColor = Color.Gray;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            gvDis.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            gvDis.ColumnHeadersHeight = 35;
            gvDis.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.White;
            dataGridViewCellStyle7.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(202, 198, 255);
            dataGridViewCellStyle7.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            gvDis.DefaultCellStyle = dataGridViewCellStyle7;
            gvDis.Dock = DockStyle.Fill;
            gvDis.GridColor = Color.FromArgb(231, 229, 255);
            gvDis.Location = new Point(0, 39);
            gvDis.Name = "gvDis";
            gvDis.ReadOnly = true;
            gvDis.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.White;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = Color.White;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            gvDis.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            gvDis.RowHeadersVisible = false;
            gvDis.RowTemplate.Height = 25;
            gvDis.SelectionMode = DataGridViewSelectionMode.CellSelect;
            gvDis.Size = new Size(1405, 587);
            gvDis.TabIndex = 6;
            gvDis.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(229, 229, 229);
            gvDis.ThemeStyle.AlternatingRowsStyle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            gvDis.ThemeStyle.AlternatingRowsStyle.ForeColor = SystemColors.ControlText;
            gvDis.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.FromArgb(202, 198, 255);
            gvDis.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            gvDis.ThemeStyle.BackColor = Color.White;
            gvDis.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            gvDis.ThemeStyle.HeaderStyle.BackColor = Color.Gray;
            gvDis.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            gvDis.ThemeStyle.HeaderStyle.Font = new Font("Bahnschrift Condensed", 12.75F, FontStyle.Regular, GraphicsUnit.Point);
            gvDis.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            gvDis.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            gvDis.ThemeStyle.HeaderStyle.Height = 35;
            gvDis.ThemeStyle.ReadOnly = true;
            gvDis.ThemeStyle.RowsStyle.BackColor = Color.White;
            gvDis.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gvDis.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            gvDis.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            gvDis.ThemeStyle.RowsStyle.Height = 25;
            gvDis.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(202, 198, 255);
            gvDis.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            gvDis.CellClick += gvDis_CellClick;
            // 
            // btCopy
            // 
            btCopy.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btCopy.Image = (Image)resources.GetObject("btCopy.Image");
            btCopy.ImageTransparentColor = Color.Magenta;
            btCopy.Name = "btCopy";
            btCopy.Size = new Size(36, 36);
            btCopy.Text = "Copy";
            btCopy.Click += btCopy_Click;
            // 
            // SpreadingList
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1405, 626);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SpreadingList";
            Text = "SpreadingList";
            Load += SpreadingList_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gvDis).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private ToolStripButton btSearch;
        private ToolStripTextBox tbSearch;
        private ToolStripComboBox cbbTypeOfSearch;
        private ToolStripLabel toolStripLabel1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btSaveStatus;
        private ToolStripComboBox cbbSDstatus;
        private ToolStripLabel toolStripLabel2;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton btClearFabric;
        private ToolStripButton btPrint;
        private ToolStripButton btEdit;
        private ToolStripButton btCreateSDDoc;
        private ToolStrip toolStrip1;
        private Panel panel2;
        private Guna.UI2.WinForms.Guna2DataGridView gvDis;
        private ToolStripButton btCopy;
    }
}