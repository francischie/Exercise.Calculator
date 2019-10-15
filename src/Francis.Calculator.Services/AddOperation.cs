using System.Collections.Generic;
using System.Linq;

namespace Francis.Calculator.Services
{
    public class AddOperation  : IOperation
    {
        public string GetExpression(IEnumerable<int> values)
        {
            var list = values.ToList();
            
            var answer = list.Sum();

            var expression = string.Join("+", list.Select(a => a < 0 ? $"({a})" : a.ToString())) + " = " + answer;
            return expression;
        }
    }
}