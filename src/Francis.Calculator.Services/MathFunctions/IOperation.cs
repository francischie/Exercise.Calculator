using System.Collections.Generic;

namespace Francis.Calculator.Services.MathFunctions
{
    public interface IOperation
    {
        string GetSymbol();
        string GetExpression(IEnumerable<int> values);
        int GetAnswer(IEnumerable<int> values);
    }
}