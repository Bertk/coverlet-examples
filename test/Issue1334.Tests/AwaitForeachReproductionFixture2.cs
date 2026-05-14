using System.Collections.Generic;
using System.Threading.Tasks;
using ClassIssue1334;
using Xunit;

namespace Issue1334.Tests;

public class AwaitForeachReproductionFixture2
{
  [Fact]
  public async Task Execute_ShouldWork()
  {
    // Arrange
    AwaitForeachReproduction2 sut = new();

    // Act
    await sut.Execute<object>(RangeAsync(1, 3));
  }

  static async IAsyncEnumerable<int> RangeAsync(int start, int count)
  {
    for (int i = 0; i < count; i++)
    {
      await Task.Delay(i);
      yield return start + i;
    }
  }
}
