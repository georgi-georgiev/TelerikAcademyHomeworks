using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.AccessCorrespondingTerritories
{
    public class EntitySet<T>
    {
        public List<T> set = new List<T>();

        public T this[int index]
        {
            get
            {
                return set[index];
            }
            set
            {
                set.Add(value);
            }
        }
    }
}
