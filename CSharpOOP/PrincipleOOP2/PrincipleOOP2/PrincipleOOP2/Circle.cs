using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincipleOOP2
{
    public class Circle : Shape
    {
        public Circle(double diameter)
            : base(diameter, diameter)
        {
        }

        public override double CalculateSurface()
        {
            return Math.PI * this.Height * this.Height / 4d;
        }
    }
}
