using System;
using Xunit;

namespace Francis.Calculator.Services.UnitTests
{
    public class CalculatorServiceTests
    {
        private readonly CalculatorService _addCalculator;

        public CalculatorServiceTests()
        {
            _addCalculator = new CalculatorService();
        }
        
        [Theory]
        [InlineData("20", 20)]
        [InlineData("1,5000", 5001)]
        [InlineData("4,-3", 1)]
        [InlineData("", 0)]
        [InlineData("5, tytyt", 5)]
        public void GetResultTest(string input, int expectedResult)
        {
            var result = _addCalculator.GetResult(input);
            
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GetResultExceptionTest()
        {
            const string input = "1,1,1";

            Assert.Throws<ArgumentException>(() => _addCalculator.GetResult(input));
        }
    }
}