using System;
using ClassIssue1334;
using Xunit;

namespace Issue1334.Tests;

public class ThrowExceptionViaMethodReproductionFixture
{
  [Fact]
  public void EnsureNull_ShouldNotThrowException_WhenNull()
  {
    // Arrange
    Action action = () => ThrowExceptionViaMethodReproduction.EnsureNull(null);

    // Act
    Exception exception = Record.Exception(action);

    // assert
    Assert.Null(exception);
  }

  [Fact]
  public void EnsureNull_ShouldThrowException_WhenNotNull()
  {
    // Arrange & Act
    Action action = () => ThrowExceptionViaMethodReproduction.EnsureNull(2);

    // Assert
    Assert.Throws<CustomException>(action);
  }
}
