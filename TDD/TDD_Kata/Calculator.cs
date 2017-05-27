using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_Kata
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            //string[] split = null;
            char[] delim = { ',','\n',';'};

            if (String.IsNullOrEmpty(numbers))
            {
                return 0;
            }
            else if (numbers.Length == 1)
            {
                var number = 0;
                Int32.TryParse(numbers, out number);
                return number;
            }
            else
            {
                return numbers.Split(delim).Sum(x => int.Parse(x));
            }
                
                 
        }
    }
}
