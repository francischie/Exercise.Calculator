using System;
using System.Linq;

namespace Francis.Calculator.Services
{
    public class CalculatorService 
    {
        public double GetResult(string input)
        {
            var values = input.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
          
            var answer = values
                .Select(a => int.TryParse(a, out var result) ? result : 0)
                .Sum();
 
            return answer;
        }
    }
}