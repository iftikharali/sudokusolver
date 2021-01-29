using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SD = SudokuSolverDAL;

namespace SudokuSolverBL
{
    public class SudokuSolver
    {
        int[][] sudokuData;
        public SudokuSolver(string[][] sudokuData)
        {
            //this.sudokuData = sudokuData.Select(x => x.Select(y => Convert.ToInt32(y)));
            this.sudokuData = new int[9][];
            for(int i = 0; i < sudokuData.Length; i++)
            {
                this.sudokuData[i] = new int[9];
                for (int j = 0; j < sudokuData[i].Length; j++)
                {
                    this.sudokuData[i][j] = Convert.ToInt32(sudokuData[i][j]==""?"0": sudokuData[i][j]);
                }
            }
            
        }

        public int[][] Solve()
        {
            SD.SudokuSolver sudokuSolver = new SD.SudokuSolver(this.sudokuData);
            return sudokuSolver.Solve();
            
        }
    }
}
