using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventofCode2021
{
    class Day13
    {
        public void Main()
        {
            string path = @"C:\Users\justi\Documents\GitHub\AdventOfCode2021\AdventofCode2021\Inputs\day13.txt";

            string[] input = File.ReadAllLines(path);

            Origami(input);
        }

        //Assume Folding is always halfway
        /// <summary>
        /// Folds paper into half and prints the board after final fold
        /// </summary>
        /// <param name="input"></param>
        private void Origami(string[] input)
        {
            var grid = new Dictionary<(int, int), bool>();

            int largestX = 0;
            int largestY = 0;
            List<int[]> foldAlong = new List<int[]>();
            foreach (string coordinate in input)
            {
                if (string.IsNullOrEmpty(coordinate))
                {
                    continue;
                }
                
                if (coordinate.Contains("x"))
                {
                    string[] folding = coordinate.Split("=");
                    int foldX = int.Parse(folding[1]);
                    int foldY = 0;
                    foldAlong.Add(new int[] { foldX, foldY });
                    continue;
                } else if (coordinate.Contains("y"))
                {
                    string[] folding = coordinate.Split("=");
                    int foldX = 0;
                    int folyY = int.Parse(folding[1]);
                    foldAlong.Add(new int[] { foldX, folyY });
                    continue;
                }
                string[] numbers = coordinate.Split(",");
                int numX = int.Parse(numbers[0]);
                int numY = int.Parse(numbers[1]);
                grid.Add((numX, numY), true);
            }

            foreach (int[] folds in foldAlong)
            {
                Fold(grid, folds[0], folds[1]);
            }

            foreach (KeyValuePair<(int,int),bool> coord in grid)
            {
                int tempX = coord.Key.Item1;
                int tempY = coord.Key.Item2;
                
                if (tempX > largestX)
                {
                    largestX = tempX;
                }

                if (tempY > largestY)
                {
                    largestY = tempY;
                }
            }
            int[,] board = new int[largestX+1, largestY+1]; 

            for (int i = 0; i < board.GetLength(0);i++)
            {
                for (int k = 0; k < board.GetLength(1);k++)
                {
                    board[i,k] = 0;
                }
            }
            foreach (KeyValuePair<(int, int), bool> coord in grid)
            {
                board[coord.Key.Item1, coord.Key.Item2] += 1;
            }

            PrintBoard(board);
        }

        /// <summary>
        /// Folds the grid
        /// Moves dots corresponding to folds
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="foldX"></param>
        /// <param name="foldY"></param>
        private void Fold(Dictionary<(int,int),bool> grid, int foldX, int foldY)
        {
            List<(int, int)> valueHolder = new List<(int, int)>();
            int count = 0;
            foreach(KeyValuePair<(int,int),bool> num in grid)
            {
                if (foldY != 0 && foldY == num.Key.Item2)
                {
                    grid.Remove(num.Key);
                    continue;
                }
                if (foldX != 0 && foldX == num.Key.Item1)
                {
                    grid.Remove(num.Key);
                    continue;
                }
                //Folding
                if (num.Key.Item2 >= foldY && num.Key.Item1 >= foldX)
                {
                    int x = num.Key.Item1;
                    int y = num.Key.Item2;
                    count++;
                    if (foldX != 0)
                    {
                        x = foldX * 2 - x;
                    }
                    else if (foldY != 0)
                    {
                        y = foldY * 2 - y;
                    }
                    grid.Remove(num.Key);
                    valueHolder.Add((x, y));
                }
            }
            foreach((int,int) i in valueHolder)
            {
                if (!grid.ContainsKey(i))
                {
                    grid.Add(i, true);
                }
            }

            Console.WriteLine(grid.Count);
        }

        /// <summary>
        /// Prints board with Code
        /// </summary>
        /// <param name="board"></param>
        private void PrintBoard(int[,] board)
        {
            for (int i = 0; i < board.GetLength(1); i++)
            {
                for (int k = 0; k < board.GetLength(0); k++)
                {
                    if (board[k, i] != 0)
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
