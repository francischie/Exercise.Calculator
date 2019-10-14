using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Francis.Calculator.Services
{
    public class CalculatorService
    {
        private static readonly char[] Delimeter = new[] {'\n', ','};

        public double GetResult(string input)
        {
            var values = input.Split(Delimeter, StringSplitOptions.RemoveEmptyEntries);
          
            var answer = values
                .Select(a => int.TryParse(a, out var result) ? result : 0)
                .Sum();
 
            return answer;
        }
    }
}