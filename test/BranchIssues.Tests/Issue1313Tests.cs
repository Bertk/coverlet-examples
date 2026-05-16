using NUnit.Framework;
using static Issue1313.Repo1313;

namespace Issue1313.Tests
{
  public class Repo1313Test
  {

    [TestCase("123", 0, true)]
    [TestCase("123", 1, true)]
    [TestCase("123", 2, true)]
    [TestCase("123", 3, true)]
    [TestCase("123", 4, true)]
    [TestCase("123", 5, true)]
    [TestCase("123", 6, true)]
    [TestCase("123", 7, true)]
    [TestCase("123", 8, false)]
    [TestCase("123", 9, false)]
    [TestCase("321", 0, false)]
    [TestCase("321", 1, false)]
    [TestCase("321", 2, false)]
    [TestCase("321", 3, false)]
    [TestCase("321", 4, false)]
    [TestCase("321", 5, false)]
    [TestCase("321", 6, false)]
    [TestCase("321", 7, false)]
    [TestCase("321", 8, false)]
    [TestCase("321", 9, false)]
    public void TestString(string start, int num, bool expected)
    {
      // Arrange
      string str = start + num;

      // Act
      bool result = CoverletRepro.TestString(str);

      // Assert
      Assert.AreEqual(expected, result);
    }

    [TestCase("123", 0, true)]
    [TestCase("123", 1, true)]
    [TestCase("123", 2, true)]
    [TestCase("123", 3, true)]
    [TestCase("123", 4, true)]
    [TestCase("123", 5, true)]
    [TestCase("123", 6, true)]
    [TestCase("123", 7, true)]
    [TestCase("123", 8, false)]
    [TestCase("123", 9, false)]
    [TestCase("321", 0, false)]
    [TestCase("321", 1, false)]
    [TestCase("321", 2, false)]
    [TestCase("321", 3, false)]
    [TestCase("321", 4, false)]
    [TestCase("321", 5, false)]
    [TestCase("321", 6, false)]
    [TestCase("321", 7, false)]
    [TestCase("321", 8, false)]
    [TestCase("321", 9, false)]
    public void TestStringOld(string start, int num, bool expected)
    {
      // Arrange
      string str = start + num;

      // Act
      bool result = CoverletRepro.TestStringOld(str);

      // Assert
      Assert.AreEqual(expected, result);
    }
  }
}
