using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionLibrary
{
    public class BackTracking
    {
        bool[,] sudokuBinary = new bool[9,9];
        public void SolveSudoku(int[,] sudoku)
        {
            Console.WriteLine("Unsolved Sudoku: ");
            PrintSudoku(sudoku);
            CreteSudokuBinary(sudoku);
            FillUpSudokuNew(sudoku);
            Console.WriteLine("Solved Sudoku: ");
            PrintSudoku(sudoku);
        }

        private bool FillUpSudokuNew(int[,] sudoku, int row=0, int col=0)
        {
            if (row >= 9 || col >= 9)
                return true;

            if (sudokuBinary[row, col])
            {
                for (int i = 1; i <= 9; i++)
                {
                    if (IsValid(sudoku, row, col, i))
                    {
                        sudoku[row, col] = i;
                        if (col == 8)
                        {
                            if (FillUpSudokuNew(sudoku, row + 1, 0))
                                return true;
                        }
                        else
                        {
                            if (FillUpSudokuNew(sudoku, row, col + 1))
                                return true;
                        }
                    }
                    sudoku[row, col] = 0;
                }
            }
            else
            {
                if(col == 8)
                {
                    if (FillUpSudokuNew(sudoku, row + 1, 0))
                        return true;
                }
                else
                {
                    if (FillUpSudokuNew(sudoku, row, col + 1))
                        return true;
                }
            }
            return false;

        }

        private bool FillUpSudoku(int[,] sudoku, int row = 0, int col = 0, int currentNumber=1)
        {
            if (row >= 9 || col >= 9)
                return true;


            if (IsValid(sudoku,row,col,currentNumber) || !sudokuBinary[row,col])
            {
                if (sudokuBinary[row, col])
                    sudoku[row, col] = currentNumber;

                int newRow, newCol;

                MoveForward(row, col, out newRow, out newCol);
                
                bool res = false;

                int i = 1;
                while (!res && i<=9)
                {
                    res = FillUpSudoku(sudoku, newRow, newCol, i);
                    i++;
                }
                if (!res)
                    sudoku[row, col] = 0;
                return res;
            }
            else
            {
                sudoku[row, col] = 0;
                return false;
            }
        }

        private bool MoveForward(int row, int col, out int newRow, out int newCol)
        {
            if (col != 8)
            {
                newCol = col + 1;
                newRow = row;
                return true;
            }
            else if (row != 8)
            {
                newRow = row + 1;
                newCol = 0;
                return true;
            }
            newRow = 9;
            newCol = 9;
            return false;
        }
        private bool IsValid(int[,] sudoku, int row, int col, int currentNumber)
        {
            return ValidInRow(sudoku, row, currentNumber) && ValidIncol(sudoku, col, currentNumber) && ValidInBox(sudoku, row, col, currentNumber);
        }
        private bool ValidInBox(int[,] sudoku, int row, int col, int currentNumber)
        {
            int rowLowerLimit;
            int rowUpperLimit;
            int colLowerLimit;
            int colUpperLimit;
            //set box boundaries
            if(row < 3)
            {
                rowLowerLimit = 0;
                rowUpperLimit = 3;
            }
            else if(row < 6)
            {
                rowLowerLimit = 3;
                rowUpperLimit = 6;
            }
            else
            {
                rowLowerLimit = 6;
                rowUpperLimit = 9;
            }

            if (col < 3)
            {
                colLowerLimit = 0;
                colUpperLimit = 3;
            }
            else if (col < 6)
            {
                colLowerLimit = 3;
                colUpperLimit = 6;
            }
            else
            {
                colLowerLimit = 6;
                colUpperLimit = 9;
            }
            for (int i = rowLowerLimit; i < rowUpperLimit; i++)
            {
                for (int j = colLowerLimit; j < colUpperLimit; j++)
                {
                    if (sudoku[i, j] == currentNumber)
                        return false;
                }
            }
            return true;
        }

        private bool ValidIncol(int[,] sudoku, int col, int currentNumber)
        {
            for (int i = 0; i < 9; i++)
            {
                if (sudoku[i, col] == currentNumber)
                    return false;
            }
            return true;
        }

        private bool ValidInRow(int[,] sudoku, int row, int currentNumber)
        {
            for (int i = 0; i < 9; i++)
            {
                if (sudoku[row, i] == currentNumber)
                    return false;
            }
            return true;
        }
        private void CreteSudokuBinary(int[,] sudoku)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (sudoku[i, j] == 0)
                        sudokuBinary[i, j] = true;
                }
            }
        }

        private void PrintSudoku(int[,] sudoku)
        {
            string s = new string('-', 36);
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine(s);
                Console.Write("|");
                for (int j = 0; j < 9; j++)
                {
                    string el = sudoku[i, j] == 0 ? " " : sudoku[i, j].ToString();
                    Console.Write($" { el} |");
                }
                Console.WriteLine();
            }
            Console.WriteLine(s);
        }
    }
}
