namespace Issue1969
{
  public static class IsOr
  {
    public static bool Operator(string text)
    {
      return text == "hello" || text == "world";
    }

    public static bool PatternMatching(string text)
    {
      return text is "hello" or "world";
    }
  }
}
