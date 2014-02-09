using System;
using System.Collections.Generic;

namespace TreesAndTraversals
{
    /*You are given a tree of N nodes represented as a set of N-1 pairs of nodes (parent node, child node),
     * each in the range (0..N-1). Example:
     * Write a program to read the tree and find:
        the root node
        all leaf nodes
        all middle nodes
        the longest path in the tree
        all paths in the tree with given sum S of their nodes
        all subtrees with given sum S of their nodes
     */
    class FirstExercise
    {
        static int n;
        static Node<int>[] nodes;

        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter N: ");
                n = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            nodes = new Node<int>[n];

            for (int i = 0; i < n; i++)
            {
                nodes[i] = new Node<int>(i);
            }
            for (int i = 1; i <= n - 1; i++)
            {
                string edgeAsString = Console.ReadLine();
                string[] edges = edgeAsString.Split(' ');
                try
                {
                    int parentId = Int32.Parse(edges[0]);
                    int childId = Int32.Parse(edges[1]);
                    nodes[parentId].Children.Add(nodes[childId]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            //a) Find the root node
            var rootNode = FindRoot(nodes);
            Console.WriteLine("The root node is: {0}", rootNode.Value);

            //b) Find the leaves
            var leaves = FindAllLeaves(nodes);
            int[] leavesAsArray = new int[leaves.Count];
            int counter = 0;
            foreach (var leaf in leaves)
            {
                leavesAsArray[counter] = leaf.Value;
                counter++;
            }
            string leavesAsString = String.Join(", ", leavesAsArray);
            Console.WriteLine("Leaves: {0}", leavesAsString);

            //c) Find all middle nodes
            var middleNodes = FindAllMiddleNodes(rootNode, leaves);
            int[] middleNodesAsArray = new int[middleNodes.Count];
            counter = 0; // Reset the counter
            foreach (var middleNode in middleNodes)
            {
                middleNodesAsArray[counter] = middleNode.Value;
                counter++;
            }
            string middleNodesAsString = String.Join(", ", middleNodesAsArray);
            Console.WriteLine("Middle nodes: {0}", middleNodesAsString);

            //d) Find the longest path
            int maxPath = FindTheLongestPath(rootNode);
            Console.WriteLine("The longest path is: {0}", maxPath);
        }

        static List<Node<int>> FindAllMiddleNodes(Node<int> rootNode, List<Node<int>> leaves)
        {
            List<Node<int>> middleNodes = new List<Node<int>>();

            for (int i = 0; i < nodes.Length; i++)
            {
                bool isRoot = nodes[i] == rootNode;
                bool isLeaf = leaves.Contains(nodes[i]);
                if (!isRoot && !isLeaf)
                {
                    middleNodes.Add(nodes[i]);
                }
            }
            return middleNodes;
        }

        static Node<int> FindRoot(Node<int>[] nodes)
        {
            bool[] hasParents = new bool[nodes.Length];
            foreach (var node in nodes)
            {
                foreach (var child in node.Children)
                {
                    hasParents[child.Value] = true;
                }
            }
            for (int i = 0; i < hasParents.Length; i++)
            {
                if (!hasParents[i])
                {
                    return nodes[i];
                }
            }
            throw new ArgumentException("There is no root node");
        }

        static List<Node<int>> FindAllLeaves(Node<int>[] nodes)
        {
            List<Node<int>> leafs = new List<Node<int>>();

            foreach (var node in nodes)
            {
                if (node.Children.Count == 0)
                {
                    leafs.Add(node);
                }
            }
            return leafs;
        }

        static Int32 FindTheLongestPath(Node<int> rootNode)
        {
            if (rootNode.Children.Count == 0)
            {
                return 0;
            }

            int maxPath = 0;
            foreach (var childrenNode in rootNode.Children)
            {
                maxPath = Math.Max(maxPath, FindTheLongestPath(childrenNode));
            }
            return maxPath + 1;
        }
    }
}
