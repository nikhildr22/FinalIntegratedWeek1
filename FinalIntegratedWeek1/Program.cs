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
                        GenerateBinaryFile();
                        break;
                    case 5:
                        Exit();
                        break;
                    default:
                        Console.WriteLine("Invalid Input, try again");
                        break;
                }

            } while (option!=5);
        }

        private static void GenerateBinaryFile()
        {
            BinaryFormatter bf = new BinaryFormatter();
            Console.WriteLine("Enter the file name : ");
            string fileName = Console.ReadLine();
            FileStream fsout = new FileStream(@$"C:\Users\Nikhil\source\repos\FinalIntegratedWeek1\FinalIntegratedWeek1\{fileName}.binary", FileMode.Create, FileAccess.Write);
            try
            {
                using (fsout)
                {
                    bf.Serialize(fsout, _vegitables);
                    Console.WriteLine("written into Binary file");
                    
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
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
        }
    }
}
