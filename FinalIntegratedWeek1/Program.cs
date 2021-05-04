using System;

namespace FinalIntegratedWeek1
{
    class Vegitable
    {
        private string _name;
        private double _price;

        public Vegitable(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get => _name; set => _name = value; }
        public double Price { get => _price; set => _price = value; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
