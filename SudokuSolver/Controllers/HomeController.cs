using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SudokuSolver.Controllers
{
    public static class SudokuStringClass
    {
        public static string ToSudokuString(this string[][] sudokudata)
        {
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(sudokudata);
            return jsonString;
        }
    }
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public JsonResult SolveSudoku(string[][] sudokuData)
        {
            var leftToRight = sudokuData.First();
            var topToBottom = getTopToBottomNumber(sudokuData,0);
            bool notCompleted = true;
            do
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if(string.IsNullOrEmpty(sudokuData[i][j]) || string.IsNullOrWhiteSpace(sudokuData[i][j]))
                        {
                            List<string> possibleValue = new List<string>();
                            leftToRight = sudokuData[i];
                            topToBottom = getTopToBottomNumber(sudokuData, j);
                            for (int integ = 1; integ <= 9; integ++)
                            {
                                //if number exist in row
                                var rowExist = leftToRight.Contains(integ.ToString());
                                //if number exist in column
                                var colExist = topToBottom.Contains(integ.ToString());
                                //if number exist in center
                                //get the centerCell
                                var centerData = getCenterData(sudokuData, i, j);
                                var centerDataExist = centerData.Contains(integ.ToString());
                                if (!rowExist && !colExist && !centerDataExist)
                                {
                                    possibleValue.Add(integ.ToString());
                                }
                            }
                            if (possibleValue.Count == 1)
                            {
                                sudokuData[i][j] = possibleValue.First();
                            }
                        }
                    }
                }
                int rowCount = 0;
                foreach(var values in sudokuData)
                {
                    if(values.All(x => !string.IsNullOrEmpty(x) && !string.IsNullOrWhiteSpace(x)))
                    {
                        rowCount++;
                    }
                }
                if (rowCount == 9)
                {
                    notCompleted = false;
                }
            } while (notCompleted);

            
            return Json(sudokuData);
        }

        public string[] getCenterData(string[][] sudokuData,int topIndex, int bottomIndex)
        {
            List<string> dataToReturn = new List<string>();
            int tIndex = 0;
            int bIndex = 0;
            if (topIndex <= 2)
            {
                tIndex = 0;
            }else if (topIndex > 2 &&topIndex<= 5)
            {
                tIndex = 3;
            }
            else
            {
                tIndex = 6;
            }

            if (bottomIndex <= 2)
            {
                bIndex = 0;
            }
            else if (bottomIndex > 2 && bottomIndex <= 5)
            {
                bIndex = 3;
            }
            else
            {
                bIndex = 6;
            }
            for (int index = tIndex; index < tIndex+3; index++)
            {
                for(int inindex = bIndex; inindex < bIndex+3; inindex++)
                {
                    dataToReturn.Add(sudokuData[index][inindex]);
                }
            }
            return dataToReturn.ToArray();
        }
        public string[] getTopToBottomNumber(string[][] sudokuData,int index)
        {
            List<string> topToBottomData = new List<string>();
            foreach(var sudokuRow in sudokuData)
            {
                topToBottomData.Add(sudokuRow[index]);
            }
            return topToBottomData.ToArray();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}