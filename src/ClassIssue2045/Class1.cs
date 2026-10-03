using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace ClassIssue2045
{
  public static class CoverletRepro
  {
    public static void TestCapacity(uint capacity)
    {
      if (!BitOperations.IsPow2(capacity)
        || capacity < 16
        || capacity > (1u << 30))
      {
        Throw(capacity);   // <-- sequence point after this is uncovered
      }

      // Attribute DoesNotReturn Applies to:
      // .NET Core 3.0, Core 3.1, 5, 6, 7, 8, 9, 10, 11
      // .NET Standard 2.1
      // Attribute StackTraceHidden Applies to:
      // .NET Core 6, 7, 8, 9, 10, 11
      [DoesNotReturn, StackTraceHidden]
      static void Throw(uint capacity)
      {
        throw new ArgumentException(
        $"""
        Capacity must be a power of 2 in [16, 2^30].
        Actual value was {capacity}.
        """
      );
        // ^ entire body missing from coverage report
      }
    }
  }
}
