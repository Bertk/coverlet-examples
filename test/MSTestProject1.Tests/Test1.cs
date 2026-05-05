namespace MSTestProject1.Tests
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public void Test1()
    {
      Assert.AreEqual(42, ClassLibrary1.Class1.Method());
    }
  }
}
