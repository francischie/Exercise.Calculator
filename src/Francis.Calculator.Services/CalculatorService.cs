using System;
using System.Linq;

namespace Francis.Calculator.Services
{
    public class CalculatorService : ICalculatorService
    {
        private static readonly char[] Delimiter = {'\n', ','};
        private readonly IOperation _operation;

        public CalculatorService(IOperation operation)
        {
            _operation = operation;
        }

        public string Calculate(string input, string[] alternateDelimiter = null, bool allowNegative = false, int maxValue  = 0)
        {
            var stringDelimiter = Delimiter.Select(a => a.ToString())
                .ToArray();
                
            if (alternateDelimiter != null )
                stringDelimiter = stringDelimiter.Concat(alternateDelimiter).ToArray();
            
            var values = input.SplitWithDelimiterExpression(stringDelimiter)
                .Select(a => int.TryParse(a, out var result) ? result : 0)
                .Select(a => (maxValue > 0) && a > maxValue ? 0 : a)
                .ToList();

            if (allowNegative == false)
            {
                var negativeValues = values
                    .Where(a => a < 0)
                    .ToList();

                if (negativeValues.Any(a => a < 0))
                    throw new ArgumentException(string.Join(",", negativeValues));
            }
            
            return _operation.GetExpression(values);
        }

       
        
    }
}