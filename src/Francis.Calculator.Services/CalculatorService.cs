using System;
using System.Linq;

namespace Francis.Calculator.Services
{
    public class CalculatorService
    {
        private static readonly char[] Delimiter = {'\n', ','};
        private const int MaxValue = 1000; 

        public string Calculate(string input)
        {
            var values = input.SplitWithDelimiterExpression(Delimiter)
                .Select(a => int.TryParse(a, out var result) ? result : 0)
                .Select(a => a > MaxValue ? 0 : a)
                .ToList();

            var negativeValues = values
                .Where(a => a < 0)
                .ToList();
            
            if (negativeValues.Any(a => a < 0))
                throw new ArgumentException(string.Join(",",  negativeValues));
            
            var answer = values.Sum();

            var expression = string.Join("+", values) + " = " + answer;
            return expression;
        }

       
        
    }
}