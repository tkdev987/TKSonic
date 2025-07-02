namespace PTS_For_Cut.SMK
{
    partial class ScanOutMaterial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScanOutMaterial));
            gvDis = new DataGridView();
            SO = new DataGridViewTextBoxColumn();
            Style = new DataGridViewTextBoxColumn();
            Color = new DataGridViewTextBoxColumn();
            Size = new DataGridViewTextBoxColumn();
            Qty = new DataGridViewTextBoxColumn();
            toolStrip1 = new ToolStrip();
            btSave = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)gvDis).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // gvDis
            // 
            gvDis.BackgroundColor = SystemColors.Control;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            gvDis.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gvDis.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvDis.Columns.AddRange(new DataGridViewColumn[] { SO, Style, Color, Size, Qty });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            gvDis.DefaultCellStyle = dataGridViewCellStyle2;
            gvDis.Location = new Point(24, 105);
            gvDis.Name = "gvDis";
            gvDis.RowTemplate.Height = 25;
            gvDis.Size = new Size(1121, 494);
            gvDis.TabIndex = 0;
            // 
            // SO
            // 
            SO.HeaderText = "SO";
            SO.Name = "SO";
            SO.Width = 180;
            // 
            // Style
            // 
            Style.HeaderText = "Style";
            Style.Name = "Style";
            Style.Width = 180;
            // 
            // Color
            // 
            Color.HeaderText = "Color";
            Color.Name = "Color";
            // 
            // Size
            // 
            Size.HeaderText = "Size";
            Size.Name = "Size";
            // 
            // Qty
            // 
            Qty.HeaderText = "Qty";
            Qty.Name = "Qty";
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btSave });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1157, 39);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // btSave
            // 
            btSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btSave.Image = (Image)resources.GetObject("btSave.Image");
            btSave.Name = "btSave";
            btSave.Size = new Size(36, 36);
            btSave.Text = "Save";
            btSave.Click += btSave_Click;
            // 
            // ScanOutMaterial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1157, 611);
            Controls.Add(toolStrip1);
            Controls.Add(gvDis);
            Name = "ScanOutMaterial";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ScanOutMaterial";
            ((System.ComponentModel.ISupportInitialize)gvDis).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView gvDis;
        private ToolStrip toolStrip1;
        private ToolStripButton btSave;
        private DataGridViewTextBoxColumn SO;
        private DataGridViewTextBoxColumn Style;
        private DataGridViewTextBoxColumn Color;
        private DataGridViewTextBoxColumn Size;
        private DataGridViewTextBoxColumn Qty;
    }
}