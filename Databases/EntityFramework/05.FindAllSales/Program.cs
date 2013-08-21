using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.UsingVSFDesigner;

namespace _05.FindAllSales
{
    class Program
    {
        static void Main(string[] args)
        {
            NorthwindEntities northwindEntities = new NorthwindEntities();
            Find("RJ", new DateTime(1996, 1, 1), new DateTime(1997, 12, 31), northwindEntities);
        }

        static void Find(string region, DateTime startDate, DateTime endDate, NorthwindEntities context)
        {
            var sales =
                from order in context.Orders
                where order.OrderDate >= startDate
                where order.OrderDate <= endDate
                where order.ShipRegion == region
                select new
                {
                    Customer = order.CustomerID,
                    Date = order.OrderDate,
                    City = order.ShipCity
                };

            foreach (var sale in sales)
            {
                Console.WriteLine("{0} - {1} - {2}", sale.Customer, sale.Date, sale.City);
            }
        }
    }
}
