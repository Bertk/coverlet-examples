// issue 1334
using System;
using System.Threading.Tasks;

namespace ClassLibrary2;

public class AsyncThrowReproduction
{
  public async Task Execute(bool throwException)
  {
    try
    {
      if (throwException)
      {
        throw new InvalidOperationException();
      }
    }
    catch (InvalidOperationException)
    {
      await Task.Delay(1);
      throw;
    }
  }

}
