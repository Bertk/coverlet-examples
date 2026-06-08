using System.Diagnostics;

namespace Issue1417
{

  public enum E
  {
    A,
    B,
    C,
  }
  public static class Class1417
  {
    internal static string _actionName = "";
    internal static E _value;
    public static void M()
    {
      E value = GetValue();

      switch (value)
      {
        case E.A:
          PerformActionA();
          break;

        case E.B:
          PerformActionB();
          break;

        case E.C:
          PerformActionC();
          break;

        default:
          throw new UnreachableException();
      }
    }
    public static E GetValue()
    {
      return _value;
    }
    public static void SetValue(E value)
    {
      _value = value;
    }
    private static void PerformActionA()
    {
      _actionName = "ActionA";
    }
    private static void PerformActionB()
    {
      _actionName = "ActionB";
    }
    private static void PerformActionC()
    {
      _actionName = "ActionC";
    }
  }
}
