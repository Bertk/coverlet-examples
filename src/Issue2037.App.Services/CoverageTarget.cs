namespace Issue2037.App.Services;

public sealed class CoverageTarget
{
  public string NormalizeName(string input)
  {
    return string.IsNullOrWhiteSpace(input) ? "unknown" : input.Trim().ToLowerInvariant();
  }
}
