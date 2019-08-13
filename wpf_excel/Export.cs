using System;
using Microsoft.Office.Interop.Excel;

namespace wpf_excel
{
    public class Export
    {
        public void GenerateExcelFile()
        {
            var excelApplication = new Application();
            excelApplication.Visible = true;
            excelApplication.WindowState = XlWindowState.xlMaximized;

            var workBook = excelApplication.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            var excelSheet = workBook.Worksheets[1];

            GenerateSheet(excelSheet);
            
            workBook.SaveAs("C:\\Temp\\test.xlsx");
            workBook.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, "C:\\Temp\\test.pdf");
        }

        private void GenerateSheet(Worksheet excelWorksheet)
        {
            excelWorksheet.Range["A1:B1"].Merge();
            excelWorksheet.Range["A1:B1"].Value = "Who is number one? :)";

            excelWorksheet.Range[1, 1].Value = "Company Name";
            //excelWorksheet.Range[1 + 1, 1].Value = model.CompanyName;


        }
    }
}
