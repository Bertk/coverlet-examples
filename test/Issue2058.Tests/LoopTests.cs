using ClassIssue2058;
using Xunit;

namespace Issue2058.Tests;

public class LoopTests
{
  // JIT-compiles Loop.Run without running it.
  //[Fact]
  // public void RunJits() => RuntimeHelpers.PrepareMethod(typeof(ClassIssue2058.ClassLoop).GetMethod("Run")!.MethodHandle);

  [Fact]
  public void RunClassLoop()
  {
    ClassLoop loop = new ClassIssue2058.ClassLoop();
    //Act
    Exception exception = Record.Exception(loop.Run);
    //Assert
    Assert.Null(exception);
  }
}
