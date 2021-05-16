using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FinalIntegratedWeek1;

namespace AnotherNameSpace
{
    // THIS is USING DIFFERENT NAMESPACES
    class StreamsHandler
    {
        static string _projectDir = Program.GetProjectDirectory();
        static string folderName = "NewFolder";
        public static void CreateNewFolder(string folderName)
        {
            string path = @$"{_projectDir}\{folderName}";
            //create a new directory
            try
            {
                
                if (Directory.Exists(path))
                {
                    Console.WriteLine("That path exists already.");
                    return;
                }
                DirectoryInfo di = Directory.CreateDirectory(path);
                Console.WriteLine("The directory was created successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            

        }

        public async static void WriteUsingFileClass(vegitableList vegitables)
        {
            string pathToFile = $@"{_projectDir}\{folderName}\FileClassDemo.txt";

            await File.WriteAllLinesAsync(pathToFile, from vegitable in vegitables select vegitable.ToString() );
            //here im using List comprehension using LINQ.

        }
        public async static void WriteUsingFileStream(vegitableList vegitables)
        {
            string pathToFile = $@"{_projectDir}\{folderName}\FileStreamDemo.txt";
            using (FileStream fs = File.Open(pathToFile, FileMode.Create))
            {
                foreach (Vegitable vegitable in vegitables)
                {
                    string line = vegitable.ToString();
                    byte[] result = Encoding.Default.GetBytes(line + "\n");
                    await fs.WriteAsync(result, 0, result.Length);
                }
            }
        }





    }
}
