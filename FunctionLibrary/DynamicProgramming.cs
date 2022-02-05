using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionLibrary
{
    public class DynamicProgramming
    {
        int[] memoizedCosts;
        int count = 0;

        private void InitialiseMemoized(int len)
        {
            memoizedCosts = new int[len];

            for (int i = 0; i < len; i++)
            {
                memoizedCosts[i] = int.MaxValue;
            }
        }
        public int MinimumCostOfClimbingStairs(int[] costs, int currentIndex=0)
        {

            int answer = int.MaxValue;

            //InitialiseMemoized(costs.Length);
            //answer = CalculateMinimumCostBottomUpRecursive(costs);
            //Console.WriteLine("Traveresed "+count+" times for length "+costs.Length);
            //count = 0;
            //InitialiseMemoized(costs.Length);
            //answer = CalculateMinimumCostTopDown(costs, costs.Length);
            //Console.WriteLine("Traveresed " + count + " times for length " + costs.Length);
            //count = 0;
            //InitialiseMemoized(costs.Length);
            //answer = CalculateMinimumCostBottomUpIterative(costs);
            InitialiseMemoized(costs.Length);
            answer = CalculateMinimumCostBottomUpIterativeSpaceoptimized(costs);
            //Console.WriteLine("Traveresed " + count + " times for length " + costs.Length);

            return answer;

        }

        private int CalculateMinimumCostBottomUpIterativeSpaceoptimized(int[] costs)
        {
            int memoizedOne = costs[0];
            int memoizedTwo = costs[1];

            for (int i = 2; i < costs.Length; i++)
            {
                count++;
                int currentCost = costs[i] + Math.Min(memoizedOne, memoizedTwo);
                memoizedOne = memoizedTwo; //because of n-1,n-2 releation
                memoizedTwo = currentCost; //because of n-1,n-2 releation
            }

            return Math.Min(memoizedOne, memoizedTwo);
        }

        private int CalculateMinimumCostBottomUpIterative(int[] costs)
        {
            memoizedCosts[0] = costs[0];
            memoizedCosts[1] = costs[1];

            for (int i = 2; i < costs.Length; i++)
            {
                count++;
                memoizedCosts[i] = costs[i] + Math.Min(memoizedCosts[i - 1], memoizedCosts[i - 2]);
            }

            return Math.Min(memoizedCosts[costs.Length - 1], memoizedCosts[costs.Length - 2]);
        }


        private int CalculateMinimumCostBottomUpRecursive(int[] costs, int currentIndex=-1)
        {
            count++;
            if (currentIndex == costs.Length)
                return 0;
            else if (currentIndex > costs.Length)
                return int.MaxValue;
            else if (currentIndex == -1 || memoizedCosts[currentIndex] == int.MaxValue)
            {
                int costToReachIfTookOneStep = CalculateMinimumCostBottomUpRecursive(costs, currentIndex + 1);
                int costToReachIfTookTwoSteps = CalculateMinimumCostBottomUpRecursive(costs, currentIndex + 2);
                int minimumCostForThisIndex = Math.Min(costToReachIfTookOneStep, costToReachIfTookTwoSteps);
                
                if(currentIndex != -1)
                    memoizedCosts[currentIndex] = costs[currentIndex] + minimumCostForThisIndex;
            }

            return currentIndex == -1 ? Math.Min(memoizedCosts[0], memoizedCosts[1]) : memoizedCosts[currentIndex];
        }

        private int CalculateMinimumCostTopDown(int[] costs, int currentIndex)
        {
            count++;
            int costForOneStepDown = int.MaxValue;
            int costForTwoStepsDown = int.MaxValue;

            if (currentIndex != costs.Length && memoizedCosts[currentIndex] != int.MaxValue)
                return memoizedCosts[currentIndex];

            if(currentIndex == 0 || currentIndex == 1)
            {
                memoizedCosts[currentIndex] = costs[currentIndex];
                return memoizedCosts[currentIndex];
            }

            costForOneStepDown = CalculateMinimumCostTopDown(costs, currentIndex - 1);
            costForTwoStepsDown = CalculateMinimumCostTopDown(costs, currentIndex - 2);
            
            if(currentIndex != costs.Length)
                memoizedCosts[currentIndex] = costs[currentIndex] + Math.Min(costForOneStepDown, costForTwoStepsDown);
            
            return currentIndex == costs.Length? Math.Min(memoizedCosts[costs.Length - 1], memoizedCosts[costs.Length - 2]) : memoizedCosts[currentIndex];
        }

        Dictionary<KeyValuePair<int, int>, Dictionary<int, decimal>> memoizedProbability = new Dictionary<KeyValuePair<int, int>, Dictionary<int, decimal>>(); //row,col,level,probability
        int totalMovesAllowed = 0;
        public decimal FindKnightProbability(int n, int k, int row, int col)
        {
            if (k == 0)
                return 1;
            if (n == 0)
                return 0;
            totalMovesAllowed = k;
            //decimal prob = GetAllPossibleMoves(n, row, col, 1);
            //decimal prob = GetAllMovesAnotherWay(n, row, col, 1);
            //decimal prob = GetAllMovesBottomUpWithKAsDrivingFactor(n, row, col);
            decimal prob = GetAllMovesBottomUpWithKAsDrivingFactorSpaceOptimized(n, row, col);

            return prob;
        }

        private decimal GetAllPossibleMoves(int n, int row, int col, int currentNumberOfMoves)
        {
            KeyValuePair<int, int> rowcol = new KeyValuePair<int, int>(row, col);

            if (memoizedProbability.ContainsKey(rowcol) && memoizedProbability[rowcol].ContainsKey(currentNumberOfMoves))
                return memoizedProbability[rowcol][currentNumberOfMoves];

            decimal prob = 0.0M;
            decimal newProbs = 0;
            if (row + 2 < n && col + 1 < n)
            {                                                                                           
                KeyValuePair<int, int> newPos = new KeyValuePair<int, int>(row + 2, col + 1);

                if (currentNumberOfMoves + 1 <= totalMovesAllowed)
                {
                    decimal newProb = GetAllPossibleMoves(n, row + 2, col + 1, currentNumberOfMoves+1);
                    newProbs += newProb;
                }
                else
                {
                    prob++;
                }
            }
            if (row + 2 < n && col - 1 >= 0)
            { 
                var newPos = new KeyValuePair<int, int>(row + 2, col - 1);
                if (currentNumberOfMoves + 1 <= totalMovesAllowed)
                {
                    decimal newProb = GetAllPossibleMoves(n, row + 2, col - 1, currentNumberOfMoves + 1);
                    newProbs += newProb;
                }
                else
                {
                    prob++;
                }

            }
            if (row - 2 >= 0 && col + 1 < n)
            {
                var newPos = new KeyValuePair<int, int>(row - 2, col + 1);
                if (currentNumberOfMoves + 1 <= totalMovesAllowed)
                {
                    decimal newProb = GetAllPossibleMoves(n, row - 2, col + 1, currentNumberOfMoves + 1);
                    newProbs += newProb;
                }
                else
                {
                    prob++;
                }
            }
            if (row - 2 >= 0 && col - 1 >= 0)
            {
                var newPos = new KeyValuePair<int, int>(row - 2, col - 1);
                if (currentNumberOfMoves + 1 <= totalMovesAllowed)
                {
                    decimal newProb = GetAllPossibleMoves(n, row - 2, col - 1, currentNumberOfMoves + 1);
                    newProbs += newProb;
                }
                else
                {
                    prob++;
                }
            }
            if (row + 1 < n && col + 2 < n )
            {
                var newPos = new KeyValuePair<int, int>(row + 1, col + 2); 
                if (currentNumberOfMoves + 1 <= totalMovesAllowed)
                {
                    decimal newProb = GetAllPossibleMoves(n, row + 1, col + 2, currentNumberOfMoves + 1);
                    newProbs += newProb;
                }
                else
                {
                    prob++;
                }
            }
            if (row - 1 >= 0 && col + 2 < n)
            {
                var newPos = new KeyValuePair<int, int>(row - 1, col + 2); 
                if (currentNumberOfMoves + 1 <= totalMovesAllowed)
                {
                    decimal newProb = GetAllPossibleMoves(n, row - 1, col + 2, currentNumberOfMoves + 1);
                    newProbs += newProb;
                }
                else
                {
                    prob++;
                }
            }
            if (row + 1 < n && col - 2 >= 0)
            {
                var newPos = new KeyValuePair<int, int>(row + 1, col - 2);
                if (currentNumberOfMoves + 1 <= totalMovesAllowed)
                {
                    decimal newProb = GetAllPossibleMoves(n, row + 1, col - 2, currentNumberOfMoves + 1);
                    newProbs += newProb;
                }
                else
                {
                    prob++;
                }
            }
            if (row - 1 >= 0 && col - 2 >= 0)
            {
                var newPos = new KeyValuePair<int, int>(row - 1, col - 2);
                if (currentNumberOfMoves + 1 <= totalMovesAllowed)
                {
                    decimal newProb = GetAllPossibleMoves(n, row - 1, col - 2, currentNumberOfMoves + 1);
                    newProbs += newProb;
                }
                else
                {
                    prob++;
                }
            }

            decimal totalProb = (prob + newProbs) / 8.0M;
            
            if (!memoizedProbability.ContainsKey(rowcol))
            {
                var d = new Dictionary<int, decimal>();
                d.Add(currentNumberOfMoves, totalProb);

                memoizedProbability.Add(rowcol, d);
            }else if (!memoizedProbability[rowcol].ContainsKey(currentNumberOfMoves))
            {
                memoizedProbability[rowcol].Add(currentNumberOfMoves, totalProb);
            }
                

            Console.WriteLine($"For {row},{col} probability for {currentNumberOfMoves}th move is {totalProb}");
            return totalProb;
        }
        
        int[,] moveArray = {
            {2,1 },
            {2,-1 },
            {-2,1 },
            {-2,-1 },
            {1,2 },
            {-1,2 },
            {1,-2 },
            {-1,-2 },
        };
        Dictionary<string, decimal> memoizedProb = new Dictionary<string, decimal>();
        public decimal GetAllMovesAnotherWay(int n, int row, int col, int currentNumberOfMoves)
        {
            if (row < 0 || row >= n || col < 0 || col >= n)
                return 0.0M;

            if (memoizedProb.ContainsKey($"{row},{col},{currentNumberOfMoves}"))
                return memoizedProb[$"{row},{col},{currentNumberOfMoves}"];

            if (currentNumberOfMoves > totalMovesAllowed)
                return 1.0M;
            
            decimal totalProb = 0;
            for (int i = 0; i < moveArray.GetLength(0); i++)
            {
                totalProb += GetAllMovesAnotherWay(n, row + moveArray[i, 0], col + moveArray[i, 1], currentNumberOfMoves + 1)/8.0M;
            }

            memoizedProb.Add($"{row},{col},{currentNumberOfMoves}", totalProb);

            Console.WriteLine($"For {row},{col} probability for {currentNumberOfMoves}th move is {totalProb}");
            return totalProb;
        }

        public decimal GetAllMovesBottomUpWithKAsDrivingFactor(int n, int row, int col)
        {
            decimal[,,] chessBoard = new decimal[totalMovesAllowed+1, n, n];

            chessBoard[0, row, col] = 1.0M;

            for (int k = 1; k <= totalMovesAllowed; k++)
            {
                for (int x = 0; x < n; x++)
                {
                    for (int y = 0; y < n; y++)
                    {
                        for (int q = 0; q < moveArray.GetLength(0); q++)
                        {
                            int newX = x + moveArray[q, 0];
                            int newY = y + moveArray[q, 1];
                            if (CanMove(n,newX,newY))
                            {
                                decimal addVal = chessBoard[k-1,newX, newY];
                                chessBoard[k, x, y] += (addVal / 8.0M);
                            }
                        }
                    }
                }
            }

            decimal prob = 0.0M;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    prob += chessBoard[totalMovesAllowed, i, j];
                }
            }

            return prob;
        }

        public decimal GetAllMovesBottomUpWithKAsDrivingFactorSpaceOptimized(int n, int row, int col)
        {
            var chessBoardPreviousState = new decimal[n, n];
            var chessBoardCurrentState = new decimal[n, n];

            chessBoardPreviousState[row, col] = 1.0M;

            for (int k = 1; k <= totalMovesAllowed; k++)
            {
                for (int x = 0; x < n; x++)
                {
                    for (int y = 0; y < n; y++)
                    {
                        for (int q = 0; q < moveArray.GetLength(0); q++)
                        {
                            int newX = x + moveArray[q, 0];
                            int newY = y + moveArray[q, 1];
                            if (CanMove(n, newX, newY))
                            {
                                decimal addVal = chessBoardPreviousState[newX, newY];
                                chessBoardCurrentState[x, y] += (addVal / 8.0M);
                            }
                        }
                    }
                }
                chessBoardPreviousState = chessBoardCurrentState;
                chessBoardCurrentState = new decimal[n, n];
            }

            decimal prob = 0.0M;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    prob += chessBoardPreviousState[i, j];
                }
            }

            return prob;
        }

        private bool CanMove(int n, int currentRow, int currentCol)
        {
            if (currentRow >= n || currentRow < 0 || currentCol >= n || currentCol < 0)
                return false;
            return true;
        }
    }
}
