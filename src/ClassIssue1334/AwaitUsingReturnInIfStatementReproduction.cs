// issue 1334
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ClassIssue1334;

public class AwaitUsingReturnInIfStatementReproduction
{
  public async Task<int> ExecuteReproduction(bool isTrue)
  {
    if (isTrue)
    {
      byte[] bytes = Encoding.ASCII.GetBytes("Words");
      await using var stream = new MemoryStream(bytes);
      var byteArray = new byte[stream.Length];
      var count = await stream.ReadAsync(byteArray.AsMemory(0, 3));
      return count;
    }

    return 1;
  }

  public async Task<int> ExecuteNoIfStatement()
  {
    byte[] bytes = Encoding.ASCII.GetBytes("Words");
    await using var stream = new MemoryStream(bytes);
    var byteArray = new byte[stream.Length];
    var count = await stream.ReadAsync(byteArray.AsMemory(0, 3));
    return count;
  }

  public async Task<int> ExecuteAwaitUsingWithBraces(bool isTrue)
  {
    if (isTrue)
    {
      byte[] bytes = Encoding.ASCII.GetBytes("Words");
      await using (var stream = new MemoryStream(bytes))
      {
        var byteArray = new byte[stream.Length];
        var count = await stream.ReadAsync(byteArray.AsMemory(0, 3));
        return count;
      }
    }

    return 1;
  }

  public async Task<int> ExecuteUsingWithoutAwait(bool isTrue)
  {
    if (isTrue)
    {
      byte[] bytes = Encoding.ASCII.GetBytes("Words");
      using var stream = new MemoryStream(bytes);
      var byteArray = new byte[stream.Length];
      var count = await stream.ReadAsync(byteArray.AsMemory(0, 3));
      return count;
    }

    return 1;
  }

  public async Task<int> ExecuteReturnOutsideIfStatement(bool isTrue)
  {
    int count = 1;
    if (isTrue)
    {
      byte[] bytes = Encoding.ASCII.GetBytes("Words");
      await using var stream = new MemoryStream(bytes);
      var byteArray = new byte[stream.Length];
      count = await stream.ReadAsync(byteArray.AsMemory(0, 3));
    }

    return count;
  }
}
