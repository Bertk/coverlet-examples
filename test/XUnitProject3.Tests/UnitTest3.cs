using ClassLibrary3;
using Xunit;

[assembly: CaptureConsole]
namespace XUnitTestProject3
{
  public class UnitTest3(ITestOutputHelper output)
  {
    private readonly ITestOutputHelper output = output;

    [Fact]
    public void Test3()
    {
      Data myrec = new(42, "Hello");
      DoerOfStuff handle = new(null);
      handle.StartWithoutWaiting(myrec);
      output.WriteLine("After StartWithoutWaiting ");
      // check logging , or whatever you want to check here
      Assert.True(true);

    }
  }
}
