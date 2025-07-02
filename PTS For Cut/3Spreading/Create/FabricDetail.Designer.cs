namespace PTS_For_Cut._3Spreading.Create
{
    partial class FabricDetail
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
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            lbLabelHeader = new Guna.UI2.WinForms.Guna2HtmlLabel();
            panel2 = new Panel();
            gvDis = new Guna.UI2.WinForms.Guna2DataGridView();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvDis).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(panel2, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(877, 540);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(lbLabelHeader);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(871, 94);
            panel1.TabIndex = 0;
            // 
            // lbLabelHeader
            // 
            lbLabelHeader.BackColor = Color.Transparent;
            lbLabelHeader.Font = new Font("Bahnschrift Condensed", 36F, FontStyle.Regular, GraphicsUnit.Point);
            lbLabelHeader.Location = new Point(270, 19);
            lbLabelHeader.Name = "lbLabelHeader";
            lbLabelHeader.Size = new Size(115, 60);
            lbLabelHeader.TabIndex = 0;
            lbLabelHeader.Text = "Header";
            // 
            // panel2
            // 
            panel2.Controls.Add(gvDis);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 103);
            panel2.Name = "panel2";
            panel2.Size = new Size(871, 434);
            panel2.TabIndex = 0;
            // 
            // gvDis
            // 
            gvDis.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(219, 219, 219);
            dataGridViewCellStyle1.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(197, 191, 255);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(71, 69, 94);
            gvDis.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
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
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(197, 191, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            gvDis.DefaultCellStyle = dataGridViewCellStyle3;
            gvDis.Dock = DockStyle.Fill;
            gvDis.GridColor = Color.FromArgb(231, 229, 255);
            gvDis.Location = new Point(0, 0);
            gvDis.Name = "gvDis";
            gvDis.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.White;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            gvDis.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            gvDis.RowHeadersVisible = false;
            gvDis.RowTemplate.Height = 25;
            gvDis.Size = new Size(871, 434);
            gvDis.TabIndex = 0;
            gvDis.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(219, 219, 219);
            gvDis.ThemeStyle.AlternatingRowsStyle.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            gvDis.ThemeStyle.AlternatingRowsStyle.ForeColor = SystemColors.ControlText;
            gvDis.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.FromArgb(197, 191, 255);
            gvDis.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            gvDis.ThemeStyle.BackColor = Color.White;
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
            gvDis.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            gvDis.ThemeStyle.RowsStyle.Height = 25;
            gvDis.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(197, 191, 255);
            gvDis.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // FabricDetail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(874, 540);
            Controls.Add(tableLayoutPanel1);
            Name = "FabricDetail";
            Text = "FabricDetail";
            Load += FabricDetail_Load;
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gvDis).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbLabelHeader;
        private Panel panel2;
        private Guna.UI2.WinForms.Guna2DataGridView gvDis;
    }
}