# coverlet example projects


- [dotnet test with VSTest](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-test-vstest) - The traditional test platform, available in .NET 6 SDK and later. Provides comprehensive test discovery, filtering, and result reporting capabilities.
- [dotnet test with MTP](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-test-mtp) - The modern testing platform, available in .NET 10 SDK and later. Offers faster test execution and more flexible test module selection.
- [Migrate to MTP mode of dotnet test](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test#migrate-to-mtp-mode-of-dotnet-test)

```shell
dotnet test --solution SampleSolution.slnx

or 

dotnet test --project test\XUnitProject1.Tests\XUnitProject1.Tests.csproj --report-trx
```


```shell
C:\GitHub\coverlet-examples\artifacts\bin\XUnitProject1.Tests\debug>XUnitProject1.Tests.exe -h
xUnit.net v3 In-Process Runner v3.2.1+a9cfb80929 (64-bit .NET 10.0.1)
Copyright (C) .NET Foundation.

usage: [:seed] [path/to/configFile.json] [options] [filters] [reporter] [resultFormat filename [...]]

General options

  -assemblyInfo                      : return test assembly information; does not find or run tests (implies -noColor and -noLogo)
  -assertEquivalentMaxDepth <option> : override the maximum recursive depth when comparing objects with Assert.Equivalent
                                     :   any integer value >= 1 is valid (default value is 50)
  -automated [option]                : enables automated mode (ensures all output is machine parseable)
                                     :   <unset> - use synchronous reporting requested by the configuration
                                     :   async   - asynchronously report messages (and don't wait)
                                     :   sync    - synchronously report messages (and wait for a carriage return after each)
  -culture <option>                  : run tests under the given culture (v3 assemblies only)
                                     : note: when running a v1/v2 assembly, the culture option will be ignored
                                     :   default   - run with default operating system culture
                                     :   invariant - run with the invariant culture
                                     :   (string)  - run with the given culture (i.e., 'en-US')
  -debug                             : launch the debugger to debug the tests
  -diagnostics                       : enable diagnostics messages for all test assemblies
  -explicit <option>                 : change the way explicit tests are handled
                                     :   on   - run both explicit and non-explicit tests
                                     :   off  - run only non-explicit tests [default]
                                     :   only - run only explicit tests
  -failSkips                         : treat skipped tests as failures
  -failSkips-                        : treat skipped tests as skipped [default]
  -failWarns                         : treat passing tests with warnings as failures
  -failWarns-                        : treat passing tests with warnings as successful [default]
  -id <id>                           : run a test case (by unique ID)
  -ignoreFailures                    : if tests fail, do not return a failure exit code
  -internalDiagnostics               : enable internal diagnostics messages for all test assemblies
  -list <option>                     : list information about the test assemblies rather than running tests (implies -noLogo)
                                     : note: you can add '/json' to the end of any option to get the listing in JSON format
                                     :   classes - list class names of every class which contains tests
                                     :   full    - list complete discovery data
                                     :   methods - list class+method names of every method which is a test
                                     :   tests   - list just the display name of all tests
                                     :   traits  - list the set of trait name/value pairs used in the test assemblies
  -longRunning <seconds>             : enable long running (hung) test detection (implies -diagnostics) by specifying
                                     : the number of seconds (as a positive integer) to report a test as running
                                     : too long (most effective with parallelAlgorithm 'conservative')
  -maxThreads <option>               : maximum thread count for collection parallelization
                                     :   default   - run with default (1 thread per CPU thread)
                                     :   unlimited - run with unbounded thread count
                                     :   (integer) - use exactly this many threads (e.g., '2' = 2 threads)
                                     :   (float)x  - use a multiple of CPU threads (e.g., '2.0x' = 2.0 * the number of CPU threads)
  -methodDisplay <option>            : set default test display name
                                     :   classAndMethod - Use a fully qualified name [default]
                                     :   method         - Use just the method name
  -methodDisplayOptions <option>     : alters the default test display name
                                     : note: you can specify more than one flag by joining with commas
                                     :   none                       - apply no alterations [default]
                                     :   all                        - apply all alterations
                                     :   replacePeriodWithComma     - replace periods in names with commas
                                     :   replaceUnderscoreWithSpace - replace underscores in names with spaces
                                     :   useOperatorMonikers        - replace operator names with operators
                                     :                                  'lt' becomes '<'
                                     :                                  'le' becomes '<='
                                     :                                  'eq' becomes '='
                                     :                                  'ne' becomes '!='
                                     :                                  'gt' becomes '>'
                                     :                                  'ge' becomes '>='
                                     :   useEscapeSequences         - replace ASCII and Unicode escape sequences
                                     :                                   X + 2 hex digits (i.e., 'X2C' becomes ',')
                                     :                                   U + 4 hex digits (i.e., 'U0192' becomes 'ƒ')
  -noAutoReporters                   : do not allow reporters to be auto-enabled by environment
                                     : (for example, auto-detecting TeamCity or AppVeyor)
  -noColor                           : do not output results with colors
  -noLogo                            : do not show the copyright message
  -parallel <option>                 : set parallelization based on option
                                     :   none        - turn off parallelization
                                     :   collections - parallelize by collections [default]
  -parallelAlgorithm <option>        : set the parallelization algoritm
                                     :   conservative - start the minimum number of tests [default]
                                     :   aggressive   - start as many tests as possible
                                     : for more information, see https://xunit.net/docs/running-tests-in-parallel#algorithms
  -pause                             : wait for input before running tests (ignored with -automated)
  -preEnumerateTheories              : enable theory pre-enumeration (disabled by default)
  -run <serialization>               : run a test case (by serialization)
  -showLiveOutput                    : show output messages from tests live
  -stopOnFail                        : stop on first test failure
  -useAnsiColor                      : force using ANSI color output on Windows (non-Windows always uses ANSI colors)
  -wait                              : wait for input after completion (ignored with -automated)
  -waitForDebugger                   : pauses execution until a debugger has been attached

Query filtering (optional, choose one or more)
If more than one query filter is specified, the filters act as an OR operation
  Note: You cannot mix simple filtering and query filtering.

  -filter "query" : use a query filter to select tests (using the query filter language;
                  : in '/assemblyName/namespace/class/method[trait=value]' format)
                  : for more information, see https://xunit.net/docs/query-filter-language

Simple filtering (optional, choose one or more)
If more than one simple filter type is specified, cross-filter type filters act as an AND operation
  Note: You cannot mix simple filtering and query filtering.

  -class "name"        : run all methods in a given test class (type names are fully qualified;
                       : i.e., 'MyNamespace.MyClass' or 'MyNamespace.MyClass+InnerClass'; wildcard '*'
                       : is supported at the beginning and/or end of the filter)
                       :   if specified more than once, acts as an OR operation
  -class- "name"       : do not run any methods in a given test class (type names are fully qualified;
                       : i.e., 'MyNamespace.MyClass' or 'MyNamespace.MyClass+InnerClass'; wildcard '*'
                       : is supported at the beginning and/or end of the filter)
                       :   if specified more than once, acts as an AND operation
  -method "name"       : run a given test method (including the fully qualified type name;
                       : i.e., 'MyNamespace.MyClass.MyTestMethod'; wildcard '*' is supported
                       : at the beginning and/or end of the filter)
                       :   if specified more than once, acts as an OR operation
  -method- "name"      : do not run a given test method (including the fully qualified type name;
                       : i.e., 'MyNamespace.MyClass.MyTestMethod'; wildcard '*' is supported
                       : at the beginning and/or end of the filter)
                       :   if specified more than once, acts as an AND operation
  -namespace "name"    : run all methods in a given namespace (i.e., 'MyNamespace.MySubNamespace';
                       : wildcard '*' is supported at the beginning and/or end of the filter)
                       :   if specified more than once, acts as an OR operation
  -namespace- "name"   : do not run any methods in a given namespace (i.e., 'MyNamespace.MySubNamespace';
                       : wildcard '*' is supported at the beginning and/or end of the filter)
                       :   if specified more than once, acts as an AND operation
  -trait "name=value"  : only run tests with matching name/value traits (wildcard '*' is supported at the
                       : beginning and/or end of the trait name and/or value)
                       :   if specified more than once, acts as an OR operation
  -trait- "name=value" : do not run tests with matching name/value traits (wildcard '*' is supported at the
                       : beginning and/or end of the trait name and/or value)
                       :   if specified more than once, acts as an AND operation

Argument display overrides

  -printMaxEnumerableLength <option>  : override the maximum number of values to show when printing a collection
                                      : set to 0 to always print the full collection
                                      :   any integer value >= 0 is valid (default value is 5)
  -printMaxObjectDepth <option>       : override the maximum recursive depth when printing object values
                                      : set to 0 to always print objects at all depths
                                      : (warning: setting 0 or a very large value can cause stack overflows that may crash the test process)
                                      :   any integer value >= 0 is valid (default value is 3)
  -printMaxObjectMemberCount <option> : override the maximum number of fields and properties to show when printing an object
                                      : set to 0 to always print all members
                                      :   any integer value >= 0 is valid (default value is 5)
  -printMaxStringLength <option>      : override the maximum length to show when printing a string value
                                      : set to 0 to always print the entire string
                                      :   any integer value >= 0 is valid (default value is 50)

Runner reporters (optional, choose only one)

  -reporter <option> : choose a reporter
                     :   default  - show standard progress messages
                     :   json     - show full progress messages in JSON [implies '-noLogo']
                     :   quiet    - only show failure messages
                     :   silent   - do not show any messages [implies '-noLogo']
                     :   teamCity - TeamCity CI support
                     :   verbose  - show verbose progress messages

  The following reporters will be automatically enabled in the appropriate environment.
  An automatically enabled reporter will override a manually selected reporter.
    Note: You can disable auto-enabled reporters by specifying the '-noAutoReporters' switch

    * AppVeyor CI support
    * Azure DevOps/VSTS CI support
    * TeamCity CI support

Result formats (optional, choose one or more)

  -ctrf <filename>  : output results to CTRF file
  -html <filename>  : output results to HTML file
  -jUnit <filename> : output results to JUnit XML file
  -nUnit <filename> : output results to NUnit v2.5 XML file
  -trx <filename>   : output results to TRX XML file
  -xml <filename>   : output results to xUnit.net v2+ XML file
  -xmlV1 <filename> : output results to xUnit.net v1 XML file
```
