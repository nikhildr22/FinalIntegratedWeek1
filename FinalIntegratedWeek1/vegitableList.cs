using System;
using System.Collections;
using System.Collections.Generic;

namespace FinalIntegratedWeek1
{
    [Serializable]
    class vegitableList : IEnumerable<Vegitable>, IVegitableList
    {
        List<Vegitable> Vegitables = new List<Vegitable>();
        public vegitableList()
        {

        }
        public void AddVegitable(Vegitable vegitable)
        {
            Vegitables.Add(vegitable);
        }
        public void RemoveVegitable(Vegitable vegitable)
        {
            Vegitables.Remove(vegitable);
        }

        public Vegitable GetVegitable(string name)
        {
            return Vegitables.Find(x => x.Name == name);
        }
        public IEnumerator<Vegitable> GetEnumerator()
        {
            return Vegitables.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        // POLYMORPHISM
        public double GetTotalBillAmount()
        {
            // Varargs
            double total = 0;
            foreach (Vegitable vegitable in Vegitables)
            {
                total += vegitable.Price;
            }
            return total;
        }

        public IEnumerable<Vegitable> GetSortedVegitablesByPrice(vegitableList vegitables)
        {
            List<Vegitable> newList = new List<Vegitable>();
            foreach (Vegitable vegitable in Vegitables)
            {
                newList.Add(vegitable);
            }
            newList.Sort();
            return newList;
        }

        public IEnumerable<Vegitable> GetSortedVegitablesByName(vegitableList vegitables)
        {
            List<Vegitable> newList = new List<Vegitable>();
            foreach (Vegitable vegitable in Vegitables)
            {
                newList.Add(vegitable);
            }
            CompareByName comparer = new CompareByName();
            newList.Sort(comparer);
            return newList;
        }

       
    }
}
