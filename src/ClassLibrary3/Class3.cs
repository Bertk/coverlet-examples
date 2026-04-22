using System;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Logging;

namespace ClassLibrary3
{

  public record Data(int One, string Two);
#pragma warning disable CA1848 // Use the LoggerMessage delegates
#pragma warning disable IDE0008 // Use explicit type
#pragma warning disable S1854 // Unused assignments should be removed
#pragma warning disable CA1873 // Avoid potentially expensive logging
#pragma warning disable S2629 // Logging templates should be constant
#pragma warning disable CA2254 // Template should be a static expression
#pragma warning disable IDE0058 // Expression value is never used
#pragma warning disable IDE0059 // Unnecessary assignment of a value
  public class DoerOfStuff(ILogger<DoerOfStuff> log)
  {
    private readonly ILogger<DoerOfStuff> _log = log;

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
        const string filePath = "simple.txt";
        const string text = $"Hello World";
        await File.WriteAllTextAsync(filePath, text).ConfigureAwait(true);
      }
    }
  }
#pragma warning restore IDE0059 // Unnecessary assignment of a value
#pragma warning restore IDE0058 // Expression value is never used
#pragma warning restore S2629 // Logging templates should be constant
#pragma warning restore CA1873 // Avoid potentially expensive logging
#pragma warning restore S1854 // Unused assignments should be removed
#pragma warning restore IDE0008 // Use explicit type
#pragma warning restore CA1848 // Use the LoggerMessage delegates
#pragma warning restore CA2254 // Template should be a static expression
}
