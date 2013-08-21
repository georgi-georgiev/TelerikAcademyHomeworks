namespace Abstraction
{
    using System;

    public class Rectangle : Figure
    {
        private double width;

        private double heigth;

        public Rectangle(double width, double height)
        {
            if (width > 0)
            {
                this.Width = width;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid input data. Width must be positive!");
            }

            if (height > 0)
            {
                this.Height = height;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid input data. Heigth must be positive!");
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value > 0)
                {
                    this.width = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Invalid input data. Width must be positive!");
                }
            }
        }

        public double Height
        {
            get
            {
                return this.heigth;
            }

            set
            {
                if (value > 0)
                {
                    this.heigth = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Invalid input data. Height must be positive!");
                }
            }
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}