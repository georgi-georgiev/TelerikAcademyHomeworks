using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.ImplementLinkedList
{
    class LinkedList<T>
    {
        ListItem<T> firstItem;

        public LInkedList()
        {
        }

        public LinkedList(T value)
        {
            firstItem = new ListItem<T>();
            FirstItem.Value = value;
        }

        public ListItem<T> FirstItem
        {
            get
            {
                return this.firstItem;
            }
        }

        static void Main()
        {
        }
    }
}
