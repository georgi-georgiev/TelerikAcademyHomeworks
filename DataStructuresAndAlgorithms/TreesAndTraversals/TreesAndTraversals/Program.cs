using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreesAndTraversals
{
    public class Program
    {
        static int TreeNodes = int.Parse(Console.ReadLine());

        static Node<int>[] nodes = new Node<int>[TreeNodes];

        private static List<List<int>> paths = new List<List<int>>();

        static void ParseInput()
        {
            for (int i = 0; i < TreeNodes; i++)
            {
                nodes[i] = new Node<int>(i);
            }

            for (int i = 1; i <= TreeNodes-1; i++)
            {
                string edge = Console.ReadLine();
                string[] splittedEdge = edge.Split(' ');

                int parrent = int.Parse(splittedEdge[0]);
                int child = int.Parse(splittedEdge[1]);

                nodes[parrent].Children.Add(nodes[child]);

                nodes[child].HasParent = true;

                nodes[child].Parent = nodes[parrent];
            }
        }

        static Node<int> GetRoot()
        {
            foreach (var node in nodes)
            {
                if (!node.HasParent)
                {
                    return node;
                }
            }
            throw new ArgumentException("No root");
        }

        static List<Node<int>> GetAllLeafs()
        {
            List<Node<int>> leafs = new List<Node<int>>();

            foreach (var node in nodes)
            {
                if (node.HasParent && node.Children.Count == 0)
                {
                    leafs.Add(node);
                    
                }
            }
            return leafs;
        }

        static List<Node<int>> GetAllMiddleNodes()
        {
            List<Node<int>> middleNodes = new List<Node<int>>();

            foreach (var node in nodes)
            {
                if (node.HasParent && node.Children.Count > 0)
                {
                    middleNodes.Add(node);
                    
                }
            }
            return middleNodes;
        }

        static int GetLongestPath(Node<int> root)
        {
            if (root.Children.Count == 0)
            {
                return 0;
            }

            int maxPath = 0;
            foreach (var node in root.Children)
            {
                maxPath = Math.Max(maxPath, GetLongestPath(node));
            }
            return maxPath + 1;
        }

        static void AllPathsWithSum(Node<int> root, int S, int sum, string result)
        {
            if (S == sum)
            {
                Console.WriteLine(result);
                
            }
            foreach (var child in root.Children)
            {
                AllPathsWithSum(child, S, sum + child.Value, result+child.Value + "->");
            }
        }

        static void AllSubtreesWithSum(Node<int> root, int S, int sum, string result)
        {
            if (S == sum)
            {
                Console.WriteLine(result);
            }
            if (root.Value == S)
            {
                result = String.Empty;
                result+=root.Value.ToString()+"->";
            }
            foreach (var child in root.Children)
            {
                AllSubtreesWithSum(child, S, sum + child.Value, result+child.Value+"->");
            }
        }

        static void Main()
        {
            ParseInput();

            //Find root
            Node<int> root = GetRoot();
            Console.WriteLine("Root: {0}", root.Value);

            //Find leafs
            Console.Write("Leafs: ");
            List<Node<int>> leafs = GetAllLeafs();
            foreach (var leaf in leafs)
	        {
		        Console.Write(leaf.Value+", ");
	        }
            Console.WriteLine();

            //Find middle nodes
            Console.Write("Middle nodes: ");
            List<Node<int>> middleNodes = GetAllMiddleNodes();
            foreach (var middleNode in middleNodes)
            {
                Console.Write(middleNode.Value+", ");
            }
            Console.WriteLine();

            //Find longest path
            int longestPath = GetLongestPath(root);
            Console.WriteLine("Longest path: {0}", longestPath);

            //Find all paths with sum
            Console.WriteLine("All paths with sum: ");
            AllPathsWithSum(root, 6, 0, "");

            //Find subtrees with given sum
            Console.WriteLine("All subtrees with given sum: ");
            AllSubtreesWithSum(root, 5, 0, "");
        }
    }
}
