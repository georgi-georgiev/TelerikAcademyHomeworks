using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.ImplementStack
{
    public class Stack<T>
    {
        StackArray<T> array;
        int count;

        public Stack()
        {
            this.array = new StackArray<T>();
            this.count = 0;
        }

        public void Push(T value)
        {
            count++;
            array.Push(value);
        }

        public T Peek()
        {
            return array.Peek();
        }

        public T Pop()
        {
            if (count > 0)
            {
                count--;
            }
            else
            {
                throw new InvalidOperationException();
            }
            return array.Pop();
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

    }
}
