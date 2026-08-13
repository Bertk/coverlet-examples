#!/usr/bin/env pwsh
# run-test.ps1 - Builds the solution, runs all tests with code coverage, and generates an HTML report.
#
# Steps performed:
#   1. Delete old build artifacts and test results
#   2. Build the solution in Debug mode
#   3. Run each test project and collect code coverage (Cobertura format)
#   4. Merge all coverage files into a single HTML report
#
# Prerequisites:
#   - .NET SDK 10 (https://dot.net)
#   - reportgenerator local tool (declared in .config/dotnet-tools.json): dotnet tool restore
#
# Usage:
#   ./run-test.ps1
#
#Requires -PSEdition Core
#Requires -Version 7

# Stop immediately if any command fails, so errors are not silently ignored.
$ErrorActionPreference = 'Stop'

# ---------------------------------------------------------------------------
# Helper: print a clearly visible section header to the console
# ---------------------------------------------------------------------------
function Write-Step ([string]$Message) {
    Write-Host ""
    Write-Host "==> $Message" -ForegroundColor Cyan
}

# ---------------------------------------------------------------------------
# Check required tools are available before doing any real work
# ---------------------------------------------------------------------------
Write-Step "Checking prerequisites"

if (-not (Get-Command dotnet -ErrorAction SilentlyContinue)) {
    Write-Error "dotnet is not installed or not in PATH. Download it from https://dot.net"
    exit 1
}

if (-not (dotnet tool list --local | Select-String 'reportgenerator')) {
    Write-Error "reportgenerator is not installed. Run: dotnet tool restore"
    exit 1
}

Write-Host "All prerequisites found." -ForegroundColor Green

# ---------------------------------------------------------------------------
# Step 1 – Clean up previous results so stale data does not affect the report
# ---------------------------------------------------------------------------
Write-Step "Cleaning previous artifacts"
Remove-Item -Path "./artifacts/*" -Force -Recurse -ErrorAction SilentlyContinue
Write-Host "Artifacts folder cleaned." -ForegroundColor Green

#dotnet --list-sdks
#dotnet --list-runtimes

# ---------------------------------------------------------------------------
# Step 2 – Build the entire solution once in Debug mode.
#           --no-build is used below so tests reuse these binaries.
# ---------------------------------------------------------------------------
Write-Step "Building solution (Debug)"
dotnet build -c Debug
Write-Host "Build succeeded." -ForegroundColor Green

# ---------------------------------------------------------------------------
# Step 3 – Run each test project with Coverlet coverage collection.
#
#   Common flags used:
#     --no-build              : reuse the binaries built above
#     --coverlet              : enable Coverlet coverage collection
#     --coverlet-output-format: produce Cobertura XML (used by reportgenerator)
#     --diagnostic            : write detailed Coverlet logs for troubleshooting
#     --results-directory     : where .trx result files and coverage XML land
# ---------------------------------------------------------------------------

# Enable experimental Coverlet feature to cache auto-property backing fields for better performance and branch coverage accuracy
$Env:COVERLET_EXPERIMENTAL_AUTOPROP_BACKING_FIELD_CACHE = '1'

Write-Host "GITHUB_ACTIONS = $Env:GITHUB_ACTIONS"

Write-Step "Running NUnit test projects"

dotnet run -c Debug --no-build `
    --project test/NUnitProject1.Tests/NUnitProject1.Tests.csproj `
    --report-trx `
    --framework net10.0 `
    --results-directory ./artifacts/results `
    --verbosity normal `
    --coverlet `
    --coverlet-output-format cobertura `
    --diagnostic --diagnostic-verbosity trace `
    --diagnostic-file-prefix NUnitProject1 `
    --report-gh

dotnet run -c Debug --no-build `
    --project test/BranchIssues.Tests/BranchIssues.Tests.csproj `
    --report-trx `
    --framework net10.0 `
    --results-directory ./artifacts/results `
    --verbosity normal `
    --coverlet `
    --coverlet-output-format cobertura `
    --coverlet-exclude "[Moq]*" `
    --diagnostic --diagnostic-verbosity trace `
    --diagnostic-file-prefix BranchIssues `
    --report-gh

Write-Step "Running xUnit test projects"

dotnet run -c Debug --no-build `
    --project test/ConsoleApp.Tests/ConsoleApp.Tests.csproj `
    --report-xunit-trx `
    --framework net10.0 `
    --results-directory ./artifacts/results `
    --verbosity normal `
    --coverlet `
    --coverlet-output-format cobertura `
    --diagnostic --diagnostic-verbosity trace `
    --diagnostic-file-prefix ConsoleApp `
    --report-gh

dotnet run -c Debug --no-build `
    --project test/XUnitProject1.Tests/XUnitProject1.Tests.csproj `
    --report-xunit-trx `
    --framework net10.0 `
    --results-directory ./artifacts/results `
    --verbosity normal `
    --coverlet `
    --coverlet-output-format cobertura `
    --diagnostic --diagnostic-verbosity trace `
    --diagnostic-file-prefix XUnitProject1 `
    --report-gh

dotnet run -c Debug --no-build `
    --project test/Issue1334.Tests/Issue1334.Tests.csproj `
    --report-xunit-trx `
    --framework net10.0 `
    --results-directory ./artifacts/results `
    --verbosity normal `
    --coverlet `
    --coverlet-output-format cobertura `
    --diagnostic --diagnostic-verbosity trace `
    --diagnostic-file-prefix Issue1334 `
    --report-gh

dotnet run -c Debug --no-build `
    --project test/MediatorApp.Tests/MediatorApp.Tests.csproj `
    --report-xunit-trx `
    --framework net10.0 `
    --results-directory ./artifacts/results `
    --verbosity normal `
    --coverlet `
    --coverlet-exclude-assemblies-without-sources MissingAll `
    --coverlet-output-format cobertura `
    --diagnostic --diagnostic-verbosity trace `
    --diagnostic-file-prefix MediatorApp `
    --report-gh

dotnet run -c Debug --no-build `
    --project test/Issue1417.Tests/Issue1417.Tests.csproj `
    --report-xunit-trx `
    --framework net10.0 `
    --results-directory ./artifacts/results `
    --verbosity normal `
    --coverlet `
    --coverlet-exclude-assemblies-without-sources MissingAll `
    --coverlet-output-format cobertura `
    --diagnostic --diagnostic-verbosity trace `
    --diagnostic-file-prefix Issue1417 `
    --report-gh

if ($IsWindows) {
  Write-Step "Running test with coverlet.MTP for .NET framework SUT net481"

  dotnet run -c Debug --no-build `
      --project test/Issue2009.Tests/Issue2009.Tests.csproj `
      --report-trx --report-trx-filename Issue2009.Tests.trx `
      --framework net481 `
      --results-directory ./artifacts/results `
      --verbosity normal `
      --coverlet `
      --coverlet-include [ClassLibrary]* `
      --coverlet-output-format cobertura `
      --diagnostic --diagnostic-verbosity trace `
      --diagnostic-file-prefix Issue2009 `
      --report-gh
}

Write-Step "Running MSTest test projects"

dotnet run -c Debug --no-build `
    --project test/MSTestProject1.Tests/MSTestProject1.Tests.csproj `
    --report-trx --report-trx-filename MSTestProject1.Tests.trx `
    --framework net10.0 `
    --results-directory ./artifacts/results `
    --verbosity normal `
    --coverlet `
    --coverlet-output-format cobertura `
    --diagnostic --diagnostic-verbosity trace `
    --diagnostic-file-prefix MSTestProject1 `
    --report-gh

Write-Step "Running .NET tool coverlet.console"

$repoRoot = if ($env:GITHUB_WORKSPACE) {
    $env:GITHUB_WORKSPACE
}
else {
    $PSScriptRoot
}

$testOutput = Join-Path $repoRoot "artifacts/bin/GlobalTool.Tests/debug_net10.0"
$testDll = Join-Path $testOutput "GlobalTool.Tests.dll"
$coverageOutput = Join-Path $repoRoot "artifacts/results/coverage.coverlet.console.json"
$time = Get-Date -Format 'yyyyMMdd-HHmmss'

#Get-ChildItem $testOutput -File |
#    Select-Object Name, Length

#Get-ChildItem (Join-Path $repoRoot "artifacts\bin") -Recurse -Filter *.pdb |
#    Select-Object FullName, Length

dotnet tool run coverlet $testOutput `
    --target "dotnet" `
    --targetargs "$testDll --report-xunit-trx --report-gh --report-xunit-trx-filename GlobalTool.Tests_$($time).trx" `
    --exclude [GlobalTool.Tests]* `
    --exclude [Microsoft.Testing.*]* `
    --exclude [xunit.v3.*]* `
    --exclude-assemblies-without-sources None `
    --output $coverageOutput `
    --verbosity trace `
    --diag "artifacts/results/coverlet.console.trace.log"

# check available pdb files
# Get-ChildItem "./artifacts" -recurse | Where-Object {$_.name -match "[a-zA-Z].pdb"} | foreach-object {write-host $_.FullName}

# Write-Step "Running test with dotnet-reportgenerator-mtp extension"

#dotnet run -c Debug --no-build `
#    --project test/Mtp1934.Core.Tests/Mtp1934.Core.Tests.csproj `
#    --report-xunit-trx `
#    --framework net10.0 `
#    --results-directory ./artifacts/results `
#    --verbosity normal `
#    --coverlet `
#    --coverlet-output-format cobertura `
#    --diagnostic --diagnostic-verbosity trace `
#    --diagnostic-file-prefix Mtp1934.Core
#   --reportgenerator

# ---------------------------------------------------------------------------
# Step 4 – Merge all Cobertura XML files and generate the HTML coverage report.
#           Output formats:
#             HtmlInline_AzurePipelines – interactive HTML report
#             Cobertura                 – merged XML (useful for CI pipelines)
#             Markdown                  – text summary
# ---------------------------------------------------------------------------
Write-Step "Generating coverage report"
dotnet tool run reportgenerator `
    "-reports:artifacts/results/coverage.cobertura*.xml" `
    "-targetdir:artifacts/CoverageReport" `
    "-reporttypes:HtmlInline_AzurePipelines;Cobertura;Markdown" `
    -verbosity:Verbose

Write-Host ""
Write-Host "Done! Open the report at: artifacts\CoverageReport\index.html" -ForegroundColor Green
