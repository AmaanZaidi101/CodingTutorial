using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionLibrary
{
    public class TreeNode
    {
        public TreeNode(int val)
        {
            Val = val;
        }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        public int Val { get; set; }
    }
    public class BinaryTree
    {
        private TreeNode Root;
        public BinaryTree(int treeNo=1, int len=0)
        {
            switch (treeNo)
            {
                case 1:
                    CreateRandomTree();
                    break;
                case 2:
                    CreateRandomTree2();
                    break;
                case 3:
                    CreateCompleteTree(len);
                    break;
                default:
                    break;
            }
            rightSideArray = new int[this.DepthFirstSearch(null)];
            for (int i = 0; i < rightSideArray.Length; i++)
            {
                rightSideArray[i] = -999;
            }
        }

        public void CreateCompleteTree(int length)
        {
            if (length == 12)
            {
                Root = new TreeNode(1)
                {
                    Left = new TreeNode(1)
                    {
                        Left = new TreeNode(1)
                        {
                            Left = new TreeNode(1),
                            Right = new TreeNode(1)
                        },
                        Right = new TreeNode(1)
                        {
                            Left = new TreeNode(1),
                            Right = new TreeNode(1)
                        }
                    },
                    Right = new TreeNode(1)
                    {
                        Left = new TreeNode(1)
                        {
                            Left = new TreeNode(1)
                        },
                        Right= new TreeNode(1)
                    }
                };
            }
            else if(length == 8)
            {
                Root = new TreeNode(1)
                {
                    Left = new TreeNode(1)
                    {
                        Left = new TreeNode(1)
                        {
                            Left = new TreeNode(1)
                        },
                        Right = new TreeNode(1)
                    },
                    Right = new TreeNode(1)
                    {
                        Left = new TreeNode(1),
                        Right = new TreeNode(1)
                    }
                };
            }
            else if(length == 15)
            {
                Root = new TreeNode(1)
                {
                    Left = new TreeNode(1)
                    {
                        Left = new TreeNode(1)
                        {
                            Left = new TreeNode(1),
                            Right = new TreeNode(1)
                        },
                        Right = new TreeNode(1)
                        {
                            Left = new TreeNode(1),
                            Right = new TreeNode(1)
                        }
                    },
                    Right = new TreeNode(1)
                    {
                        Left = new TreeNode(1)
                        {
                            Left = new TreeNode(1),
                            Right = new TreeNode(1)
                        },
                        Right = new TreeNode(1)
                        {
                            Left = new TreeNode(1),
                            Right = new TreeNode(1)
                        }
                    }
                };
            }
        }


        public void CreateRandomTree()
        {
            Root = new TreeNode(3) {
                Left = new TreeNode(6)
                {
                    Left = new TreeNode(9)
                    {
                        Right = new TreeNode(5)
                        {
                            Left = new TreeNode(8)
                        }
                    },
                    Right = new TreeNode(2)
                },
                Right = new TreeNode(1)
                {
                    Right = new TreeNode(4)
                }
            };
        }

        public void CreateRandomTree2()
        {
            Root = new TreeNode(1)
            {
                Left = new TreeNode(2)
                {
                    Left = new TreeNode(4)
                    {
                        Right = new TreeNode(7)
                        {
                            Left = new TreeNode(8)
                        }
                    },
                    Right = new TreeNode(5)
                },
                Right = new TreeNode(3)
                {
                    Right = new TreeNode(6)
                }
            };
        }

        public int DepthFirstSearch(TreeNode node)
        {
            if (node == null)
                node = Root;
            int leftCount = 0; int rightCount = 0;
            if (node.Left == null && node.Right == null)
                return 1;
            else if(node.Left != null)
            {
                leftCount = DepthFirstSearch(node.Left);
            }
            else if(node.Right != null)
            {
                rightCount = DepthFirstSearch(node.Right);
            }
            return 1 + Math.Max(leftCount, rightCount);
        }

        public int[][] LevelOrderTraversel()
        {
            //TraverseNodesWithList(Root,0);
            //int[][] leveltraversed = new int[dict.Keys.Count][];
            //int c = 0;
            //foreach (var key in dict.Keys)
            //{
            //    leveltraversed[c++] = dict[key].ToArray();
            //}
            //return leveltraversed;
            TraverseNodes(Root, 0, 0);
            int[][] leveltraversed = new int[dictionary.Keys.Count][];
            int c = 0;
            foreach (var key in dictionary.Keys)
            {
                leveltraversed[c++] = dictionary[key].Where(x=>x != -999).ToArray();
            }
            return leveltraversed;
        }
        Dictionary<int, int[]> dictionary = new Dictionary<int, int[]>();
        private void TraverseNodes(TreeNode node, int height, int index)
        {
            if (node != null)
            {
                if (!dictionary.ContainsKey(height))
                {
                    int[] arr = new int[height * 2 + 1];
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i] = -999;
                    }
                    arr[index] = node.Val;
                    dictionary.Add(height, arr);
                }
                else
                {
                    dictionary[height][index] = node.Val;
                }
            }
            
            if(node.Left != null)
            {
                TraverseNodes(node.Left, height + 1, 0);
            }
            if (node.Right != null)
            {
                int c = 0;
                while(dictionary.ContainsKey(height+1) && dictionary[height+1] != null && c <dictionary[height+1].Length && dictionary[height+1][c] != -999)
                {
                    c++;
                }
                TraverseNodes(node.Right, height + 1, c);
            }
        }

        Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
        private void TraverseNodesWithList(TreeNode node, int height)
        {
            if (node != null)
            {
                if (!dict.ContainsKey(height))
                {
                    var list = new List<int>();
                    list.Add(node.Val);
                    dict.Add(height, list);
                }
                else
                {
                    dict[height].Add(node.Val);
                }
            }
            if (node.Left != null)
            {
                TraverseNodesWithList(node.Left, height + 1);
            }
            if (node.Right != null)
            {
                TraverseNodesWithList(node.Right, height + 1);
            }
        }

        public void BreadthFirstTraversal()
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(Root);
            while(queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                Console.Write($"{node.Val} ");

                if (node.Left != null)
                    queue.Enqueue(node.Left);
                if (node.Right != null)
                    queue.Enqueue(node.Right);
            }
        }

        public int[][] LevelTraversalWithBFS()
        {
            int[][] arr = new int[DepthFirstSearch(null)][];

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(Root);
            int countsToGo = queue.Count;
            int[] a = new int[countsToGo];
            int counter = 0;
            while(queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                a[a.Length - countsToGo] = node.Val;
                countsToGo--;
                
                if (node.Left != null)
                    queue.Enqueue(node.Left);
                if (node.Right != null)
                    queue.Enqueue(node.Right);
                if (countsToGo == 0)
                {

                    arr[counter++] = a;
                    countsToGo = queue.Count;
                    a = new int[countsToGo];
                }
            }

            return arr;
        }

        private int[] rightSideArray;
        public int[] LookFromRightSide(TreeNode node, int level=0)
        {
            if (node == null)
                node = Root;
            if (rightSideArray[level] == -999)
                rightSideArray[level] = node.Val;
            if (node.Right != null)
                LookFromRightSide(node.Right, level + 1);
            if (node.Left != null)
                LookFromRightSide(node.Left, level + 1);
            return rightSideArray;
        }

        public int[] LookFromRightSideWithBFS()
        {
            List<int> list = new List<int>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(Root);
            int countsToGo = queue.Count;

            while(queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                countsToGo--;
                
                if (node.Left != null)
                    queue.Enqueue(node.Left);
                if (node.Right != null)
                    queue.Enqueue(node.Right);
                
                if(countsToGo == 0)
                {
                    list.Add(node.Val);
                    countsToGo = queue.Count;
                }

            }

            return list.ToArray();
        }

        private int countNodes = 0;
        public int CountNodesInCompleteTree(TreeNode node)
        {
            if (Root == null)
                return 0;
            else if (node == null)
                node = Root;
            int left = 0, right = 0;

            if (node.Left != null)
                left = CountNodesInCompleteTree(node.Left);
            if (node.Right != null)
                right = CountNodesInCompleteTree(node.Right);
            return 1 + left + right;
        }
        public int CountNodesInCompleteTreeBFS()
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(Root);
            int count = 0;
            while(queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                count++;

                if (node.Left != null)
                    queue.Enqueue(node.Left);
                if (node.Right != null)
                    queue.Enqueue(node.Right);
            }
            return count;
        }

        public int CountNodesInCompleteTreeInLogN()
        {
            if (Root == null)
                return 0;
            int height = GetCompleteTreeHeight();
            if (height == 0)
                return 1;
            int upperNodeCount = (int)Math.Pow(2, height) - 1;
            //BinarySearch
            int lowerNodeCount = 0;
            int low = 0, high = upperNodeCount;
            while (low != high)
            {
                int mid = (int)Math.Ceiling((decimal)(low + high) / 2);
                bool nodeExist = DoesNodeExist(mid,height);
                if(nodeExist)
                {
                    lowerNodeCount = mid;
                    low = mid;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return upperNodeCount + lowerNodeCount + 1;
        }

        private bool DoesNodeExist(int indexToFind,int height)
        {
            int totalNodesThatCanExistForCurrentRoot = (int)Math.Pow(2, height);
            int highestIndex = totalNodesThatCanExistForCurrentRoot - 1;
            int low = 0;
            int high = highestIndex;
            int mid = (int)Math.Ceiling((decimal)(low + high) / 2);
            int depthWeAreAt = 0;
            TreeNode node = Root;
            while(depthWeAreAt != height)
            {
                if (mid <= indexToFind)
                {
                    node = node.Right;
                    low = mid;
                }
                else if (mid > indexToFind)
                {
                    node = node.Left;
                    high = mid-1;
                }
                mid = (int)Math.Ceiling((decimal)(low + high) / 2);
                depthWeAreAt++;
            }
            return node != null;
        }

        private int GetCompleteTreeHeight()
        {
            int count = 0;
            TreeNode temp = Root;
            while(temp.Left != null)
            {
                count++;
                temp = temp.Left;
            }
            return count;
        }
    }
}
