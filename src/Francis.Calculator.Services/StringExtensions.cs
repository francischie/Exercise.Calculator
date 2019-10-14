using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Francis.Calculator.Services
{
    public  static class StringExtensions
    {
        public static string[] SplitWithDelimiterExpression(this string input, char[] delimiter)
        {
            if (string.IsNullOrWhiteSpace(input)) return new string[0];

            var stringDelimiter = delimiter.Select(a => a.ToString()).ToArray();

            if (input.StartsWith("//"))
            {
                var pattern = @"\[(.*?)\]";
                var matches = Regex.Matches(input, pattern)
                    .Select(a => a.ToString().Replace("[","").Replace("]",""))
                    .Take(1);
                var lastIndex = input.LastIndexOf(']');
                input = input.Substring(lastIndex > -1 ? lastIndex + 1 : 0);

                stringDelimiter= matches.Concat(delimiter.Select(a => a.ToString())).ToArray();
            }
            
            return input.Split(stringDelimiter.ToArray(), StringSplitOptions.RemoveEmptyEntries);
        }
    }
}