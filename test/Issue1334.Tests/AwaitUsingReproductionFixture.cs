using System.Threading.Tasks;
using ClassIssue1334;
using Xunit;

namespace Issue1334.Tests;

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
