using System.Threading.Tasks;

namespace Issue1561
{
  public class MyAsyncClass
  {
#pragma warning disable CA1822 // Mark members as static
    public async Task<int> DoAsyncAction()
#pragma warning restore CA1822 // Mark members as static
    {
      return await Task.FromResult<int>(1);
    }
  }

  public record MyRecord(int A);
}
