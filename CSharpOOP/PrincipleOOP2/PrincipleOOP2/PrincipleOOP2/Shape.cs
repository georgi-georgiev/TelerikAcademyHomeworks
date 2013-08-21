using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincipleOOP2
{
    public abstract class Shape
    {
        private double height;
        private double width;

        protected Shape(double height, double width)
        {
            this.height = height;
            this.width = width;
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (this.height < 0)
                {
                    throw new ArgumentOutOfRangeException("The height must be bigger than zero");
                }
                else
                {
                    this.height = value;
                }
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (this.width < 0)
                {
                    throw new ArgumentOutOfRangeException("The width must be bigger than zero");
                }
                else
                {
                    this.width = value;
                }
            }
        }

        public abstract double CalculateSurface();
    }
}
