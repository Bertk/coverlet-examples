using System;
using FluentAssertions;
using NUnit.Framework;
using NSubstitute;

namespace Issue1644.Tests
{
  public class ServiceExtensionsTests
  {
    [Test]
    public void IsInPast_ShouldBeTrue_WhenServiceHasNoTime()
    {
      // Arrange
      IService service = Substitute.For<IService>();
      service.GetTime().Returns((TimeOnly?)null);

      // Act
      bool result = service.IsInPast();

      // Assert
      result.Should().BeTrue();
    }

    [Test]
    public void IsInPast_ShouldBeTrue_WhenTimeIsInPast()
    {
      // Arrange
      IService service = Substitute.For<IService>();
      service.GetTime().Returns(new TimeOnly(0, 0));

      // Act
      bool result = service.IsInPast();

      // Assert
      result.Should().BeTrue();
    }

    [Test]
    public void IsInPast_ShouldBeFalse_WhenTimeIsInFuture()
    {
      // Arrange
      IService service = Substitute.For<IService>();
      service.GetTime().Returns(new TimeOnly(23, 59));

      // Act
      bool result = service.IsInPast();

      // Assert
      result.Should().BeFalse();
    }
  }
}
