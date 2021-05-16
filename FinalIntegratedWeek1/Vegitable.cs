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
    class Vegitable : Product, IComparable<Vegitable>, IEquatable<Vegitable>
    {

        public Vegitable(string name, double price)
        {
            Name = name;
            Price = price;
        }                                           

        public string Name { get => _name; set => _name = value; }
        public double Price 
        { 
            get => _price; 
            set 
            {
                if (value>1000)
                {
                    throw new OverPricedVegitableException(value);
                }
                _price = value; 
            } 
        }

        //IComparable implementation to make Sort() method work
        public int CompareTo(Vegitable other)
        {
            
            if (this.Price > other.Price)
            {
                return 1;
            }
            else if(this.Price < other.Price)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public bool Equals(Vegitable other)
        {
            
                return this.Name.CompareTo(other.Name) == 0 ? true : false;
            
            
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj);
        }

        public override string ToString()
        {
            return $"Vegitable Name - {Name} | Vegitable Price - {Price}"; 
        }
    }
}
