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

        //static void Main()
        //{
        //    Initializer(@"C:\Users\Nikhil\Desktop\DotnetTestFile.xlsx");
        //    //Console.WriteLine(Read(1, 1)); // Excel indexing starts from 1 -->  NOTE THIS
        //    Student student = new Student { Name = "Nikhil", Roll = 1, Marks = 100 };
        //    Write(2, 2, student.Roll.ToString());
        //    Write(2, 1, student.Name);
        //    Write(2, 3, student.Marks.ToString());
        //    for (int i = 1; i < 10; i++)
        //    {
        //        Console.WriteLine(Read(2, i).ToString());
        //    }
        //    // Above loop is just for single row
        //    // for multiple rows, we have to use 2 loops to iterate over both rows and columns

        //    //Saving it to a different file, due to ReadOnly file handling previleges since  the file is being handled by one task
        //    SaveAs(@"C:\Users\Nikhil\Desktop\DotnetTestFile1.xlsx");

        //}

    }
}
