using System.Data;
using System.Runtime.InteropServices;


namespace Production_Tracking_systems.myClass
{
    internal class myExcel
    {
        private static Action savedata;

        public static void importExcel(ToolStripTextBox txtFile, DataGridView gvExcel)
        {

            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.ShowDialog();
                int ImportedRecord = 0, inValidItem = 0;
                string SourceURl = "";

                if (dialog.FileName != "")
                {

                    DataTable dtNew = new DataTable();
                    if (dialog.FileName.EndsWith(".csv"))
                    {

                        dtNew = GetDataTabletFromCSVFile(dialog.FileName);
                        txtFile.Text = dialog.SafeFileName;
                        SourceURl = dialog.FileName;
                        if (dtNew.Rows != null && dtNew.Rows.ToString() != String.Empty)
                        {
                            gvExcel.DataSource = dtNew;
                        }
                        if (gvExcel.Rows.Count == 0)
                        {
                            MessageBox.Show("There is no data in this file", "GAUTAM POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else if (dialog.FileName.EndsWith(".xls"))
                    {
                        //using (WaitingLoading waitingLoading = new WaitingLoading(GetDataTabletFromXLSFile(dialog.FileName)))
                        //{
                        //    waitingLoading.ShowDialog(this);
                        //}
                        dtNew = GetDataTabletFromXLSFile(dialog.FileName);
                        txtFile.Text = dialog.SafeFileName;
                        SourceURl = dialog.FileName;
                        if (dtNew.Rows != null && dtNew.Rows.ToString() != String.Empty)
                        {
                            gvExcel.DataSource = dtNew;
                        }
                        if (gvExcel.Rows.Count == 0)
                        {
                            MessageBox.Show("There is no data in this file", "GAUTAM POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Selected File is Invalid, Please Select valid csv file.", "GAUTAM POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex);

            }
            //  gvExcel.Columns[1].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss";

        }


        public static DataTable GetDataTabletFromCSVFile(string csv_file_path)
        {
            DataTable csvData = new DataTable();
            try
            {
                if (csv_file_path.EndsWith(".csv"))
                {
                    using (Microsoft.VisualBasic.FileIO.TextFieldParser csvReader = new Microsoft.VisualBasic.FileIO.TextFieldParser(csv_file_path))
                    {
                        csvReader.SetDelimiters(new string[] { "," });
                        csvReader.HasFieldsEnclosedInQuotes = true;
                        //read column
                        string[] colFields = csvReader.ReadFields();
                        foreach (string column in colFields)
                        {
                            DataColumn datecolumn = new DataColumn(column);
                            datecolumn.AllowDBNull = true;
                            csvData.Columns.Add(datecolumn);
                        }
                        while (!csvReader.EndOfData)
                        {
                            string[] fieldData = csvReader.ReadFields();
                            for (int i = 0; i < fieldData.Length; i++)
                            {
                                if (fieldData[i] == "")
                                {
                                    fieldData[i] = null;
                                }
                            }
                            csvData.Rows.Add(fieldData);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excel " + ex);
            }
            return csvData;
        }

        public static DataTable GetDataTabletFromXLSFile(string csv_file_path)
        {
            DataTable csvData = new DataTable();
            DataRow row;
            try
            {
                if (csv_file_path.EndsWith(".xls"))
                {

                    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

                    Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(csv_file_path);

                    Microsoft.Office.Interop.Excel._Worksheet excelWorksheet = excelWorkbook.Sheets[1];

                    Microsoft.Office.Interop.Excel.Range excelRange = excelWorksheet.UsedRange;


                    int rowCount = excelRange.Rows.Count;  //get row count of excel data
                    int colCount = excelRange.Columns.Count; // get column count of excel data

                    for (int i = 1; i <= rowCount; i++)
                    {

                        for (int j = 1; j <= colCount; j++)
                        {

                            csvData.Columns.Add(excelRange.Cells[i, j].Value2.ToString());


                        }
                        break;
                    }
                    //Get Row Data of Excel              
                    int rowCounter;  //This variable is used for row index number
                    for (int i = 2; i <= rowCount; i++) //Loop for available row of excel data
                    {
                        row = csvData.NewRow();  //assign new row to DataTable
                        rowCounter = 0;
                        for (int j = 1; j <= colCount; j++) //Loop for available column of excel data
                        {
                            //check if cell is empty
                            //if (j != 2)
                            //{
                            if (excelRange.Cells[i, j] != null && excelRange.Cells[i, j].Value2 != null)
                            {
                                if (j == 2)
                                {
                                    IFormatProvider yyyymmddFormat = new System.Globalization.CultureInfo("en-US", false);
                                    string x = excelRange.Cells[i, j].Value2.ToString();
                                    double d = double.Parse(x);
                                    DateTime conv = DateTime.FromOADate(d);
                                    row[rowCounter] = conv.ToString("yyyy-MM-dd", yyyymmddFormat);
                                }
                                else
                                {
                                    row[rowCounter] = excelRange.Cells[i, j].Value2.ToString();
                                }

                                // MessageBox.Show(excelRange.Cells[i, j].Value2.ToString());
                            }
                            else
                            {
                                row[i] = "";
                            }
                            rowCounter++;
                            //}


                            // Thread.Sleep(10);
                        }
                        csvData.Rows.Add(row); //add row to DataTable
                    }

                    //dataGridView1.DataSource = csvData; //assign DataTable as Datasource for DataGridview

                    //Close and Clean excel process
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    Marshal.ReleaseComObject(excelRange);
                    Marshal.ReleaseComObject(excelWorksheet);
                    excelWorkbook.Close();
                    Marshal.ReleaseComObject(excelWorkbook);

                    //quit 
                    excelApp.Quit();
                    Marshal.ReleaseComObject(excelApp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excel " + ex);
            }
            return csvData;
        }

    }
}
