using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventofCode2021
{
    class Day3
    {
        public void Main()
        {
            string path = @"C:\Users\justi\Documents\GitHub\AdventOfCode2021\AdventofCode2021\Inputs\day3.txt";

            string[] input = File.ReadAllLines(path);

            Console.WriteLine("Part One: " + PartOne(input));

            Console.WriteLine("Part Two: " + PartTwo(input));
        }

        private int PartOne(string[] input)
        {
            int[] array = new int[input[0].Length];
            string gamma = "";
            string epsilon = "";
            foreach (string num in input)
            {
                //int number = Convert.ToInt32(num,2);
                for (int j = 0; j < num.Length; j++)
                {
                    if (num[j] == '0')
                    {
                        array[j] += 1;
                    }
                    else if (num[j] == '1')
                    {
                        array[j] -= 1;
                    }
                }
            }

            for (int p = 0; p < array.Length; p++)
            {
                if (array[p] < 0)
                {
                    gamma += "1";
                    epsilon += "0";

                }
                else
                {
                    gamma += "0";
                    epsilon += "1";
                }
            }

            int newGamma = Convert.ToInt32(gamma, 2);
            int newEpsilon = Convert.ToInt32(epsilon, 2);
            //Console.WriteLine(gamma + " " + epsilon);
            return newGamma * newEpsilon;
        }

        private int PartTwo(string[] input)
        {
            //multiplying the oxygen generator rating by the CO2 scrubber rating.
            //Check first index for most common 0 or 1 -> deduct to only most common
            //Check second index for most common --> deduct to most common

            //string 
            var numbers = new Dictionary<string, string>();
            List<string> oxTemp = new List<string>();
            List<string> coTemp = new List<string>();
            int[] oxArray = new int[input[0].Length];
            int[] coArray = new int[input[0].Length];

            string oxygen = "";
            string scrubber = "";
            int i = 0;
            while (i < input[0].Length)
            {
                if (oxTemp.Count > 1)
                {
                    oxTemp.Clear();
                }
                if (coTemp.Count > 1)
                {
                    coTemp.Clear();
                }
                foreach (string num in input)
                {
                    if (num.Substring(0, i) == oxygen)
                    {
                        if (num[i] == '0')
                        {
                            oxArray[i] += 1;
                        }
                        else if (num[i] == '1')
                        {
                            oxArray[i] -= 1;
                        }

                        oxTemp.Add(num);
                    }

                    if (num.Substring(0, i) == scrubber)
                    {
                        if (num[i] == '0')
                        {
                            coArray[i] += 1;
                        }
                        else if (num[i] == '1')
                        {
                            coArray[i] -= 1;
                        }
                        coTemp.Add(num);
                    }
                }

                if (oxArray[i] > 0)
                {
                    oxygen += "0";
                }
                else if (oxArray[i] <= 0)
                {
                    oxygen += "1";
                }
                if (coArray[i] > 0)
                {
                    scrubber += "1";
                }
                else if (coArray[i] <= 0)
                {
                    scrubber += "0";
                }

                i++;
            }

            if (oxTemp.Count > 1)
            {
                for (int k = 0; k < oxTemp.Count; k++)
                {
                    if (oxTemp[k] == oxygen)
                    {
                        oxygen = oxTemp[k];
                    }
                }
            }
            else
            {
                oxygen = oxTemp[0];
            }

            if (coTemp.Count > 1)
            {
                for (int k = 0; k < coTemp.Count; k++)
                {
                    if (coTemp[k] == scrubber)
                    {
                        scrubber = coTemp[k];
                    }
                }
            }
            else
            {
                scrubber = coTemp[0];
            }
            int newOxygen = Convert.ToInt32(oxygen, 2);
            int newScrubber = Convert.ToInt32(scrubber, 2);
            return newOxygen * newScrubber;
        }
    }
}
