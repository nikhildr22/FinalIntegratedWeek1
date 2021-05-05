using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FinalIntegratedWeek1
{
    class Program
    {
        static vegitableList _vegitables = new vegitableList();
        static void Main(string[] args)
        {
            int option;
            do
            {
                
                DisplayMenuToUser();
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        AddVegitable();
                        break;
                    case 2:
                        DisplayAllVegitables();
                        break;
                    case 3:
                        //SERIALIZE
                        GenerateBinaryFile();
                        break;
                    case 4:
                        //DE-SERIALIZE
                        ReadFromBinaryFile();
                        break;
                    case 5:
                        WriteIntoTextFile();
                        break;
                    case 6:
                        WriteIntoExcelFile();
                        break;
                    case 10:
                        Exit();
                        break;
                    default:
                        Console.WriteLine("Invalid Input, try again");
                        break;
                }

            } while (option!=10);
        }

        private static void WriteIntoExcelFile()
        {
            string projectDirectory = GetProjectDirectory();
            string fileName = "ExcelFile.xlsx";
            string pathToFile = projectDirectory + @"\" + fileName;
            ExcelWriter.Initializer(pathToFile);
            ExcelWriter.Write(1, 1, "Vegitable Name");
            ExcelWriter.Write(1, 2, "Price");
            int rowCounter = 2;
            foreach (Vegitable vegitable in _vegitables)
            {
                int columnCounter = 1;
                ExcelWriter.Write(rowCounter, columnCounter, vegitable.Name);
                columnCounter++;
                ExcelWriter.Write(rowCounter, columnCounter, vegitable.Price.ToString());
                rowCounter++;
            }
            string outputFile = projectDirectory + @"\" + $"FinalExcelFile-{DateTime.Now.ToString("dddd, dd MMMM yyyy HH-mm-ss")}.xlsx";
            ExcelWriter.SaveAs(outputFile);
            Console.WriteLine($"File save as : {outputFile}");



        }

        private static void WriteIntoTextFile()
        {
            string projectDirectory = GetProjectDirectory();
            string fileName = "textfile.txt";
            using (StreamWriter writer = new StreamWriter($@"{projectDirectory}\{fileName}"))
            {
                writer.WriteLine("_________BILL____________");
                foreach (Vegitable vegitable in _vegitables)
                {
                    writer.WriteLine(vegitable.ToString());
                }
                writer.WriteLine("_________________________");
                writer.WriteLine($"Total Bill = {_vegitables.GetTotalBillAmount()}");
                
            }
        }

        private static void ReadFromBinaryFile()
        {
            string projectDirectory = GetProjectDirectory();
            string fileName = "BinaryFile";
            BinaryFormatter bf = new BinaryFormatter();

            FileStream fsin = new FileStream(@$"{projectDirectory}\{fileName}.binary", FileMode.Open, FileAccess.Read);
            try
            {
                using (fsin)
                {
                    vegitableList newVegitables = (vegitableList)bf.Deserialize(fsin);
                    Console.WriteLine("De-serialized");

                    foreach (Vegitable vegitable  in newVegitables)
                    {
                        DisplaySingleVegitableDetails(vegitable);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void GenerateBinaryFile()
        {
            BinaryFormatter bf = new BinaryFormatter();
            //Console.WriteLine("Enter the file name : ");
            //string fileName = Console.ReadLine();
            string projectDirectory = GetProjectDirectory();

            string fileName = "BinaryFile";
            FileStream fsout = new FileStream(@$"{projectDirectory}\{fileName}.binary", FileMode.Create, FileAccess.Write);
            try
            {
                using (fsout)
                {
                    bf.Serialize(fsout, _vegitables);
                    Console.WriteLine("written into Binary file");

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static string GetProjectDirectory()
        {
            string workingDirectory = Environment.CurrentDirectory;
            //Console.WriteLine(Environment.CurrentDirectory);
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            return projectDirectory;
        }

        private static void DisplayAllVegitables()
        {
            foreach (Vegitable vegitable in _vegitables)
            {
                DisplaySingleVegitableDetails(vegitable);
            }
        }

        private static void DisplaySingleVegitableDetails(Vegitable vegitable)
        {
            Console.WriteLine("-------------------");
            Console.WriteLine($"Name : {vegitable.Name}");
            Console.WriteLine($"Price : {vegitable.Price}");
            Console.WriteLine("-------------------");
        }

        private static void AddVegitable()
        {
            Vegitable vegitable = GetNewVegitableDetails();
            _vegitables.AddVegitable(vegitable);
        }

        private static Vegitable GetNewVegitableDetails()
        {
            Console.WriteLine("Enter Vegitable Name  : ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter vegitable price : ");
            double price = Convert.ToDouble(Console.ReadLine());
            return new Vegitable(name, price);
        }

        private static void Exit()
        {
            Console.WriteLine("Bye!");
        }

        private static void DisplayMenuToUser()
        {
            Console.WriteLine("**************MENU****************");
            Console.WriteLine("1. Add vegitables");
            Console.WriteLine("2. Display vegitables Added");
            Console.WriteLine("3. Write into Binary file");
            Console.WriteLine("4.  Read binary file");
            Console.WriteLine("5. Write Print Total bill into text file");
            Console.WriteLine("6. Write into excel file");
            
        }
    }
}
