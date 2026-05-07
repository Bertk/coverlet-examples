// issue 1334
using System;
using System.Diagnostics.CodeAnalysis;

namespace ClassLibrary2;

public static class ThrowExceptionViaMethodReproduction
{
  public static void EnsureNull(int? value)
  {
    if (!value.HasValue)
    {
      return;
    }

    CustomException.Throw(value.Value);
  }
}

public class CustomException : InvalidOperationException
{
  public CustomException(string message) : base(message)
  {
  }

  [DoesNotReturn]
  public static void Throw(int id)
  {
    throw new CustomException($"Id '{id}' is not allowed");
  }
}
