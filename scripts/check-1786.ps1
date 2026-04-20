#!/usr/bin/env pwsh
# check-1786.ps1 - Helper script to generate coverage reports for the Coverlet project.
#
# Usage:
#   ./scripts/check-1786.ps1
#
# Arguments passed to reportgenerator:
#   -reports: test/**/*.cobertura.xml
#   -targetdir: artifacts/CoverageReport
#   -reporttypes: HtmlInline_AzurePipelines;Cobertura;Markdown
#   -verbosity: Verbose
dotnet tool restore --add-source https://api.nuget.org/v3/index.json
dotnet tool list

# Remove artifacts directory
if (Test-Path 'artifacts') {
    Remove-Item -Path 'artifacts' -Recurse -Force
}

dotnet test --project test\XUnitProject2.Tests\XUnitProject2.Tests.csproj --report-xunit-trx --framework net10.0 --verbosity normal --coverlet --coverlet-output-format cobertura --coverlet-output-format json --coverlet-output-format opencover --coverlet-file-prefix XUnitProject2 --diagnostic --diagnostic-verbosity trace --results-directory artifacts/results --diagnostic-file-prefix XUnitProject2

# Generate html report using cobertura coverage reports
#dotnet reportgenerator "-reports:./artifacts/results/*.coverage.cobertura*.xml" -targetdir:./artifacts/results/CoverageReport -reporttypes:'HtmlInline_AzurePipelines;Cobertura;Markdown' -verbosity:Verbose

# Generate html report using opencover coverage reports
dotnet reportgenerator "-reports:./artifacts/results/*.coverage.opencover*.xml" -targetdir:./artifacts/results/CoverageReport -reporttypes:'HtmlInline_AzurePipelines;Cobertura;Markdown' -verbosity:Verbose
# display results
./artifacts/results/CoverageReport\index.html

