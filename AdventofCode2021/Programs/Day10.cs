using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace AdventofCode2021
{
    class Day10
    {
        public void Main()
        {
            string path = @"C:\Users\justi\Documents\GitHub\AdventOfCode2021\AdventofCode2021\Inputs\day10.txt";

            string[] input = File.ReadAllLines(path);

            Chunks(input);
        }

        private void Chunks(string[] input)
        {
            Dictionary<char, int> charPoints = new Dictionary<char, int>()
            {
                {')',3},
                {']',57 },
                {'}',1197 },
                {'>',25137 }
            };

            List<string> unfinishedLines = new List<string>();

            int partOneResult = 0;

            List<long> partTwoResult = new List<long>();

            foreach (string line in input)
            {
                char holder = FindIllegalChararacter(line);
                if (holder != '0')
                {
                    partOneResult += charPoints[holder];
                }
                else
                {
                    unfinishedLines.Add(line);
                }
            }

            foreach (string line in unfinishedLines)
            {
                partTwoResult.Add(FindIncomplete(line));
            }

            partTwoResult.Sort();

            Console.WriteLine("Part One: " + partOneResult);
            Console.WriteLine(partTwoResult[partTwoResult.Count / 2]);
        }

        /// <summary>
        /// Checks if line has an unclosed Bracket
        /// returns first char that is missing
        /// </summary>
        /// <param name="line"></param>
        private char FindIllegalChararacter(string line)
        {
            //if open check if next one is closed
            //Stacks FILO
            Stack<char> open = new Stack<char>();
            foreach (char symbol in line)
            {
                if (symbol == '(' || symbol == '[' || symbol == '{' || symbol == '<')
                {
                    open.Push(symbol);
                }
                else
                {
                    if (open.Peek() == '(' && symbol == ')')
                    {
                        open.Pop();
                    } 
                    else if (open.Peek() == '[' && symbol == ']')
                    {
                        open.Pop();
                    }
                    else if (open.Peek() == '{' && symbol == '}')
                    {
                        open.Pop();
                    }
                    else if (open.Peek() == '<' && symbol == '>')
                    {
                        open.Pop();
                    }
                    else
                    {
                        return symbol;
                    }
                }
            }

            return '0';
        }
        /// <summary>
        /// Finds the incomplete characters in a line
        /// returns total points for line
        /// </summary>
        /// <param name="line"></param>
        private long FindIncomplete(string line)
        {
            Stack<char> open = new Stack<char>();
            Dictionary<char, int> points = new Dictionary<char, int>()
            {
                {'(',1 },
                {'[',2 },
                {'{',3 },
                {'<',4 }
            };

            long total = 0;

            foreach (char symbol in line)
            {
                if (symbol == '(' || symbol == '[' || symbol == '{' || symbol == '<')
                {
                    open.Push(symbol);
                }
                else
                {
                    if (open.Peek() == '(' && symbol == ')')
                    {
                        open.Pop();
                    }
                    else if (open.Peek() == '[' && symbol == ']')
                    {
                        open.Pop();
                    }
                    else if (open.Peek() == '{' && symbol == '}')
                    {
                        open.Pop();
                    }
                    else if (open.Peek() == '<' && symbol == '>')
                    {
                        open.Pop();
                    }
                }
            }

            foreach (char bracket in open)
            {
                total = (total * 5) + points[bracket];
            }
            return total;
        }
    }
}
