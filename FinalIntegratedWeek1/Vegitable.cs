using System;

namespace FinalIntegratedWeek1
{
    [Serializable]
    class Product
    {
        protected string _name;
        protected double _price;
    }
    [Serializable]
    class Vegitable : Product
    {

        public Vegitable(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get => _name; set => _name = value; }
        public double Price { get => _price; set => _price = value; }

        public override string ToString()
        {
            return $"Vegitable Name - {Name} | Vegitable Price - {Price}"; 
        }
    }
}
