using NUnit.Framework;

namespace NUnitProject1.Tests;

public class UnitTest1
{
  [Test]
  public void Test1()
  {
    Assert.That(ClassLibrary1.Class1.Method(), Is.EqualTo(42));
  }
}
