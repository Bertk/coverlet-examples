using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Issue1968
{
  public class TheFunction
  {
#pragma warning disable IDE0390 // Make method synchronous
    public static async IAsyncEnumerable<T?> FunctionThatReturnsIAsyncEnumerable<T>([EnumeratorCancellation] CancellationToken cancellationToken)
#pragma warning restore IDE0390 // Make method synchronous
    {
      T?[] items = [default, default];
      foreach (T? item in items)
      {
        yield return !cancellationToken.IsCancellationRequested ? item : throw new OperationCanceledException();
      }
    }
  }
}
