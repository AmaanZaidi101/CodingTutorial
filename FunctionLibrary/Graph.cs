using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionLibrary
{
    public class Graph
    {
        Dictionary<int, bool> seen = new Dictionary<int, bool>();


        List<int> answerList = new List<int>();
        public void BFS(int[][] adjacenyList)
        {
            if (adjacenyList.Length <= 0)
                return;
            
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(0);
            seen.Add(0, true);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                answerList.Add(vertex);
                
                for (int i = 0; i < adjacenyList[vertex].Length; i++)
                {
                    if (!seen.ContainsKey(adjacenyList[vertex][i]))
                    {
                        queue.Enqueue(adjacenyList[vertex][i]);
                        seen.Add(adjacenyList[vertex][i], true);
                    }
                }
            }

            PrintAnswer(answerList);
        }

        public void DFS(int[][] adjacencyList, int index = 0)
        {
            if (!seen.ContainsKey(index))
            {
                seen.Add(index, true);
                answerList.Add(index);
            }

            for (int i = 0; i < adjacencyList[index].Length; i++)
            {
                if(!seen.ContainsKey(adjacencyList[index][i]))
                    DFS(adjacencyList, adjacencyList[index][i]);
            }
            

            if (index == 0)
                PrintAnswer(answerList);
        }

        Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>();
        public int InformEmployees(int employeeCount, int[] managersArray, int[] informTimes, int headId)
        {
            ConvertToAdjacencyList(managersArray);
            //PrintAdjacencyListDictionary();
            return InformSubordinates(informTimes, headId);
        }

        private int InformSubordinates(int[] informTimes, int managerId)
        {
            int thisManagerTime = informTimes[managerId];
            int maxTimeForSubOrdinates = 0;

            if (!adjList.ContainsKey(managerId))
                return 0;

            for (int i = 0; i < adjList[managerId].Count; i++)
            {
                int currentManagerSubordinateTime = InformSubordinates(informTimes, adjList[managerId][i]);
                if (currentManagerSubordinateTime > maxTimeForSubOrdinates)
                    maxTimeForSubOrdinates = currentManagerSubordinateTime;
            }

            return thisManagerTime + maxTimeForSubOrdinates;
        }

        private void ConvertToAdjacencyList(int[] managersArray)
        {
            for (int i = 0; i < managersArray.Length; i++)
            {
                if (adjList.ContainsKey(managersArray[i]))
                {
                    adjList[managersArray[i]].Add(i);
                }
                else
                {
                    adjList[managersArray[i]] = new List<int>();
                    adjList[managersArray[i]].Add(i);
                }
            }

        }

        List<int> nodeNotTraversed = new List<int>(); //need this for disconnected graph
        public bool CanTraverse(int numberOfElements, int[,] prerequisites)
        {
            CreateAdjacencyListForCanTraverse(prerequisites);
            //PrintAdjacencyListDictionary();
            if (adjList.Keys.Count == 0)
                return false;

            for (int i = 0; i < numberOfElements; i++)
            {
                nodeNotTraversed.Add(i);
            }

            bool result = false;
            while(nodeNotTraversed.Count > 0)
            {
                result = TraverseWithDFS(nodeNotTraversed.First());
                if (!result)
                    return result;
            }

            return result;
        }

        private bool TraverseWithDFS(int vertex)
        {
            nodeNotTraversed.Remove(vertex);

            if (!adjList.ContainsKey(vertex))
                return true;

            if (seen.ContainsKey(vertex) && seen[vertex])
            {
                //Console.WriteLine("Found cycle at node " + vertex);
                return false;
            }

            seen.Add(vertex, true);
            //Traverse connected nodes with DFS
            for (int i = 0; i < adjList[vertex].Count; i++)
            {
                bool res = TraverseWithDFS(adjList[vertex][i]);
                if (!res)
                    return false;
            }

            seen.Remove(vertex);
            return true;
        }

        private void CreateAdjacencyListForCanTraverse(int[,] prerequisites)
        {
            for (int i = 0; i < prerequisites.GetLength(0); i++)
            {
                if (adjList.ContainsKey(prerequisites[i, 1]))
                    adjList[prerequisites[i, 1]].Add(prerequisites[i, 0]);
                else
                {
                    adjList[prerequisites[i, 1]] = new List<int>();
                    adjList[prerequisites[i, 1]].Add(prerequisites[i, 0]);
                }
            }
        }
        
        public bool CanTraverseWithTopologicalSort(int numberOfElements, int[,] prerequisites)
        {

            var indegrees = CreateAdjacencyListForCanTraverseWithIndegrees(numberOfElements, prerequisites);
            //PrintAdjacencyListDictionary();
            //Console.WriteLine("Indegrees");
            //PrintIndegrees(indegrees);

            int prevCount;

            do
            {
                prevCount = adjList.Count;
                for (int index = 0; index < indegrees.Length; index++)
                {
                    if (indegrees[index] == 0 && adjList.ContainsKey(index))
                    {
                        //Console.WriteLine(index + " has indegree of zero. Removing it.");
                        var nodesWhoseIndegreeWillBeChanged = adjList[index];
                        adjList.Remove(index);

                        foreach (var node in nodesWhoseIndegreeWillBeChanged)
                        {
                            indegrees[node]--;
                        }
                        //Console.WriteLine("New Indegrees");
                        //PrintIndegrees(indegrees);
                    }
                }
                
            } while (adjList.Count < prevCount);

            return adjList.Count == 0;
        }

        private int[] CreateAdjacencyListForCanTraverseWithIndegrees(int numberOfElements, int[,] prerequisites)
        {
            int[] indegrees = new int[numberOfElements];

            for (int i = 0; i < prerequisites.GetLength(0); i++)
            {
                if (adjList.ContainsKey(prerequisites[i, 1]))
                {
                    adjList[prerequisites[i, 1]].Add(prerequisites[i, 0]);
                }
                else
                {
                    adjList[prerequisites[i, 1]] = new List<int>();
                    adjList[prerequisites[i, 1]].Add(prerequisites[i, 0]);
                }
                indegrees[prerequisites[i, 0]]++;
            }

            return indegrees;
        }

        Dictionary<int, List<KeyValuePair<int, int>>> WeightedAdjList = new Dictionary<int, List<KeyValuePair<int, int>>>();
        bool[] seenNodes;
        int[] currentMinTimes;
        public int CalculateTimeToTravelToAllNodes(int numberOfNodes, int startingNode, int[][] timeArray)
        {
            seenNodes = new bool[numberOfNodes];
            currentMinTimes = new int[numberOfNodes];

            for (int i = 0; i < numberOfNodes; i++)
            {
                currentMinTimes[i] = int.MaxValue;
            }

            CreateAdjacencyListForWeightedTraversal(timeArray);
            TraverseToNodes(startingNode);
            return seenNodes.Any(x => x == false)? -1 : currentMinTimes.Max();
        }
        /// <summary>
        /// We did this with DFS, here we are going through neighbouring nodes as they appear and then backtracking
        /// </summary>
        /// <param name="currentNode"></param>
        /// <param name="timeToThisNode"></param>
        private void TraverseToNodes(int currentNode, int timeToThisNode = 0)
        {
            seenNodes[currentNode - 1] = true;
            if (timeToThisNode < currentMinTimes[currentNode-1])
                currentMinTimes[currentNode-1] = timeToThisNode;
            else
                return;
            if (WeightedAdjList.ContainsKey(currentNode))
            {
                for (int i = 0; i < WeightedAdjList[currentNode].Count; i++)
                {
                    int nextNode = WeightedAdjList[currentNode][i].Key;
                    int timeToNextNode = WeightedAdjList[currentNode][i].Value;

                    TraverseToNodes(nextNode, timeToThisNode + timeToNextNode);
                }
            }
        }

        Dictionary<int, int> minTimes = new Dictionary<int, int>();
        /// <summary>
        /// Dijkstra's Algorithm is Basically BFS but with priority queue so we take the min distance first
        /// </summary>
        /// <param name="numberOfNodes"></param>
        /// <param name="startingNode"></param>
        /// <param name="timeArray"></param>
        /// <returns></returns>
        public int CalculateTimeToTravelToAllNodesUsingDijkstras(int numberOfNodes, int startingNode, int[][] timeArray)
        {
            CreateAdjacencyListForWeightedTraversal(timeArray);

            
            for (int i = 1; i <= numberOfNodes; i++)
            {
                minTimes.Add(i, int.MaxValue);
            }
            minTimes[startingNode] = 0;

            PriorityQueue heap = new PriorityQueue((x, y) => minTimes[x] < minTimes[y]);
            heap.Push(startingNode);

            while (!heap.IsEmpty())
            {
                int currentNode = heap.Pop();

                if (!WeightedAdjList.ContainsKey(currentNode))
                    continue;

                var adjacentNodes = WeightedAdjList[currentNode];

                for (int i = 0; i < adjacentNodes.Count; i++)
                {
                    int neighbouringNode = adjacentNodes[i].Key;
                    int timeToReachNeighbour = adjacentNodes[i].Value;

                    if (minTimes[currentNode] + timeToReachNeighbour < minTimes[neighbouringNode])
                    {
                        minTimes[neighbouringNode] = minTimes[currentNode] + timeToReachNeighbour;
                        heap.Push(neighbouringNode);
                    }
                }
            }

            return minTimes.Values.Max() == int.MaxValue ? -1 : minTimes.Values.Max();
        }

        int[] memoizedTime;
        /// <summary>
        /// Only Bellman Ford can deal with negative weights. It cannot deal with negative cycles tho so it is helpful
        /// in recognising negative cycles. If the outer loop goes past n-1 steps and anyChange flag keeps changing
        /// then we know we have a negative cycle
        /// </summary>
        /// <param name="numberOfNodes"></param>
        /// <param name="startingNode"></param>
        /// <param name="timeArray"></param>
        /// <returns></returns>
        public int CalculateTimeToTravelToAllNodesUsingBellmanFord(int numberOfNodes, int startingNode, int[][] timeArray)
        {
            CreateAdjacencyListForWeightedTraversal(timeArray);

            memoizedTime = new int[numberOfNodes];
            for (int i = 0; i < numberOfNodes; i++)
            {
                memoizedTime[i] = int.MaxValue;
            }

            memoizedTime[startingNode-1] = 0; //nodes are 1 indexed but our memoized array is 0 indexed

            for (int i = 0; i < numberOfNodes; i++)
            {
                bool anyChange = false;

                for (int j = 0; j < timeArray.Length; j++)
                {
                    int from = timeArray[j][0] - 1; //it is 1 indexed but our memoized array is 0 indexed
                    int to = timeArray[j][1] - 1; //it is 1 indexed but our memoized array is 0 indexed
                    int timeToReach = timeArray[j][2];

                    if (memoizedTime[from] != int.MaxValue && memoizedTime[from] + timeToReach < memoizedTime[to])
                    {
                        memoizedTime[to] = memoizedTime[from] + timeToReach;
                        anyChange = true; 
                    }
                }
                if (!anyChange)
                    break;
            }
            return memoizedTime.Max() == int.MaxValue? -1: memoizedTime.Max();
        }

        private void CreateAdjacencyListForWeightedTraversal(int[][] timeArray)
        {
            for (int i = 0; i < timeArray.Length; i++)
            {
                if (WeightedAdjList.ContainsKey(timeArray[i][0]))
                {
                    WeightedAdjList[timeArray[i][0]].Add(new KeyValuePair<int, int>(timeArray[i][1], timeArray[i][2])); //from.Add(to,weight)
                }
                else
                {
                    WeightedAdjList[timeArray[i][0]] = new List<KeyValuePair<int, int>>();
                    WeightedAdjList[timeArray[i][0]].Add(new KeyValuePair<int, int>(timeArray[i][1], timeArray[i][2])); //from.Add(to,weight)
                }
            }
        }

        private void PrintIndegrees(int[] indegrees)
        {
            for (int i = 0; i < indegrees.Length; i++)
            {
                Console.WriteLine($"{i}: {indegrees[i]}");
            }
        }

        private void PrintAnswer(List<int> answer)
        {
            foreach (var ans in answer)
            {
                Console.Write(ans + " ");
            }
            Console.WriteLine();
        }

        private void PrintAdjacencyListDictionary()
        {
            Console.WriteLine("Manager\tEmployees");
            foreach (var key in adjList.Keys)
            {
                Console.Write(key+":\t");
                foreach (var value in adjList[key])
                {
                    Console.Write(value+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
