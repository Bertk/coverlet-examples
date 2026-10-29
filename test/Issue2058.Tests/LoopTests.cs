using System.Runtime.CompilerServices;
using Xunit;

namespace Issue2058.Tests;

public class LoopTests
{
    // JIT-compiles Loop.Run without running it.
    [Fact]
    public void RunJits() => RuntimeHelpers.PrepareMethod(typeof(ClassIssue2058.ClassLoop).GetMethod("Run")!.MethodHandle);
}
