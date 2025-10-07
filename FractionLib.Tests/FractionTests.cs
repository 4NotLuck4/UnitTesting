using FluentAssertions;

namespace FractionLib.Tests
{
    public class FractionTests
    {
        [Fact]
        public void Constructor_WithValidArgs_ShouldCreateFraction()
        {
            var fraction = new Fraction(1, 2);

            fraction.Numerator.Should().Be(1);
            fraction.Denominator.Should().Be(2);
        }

        [Theory]
        [InlineData(2, 4, 1, 2)]
        [InlineData(3, 9, 1, 3)]
        [InlineData(5, 10, 1, 2)]
        public void Constructor_ShouldSimplifyFraction(int num, int den, int expectedNum, int expectedDen)
        {
            var fraction = new Fraction(num, den);

            fraction.Numerator.Should().Be(expectedNum);
            fraction.Denominator.Should().Be(expectedDen);
        }

        [Theory]
        [InlineData(1, 2, 1, 2, 1, 1)]
        [InlineData(1, 3, 2, 3, 1, 1)]
        [InlineData(1, 4, 1, 4, 1, 2)]
        public void Addition_ShouldReturnCorrectResult(int num1, int den1, int num2, int den2, int expectedNum, int expectedDen)
        {
            var a = new Fraction(num1, den1);
            var b = new Fraction(num2, den2);

            var result = a + b;

            result.Should().Be(new Fraction(expectedNum, expectedDen));
        }

        [Theory]
        [InlineData(1, 2, 1, 3, 1, 6)]
        [InlineData(3, 4, 1, 4, 1, 2)]
        public void Subtraction_ShouldReturnCorrectResult(int num1, int den1, int num2, int den2, int expectedNum, int expectedDen)
        {
            var a = new Fraction(num1, den1);
            var b = new Fraction(num2, den2);

            var result = a - b;

            result.Should().Be(new Fraction(expectedNum, expectedDen));
        }

        [Theory]
        [InlineData(1, 2, 2, 3, 1, 3)]
        [InlineData(3, 4, 2, 5, 3, 10)]
        public void Multiplication_ShouldReturnCorrectResult(int num1, int den1, int num2, int den2, int expectedNum, int expectedDen)
        {
            var a = new Fraction(num1, den1);
            var b = new Fraction(num2, den2);

            var result = a * b;

            result.Should().Be(new Fraction(expectedNum, expectedDen));
        }

        [Theory]
        [InlineData(1, 2, 3, 4, 2, 3)]
        [InlineData(3, 4, 1, 2, 3, 2)]
        public void Division_ShouldReturnCorrectResult(int num1, int den1, int num2, int den2, int expectedNum, int expectedDen)
        {
            var a = new Fraction(num1, den1);
            var b = new Fraction(num2, den2);

            var result = a / b;

            result.Should().Be(new Fraction(expectedNum, expectedDen));
        }

        [Fact]
        public void ToDouble_ShouldReturnCorrectValue()
        {
            var fraction = new Fraction(1, 2);

            var result = fraction.ToDouble();

            result.Should().Be(0.5);
        }

        [Fact]
        public void ToString_ShouldReturnCorrectFormat()
        {
            var fraction = new Fraction(3, 4);

            fraction.ToString().Should().Be("3/4");
        }

        [Fact]
        public void Equals_WithSameValues_ShouldReturnTrue()
        {
            var a = new Fraction(1, 2);
            var b = new Fraction(1, 2);

            a.Equals(b).Should().BeTrue();
        }

        [Fact]
        public void Equals_WithDifferentValues_ShouldReturnFalse()
        {
            var a = new Fraction(1, 2);
            var b = new Fraction(2, 3);

            a.Equals(b).Should().BeFalse();
        }
    }
}
