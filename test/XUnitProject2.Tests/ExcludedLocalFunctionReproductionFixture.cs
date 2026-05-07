using ClassLibrary2;
using Xunit;

namespace XUnitProject2.Tests;

public class ExcludedLocalFunctionReproductionFixture
{
  [Fact]
  public void Execute_ShouldWork()
  {
    // Arrange
    ExcludedLocalFunctionReproduction sut = new();

    // Act
    sut.SomethingThatIsUsingALocalFunction();
  }
}
