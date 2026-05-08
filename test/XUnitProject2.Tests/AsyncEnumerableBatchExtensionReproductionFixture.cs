using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary2;
using Xunit;

namespace XUnitProject2.Tests;

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
