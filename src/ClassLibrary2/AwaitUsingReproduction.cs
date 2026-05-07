// issue 1334
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2;

public class AwaitUsingReproduction
{
  public async Task Execute()
  {
    await using var stream = new MemoryStream(Encoding.UTF8.GetBytes("Hello world!"));
  }
}
