namespace CorrectUseVariables
{
    using System;
    using System.Linq;

    class PrintStatistics
    {
        public PrintStatistics()
        {
        }

        public static void Main(double[] elements, int limit)
        {
            PrintMinElement(elements, limit);
            PrintMaxElement(elements, limit);
            PrintAverage(elements, limit);
        }

        public static void PrintMinElement(double[] elements, int limit)
        {
            double minElement = elements[0];

            for (int i = 1; i < limit; i++)
            {
                if (elements[i] < minElement)
                {
                    minElement = elements[i];
                }
            }

            Console.WriteLine(minElement);
        }

        public static void PrintMaxElement(double[] elements, int limit)
        {
            double maxElement = elements[0];

            for (int i = 1; i < limit; i++)
            {
                if (elements[i] > maxElement)
                {
                    maxElement = elements[i];
                }
            }

            Console.WriteLine(maxElement);
        }

        public static void PrintAverage(double[] elements, int limit)
        {
            double sumOfTheElements = 0;

            for (int i = 0; i < limit; i++)
            {
                sumOfTheElements += elements[i];
            }

            double average = sumOfTheElements / limit;
            Console.WriteLine(average);
        }
    }
}
