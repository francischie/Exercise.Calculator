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
        [InlineData("1,2,3,4,5,6,7,8,9,10,11,12", 78)]
        public void GetResultTest(string input, int expectedResult)
        {
            var result = _addCalculator.GetResult(input);
            
            Assert.Equal(expectedResult, result);
        }

    }
}