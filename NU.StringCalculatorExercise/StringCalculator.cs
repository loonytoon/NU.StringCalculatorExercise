using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NU.StringCalculatorExercise
{
    public class StringCalculator
    {
        private string _delimiter = ",|\n";
       

        public int Add(string numbers)
        {
            int total = 0;
            
            try
            {
                if (numbers != string.Empty)
                {
                    var result = SplitNumberString(numbers);
                    foreach (var value in result)
                    {
                        int number;
                        var success = int.TryParse(value, out number);
                        if (success)
                        {
                            total = Add(total, number);
                        }
                        else
                        {
                            throw new System.ArgumentException("None number found in Parameter", "numbers");
                        }
                    }
                    return total;
                }
                else
                {
                    return total;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /*
         * Add two integers
         */
        public int Add(int number1, int number2)
        {
            return number1 + number2;
        }


        public string[] SplitNumberString(string numbers)
        {
            //check for new line and delimiter
            string delimiter_pattern = "//(.{1})\n";
            Match match = Regex.Match(numbers, delimiter_pattern);
            if (match.Success && match.Groups.Count > 1)
            {
                //remove the pattern from the string
               Regex rgx = new Regex(delimiter_pattern);
               numbers = rgx.Replace(numbers, "");
                //set the delimiter to be the value of group 1.
                Group g = match.Groups[1];
                _delimiter = g.Value;
            }

            string[] result = Regex.Split(numbers, _delimiter, RegexOptions.IgnoreCase);

            return result;
        }
    }
}
