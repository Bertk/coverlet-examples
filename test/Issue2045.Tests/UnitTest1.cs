using Xunit;
using System;
using ClassIssue2045;
namespace Issue2045.Tests
{
  public class UnitTest1
  {
    [Fact]
    public void Test2045DoesNotReturn1()
    {
      Assert.Throws<ArgumentException>(() => CoverletRepro.TestCapacity(100));
    }

  [Fact]
    public void Test2045DoesReturn2()
    {
      //Act
      Exception exception = Record.Exception(() => CoverletRepro.TestCapacity(16));

      //Assert
      Assert.Null(exception);
    }

  }
}
