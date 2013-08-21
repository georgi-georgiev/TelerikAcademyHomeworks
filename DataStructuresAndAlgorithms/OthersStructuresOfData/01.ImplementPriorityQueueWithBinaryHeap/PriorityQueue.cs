using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ImplementPriorityQueueWithBinaryHeap
{
    class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T> data;

        public PriorityQueue()
        {
            this.data = new List<T>();
        }

        public int Count
        {
            get { return this.data.Count; }
            private set { }
        }

        public int Capacity
        {
            get { return this.data.Capacity; }
            private set { }
        }

        public T Peek()
        {
            return this.data[0];
        }

        public void Enqueue(T value)
        {
            this.data.Add(value);
        }

        public T Dequeue()
        {
            data.RemoveAt(0);

            return this.data[0];
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < data.Count; ++i)
                s += data[i].ToString() + " ";
            s += "count = " + data.Count;
            return s;
        }
    }
}
