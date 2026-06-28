using NUnit.Framework;

namespace Issue1969.Tests
{
  public class Issue1969Tests
  {
    [TestCase("hello")]
    [TestCase("world")]
    public void OrTest(string text)
    {
      Assert.True(IsOr.Operator(text));
      Assert.True(IsOr.PatternMatching(text));
    }
  }
}
