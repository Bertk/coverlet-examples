using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.IO;
using System.Threading.Tasks;

// use this command for test execution and coverage collection:
// dotnet run --project test\Issue1337.Tests\Issue1337.Tests.csproj --report-trx --framework net10.0 --results-directory artifacts/results --verbosity normal --coverlet --coverlet-exclude [Moq]* --coverlet-output-format cobertura --diagnostic --diagnostic-verbosity trace --diagnostic-file-prefix Issue1337

namespace Issue_1337;

public class DoerOfStuffTests
{
  private Mock<ILogger<Issue1337.DoerOfStuff>> _loggerMock = null!;
  private Issue1337.DoerOfStuff _sut = null!;

  [SetUp]
  public void Setup()
  {
    _loggerMock = new Mock<ILogger<Issue1337.DoerOfStuff>>();
    _sut = new Issue1337.DoerOfStuff(_loggerMock.Object);
  }

  [Test]
  public async Task Test1_ActualWork_LogsResultAndWritesFile()
  {
    // Arrange
    var data = new Issue1337.Data(1, "test");
    var filePath = "simple.txt";

    // Act
    _sut.StartWithoutWaiting(data);
    await Task.Delay(500); // Allow background task to complete

    // Assert
    _loggerMock.Verify(
      x => x.Log(
        LogLevel.Information,
        It.IsAny<EventId>(),
        It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("Res")),
        null,
        It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
      Times.Once);

    _loggerMock.Verify(
      x => x.Log(
        LogLevel.Information,
        It.IsAny<EventId>(),
        It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("I'm finally here")),
        null,
        It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
      Times.Once);

    Assert.That(File.Exists(filePath), Is.True);
    Assert.That(await File.ReadAllTextAsync(filePath), Is.EqualTo("Hello World"));

    // Cleanup
    File.Delete(filePath);
  }

    [Test]
  public async Task Test2_ActualWork_LogsError_WhenExceptionOccurs()
  {
    // Arrange
    var data = new Issue1337.Data(1, "test");

    _loggerMock
      .Setup(x => x.Log(
        LogLevel.Information,
        It.IsAny<EventId>(),
        It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("Res")),
        It.IsAny<Exception?>(),
        It.IsAny<Func<It.IsAnyType, Exception?, string>>()))
      .Throws(new InvalidOperationException("Simulated failure"));

    // Act
    _sut.StartWithoutWaiting(data);
    await Task.Delay(500); // Allow background task to complete

    // Assert: catch block — LogError
    _loggerMock.Verify(
      x => x.Log(
        LogLevel.Error,
        It.IsAny<EventId>(),
        It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("Something bad happened")),
        It.IsAny<Exception>(),
        It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
      Times.Once);

    // Assert: finally block still runs
    _loggerMock.Verify(
      x => x.Log(
        LogLevel.Information,
        It.IsAny<EventId>(),
        It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("I'm finally here")),
        It.IsAny<Exception?>(),
        It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
      Times.Once);
  }
}
