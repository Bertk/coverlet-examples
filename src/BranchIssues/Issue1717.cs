using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Issue1717
{
  public static class ThrowHelper
  {
    [DoesNotReturn]
    public static void Throw(Exception e)
    {
      throw e;
    }

  }

  public class Class1717
  {
    public async Task ThrowMethodWithMessageAsync(string message)
    {
      Console.WriteLine(message);
      ThrowHelper.Throw(new Exception());
    }
  }

}
