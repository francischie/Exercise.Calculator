using System.Collections.Generic;
using System.Linq;

namespace Francis.Calculator.Services.MathFunctions
{
    public abstract class BaseOperation : IOperation
    {
        public abstract string GetSymbol();
        public abstract int GetAnswer(IEnumerable<int> values);
        public string GetExpression(IEnumerable<int> values)
        {
            var list = values.ToList();
            if (list.Count == 0) list = new List<int> {0};
            var answer = GetAnswer(list);
            var expression = string.Join(GetSymbol(), list.Select(a => a < 0 ? $"({a})" : a.ToString())) + " = " + answer;
            return expression;
        }
    }
}