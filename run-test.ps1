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
    --diagnostic-file-prefix NUnitProject1

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
    --diagnostic-file-prefix BranchIssues

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
    --diagnostic-file-prefix ConsoleApp

dotnet run -c Debug --no-build `
    --project test/XUnitProject1.Tests/XUnitProject1.Tests.csproj `
    --report-xunit-trx `
    --framework net10.0 `
    --results-directory ./artifacts/results `
    --verbosity normal `
    --coverlet `
    --coverlet-output-format cobertura `
    --diagnostic --diagnostic-verbosity trace `
    --diagnostic-file-prefix XUnitProject1

dotnet run -c Debug --no-build `
    --project test/Issue1334.Tests/Issue1334.Tests.csproj `
    --report-xunit-trx `
    --framework net10.0 `
    --results-directory ./artifacts/results `
    --verbosity normal `
    --coverlet `
    --coverlet-output-format cobertura `
    --diagnostic --diagnostic-verbosity trace `
    --diagnostic-file-prefix Issue1334

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
    --diagnostic-file-prefix MediatorApp

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
    --diagnostic-file-prefix Issue1417

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
    --diagnostic-file-prefix MSTestProject1

Write-Step "Running test with dotnet-reportgenerator-mtp extension"

dotnet run -c Debug --no-build `
    --project test/Mtp1934.Core.Tests/Mtp1934.Core.Tests.csproj `
    --report-xunit-trx `
    --framework net10.0 `
    --results-directory ./artifacts/results `
    --verbosity normal `
    --coverlet `
    --coverlet-output-format cobertura `
    --diagnostic --diagnostic-verbosity trace `
    --diagnostic-file-prefix Mtp1934.Core
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
