using Xunit;

namespace XUnitTestProject3
{
  public class UnitTest3
    {
        [Fact]
        public void Test3()
        {
            Assert.Equal(42, ClassLibrary3.Class3.Method());
        }
    }
}
