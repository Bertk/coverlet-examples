using Issue2037.App.Services;
using Microsoft.Extensions.Hosting;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

WebApplication app = builder.Build();

app.MapGet("/normalize/{name}", (string name) =>
{
  CoverageTarget target = new();
  return target.NormalizeName(name);
});

app.MapPost("/shutdown", (IHostApplicationLifetime lifetime) =>
{
  lifetime.StopApplication();
  return Results.Accepted();
});

await app.RunAsync();
