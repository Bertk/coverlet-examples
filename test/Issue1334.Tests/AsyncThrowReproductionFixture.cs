using System;
using System.Threading.Tasks;
using ClassIssue1334;
using Xunit;

namespace Issue1334.Tests;

public class AsyncThrowReproductionFixture
{
  [Fact]
  public async Task Execute_ShouldWork_Exception()
  {
    // Arrange
    AsyncThrowReproduction sut = new();

    // Act
    async Task TestFunc() => await sut.Execute(true);

    // Assert
    await Assert.ThrowsAsync<InvalidOperationException>(TestFunc);
  }

  [Fact]
  public async Task Execute_ShouldWork_NoException()
  {
    // Arrange
    AsyncThrowReproduction sut = new();

    // Act
    await sut.Execute(false);
  }
}
