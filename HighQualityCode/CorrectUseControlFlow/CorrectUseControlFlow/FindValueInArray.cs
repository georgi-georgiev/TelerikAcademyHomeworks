namespace CorrectUseControlFlow
{
    using System;
    using System.Linq;

    class FindValueInArray
    {
        public static void Main()
        {
            //int expectedValue;
            //int[] values;
            bool isExpectedValueFound = false;
            for (int index = 0; index < values.Length; index++)
            {
                Console.WriteLine(values[index]);

                if (index % 10 == 0)
                {
                    if (values[index] == expectedValue)
                    {
                        isExpectedValueFound = true;
                        break;
                    }
                }
            }

            if (isExpectedValueFound)
            {
                Console.WriteLine("Value Found!");
            }
        }
    }
}
