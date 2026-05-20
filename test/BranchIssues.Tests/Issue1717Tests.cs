using System;
using NUnit.Framework;
using Issue1717;

namespace Issue1717Tests;

public class Issue1717Tests
{

  [Test]
  public void TestMethodAsync()
  {
    var sut = new Class1717();
    Assert.ThrowsAsync<Exception>(async () => await sut.ThrowMethodWithMessageAsync("Test Message"));
  }
}
