using Issue2037.App.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

WebApplication app = builder.Build();

app.MapGet("/normalize/{name}", (string name) =>
{
  CoverageTarget target = new();
  return target.NormalizeName(name);
});

await app.RunAsync();
