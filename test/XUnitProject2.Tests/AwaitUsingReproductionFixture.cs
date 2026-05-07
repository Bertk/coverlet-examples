using System.Threading.Tasks;
using ClassLibrary2;
using Xunit;

namespace XUnitProject2.Tests;

public class AwaitUsingReproductionFixture
{
  [Fact]
  public async Task Execute_ShouldWork()
  {
    // Arrange
    AwaitUsingReproduction sut = new();

    // Act
    await sut.Execute();

    // Assert
    // No assert
  }
}
