# coverlet example projects


- [dotnet test with VSTest](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-test-vstest) - The traditional test platform, available in .NET 6 SDK and later. Provides comprehensive test discovery, filtering, and result reporting capabilities.
- [dotnet test with MTP](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-test-mtp) - The modern testing platform, available in .NET 10 SDK and later. Offers faster test execution and more flexible test module selection.
- [Migrate to MTP mode of dotnet test](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test#migrate-to-mtp-mode-of-dotnet-test)

```shell
dotnet test --solution SampleSolution.slnx

or 

dotnet test --project test\XUnitProject1.Tests\XUnitProject1.Tests.csproj --report-xunit-trx --framework net10.0 --verbosity normal --coverlet --coverlet-output-format cobertura --diagnostic --diagnostic-verbosity trace
```


```shell
C:\GitHub\coverlet-examples>dotnet test --project test\XUnitProject1.Tests\XUnitProject1.Tests.csproj -h
Description:
  .NET Test Command for Microsoft.Testing.Platform (opted-in via 'global.json' file). This only supports Microsoft.Testing.Platform and doesn't support VSTest.
  For more information, see https://aka.ms/dotnet-test.

Usage:
  dotnet test [options] [platform options] [extension options]

Options:
  --project <PROJECT_PATH>                        Defines the path of the project file to run (folder name or full path). If not specified, it defaults to the
                                                  current directory.
  --solution <SOLUTION_PATH>                      Defines the path of the solution file to run. If not specified, it defaults to the current directory.
  --test-modules <EXPRESSION>                     Run tests for the specified test modules.
  --root-directory <ROOT_PATH>                    The test modules have the specified root directory.
  --results-directory <RESULTS_DIR>               The directory where the test results will be placed.
                                                  The specified directory will be created if it does not exist.
  --config-file <CONFIG_FILE>                     Specifies a testconfig.json file.
  --diagnostic-output-directory <DIAGNOSTIC_DIR>  Output directory of the diagnostic logging.
                                                  If not specified the file will be generated inside the default 'TestResults' directory.
  --max-parallel-test-modules <NUMBER>            The max number of test modules that can run in parallel.
  --minimum-expected-tests <NUMBER>               Specifies the minimum number of tests that are expected to run.
  -a, --arch <ARCH>                               The target architecture.
  -e, --environment <NAME="VALUE">                Sets the value of an environment variable.
                                                  Creates the variable if it does not exist, overrides if it does.
                                                  This argument can be specified multiple times to provide multiple variables.

                                                  Examples:
                                                  -e VARIABLE=abc
                                                  -e VARIABLE="value with spaces"
                                                  -e VARIABLE="value;seperated with;semicolons"
                                                  -e VAR1=abc -e VAR2=def -e VAR3=ghi
  -c, --configuration <CONFIGURATION>             The configuration to use for running tests. The default for most projects is 'Debug'.
  -f, --framework <FRAMEWORK>                     The target framework to run tests for. The target framework must also be specified in the project file.
  --os <OS>                                       The target operating system.
  -r, --runtime <RUNTIME_IDENTIFIER>              The target runtime to test for.
  -v, -verbosity <LEVEL>                          Set the MSBuild verbosity level. Allowed values are q[uiet], m[inimal], n[ormal], d[etailed], and
                                                  diag[nostic].
  --no-restore                                    Do not restore the project before building. [default: False]
  --no-build                                      Do not build the project before testing. Implies --no-restore. [default: False]
  --no-ansi                                       Disable ANSI output. [default: False]
  --no-progress                                   Disable progress reporting. [default: False]
  --output <Detailed|Normal>                      Verbosity of test output.
  --list-tests <list-tests>                       List the discovered tests instead of running the tests.
  --no-launch-profile                             Do not attempt to use launchSettings.json or [app].run.json to configure the application. [default: False]
  --no-launch-profile-arguments                   Do not use arguments specified in launch profile to run the application. [default: False]
  -?, -h, --help                                  Show command line help.

Waiting for options and extensions...
Platform Options:
  --debug                         Allows to pause execution in order to attach to the process for debug purposes.
  --diagnostic                    Enable the diagnostic logging. The default log level is 'Trace'.
                                  The file will be written in the output directory with the name log_[yyMMddHHmmssfff].diag
  --diagnostic-file-prefix        Prefix for the log file name that will replace '[log]_.'
  --diagnostic-synchronous-write  Force the built-in file logger to write the log synchronously.
                                  Useful for scenario where you don't want to lose any log (i.e. in case of crash).
                                  Note that this is slowing down the test execution.
  --diagnostic-verbosity          Define the level of the verbosity for the --diagnostic.
                                  The available values are 'Trace', 'Debug', 'Information', 'Warning', 'Error', and 'Critical'.
  --exit-on-process-exit          Exit the test process if dependent process exits. PID must be provided.
  --filter-uid                    Provides a list of test node UIDs to filter by.
  --help                          Show the command line help.
  --ignore-exit-code              Do not report non successful exit value for specific exit codes
                                  (e.g. '--ignore-exit-code 8;9' ignore exit code 8 and 9 and will return 0 in these case)
  --info                          Display .NET test application information.
  --timeout                       A global test execution timeout.
                                  Takes one argument as string in the format <value>[h|m|s] where 'value' is float.

Extension Options:
  --assert-equivalent-max-depth                  Set the maximum recursive depth when comparing objects with Assert.Equivalent. Default value is 50.
                                                     (integer) - maximum depth to compare; exceeding this fails the assertion
  --auto-reporters                               Change whether reporters can be auto-enabled.
                                                     on  - allow reporters to be auto-enabled by the environment [default]
                                                     off - do not allow reporters to be auto-enabled by the environment
  --coverlet                                     Enable code coverage data collection.
  --coverlet-does-not-return-attribute           Attributes that mark methods as not returning.
  --coverlet-exclude                             Exclude assemblies matching filters (e.g., [Assembly]Type).
  --coverlet-exclude-assemblies-without-sources  Exclude assemblies without source code.
  --coverlet-exclude-by-attribute                Exclude methods/classes decorated with attributes.
  --coverlet-exclude-by-file                     Exclude source files matching glob patterns.
  --coverlet-include                             Include assemblies matching filters (e.g., [Assembly]Type).
  --coverlet-include-directory                   Include additional directories for instrumentation.
  --coverlet-include-test-assembly               Include test assembly in coverage.
  --coverlet-output-format                       Output format(s) for coverage report (json, lcov, opencover, cobertura).
  --coverlet-single-hit                          Limit the number of hits to one for each location.
  --coverlet-skip-auto-props                     Skip auto-implemented properties.
  --culture                                      Run tests under the given culture.
                                                     default   - run with the default operating system culture [default]
                                                     invariant - run with the invariant culture
                                                     (string)  - run with the given culture (i.e., 'en-US')
  --explicit                                     Change the way explicit tests are handled.
                                                     on   - run both explicit and non-explicit tests
                                                     off  - run only non-explicit tests [default]
                                                     only - run only explicit tests
  --fail-skips                                   Change the way skipped tests are handled.
                                                     on  - treat skipped tests as failed
                                                     off - treat skipped tests as skipped [default]
  --fail-warns                                   Change the way passing tests with warnings are handled.
                                                     on  - treat passing tests with warnings as failed
                                                     off - treat passing tests with warnings as passed [default]
  --filter-class                                 Run all methods in a given test class. Pass one or more fully qualified type names (i.e.,
                                                 'MyNamespace.MyClass' or 'MyNamespace.MyClass+InnerClass'). Wildcard '*' is supported at
                                                 the beginning and/or end of each filter.
                                                     Note: Specifying more than one is an OR operation.
                                                           This is categorized as a simple filter. You cannot use both simple filters and query filters.
  --filter-method                                Run a given test method. Pass one or more fully qualified method names (i.e.,
                                                 'MyNamespace.MyClass.MyTestMethod'). Wildcard '*' is supported at the beginning and/or end
                                                 of each filter.
                                                     Note: Specifying more than one is an OR operation.
                                                           This is categorized as a simple filter. You cannot use both simple filters and query filters.
  --filter-namespace                             Run all methods in the given namespace. Pass one or more namespaces (i.e., 'MyNamespace' or
                                                 'MyNamespace.MySubNamespace'). Wildcard '*' is supported at the beginning and/or end of
                                                 each filter.
                                                     Note: Specifying more than one is an OR operation.
                                                           This is categorized as a simple filter. You cannot use both simple filters and query filters.
  --filter-not-class                             Do not run any methods in the given test class. Pass one or more fully qualified type names
                                                 (i.e., 'MyNamespace.MyClass', or 'MyNamespace.MyClass+InnerClass'). Wildcard '*' is supported at
                                                 the beginning and/or end of each filter.
                                                     Note: Specifying more than one is an AND operation.
                                                           This is categorized as a simple filter. You cannot use both simple filters and query filters.
  --filter-not-method                            Do not run a given test method. Pass one or more fully qualified method names (i.e.,
                                                 'MyNamespace.MyClass.MyTestMethod'). Wildcard '*' is supported at the beginning and/or end
                                                 of each filter.
                                                     Note: Specifying more than one is an AND operation.
                                                           This is categorized as a simple filter. You cannot use both simple filters and query filters.
  --filter-not-namespace                         Do not run any methods in the given namespace. Pass one or more namespaces (i.e., 'MyNamespace'
                                                 or 'MyNamespace.MySubNamespace'). Wildcard '*' is supported at the beginning and/or end of
                                                 each filter.
                                                     Note: Specifying more than one is an AND operation.
                                                           This is categorized as a simple filter. You cannot use both simple filters and query filters.
  --filter-not-trait                             Do not run any methods with a given trait value. Pass one or more name/value pairs (i.e.,
                                                 'name=value'). Wildcard '*' is supported at the beginning and/or end of the trait name
                                                 and/or value.
                                                     Note: Specifying more than one is an AND operation.
                                                           This is categorized as a simple filter. You cannot use both simple filters and query filters.
  --filter-query                                 Filter based on the filter query language. Pass one or more filter queries (in the
                                                 '/assemblyName/namespace/type/method[trait=value]' format. For more information, see
                                                 https://xunit.net/docs/query-filter-language
                                                     Note: Specifying more than one is an OR operation.
                                                           This is categorized as a query filter. You cannot use both query filters and simple filters.
  --filter-trait                                 Run all methods with a given trait value. Pass one or more name/value pairs (i.e.,
                                                 'name=value'). Wildcard '*' is supported at the beginning and/or end of the trait name
                                                 and/or value.
                                                     Note: Specifying more than one is an OR operation.
                                                           This is categorized as a simple filter. You cannot use both simple filters and query filters.
  --long-running                                 Enable long running (hung) test detection.
                                                     (integer) - number of seconds a test runs to be considered 'long running'
  --max-threads                                  Set maximum thread count for collection parallelization.
                                                     default   - run with default (1 thread per CPU thread)
                                                     unlimited - run with unbounded thread count
                                                     (integer) - use exactly this many threads (e.g., '2' = 2 threads)
                                                     (float)x  - use a multiple of CPU threads (e.g., '2.0x' = 2.0 * the number of CPU threads)
  --method-display                               Set default test display name.
                                                     classAndMethod - use a fully qualified name [default]
                                                     method         - use just the method name
  --method-display-options                       Alters the default test display name.
                                                     none - apply no alterations [default]
                                                     all  - apply all alterations
                                                     Or one or more of:
                                                         replacePeriodWithComma     - replace periods in names with commas
                                                         replaceUnderscoreWithSpace - replace underscores in names with spaces
                                                         useOperatorMonikers        - replace operator names with operators
                                                                                          'lt' becomes '<'
                                                                                          'le' becomes '<='
                                                                                          'eq' becomes '='
                                                                                          'ne' becomes '!='
                                                                                          'gt' becomes '>'
                                                                                          'ge' becomes '>='
                                                         useEscapeSequences         - replace ASCII and Unicode escape sequences
                                                                                          X + 2 hex digits (i.e., 'X2C' becomes ',')
                                                                                          U + 4 hex digits (i.e., 'U0192' becomes 'ƒ')
  --parallel                                     Change test parallelization.
                                                     none        - turn off parallelization
                                                     collections - parallelize by collections [default]
  --parallel-algorithm                           Change the parallelization algorithm.
                                                     conservative - start the minimum number of tests [default]
                                                     aggressive   - start as many tests as possible
  --pre-enumerate-theories                       Change theory pre-enumeration during discovery.
                                                     on  - turns on theory pre-enumeration [default]
                                                     off - turns off theory pre-enumeration
  --print-max-enumerable-length                  Set the maximum number of values to show when printing a collection. Default value is 5.
                                                     0         - always print the full collection
                                                     (integer) - maximum values to print, followed by an ellipsis
  --print-max-object-depth                       Set the maximum recursive depth when printing object values. Default value is 3.
                                                     0         - print objects at all depths
                                                     (integer) - maximum depth to print, followed by an ellipsis
                                                 Warning: Setting '0' or a very large value can cause stack overflows that may crash the test process
  --print-max-object-member-count                Set the maximum number of fields and properties to show when printing an object. Default value is 5.
                                                     0         - always print the full collection
                                                     (integer) - maximum members to print, followed by an ellipsis
  --print-max-string-length                      Set the maximum length when printing a string. Default value is 50.
                                                     0         - always print the full collection
                                                     (integer) - maximum string length to print, followed by an ellipsis
  --report-ctrf                                  Enable generating CTRF (JSON) report
  --report-ctrf-filename                         The name of the generated CTRF report
  --report-junit                                 Enable generating JUnit (XML) report
  --report-junit-filename                        The name of the generated JUnit report
  --report-nunit                                 Enable generating NUnit (v2.5 XML) report
  --report-nunit-filename                        The name of the generated NUnit report
  --report-xunit                                 Enable generating xUnit.net (v2+ XML) report
  --report-xunit-filename                        The name of the generated xUnit.net report
  --report-xunit-html                            Enable generating xUnit.net HTML report
  --report-xunit-html-filename                   The name of the generated xUnit.net HTML report
  --report-xunit-trx                             Enable generating xUnit.net TRX report
  --report-xunit-trx-filename                    The name of the generated xUnit.net TRX report
  --seed                                         Set the randomization seed.
                                                     (integer) - use this as the randomization seed
  --show-live-output                             Determine whether to show test output (from ITestOutputHelper) live during test execution.
                                                     on  - turn on live reporting of test output
                                                     off - turn off live reporting of test output [default]
  --stop-on-fail                                 Stop running tests after the first test failure.
                                                     on  - stop running tests after the first test failure
                                                     off - run all tests regardless of failures [default]
  --xunit-config-filename                        Sets the configuration file. By default, this is 'xunit.runner.json' in the bin directory
                                                 alongside the compiled output.
  --xunit-diagnostics                            Determine whether to show diagnostic messages.
                                                     on  - display diagnostic messages
                                                     off - hide diagnostic messages [default]
  --xunit-info                                   Show xUnit.net headers and information
  --xunit-internal-diagnostics                   Determine whether to show internal diagnostic messages.
                                                     on  - display internal diagnostic messages
                                                     off - hide internal diagnostic messages [default]
```
