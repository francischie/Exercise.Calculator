using System;
using System.Linq;

namespace Francis.Calculator.Services
{
    public class CalculatorService
    {
        private static readonly char[] Delimeter = new[] {'\n', ','};
        private const int MaxValue = 1000; 

        public double GetResult(string input)
        {
            var values = input.Split(Delimeter, StringSplitOptions.RemoveEmptyEntries)
                .Select(a => int.TryParse(a, out var result) ? result : 0)
                .ToList();

            var negativeValues = values
                .Where(a => a < 0)
                .ToList();
            
            if (negativeValues.Any(a => a < 0))
                throw new ArgumentException(string.Join(",",  negativeValues));
            
            var answer = values
                .Where(a => a <= 1000)
                .Sum();
 
            return answer;
        }
    }
}