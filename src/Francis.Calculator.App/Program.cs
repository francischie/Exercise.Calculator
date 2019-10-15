using System;
using System.Diagnostics.CodeAnalysis;
using Francis.Calculator.Services;
using Francis.Calculator.Services.Enums;
using Francis.Calculator.Services.Factories;
using Francis.Calculator.Services.MathFunctions;
using Microsoft.Extensions.DependencyInjection; 

namespace Francis.Calculator.App
{
    [ExcludeFromCodeCoverage]
    public static class Program
    {
        static void Main()
        {
            var services = new ServiceCollection()
                .AddTransient<IOperationFactory>(provider =>
                {
                    var factory = ActivatorUtilities.CreateInstance<OperationFactory>(provider);
                    factory.Add(Operations.Add, new Addition());
                    factory.Add(Operations.Subtract, new Subtraction());
                    return factory;
                })
                .AddSingleton<ICalculatorService, CalculatorService>()
                .BuildServiceProvider();
            
            var calculator = services.GetService<ICalculatorService>();
            do
            {
                var input = Console.ReadLine();
                Console.WriteLine($"Result : {calculator.Calculate(input, Operations.Add)}");
            } while (true);
        }
        
        
    }
}