namespace PTS_For_Cut._9_1Inc
{
    partial class IncBreakReport
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
            PreReportInc = new Microsoft.Reporting.WinForms.ReportViewer();
            dataSet12 = new PTS_For_Cut._Main.DataSet1();
            ((System.ComponentModel.ISupportInitialize)dataSet12).BeginInit();
            SuspendLayout();
            // 
            // PreReportInc
            // 
            PreReportInc.Dock = DockStyle.Fill;
            PreReportInc.Location = new Point(0, 0);
            PreReportInc.Name = "ReportViewer";
            PreReportInc.ServerReport.BearerToken = null;
            PreReportInc.Size = new Size(396, 246);
            PreReportInc.TabIndex = 0;
            // 
            // dataSet12
            // 
            dataSet12.DataSetName = "DataSet1";
            dataSet12.Namespace = "http://tempuri.org/DataSet1.xsd";
            dataSet12.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // IncBreakReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 620);
            Controls.Add(PreReportInc);
            Name = "IncBreakReport";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "IncBreakReport";
            WindowState = FormWindowState.Maximized;
            Load += IncBreakReport_Load;
            ((System.ComponentModel.ISupportInitialize)dataSet12).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer PreReportInc;
        private _Main.DataSet1 dataSet11;
        private _Main.DataSet1 dataSet12;
    }
}