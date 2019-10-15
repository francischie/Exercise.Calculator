using System;
using System.Security.Authentication.ExtendedProtection;
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
                .AddTransient<IOperation, AddOperation>()
                .BuildServiceProvider();
            
            _addCalculator = ActivatorUtilities.GetServiceOrCreateInstance<CalculatorService>(services);
        }
        
        [Theory]
        [InlineData("2,,4,rrr,1001,6", null, false, 1000, "2+0+4+0+0+6 = 12")]
        [InlineData("2,,4,rrr,1001,6", null, false, 1000, "2+0+4+0+0+6 = 12")]
        [InlineData("2,,4,rrr,1001,-6", null, true, 1000, "2+0+4+0+0+(-6) = 0")]
        [InlineData("2,,4,rrr,1001,-6", null, true, 5000, "2+0+4+0+1001+(-6) = 1001")]
        [InlineData("2,,4,rrr#1001,-6", new[]{"#"}, true, 5000, "2+0+4+0+1001+(-6) = 1001")]
        [InlineData("20", null, false, 0, "20 = 20")]
        [InlineData("1,1000", null, false, 0, "1+1000 = 1001")]
        [InlineData("//[*][r]1r2,3*4,y,5" , null, false, 0, "1+2+3+4+0+5 = 15")]
        public void GetResultTest(string input, string[] delimiter, bool allowNegative, int max, string expectedResult)
        {
            var result = _addCalculator.Calculate(input, delimiter, allowNegative, max);
            
            Assert.Equal(expectedResult, result);
        }
        
        [Fact]
        public void GetResultNegativeExceptionTest()
        {
            var exception = Assert.Throws<ArgumentException>(() =>  _addCalculator.Calculate("1,-2,3,4,5,-6"));
            
            Assert.Equal("-2,-6", exception.Message);
        }

    }
}