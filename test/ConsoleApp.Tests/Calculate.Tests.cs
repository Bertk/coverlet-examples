using Xunit;

namespace ConsoleApp.Tests;

public class CalculateTests
{
    [Theory]
    [InlineData(5, 3, 8)]
    [InlineData(-1, 1, 0)]
    [InlineData(0, 0, 0)]
    [InlineData(2.5, 3.5, 6)]
    public void Add_ReturnsCorrectSum(double n1, double n2, double expected)
    {
        // Act
        double result = Calculate.Add(n1, n2);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(5, 3, 2)]
    [InlineData(1, 1, 0)]
    [InlineData(0, 5, -5)]
    [InlineData(10.5, 3.5, 7)]
    public void Subtract_ReturnsCorrectDifference(double n1, double n2, double expected)
    {
        // Act
        double result = Calculate.Subtract(n1, n2);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(5, 3, 15)]
    [InlineData(-2, 4, -8)]
    [InlineData(0, 100, 0)]
    [InlineData(2.5, 4, 10)]
    public void Multiply_ReturnsCorrectProduct(double n1, double n2, double expected)
    {
        // Act
        double result = Calculate.Multiply(n1, n2);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(10, 2, 5)]
    [InlineData(9, 3, 3)]
    [InlineData(-8, 4, -2)]
    [InlineData(7.5, 2.5, 3)]
    public void Divide_ReturnsCorrectQuotient(double n1, double n2, double expected)
    {
        // Act
        double result = Calculate.Divide(n1, n2);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Divide_ByZero_ReturnsPositiveInfinity()
    {
        // Act
        double result = Calculate.Divide(10, 0);

        // Assert
        Assert.Equal(double.PositiveInfinity, result);
    }

    [Fact]
    public void Divide_ZeroByZero_ReturnsNaN()
    {
        // Act
        double result = Calculate.Divide(0, 0);

        // Assert
        Assert.True(double.IsNaN(result));
    }
}
