using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadthFirstSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Node root = new Node(5);
            root.left = new Node(10);
            root.right = new Node(15);
            root.left.left = new Node(20);
            root.left.right = new Node(25);
            root.right.left = new Node(30);
            root.right.right = new Node(35);
            root.left.left.right = new Node(40);
            root.left.right.right = new Node(45);
            //root.right.left.right = new Node(50);
            root.right.right.right = new Node(55);
            //root.right.right.right.right = new Node(55);

            //Console.WriteLine(getTreeWidth(root));
            //Console.WriteLine(getMinDepth(root));
            //Console.WriteLine(getMaxDepth(root));
            //Console.WriteLine(getMinDepthRecursive(root));
            //Console.WriteLine(getTreeWidthRecursive(root));
        }

        public static int getTreeWidth(Node root)
        {
            if (root == null)
            {
                return 0;
            }

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            int nodesAtLevel, maxWidth = 0;

            while (queue.Count > 0)
            {
                nodesAtLevel = queue.Count;
                if (nodesAtLevel > maxWidth)
                {
                    maxWidth = nodesAtLevel;
                }

                while (nodesAtLevel > 0)
                {
                    Node n = queue.Dequeue();
                    if (n.left != null)
                    {
                        queue.Enqueue(n.left);
                    }
                    if (n.right != null)
                    {
                        queue.Enqueue(n.right);
                    }
                    nodesAtLevel--;
                }
            }

            return maxWidth;
        }

        public static int getTreeWidthRecursive(Node root)
        {
            if (root == null)
            {
                return -1;
            }

            Dictionary<int, int> levels = new Dictionary<int, int>();
            List<Node> level = new List<Node>() { root };

            getTreeWidthHelper(level, 0, levels);

            return levels.Values.Max();
        }

        public static void getTreeWidthHelper(List<Node> level, int depth, Dictionary<int, int> levels)
        {
            List<Node> nextLevel = new List<Node>();
            levels[depth] = level.Count;

            foreach (Node n in level)
            {
                if (n.left != null)
                {
                    nextLevel.Add(n.left);
                }
                if (n.right != null)
                {
                    nextLevel.Add(n.right);
                }
            }

            if (nextLevel.Count > 0)
            {
                getTreeWidthHelper(nextLevel, ++depth, levels);
            }
        }

        public static int getMinDepth(Node root)
        {
            if (root == null)
            {
                return -1;
            }

            Queue<Node> queue = new Queue<Node>();
            int currDepth = -1, nodesAtLevel;
            queue.Enqueue(root);
            bool minDepthFound = false;

            while (queue.Count > 0 && !minDepthFound)
            {
                nodesAtLevel = queue.Count;
                currDepth++;

                while (nodesAtLevel-- > 0 && !minDepthFound)
                {
                    Node n = queue.Dequeue();
                    if (n.left == null && n.right == null)
                    {
                        minDepthFound = true;
                        break;
                    }
                    if (n.left != null)
                    {
                        queue.Enqueue(n.left);
                    }
                    if (n.right != null)
                    {
                        queue.Enqueue(n.right);
                    }
                }
            }

            return currDepth;
        }

        public static int getMinDepthRecursive(Node root)
        {
            if (root == null)
            {
                return -1;
            }

            List<Node> firstLevel = new List<Node>() { root };

            return getMinDepthHelper(firstLevel, 0, false);
        }

        public static int getMinDepthHelper(List<Node> level, int depth, bool minFound)
        {
            List<Node> nextLevel = new List<Node>();
            int minDepth = -1;
            foreach (Node n in level)
            {
                if (n.left == null && n.right == null)
                {
                    minFound = true;
                    break;
                }
                if (n.left != null)
                {
                    nextLevel.Add(n.left);
                }
                if (n.right != null)
                {
                    nextLevel.Add(n.right);
                }
            }
            if (nextLevel.Count > 0 && !minFound)
            {
                minDepth = getMinDepthHelper(nextLevel, ++depth, false);
            }

            return ++minDepth;
        }

        public static int getMaxDepthRecursive(Node focusNode)
        {
            if (focusNode == null)
            {
                return -1;
            }

            int leftHeight = getMaxDepthRecursive(focusNode.left);
            int rightHeight = getMaxDepthRecursive(focusNode.right);

            if (leftHeight > rightHeight)
            {
                return leftHeight + 1;
            }
            else
            {
                return rightHeight + 1;
            }
        }

        public static int getMaxDepth(Node root)
        {
            if (root == null)
            {
                return -1;
            }

            int depth = -1;
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int nodesAtLevel = queue.Count;
                depth++;

                while (nodesAtLevel-- > 0)
                {
                    Node n = queue.Dequeue();
                    if (n.left != null)
                    {
                        queue.Enqueue(n.left);
                    }
                    if (n.right != null)
                    {
                        queue.Enqueue(n.right);
                    }
                }
            }

            return depth;
        }
    }
    public class Node
    {
        public int data;
        public Node left = null;
        public Node right = null;

        public Node(int data)
        {
            this.data = data;
        }
    }
}
