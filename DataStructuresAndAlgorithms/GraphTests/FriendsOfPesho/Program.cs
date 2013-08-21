using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsOfPesho
{
    class Program
    {
        public static HashSet<long> nodes = new HashSet<long>();
        public static long[,] minDistance;

        static void Main(string[] args)
        {

            string[] polongs = Console.ReadLine().Split(' ');
            long housesAndHospitalsCount = long.Parse(polongs[0]);
            long streetsCount = long.Parse(polongs[1]);
            long hospitalsCount = long.Parse(polongs[2]);

            long[] hospitals = new long[hospitalsCount];

            string[] hospitalPolongs = Console.ReadLine().Split(' ');
            for (long i = 0; i < hospitalsCount; i++)
            {
                hospitals[i] = long.Parse(hospitalPolongs[i]);
            }

            minDistance = new long[housesAndHospitalsCount, housesAndHospitalsCount];

            List<long> houses = new List<long>();
            for (long i = 1; i <= housesAndHospitalsCount; i++)
            {
                if (!hospitals.Contains(i))
                {
                    houses.Add(i);
                }
            }

            long[,] graph = new long[housesAndHospitalsCount, housesAndHospitalsCount];

            for (long i = 0; i < streetsCount; i++)
            {
                string[] street = Console.ReadLine().Split(' ');
                long firstPolong = long.Parse(street[0]);
                long secondPolong = long.Parse(street[1]);
                long distance = long.Parse(street[2]);

                graph[firstPolong - 1, secondPolong - 1] = distance;
                //We have to set path from B to A !!!
                graph[secondPolong - 1, firstPolong - 1] = distance;
            }

            for (long i = 0; i < hospitalPolongs.Length; i++)
            {
                FindMinimumDistance(graph, hospitals[i] - 1, i);
            }
            for (int i = 0; i < hospitals.Length - 1; i += 2)
            {
                minDistance[hospitals[i] - 1, hospitals[i + 1] - 1] = 0;
            }


            long min = long.MaxValue;
            for (long i = 0; i < minDistance.GetLength(0); i++)
            {
                long currentMin = 0;
                for (long j = 0; j < minDistance.GetLength(0); j++)
                {
                    if (minDistance[i, j] > 0 && minDistance[i, j] < long.MaxValue)
                    {
                        currentMin += minDistance[i, j];
                    }
                }
                if (currentMin < min && currentMin != 0)
                {
                    min = currentMin;
                }
            }
            Console.WriteLine(min);
        }

        static void FindMinimumDistance(long[,] graph, long hospitalPolong, long i)
        {
            for (long j = 0; j < graph.GetLength(0); j++)
            {
                minDistance[i, j] = long.MaxValue;
                nodes.Add(j);
            }

            minDistance[i, hospitalPolong] = 0;

            while (nodes.Count != 0)
            {
                long minNode = long.MaxValue;

                foreach (var node in nodes)
                {
                    if (minNode > minDistance[i, node])
                    {
                        minNode = node;
                    }
                }

                nodes.Remove(minNode);

                if (minNode == long.MaxValue)
                {
                    break;
                }
                for (long k = 0; k < graph.GetLength(0); k++)
                {
                    if (graph[minNode, k] > 0)
                    {
                        long potentialDistance = minDistance[i, minNode] + graph[minNode, k];

                        if (potentialDistance < minDistance[i, k])
                        {
                            minDistance[i, k] = potentialDistance;
                        }
                    }
                }
            }
            nodes.Clear();
        }
    }
}