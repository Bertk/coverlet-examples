using Mediator;
using MediatorApp1718;
using Microsoft.Extensions.DependencyInjection;

namespace ThresholdConfigFile.Tests
{
  public class UnitTest1
  {
    [Fact]
    public async Task Test1()
    {
      ServiceCollection services = new();
      _ = services.AddApplication();

      ServiceProvider serviceProvider = services.BuildServiceProvider();
      IMediator mediator = serviceProvider.GetRequiredService<Mediator.IMediator>();

      string result = await mediator.Send(new PingQuery("pong"), TestContext.Current.CancellationToken);

      Assert.Equal("pong", result);
    }
  }
}
