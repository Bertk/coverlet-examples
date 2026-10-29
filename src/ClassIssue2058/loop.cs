namespace ClassIssue2058;

public sealed class ClassLoop
{
  private int _n;

  public void Run()
  {
    while (true)
    {
      if (_n > 0)
      {
        _n--;
      }
      try { _n++; } finally { _n++; }
    }
  }
}
