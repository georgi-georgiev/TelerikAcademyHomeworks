using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeException
{
    class Program
    {
        static void Main(string[] args)
        {
            int startInt = int.Parse(Console.ReadLine());
            int endInt = int.Parse(Console.ReadLine());

            if (startInt > endInt)
            {
                throw new InvalidRangeException<int>("Int is out of range", startInt, endInt);
            }

            string startString = Console.ReadLine();
            string endString = Console.ReadLine();

            DateTime startDate = DateTime.Parse(startString);
            DateTime endDate = DateTime.Parse(endString);

            if (startDate.CompareTo(endDate) > 0)
            {
                throw new InvalidRangeException<DateTime>("DateTime is out of range", startDate, endDate);
            }
        }
    }
}
