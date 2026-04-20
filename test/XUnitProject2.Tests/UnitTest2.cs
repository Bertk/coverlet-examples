using Xunit;

namespace XUnitTestProject2
{
  public class UnitTest2
  {
    [Fact]
    public static void Test2()
    {
      int ret = ClassLibrary2.Class2.Test2(12);
      Assert.Equal(12, ret);
    }
  }
}
