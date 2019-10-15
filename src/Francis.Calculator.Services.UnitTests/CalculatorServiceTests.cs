using System;
using Francis.Calculator.Services.Enums;
using Francis.Calculator.Services.Factories;
using Francis.Calculator.Services.MathFunctions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Francis.Calculator.Services.UnitTests
{
    public class CalculatorServiceTests
    {
        private readonly CalculatorService _addCalculator;

        public CalculatorServiceTests()
        {
            var services = new ServiceCollection()
                .AddTransient<IOperationFactory>(provider =>
                {
                    var factory = ActivatorUtilities.CreateInstance<OperationFactory>(provider);
                    factory.Add(Operations.Add, new Addition());
                    factory.Add(Operations.Subtract, new Subtraction());
                    factory.Add(Operations.Multiple, new Multiplication());
                    factory.Add(Operations.Divide, new Division());
                    return factory;
                })
                .AddSingleton<ICalculatorService, CalculatorService>()
                .BuildServiceProvider();
            
            _addCalculator = ActivatorUtilities.GetServiceOrCreateInstance<CalculatorService>(services);
        }
        
        [Theory]
        [InlineData("", Operations.Add, null, false, 1000, "0 = 0")]
        [InlineData("2,,4,rrr,1001,6", Operations.Add, null, false, 1000, "2+0+4+0+0+6 = 12")]
        [InlineData("2,,4,rrr,1001,-6", Operations.Add, null, true, 1000, "2+0+4+0+0+(-6) = 0")]
        [InlineData("2,,4,rrr,1001,-6", Operations.Add, null, true, 5000, "2+0+4+0+1001+(-6) = 1001")]
        [InlineData("2,,4,rrr#1001,-6", Operations.Add, new[]{"#"}, true, 5000, "2+0+4+0+1001+(-6) = 1001")]
        [InlineData("20", Operations.Add, null, false, 0, "20 = 20")]
        [InlineData("1,1000", Operations.Add, null, false, 0, "1+1000 = 1001")]
        [InlineData("//[*][r]1r2,3*4,y,5", Operations.Add , null, false, 0, "1+2+3+4+0+5 = 15")]
        [InlineData("//[*][r]1r2,3*4,y,5", Operations.Subtract, null, false, 0, "1-2-3-4-0-5 = -13")]
        [InlineData("//[*][r]1r2,3*4,y,5", Operations.Multiple, null, false, 0, "1*2*3*4*0*5 = 0")]
        [InlineData("//[*]1*2,3*4,5,6", Operations.Multiple, null, false, 0, "1*2*3*4*5*6 = 720")]
        [InlineData("720,6,5,4,3,2", Operations.Divide, null, false, 0, "720/6/5/4/3/2 = 1")]
        public void GetResultTest(string input, Operations operations, string[] delimiter, bool allowNegative, int max, string expectedResult)
        {
            var result = _addCalculator.Calculate(input, operations, delimiter, allowNegative, max);
            
            Assert.Equal(expectedResult, result);
        }
        
        [Fact]
        public void GetResultNegativeExceptionTest()
        {
            var exception = Assert.Throws<ArgumentException>(() =>  _addCalculator.Calculate("1,-2,3,4,5,-6", Operations.Add));
            
            Assert.Equal("-2,-6", exception.Message);
        }

    }
}