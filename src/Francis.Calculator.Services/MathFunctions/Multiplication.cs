using System.Collections.Generic;
using System.Linq;

namespace Francis.Calculator.Services.MathFunctions
{
    public class Multiplication : BaseOperation
    {
        private const string Symbol = "*";
        public override string GetSymbol()
        {
            return Symbol;
        }

        public override int GetAnswer(IEnumerable<int> values)
        {
            return values.Aggregate((a, b) => a * b);
        }
    }
}