using NUnit.Framework;
using System.Threading.Tasks;

namespace Issue1561.Tests;

public class MyClassTests
{
  [Test]
  public async Task TestAsyncMethod()
  {
    MyAsyncClass obj = new();
    int result = await obj.DoAsyncAction();
    Assert.AreEqual(1, result);
  }

  [Test]
  public void Constructor()
  {
    MyRecord myRecord = new(1);
    Assert.AreEqual(1, myRecord.A);
  }
}
