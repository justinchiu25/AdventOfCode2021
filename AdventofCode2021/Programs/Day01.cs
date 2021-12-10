using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventofCode2021
{
    class Day01
    {
		public void Main()
		{
			int[] test = new int[] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };
			string path = @"C:\Users\justi\Documents\GitHub\AdventOfCode2021\AdventofCode2021\Inputs\day01.txt";
			string[] input = File.ReadAllLines(path);

			int holder = 0;
			int result = 0;
			for (int i = 1; i < input.Length; i++)
			{
				int current = int.Parse(input[i]);
				int past = int.Parse(input[i - 1]);
				int temp = current - past;

				if (temp > holder)
				{
					result++;
				}
			}

			Console.WriteLine("Part One: " + result);

			Console.WriteLine("Part Two: " + PartTwo(input));
		}


		private int PartTwo(string[] input)
		{
			int result = 0;
			int sum = 0;
			for (int i = 1; i < input.Length - 2; i++)
			{
				int one = int.Parse(input[i]);
				int two = int.Parse(input[i + 1]);
				int three = int.Parse(input[i + 2]);

				int temp = one + two + three;
				if (temp > sum)
				{
					result++;
				}
				sum = temp;
			}

			return result;
		}
	}
}
