namespace Issue2037.App.Services.UnitTests;

public class CoverageTargetTests
{
  [Fact]
  public void NormalizeName_WhenNameHasWhitespace_ReturnsLoweredTrimmedValue()
  {
    CoverageTarget target = new();

    string result = target.NormalizeName("  Alice  ");

    Assert.Equal("alice", result);
  }
}
