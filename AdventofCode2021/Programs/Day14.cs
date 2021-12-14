using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventofCode2021
{
    class Day14
    {
        public void Main()
        {
            string path = @"C:\Users\justi\Documents\GitHub\AdventOfCode2021\AdventofCode2021\Inputs\day14.txt";

            string[] input = File.ReadAllLines(path);

            string polymerTemplate = input[0];

            var pairInsertions = new Dictionary<string, string>();
            for (int i = 2; i < input.Length; i++)
            {
                string[] inputs = input[i].Split("->");
                string pairing = inputs[0].Trim();
                string output = inputs[1].Trim();

                pairInsertions.Add(pairing, output);
            }
            PartOne(polymerTemplate, pairInsertions, 40);
        }
        
        private void PartOne(string polymerTemplate, Dictionary<string,string> pairInsertions,int maxSteps)
        {
            int steps = 0;
            string polymer = polymerTemplate;
            while (steps < maxSteps)
            {
                polymer = PolymerSolver(polymer, pairInsertions);
                Console.WriteLine(steps);
                steps++;
            }
            Dictionary<char,int> uniqueCharacters = CountAllUniqueCharacters(polymer);
            long maxCount = uniqueCharacters.Values.Max();
            long minCount = uniqueCharacters.Values.Min();

            Console.WriteLine(maxCount - minCount);
        }

        /// <summary>
        /// Finds whether polymer and pair insertion matches
        /// Then inserts letter between
        /// </summary>
        /// <param name="polymerTemplate"></param>
        /// <param name="pairInsertions"></param>
        /// <returns> returns new polymer </returns>
        private string PolymerSolver(string polymerTemplate, Dictionary<string,string> pairInsertions)
        {
            string polymer = polymerTemplate;
            string polymerBuilder = null;
            for (int i = 0; i < polymer.Length - 1; i++)
            {
                string letterOne = polymer[i].ToString();
                string letterTwo = polymer[i + 1].ToString();
                string current = letterOne + letterTwo;

                if (pairInsertions.ContainsKey(current))
                {
                    //polymer = polymer.Insert(i + 1, pairInsertions[current]);
                    //i++;
                    polymerBuilder += polymer[i] + pairInsertions[current];
                }
            }

            polymerBuilder += polymer[polymer.Length - 1];
            return polymerBuilder;
        }

        /// <summary>
        /// Counts hows many times each character appears
        /// </summary>
        /// <param name="polymer"></param>
        /// <returns> </returns>
        private Dictionary<char,int> CountAllUniqueCharacters(string polymer)
        {
            var uniqueCharacters = new Dictionary<char, int>();
            foreach(char character in polymer)
            {
                if (!uniqueCharacters.ContainsKey(character))
                {
                    uniqueCharacters.Add(character, 1);
                }
                else
                {
                    uniqueCharacters[character] += 1;
                }
            }

            return uniqueCharacters;
        }
    }

}
