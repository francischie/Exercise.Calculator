using Francis.Calculator.Services.Enums;
using Francis.Calculator.Services.MathFunctions;

namespace Francis.Calculator.Services.Factories
{
    public interface IOperationFactory
    {
        void Add(Operations name, IOperation operation);
        IOperation GetOperation(Operations name);
    }
}