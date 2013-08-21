using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.UsingVSFDesigner;

namespace _01.UsingVSFDesignerDBContext
{
    class Program
    {
        static void Main(string[] args)
        {
            var entity = new NorthwindEntities();
            foreach (var customer in entity.Customers)
            {
                Console.WriteLine("{0} - {1} - {2} - {3} - {4}",customer.Address, customer.City, customer.CompanyName, customer.ContactTitle, customer.Country);
                Console.WriteLine("-----------------------------------------------------");
            }
        }
    }
}
