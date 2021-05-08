using System;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.IO;
namespace FinalIntegratedWeek1
{
    class ExcelWriter
    {
        static Application excel = new _Excel.Application();
        static Workbook wb;
        static Worksheet ws;
        //These 3 static objects are called as COM objects
        public static void Initializer(string path)
        {
            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[1]; //1 is sheet number
        }
        // READ operation

        public static Object Read(int i, int j)
        {
            if (ws.Cells[i, j].Value2 != null)
            {
                return ws.Cells[i, j].Value2;
            }
            else
            {
                return "Empty";
            }
        }

        //WRITE

        public static void Write(int i, int j, string val)
        {
            ws.Cells[i, j] = val;
        }

        public static void SaveAs(string filename)
        {
            ws.SaveAs(filename);
        }

        
       

    }
}
