namespace Francis.Calculator.Services
{
    public interface ICalculatorService
    {
        string Calculate(string input, string[] alternateDelimiter = null, bool allowNegative = false, int maxValue  = 0);
    }
}