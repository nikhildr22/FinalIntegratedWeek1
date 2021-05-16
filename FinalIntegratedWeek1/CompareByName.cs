using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalIntegratedWeek1
{
    class CompareByName : IComparer<Vegitable>
    {
        public int Compare(Vegitable x, Vegitable y)
        {
            if (x.Name.CompareTo(y.Name) > 0)
            {
                return 1;
            }
            else if (x.Name.CompareTo(y.Name) < 0)
            {
                return -1;
            }
            else
            {
                return 0;
            }

        }
    }
}
