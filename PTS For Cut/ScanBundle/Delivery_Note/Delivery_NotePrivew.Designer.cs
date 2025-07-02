namespace PTS_For_Cut.ScanBundle.Delivery_Note
{
    partial class Delivery_NotePrivew
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
            appData1 = new _Main.AppData();
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)appData1).BeginInit();
            SuspendLayout();
            // 
            // appData1
            // 
            appData1.DataSetName = "AppData";
            appData1.Namespace = "http://tempuri.org/AppData.xsd";
            appData1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportViewer1.Dock = DockStyle.Fill;
            reportViewer1.Location = new Point(0, 0);
            reportViewer1.Name = "ReportViewer";
            reportViewer1.ServerReport.BearerToken = null;
            reportViewer1.Size = new Size(1018, 577);
            reportViewer1.TabIndex = 0;
            // 
            // Delivery_NotePrivew
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1018, 577);
            Controls.Add(reportViewer1);
            Name = "Delivery_NotePrivew";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Delivery_NotePrivew";
            WindowState = FormWindowState.Maximized;
            Load += Delivery_NotePrivew_Load;
            ((System.ComponentModel.ISupportInitialize)appData1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private _Main.AppData appData1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}