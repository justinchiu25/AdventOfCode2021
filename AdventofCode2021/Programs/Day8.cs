using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventofCode2021
{
    class Day8
    {
        public void Main()
        {
            string path = @"C:\Users\justi\Documents\GitHub\AdventOfCode2021\AdventofCode2021\Inputs\day8.txt";

            string[] input = File.ReadAllLines(path);

            //Refactor in future
            PartTwo(input);
            
        }

        private void PartOne(string[] input)
        {
            int count = 0;
            foreach(string p in input)
            {
                string[] number = p.Split("|");

                string[] rightCode = number[1].Split(" ");
                foreach (string i in rightCode)
                {
                    int distinctLetters = i.Distinct().Count();
                    if (distinctLetters == 2)
                    {
                        count++;
                    }
                    else if (distinctLetters == 4)
                    {
                        count++;
                    }
                    else if (distinctLetters == 3)
                    {
                        count++;
                    }
                    else if (distinctLetters == 7)
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
        }
        // Lengths
        // 2: 1
        // 3: 7
        // 4: 4
        // 5: 2 , 3 , 5
        // 6: 0 , 6 , 9
        // 7: 8

        // 1: c f
        // if Length = 5 but is missing C or F. x = 5
        //No repeat letters -> all  unqiue

        /// <summary>
        /// Comeback to this in future
        /// </summary>
        /// <param name="input"></param>
        private void PartTwo(string[] input)
        {
            int total = 0;
            string zero = null;
            string one = null;
            string two = null;
            string three = null;
            string four = null;
            string five = null;
            string six = null;
            string seven = null;
            string eight = null;
            string nine = null;
            foreach (string i in input)
            {
                string[] number = i.Split("|");


                string[] leftCode = number[0].Split(" ");
                string[] rightCode = number[1].Split(" ");


                foreach(string code in leftCode)
                {
                    if (code.Length == 2)
                    {
                        char[] temp = code.ToCharArray();
                        Array.Sort(temp);
                        one = new string(temp);
                    }
                    else if (code.Length == 4)
                    {
                        char[] temp = code.ToCharArray();
                        Array.Sort(temp);
                        four = new string(temp);
                    }
                    else if (code.Length == 3)
                    {
                        char[] temp = code.ToCharArray();
                        Array.Sort(temp);
                        seven = new string(temp);
                    }
                    else if (code.Length == 7)
                    {
                        char[] temp = code.ToCharArray();
                        Array.Sort(temp);
                        eight = new string(temp);
                    }
                }
                //Finding 9
                foreach(string code in leftCode)
                {
                    if (code.Length == 6)
                    {
                        //Could use for loop instead
                        if (code.Contains(four[0]) && code.Contains(four[1]) && code.Contains(four[2]) && code.Contains(four[3]))
                        {
                            char[] temp = code.ToCharArray();
                            Array.Sort(temp);
                            nine = new string(temp);
                        }
                        else if (code.Contains(one[0]) && code.Contains(one[1]))
                        {
                            char[] temp = code.ToCharArray();
                            Array.Sort(temp);
                            zero = new string(temp);
                        } else
                        {
                            char[] temp = code.ToCharArray();
                            Array.Sort(temp);
                            six = new string(temp);
                        }
                    }

                    if (code.Length == 5)
                    {
                        if (code.Contains(one[0]) && code.Contains(one[1]))
                        {
                            char[] temp = code.ToCharArray();
                            Array.Sort(temp);
                            three = new string(temp);
                        }
                    }
                }
            
                foreach (string code in leftCode)
                {
                    int count = 0;
                    char[] checker = code.ToCharArray();
                    Array.Sort(checker);
                    string newCode = new string(checker);
                    if (code.Length == 5 && newCode != three)
                    {
                        for (int x = 0; x < six.Length;x++)
                        {
                            if (code.Contains(six[x]))
                            {
                                count++;
                            }
                        }
                        if (count == 5)
                        {
                            char[] temp = code.ToCharArray();
                            Array.Sort(temp);
                            five = new string(temp);
                        }
                        else
                        {
                            char[] temp = code.ToCharArray();
                            Array.Sort(temp);
                            two = new string(temp);
                        }
                    }
                }
                string result = "";

                foreach(string code in rightCode)
                {
                    char[] temp = code.ToCharArray();
                    Array.Sort(temp);
                    string newCode = new string(temp);
                    if (newCode.CompareTo(zero) == 0)
                    {
                        result += "0";
                    }

                    if (newCode.CompareTo(one) == 0)
                    {
                        result += "1";
                    }

                    if (newCode.CompareTo(two) == 0)
                    {
                        result += "2";
                    }

                    if (newCode.CompareTo(three) == 0)
                    {
                        result += "3";
                    }

                    if (newCode.CompareTo(four) == 0)
                    {
                        result += "4";
                    }
                    if (newCode.CompareTo(five) == 0)
                    {
                        result += "5";                     
                    } 
                        
                    if (newCode.CompareTo(six) == 0)
                    {
                        result += "6";
                    }
                    
                    if (newCode.CompareTo(seven) == 0)
                    {
                        result += "7";
                    }

                    if (newCode.CompareTo(eight) == 0)
                    {
                        result += "8";
                    }

                    if (newCode.CompareTo(nine) == 0)
                    {
                        result += "9";
                    }
                    //Console.WriteLine(result);
                }
                total += int.Parse(result);
                //Console.WriteLine(result);

            }
             Console.WriteLine(total);
        }
    }
}
