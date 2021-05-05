using System;
using System.Collections;
using System.Collections.Generic;

namespace FinalIntegratedWeek1
{
    [Serializable]
    class vegitableList : IEnumerable<Vegitable>
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
    }
}
