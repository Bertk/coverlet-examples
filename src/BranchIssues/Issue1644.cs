using System;

namespace Issue1644
{
  public interface IService
  {
    TimeOnly? GetTime();
  }
  public static class ServiceExtensions
  {
    public static bool IsInPast(this IService service)
    {
      TimeOnly? timeFromService = service.GetTime();
      if (!timeFromService.HasValue) return true;

      bool isInPast = timeFromService < TimeOnly.FromDateTime(DateTime.UtcNow);

      return isInPast;
    }
  }
}
