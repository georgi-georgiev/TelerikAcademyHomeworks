using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _02.ReadLargeCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderedBag<Product> products = new OrderedBag<Product>();

            Random random = new Random();
            for (int i = 0; i < 50000; i++)
            {
                products.Add(new Product("item" + i, random.Next(0, int.MaxValue)));
            }

            var prices = products.FindAll(x => x.Price > 0);
            for (int i = 0; i < 10000; i++)
            {
                int min = random.Next(0, int.MaxValue);
                int max = random.Next(min, int.MaxValue);
                prices = products.FindAll(x => x.Price > min && x.Price < max);
            }

            int counter = 20;
            foreach (var item in prices)
            {
                if (counter != 0)
                {
                    Console.WriteLine("Name: {0} Price: {1}", item.Name, item.Price);
                    counter--;
                }
            }
        }
    }
}
