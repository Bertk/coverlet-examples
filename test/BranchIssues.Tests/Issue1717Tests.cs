using System;
using NUnit.Framework;

namespace Issue1717.Tests;

public class Class1717Tests
{

  [Test]
  public void TestMethodAsync()
  {
    Class1717 sut = new();
    _ = Assert.ThrowsAsync<Exception>(async () => await sut.ThrowMethodWithMessageAsync("Test Message").ConfigureAwait(false));
  }
}
