using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventofCode2021
{
    class Day5
    {
        public void Main()
        {
            string path = @"C:\Users\justi\Documents\GitHub\AdventOfCode2021\AdventofCode2021\Inputs\day5.txt";

            string[] input = File.ReadAllLines(path);

            Console.WriteLine(PartOne(input));
            Console.WriteLine(PartTwo(input));
        }

        private int PartOne(string[] input)
        {
            var board = new Dictionary<string, int>();
            List<string> myList = new List<string>();
            for (int i = 0; i < input.Length; i++)
            {
                string[] check = input[i].Split("->");
                for (int p = 0; p < check.Length; p++)
                {
                    check[p] = check[p].Trim();
                    myList.Add(check[p]);
                    //Console.WriteLine(check[p]);
                }
            }
            for (int i = 0; i < myList.Count; i+=2)
            {
                int x1 = int.Parse(myList[i].Split(",")[0]);
                int y1 = int.Parse(myList[i].Split(",")[1]);
                int x2 = int.Parse(myList[i+1].Split(",")[0]);
                int y2 = int.Parse(myList[i+1].Split(",")[1]);

                foreach (string a in FindLocations(x1,x2,y1,y2))
                {
                    if (board.ContainsKey(a))
                    {
                        board[a] += 1;
                    }
                    else
                    {
                        board[a] = 1;
                    }
                }
            }

            int count = 0;
            foreach (int a in board.Values)
            {
                if (a > 1)
                {
                    count++;
                }
            }

            //LINQ foreach loop for dictionary
            //board.ToList().ForEach(x => Console.WriteLine(x.Key + " " + x.Value));

            return count;
        }

        /// <summary>
        /// 
        /// </summary>
        private List<string> FindLocations(int x1, int x2, int y1, int y2)
        {
            List<string> result = new List<string>();
            int maxX = 0;
            int minX = 0;
            int maxY = 0;
            int minY = 0;
            
            if (y2 > y1)
            {
                maxY = y2;
                minY = y1;
            } else
            {
                maxY = y1;
                minY = y2;
            }

            if (x2 > x1)
            {
                maxX = x2;
                minX = x1;
            } else
            {
                maxX = x1;
                minX = x2;
            }

            //Find y
            if (x1 == x2)
            {
                for (int i = minY; i <= maxY; i++)
                {
                    result.Add($"{x1},{i}");
                }
            }

            if (y1 == y2)
            {
                for (int i = minX; i <= maxX; i++)
                {
                    result.Add($"{ i},{ y1}");
                }
            }


            return result;
        }

        private List<string> FindDiagonals(int x1,int x2, int y1, int y2)
        {
            List<string> result = new List<string>();

            if (Math.Abs(x1-x2) == Math.Abs(y1-y2)) //is diagonal
            {
                //Console.WriteLine($"{x1},{y1} -> {x2},{y2}");
                if (x1 < x2 && y1 < y2)
                {
                    int count = 0;
                    for (int i = x1; i <= x2; i++)
                    {
                        result.Add($"{i},{y1+count}");
                        count++;
                    }
                }
                else if (x1 > x2 && y1 > y2)
                {
                    int count = 0;
                    for (int i = x1; i >= x2; i--)
                    {
                        result.Add($"{i},{y1-count}");
                        count++;
                    }
                }
                else if (x1 > x2 && y1 < y2)
                {
                    int count = 0;
                    for (int i = y1; i <= y2;i++)
                    {
                        result.Add($"{x1-count},{i}");
                        count++;
                    }
                }
                else if (x1 < x2 && y1 > y2)
                {
                    int count = 0;
                    for (int i = x1; i <= x2;i++)
                    {
                        result.Add($"{i},{y1-count}");
                        count++;
                    }
                }

            }

            return result;
        }

        private int PartTwo(string[] input)
        {
            var board = new Dictionary<string, int>();
            List<string> myList = new List<string>();
            for (int i = 0; i < input.Length; i++)
            {
                string[] check = input[i].Split("->");
                for (int p = 0; p < check.Length; p++)
                {
                    check[p] = check[p].Trim();
                    myList.Add(check[p]);
                }
            }
            for (int i = 0; i < myList.Count; i += 2)
            {
                int x1 = int.Parse(myList[i].Split(",")[0]);
                int y1 = int.Parse(myList[i].Split(",")[1]);
                int x2 = int.Parse(myList[i + 1].Split(",")[0]);
                int y2 = int.Parse(myList[i + 1].Split(",")[1]);

                foreach (string a in FindLocations(x1, x2, y1, y2))
                {
                    if (board.ContainsKey(a))
                    {
                        board[a] += 1;
                    }
                    else
                    {
                        board[a] = 1;
                    }
                }
                foreach (string a in FindDiagonals(x1, x2, y1, y2))
                {
                    if (board.ContainsKey(a))
                    {
                        board[a] += 1;
                    }
                    else
                    {
                        board[a] = 1;
                    }
                }

            }

            int count = 0;
            foreach (int a in board.Values)
            {
                if (a > 1)
                {
                    count++;
                }
            }

            //LINQ foreach loop for dictionary
            //board.ToList().ForEach(x => Console.WriteLine(x.Key + " " + x.Value));

            return count;
        }
    }
}
