// issue 1334
using System;
using System.Diagnostics.CodeAnalysis;

namespace ClassIssue1334;

[ExcludeFromCodeCoverage]
class Program
{
  static void Main()
      => Console.WriteLine("Hello World!");
}
