using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace wpf_excel
{
    public class Export
    {
        public void GenerateExcelFile()
        {
            //Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            //app.Visible = true;
            //app.WindowState = XlWindowState.xlMaximized;

            //Workbook wb = app.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            //Worksheet ws = wb.Worksheets[1];
            //DateTime currentDate = DateTime.Now;

            //ws.Range["A1:B1"].Merge();
            //ws.Range["A1:B1"].Value = "Who is number one? :)";
            

            //wb.SaveAs("C:\\Temp\\test.xlsx");
            //wb.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, "C:\\Temp\\test.pdf");
        }
    }
}
