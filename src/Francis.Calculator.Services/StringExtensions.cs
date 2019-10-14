using System;
using System.Linq;

namespace Francis.Calculator.Services
{
    public  static class StringExtensions
    {
        public static string[] SplitWithDelimiterExpression(this string input, char[] delimiter)
        {
            if (string.IsNullOrWhiteSpace(input)) return new string[0];

            if (input.StartsWith("//"))
            {
                var customDelimiter = input[2];
                input = input.Substring(3);
                delimiter = delimiter.Concat(new[] {customDelimiter}).ToArray();
            }
            
            return input.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}