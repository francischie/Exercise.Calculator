using System.Collections.Generic;
using Francis.Calculator.Services.Enums;
using Francis.Calculator.Services.MathFunctions;

namespace Francis.Calculator.Services.Factories
{
    public class OperationFactory : IOperationFactory
    {
        private readonly Dictionary<Operations, IOperation> _operations;

        public OperationFactory()
        {
            _operations = new Dictionary<Operations, IOperation>();
        }
        public void Add(Operations name, IOperation operation)
        {
            _operations.Add(name, operation);
        }

        public IOperation GetOperation(Operations name)
        {
            return _operations.TryGetValue(name, out var found) ? found : null;
        }
        
    }
}