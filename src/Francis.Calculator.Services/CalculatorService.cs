using System;
using System.Linq;

namespace Francis.Calculator.Services
{
    public class CalculatorService 
    {
        public double GetResult(string input)
        {
            var values = input.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            
            if (values.Length > 2)
                throw new ArgumentException("Maximum of 2 numbers only.");
        
            var answer = values
                .Select(a => int.TryParse(a, out var result) ? result : 0)
                .Sum();
 
            return answer;
        }
    }
}