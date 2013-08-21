using System;
using System.Collections.Generic;
using System.Linq;
using DynamicPrograming;

namespace DynamicPrograming
{
    class Program
    {
        static void Main()
        {
            Product[] Products = new Product[]{
                                        new Product("beer", 3, 2),
                                        new Product("vodka", 8, 12),
                                        new Product("cheese", 4, 5),
                                        new Product("nuts", 1, 4),
                                        new Product("ham", 2, 3),
                                        new Product("whiskey", 8, 13)
            };

            int capacity = 10;

            Console.WriteLine(String.Join(" ", KnapsackDynamic(Products, capacity).Select(r => r.Name)));

        }

        public static List<Product> KnapsackDynamic(Product[] Products, int capacity)
        {
            if (capacity == 0)
                return new List<Product>();

            if (Products.Length == 0)
                return new List<Product>();

            int[,] CostsArray = new int[Products.Length, capacity + 1];

            int[,] keepArray = new int[Products.Length, capacity + 1];


            for (int x = 0; x <= Products.Length - 1; x++)
            {
                CostsArray[x, 0] = 0;
                keepArray[x, 0] = 0;
            }

            for (int y = 1; y <= capacity; y++)
            {
                if (Products[0].Weight <= y)
                {
                    CostsArray[0, y] = Products[0].Cost;
                    keepArray[0, y] = 1;
                }
                else
                {
                    CostsArray[0, y] = 0;
                    keepArray[0, y] = 0;
                }
            }


            for (int x = 0; x <= Products.Length - 2; x++)
            {
                for (int y = 1; y <= capacity; y++)
                {
                    var currentProduct = Products[x + 1];

                    if (currentProduct.Weight > y)
                    {
                        CostsArray[x + 1, y] = CostsArray[x, y];

                        continue;
                    }

                    int CostWhenDropping = CostsArray[x, y];
                    int CostWhenTaking = CostsArray[x, y - currentProduct.Weight] + currentProduct.Cost;

                    if (CostWhenTaking > CostWhenDropping)
                    {
                        CostsArray[x + 1, y] = CostWhenTaking;
                        keepArray[x + 1, y] = 1;
                    }
                    else
                    {
                        CostsArray[x + 1, y] = CostWhenDropping;
                        keepArray[x + 1, y] = 0;
                    }
                }
            }

            var bestProducts = new List<Product>();

            {
                int remainingSpace = capacity;
                int Product = Products.Length - 1;

                while (Product >= 0 && remainingSpace >= 0)
                {
                    if (keepArray[Product, remainingSpace] == 1)
                    {

                        bestProducts.Add(Products[Product]);
                        remainingSpace -= Products[Product].Weight;
                        Product -= 1;
                    }
                    else
                    {
                        Product -= 1;
                    }
                }
            }

            return bestProducts;
        }

        public static void PrintMatrix(int[,] mx, int untilRow, Product[] Products)
        {
            const int FOO = 17;

            Console.Write("R Product     W  V |");

            for (int col = 0; col < mx.GetLength(1); ++col)
            {
                Console.Write((col + "").PadLeft(2, ' ').PadRight(3, ' '));
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', FOO + mx.GetLength(1) * 3));

            for (int row = 0; row <= untilRow; ++row)
            {
                Console.Write("{0} ", row);
                Console.Write("{0:0} ", Products[row].Name.PadRight(8, ' '));
                Console.Write("{0:0} ", Products[row].Weight);
                Console.Write("{0:0} |", (Products[row].Cost + "").PadLeft(2, ' '));

                for (int col = 0; col < mx.GetLength(1); ++col)
                {
                    Console.Write("{0:00} ", mx[row, col]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}