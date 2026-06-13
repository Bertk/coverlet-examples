using System;

namespace Issue1786;

public static class Class1786
{
  public static int Test1(int n)
  {
    if (n < 10)
    {
      n = Random.Shared.Next();
    }
    return n;
  }
}
