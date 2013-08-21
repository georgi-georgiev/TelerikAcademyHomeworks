using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincipleOOP2
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape[] shapes = 
            {
                new Rectangle(3, 5),
                new Triangle(4, 6),
                new Circle(7)
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.CalculateSurface());
            }
        }
    }
}
