using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolverDAL
{
    public class SudokuSolver
    {
        int[][] sudokuData;
        public SudokuSolver(int[][] sudokuData)
        {
            this.sudokuData = sudokuData;
        }

        public int[][] Solve()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (this.sudokuData[i][j] == 0)
                    {
                        int injectable = GetInjectableValue(i, j);
                        if (injectable != 0)
                        {
                            this.sudokuData[i][j] = injectable;
                            Solve();
                        }
                    }

                }
            }
            return this.sudokuData;
        }

        int GetInjectableValue(int x, int y)
        {
            List<int> values = new List<int>();
            for (int i = 1; i < 10; i++)
            {
                if (IfPossible(x, y, i))
                {
                    values.Add(i);
                }
            }
            if (values.Count == 1)
            {
                return values.First();
            }
            else
            {
                return 0;
            }
        }
        bool IfPossible(int x, int y, int number)
        {
            //Console.WriteLine("printing");
            //check horizontally
            for (int i = 0; i < 9; i++)
            {
                if (this.sudokuData[x][i] == number)
                {
                    return false;
                }
                if (this.sudokuData[i][y] == number)
                {
                    return false;
                }
            }

            //check center
            int startX = 0;
            int startY = 0;
            int endX = 9;
            int endY = 9;
            if (x < 3)
            {
                startX = 0;
                endX = 3;
            }
            else if (x < 6)
            {
                startX = 3;
                endX = 6;
            }
            else
            {
                startX = 6;
                endX = 9;
            }
            if (y < 3)
            {
                startY = 0;
                endY = 3;
            }
            else if (y < 6)
            {
                startY = 3;
                endY = 6;
            }
            else
            {
                startY = 6;
                endY = 9;
            }


            for (int i = startX; i < endX; i++)
            {
                for (int j = startY; j < endY; j++)
                {
                    if (this.sudokuData[i][j] == number)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
