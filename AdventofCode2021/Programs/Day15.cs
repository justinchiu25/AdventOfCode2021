using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventofCode2021
{
    class Day15
    {
        public void Main()
        {
            string path = @"C:\Users\justi\Documents\GitHub\AdventOfCode2021\AdventofCode2021\Inputs\day15.txt";

            string[] input = File.ReadAllLines(path);
            int[,] board = new int[input.Length, input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                for (int k = 0; k < input[0].Length;k++)
                {
                    board[i, k] = int.Parse(input[i][k].ToString());
                }
            }
            foreach (int p in board)
            {
                Console.WriteLine(p);
            }
        }

        //Going top left to bottom right
        //Find path which has the least Risk - each x,y has a certain risk when entered
        //Use A*

        private void PartOne()
        {

        }

    }
}
