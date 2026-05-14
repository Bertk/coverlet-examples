using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

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
    var (one, two) = data;
    try
    {

      var res = one++;
      _log.LogInformation($"Res {res}");
    }
    catch (Exception exception)
    {
      _log.LogError(exception, "Something bad happened");
    }
    finally
    {
      _log.LogInformation("I'm finally here");
      string filePath = "simple.txt";
      string text = $"Hello World";

      await File.WriteAllTextAsync(filePath, text);
    }
  }
}
