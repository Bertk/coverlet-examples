using System.CommandLine;
using System.CommandLine.Help;

namespace ConsoleApp;
static class Program
{
static async Task Main(string[] args)
{
    Option<int> delayOption = new("--delay") { Description = "delay in seconds", DefaultValueFactory = (_) => 42 };
    Option<string> calculateOption = new("--calculate") { DefaultValueFactory = (_) => "add", Required = false, Arity = ArgumentArity.ZeroOrOne };
    calculateOption.AcceptOnlyFromAmong("add", "subtract", "multiply", "Divide");
    Option<string> messageOption = new("--message") { Required = true };

    RootCommand rootCommand = new("CommandLine example")
    {
        delayOption,
        messageOption,
        new HelpOption(),
        new VersionOption() { Description = "SampleConsoleApp version" }
    };

    ParseResult parseResult = rootCommand.Parse(args);

    rootCommand.SetAction(_ =>
    {
      int delayOptionValue = parseResult.GetValue(delayOption);
      string calculateOptionValue = parseResult.GetValue(calculateOption) ?? "";
      string messageOptionValue = parseResult.GetValue(messageOption) ?? "unknown";
      DoRootCommand(delayOptionValue, messageOptionValue, messageOptionValue);
    });

    await parseResult.InvokeAsync().ConfigureAwait(false);

}

public static void DoRootCommand(int delay, string message, string calculate)
{
    Console.WriteLine($"--delay = {delay}");
    Console.WriteLine($"--message = {message}");
  if (!string.IsNullOrEmpty(calculate))
  {
    Console.WriteLine($"--calculate = {calculate}");
      switch (calculate)
      { 
        case "add":
        _ = Calculate.Add(10, 5);
        break;
      case "subtract":
        _ = Calculate.Subtract(10, 5);
        break;
      case "multiply":
        _ = Calculate.Multiply(10, 5);
        break;
      case "divide":
        _ = Calculate.Divide(10, 5);
        break;
      }
    }
  }
}
