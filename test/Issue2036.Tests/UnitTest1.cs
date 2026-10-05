using ClassIssue2036;
using System.Reflection;
using System.Linq.Expressions;

namespace Issue2036.Tests
{
  public class Issue2036Test
  {
    [Fact]
    public void ExtractResourceClrTypeFromControllerTest()
    {
      Assert.Null(
          CoverletRepro.ExtractResourceClrTypeFromController(typeof(string)));
    }

    [Fact]
    public void NullControllerTypeReturnsNull()
    {
      Assert.Null(CoverletRepro.ExtractResourceClrTypeFromController(null!));
    }

    [Fact]
    public void IdentifiableGenericArgumentIsReturned()
    {
      Type resourceType = GetNestedType("Resource");
      Type controllerType = GetNestedType("TestController`1").MakeGenericType(resourceType);

      Assert.Equal(
          resourceType,
          CoverletRepro.ExtractResourceClrTypeFromController(controllerType));
    }

    [Fact]
    public void IdentifiableInterfaceArgumentIsReturned()
    {
      Type identifiableType = GetNestedType("IIdentifiable");
      Type controllerType = GetNestedType("TestController`1").MakeGenericType(identifiableType);

      Assert.Equal(
          identifiableType,
          CoverletRepro.ExtractResourceClrTypeFromController(controllerType));
    }

    [Fact]
    public void IdentifiableGenericArgumentIsReturnedForAspNetControllerBase()
    {
      Type resourceType = GetNestedType("Resource");
      Type controllerType = GetNestedType("DirectController`1").MakeGenericType(resourceType);

      Assert.Equal(
          resourceType,
          CoverletRepro.ExtractResourceClrTypeFromController(controllerType));
    }

    [Fact]
    public void NonIdentifiableGenericArgumentUsesBaseControllerFallback()
    {
      Type resourceType = typeof(string);
      Type controllerType = GetNestedType("FallbackController`1").MakeGenericType(resourceType);

      Assert.Equal(
          resourceType,
          CoverletRepro.ExtractResourceClrTypeFromController(controllerType));
    }

    [Fact]
    public void NonIdentifiableGenericArgumentOnDirectControllerReturnsNull()
    {
      Type controllerType = GetNestedType("DirectController`1").MakeGenericType(typeof(string));

      Assert.Null(CoverletRepro.ExtractResourceClrTypeFromController(controllerType));
    }

    [Fact]
    public void FindIdentifiableArgumentReturnsNullForNonGenericType()
    {
      MethodInfo method = typeof(CoverletRepro).GetMethod(
          "FindIdentifiableArgument",
          BindingFlags.NonPublic | BindingFlags.Static)!;

      Type? result = (Type?)method.Invoke(null, [typeof(string)]);

      Assert.Null(result);
    }

    [Fact]
    public void LogDebugLogsFormattedExpression()
    {
      var repro = new CoverletRepro(getText: _ => "formatted expression");

      repro.LogDebug(Expression.Constant(1));

      Assert.Equal("formatted expression", repro.LastLoggedExpression);
      Assert.False(repro.AssemblyUnavailableLogged);
    }

    [Fact]
    public void LogDebugHandlesUnavailableFormatter()
    {
      var repro = new CoverletRepro(getText: _ => null);

      repro.LogDebug(Expression.Constant(1));

      Assert.Null(repro.LastLoggedExpression);
      Assert.True(repro.AssemblyUnavailableLogged);
    }

    [Fact]
    public void LogDebugSkipsFormattingWhenDebugIsDisabled()
    {
      var repro = new CoverletRepro(debugEnabled: false, getText: _ => throw new InvalidOperationException());

      repro.LogDebug(Expression.Constant(1));

      Assert.Null(repro.LastLoggedExpression);
      Assert.False(repro.AssemblyUnavailableLogged);
    }

    [Fact]
    public void LogDebugThrowsForNullExpression()
    {
      var repro = new CoverletRepro();

      Assert.Throws<ArgumentNullException>(() => repro.LogDebug(null!));
    }

    private static Type GetNestedType(string name)
    {
      return typeof(CoverletRepro).GetNestedType(name, BindingFlags.NonPublic)!;
    }
  }
}
