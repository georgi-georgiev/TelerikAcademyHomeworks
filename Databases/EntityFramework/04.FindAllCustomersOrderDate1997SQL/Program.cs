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
                var nativeSQLQuery =
                    "SELECT c.CompanyName FROM Customers c " +
                    "JOIN Orders o "+
                    "ON c.CustomerID = o.CustomerID AND YEAR(o.OrderDate) = 1997 AND c.Country = 'Canada'";

                var customerOrders = ne.Database.SqlQuery<string>(nativeSQLQuery);

                foreach (var item in customerOrders)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
