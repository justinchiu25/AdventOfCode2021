using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventofCode2021
{
    class Day6
    {

        public void Main()
        {
            string path = @"C:\Users\justi\Documents\GitHub\AdventOfCode2021\AdventofCode2021\Inputs\day6.txt";

            string[] input = File.ReadAllLines(path);

            string[] temp = input[0].Split(',');

            List<uint> numbers = new List<uint>();

            uint[] numArray = new uint[9];


            foreach (string i in temp)
            {
                uint num = uint.Parse(i);
                numbers.Add(num);

                numArray[num]++;              
            }


            //PartOne(numbers);
            two(numArray);
        }

        private void PartOne(List<uint> input)
        {
            uint maxDays = 18;
            uint day = 1;

            while (day <= maxDays)
            {
                uint count = 0;
                for (int i = 0; i < input.Count; i++)
                {
                    if (input[i] != 0)
                    {
                        input[i] -= 1;
                    }
                    else if (input[i] == 0)
                    {
                        input[i] = 6;
                        count++;
                    }
                }

                for (int p = 0; p < count; p++)
                {
                    input.Add(8);
                }
                day++;
            }
        }

        private void two(uint[] input)
        {
            uint[] overflowArray = new uint[9];
            uint days = 1;
            uint maxDays = 256;
            while (days <= maxDays)
            {
                uint count = 0;
                uint overflowCount = 0;
                for (int i = 0; i < input.Length - 1; i++)
                {
                    if (i == 0)
                    {
                        count = input[i];
                        overflowCount = overflowArray[i];
                    }
                    input[i] = input[i + 1];
                    overflowArray[i] = overflowArray[i + 1];
                }
                if (CheckOverflow(input[6], count, out input[6]))
                {
                    overflowArray[6]++;
                }
                overflowArray[8] = overflowCount;

                overflowArray[6] += overflowCount;
                input[8] = count;

                days++;
            }
            uint total = 0;
            uint maxValues = 0;
            foreach(uint p in input)
            {
                if (uint.MaxValue - total <= p)
                {
                    maxValues++;
                    total = p - (uint.MaxValue - total);
                }
                else
                {
                    total += p;
                }
            }

            uint maxOverflows = 0;
            foreach(uint p in overflowArray)
            {
                maxOverflows += p;
            }
            Console.WriteLine("Answer: " + total);
            Console.WriteLine("Overflows: " + maxOverflows + maxValues);
            Console.WriteLine("C# maxValue = " + uint.MaxValue);
        }

        private bool CheckOverflow(uint current, uint additionValue, out uint newValue)
        {
            if (uint.MaxValue - current <= additionValue)
            {
                newValue = additionValue - (uint.MaxValue - current);
                return true;
            }
            else
            {
                newValue = current + additionValue;
                return false;
            }  
        }
    }
}
