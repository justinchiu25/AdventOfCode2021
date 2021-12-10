using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventofCode2021
{
    class Day02
    {
        public void Main()
        {
            string path = @"C:\Users\justi\Documents\GitHub\AdventOfCode2021\AdventofCode2021\Inputs\day02.txt";

            string[] input = File.ReadAllLines(path);

            Console.WriteLine("Part One: " + PartOne(input));
            Console.WriteLine("Part Two: " + PartTwo(input));
        }

        private int PartOne(string[] input)
        {
            int horizontal = 0;
            int depth = 0;
            foreach (string i in input)
            {
                string[] temp = i.Split(" ");
                string direction = temp[0];
                int movement = int.Parse(temp[1]);
                switch (direction)
                {
                    case "forward":
                        horizontal += movement;
                        break;
                    case "up":
                        depth -= movement;
                        break;
                    case "down":
                        depth += movement;
                        break;
                }
            }

            return horizontal * depth;
        }

        private int PartTwo(string[] input)
        {
            int horizontal = 0;
            int depth = 0;
            int aim = 0;
            foreach (string i in input)
            {
                string[] temp = i.Split(" ");
                string direction = temp[0];
                int movement = int.Parse(temp[1]);
                switch (direction)
                {
                    case "forward":
                        horizontal += movement;
                        depth += aim * movement;
                        break;
                    case "up":
                        aim -= movement;
                        break;
                    case "down":
                        aim += movement;
                        break;
                }
            }

            return horizontal * depth;
        }
    }
}
