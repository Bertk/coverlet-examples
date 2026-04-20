using System;

namespace ClassLibrary2
{
  public static class Class2
  {
    public static int Test2(int n)
    {
      if (n < 10)
      {
        n = Random.Shared.Next();
      }
      return n;
    }
  }
}
