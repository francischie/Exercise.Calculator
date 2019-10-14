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
        [InlineData("2,,4,rrr,1001,6", "2+0+4+0+0+6 = 12")]
        [InlineData("20", "20 = 20")]
        [InlineData("1,1000", "1+1000 = 1001")]
        [InlineData("//[*][r]1r2,3*4,y,5", "1+2+3+4+0+5 = 15")]
        public void GetResultTest(string input, string expectedResult)
        {
            var result = _addCalculator.Calculate(input);
            
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