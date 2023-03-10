using TDD;

namespace WorkshopTests
{
    public class StringCalculatorTests
    {
        [Fact]
        public void EmptyStringReturnZero()
        {
            int result = StringCalculator.Calculate("");
            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("12", 12)]
        [InlineData("0", 0)]
        [InlineData("121", 121)]
        [InlineData("42", 42)]
        public void StringWithNumberReturnsItsValue(string str, int expected)
        {
            int result = StringCalculator.Calculate(str);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("12,10", 22)]
        [InlineData("3,2", 5)]
        [InlineData("121,3", 124)]
        [InlineData("30,42", 72)]
        public void StringWithTwoNumbersWithCommaSeparatorReturnsSum(string str, int expected)
        {
            int result = StringCalculator.Calculate(str);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("12\n10", 22)]
        [InlineData("2\n2", 4)]
        [InlineData("121\n3", 124)]
        [InlineData("30\n42", 72)]
        public void StringWithTwoNumbersWithNewLineSeparatorReturnsSum(string str, int expected)
        {
            int result = StringCalculator.Calculate(str);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("12\n10,3", 25)]
        [InlineData("0,3\n2", 5)]
        [InlineData("121\n3", 124)]
        [InlineData("30\n42,10,10", 92)]
        public void StringWithMultipleNumbersWithNewLineOrCommaSeparatorReturnsSum(string str, int expected)
        {
            int result = StringCalculator.Calculate(str);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("12\n1001,3", 15)]
        [InlineData("0,5001\n3", 3)]
        [InlineData("121\n1000\n3", 1124)]
        [InlineData("1250", 0)]
        public void StringWithNumbersBiggerThanThousandIgnored(string str, int expected)
        {
            int result = StringCalculator.Calculate(str);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("-12\n1001,3")]
        [InlineData("-2,5001\n3")]
        [InlineData("121\n-1000\n3")]
        [InlineData("-1250")]
        public void StringWithNegativeNumbersThrowException(string str)
        {
            Assert.Throws<ArgumentException>(() => StringCalculator.Calculate(str));
        }

        [Theory]
        [InlineData("//X\n12\n1001X3", 15)]
        [InlineData("//%\n0,5001%3", 3)]
        [InlineData("//$\n121$1000\n3", 1124)]
        [InlineData("//C\n1250", 0)]
        [InlineData("// \n10 20,3\n4", 37)]
        public void StringsWithOneCustomNumberSeparator(string str, int expected)
        {
            int result = StringCalculator.Calculate(str);
            Assert.Equal(expected, result);
        }
    }
}