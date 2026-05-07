using System.Threading.Tasks;
using ClassLibrary2;
using Xunit;

namespace XUnitProject2.Tests;

public class AwaitUsingReturnInIfStatementReproductionFixture
{
  [Fact]
  public async Task ExecuteReproduction_HasUncoveredLine()
  {
    // Arrange
    AwaitUsingReturnInIfStatementReproduction sut = new();

    // Act
    int resultTrue = await sut.ExecuteReproduction(true);
    int resultFalse = await sut.ExecuteReproduction(false);

    // Assert
    Assert.Equal(3, resultTrue);
    Assert.Equal(1, resultFalse);
  }

  [Fact]
  public async Task ExecuteNoIfStatement_AllCovered()
  {
    // Arrange
    AwaitUsingReturnInIfStatementReproduction sut = new();

    // Act
    int result = await sut.ExecuteNoIfStatement();

    // Assert
    Assert.Equal(3, result);
  }

  [Fact]
  public async Task ExecuteAwaitUsingWithBraces_AllCovered()
  {
    // Arrange
    AwaitUsingReturnInIfStatementReproduction sut = new();

    // Act
    int resultTrue = await sut.ExecuteAwaitUsingWithBraces(true);
    int resultFalse = await sut.ExecuteAwaitUsingWithBraces(false);

    // Assert
    Assert.Equal(3, resultTrue);
    Assert.Equal(1, resultFalse);
  }

  [Fact]
  public async Task ExecuteUsingWithoutAwait_AllCovered()
  {
    // Arrange
    AwaitUsingReturnInIfStatementReproduction sut = new();

    // Act
    int resultTrue = await sut.ExecuteUsingWithoutAwait(true);
    int resultFalse = await sut.ExecuteUsingWithoutAwait(false);

    // Assert
    Assert.Equal(3, resultTrue);
    Assert.Equal(1, resultFalse);
  }

  [Fact]
  public async Task ExecuteReturnOutsideIfStatement_AllCovered()
  {
    // Arrange
    AwaitUsingReturnInIfStatementReproduction sut = new();

    // Act
    int resultTrue = await sut.ExecuteReturnOutsideIfStatement(true);
    int resultFalse = await sut.ExecuteReturnOutsideIfStatement(false);

    // Assert
    Assert.Equal(3, resultTrue);
    Assert.Equal(1, resultFalse);
  }
}
