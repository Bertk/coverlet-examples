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

    [TestCase("world")]
    public void OrPartialTest(string text)
    {
      Assert.True(IsOrPartial.Operator(text));
      Assert.True(IsOrPartial.PatternMatching(text));
    }

    [TestCase("other")]
    public void OrWithoutTest(string text)
    {
      Assert.False(IsOrWithout.Operator(text));
      Assert.False(IsOrWithout.PatternMatching(text));
    }
  }

}
