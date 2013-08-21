using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _02.CompanyArticles
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] range = input.Split(new char[] { ',' });

            OrderedMultiDictionary<long, Article> articles = new OrderedMultiDictionary<long, Article>(true);

            Random random = new Random();
            for (int i = 0; i < 1000; i++)
            {
                long barcode = random.Next(0, 100000);
                string vendor = "Vendor"+i;
                string title = "Title"+i;
                int price = i*100;
                articles.Add(barcode, new Article(barcode, vendor, title, price));
            }
            long from = long.Parse(range[0]);
            long to = long.Parse(range[1]);
            var result = articles.Range(from, true, to, true);
            Console.WriteLine("Results: {0}: ", result.Count);
        }
    }
}
