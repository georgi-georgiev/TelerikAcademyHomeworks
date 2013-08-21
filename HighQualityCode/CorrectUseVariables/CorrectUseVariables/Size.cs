namespace CorrectUseVariables
{
    using System;
    using System.Linq;

    public class Size
    {
        private double width;
        private double height;

        public Size(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public static double Width
        {
            get { return width; }
            set { width = value; }
        }

        public static double Height
        {
            get { return height; }
            set { height = value; }
        }

        public static Size GetRotatedSize(Size size, double angleOfTheFigureToRotate)
        {
            double cosOfTheFigure = Math.Abs(Math.Cos(angleOfTheFigureToRotate));
            double sinOfTheFigure = Math.Abs(Math.Sin(angleOfTheFigureToRotate));

            double widthOfTheRotatedFigure = cosOfTheFigure * size.width + sinOfTheFigure * size.height;
            double heightOfTheRotatedFigure = sinOfTheFigure * size.width + cosOfTheFigure * size.height;

            Size rotatedSize = new Size(widthOfTheRotatedFigure, heightOfTheRotatedFigure);

            return rotatedSize;
        }
    }
}