using System.Collections.Generic;
using System.Linq;

namespace Issue1767;

public class Class1767
{
  private readonly List<string> _items = new List<string> { "One", "two" };
  public IEnumerable<string> Exists(string name)
  {
    return _items.Where(x => x == name);
  }
}
