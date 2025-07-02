namespace PTS_For_Cut._3Spreading.Create
{
    partial class SelectFabric
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectFabric));
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            gvDisStock = new DataGridView();
            Select = new DataGridViewCheckBoxColumn();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            toolStrip1 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            tbBarcode = new ToolStripTextBox();
            btSearch = new ToolStripButton();
            btSeparate = new ToolStripButton();
            btFabricDetail = new ToolStripButton();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel5 = new Panel();
            lbSD_Color = new Label();
            label4 = new Label();
            panel6 = new Panel();
            lbFbType = new Label();
            panel7 = new Panel();
            panel8 = new Panel();
            cbbColor = new ComboBox();
            label3 = new Label();
            cbbPO = new ComboBox();
            label8 = new Label();
            panel2 = new Panel();
            tableLayoutPanel3 = new TableLayoutPanel();
            panel9 = new Panel();
            label5 = new Label();
            panel10 = new Panel();
            label6 = new Label();
            panel11 = new Panel();
            lbPliesSD = new Label();
            panel12 = new Panel();
            lbMarkerLengthYard = new Label();
            panel13 = new Panel();
            label7 = new Label();
            panel14 = new Panel();
            lbPliesSelect = new Label();
            panel15 = new Panel();
            label9 = new Label();
            panel16 = new Panel();
            lbOverSD = new Label();
            panel21 = new Panel();
            toolStrip2 = new ToolStrip();
            btOk = new ToolStripButton();
            panel3 = new Panel();
            label1 = new Label();
            panel4 = new Panel();
            gvDisSelected = new DataGridView();
            Select2 = new DataGridViewCheckBoxColumn();
            label2 = new Label();
            pageSetupDialog1 = new PageSetupDialog();
            ((System.ComponentModel.ISupportInitialize)gvDisStock).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            toolStrip1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel8.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            panel9.SuspendLayout();
            panel10.SuspendLayout();
            panel11.SuspendLayout();
            panel12.SuspendLayout();
            panel13.SuspendLayout();
            panel14.SuspendLayout();
            panel15.SuspendLayout();
            panel16.SuspendLayout();
            toolStrip2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvDisSelected).BeginInit();
            SuspendLayout();
            // 
            // gvDisStock
            // 
            gvDisStock.AllowUserToAddRows = false;
            gvDisStock.AllowUserToDeleteRows = false;
            gvDisStock.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gvDisStock.BackgroundColor = SystemColors.Control;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Gainsboro;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            gvDisStock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gvDisStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvDisStock.Columns.AddRange(new DataGridViewColumn[] { Select });
            gvDisStock.EnableHeadersVisualStyles = false;
            gvDisStock.Location = new Point(9, 36);
            gvDisStock.Name = "gvDisStock";
            gvDisStock.RowHeadersWidth = 15;
            gvDisStock.RowTemplate.Height = 35;
            gvDisStock.Size = new Size(852, 422);
            gvDisStock.TabIndex = 11;
            gvDisStock.CellClick += gvDisStock_CellClick;
            gvDisStock.CellContentClick += gvDisStock_CellContentClick;
            gvDisStock.RowsAdded += gvDisStock_RowsAdded;
            // 
            // Select
            // 
            Select.HeaderText = "Select";
            Select.Name = "Select";
            Select.Width = 55;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(panel2, 1, 0);
            tableLayoutPanel1.Controls.Add(panel3, 0, 1);
            tableLayoutPanel1.Controls.Add(panel4, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 160F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1583, 633);
            tableLayoutPanel1.TabIndex = 12;
            // 
            // panel1
            // 
            panel1.Controls.Add(toolStrip1);
            panel1.Controls.Add(tableLayoutPanel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(864, 154);
            panel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.Bottom;
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1, tbBarcode, btSearch, btSeparate, btFabricDetail });
            toolStrip1.Location = new Point(0, 115);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(864, 39);
            toolStrip1.TabIndex = 3;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(57, 36);
            toolStripLabel1.Text = "Search";
            // 
            // tbBarcode
            // 
            tbBarcode.BackColor = SystemColors.ScrollBar;
            tbBarcode.BorderStyle = BorderStyle.None;
            tbBarcode.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbBarcode.Name = "tbBarcode";
            tbBarcode.Size = new Size(200, 39);
            tbBarcode.KeyUp += tbBarcode_KeyUp;
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
            // btSeparate
            // 
            btSeparate.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btSeparate.Image = (Image)resources.GetObject("btSeparate.Image");
            btSeparate.ImageTransparentColor = Color.Magenta;
            btSeparate.Name = "btSeparate";
            btSeparate.Size = new Size(36, 36);
            btSeparate.Text = "Separate";
            btSeparate.Click += btSeparate_Click;
            // 
            // btFabricDetail
            // 
            btFabricDetail.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btFabricDetail.Image = (Image)resources.GetObject("btFabricDetail.Image");
            btFabricDetail.ImageTransparentColor = Color.Magenta;
            btFabricDetail.Name = "btFabricDetail";
            btFabricDetail.Size = new Size(36, 36);
            btFabricDetail.Text = "Fabric Status";
            btFabricDetail.Click += btFabricDetail_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 83.21678F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.7832165F));
            tableLayoutPanel2.Controls.Add(panel5, 0, 0);
            tableLayoutPanel2.Controls.Add(panel6, 1, 0);
            tableLayoutPanel2.Controls.Add(panel7, 1, 1);
            tableLayoutPanel2.Controls.Add(panel8, 0, 1);
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(858, 72);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // panel5
            // 
            panel5.Controls.Add(lbSD_Color);
            panel5.Controls.Add(label4);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(3, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(708, 30);
            panel5.TabIndex = 0;
            // 
            // lbSD_Color
            // 
            lbSD_Color.AutoSize = true;
            lbSD_Color.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbSD_Color.Location = new Point(132, 5);
            lbSD_Color.Name = "lbSD_Color";
            lbSD_Color.Size = new Size(38, 21);
            lbSD_Color.TabIndex = 1;
            lbSD_Color.Text = "xxxx";
            lbSD_Color.Click += lbSD_Color_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(3, 7);
            label4.Name = "label4";
            label4.Size = new Size(123, 21);
            label4.TabIndex = 1;
            label4.Text = "Spreading Color";
            // 
            // panel6
            // 
            panel6.Controls.Add(lbFbType);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(717, 3);
            panel6.Name = "panel6";
            panel6.Size = new Size(138, 30);
            panel6.TabIndex = 0;
            // 
            // lbFbType
            // 
            lbFbType.AutoSize = true;
            lbFbType.Dock = DockStyle.Left;
            lbFbType.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbFbType.Location = new Point(0, 0);
            lbFbType.Name = "lbFbType";
            lbFbType.Size = new Size(87, 21);
            lbFbType.TabIndex = 2;
            lbFbType.Text = "Fabric Type";
            // 
            // panel7
            // 
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(717, 39);
            panel7.Name = "panel7";
            panel7.Size = new Size(138, 30);
            panel7.TabIndex = 1;
            // 
            // panel8
            // 
            panel8.Controls.Add(cbbColor);
            panel8.Controls.Add(label3);
            panel8.Controls.Add(cbbPO);
            panel8.Controls.Add(label8);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(3, 39);
            panel8.Name = "panel8";
            panel8.Size = new Size(708, 30);
            panel8.TabIndex = 1;
            // 
            // cbbColor
            // 
            cbbColor.Dock = DockStyle.Left;
            cbbColor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbColor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbColor.FormattingEnabled = true;
            cbbColor.Location = new Point(446, 0);
            cbbColor.Name = "cbbColor";
            cbbColor.RightToLeft = RightToLeft.No;
            cbbColor.Size = new Size(259, 29);
            cbbColor.TabIndex = 0;
            cbbColor.SelectedIndexChanged += cbbColor_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Left;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(341, 0);
            label3.Name = "label3";
            label3.Size = new Size(105, 21);
            label3.TabIndex = 1;
            label3.Text = "   Select Color";
            // 
            // cbbPO
            // 
            cbbPO.Dock = DockStyle.Left;
            cbbPO.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbPO.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbbPO.FormattingEnabled = true;
            cbbPO.Location = new Point(130, 0);
            cbbPO.Name = "cbbPO";
            cbbPO.RightToLeft = RightToLeft.No;
            cbbPO.Size = new Size(211, 29);
            cbbPO.TabIndex = 3;
            cbbPO.SelectedIndexChanged += cbbPO_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Dock = DockStyle.Left;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(0, 0);
            label8.Name = "label8";
            label8.Size = new Size(130, 21);
            label8.TabIndex = 2;
            label8.Text = "Select ( Lot / PO )";
            // 
            // panel2
            // 
            panel2.Controls.Add(tableLayoutPanel3);
            panel2.Controls.Add(toolStrip2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(873, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(707, 154);
            panel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel3.ColumnCount = 4;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.Controls.Add(panel9, 0, 0);
            tableLayoutPanel3.Controls.Add(panel10, 1, 0);
            tableLayoutPanel3.Controls.Add(panel11, 1, 1);
            tableLayoutPanel3.Controls.Add(panel12, 0, 1);
            tableLayoutPanel3.Controls.Add(panel13, 2, 0);
            tableLayoutPanel3.Controls.Add(panel14, 2, 1);
            tableLayoutPanel3.Controls.Add(panel15, 3, 0);
            tableLayoutPanel3.Controls.Add(panel16, 3, 1);
            tableLayoutPanel3.Controls.Add(panel21, 0, 2);
            tableLayoutPanel3.Location = new Point(3, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.Size = new Size(701, 112);
            tableLayoutPanel3.TabIndex = 4;
            // 
            // panel9
            // 
            panel9.Controls.Add(label5);
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(3, 3);
            panel9.Name = "panel9";
            panel9.Size = new Size(169, 31);
            panel9.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(3, 5);
            label5.Name = "label5";
            label5.Size = new Size(147, 21);
            label5.TabIndex = 1;
            label5.Text = "MarkerLength(YDS)";
            // 
            // panel10
            // 
            panel10.Controls.Add(label6);
            panel10.Dock = DockStyle.Fill;
            panel10.Location = new Point(178, 3);
            panel10.Name = "panel10";
            panel10.Size = new Size(169, 31);
            panel10.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(3, 5);
            label6.Name = "label6";
            label6.Size = new Size(155, 21);
            label6.TabIndex = 1;
            label6.Text = "Plies from Spreading";
            // 
            // panel11
            // 
            panel11.Controls.Add(lbPliesSD);
            panel11.Dock = DockStyle.Fill;
            panel11.Location = new Point(178, 40);
            panel11.Name = "panel11";
            panel11.Size = new Size(169, 31);
            panel11.TabIndex = 1;
            // 
            // lbPliesSD
            // 
            lbPliesSD.AutoSize = true;
            lbPliesSD.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbPliesSD.Location = new Point(3, 3);
            lbPliesSD.Name = "lbPliesSD";
            lbPliesSD.Size = new Size(38, 21);
            lbPliesSD.TabIndex = 1;
            lbPliesSD.Text = "xxxx";
            // 
            // panel12
            // 
            panel12.Controls.Add(lbMarkerLengthYard);
            panel12.Dock = DockStyle.Fill;
            panel12.Location = new Point(3, 40);
            panel12.Name = "panel12";
            panel12.Size = new Size(169, 31);
            panel12.TabIndex = 1;
            panel12.Paint += panel12_Paint;
            // 
            // lbMarkerLengthYard
            // 
            lbMarkerLengthYard.AutoSize = true;
            lbMarkerLengthYard.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbMarkerLengthYard.Location = new Point(3, 3);
            lbMarkerLengthYard.Name = "lbMarkerLengthYard";
            lbMarkerLengthYard.Size = new Size(38, 21);
            lbMarkerLengthYard.TabIndex = 1;
            lbMarkerLengthYard.Text = "xxxx";
            // 
            // panel13
            // 
            panel13.Controls.Add(label7);
            panel13.Dock = DockStyle.Fill;
            panel13.Location = new Point(353, 3);
            panel13.Name = "panel13";
            panel13.Size = new Size(169, 31);
            panel13.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(3, 5);
            label7.Name = "label7";
            label7.Size = new Size(170, 21);
            label7.TabIndex = 1;
            label7.Text = "Plies Of Fabric Selected";
            // 
            // panel14
            // 
            panel14.Controls.Add(lbPliesSelect);
            panel14.Dock = DockStyle.Fill;
            panel14.Location = new Point(353, 40);
            panel14.Name = "panel14";
            panel14.Size = new Size(169, 31);
            panel14.TabIndex = 3;
            // 
            // lbPliesSelect
            // 
            lbPliesSelect.AutoSize = true;
            lbPliesSelect.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbPliesSelect.Location = new Point(3, 5);
            lbPliesSelect.Name = "lbPliesSelect";
            lbPliesSelect.Size = new Size(38, 21);
            lbPliesSelect.TabIndex = 1;
            lbPliesSelect.Text = "xxxx";
            // 
            // panel15
            // 
            panel15.Controls.Add(label9);
            panel15.Dock = DockStyle.Fill;
            panel15.Location = new Point(528, 3);
            panel15.Name = "panel15";
            panel15.Size = new Size(170, 31);
            panel15.TabIndex = 4;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(3, 3);
            label9.Name = "label9";
            label9.Size = new Size(146, 21);
            label9.TabIndex = 1;
            label9.Text = "Over Spreading (%)";
            // 
            // panel16
            // 
            panel16.Controls.Add(lbOverSD);
            panel16.Dock = DockStyle.Fill;
            panel16.Location = new Point(528, 40);
            panel16.Name = "panel16";
            panel16.Size = new Size(170, 31);
            panel16.TabIndex = 4;
            // 
            // lbOverSD
            // 
            lbOverSD.AutoSize = true;
            lbOverSD.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbOverSD.Location = new Point(3, 5);
            lbOverSD.Name = "lbOverSD";
            lbOverSD.Size = new Size(19, 21);
            lbOverSD.TabIndex = 1;
            lbOverSD.Text = "0";
            // 
            // panel21
            // 
            panel21.Dock = DockStyle.Fill;
            panel21.Location = new Point(3, 77);
            panel21.Name = "panel21";
            panel21.Size = new Size(169, 32);
            panel21.TabIndex = 5;
            // 
            // toolStrip2
            // 
            toolStrip2.Dock = DockStyle.Bottom;
            toolStrip2.ImageScalingSize = new Size(32, 32);
            toolStrip2.Items.AddRange(new ToolStripItem[] { btOk });
            toolStrip2.Location = new Point(0, 115);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(707, 39);
            toolStrip2.TabIndex = 13;
            toolStrip2.Text = "toolStrip2";
            // 
            // btOk
            // 
            btOk.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btOk.Image = (Image)resources.GetObject("btOk.Image");
            btOk.ImageTransparentColor = Color.Magenta;
            btOk.Name = "btOk";
            btOk.Size = new Size(36, 36);
            btOk.Text = "OK";
            btOk.Click += btOk_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(label1);
            panel3.Controls.Add(gvDisStock);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 163);
            panel3.Name = "panel3";
            panel3.Size = new Size(864, 467);
            panel3.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(9, 12);
            label1.Name = "label1";
            label1.Size = new Size(109, 21);
            label1.TabIndex = 12;
            label1.Text = "Fabric In Stock";
            // 
            // panel4
            // 
            panel4.Controls.Add(gvDisSelected);
            panel4.Controls.Add(label2);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(873, 163);
            panel4.Name = "panel4";
            panel4.Size = new Size(707, 467);
            panel4.TabIndex = 2;
            panel4.Paint += panel4_Paint;
            // 
            // gvDisSelected
            // 
            gvDisSelected.AllowUserToAddRows = false;
            gvDisSelected.AllowUserToDeleteRows = false;
            gvDisSelected.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gvDisSelected.BackgroundColor = SystemColors.Control;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Gainsboro;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            gvDisSelected.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            gvDisSelected.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvDisSelected.Columns.AddRange(new DataGridViewColumn[] { Select2 });
            gvDisSelected.EnableHeadersVisualStyles = false;
            gvDisSelected.Location = new Point(3, 36);
            gvDisSelected.Name = "gvDisSelected";
            gvDisSelected.RowHeadersWidth = 15;
            gvDisSelected.RowTemplate.Height = 35;
            gvDisSelected.Size = new Size(695, 422);
            gvDisSelected.TabIndex = 11;
            gvDisSelected.CellContentClick += gvDisSelected_CellContentClick;
            gvDisSelected.RowsAdded += gvDisSelected_RowsAdded;
            // 
            // Select2
            // 
            Select2.HeaderText = "Select";
            Select2.Name = "Select2";
            Select2.Width = 55;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(18, 12);
            label2.Name = "label2";
            label2.Size = new Size(113, 21);
            label2.TabIndex = 12;
            label2.Text = "Fabric Selected";
            // 
            // SelectFabric
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1583, 633);
            Controls.Add(tableLayoutPanel1);
            Name = "SelectFabric";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SelectFabric";
            WindowState = FormWindowState.Maximized;
            FormClosing += SelectFabric_FormClosing;
            FormClosed += SelectFabric_FormClosed;
            Load += SelectFabric_Load;
            ((System.ComponentModel.ISupportInitialize)gvDisStock).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            panel12.ResumeLayout(false);
            panel12.PerformLayout();
            panel13.ResumeLayout(false);
            panel13.PerformLayout();
            panel14.ResumeLayout(false);
            panel14.PerformLayout();
            panel15.ResumeLayout(false);
            panel15.PerformLayout();
            panel16.ResumeLayout(false);
            panel16.PerformLayout();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gvDisSelected).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gvDisStock;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private Label label2;
        private DataGridView gvDisSelected;
        private ToolStrip toolStrip2;
        private ToolStripButton btOk;
        private Panel panel3;
        private Panel panel4;
        private Label label3;
        private ComboBox cbbColor;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Label label4;
        private Label lbSD_Color;
        private DataGridViewCheckBoxColumn Select;
        private DataGridViewCheckBoxColumn Select2;
        private ToolStrip toolStrip1;
        private ToolStripButton btSeparate;
        private ToolStripLabel toolStripLabel1;
        private ToolStripTextBox tbBarcode;
        private ToolStripButton btSearch;
        private TableLayoutPanel tableLayoutPanel3;
        private Panel panel9;
        private Label label5;
        private Panel panel10;
        private Label lbMarkerLengthYard;
        private Panel panel11;
        private Panel panel12;
        private Label label6;
        private Label lbPliesSD;
        private Panel panel13;
        private Label label7;
        private Panel panel14;
        private Label lbPliesSelect;
        private Panel panel15;
        private Label label9;
        private Panel panel16;
        private Label lbOverSD;
        private Label lbFbType;
        private Panel panel21;
        private PageSetupDialog pageSetupDialog1;
        private ToolStripButton btFabricDetail;
        private ComboBox cbbPO;
        private Label label8;
    }
}