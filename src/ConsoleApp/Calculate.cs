namespace ConsoleApp;

internal static class Calculate
{
    public static double Add(double n1, double n2)
    {
      double result = n1 + n2;
      Console.WriteLine("Received Add({0},{1}). Return: {2}", n1, n2, result);
      return result;
    }

    public static double Subtract(double n1, double n2)
    {
      double result = n1 - n2;
      Console.WriteLine("Received Subtract({0},{1}). Return: {2}", n1, n2, result);
      return result;
    }

    public static double Multiply(double n1, double n2)
    {
      double result = n1 * n2;
      Console.WriteLine("Received Multiply({0},{1}). Return: {2}", n1, n2, result);
      return result;
    }

    public static double Divide(double n1, double n2)
    {
      double result = n1 / n2;
      Console.WriteLine("Received Divide({0},{1}). Return: {2}", n1, n2, result);
      return result;
    }
  }
