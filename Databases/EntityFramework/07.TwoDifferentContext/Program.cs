using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.UsingVSFDesigner;

namespace _07.TwoDifferentContext
{
    class Program
    {
        static void Main(string[] args)
        {
            using (NorthwindEntities firstContext = new NorthwindEntities())
            {
                using (NorthwindEntities secondContext = new NorthwindEntities())
                {
                    Product firstDataContext = firstContext.Products.Find(71);
                    firstDataContext.ProductName = "Flo";

                    Product secondDataContext = secondContext.Products.Find(71);
                    secondDataContext.ProductName = "Flot";

                    firstContext.SaveChanges();
                    secondContext.SaveChanges();
                }
            }
        }
    }
}
