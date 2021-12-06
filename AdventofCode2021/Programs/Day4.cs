using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventofCode2021
{
    class Day4
    {
        public void Main()
        {
            string path = @"C:\Users\justi\Documents\GitHub\AdventOfCode2021\AdventofCode2021\Inputs\day4.txt";

            string[] input = File.ReadAllLines(path);

            //Console.WriteLine(PartTwo(input));

            TestSolution(input);
        }

        /// <summary>
        /// Finding first board to bingo
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private int PartOne(string[] input)
        {
            int[,] bingoBoard = new int[5,5];
            string[] numbers = input[0].Split(",");
            int unmarkedNum = 0;
            int recentCall = 0;
            //Set first bingoBoard array
            int j = 2;
            int lowestTurns = 0;
            while (j < input.Length)
            {
                int row = 0;

                for (int i = j; i < j+5; i++)
                {
                    int temp = i;
                    string[] inputArray = input[temp].Split(" ");
                    int col = 0;
                    foreach(string num in inputArray)
                    {
                        if (!string.IsNullOrWhiteSpace(num))
                        {
                            bingoBoard[row, col] = int.Parse(num);
                            col++;
                        }
                    }
                    row++;
                }
                int[] result = new int[3];
                int[] checking = new int[3];
                checking = CheckBoard(bingoBoard, numbers);
                if (j == 2)
                {
                    lowestTurns = checking[0];
                    recentCall = int.Parse(numbers[lowestTurns - 1]);
                    unmarkedNum = CheckUnmarked(lowestTurns, bingoBoard, numbers);
                } else
                {
                    if (checking[0] < lowestTurns)
                    {
                        lowestTurns = checking[0];
                        result = checking;

                        recentCall = int.Parse(numbers[lowestTurns - 1]);
                        unmarkedNum = CheckUnmarked(lowestTurns, bingoBoard, numbers);
                    }
                }
                j += 6;
            }
            Console.WriteLine(unmarkedNum + " " + recentCall);
            return unmarkedNum * recentCall;
        }

        /// <summary>
        /// Find board's lowest amount of turns
        /// </summary>
        /// <param name="input"></param>
        /// <param name="number"></param>
        private int[] CheckBoard(int[,] input, string[] number)
        {
            //array[2] 0 = row 1 = col
            int[] array = new int[3];
            int[] row = new int[2];
            int[] col = new int[2];
            row = CheckRow(input, number);
            col = CheckColumn(input, number);
            if (row[0] < col[0])
            {
                array[0] = row[0];
                array[1] = row[1];
                array[2] = 0;
                return array;
            }
            else
            {
                array[0] = col[0];
                array[1] = col[1];
                array[2] = 1;
                return array;
            }
        }

        private int[] CheckRow(int[,] input, string[] number)
        {
            int turns = 0;
            int row = 0;
            for (int i = 0; i < input.GetLength(0);i++) //Rows
            {
                int maxTurns = 0; //Greatest amount of turns it takes to complete a row
                int count = 0;
                for (int k = 0; k < input.GetLength(1); k++) //Columns
                {
                    for (int j = 0; j < number.Length;j++) //Bingo numbers
                    {
                        if (input[i, k] == int.Parse(number[j]))
                        {
                            count++;

                            if (maxTurns < j + 1)
                            {
                                maxTurns = j + 1;
                            }
                        }
                    }
                    if (count == 5)
                    {
                        if (turns == 0)
                        {
                            turns = maxTurns;
                        } else
                        {
                            if (maxTurns < turns)
                            {
                                turns = maxTurns;
                                row = i+1;
                            }
                        }
                    }

                }
            }
            int[] result = new int[2] { turns, row};
            return result;
        }

        private int[] CheckColumn(int[,] input, string[] number)
        {
            int turns = 0;
            int col = 0;
            for (int i = 0; i < input.GetLength(0); i++) //Rows
            {
                int maxTurns = 0; //Greatest amount of turns it takes to complete a row
                int count = 0;
                for (int k = 0; k < input.GetLength(1); k++) //Columns
                {
                    for (int j = 0; j < number.Length; j++) //Bingo numbers
                    {
                        if (input[k, i] == int.Parse(number[j]))
                        {
                            count++;

                            if (maxTurns < j + 1)
                            {
                                maxTurns = j + 1;
                            }
                        }
                    }
                    if (count == 5)
                    {
                        if (turns == 0)
                        {
                            turns = maxTurns;
                        }
                        else
                        {
                            if (maxTurns < turns)
                            {
                                turns = maxTurns;
                                col = i + 1;
                            }
                        }
                    }

                }
            }
            int[] result = new int[2] { turns, col};
            return result;
        }

        private int CheckUnmarked(int turns, int[,] board, string[] numbers)
        {
            int total = 0;
            int marked = 0;
            for (int i = 0; i < board.GetLength(0);i++)
            {
                for (int k = 0; k < board.GetLength(1);k++)
                {
                    for (int s = 0; s < turns; s++)
                    {
                        if (board[i,k] == int.Parse(numbers[s]))
                        {
                            marked += board[i, k];
                            break;
                        }
                    }
                }
            }
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int k = 0; k < board.GetLength(1); k++)
                {
                    for (int s = 0; s < turns; s++)
                    {
                        if (board[i, k] != int.Parse(numbers[s]))
                        {
                            total += board[i, k];
                            break;
                        }
                    }
                }
            }
            return total - marked;
        }

        /// <summary>
        /// Finding board takes longest to Bingo
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public int PartTwo(string[] input)
        {
            int[,] bingoBoard = new int[5, 5];
            string[] numbers = input[0].Split(",");
            int unmarkedNum = 0;
            int recentCall = 0;
            int j = 2;
            int higestTurns = 0;
            while (j < input.Length)
            {
                int row = 0;

                for (int i = j; i < j + 5; i++)
                {
                    int temp = i;
                    string[] inputArray = input[temp].Split(" ");
                    int col = 0;
                    foreach (string num in inputArray)
                    {
                        if (!string.IsNullOrWhiteSpace(num))
                        {
                            bingoBoard[row, col] = int.Parse(num);
                            col++;
                        }
                    }
                    row++;
                }
                int[] result = new int[3];
                int[] checking = new int[3];
                checking = CheckBoard(bingoBoard, numbers);
                if (j == 2)
                {
                    higestTurns = checking[0];
                    recentCall = int.Parse(numbers[higestTurns - 1]);
                    unmarkedNum = CheckUnmarked(higestTurns, bingoBoard, numbers);
                }
                else
                {
                    if (checking[0] > higestTurns)
                    {
                        higestTurns = checking[0];
                        result = checking;

                        recentCall = int.Parse(numbers[higestTurns - 1]);
                        unmarkedNum = CheckUnmarked(higestTurns, bingoBoard, numbers);
                    }
                }
                j += 6;
            }
            Console.WriteLine(unmarkedNum + " " + recentCall);
            return unmarkedNum * recentCall;
        }


        public void TestSolution(string[] input)
        {
            List<string> temp = new List<string>();
            var bingoNumbers = input[0].Split(",").Select(int.Parse);
            int boardSize = 5;
            int i = 0;
            //Blocks of 6 with one empty 
            foreach(string a in input)
            {
                if (string.IsNullOrWhiteSpace(a))
                {
                    i = 0;
                    Console.WriteLine("New Line");
                } else
                {
                    if (i < boardSize)
                    {
                        temp.Add(a);
                        Console.WriteLine(a);
                    }
                    i++;

                    if(i == boardSize)
                    {
                        //determine fastest bingo? from list
                        //int and string of numbers
                        Console.WriteLine("Solve Board");
                    }
                }

            }
        }
    }
}
