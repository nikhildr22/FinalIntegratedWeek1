﻿using System.Collections;
using System.Collections.Generic;

namespace FinalIntegratedWeek1
{
    class vegitableList : IEnumerator<Vegitable>
    {
        List<Vegitable> vegitables = new List<Vegitable>();
        public int Counter;
        public vegitableList()
        {
            Counter = -1;
        }
        public Vegitable Current => throw new System.NotImplementedException();

        object IEnumerator.Current => throw new System.NotImplementedException();

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public bool MoveNext()
        {
            
                Counter++;
                Console.WriteLine("Inside MoveNext Method : " + Counter);
                return Counter != 5;
            
        }

        public void Reset()
        {
            throw new System.NotImplementedException();
        }
    }
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
}
