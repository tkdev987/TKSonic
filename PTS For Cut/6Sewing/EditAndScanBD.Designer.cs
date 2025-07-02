namespace PTS_For_Cut._6Sewing
{
    partial class EditAndScanBD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditAndScanBD));
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            pnScan = new Panel();
            gvScan = new Guna.UI2.WinForms.Guna2DataGridView();
            toolStrip1 = new ToolStrip();
            lbBDid = new ToolStripLabel();
            tbBundleID = new ToolStripTextBox();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripLabel2 = new ToolStripLabel();
            tbQtyCut = new ToolStripTextBox();
            toolStripLabel3 = new ToolStripLabel();
            tbQtyOut = new ToolStripTextBox();
            toolStripLabel4 = new ToolStripLabel();
            cbbLine = new ToolStripComboBox();
            btSave = new ToolStripButton();
            btDelete = new ToolStripButton();
            panel2 = new Panel();
            dtpTime = new DateTimePicker();
            dtpDate = new DateTimePicker();
            lbEditAndScan = new Label();
            pnSD = new Panel();
            gvSew = new Guna.UI2.WinForms.Guna2DataGridView();
            toolStrip2 = new ToolStrip();
            toolStripLabel5 = new ToolStripLabel();
            gvCut = new Guna.UI2.WinForms.Guna2DataGridView();
            toolStrip3 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            pnScan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvScan).BeginInit();
            toolStrip1.SuspendLayout();
            panel2.SuspendLayout();
            pnSD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvSew).BeginInit();
            toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvCut).BeginInit();
            toolStrip3.SuspendLayout();
            SuspendLayout();
            // 
            // pnScan
            // 
            pnScan.Controls.Add(gvScan);
            pnScan.Controls.Add(toolStrip1);
            pnScan.Controls.Add(panel2);
            pnScan.Dock = DockStyle.Fill;
            pnScan.Location = new Point(0, 0);
            pnScan.Name = "pnScan";
            pnScan.Size = new Size(784, 735);
            pnScan.TabIndex = 0;
            // 
            // gvScan
            // 
            gvScan.AllowUserToAddRows = false;
            gvScan.AllowUserToDeleteRows = false;
            gvScan.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(219, 219, 219);
            dataGridViewCellStyle1.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(197, 191, 255);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(71, 69, 94);
            gvScan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Gray;
            dataGridViewCellStyle2.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.Gray;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            gvScan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            gvScan.ColumnHeadersHeight = 35;
            gvScan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(197, 191, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            gvScan.DefaultCellStyle = dataGridViewCellStyle3;
            gvScan.Dock = DockStyle.Fill;
            gvScan.GridColor = Color.FromArgb(231, 229, 255);
            gvScan.Location = new Point(0, 69);
            gvScan.Name = "gvScan";
            gvScan.ReadOnly = true;
            gvScan.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.White;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            gvScan.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            gvScan.RowHeadersVisible = false;
            gvScan.RowTemplate.Height = 25;
            gvScan.SelectionMode = DataGridViewSelectionMode.CellSelect;
            gvScan.Size = new Size(784, 666);
            gvScan.TabIndex = 2;
            gvScan.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            gvScan.ThemeStyle.AlternatingRowsStyle.Font = null;
            gvScan.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            gvScan.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            gvScan.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            gvScan.ThemeStyle.BackColor = Color.White;
            gvScan.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            gvScan.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            gvScan.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            gvScan.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            gvScan.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            gvScan.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            gvScan.ThemeStyle.HeaderStyle.Height = 35;
            gvScan.ThemeStyle.ReadOnly = true;
            gvScan.ThemeStyle.RowsStyle.BackColor = Color.White;
            gvScan.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gvScan.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            gvScan.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            gvScan.ThemeStyle.RowsStyle.Height = 25;
            gvScan.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            gvScan.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            gvScan.CellClick += gvScan_CellClick;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { lbBDid, tbBundleID, toolStripSeparator1, toolStripLabel2, tbQtyCut, toolStripLabel3, tbQtyOut, toolStripLabel4, cbbLine, btSave, btDelete });
            toolStrip1.Location = new Point(0, 30);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(784, 39);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // lbBDid
            // 
            lbBDid.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbBDid.Name = "lbBDid";
            lbBDid.Size = new Size(59, 36);
            lbBDid.Text = "Bundle ID";
            // 
            // tbBundleID
            // 
            tbBundleID.BackColor = SystemColors.ActiveCaption;
            tbBundleID.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbBundleID.Name = "tbBundleID";
            tbBundleID.Size = new Size(140, 39);
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
            toolStripLabel2.Size = new Size(50, 36);
            toolStripLabel2.Text = "Cut QTY";
            // 
            // tbQtyCut
            // 
            tbQtyCut.BackColor = SystemColors.ActiveCaption;
            tbQtyCut.Enabled = false;
            tbQtyCut.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbQtyCut.Name = "tbQtyCut";
            tbQtyCut.Size = new Size(70, 39);
            // 
            // toolStripLabel3
            // 
            toolStripLabel3.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel3.Name = "toolStripLabel3";
            toolStripLabel3.Size = new Size(57, 36);
            toolStripLabel3.Text = "Scan Out";
            // 
            // tbQtyOut
            // 
            tbQtyOut.BackColor = SystemColors.ActiveCaption;
            tbQtyOut.Name = "tbQtyOut";
            tbQtyOut.Size = new Size(70, 39);
            tbQtyOut.KeyPress += tbQtyOut_KeyPress;
            tbQtyOut.Click += tbQtyOut_Click;
            // 
            // toolStripLabel4
            // 
            toolStripLabel4.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel4.Name = "toolStripLabel4";
            toolStripLabel4.Size = new Size(31, 36);
            toolStripLabel4.Text = "Line";
            // 
            // cbbLine
            // 
            cbbLine.BackColor = SystemColors.ActiveCaption;
            cbbLine.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbLine.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbLine.Name = "cbbLine";
            cbbLine.Size = new Size(121, 39);
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
            // btDelete
            // 
            btDelete.Alignment = ToolStripItemAlignment.Right;
            btDelete.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btDelete.Image = (Image)resources.GetObject("btDelete.Image");
            btDelete.ImageTransparentColor = Color.Magenta;
            btDelete.Name = "btDelete";
            btDelete.Size = new Size(36, 36);
            btDelete.Text = "Delete";
            btDelete.Click += btDelete_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(dtpTime);
            panel2.Controls.Add(dtpDate);
            panel2.Controls.Add(lbEditAndScan);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(784, 30);
            panel2.TabIndex = 5;
            // 
            // dtpTime
            // 
            dtpTime.CalendarFont = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dtpTime.Dock = DockStyle.Left;
            dtpTime.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dtpTime.Format = DateTimePickerFormat.Time;
            dtpTime.Location = new Point(155, 0);
            dtpTime.Name = "dtpTime";
            dtpTime.ShowUpDown = true;
            dtpTime.Size = new Size(98, 27);
            dtpTime.TabIndex = 3;
            // 
            // dtpDate
            // 
            dtpDate.CalendarFont = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDate.Dock = DockStyle.Left;
            dtpDate.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(38, 0);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(117, 27);
            dtpDate.TabIndex = 4;
            // 
            // lbEditAndScan
            // 
            lbEditAndScan.AutoSize = true;
            lbEditAndScan.Dock = DockStyle.Left;
            lbEditAndScan.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbEditAndScan.Location = new Point(0, 0);
            lbEditAndScan.Name = "lbEditAndScan";
            lbEditAndScan.Size = new Size(38, 23);
            lbEditAndScan.TabIndex = 5;
            lbEditAndScan.Text = "XXXX";
            // 
            // pnSD
            // 
            pnSD.Controls.Add(gvSew);
            pnSD.Controls.Add(toolStrip2);
            pnSD.Controls.Add(gvCut);
            pnSD.Controls.Add(toolStrip3);
            pnSD.Dock = DockStyle.Right;
            pnSD.Location = new Point(784, 0);
            pnSD.Name = "pnSD";
            pnSD.Size = new Size(377, 735);
            pnSD.TabIndex = 2;
            // 
            // gvSew
            // 
            gvSew.AllowUserToAddRows = false;
            gvSew.AllowUserToDeleteRows = false;
            gvSew.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(219, 219, 219);
            dataGridViewCellStyle5.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(197, 191, 255);
            dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(71, 69, 94);
            gvSew.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.Gray;
            dataGridViewCellStyle6.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = Color.White;
            dataGridViewCellStyle6.SelectionBackColor = Color.Gray;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            gvSew.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            gvSew.ColumnHeadersHeight = 35;
            gvSew.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.White;
            dataGridViewCellStyle7.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(197, 191, 255);
            dataGridViewCellStyle7.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            gvSew.DefaultCellStyle = dataGridViewCellStyle7;
            gvSew.Dock = DockStyle.Fill;
            gvSew.GridColor = Color.FromArgb(231, 229, 255);
            gvSew.Location = new Point(0, 491);
            gvSew.Name = "gvSew";
            gvSew.ReadOnly = true;
            gvSew.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.White;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = Color.White;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            gvSew.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            gvSew.RowHeadersVisible = false;
            gvSew.RowTemplate.Height = 25;
            gvSew.SelectionMode = DataGridViewSelectionMode.CellSelect;
            gvSew.Size = new Size(377, 244);
            gvSew.TabIndex = 5;
            gvSew.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            gvSew.ThemeStyle.AlternatingRowsStyle.Font = null;
            gvSew.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            gvSew.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            gvSew.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            gvSew.ThemeStyle.BackColor = Color.White;
            gvSew.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            gvSew.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            gvSew.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            gvSew.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            gvSew.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            gvSew.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            gvSew.ThemeStyle.HeaderStyle.Height = 35;
            gvSew.ThemeStyle.ReadOnly = true;
            gvSew.ThemeStyle.RowsStyle.BackColor = Color.White;
            gvSew.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gvSew.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            gvSew.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            gvSew.ThemeStyle.RowsStyle.Height = 25;
            gvSew.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            gvSew.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // toolStrip2
            // 
            toolStrip2.Items.AddRange(new ToolStripItem[] { toolStripLabel5 });
            toolStrip2.Location = new Point(0, 466);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(377, 25);
            toolStrip2.TabIndex = 4;
            toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel5
            // 
            toolStripLabel5.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel5.Name = "toolStripLabel5";
            toolStripLabel5.Size = new Size(168, 22);
            toolStripLabel5.Text = "Bundle Scan Otu From Sewing";
            // 
            // gvCut
            // 
            gvCut.AllowUserToAddRows = false;
            gvCut.AllowUserToDeleteRows = false;
            gvCut.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = Color.FromArgb(219, 219, 219);
            dataGridViewCellStyle9.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle9.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(197, 191, 255);
            dataGridViewCellStyle9.SelectionForeColor = Color.FromArgb(71, 69, 94);
            gvCut.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = Color.Gray;
            dataGridViewCellStyle10.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle10.ForeColor = Color.White;
            dataGridViewCellStyle10.SelectionBackColor = Color.Gray;
            dataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
            gvCut.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            gvCut.ColumnHeadersHeight = 35;
            gvCut.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = Color.White;
            dataGridViewCellStyle11.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle11.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle11.SelectionBackColor = Color.FromArgb(197, 191, 255);
            dataGridViewCellStyle11.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.False;
            gvCut.DefaultCellStyle = dataGridViewCellStyle11;
            gvCut.Dock = DockStyle.Top;
            gvCut.GridColor = Color.FromArgb(231, 229, 255);
            gvCut.Location = new Point(0, 25);
            gvCut.Name = "gvCut";
            gvCut.ReadOnly = true;
            gvCut.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = Color.White;
            dataGridViewCellStyle12.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle12.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = Color.White;
            dataGridViewCellStyle12.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.True;
            gvCut.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            gvCut.RowHeadersVisible = false;
            gvCut.RowTemplate.Height = 25;
            gvCut.SelectionMode = DataGridViewSelectionMode.CellSelect;
            gvCut.Size = new Size(377, 441);
            gvCut.TabIndex = 3;
            gvCut.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            gvCut.ThemeStyle.AlternatingRowsStyle.Font = null;
            gvCut.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            gvCut.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            gvCut.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            gvCut.ThemeStyle.BackColor = Color.White;
            gvCut.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            gvCut.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            gvCut.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            gvCut.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            gvCut.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            gvCut.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            gvCut.ThemeStyle.HeaderStyle.Height = 35;
            gvCut.ThemeStyle.ReadOnly = true;
            gvCut.ThemeStyle.RowsStyle.BackColor = Color.White;
            gvCut.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gvCut.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            gvCut.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            gvCut.ThemeStyle.RowsStyle.Height = 25;
            gvCut.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            gvCut.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // toolStrip3
            // 
            toolStrip3.ImageScalingSize = new Size(32, 32);
            toolStrip3.Items.AddRange(new ToolStripItem[] { toolStripLabel1 });
            toolStrip3.Location = new Point(0, 0);
            toolStrip3.Name = "toolStrip3";
            toolStrip3.Size = new Size(377, 25);
            toolStrip3.TabIndex = 0;
            toolStrip3.Text = "toolStrip3";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(166, 22);
            toolStripLabel1.Text = "Generate Bundle from Cutting";
            // 
            // EditAndScanBD
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1161, 735);
            Controls.Add(pnScan);
            Controls.Add(pnSD);
            Name = "EditAndScanBD";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EditAndScanBD";
            WindowState = FormWindowState.Maximized;
            Load += EditAndScanBD_Load;
            pnScan.ResumeLayout(false);
            pnScan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gvScan).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            pnSD.ResumeLayout(false);
            pnSD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gvSew).EndInit();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gvCut).EndInit();
            toolStrip3.ResumeLayout(false);
            toolStrip3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnScan;
        private ToolStrip toolStrip1;
        private ToolStripLabel lbBDid;
        private ToolStripButton btSave;
        private Panel pnSD;
        private ToolStrip toolStrip3;
        private ToolStripTextBox tbBundleID;
        private Guna.UI2.WinForms.Guna2DataGridView gvScan;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel toolStripLabel2;
        private ToolStripTextBox tbQtyCut;
        private ToolStripLabel toolStripLabel3;
        private ToolStripTextBox tbQtyOut;
        private ToolStripLabel toolStripLabel4;
        private ToolStripComboBox cbbLine;
        private DateTimePicker dtpTime;
        private Panel panel2;
        private DateTimePicker dtpDate;
        private Label lbEditAndScan;
        private Guna.UI2.WinForms.Guna2DataGridView gvCut;
        private Guna.UI2.WinForms.Guna2DataGridView gvSew;
        private ToolStrip toolStrip2;
        private ToolStripLabel toolStripLabel5;
        private ToolStripLabel toolStripLabel1;
        private ToolStripButton btDelete;
    }
}