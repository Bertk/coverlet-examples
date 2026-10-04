namespace Issue1334
{
  public class Repo1334
  {
    public bool ExecuteWithCondition2(int number)
    {
      return number == 1 || number == 2;
    }

    public bool ExecuteWithCondition3(int number)
    {
      return number == 1 || number == 2 || number == 3;
    }
  }

  public static class RepoValues1334
  {
    public static bool ExecuteWithAndCondition(int number1, int number2, int number3, int number4)
    {
      return number1 == number2 && number3 == number4;
    }

    public static bool ExecuteWithOrCondition(int number1, int number2, int number3, int number4)
    {
      return number1 == number2 || number3 == number4;
    }
  }
}
