using System;
using System.Collections.Generic;

namespace TVCompany
{
    class Program
    {
        public static void Main()
        {
            SortedSet<Edge> priority = new SortedSet<Edge>();
            int numberOfNodes = 8;
            bool[] used = new bool[numberOfNodes + 1];
            List<Edge> mpdNodes = new List<Edge>();
            List<Edge> edges = new List<Edge>();
            InitializeGraph(edges);

            Console.WriteLine("The paths from house to house are:");

            for (int i = 0; i < edges.Count; i++)
            {
                Console.WriteLine("{0}", edges[i]);
                if (edges[i].StartHouse == edges[0].StartHouse)
                {
                    priority.Add(edges[i]);
                }
            }
            used[edges[0].StartHouse] = true;

            FindMinimumSpanningTree(used, priority, mpdNodes, edges);

            PrintMinimumSpanningTree(mpdNodes);
        }

        private static void PrintMinimumSpanningTree(List<Edge> mpdNodes)
        {
            Console.WriteLine("The minimum spanning tree to minimize the cabling expenses:");
            for (int i = 0; i < mpdNodes.Count; i++)
            {
                Console.WriteLine("{0}", mpdNodes[i]);
            }
        }

        private static void FindMinimumSpanningTree(bool[] used, SortedSet<Edge> priority, List<Edge> mpdEdges, List<Edge> edges)
        {
            while (priority.Count > 0)
            {
                Edge edge = priority.Min;
                priority.Remove(edge);

                if (!used[edge.EndHouse])
                {
                    used[edge.EndHouse] = true;
                    mpdEdges.Add(edge);
                    AddEdges(edge, edges, mpdEdges, priority, used);
                }
            }
        }

        private static void AddEdges(Edge edge, List<Edge> edges, List<Edge> mpd, SortedSet<Edge> priority, bool[] used)
        {
            for (int i = 0; i < edges.Count; i++)
            {
                if (!mpd.Contains(edges[i]))
                {
                    if (edge.EndHouse == edges[i].StartHouse && !used[edges[i].EndHouse])
                    {
                        priority.Add(edges[i]);
                    }
                }
            }
        }

        private static void InitializeGraph(List<Edge> edges)
        {
            edges.Add(new Edge(1, 3, 5));
            edges.Add(new Edge(1, 2, 4));
            edges.Add(new Edge(1, 4, 9));
            edges.Add(new Edge(2, 4, 2));
            edges.Add(new Edge(3, 4, 20));
            edges.Add(new Edge(3, 5, 7));
            edges.Add(new Edge(4, 5, 8));
            edges.Add(new Edge(4, 7, 6));
            edges.Add(new Edge(5, 6, 12));
            edges.Add(new Edge(6, 8, 2));
            edges.Add(new Edge(7, 8, 4));
        }
    }
}