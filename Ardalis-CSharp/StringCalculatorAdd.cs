using System;
using Xunit;

namespace StringCalcKata
{
    public class StringCalculatorAdd
    {
        private StringCalculator _calc = new StringCalculator();
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Returns0GivenEmptyValues(string numbers)
        {
            int result = _calc.Add(numbers);

            Assert.Equal(0, result);


        }

        [Theory]
        [InlineData("1")]
        [InlineData("10")]
        [InlineData("100")]
        public void ReturnsNumberGivenSingleNumber(string number)
        {
            int result = _calc.Add(number);

            Assert.Equal(Int32.Parse(number), result);
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("10,20", 30)]
        public void ReturnsSumGivenTwoNumbers(string numbers, int expectedSum)
        {
            int result = _calc.Add(numbers);

            Assert.Equal(expectedSum, result);
        }

        [Theory]
        [InlineData("1,2,3", 6)]
        [InlineData("1,2,3,4,5", 15)]
        public void ReturnsSumGivenThreeOrMoreNumbers(string numbers, int expectedSum)
        {
            int result = _calc.Add(numbers);

            Assert.Equal(expectedSum, result);
        }

        [Theory]
        [InlineData("1\n2,3", 6)]
        public void ReturnsSumGivenNewLinesAndCommaDelimiters(string numbers, int expectedSum)
        {
            int result = _calc.Add(numbers);

            Assert.Equal(expectedSum, result);
        }

        [Theory]
        [InlineData("//*\n1*2,3", 6)]
        public void ReturnsSumGivenUserSpecifiedDelimiter(string numbers, int expectedSum)
        {
            int result = _calc.Add(numbers);

            Assert.Equal(expectedSum, result);
        }

        [Theory]
        [InlineData("1,-2", "-2")]
        [InlineData("-1", "-1")]
        [InlineData("1,-2,-3", "-2,-3")]
        public void ThrowsGivenNegativeInput(string numbers, string negString)
        {
            var result = Record.Exception(() => _calc.Add(numbers));

            Assert.IsAssignableFrom<NegativeNotAllowedException>(result);
            Assert.Equal($"Negatives not allowed: {negString}", result.Message);
        }

        [Theory]
        [InlineData("1001,2", 2)]
        [InlineData("1000,2", 1002)]
        public void IgnoresNumbersOver1000(string numbers, int expectedSum)
        {
            int result = _calc.Add(numbers);

            Assert.Equal(expectedSum, result);
        }

        [Theory]
        [InlineData("//[***]\n1***2***3", 6)]
        [InlineData("//[*][**][***]\n1*2**3***4", 10)]
        public void SupportsLongDelimiters(string numbers, int expectedSum)
        {
            int result = _calc.Add(numbers);

            Assert.Equal(expectedSum, result);
        }

    }
}
