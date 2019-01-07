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
        private string _delimiter = ",";
       

        public int Add(string numbers)
        {
            int total = 0;
            try
            {
                if (numbers != string.Empty)
                {
                    string[] result = Regex.Split(numbers, _delimiter, RegexOptions.IgnoreCase);
                    foreach (var value in result)
                    {
                        int number;
                        bool success = int.TryParse(value, out number);
                        if (success)
                        {
                            total = Add(total, number);
                        }
                        else
                        {
                            throw new System.ArgumentException("No numbers found in Parameter", "numbers");
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

        public int Add(int number1, int number2)
        {
            return number1 + number2;
        }
    }
}
