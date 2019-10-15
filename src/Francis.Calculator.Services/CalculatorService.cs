using System;
using System.Linq;
using Francis.Calculator.Services.Enums;
using Francis.Calculator.Services.Extensions;
using Francis.Calculator.Services.Factories;

namespace Francis.Calculator.Services
{
    public class CalculatorService : ICalculatorService
    {
        private static readonly char[] Delimiter = {'\n', ','};
        private readonly IOperationFactory _operationFactory;
        
        public CalculatorService(IOperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        /// <summary>
        /// Function for parsing string and calculate the equivalent value.
        /// </summary>
        /// <param name="input">String to be parse. Expression delimiter is allowed in the beginning of the value with format of [{value}].</param>
        /// <param name="operation">Supported operation is addition, subtraction, multiplication and division.</param>
        /// <param name="alternateDelimiter">Additional delimiter aside from build-in comma and new line characters.</param>
        /// <param name="allowNegative">Allow negative value. Default to false.</param>
        /// <param name="maxValue">Maximum allowed value. Defaulted to 0 means no limit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public string Calculate(string input, Operations operation, string[] alternateDelimiter = null,
            bool allowNegative = false, int maxValue = 0)
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

                if (negativeValues.Any())
                    throw new ArgumentException(string.Join(",", negativeValues));
            }
            
            
            return _operationFactory.GetOperation(operation).GetExpression(values);
        }

       
        
    }
}