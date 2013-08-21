using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ReadLargeCollection
{
    public class Product:IComparable<Product>
    {
        private string name;
        private int price;

        public Product(string name, int price)
        {
            this.name = name;
            this.price = price;
        }

        public string Name
        {
            get { return this.name; }
            private set { }
        }

        public int Price
        {
            get { return this.price; }
            private set { }
        }

        public int CompareTo(Product obj)
        {
            return this.price.CompareTo(obj.price);
        }
    }
}
