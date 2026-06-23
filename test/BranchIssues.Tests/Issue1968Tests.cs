using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Issue1968.Tests
{
  public class FunctionTests
  {
    [Test]
    public async Task FunctionThatReturnsIAsyncEnumerable_Test()
    {
      List<int> values = await TheFunction.FunctionThatReturnsIAsyncEnumerable<int>(TestContext.CurrentContext.CancellationToken)
          .ToListAsync(TestContext.CurrentContext.CancellationToken);

      Assert.That(values.Count, Is.EqualTo(2));
    }

    [Test]
    public void FunctionThatReturnsIAsyncEnumerable_ImmediateCancellation()
    {
      CancellationTokenSource cts = new();
      cts.Cancel();

      _ = Assert.ThrowsAsync<OperationCanceledException>(async () =>
           await TheFunction.FunctionThatReturnsIAsyncEnumerable<int>(cts.Token)
              .FirstAsync(cts.Token).ConfigureAwait(false));
      cts.Dispose();
    }

    [Test]
    public async Task FunctionThatReturnsIAsyncEnumerable_CancelAfterFirst()
    {
      CancellationTokenSource cts = new();

      await using IAsyncEnumerator<int> enumerator =
          TheFunction.FunctionThatReturnsIAsyncEnumerable<int>(cts.Token)
              .GetAsyncEnumerator(cts.Token);

      Assert.That(await enumerator.MoveNextAsync(), Is.True);

#pragma warning disable S6966 // Awaitable method should be used
      cts.Cancel();
#pragma warning restore S6966 // Awaitable method should be used

      _ = Assert.ThrowsAsync<OperationCanceledException>(async () =>
          await enumerator.MoveNextAsync());
      cts.Dispose();
    }
  }
}
