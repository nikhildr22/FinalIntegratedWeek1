using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using AnotherNameSpace;

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
                    case 7:
                        FileStreamDemo();
                        break;
                    case 8:
                        SortByPriceAndDisplay(_vegitables);
                        break;
                    case 9:
                        SortByNameAndDisplay(_vegitables);
                        break;
                    case 10:
                        FindVegitableByName();
                        break;
                    case 20:
                        Exit();
                        break;
                    default:
                        Console.WriteLine("Invalid Input, try again");
                        break;
                }

            } while (option!=20);
        }

        private static void FindVegitableByName()
        {
            Console.WriteLine("Enter the vegitable name : ");
            string name = Console.ReadLine();
            bool isFound = false;
            Vegitable newVegitable = new Vegitable(name, 0.0);
            foreach (Vegitable vegitable in _vegitables)
            {
                if (vegitable.Equals( newVegitable) )
                {
                    DisplaySingleVegitableDetails(vegitable);
                    isFound = true;
                    break;
                }
                
            }
            if (!isFound)
            {
                Console.WriteLine("Entered Vegitable was not found!!! ");
            }
            
        }

        private static void SortByNameAndDisplay(vegitableList vegitables)
        {
            // This works with IComparer interface
            IEnumerable<Vegitable> newList = vegitables.GetSortedVegitablesByName(vegitables);
            foreach (Vegitable vegitable in newList)
            {
                DisplaySingleVegitableDetails(vegitable);
            }
        }

        private static void SortByPriceAndDisplay(vegitableList vegitables)
        {
            // This works with IComparable interface
            IEnumerable<Vegitable> newList = vegitables.GetSortedVegitablesByPrice(vegitables);
            foreach (Vegitable vegitable in newList)
            {
                DisplaySingleVegitableDetails(vegitable);
            }
        }

        private static void FileStreamDemo()
        {
            AnotherNameSpace.StreamsHandler.CreateNewFolder("NewFolder");
            AnotherNameSpace.StreamsHandler.WriteUsingFileClass(_vegitables);
            AnotherNameSpace.StreamsHandler.WriteUsingFileStream(_vegitables);

        }

        private static void WriteIntoExcelFile()
        {
            string projectDirectory = GetProjectDirectory();
            string newFolderName = "NewExcelFiles";
            AnotherNameSpace.StreamsHandler.CreateNewFolder(newFolderName);
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
            string outputFile = projectDirectory + @"\" +newFolderName+ @"\" + $"FinalExcelFile-{DateTime.Now.ToString("dddd, dd MMMM yyyy HH-mm-ss")}.xlsx";
            ExcelWriter.SaveAs(outputFile);
            Console.WriteLine($"File saved as : {outputFile}");



        }

        private async static void WriteIntoTextFile()
        {
            string projectDirectory = GetProjectDirectory();
            string fileName = "textfile.txt";
            using (StreamWriter writer = new StreamWriter($@"{projectDirectory}\{fileName}"))
            {
                await writer.WriteLineAsync("_________BILL____________");
                foreach (Vegitable vegitable in _vegitables)
                {
                    await writer.WriteLineAsync(vegitable.ToString());
                }
               await writer.WriteLineAsync("_________________________");
               await writer.WriteLineAsync($"Total Bill = {_vegitables.GetTotalBillAmount()}");
                
            }
            Console.WriteLine("printed");
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
            FileStream fsout;
            try
            {
                using (fsout = new FileStream(@$"{projectDirectory}\{fileName}.binary", FileMode.Create, FileAccess.Write))
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

        public static string GetProjectDirectory()
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
            try
            {
                Vegitable vegitable = GetNewVegitableDetails();
                _vegitables.AddVegitable(vegitable);
                Console.WriteLine($"vegitable - {vegitable.Name} was added successfuly to the list");
            }
            catch (OverPricedVegitableException e)
            {

                Console.WriteLine(e.Message);
            }
            catch(InvalidInputValueException e)
            {
                Console.WriteLine(e.Message);
            }
            
            
            
        }

        private static Vegitable GetNewVegitableDetails()
        {
            Console.WriteLine("Enter Vegitable Name  : ");
            string? name = null;
            name = Console.ReadLine();
            Console.WriteLine("Enter vegitable price : ");
            double? price = null;
            try
            {
                price = Convert.ToDouble(Console.ReadLine());
            }
            catch (FormatException e)
            {
                throw new InvalidInputValueException();
            }
            

            if (price<=0 && name=="")
            {
                throw new InvalidInputValueException(price,name);
            }
            else if (price <= 0)
            {
                throw new InvalidInputValueException(price);
            }
            else if (name == "")
            {
                throw new InvalidInputValueException(name);
            }
            else
            {
                return new Vegitable(name, price ?? 0);
            }



            
            
            
            
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
            Console.WriteLine("7. File Stream Example Demo");
            Console.WriteLine("8. Sort by price and display all vegitables");
            Console.WriteLine("9. Sort By name and display all vegitables");
            Console.WriteLine("20. EXIT");
        }
    }
}
