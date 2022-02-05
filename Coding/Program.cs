using System;
using System.Collections.Generic;
using System.Diagnostics;
using FunctionLibrary;

namespace Coding
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //ArrayOperations();
            StringOperations();
            //LinkedListOperations();
            //DoublyLinkedListOperations();
            //CycledLinkedListOperations();
            //StackOperations();
            //RecursiveOperations();
            //BinaryTreeOperations();
            //BinarySearchTreeOperations();
            //HeapOperations();
            //PriorityQueueOperations();
            //MatrixOperations();
            //GraphOperations();
            //DynamicProgrammingOperations();
            //BackTrackingOperations();
            //InterfaceDesignOperations();
            //TrieOperations();
            //SortOperations();
        }

        private static void SortOperations()
        {
            
            do
            {
                Console.WriteLine();
                Console.WriteLine("1: Selection Sort" +
                    "\n2: Bubble Sort" +
                    "\n3 Insertion Sort" +
                    "\n4 Merge Sort" +
                    "\n5 Quick Sort");
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                    continue;
                int[][] arrays = GetArrays();
                Console.WriteLine();
                foreach (var array in arrays)
                {
                    SortFunctions sf = new SortFunctions(array);
                    Console.WriteLine("Original Array");
                    sf.PrintArray();
                    
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("--------------Selection Sort----------------");
                            sf.SelectionSort();
                            break;
                        case 2:
                            Console.WriteLine("--------------Bubble Sort----------------");
                            sf.BubbleSort();
                            break;
                        case 3:
                            Console.WriteLine("--------------Insertion Sort----------------");
                            sf.InsertionSort();
                            break;
                        case 4:
                            Console.WriteLine("--------------Merge Sort----------------");
                            sf.MergeSort(0,array.Length-1);
                            break;
                        case 5:
                            Console.WriteLine("--------------Quick Sort----------------");
                            sf.QuickSort(0, array.Length - 1, array.Length - 1);
                            break;
                        case 6:
                            Console.WriteLine("--------------Heap Sort----------------");
                            sf.HeapSort();
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine("Sorted Array");
                    sf.PrintArray();
                }
                
            } while (true);
        }

        private static int[][] GetArrays()
        {
            return new int[][]
            {
                new int[] { 4, 10, 3, 5, 1 },
                new int[] { 75, 22, 5, 14, 54, 100, 69 },
                new int[] { 1,3,3,5,5,5,8,9 },
                new int[] { 5, 3, 1, 6, 4, 2 },
                new int[]{ 0, 1, 0, 2, 1 , 0, 3, 1, 0, 1, 2 },
                new int[]{ },
                new int[]{0 },
                new int[]{3,4,3 },
                new int[]{2,0,2 },
                new int[]{ 3,0,2,0,4},
                new int[]{ 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 },
                new int[]{ 4,2,0,3,2,5 },
                new int[]{ 5,5,1,7,1,1,5,2,7,6}
            };
        }

        private static void TrieOperations()
        {
            //Trie trie = new Trie();
            Trie2 trie = new Trie2();
            do
            {
                Console.WriteLine("1: Insert" +
                    "\n2: Search" +
                    "\n3: StartsWith");
                int choice;
                int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter Word");
                        var word = Console.ReadLine();
                        trie.Insert(word);
                        break;
                    case 2:
                        Console.WriteLine("Enter Search Word");
                        var search = Console.ReadLine();
                        var res = trie.Search(search);
                        if(res)
                            Console.WriteLine(search+" was found");
                        else
                            Console.WriteLine(search + " was not found");
                        break;
                    case 3:
                        Console.WriteLine("Enter Prefix");
                        var prefix = Console.ReadLine();
                        var r= trie.StartsWith(prefix);
                        if(r)
                            Console.WriteLine("Word starting with "+prefix+" was found");
                        else
                            Console.WriteLine("Word starting with " + prefix + " was not found");
                        break;
                    default:
                        break;
                }
            } while (true);
        }

        private static void InterfaceDesignOperations()
        {
            //Monarchy M = new Monarchy("Jake");
            Monarchy2 M = new Monarchy2("Jake");
            do
            {
                Console.WriteLine("1: Add family member" +
                    "\n2: Kill family member" +
                    "\n3: Get order of succession" +
                    "\n4: Run readymade test cases");
                int choice = 0;
                int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter child's name with parent's name separated by comma");
                        string childparent = Console.ReadLine();
                        string child = childparent.Split(",")[0];
                        string parent = childparent.Split(",")[1];
                        M.Birth(child, parent);
                        break;
                    case 2:
                        Console.WriteLine("Who's dying?");
                        string dying = Console.ReadLine();
                        M.Death(dying);
                        break;
                    case 3:
                        var succession = M.GetOrderOfSuccession();
                        Console.WriteLine("Order of succession is");
                        foreach (var successor in succession)
                        {
                            Console.Write(successor + " ");
                        }
                        break;
                    case 4:
                        RunTestCases(M);
                        break;
                    default:
                        break;
                }
            } while (true);
        }

        private static void RunTestCases(Monarchy2 m)
        {
            Console.WriteLine("Catherine born to Jake");
            m.Birth("Catherine","Jake");
            Console.WriteLine("Tom born to Jake");
            m.Birth("Tom", "Jake");
            Console.WriteLine("Celine born to Jake");
            m.Birth("Celine", "Jake");
            Console.WriteLine("Jane born to Catherine");
            m.Birth("Jane", "Catherine");
            Console.WriteLine("Peter born to Celine");
            m.Birth("Peter", "Celine");
            Console.WriteLine("Farah born to Jake");
            m.Birth("Farah", "Jane");
            Console.WriteLine("Mark born to Catherine");
            m.Birth("Mark","Catherine");
            var succession = m.GetOrderOfSuccession();
            Console.WriteLine("Order of succession is");
            foreach (var successor in succession)
            {
                Console.Write(successor + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Jake died");
            m.Death("Jake");
            Console.WriteLine("Jane died");
            m.Death("Jane");
            succession = m.GetOrderOfSuccession();
            Console.WriteLine("New Order of succession is");
            foreach (var successor in succession)
            {
                Console.Write(successor + " ");
            }
            Console.WriteLine();
        }

        private static void BackTrackingOperations()
        {
            do
            {
                Console.WriteLine("1: Sudoku");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        int[][,] unSolvedSudoku =
                        {
                            new int[9,9]{
                                {5,3,0,0,7,0,0,0,0 },
                                {6,0,0,1,9,5,0,0,0 },
                                {0,9,8,0,0,0,0,6,0 },
                                {8,0,0,0,6,0,0,0,3 },
                                {4,0,0,8,0,3,0,0,1 },
                                {7,0,0,0,2,0,0,0,6 },
                                {0,6,0,0,0,0,2,8,0 },
                                {0,0,0,4,1,9,0,0,5 },
                                {0,0,0,0,8,0,0,7,9 },
                            }
                        };
                        foreach (var sudoku in unSolvedSudoku)
                        {
                            BackTracking bt = new BackTracking();
                            bt.SolveSudoku(sudoku);
                        }
                        break;
                    default:
                        break;
                }
            } while (true);
        }

        private static void DynamicProgrammingOperations()
        {
            do
            {
                Console.WriteLine("1: Minimum Cost of Climbing Stairs" +
                    "\n2: Probability of knight staying on chess board");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        int[][] costs = { 
                            new int[]{ 20, 15, 30, 5 }, //ans 20
                            new int[]{ 10, 15, 30 }, //ans 15
                            new int[]{ 20, 15, 30, 5,10, 15, 30 }, //ans 35
                        }; //can travel 1 or 2 steps at a time
                        foreach (var costsArray in costs)
                        {
                            DynamicProgramming dp = new DynamicProgramming();
                            Console.WriteLine("Minimum cost of cliomibing stairs is " + dp.MinimumCostOfClimbingStairs(costsArray));
                        }
                        break;
                    case 2:
                        Dictionary<KeyValuePair<int, int>, KeyValuePair<int, int>> d = new Dictionary<KeyValuePair<int, int>, KeyValuePair<int, int>>();
                        d.Add(new KeyValuePair<int, int>(6, 2), new KeyValuePair<int, int>(2, 2)); //n - size of chessboard,k-number of steps,row,col
                        d.Add(new KeyValuePair<int, int>(6, 1), new KeyValuePair<int, int>(2, 2)); //n - size of chessboard,k-number of steps,row,col
                        d.Add(new KeyValuePair<int, int>(6, 3), new KeyValuePair<int, int>(2, 2)); //n - size of chessboard,k-number of steps,row,col
                        d.Add(new KeyValuePair<int, int>(8, 3), new KeyValuePair<int, int>(0, 0)); //n - size of chessboard,k-number of steps,row,col
                        d.Add(new KeyValuePair<int, int>(0, 2), new KeyValuePair<int, int>(1, 2)); //n - size of chessboard,k-number of steps,row,col
                        d.Add(new KeyValuePair<int, int>(2, 3), new KeyValuePair<int, int>(1, 1)); //n - size of chessboard,k-number of steps,row,col
                        d.Add(new KeyValuePair<int, int>(2, 0), new KeyValuePair<int, int>(1, 1)); //n - size of chessboard,k-number of steps,row,col
                        foreach (var tc in d)
                        {
                            DynamicProgramming dp = new DynamicProgramming();
                            decimal prob = dp.FindKnightProbability(tc.Key.Key, tc.Key.Value, tc.Value.Key, tc.Value.Value);
                            Console.WriteLine("Probability is "+prob);
                        }
                        break;
                    default:
                        break;
                }
            } while (true);
        }

        private static void GraphOperations()
        {
            do
            {
                Graph graph = new Graph();

                Console.WriteLine("1: BFS" +
                    "\n2: DFS" +
                    "\n3: Time to inform news to the company" +
                    "\n4: Finish all courses" +
                    "\n5: Travel from source to target node");
                int choice = int.Parse(Console.ReadLine());

                int[][] adjacencyList =
                {
                    new int[]{1, 3},
                    new int[]{0 },
                    new int[]{3, 8},
                    new int[]{0, 4, 5, 2},
                    new int[]{3, 6},
                    new int[]{3 },
                    new int[]{4, 7 },
                    new int[]{6 },
                    new int[]{2 },
                };
                switch (choice)
                {
                    case 1:
                        graph.BFS(adjacencyList);
                        break;
                    case 2:
                        graph.DFS(adjacencyList);
                        break;
                    case 3:
                        int numberOfEmployees = 8;
                        int[] managersArray = { 2, 2, 4, 6, -1, 4, 4, 5 };
                        int[] informTimes = {0, 0, 4, 0, 7, 3, 6, 0 };
                        int headId = 4;
                        int timeToInform = graph.InformEmployees(numberOfEmployees, managersArray, informTimes, headId);
                        Console.WriteLine("Time to spread the news across the whole company is "+timeToInform);
                        break;
                    case 4:
                        List<KeyValuePair<int, int[,]>> list = new List<KeyValuePair<int, int[,]>>();
                        list.Add(new KeyValuePair<int, int[,]>(6, new int[,] //no cycle hence true
                        {
                            {1, 0},
                            {2, 1},
                            {2, 5},
                            {0, 3},
                            {4, 3},
                            {3, 5},
                            {4, 5},
                        }));
                        list.Add(new KeyValuePair<int, int[,]>(6, new int[,] //cyclic hence false
                        {
                            {1, 0},
                            {2, 1},
                            {5, 2},
                            {0, 3},
                            {4, 3},
                            {3, 5},
                            {4, 5},
                        }));
                        list.Add(new KeyValuePair<int, int[,]>(7, new int[,] //disconnected but doesn't matter one is cyclic hence false
                        {
                            {0, 3},
                            {1, 0},
                            {2, 1},
                            {4, 5},
                            {6, 4},
                            {5, 6},
                        }));
                        list.Add(new KeyValuePair<int, int[,]>(7, new int[,] //no cycle hence true
                        {
                            {1, 0},
                            {2, 1},
                            {2, 5},
                            {0, 3},
                            {4, 3},
                            {3, 5},
                            {4, 5},
                            {6, 5},
                            {4, 6}
                        }));
                        foreach (var keyValue in list)
                        {
                            graph = new Graph();
                            
                            //bool res = graph.CanTraverse(keyValue.Key, keyValue.Value);
                            bool res = graph.CanTraverseWithTopologicalSort(keyValue.Key, keyValue.Value);
                            
                            if (res)
                                Console.WriteLine("YES! We can traverse");
                            else
                                Console.WriteLine("NO! We cannot traverse");
                        }
                        break;
                    case 5:
                        List<KeyValuePair<int, KeyValuePair<int, int[][]>>> testCases = new List<KeyValuePair<int, KeyValuePair<int, int[][]>>>()
                        {
                            new KeyValuePair<int, KeyValuePair<int, int[][]>>(5, //number of nodes
                                
                                    new KeyValuePair<int, int[][]>(1, //starting node
                                        new int[][]{
                                            new int[]{1,2,9 },
                                            new int[]{1,4,2 },
                                            new int[]{2,5,1 },
                                            new int[]{4,2,4 },
                                            new int[]{4,5,6 },
                                            new int[]{3,2,3 },
                                            new int[]{5,3,7 },
                                            new int[]{3,1,5 },
                                        }
                                    )
                            ),
                            new KeyValuePair<int, KeyValuePair<int, int[][]>>(3, //number of nodes
                                new KeyValuePair<int, int[][]>(2, //starting node
                                        new int[][]{
                                            new int[]{2,3,4 },
                                        }
                                    )
                            ),
                            new KeyValuePair<int, KeyValuePair<int, int[][]>>(3, //number of nodes
                                new KeyValuePair<int, int[][]>(1, //starting node
                                        new int[][]{
                                            new int[]{1,2,8 },
                                            new int[]{3,1,3 },
                                        }
                                    )
                            ),
                            new KeyValuePair<int, KeyValuePair<int, int[][]>>(5, //number of nodes
                                new KeyValuePair<int, int[][]>(1, //starting node
                                        new int[][]{
                                            new int[]{1,2,9 },
                                            new int[]{1,4,2 },
                                            new int[]{4,2,-4 },
                                            new int[]{4,5,6 },
                                            new int[]{2,5,-3 },
                                            new int[]{5,3,7 },
                                            new int[]{3,2,3}
                                        }
                                    )
                            ),
                        };

                        foreach (var testCase in testCases)
                        {
                            graph = new Graph();
                            var numberOfNodes = testCase.Key;
                            var startingNode = testCase.Value.Key;
                            var timeArray = testCase.Value.Value;

                            //int timeToTravel = graph.CalculateTimeToTravelToAllNodes(numberOfNodes, startingNode, timeArray);
                            //int timeToTravel = graph.CalculateTimeToTravelToAllNodesUsingDijkstras(numberOfNodes, startingNode, timeArray);
                            int timeToTravel = graph.CalculateTimeToTravelToAllNodesUsingBellmanFord(numberOfNodes, startingNode, timeArray);

                            Console.WriteLine($"Total time to traverse all the nodes starting from node {startingNode} is {timeToTravel}");
                        }
                        break;
                    default:
                        break;
                }
            } while (true);
        }

        private static void MatrixOperations()
        {
            Matrix matrix = new Matrix(4,5);
            
            do
            {
                Console.WriteLine("1: DFS" +
                    "\n2: BFS" +
                    "\n3: No of Islands" +
                    "\n4: Minutes for oranges to rot" +
                    "\n5: Path to gates");
                int choice;
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Enter a valid choice");
                    continue;
                }
                Console.WriteLine();
                List<int> list;
                switch (choice)
                {
                    case 1:
                        list = matrix.DFS();
                        foreach (var item in list)
                        {
                            Console.Write(item+" ");
                        }
                        break;
                    case 2:
                        list = matrix.BFS(0,0);
                        foreach (var item in list)
                        {
                            Console.Write(item + " ");
                        }
                        break;
                    case 3:
                        int[][,] matrices = {
                          new int[4, 5]
                          {
                              {1,1,1,1,0,},
                              {1,1,0,1,0,},
                              {1,1,0,0,1,},
                              {0,0,0,1,1,}
                          },
                          new int[4,5]
                          {
                              {0,1,0,1,0 },
                              {1,0,1,0,1 },
                              {0,1,1,1,0 },
                              {1,0,1,0,1 }
                          }
                        }; 
                        
                        foreach (var mat in matrices)
                        {
                            Console.WriteLine($"The number of islands are { matrix.FindIslands(mat, 4, 5)}");
                        }
                        break;
                    case 4:
                        int[][,] mats = {
                          new int[4, 5]
                          {
                              {2,1,1,0,0,},
                              {1,1,1,0,0,},
                              {0,1,1,1,1,},
                              {0,1,0,0,1,}
                          },
                          new int[4,5]
                          {
                              {1,1,0,0,0 },
                              {2,1,0,0,0 },
                              {0,0,0,1,2 },
                              {0,1,0,0,1 }
                          },
                          new int[,]
                          {
                              { },
                              { }
                          },
                          new int[,]
                          {}
                        };

                        foreach (var mat in mats)
                        {
                            Console.WriteLine($"Minutes for all oranges to rot = { matrix.FindRotTime(mat, 4, 5)}");
                        }
                        
                        break;
                    case 5:
                        var inf = int.MaxValue;

                        int[][,] Mats = {
                            new int[4,4]
                            {
                                {inf, -1, 0, inf },
                                {inf, inf, inf, -1 },
                                {inf, -1, inf, -1 },
                                {0, -1, inf, inf },
                            },
                            new int[4,4]
                            {
                                {inf, -1, 0, inf },
                                {-1, inf, inf, -1 },
                                {inf, -1, inf, -1 },
                                {0, -1, inf, inf },
                            },
                            new int[,]
                            { },
                            new int[,]
                            { { } }
                        };

                        foreach (var mat in Mats)
                        {
                            matrix.FindStepsToNearestGate(mat, 4, 4);
                        }
                        break;
                    default:
                        break;
                }
                Console.WriteLine();
            } while (true);
        }

        private static void PriorityQueueOperations()
        {
            Console.WriteLine("1: Max Queue, 2: Min Queue");
            int c = int.Parse(Console.ReadLine());

            PriorityQueue pq;

            if (c == 1)
                pq = new PriorityQueue((x, y) => x >= y); //Max Queue
            else
                pq = new PriorityQueue((x, y) => x <= y); //Min Queue

            do
            {
                Console.WriteLine("1: Insert value into priority queue" +
                           "\n2: Peek" +
                           "\n3: Remove from priority queue" +
                           "\n4: Print heap");
                int choice;
                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the value to be inserted");
                        int val = int.Parse(Console.ReadLine());
                        Console.WriteLine("Added! New size is "+(pq.Push(val)));
                        break;
                    case 2:
                        Console.WriteLine("Peeked value is "+pq.Peek());
                        break;
                    case 3:
                        Console.WriteLine("Removed value is " + pq.Pop());
                        break;
                    case 4:
                        pq.Print();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid choice");
                        break;
                }
            } while (true);
        }

        private static void HeapOperations()
        {
            Heap heap = new Heap();
            do
            {
                Console.WriteLine("1: Insert value into heap" +
                    "\n2: Remove from heap" +
                    "\n3: Print heap");
                int choice;
                int.TryParse(Console.ReadLine(), out choice);
                
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the value to be inserted");
                        int val = int.Parse(Console.ReadLine());
                        if(heap.Add(val))
                            Console.WriteLine("Added successfully");
                        else
                            Console.WriteLine("Could not add");
                        break;
                    case 2:
                        Console.WriteLine("Removed value is " + heap.Remove());
                        break;
                    case 3:
                        heap.Print();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid choice");
                        break;
                }
            } while (true);
        }

        private static void BinarySearchTreeOperations()
        {
            do
            {
                Console.WriteLine("1: Check if its a valid binary search tree");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        for (int i = 1; i <= 7; i++)
                        {
                            BinarySearchTree bst = new BinarySearchTree(i);
                            if (bst.IsValidBinaryTree())
                                Console.Write("Valid");
                            else
                                Console.Write("Invalid");
                            bst.PrintListOfNodes();
                        }
                        break;
                    default:
                        break;
                }
            } while (true);
        }

        private static void BinaryTreeOperations()
        {
            BinaryTree bt = new BinaryTree();
           
            do
            {
                Console.WriteLine("1: Find height of tree" +
                    "\n2: Level Traverse the tree" +
                    "\n3: Breadth First Traversal" +
                    "\n4: Lever Traversal with BFS" +
                    "\n5: Looking at tree frrom right hand side" +
                    "\n6: Looking at tree frrom right hand side with BFS" +
                    "\n7: Count nodes in complete tree" +
                    "\n8: Count nodes in complete tree in Log N time");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        int height = bt.DepthFirstSearch(null);
                        Console.WriteLine("Height is "+height);
                        break;
                    case 2:
                        int[][] a = bt.LevelOrderTraversel();
                        foreach (var item in a)
                        {
                            foreach (var i in item)
                            {
                                Console.Write($"{i} ");
                            }
                            Console.WriteLine();
                        }
                        break;
                    case 3:
                        bt.BreadthFirstTraversal();
                        break;
                    case 4:
                        int[][] ar = bt.LevelTraversalWithBFS();
                        foreach (var item in ar)
                        {
                            foreach (var i in item)
                            {
                                Console.Write($"{i} ");
                            }
                            Console.WriteLine();
                        }
                        break;
                    case 5:
                        bt = new BinaryTree(2);
                        int[] rsa = bt.LookFromRightSide(null);
                        foreach (var item in rsa)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case 6:
                        bt = new BinaryTree(2);
                        int[] rs = bt.LookFromRightSideWithBFS();
                        foreach (var item in rs)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case 7:
                        Console.WriteLine("1 for DFS, 2 for BFS");
                        int ch = int.Parse(Console.ReadLine());
                        int[] lens = { 15, 8, 12 };
                        if (ch == 1)
                        {
                            foreach (var len in lens)
                            {
                                bt = new BinaryTree(3, len);
                                int c = bt.CountNodesInCompleteTree(null);
                                Console.WriteLine("Number of Nodes is " + c);
                            }
                        }
                        else
                        {
                            foreach (var len in lens)
                            {
                                bt = new BinaryTree(3, len);
                                int c = bt.CountNodesInCompleteTreeBFS();
                                Console.WriteLine("Number of Nodes is " + c);
                            }
                        }
                        break;
                    case 8:
                        int[] ls = { 15, 8, 12 };
                        foreach (var len in ls)
                        {
                            bt = new BinaryTree(3, len);
                            int c = bt.CountNodesInCompleteTreeInLogN();
                            Console.WriteLine("Number of Nodes is " + c);
                        }
                        break;
                    default:
                        break;
                }
            } while (true);
        }

        private static void RecursiveOperations()
        {
            Recursion R = new Recursion();
            do
            {
                Console.WriteLine("1: Factorial" +
                    "\n2: Tail Recursion Factorial" +
                    "\n3: QuickSort" +
                    "\n4: Kth Largest Element"+
                    "\n5: Return starting and ending indexes of a number in sorted array in LOG N time");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter number");
                        int n = int.Parse(Console.ReadLine());
                        Console.WriteLine("Factorial is "+R.Factorial(n));
                        break;
                    case 2:
                        Console.WriteLine("Enter number");
                        int num = int.Parse(Console.ReadLine());
                        Console.WriteLine("Factorial is "+ R.FactorialTailRecursion(num));
                        break;
                    case 3:
                        //int[] arr = { 10, 16, 8, 12, 15, 6, 3, 9, 5 };
                        int[] arr = { 5,4,3,2,1 };
                        Console.WriteLine("Before Recursion");
                        foreach (var item in arr)
                        {
                            Console.WriteLine(item);
                        }
                        try
                        {
                            R.QuickSort(arr, 0, arr.Length - 1);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        Console.WriteLine("After Recursion");
                        foreach (var item in arr)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case 4:
                        Dictionary<int, int[]> dictionary = new Dictionary<int, int[]>();
                        dictionary.Add(2, new int[] { 5, 3, 1, 6, 4, 2 });
                        dictionary.Add(4, new int[] { 2, 3, 1, 2, 4, 2 });
                        dictionary.Add(1, new int[] { 3 });
                        foreach (var key in dictionary.Keys)
                        {
                            int el = R.KthLargestElement(dictionary[key], key, 0, dictionary[key].Length - 1);
                            Console.WriteLine(key+"th largest element in array is "+el);
                        }
                        break;
                    case 5:
                        Dictionary<int, int[]> dictionary1 = new Dictionary<int, int[]>();
                        dictionary1.Add(5, new int[] { 1,3,3,5,5,5,8,9 });
                        dictionary1.Add(4, new int[] { 1,2,3,4,5,6 });
                        dictionary1.Add(9, new int[] { 1, 2, 3, 4, 5 });
                        dictionary1.Add(3, new int[] { });
                        foreach (var key in dictionary1.Keys)
                        {
                            int[] a = R.StartAndEndIndex(dictionary1[key], key);
                            Console.WriteLine($"Starting and ending indexes for {key} are: {a[0]} and {a[1]} ");
                        }
                        break;
                    default:
                        break;
                }
            } while (true);
        }

        private static void StackOperations()
        {
            do
            {
                Console.WriteLine("1: Check valid bracket expression" +
                    "\n2: Make valid" +
                    "\n3: Queue using stacks");
                int choice = int.Parse(Console.ReadLine());
                string[] expressions;
                switch (choice)
                {
                    case 1:
                        expressions = new string[]
                        {
                            "",
                            "{([])}",
                            "{([]",
                            "{[(]}",
                            "{[]()}"
                        };
                        foreach (var expr in expressions)
                        {
                            StackFunctions sf = new StackFunctions(expr.Length);
                            if (sf.IsValidParantheses(expr))
                            {
                                Console.WriteLine("Valid");
                            }
                            else
                            {
                                Console.WriteLine("Invalid");
                            }
                        }
                        break;
                    case 2:
                        expressions = new string[]
                        {
                            "a)bc(d)", //abc(d)
                            "(ab(c)d",  //(abc)d ab(c)d
                            "))((", //""
                        };
                        foreach (var expr in expressions)
                        {
                            StackFunctions sf = new StackFunctions(expr.Length);
                            string str = sf.MakeValid(expr);
                            Console.WriteLine($"{expr} --> {str}");
                        }
                        break;
                    case 3:
                        bool flag = true;
                        StackQueue sq = new StackQueue();
                        do
                        {
                            Console.WriteLine("1: Enqueue\n 2: Dequeue\n 3: Peek\n 4: Print\n 5: Exit");
                            int c = int.Parse(Console.ReadLine());
                            switch (c)
                            {
                                case 1:
                                    Console.WriteLine("Enter number to enqueue");
                                    int num = int.Parse(Console.ReadLine());
                                    sq.Enqueue(num);
                                    break;
                                case 2:
                                    int n = sq.Dequeue();
                                    Console.WriteLine("Dequeued item is "+n);
                                    break;
                                case 3:
                                    Console.WriteLine("Peek: "+sq.Peek());
                                    break;
                                case 4:
                                    sq.Print();
                                    break;
                                case 5:
                                    flag = false;
                                    break;
                                default:
                                    break;
                            }

                        } while (flag);
                        break;
                    default:
                        break;
                }
            } while (true);
        }

        private static void CycledLinkedListOperations()
        {
            do
            {
                Console.WriteLine();
                Console.WriteLine
                    (
                    "1: Detect Cycle\n" +
                    "2: Floyd's tortoise and hare\n" +
                    "3: trapping rainwater\n" +
                    "0: exit");
                int choice = int.Parse(Console.ReadLine());
                Dictionary<int, bool> dictionary = new Dictionary<int, bool>();
                
                dictionary.Add(1, false);
                dictionary.Add(2, false);
                dictionary.Add(3, true);
                dictionary.Add(4, false);
                dictionary.Add(5, false);
                dictionary.Add(6, false);
                dictionary.Add(7, false);
                dictionary.Add(8, false);


                CycleLinkedList.CreateLinkedList(dictionary);
                switch (choice)
                {
                    case 1:
                        CycleLinkedList.DetectCycle();
                        break;
                    case 2:
                        CycleLinkedList.TortoiseAndHare();
                        break;
                    default:
                        break;
                }

                CycleLinkedList.PrintLinkedList();
            } while (true);
        }

        private static void DoublyLinkedListOperations()
        {
            do
            {
                Console.WriteLine();
                Console.WriteLine
                    (
                    "1: Reverse Linked List\n" +
                    "2: Find Linked List m to n\n" +
                    "3: trapping rainwater\n" +
                    "0: exit");
                int choice = int.Parse(Console.ReadLine());
                Dictionary<int, object> dictionary1 = new Dictionary<int, object>();
                Dictionary<int, object> dictionary11 = new Dictionary<int, object>();
                Dictionary<int, object> dictionary12 = new Dictionary<int, object>();
                Dictionary<int, object> dictionary21 = new Dictionary<int, object>();

                dictionary12.Add(10, null);
                dictionary12.Add(11, null);

                dictionary11.Add(7, null);
                dictionary11.Add(8, dictionary12);
                dictionary11.Add(9, null);

                dictionary21.Add(12, null);
                dictionary21.Add(13, null);

                dictionary1.Add(1, null);
                dictionary1.Add(2, dictionary11);
                dictionary1.Add(3, null);
                dictionary1.Add(4, null);
                dictionary1.Add(5, dictionary21);
                dictionary1.Add(6, null);

                DoublyLinkedList.CreateLinkedList(dictionary1, null);
                DoublyLinkedList.Print(null);
                DoublyLinkedList.FlattenLinkedList(null,null);
                DoublyLinkedList.PrintAgain();

            } while (true);
        }

        private static void LinkedListOperations()
        {
            do
            {
                Console.WriteLine();
                Console.WriteLine
                    (
                    "1: Reverse Linked List\n" +
                    "2: Find Linked List m to n\n" +
                    "0: exit");
                int choice = int.Parse(Console.ReadLine());
                LinkedList.CreateLinkedList(new int[] { 1, 2, 3, 4, 5 });
                Console.WriteLine("Before Operation");
                LinkedList.PrintLinkedList();
                switch (choice)
                {
                    case 1:
                        LinkedList.ReverseLinkedList();
                        break;
                    default:
                        break;
                    case 2:
                        int[][] pairs = new int[][] {
                            new int[]{2, 4 },
                            new int[]{1, 5 },
                            new int[]{1, 1},
                            new int[]{0, 0} 
                        };
                        foreach (var pair in pairs)
                        {
                            LinkedList.CreateLinkedList(new int[] { 1, 2, 3, 4, 5 });
                            LinkedList.ReverseLinkedListPartially(pair[0], pair[1]);
                            Console.WriteLine("-------------------------");
                            Console.WriteLine($"For {pair[0]} to {pair[1]}");
                            LinkedList.PrintLinkedList();
                        }
                        break;
                        
                }
                //Console.WriteLine("After Operation");
                //LinkedList.PrintLinkedList();
            } while (true);
        }

        private static void ArrayOperations()
        {
            do
            {
                Console.WriteLine();
                Console.WriteLine
                    ("1: Find indices of two numbers in array that equal a given sum\n" +
                    "2: Find area of bucket with most water using array values as height\n"+
                    "3: trapping rainwater\n" +
                    "0: exit");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        int[] arr = { 1, 3, 7, 9, 2 };
                        int sum = 11;
                        //int[] result = ArrayFunctions.FindTwoSums(arr, sum);
                        int[] result = ArrayFunctions.FindTwoSumsOptimized(arr, sum);
                        if (result == null)
                            Console.WriteLine("No solution found");
                        else
                            foreach (var item in result)
                            {
                                Console.Write(item+" ");
                            }
                        break;
                    case 2:
                        //int[] heights = { 7, 1, 2, 3, 9 };
                        //int maxArea = ArrayFunctions.GetMaxWaterContainer(heights);
                        int[] heights = { 4, 8, 1, 2, 3, 9 };
                        int maxArea = ArrayFunctions.GetMaxWaterContainerOptimized(heights);
                        Console.WriteLine($"Max water container area is {maxArea}");
                        break;
                    case 3:
                        int[][] arrayOfArrayBlocks = new int[][]
                        {
                            new int[]{ 0, 1, 0, 2, 1 , 0, 3, 1, 0, 1, 2 },//8
                            new int[]{ },//0
                            new int[]{0 },//0
                            new int[]{3,4,3 },//0
                            new int[]{2,0,2 },//2
                            new int[]{ 3,0,2,0,4},//7
                            new int[]{ 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 },//6
                            new int[]{ 4,2,0,3,2,5 },//9
                            new int[]{ 5,5,1,7,1,1,5,2,7,6}//23
                        };
                        foreach (var arrayBlock in arrayOfArrayBlocks)
                        {
                            //int rainWater = ArrayFunctions.CollectRainWaterAgain(arrayBlock);
                            //int rainWater = ArrayFunctions.CollectRainWater(arrayBlock);
                            int rainWater = ArrayFunctions.CollectRainWaterOptimised(arrayBlock);
                            Console.WriteLine(rainWater);
                        }
                        break;
                    default:
                        break;
                }
            } while (true);
        }

        private static void StringOperations()
        {
            do
            {
                Console.WriteLine();
                Console.WriteLine
                    ("1: String equality with # as backspace\n" +
                    "2: Substring no duplicate\n" +
                    "3: Simple Palindrome\n" +
                    "4: Almost Palindrome\n" +
                    "0: exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        string[][] strings = new string[][]
                        {
                            new string[]{"ab#z","az#z" },
                            new string[]{"abc#d","acc#c" },
                            new string[]{"x#y#z#","a#" },
                            new string[]{"a###b","b" },
                            new string[]{"Ab#z","ab#z" },
                            new string[]{"y#fo##f","y#f#o##f"},
                            new string[]{"bxj##tw","bxj###tw"}
                        };
                        foreach (var str in strings)
                        {
                            //bool res = StringFunctions.CompareStrings(str[0], str[1]);
                            //bool res = StringFunctions.CompareStringsWithStringBuilder(str[0], str[1]);
                            //bool res = StringFunctions.CompareStringsUsingStacks(str[0], str[1]);
                            bool res = StringFunctions.CompareStringsOptimized(str[0], str[1]);
                            Console.WriteLine(res);
                        }
                        break;
                    case 2:
                        string[] arr = new string[]
                        {
                            "abccabb",
                            "ccc",
                            "",
                            "abcbda",
                            "ygyjchvdreekwrro",
                            "axropfaujpkfgeqohbtvqpzekndgikpkjhyzmbvxqfdyjtnsvinnznujczrmlhwvqxweyr",
                            "pwwkew",
                            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCD",
                            " "
                        };
                        foreach (var s in arr)
                        {
                            Stopwatch stopwatch = new Stopwatch();

                            //stopwatch.Start();
                            //int l = StringFunctions.GetSubstringNoDuplicate(s);
                            //int l = StringFunctions.GetSubstringNoDuplicateLengthFast(s);
                            int l = StringFunctions.GetSubstringNoDuplicateLengthSlidingWindow(s);
                            //stopwatch.Stop();
                            //Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
                            //string l = StringFunctions.GetSubstringNoDuplicateString(s);
                            Console.WriteLine(l) ;
                        }
                        break;
                    case 3:
                        string[] pals = new string[]
                        {
                            "aabaa",
                            "aabbaa",
                            "abc",
                            "a",
                            "",
                            "A man, a plan, a canal: Panama",
                            "race a car"
                        };
                        foreach (var p in pals)
                        {
                            if (StringFunctions.IsValidPalindrome(p))
                            {
                                Console.WriteLine($"{p} is palindrome");
                            }
                            else
                            {
                                Console.WriteLine($"{p} is not palindrome");
                            }
                        }
                        break;
                    case 4:
                        string[] almostPals = new string[]
                        {
                            "raceacar",
                            "abccdba",
                            "abcdefdba", //false
                            "",
                            "a",
                            "ab",
                            "madam"
                        };
                        foreach (var p in almostPals)
                        {
                            if (StringFunctions.AlmostPalindrome(p))
                            {
                                Console.WriteLine($"{p} is an almost palindrome");
                            }
                            else
                            {
                                Console.WriteLine($"{p} is not an almost palindrome");
                            }
                        }
                        break;
                    default:
                        break;
                }
            } while (true);
        }
    }
}
