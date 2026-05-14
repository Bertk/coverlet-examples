// issue 1334
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassIssue1334;

public class AwaitForeachReproduction2
{
  public virtual async Task Execute<T>(IAsyncEnumerable<int> messages)
  {
    await foreach (int obj in messages)
    {
      await Task.Delay(1);
    }
  }
}
