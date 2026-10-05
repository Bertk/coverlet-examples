using System;
using System.Linq.Expressions;

namespace ClassIssue2036
{
  public class CoverletRepro
  {
    private readonly bool _debugEnabled;
    private readonly Func<Expression, string?> _getText;
    public string? LastLoggedExpression { get; private set; }
    public bool AssemblyUnavailableLogged { get; private set; }

    public CoverletRepro(bool debugEnabled = true, Func<Expression, string?>? getText = null)
    {
      _debugEnabled = debugEnabled;
      _getText = getText ?? (expression => expression.ToString());
    }

    public void LogDebug(Expression expression)
    {
      ArgumentNullException.ThrowIfNull(expression);

      if (_debugEnabled)
      {
        string? text = _getText(expression);

        if (text != null)
        {
          LogExpression(text);
        }
        else
        {
          LogReadableExpressionsAssemblyUnavailable();
        }
      }
    }

    private void LogExpression(string text)
    {
      LastLoggedExpression = text;
    }

    private void LogReadableExpressionsAssemblyUnavailable()
    {
      AssemblyUnavailableLogged = true;
    }

    private interface IIdentifiable { }

    private class ControllerBase { }
    private class CoreJsonApiController : ControllerBase { }

    private class BaseJsonApiController<TResource, TId>
        : CoreJsonApiController
    {
    }

    private sealed class Resource : IIdentifiable { }

    private sealed class TestController<T>
        : CoreJsonApiController
    {
    }

    private sealed class DirectController<T> : ControllerBase
    {
    }

    private sealed class FallbackController<TResource>
        : BaseJsonApiController<TResource, int>
    {
    }

    public static Type? ExtractResourceClrTypeFromController(Type controllerType)
    {
      Type aspNetControllerType = typeof(ControllerBase);
      Type coreControllerType = typeof(CoreJsonApiController);
      Type baseControllerUnboundType = typeof(BaseJsonApiController<,>);
      Type? currentType = controllerType;

      while (!currentType.IsGenericType ||
             currentType.GetGenericTypeDefinition() != baseControllerUnboundType)
      {
        Type? nextBaseType = currentType.BaseType;

        if ((nextBaseType == aspNetControllerType ||
             nextBaseType == coreControllerType) &&
            currentType.IsGenericType)
        {
          Type? resourceClrType = FindIdentifiableArgument(currentType);

          if (resourceClrType != null)
          {
            return resourceClrType;
          }
        }

        currentType = nextBaseType;

        if (currentType == null)
        {
          break;
        }
      }

      return currentType?.GetGenericArguments()[0];
    }

    private static Type? FindIdentifiableArgument(Type currentType)
    {
      foreach (Type typeArgument in currentType.GetGenericArguments())
      {
        if (typeArgument == typeof(IIdentifiable))
        {
          return typeArgument;
        }

        foreach (Type implementedInterface in typeArgument.GetInterfaces())
        {
          if (implementedInterface == typeof(IIdentifiable))
          {
            return typeArgument;
          }
        }
      }

      return null;
    }
  }
}
