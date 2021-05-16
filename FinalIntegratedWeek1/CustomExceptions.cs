using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalIntegratedWeek1
{
    class OverPricedVegitableException : Exception
    {
        public OverPricedVegitableException() : base("The vegitable is overpriced")
        {
            
        }

        public OverPricedVegitableException(double price) : base($"The Price of the vegitable-Rs.{price} Exceeds the Limit of 1000Rs, ")
        {

        }

    }

    class InvalidInputValueException : Exception
    {
        public InvalidInputValueException() : base("Please enter valid values")
        {
          
        }

        public InvalidInputValueException(params Object[] p) : base($"Invalid input values  - {string.Join(',', from i in p select i.ToString())}")
        {

        }

    }
}
