using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.ImplementLinkedList
{
    class ListItem<T>
    {
        T value;
        ListItem<T> nextItem;

        public ListItem()
        {

        }

        public ListItem(T value)
        {
            this.value = value;
        }

        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public ListItem<T> NextItem
        {
            get { return this.nextItem; }
            set { this.nextItem = value; }
        }

        static void Main()
        {
        }
    }
}
