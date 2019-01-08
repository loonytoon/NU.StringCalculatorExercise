using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

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
                if (numbers == string.Empty) return total;
                var result = GetNumbersFromString(numbers);
                foreach (var value in result)
                {
                    total = Add(value, total);                  
                }
                return total;
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

        public List<int> GetNumbersFromString(string numbers)
        {
            List<int> numberInts = new List<int>();
            StringBuilder negatives = new StringBuilder("");

            string[] numberStrings = SplitNumberString(numbers);

            foreach (var value in numberStrings)
            {
                int number;
                var success = int.TryParse(value, out number);

                if (!success)
                {
                    throw new ArgumentException("None number found in Parameter", "numbers");
                }
                if (number >= 0 && number <= 1000)
                {
                    numberInts.Add(number);
                }
                else if (number < 0)
                {
                    if (negatives.Length > 0)
                    {
                        negatives.Append(',');
                    }
                    negatives.Append(value);
                }
            }

            if (negatives.Length > 0)
            {
                String msg = $"negatives not allowed: {negatives}";
                throw new Exception(msg);
            }

            return numberInts;
        }

        public string CheckForDifferentDelimiters(string numbers)
        {
            string delimiter_pattern = "//(.{1})\n|//\\[(.+)\\]\n";
            Match match = Regex.Match(numbers, delimiter_pattern);

            if (match.Success && match.Groups.Count > 1)
            {
                //remove the pattern from the string
                Regex rgx = new Regex(delimiter_pattern);
                numbers = rgx.Replace(numbers, "");
                //set the delimiter to be the value of group that contains the match.
                for (var i = 1; i < match.Groups.Count; i++)
                {
                    Group g = match.Groups[i];
                    if (!string.IsNullOrEmpty(g.Value))
                    {
                        _delimiter = Regex.Escape(g.Value);
                     }
                }
            }

            return numbers;

            
        }
        public string[] SplitNumberString(string numbers)
        {
            //check for new line and delimiter
            numbers = CheckForDifferentDelimiters(numbers);

            string[] result = Regex.Split(numbers, _delimiter, RegexOptions.IgnoreCase);

            return result;
        }
    }
}
