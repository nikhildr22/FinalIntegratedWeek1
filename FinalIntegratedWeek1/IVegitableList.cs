using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalIntegratedWeek1
{
    interface IVegitableList
    {
        void AddVegitable(Vegitable vegitable);
        void RemoveVegitable(Vegitable vegitable);
        Vegitable GetVegitable(string name);
        double GetTotalBillAmount();
        double GetTotalBillAmount(params Vegitable[] vegitables)
        {
            // Varargs
            // Polymorphism
            // default interface
            double total = 0;
            foreach (Vegitable vegitable in vegitables)
            {
                total += vegitable.Price;
            }
            return total;
        }
    }
}
