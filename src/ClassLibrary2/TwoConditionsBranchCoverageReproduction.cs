// issue 1334
namespace ClassLibrary2;

public class TwoConditionsBranchCoverageReproduction
{
  public bool ExecuteReproduction(int number)
  {
    return number == 1 || number == 2;
  }

  public bool ExecuteReproduction2(int number)
  {
    bool isTrue = number == 1 || number == 2;
    return isTrue;
  }

  public bool ExecuteReproduction3(int number)
  {
    bool isTrue = number == 1 || number == 2;
    if (isTrue)
    {
      return true;
    }

    return false;
  }

  public bool ExecuteReproduction4(int? number)
  {
    return number != null && number == 2;
  }

  public bool ExecuteReturnBooleanValue(int number)
  {
    if (number == 1 || number == 2)
    {
      return true;
    }
    return false;
  }

  public bool ExecuteSecondAssertIsNeverTrue(int number)
  {
    return number == 1 || number == 2;
  }

  public bool ExecuteSecondAssertIsNeverTrue2(int number)
  {
    bool isTrue = number == 1 || number == 2;
    return isTrue;
  }

  public bool ExecuteSecondAssertIsNeverTrue3(int number)
  {
    bool isTrue = number == 1 || number == 2;
    if (isTrue)
    {
      return true;
    }

    return false;
  }

  public bool ExecuteSecondAssertIsNeverTrue4(int? number)
  {
    return number != null && number == 2;
  }
}
