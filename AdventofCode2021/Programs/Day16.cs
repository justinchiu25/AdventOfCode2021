using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCode2021
{
    class Day16
    {
        public void Main()
        {
            Console.WriteLine(StringToBinary("D2FE28"));
        }


        private void PartOne(string input)
        {
            
        }
        private string StringToBinary(string data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in data.ToCharArray())
            {
                //Console.WriteLine(c + " " + Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0'));
                sb.Append(Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0'));
            }
            return sb.ToString();
        }
    }
}
