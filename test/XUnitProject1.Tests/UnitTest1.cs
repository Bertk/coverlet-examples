using Xunit;

namespace XUnitTestProject1
{
  public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(42, ClassLibrary1.Class1.Method());
        }
    }
}
