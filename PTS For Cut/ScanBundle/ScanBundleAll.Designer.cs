namespace PTS_For_Cut.ScanBundle
{
    partial class ScanBundleAll
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScanBundleAll));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnHeader = new Panel();
            lbHeader = new Label();
            pnFooter = new Panel();
            pbSave = new PictureBox();
            gvDisData = new DataGridView();
            toolStrip1 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            pnHeader.SuspendLayout();
            pnFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbSave).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvDisData).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pnHeader
            // 
            pnHeader.Controls.Add(lbHeader);
            pnHeader.Dock = DockStyle.Top;
            pnHeader.Location = new Point(0, 0);
            pnHeader.Name = "pnHeader";
            pnHeader.Size = new Size(1116, 52);
            pnHeader.TabIndex = 1;
            // 
            // lbHeader
            // 
            lbHeader.AutoSize = true;
            lbHeader.Font = new Font("Bahnschrift", 24F, FontStyle.Regular, GraphicsUnit.Point);
            lbHeader.Location = new Point(487, 9);
            lbHeader.Name = "lbHeader";
            lbHeader.Size = new Size(222, 39);
            lbHeader.TabIndex = 0;
            lbHeader.Text = "Scan All Parts";
            // 
            // pnFooter
            // 
            pnFooter.Controls.Add(pbSave);
            pnFooter.Dock = DockStyle.Bottom;
            pnFooter.Location = new Point(0, 608);
            pnFooter.Name = "pnFooter";
            pnFooter.Size = new Size(1116, 52);
            pnFooter.TabIndex = 4;
            // 
            // pbSave
            // 
            pbSave.Dock = DockStyle.Right;
            pbSave.Image = (Image)resources.GetObject("pbSave.Image");
            pbSave.InitialImage = (Image)resources.GetObject("pbSave.InitialImage");
            pbSave.Location = new Point(1058, 0);
            pbSave.Name = "pbSave";
            pbSave.Size = new Size(58, 52);
            pbSave.SizeMode = PictureBoxSizeMode.Zoom;
            pbSave.TabIndex = 0;
            pbSave.TabStop = false;
            // 
            // gvDisData
            // 
            gvDisData.AllowUserToAddRows = false;
            gvDisData.AllowUserToDeleteRows = false;
            gvDisData.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            gvDisData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gvDisData.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            gvDisData.DefaultCellStyle = dataGridViewCellStyle2;
            gvDisData.Location = new Point(0, 110);
            gvDisData.Name = "gvDisData";
            gvDisData.ReadOnly = true;
            gvDisData.RowHeadersWidth = 15;
            gvDisData.RowTemplate.Height = 25;
            gvDisData.Size = new Size(1116, 498);
            gvDisData.TabIndex = 5;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1 });
            toolStrip1.Location = new Point(0, 52);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1116, 25);
            toolStrip1.TabIndex = 6;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(86, 22);
            toolStripLabel1.Text = "toolStripLabel1";
            // 
            // ScanBundleAll
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1116, 660);
            Controls.Add(toolStrip1);
            Controls.Add(gvDisData);
            Controls.Add(pnFooter);
            Controls.Add(pnHeader);
            Name = "ScanBundleAll";
            Text = "v";
            Load += ScanBundleAll_Load;
            pnHeader.ResumeLayout(false);
            pnHeader.PerformLayout();
            pnFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbSave).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvDisData).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnHeader;
        private Label lbHeader;
        private DataGridView dgvData;
        private Panel pnFooter;
        private DataGridView gvDisData;
        private PictureBox pbSave;
        private Button button1;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
    }
}