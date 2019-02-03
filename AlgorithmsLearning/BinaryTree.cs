using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsLearning
{
    class BinaryTree
    {
        public BinaryTree()
        {
            //TreeNode tree = new TreeNode(1);
            //tree.left = new TreeNode(2);
            //tree.right = new TreeNode(3);
            //tree.left.left = new TreeNode(4);
            //tree.left.right = new TreeNode(5);
            //int _Result = FindMinimumDepth(tree);

            //TreeNode tree = new TreeNode(5);
            //tree.left = new TreeNode(2);
            //tree.right = new TreeNode(10);
            //tree.left.left = new TreeNode(20);
            //tree.left.right = new TreeNode(1);
            //tree.right.left = new TreeNode(6);
            //tree.right.right = new TreeNode(15);

            //int _Result = FindMaxSum(tree);

            //PrintTreeInOrder(tree);
            //PrintTreePreOrder(tree);
            //PrintTreePostOrder(tree);

            //if (IsFullBinaryTree(tree))
            //    Console.Write("true");
            //else
            //Console.Write("false");
            //1 5 7 10 40 50
            TreeNode[] _TreeNodes = new TreeNode[] { new TreeNode(10), new TreeNode(5), new TreeNode(1), new TreeNode(7), new TreeNode(40), new TreeNode(50) };
            TreeNode _Root = ConstructBinarySearchTreePreOrder(_TreeNodes);

            Console.ReadKey();
        }
        public int FindMinimumDepth(TreeNode node)
        {
            if (node.left == null && node.right == null)
                return 1;

            if (node.left == null)
                return FindMinimumDepth(node.left) + 1;
            if (node.right == null)
                return FindMinimumDepth(node.right) + 1;

            return Math.Min(FindMinimumDepth(node.left), FindMinimumDepth(node.right)) + 1;

        }
        public int FindMaxSum(TreeNode node)
        {
            int _LeftMax = 0;
            int _RightMax = 0;
            if (node.left != null)
                _LeftMax = FindMaxSumHelper(node.left);
            if (node.right != null)
                _RightMax = FindMaxSumHelper(node.right);

            return Math.Max(Math.Max(Math.Max(_LeftMax, _RightMax), Math.Max(_LeftMax + node.data, _RightMax + node.data)), _LeftMax + node.data + _RightMax);

        }
        public int FindMaxSumHelper(TreeNode node)
        {
            int _LeftMax = 0;
            int _RightMax = 0;

            if (node.left == null && node.right == null)
                return Math.Max(node.data, 0);

            if (node.left != null)
                _LeftMax = FindMaxSumHelper(node.left);

            if (node.right != null)
                _RightMax = FindMaxSumHelper(node.right);

            return node.data + Math.Max(_LeftMax, _RightMax);

        }
        public void PrintTreeInOrder(TreeNode node)
        {
            if (node == null)
                return;

            PrintTreeInOrder(node.left);

            Console.Write(node.data + " ");

            PrintTreeInOrder(node.right);
        }
        public void PrintTreePreOrder(TreeNode node)
        {
            if (node == null)
                return;

            Console.Write(node.data + " ");

            PrintTreePreOrder(node.left);

            PrintTreePreOrder(node.right);
        }
        public void PrintTreePostOrder(TreeNode node)
        {
            if (node == null)
                return;

            PrintTreePostOrder(node.left);

            PrintTreePostOrder(node.right);

            Console.Write(node.data + " ");
        }
        public bool IsFullBinaryTree(TreeNode node)
        {
            if (node == null)
                return true;
            if ((node.left != null && node.right != null) || (node.left == null && node.right == null))
                return IsFullBinaryTree(node.left) && IsFullBinaryTree(node.right);
            else
                return false;
        }
        public TreeNode ConstructBinarySearchTreePreOrder(TreeNode[] nodes)
        {
            Stack<TreeNode> _Stack = new Stack<TreeNode>();
            TreeNode _Root = nodes[0];
            _Stack.Push(_Root);

            for (int i = 1; i < nodes.Length; i++)
            {
                TreeNode _Temp = null;
                while (_Stack.Count > 0 && _Stack.Peek().data < nodes[i].data)
                {
                    _Temp = _Stack.Pop();
                }
                if (_Temp != null)
                {
                    _Temp.right = nodes[i];
                }
                else
                {
                    _Temp = _Stack.Peek();
                    _Temp.left = nodes[i];
                }
                _Stack.Push(nodes[i]);

            }

            return _Root;
        }

        public class TreeNode
        {
            public int data;
            public TreeNode left, right;
            public TreeNode(int item)
            {
                data = item;
                left = right = null;
            }
        }
    }
}