using NUnit.Framework;

namespace Issue2009Repro
{
  /// <summary>
  /// This is a test class for demonstrating the issue with coverlet and NUnit.
  /// </summary>
  [TestFixture]
  public class Repro
  {
    /// <summary>
    /// A simple test that always passes.
    /// </summary>
    [Test]
    public void DemoTest()
    {
      Assert.AreEqual(42, ClassLibrary.Class1.Method());
    }
   }
}
