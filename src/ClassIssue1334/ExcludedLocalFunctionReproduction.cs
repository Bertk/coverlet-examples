// issue 1334
using System;
using System.Diagnostics.CodeAnalysis;

namespace ClassIssue1334;

public class ExcludedLocalFunctionReproduction
{
  public void SomethingThatIsUsingALocalFunction()
  {
    MethodThatTakesALambda(NewMethod());

    [ExcludeFromCodeCoverage(Justification = "Not testable")]
    static Func<string, bool> NewMethod()
    {
      return myString => myString.Length == 10;
    }
  }

  private void MethodThatTakesALambda(Func<string, bool> function)
  {
    _ = function != null;
  }
}
