using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.UsingVSFDesigner;

namespace _09.CallStoreProcedure
{
    class Program
    {
        static void Main(string[] args)
        {
            Insert(1, null, null, null, null, null, null, null, null, null);
        }

        static void Insert(int orderId, string customerId, int? employeeId, DateTime? orderDate, DateTime? requiredDate,
            DateTime? shippedDate, int? shipVia, decimal? freight, string shipName, string shipAddress)
        {
            NorthwindEntities context = new NorthwindEntities();

            var order = new Order
            {
                OrderID = orderId,
                CustomerID = customerId,
                EmployeeID = employeeId,
                OrderDate = orderDate,
                ShippedDate = shippedDate,
                ShipVia = shipVia,
                Freight = freight,
                ShipName = shipName,
                ShipAddress = shipAddress
            };
            
            context.Orders.Add(order);
            context.SaveChanges();
        }
    }
}
