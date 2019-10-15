using Francis.Calculator.Services.Enums;

namespace Francis.Calculator.Services
{
    public interface ICalculatorService
    {
        string Calculate(string input, Operations operation, string[] alternateDelimiter = null,
            bool allowNegative = false, int maxValue = 0);
    }
}