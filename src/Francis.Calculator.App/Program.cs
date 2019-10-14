using System;
using Francis.Calculator.Services;

namespace Francis.Calculator.App
{
    public static class Program
    {
        static void Main()
        {
            var calculator = new CalculatorService();
            var input = "1,1000";
            Console.WriteLine($"Result : {calculator.Calculate(input)}");
            Console.ReadLine();
        }
        
        
    }
}