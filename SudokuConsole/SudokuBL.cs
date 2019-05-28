using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuConsole
{
    class SudokuBL
    {
        public List<List<string>> sudokuData;
        public SudokuBL()
        {
            sudokuData = new List<List<string>>() {
            new List<string>() { "3","4,","5"},
            new List<string>() { },
            new List<string>() { },
            new List<string>() { },
            new List<string>() { },
            new List<string>() { },
            new List<string>() { },
            new List<string>() { },
            new List<string>() { }
            };
        }
    }
}
