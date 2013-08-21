using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.ImplementQueue
{
    class Queue<T>
    {
        Queue<T> firstItem;
        Queue<T> lastItem;
        int count;

        public void Push(T value)
        {
            if (firstItem == null)
            {
                lastItem = new Queue<T>(value);
                firstItem = lastItem;
            }
            else
            {
                lastItem.PreviousItem = new Queue<T>(value);
                lastItem = lastItem.PreviousItem;
            }

            count++;
        }

        public T Peek()
        {
            return firstItem.Value;
        }

        public T Pop()
        {
            if (firstItem == null)
            {
                throw new InvalidOperationException();
            }
            T valueToReturn = firstItem.Value;
            firstItem = firstItem.PreviousItem;
            count--;
            return valueToReturn;
        }

        public int Count
        {
            get
            {
                return count;
            }
        }
    }
}
