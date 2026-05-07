// issue 1334
using System.Collections.Generic;

namespace ClassLibrary2;

public static class AsyncEnumerableBatchExtensionReproduction
{
  public static async IAsyncEnumerable<IAsyncEnumerable<T>> ExecuteReproduction<T>(this IAsyncEnumerable<T> source, int batchSize)
  {
    var enumerator = source.GetAsyncEnumerator();

    while (await enumerator.MoveNextAsync())
    {
      yield return YieldBatch(enumerator, batchSize);
    }
  }

  private static async IAsyncEnumerable<T> YieldBatch<T>(IAsyncEnumerator<T> source, int batchSize)
  {
    yield return source.Current;

    for (int i = 1; i < batchSize && await source.MoveNextAsync(); i++)
    {
      yield return source.Current;
    }
  }
}
