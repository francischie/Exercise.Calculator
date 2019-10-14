using System;
using Francis.Calculator.Services;

namespace Francis.Calculator.App
{
    public static class Program
    {
        static void Main()
        {
            var calculator = new CalculatorService();
            var input = "1,5000";
            Console.WriteLine($"The sum of {input} is : {calculator.GetResult(input)}");
            Console.ReadLine();
        }
        
        
    }
}