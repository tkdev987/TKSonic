using PTS_For_Cut._Main;

namespace PTS_For_Cut.Spreading.Create
{
    partial class SDPreviweReport
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
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            appData1 = new AppData();
            appData2 = new _Main.DataSet1();
            ((System.ComponentModel.ISupportInitialize)appData1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)appData2).BeginInit();
            SuspendLayout();
            // 
            // reportViewer1
            // 
            reportViewer1.Dock = DockStyle.Fill;
            reportViewer1.LocalReport.ReportEmbeddedResource = "PTS_For_Cut._3Spreading.Create.Report1.rdlc";
            reportViewer1.Location = new Point(0, 0);
            reportViewer1.Name = "ReportViewer";
            reportViewer1.ServerReport.BearerToken = null;
            reportViewer1.Size = new Size(1367, 564);
            reportViewer1.TabIndex = 0;
            // 
            // appData1
            // 
            appData1.DataSetName = "AppData";
            appData1.Namespace = "http://tempuri.org/AppData.xsd";
            appData1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // appData2
            // 
            appData2.DataSetName = "DataSet1";
            appData2.Namespace = "http://tempuri.org/DataSet1.xsd";
            appData2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SDPreviweReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1367, 564);
            Controls.Add(reportViewer1);
            Name = "SDPreviweReport";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SDPreviweReport";
            WindowState = FormWindowState.Maximized;
            Load += SDPreviweReport_Load;
            ((System.ComponentModel.ISupportInitialize)appData1).EndInit();
            ((System.ComponentModel.ISupportInitialize)appData2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private AppData appData1;
        private DataSet1 appData2;
    }
}