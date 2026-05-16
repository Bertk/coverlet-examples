using System.Linq;

namespace Issue1313
{
  public class Repo1313
  {
    public static class CoverletRepro
    {
      public static bool TestString(string test)
      {
        char lastDigit = test.Last();
        if (test.StartsWith("123") && lastDigit is >= '0' and <= '7')
        {
          return true;
        }

        return false;
      }

      public static bool TestStringOld(string test)
      {
        char lastDigit = test.Last();
        if (test.StartsWith("123") && lastDigit >= '0' && lastDigit <= '7')
        {
          return true;
        }

        return false;
      }
    }
  }
}
