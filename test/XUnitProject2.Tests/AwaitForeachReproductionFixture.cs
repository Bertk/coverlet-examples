using System.Threading.Tasks;
using ClassLibrary2;
using Xunit;

namespace XUnitProject2.Tests;

public class AwaitForeachReproductionFixture
{
  [Fact]
  public async Task Execute_ShouldWork()
  {
    // Arrange
    AwaitForeachReproduction sut = new();

    // Act
    int result = await sut.Execute();

    // Assert
    Assert.Equal(4950, result);
  }
}
