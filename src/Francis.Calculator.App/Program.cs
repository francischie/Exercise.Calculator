using System;
using Francis.Calculator.Services;

namespace Francis.Calculator.App
{
    public static class Program
    {
        static void Main()
        {
            var calculator = new CalculatorService();
            do
            {
                var input = Console.ReadLine();
                Console.WriteLine($"Result : {calculator.Calculate(input)}");
            } while (true);
        }
        
        
    }
}