using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Issue1337;

public record Data(int One, string Two);
public class DoerOfStuff
{
  private readonly ILogger<DoerOfStuff> _log;

  public DoerOfStuff(ILogger<DoerOfStuff> log)
  {
    _log = log;
  }

  public void StartWithoutWaiting(Data data)
  {
    Task.Run(() => ActualWork(data));
  }

  private async Task ActualWork(Data data)
  {
    (int one, string? two) = data;
    try
    {

      int res = one++;
      _log.LogInformation($"Res {res}");
    }
    catch (Exception exception)
    {
      _log.LogError(exception, "Something bad happened");
    }
    finally
    {
      _log.LogInformation("I'm finally here");
      const string filePath = "simple.txt";
      const string text = $"Hello World";

      await File.WriteAllTextAsync(filePath, text);
    }
  }
}
