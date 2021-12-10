using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace AdventofCode2021
{
    class Day09
    {

        public void Main()
        {
            string path = @"C:\Users\justi\Documents\GitHub\AdventOfCode2021\AdventofCode2021\Inputs\day09.txt";
            string[] input = File.ReadAllLines(path);

            Problem(input);
        }
        
        private void Problem(string[] input)
        {
            int resultSum = 0;
            int partTwoResult = 1;
            List<int[]> lowestPoints = new List<int[]>();
            for (int i = 0; i < input.Length;i++)
            {
                for (int k = 0; k < input[i].Length; k++)
                {
                    if (CheckLowestPoint(input, i, k))
                    {
                        resultSum += int.Parse(input[i][k].ToString()) + 1;
                        lowestPoints.Add(new int[] { i, k });
                    }
                }
            }
            //Console.WriteLine("Part One: " + resultSum);

            List<int> counts = new List<int>(); 
            for (int i = 0; i < lowestPoints.Count;i++)
            {
                var myDict = new Dictionary<string,int>();
                var tempDict = new Dictionary<string, bool>();
                FindAdjacent(input, lowestPoints[i][0], lowestPoints[i][1],myDict);
                counts.Add(myDict.Count);
                
                newCode(input, lowestPoints[i][0], lowestPoints[i][1],tempDict);
            }

            counts.Sort();
            counts.Reverse();
            partTwoResult = counts[0] * counts[1] * counts[2];

            Console.WriteLine(partTwoResult);
        }

        /// <summary>
        /// Check if lowest point compared to adjacent tiles
        /// </summary>
        /// <param name="input"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        private bool CheckLowestPoint(string[] input, int row, int col)
        {
            bool lowestPoint = true;
            //Check left
            if ((col-1) >= 0 && (input[row][col-1] <= input[row][col]))
            {
                lowestPoint = false;
                return lowestPoint;
            }
            //Check right
            if ((col + 1) < input[0].Length && input[row][col + 1] <= input[row][col])
            {
                lowestPoint = false;
                return lowestPoint;
            }

            //Check up
            if ((row-1) >= 0 && input[row-1][col] <= input[row][col])
            {
                lowestPoint = false;
                return lowestPoint;
            }

            //Check down
            if ((row+1) < input.Length && input[row+1][col] <= input[row][col])
            {
                lowestPoint = false;
                return lowestPoint;
            }

            return lowestPoint;
        }
        //iterating from LowestPoints array
        //Find Adjacent that is +1  if true count++; 9 does not count
        private void FindAdjacent(string[] input,int row, int col, Dictionary<string,int> myDict)
        {
            if (!myDict.ContainsKey($"{row},{col}"))
            {
                //Check left
                if ((col - 1) >= 0 && (input[row][col - 1] > input[row][col]) && input[row][col-1] != '9')
                {
                    FindAdjacent(input, row, col-1, myDict);
                }
                //Check right
                if ((col + 1) < input[0].Length && input[row][col + 1] > input[row][col] && input[row][col+1] != '9')
                {
                    FindAdjacent(input, row, col+1,myDict);
                }

                //Check up
                if ((row - 1) >= 0 && input[row - 1][col] > input[row][col] && input[row-1][col] != '9')
                {
                    FindAdjacent(input, row - 1, col,myDict);
                }

                //Check down
                if ((row + 1) < input.Length && input[row + 1][col] > input[row][col] && input[row+1][col] != '9')
                {
                    FindAdjacent(input, row + 1, col,myDict);
                }
                myDict.Add($"{row},{col}",0);
            }
        }


        private void newCode(string[] input, int row, int col, Dictionary<string, bool> myDict)
        {
            if (!myDict.ContainsKey($"{row},{col}"))
            {
                myDict.Add($"{row},{col}", false);
                Console.WriteLine("Added");
            }

            if (myDict[$"{row},{col}"].Equals("false"))
            {
                Console.WriteLine(input[row][col] + " " + row + " " + col);
                newCode(input, row, col, myDict);
            }

            myDict[$"{row},{col}"] = true;
        }
    }
}
