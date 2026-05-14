using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassIssue1334;
using Xunit;


// // dotnet run --project test\Issue1334.Tests\Issue1334.Tests.csproj --report-trx --framework net10.0 --results-directory artifacts/results --verbosity normal --coverlet --coverlet-exclude [Moq]* --coverlet-output-format cobertura --diagnostic --diagnostic-verbosity trace --diagnostic-file-prefix Issue1334

namespace Issue1334.Tests;

public class AsyncEnumerableBatchExtensionReproductionFixture
{
    [Fact]
    public async Task ExecuteReproduction_UncoveredBranches()
    {
        // Arrange
        var enumerable = AsyncEnumerable.Range(1, 95);

        // Act
        IAsyncEnumerable<IAsyncEnumerable<int>> batches = enumerable.ExecuteReproduction(10);
         await foreach (IAsyncEnumerable<int> batch in batches)
         {
             await batch.ToArrayAsync();
         }

        // Assert
        // no assert
    }
}
