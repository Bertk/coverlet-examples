using System.Collections.Generic;

namespace Issue1633;

public sealed record FolderInfoDto
{
  public bool IsHidden { get; init; }
  public long Creation { get; init; }
}

public sealed record FolderSource
{
  public string? Mode { get; init; }
  public long Creation { get; init; }
}

public abstract record BasicFolderDto
{
  public string? DfsMappedPath { get; init; }
  public string Path { get; init; } = null!;
}

public sealed record CreateFolderDto : BasicFolderDto;

public sealed record DeleteFolderDto : BasicFolderDto
{
  public bool Recurse { get; init; }
  public bool Force { get; init; }
}

public static class FolderService
{
  /// <summary>Maps a <see cref="FolderSource"/> to a <see cref="FolderInfoDto"/>.</summary>
  public static FolderInfoDto MapToInfo(FolderSource f)
  {
    return new()
    {
      Creation = f.Creation,
      IsHidden = f.Mode is { Length: > 3 } mode && mode[3] == 'h'
    };
  }

  /// <summary>Creates a <see cref="CreateFolderDto"/> from an optional args dictionary.</summary>
  public static CreateFolderDto BuildCreateDto(Dictionary<string, object>? args)
  {
    return new()
    {
      Path = args != null && args.TryGetValue("path", out var path) && path is string s
         ? s
        : @"F:\rep1\rep2",
    };
  }

  /// <summary>Creates a <see cref="DeleteFolderDto"/> for the given path.</summary>
  public static DeleteFolderDto BuildDeleteDto(string folderPath)
  {
    return new()
    {
      Path = folderPath,
    };
  }
}
