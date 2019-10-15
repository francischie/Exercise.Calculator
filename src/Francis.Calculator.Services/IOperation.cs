using System.Collections.Generic;

namespace Francis.Calculator.Services
{
    public interface IOperation
    {
        string GetExpression(IEnumerable<int> values);
    }
}