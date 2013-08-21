using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.ImplementHashTable
{
    public class HashTable<K, T> : IEnumerable<KeyValuePair<K, T>>
    {
        private int count;
        private int capacity;
        private LinkedList<KeyValuePair<K, T>>[] values;

        public HashTable()
        {
            this.values = new LinkedList<KeyValuePair<K, T>>[16];
            this.Count = 0;
            this.Capacity = 0;
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                this.capacity = value;
            }
        }

        public int Count
        {
            get
            {
                return this.count;
            }
            private set
            {
                this.count = value;
            }
        }

        public List<K> Keys
        {
            get
            {
                List<K> keys = new List<K>();

                foreach (var item in this.values)
                {
                    if (item != null)
                    {
                        var currentLinkedList = item.First;

                        while (currentLinkedList != null)
                        {
                            keys.Add(currentLinkedList.Value.Key);
                            currentLinkedList = currentLinkedList.Next;
                        }
                    }
                }

                return keys;
            }
        }

        public T this[K key]
        {
            get
            {
                return Find(key);
            }
            set
            {
                int index = key.GetHashCode() % this.values.Length;

                if (this.values[index] == null)
                {
                    this.values[index] = new LinkedList<KeyValuePair<K, T>>();
                }

                bool isExist = false;
                var currentElement = this.values[index].First;

                while (currentElement != null)
                {
                    if (currentElement.Value.Key.Equals(key))
                    {
                        currentElement.Value = new KeyValuePair<K, T>(key, value);
                        isExist = true;
                        break;
                    }

                    currentElement = currentElement.Next;
                }

                if (!isExist)
                {
                    throw new ArgumentException("Key does not exist.");
                }
            }
        }

        public T Find(K key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("Key cannot be null.");
            }

            int index = Math.Abs(key.GetHashCode() % this.values.Length);

            if (this.values[index] == null)
            {
                throw new ArgumentNullException("The element is null.");
            }
            else
            {
                foreach (var item in this.values[index])
                {
                    if (key.Equals(item.Key))
                    {
                        return item.Value;
                    }
                }
            }

            throw new ArgumentException("No element with this key.");
        }

        public void Add(K key, T value)
        {
            if (key == null || value == null)
            {
                throw new ArgumentNullException("Key and value cannot be null.");
            }

            if (this.Capacity >= this.values.Length * 0.75)
            {
                LinkedList<KeyValuePair<K, T>>[] expanded = new LinkedList<KeyValuePair<K, T>>[this.Capacity * 2];
                Array.Copy(this.values, expanded, this.Capacity);
                this.values = expanded;
            }

            int index = Math.Abs(key.GetHashCode() % this.values.Length);

            if (this.values[index] == null)
            {
                this.values[index] = new LinkedList<KeyValuePair<K, T>>();
                this.Capacity += 1;
            }

            var currentElement = this.values[index].First;

            while (currentElement != null)
            {
                if (currentElement.Value.Key.Equals(key))
                {
                    throw new ArgumentException("Key already exist.");
                }

                currentElement = currentElement.Next;
            }

            this.values[index].AddLast(new KeyValuePair<K, T>(key, value));
            this.Count += 1;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
        {
            for (int i = 0; i < this.values.Length; i++)
            {
                if (this.values[i] != null)
                {
                    var next = this.values[i].First;
                    while (next != null)
                    {
                        yield return next.Value;
                        next = next.Next;
                    }
                }
            }
        }

        public void Remove(K key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("Key cannot be null.");
            }

            int index = Math.Abs(key.GetHashCode() % this.values.Length);

            if (this.values[index] == null)
            {
                throw new ArgumentException("Key does not exist.");
            }

            var currentElement = this.values[index].First;
            bool isExist = false;
            while (currentElement != null)
            {
                if (currentElement.Value.Key.Equals(key))
                {
                    this.values[index].Remove(currentElement);
                    this.Count -= 1;
                    isExist = true;
                    break;
                }

                currentElement = currentElement.Next;
            }

            if (this.values[index].First == null)
            {
                this.Capacity -= 1;
            }

            if (!isExist)
            {
                throw new ArgumentException("Key does not exist.");
            }
        }

        public void Clear()
        {
            this.values = new LinkedList<KeyValuePair<K, T>>[16];
            this.Count = 0;
            this.Capacity = 0;
        }

        public bool Contains(K key)
        {
            int index = Math.Abs(key.GetHashCode() % this.values.Length);

            bool isExist = false;
            if (this.values[index] != null)
            {
                var next = this.values[index].First;
                while (next != null)
                {
                    if (next.Value.Key.Equals(key))
                    {
                        isExist = true;
                        break;
                    }
                    next = next.Next;
                }
            }

            return isExist;
        }
    }
}
