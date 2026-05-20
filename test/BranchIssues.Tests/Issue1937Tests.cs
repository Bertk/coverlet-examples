using AWSSecretsManager.Provider.Internal;
using Issue1937;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Issue1937.Tests;

  public class Class1Tests
  {

    [Test]
    public void ConfigureSecretsManager()
    {
      var builder = new ConfigurationBuilder()
          .ConfigureSecretsManager();

      var source = (SecretsManagerConfigurationSource)builder.Sources[0];

      Assert.True(
          source.Options.SecretFilter(new()
          {
            Name = "/Test/Key"
          })
      );

      Assert.False(
          source.Options.SecretFilter(new()
          {
            Name = "/Invalid/Key"
          })
      );
    }
  }

