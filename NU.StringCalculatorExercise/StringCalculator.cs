using System;
using System.Collections.Generic;
using System.Globalization;
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
            
            string delimiter_pattern = "//(.{1})\n";
            string delimiter_present = "//.+?\n";

            MatchCollection matches = Regex.Matches(numbers, delimiter_pattern);

            if (matches.Count == 0)
            {
                //try the multi delimiter match
                Regex rgx = new Regex(delimiter_present);
                Match present = rgx.Match(numbers);
                if (present.Success)
                {
                    delimiter_pattern = "\\[(.+?)\\]";
                    matches = Regex.Matches(numbers, delimiter_pattern);
                }
            }

            if (matches.Count > 0)
            {
                _delimiter = "";
                //remove the pattern from the string
                Regex rgx = new Regex(delimiter_present);
                numbers = rgx.Replace(numbers, "");
            }
            foreach (Match match in matches)
            {
                if (match.Success && match.Groups.Count > 1)
                {
                    //set the delimiter to be the value of group that contains the match.
                    //ignore first value it contains he match pattern
                    for (var i = 1; i < match.Groups.Count; i++)
                    {
                        Group g = match.Groups[i];
                        if (!string.IsNullOrEmpty(g.Value))
                        {
                            if (_delimiter.Length > 0) _delimiter = $"{_delimiter}|";
                            _delimiter = $"{_delimiter}{Regex.Escape(g.Value)}";
                        }
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
