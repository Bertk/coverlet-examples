using System;
using System.Linq;
using AWSSecretsManager.Provider;
using Microsoft.Extensions.Configuration;

namespace Issue1937;

public static class Class1937
{
  public static IConfigurationBuilder ConfigureSecretsManager(this IConfigurationBuilder builder)
  {
    string[] prefixes = ["/Test/"];

    builder.AddSecretsManager(configurator: (options) =>
    {
      options.SecretFilter = (secret) =>
      {
        return prefixes.Any(prefix =>
            secret.Name.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)
        );
      };
    });

    return builder;
  }
}
