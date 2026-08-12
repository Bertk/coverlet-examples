using NUnit.Framework;

namespace Issue1767.Tests;

public static class Class1Tests
{

  [Test]
  public static void Test2()
  {
    Class1767 class1767 = new();
    Assert.That(class1767.Exists("42"), Does.Not.Contain("One"));
  }
}
