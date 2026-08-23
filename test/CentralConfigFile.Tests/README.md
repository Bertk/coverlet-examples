# Central `testconfig.json` file

This example demonstrates several ways to share one `testconfig.json` file across test projects.

## Microsoft Testing Platform recommended approach

Microsoft Testing Platform recommends using a single, centrally located `testconfig.json` file and configuring it in `Directory.Build.props`. For details, see [Use a centralized testconfig.json](https://learn.microsoft.com/en-us/dotnet/core/testing/microsoft-testing-platform-config#use-a-centralized-testconfigjson).

To share the configuration across test projects, add the following property group to `Directory.Build.props`:

```xml
<PropertyGroup>
  <TestingPlatformCommandLineArguments>$(TestingPlatformCommandLineArguments) --config-file $(MSBuildThisFileDirectory)/test/testconfig.json</TestingPlatformCommandLineArguments>
</PropertyGroup>
```

The diagnostic log file, *CentralConfigFile_260823080302183.diag*, confirms that the configuration file was loaded:

```text
2026-08-23T08:03:02.1950091+00:00 Microsoft.Testing.Platform.Builder.TestApplication INFORMATION TESTINGPLATFORM_DEFAULT_HANG_TIMEOUT: ''
2026-08-23T08:03:02.2312500+00:00 Microsoft.Testing.Platform.Hosts.TestHostBuilder INFORMATION Setting RegisterEnvironmentVariablesConfigurationSource: 'True'
2026-08-23T08:03:02.2372107+00:00 Microsoft.Testing.Platform.Configurations.JsonConfigurationSource+JsonConfigurationProvider INFORMATION Config file 'C:\GitHub\coverlet-examples\/test/testconfig.json' loaded.
2026-08-23T08:03:02.2500868+00:00 ConfigurationManager TRACE Configuration file ('C:\GitHub\coverlet-examples\/test/testconfig.json') content:
{
  "platformOptions": {
    "Coverlet": {
      "Exclude": "[*.Tests]*,[xunit*]*",
      "ExcludeByAttribute": "GeneratedCode,ExcludeFromCodeCoverage",
      "Format": "cobertura,json,lcov,opencover",
      "SkipAutoProps": true,
      "ExcludeAssembliesWithoutSources": "MissingAll"
    }
  }
}
```

## Configure the central file from each test project

Alternatively, multiple test projects can reference the shared configuration file by adding the following property group to each test project file:

```xml
<PropertyGroup>
  <TestingPlatformCommandLineArguments>$(TestingPlatformCommandLineArguments) --config-file $(RepoRoot)/test/testconfig.json</TestingPlatformCommandLineArguments>
</PropertyGroup>
```

The diagnostic log file, *CentralConfigFile_260823080825441.diag*, confirms that the configuration file was loaded:

```text
2026-08-23T08:08:25.4522841+00:00 Microsoft.Testing.Platform.Builder.TestApplication INFORMATION TESTINGPLATFORM_DEFAULT_HANG_TIMEOUT: ''
2026-08-23T08:08:25.4883364+00:00 Microsoft.Testing.Platform.Hosts.TestHostBuilder INFORMATION Setting RegisterEnvironmentVariablesConfigurationSource: 'True'
2026-08-23T08:08:25.4943067+00:00 Microsoft.Testing.Platform.Configurations.JsonConfigurationSource+JsonConfigurationProvider INFORMATION Config file 'C:\GitHub\coverlet-examples\/test/testconfig.json' loaded.
2026-08-23T08:08:25.5062185+00:00 ConfigurationManager TRACE Configuration file ('C:\GitHub\coverlet-examples\/test/testconfig.json') content:
{
  "platformOptions": {
    "Coverlet": {
      "Exclude": "[*.Tests]*,[xunit*]*",
      "ExcludeByAttribute": "GeneratedCode,ExcludeFromCodeCoverage",
      "Format": "cobertura,json,lcov,opencover",
      "SkipAutoProps": true,
      "ExcludeAssembliesWithoutSources": "MissingAll"
    }
  }
}
```

## Use the central file from the command line

```powershell

$testConfig =  "./test/testconfig.json"

dotnet run -c Debug --no-build `
    --project test/CentralConfigFile.Tests/CentralConfigFile.Tests.csproj `
    --report-xunit-trx `
    --framework net10.0 `
    --results-directory ./artifacts/results `
    --config-file $testConfig `
    --verbosity normal `
    --coverlet `
    --coverlet-output-format cobertura `
    --diagnostic --diagnostic-verbosity trace `
    --diagnostic-file-prefix CentralConfigFile `
    --report-gh
```

The diagnostic log file, *CentralConfigFile_260823075138241.diag*, confirms that the configuration file was loaded:

```text
2026-08-23T07:51:38.2521784+00:00 Microsoft.Testing.Platform.Builder.TestApplication INFORMATION TESTINGPLATFORM_DEFAULT_HANG_TIMEOUT: ''
2026-08-23T07:51:38.2878447+00:00 Microsoft.Testing.Platform.Hosts.TestHostBuilder INFORMATION Setting RegisterEnvironmentVariablesConfigurationSource: 'True'
2026-08-23T07:51:38.2938124+00:00 Microsoft.Testing.Platform.Configurations.JsonConfigurationSource+JsonConfigurationProvider INFORMATION Config file './test/testconfig.json' loaded.
2026-08-23T07:51:38.3063271+00:00 ConfigurationManager TRACE Configuration file ('./test/testconfig.json') content:
{
  "platformOptions": {
    "Coverlet": {
      "Exclude": "[*.Tests]*,[xunit*]*",
      "ExcludeByAttribute": "GeneratedCode,ExcludeFromCodeCoverage",
      "Format": "cobertura,json,lcov,opencover",
      "SkipAutoProps": true,
      "ExcludeAssembliesWithoutSources": "MissingAll"
    }
  }
}
```
