// issue 1313

using System.Linq;

namespace ClassLibrary2
{
  public static class CoverletRepro
  {
    public static bool TestString(string test)
    {
      var lastDigit = test.Last();
      if (test.StartsWith("123") && lastDigit is >= '0' and <= '7')
      {
        return true;
      }

      return false;
    }

    public static bool TestStringOld(string test)
    {
      var lastDigit = test.Last();
      if (test.StartsWith("123") && lastDigit >= '0' && lastDigit <= '7')
      {
        return true;
      }

      return false;
    }
  }
}
