using MediatorApp1718;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();

WebApplication app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/ping", async (Mediator.IMediator mediator, CancellationToken cancellationToken) =>
{
  return await mediator.Send(new PingQuery("pong"), cancellationToken);
});

await app.RunAsync();
