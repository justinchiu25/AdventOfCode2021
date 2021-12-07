using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventofCode2021
{
    class Day7
    {

        public void Main()
        {
            string path = @"C:\Users\justi\Documents\GitHub\AdventOfCode2021\AdventofCode2021\Inputs\day7.txt";

            string[] input = File.ReadAllLines(path);

            int[] numbers = input[0].Split(",").Select(x => int.Parse(x)).ToArray();

            Array.Sort(numbers);

            PartOne(numbers);
            PartTwo(numbers);
            
        }

        private void PartOne(int[] input)
        {
            int leastCost = int.MaxValue;
            int intResult = 0;
            for (int i = 0; i < input.Length;i++)
            {
                int count = 0;
                for (int k = 0; k < input.Length; k++)
                {
                    count += Math.Abs(input[i] - input[k]);
                }

                if (count < leastCost)
                {
                    leastCost = count;
                    intResult = input[i];
                }
            }

            Console.WriteLine(intResult+": " + leastCost);
        }

        private void PartTwo(int[] input)
        {
            int leastCost = int.MaxValue;
            int intResult = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int count = 0;
                for (int k = 0; k < input.Length;k++)
                {
                    int difference = Math.Abs(input[i] - input[k]);
                    count += (difference * (difference + 1)) / 2;
                }

                if (count < leastCost)
                {
                    leastCost = count;
                    intResult = input[i];
                }
            }

            Console.WriteLine(intResult + ": " + leastCost);
        }

        
    }
}
