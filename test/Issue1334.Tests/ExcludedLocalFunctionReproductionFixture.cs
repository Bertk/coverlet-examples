using ClassIssue1334;
using Xunit;

namespace Issue1334.Tests;

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
