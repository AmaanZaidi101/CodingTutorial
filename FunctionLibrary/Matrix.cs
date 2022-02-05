using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionLibrary
{
    public class Matrix
    {
        private int[,] Mat;
        int Row,Col;
        public Matrix(int row, int col)
        {

            Row = row;
            Col = col; 
            int num = 1;
            Mat = new int[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Mat[i, j] = num++;
                }
            }
        }

        Dictionary<KeyValuePair<int,int>, bool> dictionary = new Dictionary<KeyValuePair<int,int>, bool>();
        List<int> list = new List<int>();
        public List<int> DFS()
        {
            int row = 0, col = 0;
            while(list.Count < Row * Col)
            {
                list.Add(Mat[row, col]);
                dictionary.Add(new KeyValuePair<int, int>(row, col), true);
                if (CanAdd(row - 1, col))
                    row--;
                else if (CanAdd(row, col + 1))
                    col++;
                else if (CanAdd(row + 1, col))
                    row++;
                else if (CanAdd(row, col - 1))
                    col--;
                else
                    break;
            }
            return list;
        }

        public List<int> BFS(int row=0, int col=0)
        {
            Queue<KeyValuePair<int,int>> queue = new Queue<KeyValuePair<int,int>>();
            if (CanAdd(row, col))
            {
                list.Add(Mat[row, col]);
                queue.Enqueue(new KeyValuePair<int, int>(row, col));
                dictionary.Add(new KeyValuePair<int, int>(row, col), true);
            }
            while (queue.Count > 0)
            {
                if (CanAdd(row - 1, col))
                {
                    list.Add(Mat[row - 1, col]);
                    dictionary.Add(new KeyValuePair<int, int>(row - 1, col), true);
                    queue.Enqueue(new KeyValuePair<int, int>(row - 1, col));
                }
                if (CanAdd(row, col + 1))
                {
                    list.Add(Mat[row, col + 1]);
                    dictionary.Add(new KeyValuePair<int, int>(row, col + 1), true);
                    queue.Enqueue(new KeyValuePair<int, int>(row, col + 1));
                }
                if (CanAdd(row + 1, col))
                {
                    list.Add(Mat[row + 1, col]);
                    dictionary.Add(new KeyValuePair<int, int>(row + 1, col), true);
                    queue.Enqueue(new KeyValuePair<int, int>(row + 1, col));
                }
                if (CanAdd(row, col - 1))
                {
                    list.Add(Mat[row, col - 1]);
                    dictionary.Add(new KeyValuePair<int, int>(row, col - 1), true);
                    queue.Enqueue(new KeyValuePair<int, int>(row, col - 1));
                }
                KeyValuePair<int, int> rowcol = queue.Dequeue();
                row = rowcol.Key;
                col = rowcol.Value;
            }
            return list;
        }

        private bool CanAdd(int row, int col)
        {
            if (row < 0 || row >= Row || col < 0 || col >= Col || dictionary.ContainsKey(new KeyValuePair<int, int>(row,col)))
                return false;
            return true;
        }

        public int FindIslands(int[,] mat, int rowCount, int colCount)
        {
            dictionary = new Dictionary<KeyValuePair<int, int>, bool>();
            PrintMatrix(mat, rowCount, colCount);
            int noOfIslands = 0;
            Queue<KeyValuePair<int, int>> queue = new Queue<KeyValuePair<int, int>>(); // for BFS
            List<KeyValuePair<int, int>> listOfOnes = new List<KeyValuePair<int, int>>(); // store all the ones
            //instead of adding to dictionary we could also flip the values to 0 as soon as we added them using DFS but 
            //    we would like to avoid modifying the matrix as a personal preference
            
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    if(mat[i,j] == 1)
                    {
                        dictionary.Add(new KeyValuePair<int, int>(i, j), true);
                        listOfOnes.Add(new KeyValuePair<int, int>(i, j));
                    }
                }
            }
            
            while(listOfOnes.Count > 0)
            {
                queue.Enqueue(listOfOnes.First());

                noOfIslands++;

                while(queue.Count > 0)
                {
                    KeyValuePair<int, int> rowcol = queue.Dequeue();
                    dictionary[rowcol] = false; //flag as visited or already added in the queue to prevent infinite loop
                    listOfOnes.Remove(rowcol); // keep removing the ones that we have visited

                    int currentRow = rowcol.Key;
                    int currentCol = rowcol.Value;

                    CheckSurrounding(queue, mat, rowCount, colCount, currentRow, currentCol);
                }
            }
            return noOfIslands;
        }

        private void CheckSurrounding(Queue<KeyValuePair<int, int>> queue, int[,] mat, int rowCount, int colCount, int currentRow, int currentCol)
        {
            if (currentRow - 1 >= 0 && dictionary.ContainsKey(new KeyValuePair<int, int>(currentRow - 1, currentCol)) && 
                dictionary[new KeyValuePair<int,int>(currentRow - 1, currentCol)]) //up
                queue.Enqueue(new KeyValuePair<int, int>(currentRow - 1, currentCol));
            
            if (currentCol + 1 < colCount && dictionary.ContainsKey(new KeyValuePair<int, int>(currentRow, currentCol + 1)) &&
                dictionary[new KeyValuePair<int, int>(currentRow,currentCol+1)]) //right
                queue.Enqueue(new KeyValuePair<int, int>(currentRow, currentCol + 1));
            
            if (currentRow + 1 < rowCount && dictionary.ContainsKey(new KeyValuePair<int, int>(currentRow + 1, currentCol)) &&
                dictionary[new KeyValuePair<int, int>(currentRow + 1, currentCol)]) //down
                queue.Enqueue(new KeyValuePair<int, int>(currentRow + 1, currentCol));
            
            if (currentCol - 1 >= 0 && dictionary.ContainsKey(new KeyValuePair<int, int>(currentRow, currentCol - 1)) && 
                dictionary[new KeyValuePair<int, int>(currentRow,currentCol - 1)]) //left
                queue.Enqueue(new KeyValuePair<int, int>(currentRow, currentCol - 1));
        }

        private bool IsIsolated(int[,] mat, int row, int col)
        {
            if (row == 0 && col == 0)
                return true;
            else if(row > 0 && col == 0)
            {
                if (mat[row - 1, col] == 0)
                    return true;
                else
                    return false;
            }
            else if(row == 0 && col > 0)
            {
                if (mat[row, col - 1] == 0)
                    return true;
                else
                    return false;
            }
            else
            {
                if (mat[row - 1, col] == 0 && mat[row, col - 1] == 0)
                    return true;
                else
                    return false;
            }
        }

        Queue<KeyValuePair<int, int>> badOranges;
        int countGoodOranges = 0;
        public int FindRotTime(int[,] mat, int row, int col)
        {
            if (mat.Length == 0 || mat.LongLength == 0)
                return 0;
            int maxTime = row + col;

            badOranges = new Queue<KeyValuePair<int, int>>();

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (mat[i, j] == 2)
                        badOranges.Enqueue(new KeyValuePair<int, int>(i, j));
                    else if (mat[i, j] == 1)
                        countGoodOranges++;
                }
            }

            int minutesPassed = 0;
            while (badOranges.Count > 0 && countGoodOranges > 0 && minutesPassed < maxTime)
            {
                int roundsToGo = badOranges.Count;
                //Console.WriteLine("Matrix at minute "+ minutesPassed);
                PrintMatrix(mat, row, col);

                int goodOrangesBeforeNextRoundOfSpoiling = countGoodOranges;
                while (roundsToGo > 0)
                {
                    var badOrange = badOranges.Dequeue();
                    SpoilNeighbouringOranges(badOrange.Key, badOrange.Value, mat, row, col);
                    roundsToGo--;
                }

                if (goodOrangesBeforeNextRoundOfSpoiling == countGoodOranges)
                    return -1;

                minutesPassed++;
            }

            
            return minutesPassed;
            
        }

        private void SpoilNeighbouringOranges(int currentRow, int currentCol, int[,] mat, int maxRow, int maxCol)
        {
            if(currentRow - 1 >= 0 && mat[currentRow-1, currentCol] == 1) //up
            {
                mat[currentRow - 1, currentCol] = 2;
                badOranges.Enqueue(new KeyValuePair<int, int>(currentRow - 1, currentCol));
                countGoodOranges--;
            }
            if(currentCol + 1 < maxCol && mat[currentRow, currentCol + 1] == 1) //right
            {
                mat[currentRow, currentCol + 1] = 2;
                badOranges.Enqueue(new KeyValuePair<int, int>(currentRow, currentCol + 1));
                countGoodOranges--;
            }
            if(currentRow + 1 < maxRow && mat[currentRow+1,currentCol] == 1) //down
            {
                mat[currentRow + 1, currentCol] = 2;
                badOranges.Enqueue(new KeyValuePair<int, int>(currentRow + 1, currentCol));
                countGoodOranges--;
            }
            if(currentCol - 1 >=0 && mat[currentRow, currentCol-1] == 1) //left
            {
                mat[currentRow, currentCol - 1] = 2;
                badOranges.Enqueue(new KeyValuePair<int, int>(currentRow, currentCol - 1));
                countGoodOranges--;
            }
        }

        List<KeyValuePair<int, int>> gates = new List<KeyValuePair<int, int>>();
        Dictionary<KeyValuePair<int, int>, int> cellStepsPair = new Dictionary<KeyValuePair<int, int>, int>();
        public void FindStepsToNearestGate(int[,] mat, int row, int col)
        {
            if (mat.Length == 0 || mat.LongLength == 0)
                return;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (mat[i, j] == 0)
                    {
                        gates.Add(new KeyValuePair<int, int>(i, j));
                        //cellStepsPair.Add(new KeyValuePair<int, int>(i, j), 0);
                    }
                }
            }

            foreach (var gate in gates)
            {
                DFSWithGates(gate.Key, gate.Value, mat, row, col);
            }
            PrintMatrix(mat, row, col);
        }

        private void DFSWithGates(int row, int col, int[,] mat, int maxRow, int maxCol, int stepLength=1)
        {

            if(row-1 >= 0 && mat[row-1,col] > stepLength) //up
            {
                mat[row - 1, col] = stepLength;
                DFSWithGates(row - 1, col, mat, maxRow, maxCol, stepLength + 1);
            }
            if(col+1 < maxCol && mat[row, col+1] > stepLength)
            {
                mat[row, col + 1] = stepLength;
                DFSWithGates(row, col + 1, mat, maxRow, maxCol, stepLength + 1);
            }
            if(row+1 < maxRow && mat[row+1,col] > stepLength)
            {
                mat[row + 1, col] = stepLength;
                DFSWithGates(row + 1, col, mat, maxRow, maxCol, stepLength + 1);
            }
            if(col-1 >=0 && mat[row, col-1] > stepLength)
            {
                mat[row, col - 1] = stepLength;
                DFSWithGates(row, col - 1, mat, maxRow, maxCol, stepLength + 1)
;           }
        }

        public void PrintMatrix(int[,] mat, int row, int col)
        {
            Console.WriteLine("The Matrix :");
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write(mat[i, j]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
