using Xunit;

namespace Issue1334.Tests
{
  public class CoverletReproTest
  {
    [Theory]
    [InlineData("123", 0, true)]
    [InlineData("123", 1, true)]
    [InlineData("123", 2, true)]
    [InlineData("123", 3, true)]
    [InlineData("123", 4, true)]
    [InlineData("123", 5, true)]
    [InlineData("123", 6, true)]
    [InlineData("123", 7, true)]
    [InlineData("123", 8, false)]
    [InlineData("123", 9, false)]
    [InlineData("321", 0, false)]
    [InlineData("321", 1, false)]
    [InlineData("321", 2, false)]
    [InlineData("321", 3, false)]
    [InlineData("321", 4, false)]
    [InlineData("321", 5, false)]
    [InlineData("321", 6, false)]
    [InlineData("321", 7, false)]
    [InlineData("321", 8, false)]
    [InlineData("321", 9, false)]
    public void TestString(string start, ushort num, bool expected)
    {
      // Arrange
      string str = start + num;

      // Act
      bool result = ClassIssue1334.CoverletRepro.TestString(str);

      // Assert
      Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("123", 0, true)]
    [InlineData("123", 1, true)]
    [InlineData("123", 2, true)]
    [InlineData("123", 3, true)]
    [InlineData("123", 4, true)]
    [InlineData("123", 5, true)]
    [InlineData("123", 6, true)]
    [InlineData("123", 7, true)]
    [InlineData("123", 8, false)]
    [InlineData("123", 9, false)]
    [InlineData("321", 0, false)]
    [InlineData("321", 1, false)]
    [InlineData("321", 2, false)]
    [InlineData("321", 3, false)]
    [InlineData("321", 4, false)]
    [InlineData("321", 5, false)]
    [InlineData("321", 6, false)]
    [InlineData("321", 7, false)]
    [InlineData("321", 8, false)]
    [InlineData("321", 9, false)]
    public void TestStringOld(string start, ushort num, bool expected)
    {
      // Arrange
      string str = start + num;

      // Act
      bool result = ClassIssue1334.CoverletRepro.TestStringOld(str);

      // Assert
      Assert.Equal(expected, result);
    }
  }
}
