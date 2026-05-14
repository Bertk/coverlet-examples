namespace Issue1786;

using System;

public static class Class1
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
