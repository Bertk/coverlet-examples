using Xunit;

namespace XUnitTestProject2
{
  public class UnitTest2
    {
        [Fact]
        public void Test2()
        {
            Assert.Equal(42, ClassLibrary2.Class2.Method());
        }
    }
}
