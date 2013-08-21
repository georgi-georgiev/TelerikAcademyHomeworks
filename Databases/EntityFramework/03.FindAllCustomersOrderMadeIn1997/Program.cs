using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.UsingVSFDesigner;

namespace _03.FindAllCustomersOrderMadeIn1997
{
    class Program
    {
        static void Main(string[] args)
        {
            NorthwindEntities northwindEntities = new NorthwindEntities();
            FindAll(northwindEntities);
        }
        static void FindAll(NorthwindEntities ne)
        {
            using (ne)
            {
                var customerOrders =
                from order in ne.Orders
                join customer in ne.Customers 
                on order.CustomerID equals customer.CustomerID
                where order.OrderDate.Value.Year == 1997
                where customer.Country == "Canada"
                select new
                {
                    CustomerName = customer.CompanyName,
                    Orderdate = order.OrderDate,
                    Country = customer.Country
                };

                foreach (var item in customerOrders)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
