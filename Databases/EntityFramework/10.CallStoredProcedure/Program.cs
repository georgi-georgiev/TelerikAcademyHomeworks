using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.UsingVSFDesigner;

namespace _10.CallStoredProcedure
{
    class Program
    {
        static void Main(string[] args)
        {
            NorthwindEntities context = new NorthwindEntities();
            GetTotalIncomes(context);
        }

        static void GetTotalIncomes(NorthwindEntities context, string supplier, DateTime startDate, DateTime endDate)
        {
            var incomes = context.usp_TotalIncomes(supplier, startDate, endDate);

            foreach (var income in incomes)
            {
                Console.WriteLine(income.SupplierName);
            }
        }
    }
}
