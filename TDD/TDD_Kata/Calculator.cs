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
            char[] delim = { ',','\n',';','*','%', '"'};

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
                var sum = 0;
                var ReactoredNumbers = numbers.Split(delim);

                foreach (var number in ReactoredNumbers)
                {
                    var num = Int32.Parse(number.ToString());

                    if (num >= 0 && num <= 1000)
                        sum += num;
                    else if (num < 0)
                        throw new NegativeNumberException("Negative numbers are not allowed: " + num);
                    //else if (num > 1000)
                    //    return sum;
                        //throw new OverOneThousandException("You overpassed 1000 with your last add: " + (sum + num));
                }
                return sum;
                
            }
                
                 
        }
    }
}
