using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Issue1633.Tests;

public class FolderServiceTests
{
  [Test]
  public void MapToInfo_WhenModeIsNullOrEmpty_IsHiddenIsFalse()
  {
    var source = new FolderSource { Mode = null, Creation = 42 };
    FolderInfoDto result = FolderService.MapToInfo(source);
    result.IsHidden.Should().BeFalse();
    result.Creation.Should().Be(42);
  }

  [Test]
  public void MapToInfo_WhenModeFourthCharIsNotH_IsHiddenIsFalse()
  {
    var source = new FolderSource { Mode = "rwxr", Creation = 10 };
    FolderInfoDto result = FolderService.MapToInfo(source);
    result.IsHidden.Should().BeFalse();
  }

  [Test]
  public void MapToInfo_WhenModeFourthCharIsH_IsHiddenIsTrue()
  {
    var source = new FolderSource { Mode = "rwxh", Creation = 10 };
    FolderInfoDto result = FolderService.MapToInfo(source);
    result.IsHidden.Should().BeTrue();
  }

  [Test]
  public void BuildCreateDto_WhenArgsIsNull_UsesDefaultPath()
  {
    CreateFolderDto dto = FolderService.BuildCreateDto(null);
    dto.Path.Should().Be(@"F:\rep1\rep2");
  }

  [Test]
  public void BuildCreateDto_WhenArgsHasPath_UsesProvidedPath()
  {
    var args = new Dictionary<string, object> { ["path"] = @"C:\custom\path" };
    CreateFolderDto dto = FolderService.BuildCreateDto(args);
    dto.Path.Should().Be(@"C:\custom\path");
  }

  [Test]
  public void BuildCreateDto_WhenArgsHasNoPathKey_UsesDefaultPath()
  {
    var args = new Dictionary<string, object> { ["other"] = "value" };
    CreateFolderDto dto = FolderService.BuildCreateDto(args);
    dto.Path.Should().Be(@"F:\rep1\rep2");
  }

  [Test]
  public void BuildDeleteDto_SetsPathCorrectly()
  {
    DeleteFolderDto dto = FolderService.BuildDeleteDto(@"L:\path\");
    dto.Path.Should().Be(@"L:\path\");
  }
}
