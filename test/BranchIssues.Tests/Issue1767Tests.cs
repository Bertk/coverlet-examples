using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Issue1767.Tests;

public static class Class1Tests
{

  [Test]
  public static void Test2()
  {
    Class1767 class1767 = new();
    CollectionAssert.DoesNotContain(class1767.Exists("42"), "One");
  }
}
