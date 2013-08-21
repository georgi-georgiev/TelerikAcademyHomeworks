using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _04.ImplementHashTable;

namespace _05.HashedSetImplementation
{
    public class HashedSet<T> : IEnumerable<T>
    {
        private HashTable<T, T> values;

        public int Count
        {
            get
            {
                return this.values.Count;
            }
            private set
            {
                this.Count = value;
            }
        }

        public int Capacity
        {
            get
            {
                return this.values.Capacity;
            }
            private set
            {
                this.Capacity = value;
            }
        }

        public HashedSet(params T[] values)
        {
            this.values = new HashTable<T, T>();

            if (values != null)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    this.values.Add(values[i], values[i]);
                }
            }
        }

        public void Add(T value)
        {
            this.values.Add(value, value);
        }

        public void Remove(T value)
        {
            this.values.Remove(value);
        }

        public T Find(T value)
        {
            T lookedValue = values.Find(value);

            return lookedValue;
        }

        public void Clear()
        {
            this.values = new HashTable<T, T>();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.values)
            {
                yield return item.Value;
            }
        }

        public void UnionWhith(HashedSet<T> set)
        {
            foreach (var item in set)
            {
                if (!this.values.Contains(new KeyValuePair<T, T>(item, item)))
                {
                    this.values.Add(item, item);
                }
            }
        }

        public void IntersectWith(HashedSet<T> set)
        {
            HashTable<T, T> table = new HashTable<T, T>();
            foreach (var item in set)
            {
                if (this.values.Contains(new KeyValuePair<T, T>(item, item)))
                {
                    table.Add(item, item);
                }
            }

            this.values = table;
        }
    }
}
