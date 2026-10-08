using System.Diagnostics;
using System.Net.Sockets;

namespace Issue2037.App.Services.IntegrationTest;

public class CoverageTargetIntegrationTest
{
  public static IEnumerable<TheoryDataRow<string, string>> TheoryDataRow_Data()
  {
    yield return new TheoryDataRow<string, string>(string.Empty, "");
    yield return new TheoryDataRow<string, string>("The-string", "the-string");
  }

  [Theory]
  [MemberData(nameof(TheoryDataRow_Data))]
  public void NormalizeName_OfInput(string value, string valueNormalized)
  {
    CoverageTarget target = new();

    string result = target.NormalizeName(value);

    Assert.Equal(valueNormalized, result);
  }

  [Fact]
  public async Task NormalizeEndpoint_ThroughWebApiProgram_ReturnsLowerCaseAsync()
  {
    int port = GetFreePort();
    string webApiDllPath = Path.Combine(AppContext.BaseDirectory, "Issue2037.App.WebApi.dll");

    ProcessStartInfo startInfo = new("dotnet", $"\"{webApiDllPath}\" --urls http://127.0.0.1:{port}")
    {
      UseShellExecute = false,
      RedirectStandardOutput = true,
      RedirectStandardError = true,
      CreateNoWindow = true
    };

    using Process process = new() { StartInfo = startInfo };
    _ = process.Start();

    try
    {
      using HttpClient client = new() { Timeout = TimeSpan.FromSeconds(1) };

      string response = await WaitForSuccessfulResponseAsync(
        client,
        $"http://127.0.0.1:{port}/normalize/THE-VALUE",
        TestContext.Current.CancellationToken);

      Assert.Equal("the-value", response);
    }
    finally
    {
      if (!process.HasExited)
      {
        using CancellationTokenSource cleanupCts = new(TimeSpan.FromSeconds(10));
        try
        {
          await RequestShutdownAndWaitForExitAsync(port, process, cleanupCts.Token);
        }
        finally
        {
          if (!process.HasExited)
          {
            try
            {
              process.Kill(entireProcessTree: true);
            }
            catch (InvalidOperationException) when (process.HasExited)
            {
              // empty catch block to ignore exceptions that may occur if the process has already exited
            }
            await process.WaitForExitAsync(TestContext.Current.CancellationToken);
          }
        }
      }
    }
  }

  private static async Task RequestShutdownAndWaitForExitAsync(int port, Process process, CancellationToken cancellationToken)
  {
    using HttpClient client = new() { Timeout = TimeSpan.FromSeconds(1) };

    try
    {
      Uri targetUri = new($"http://127.0.0.1:{port}/shutdown");
      using HttpResponseMessage _ = await client.PostAsync(
        targetUri,
        content: null,
        cancellationToken);
    }
    catch (HttpRequestException)
    {
      // empty catch block to ignore exceptions that may occur if the process is already shutting down
    }
    catch (TaskCanceledException)
    {
      // empty catch block to ignore exceptions that may occur if the shutdown request times out
    }

    using CancellationTokenSource waitCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
    waitCts.CancelAfter(TimeSpan.FromSeconds(5));

    try
    {
      await process.WaitForExitAsync(waitCts.Token);
    }
    catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
    {
      throw new InvalidOperationException("Web API process did not exit gracefully after shutdown request.");
    }
  }

  private static int GetFreePort()
  {
    TcpListener listener = new(System.Net.IPAddress.Loopback, 0);
    listener.Start();
    int port = ((System.Net.IPEndPoint)listener.LocalEndpoint).Port;
    listener.Stop();
    return port;
  }

  private static async Task<string> WaitForSuccessfulResponseAsync(HttpClient client, string url, CancellationToken cancellationToken)
  {
    string? lastError = null;
    Uri targetUri = new(url);

    for (int i = 0; i < 30; i++)
    {
      cancellationToken.ThrowIfCancellationRequested();
      try
      {
        string response = await client.GetStringAsync(targetUri, cancellationToken);
        return response;
      }
      catch (Exception ex) when (ex is HttpRequestException or TaskCanceledException)
      {
        lastError = ex.Message;
        await Task.Delay(100, cancellationToken);
      }
    }

    throw new InvalidOperationException($"Web API did not become ready in time. Last error: {lastError}");
  }
}
