using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventofCode2021
{
    class Day11
    {
        public void Main()
        {
            string path = @"C:\Users\justi\Documents\GitHub\AdventOfCode2021\AdventofCode2021\Inputs\day11.txt";

            string[] input = File.ReadAllLines(path);

            int[][] grid = new int[input.Length][];
            for (int i = 0; i < input.Length; i++)
            {
                grid[i] = new int[input[i].Length];
                for (int k = 0; k < grid[i].Length; k++)
                {
                    grid[i][k] = int.Parse(input[i][k].ToString());
                }
            }

            int maxSteps = 300;
            OctupusFlash(grid,maxSteps);
        }

        private void OctupusFlash(int[][] grid, int maxSteps)
        {
            int totalFlashed = 0;
            int step = 1;
            while (step <= maxSteps)
            {
                int count = 0;
                Dictionary<(int, int), bool> myDict = new Dictionary<(int, int), bool>();
                for (int i = 0; i < grid.Length; i++)
                {
                    for (int k = 0; k < grid[i].Length;k++)
                    {
                        AddEnergy(grid, i, k, myDict);

                    }
                }

                for (int i = 0; i < myDict.Count; i++)
                {
                    if (myDict.ElementAt(i).Value == true)
                    {
                        count++;
                    }
                }

                if (count == 100)
                {
                    Console.WriteLine("Fully  Flashed:  " + step);
                }

                totalFlashed += count;
                step++;
            }
            Console.WriteLine("Total Flashed: " + totalFlashed);
        }

        /// <summary>
        /// Check if next number will Flash
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private bool Flashes(int number)
        {
            if (number+1 > 9)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Adds energy to grid[row][col]
        /// If it goes above treshhold
        /// Adds energy to inputs around
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="myDict"></param>
        private void AddEnergy(int[][] grid, int row, int col, Dictionary<(int,int),bool> myDict)
        {
            if (myDict.ContainsKey((row, col)))
            {
                //If true set to 0
                if (myDict[(row, col)] == true)
                {
                    return;
                }
            }
            else
            {
                myDict.Add((row, col), false);
            }

            if (Flashes(grid[row][col]))
            {
                grid[row][col] = 0;
                myDict[(row, col)] = true;
                //Check Top Left
                if (col - 1 >= 0 && (row - 1) >= 0)
                {
                    AddEnergy(grid, row - 1, col - 1, myDict);
                }

                //Check Top right
                if ((col + 1) < grid[row].Length && (row+1) < grid.Length)
                {
                    AddEnergy(grid, row + 1, col + 1, myDict);
                }

                //Check Bottom Right
                if ((col + 1) < grid[row].Length && (row - 1) >= 0)
                {
                    AddEnergy(grid, row - 1, col + 1, myDict);
                }

                //Check Bottom Left
                if ((col -1) >= 0 && (row+1)<grid.Length)
                {
                    AddEnergy(grid, row + 1, col - 1, myDict);
                }

                //Check left
                if ((col - 1) >= 0)
                {
                    AddEnergy(grid, row, col - 1, myDict);
                }

                //Check right
                if ((col + 1) < grid[row].Length)
                {
                    AddEnergy(grid, row, col + 1, myDict);
                }

                //Check up
                if ((row - 1) >= 0)
                {
                    AddEnergy(grid, row - 1, col, myDict);
                }

                //Check down
                if ((row + 1) < grid.Length)
                {
                    AddEnergy(grid, row + 1, col, myDict);
                }
            } 
            else
            {
                grid[row][col] += 1;
            }
        }
    }
}
