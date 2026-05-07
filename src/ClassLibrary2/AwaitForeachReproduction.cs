// issue 1334
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassLibrary2;

public class AwaitForeachReproduction
{
  public async Task<int> Execute()
  {
    int sum = 0;

    await foreach (int result in AsyncEnumerable())
    {
      sum += result;
    }

    return sum;
  }

  private async IAsyncEnumerable<int> AsyncEnumerable()
  {
    for (int i = 0; i < 100; i++)
    {
      await Task.Delay(10);
      yield return i;
    }
  }
}
