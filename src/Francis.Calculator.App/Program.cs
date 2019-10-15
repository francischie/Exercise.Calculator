using System;
using Francis.Calculator.Services;
using Microsoft.Extensions.DependencyInjection; 

namespace Francis.Calculator.App
{
    public static class Program
    {
        static void Main()
        {
            var services = new ServiceCollection()
                .AddTransient<IOperation, AddOperation>()
                .AddTransient<ICalculatorService, CalculatorService>()
                .BuildServiceProvider();
            
            var calculator = services.GetService<ICalculatorService>();
            do
            {
                var input = Console.ReadLine();
                Console.WriteLine($"Result : {calculator.Calculate(input)}");
            } while (true);
        }
        
        
    }
}