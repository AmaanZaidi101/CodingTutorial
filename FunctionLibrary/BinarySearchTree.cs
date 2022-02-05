using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionLibrary
{
    public class BSTNode
    {
        public int val;
        public BSTNode left;
        public BSTNode right; public BSTNode(int v)
        {
            val = v;
        }
    }
    public class BinarySearchTree
    {
        private BSTNode root;

        private int[] arr;
        private List<BSTNode> listOfNodes = new List<BSTNode>();

        public BinarySearchTree(int choice)
        {
            CreateBinaryTree(choice);
            arr = new int[GetNumberOfNodes()];
        }

        private int GetNumberOfNodes()
        {
            if (root == null)
                return 0;
            Queue<BSTNode> queue = new Queue<BSTNode>();
            queue.Enqueue(root);
            int count = 0;
            while(queue.Count > 0)
            {
                BSTNode node = queue.Dequeue();
                count++;

                if (node.left != null)
                    queue.Enqueue(node.left);
                if (node.right != null)
                    queue.Enqueue(node.right);
            }

            return count;
        }

        private void CreateBinaryTree(int choice)
        {
            switch (choice)
            {
                case 1:
                    root = new BSTNode(12)
                    {
                        left = new BSTNode(7)
                        {
                            left = new BSTNode(5),
                            right = new BSTNode(9)
                        },
                        right = new BSTNode(18)
                        {
                            left = new BSTNode(16),
                            right = new BSTNode(25)
                        }
                    };
                    break;
                case 2:
                    root = null;
                    break;
                case 3:
                    root = new BSTNode(10);
                    break;
                case 4:
                    root = new BSTNode(12)
                    {
                        left = new BSTNode(15),
                        right = new BSTNode(17)
                    };
                    break;
                case 5:
                    root = new BSTNode(13)
                    {
                        left = new BSTNode(9),
                        right = new BSTNode(10)
                    };
                    break;
                case 6:
                    root = new BSTNode(15)
                    {
                        left = new BSTNode(12)
                        {
                            left = new BSTNode(10),
                            right = new BSTNode(16)
                        },
                        right = new BSTNode(17)
                        {
                            left = new BSTNode(16),
                            right = new BSTNode(18)
                        }
                    };
                    break;
                case 7:
                    root = new BSTNode(15)
                    {
                        left = new BSTNode(12)
                        {
                            left = new BSTNode(10),
                            right = new BSTNode(14)
                        },
                        right = new BSTNode(18)
                        {
                            left = new BSTNode(13),
                            right = new BSTNode(20)
                        }
                    };
                    break;
                default:
                    break;
            }
        }

        public bool IsValidBinaryTree()
        {
            if (root == null || (root.left == null && root.right == null))
                return true;
            // InOrder
            //InOrderTraversal(root);

            //for (int i = 0; i < listOfNodes.Count-1; i++)
            //{
            //    if (listOfNodes[i].val > listOfNodes[i + 1].val)
            //        return false;
            //}
            //return true;

            //PreOrder
            return CheckValidityWithPreOrder(root.left, root.val, int.MinValue) && CheckValidityWithPreOrder(root.right, int.MaxValue, root.val);
        }

        private bool CheckValidityWithPreOrder(BSTNode node, int lessThan, int greaterThan)
        {
            if (node.val > lessThan || node.val < greaterThan)
                return false;

            if (node.left == null && node.right == null)
                return true;

            return CheckValidityWithPreOrder(node.left, node.val, greaterThan) && CheckValidityWithPreOrder(node.right, lessThan, node.val);
        }

        private void InOrderTraversal(BSTNode node)
        {
            if (node.left != null)
                InOrderTraversal(node.left);
            
            listOfNodes.Add(node);
            
            if (node.right != null)
                InOrderTraversal(node.right);
        }

        public void PrintListOfNodes()
        {
            Console.Write(" ");
            foreach (var node in listOfNodes)
            {
                Console.Write(node.val + " ");
            }
            Console.WriteLine();
        }
    }
}
