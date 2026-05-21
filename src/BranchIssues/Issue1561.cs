using System.Threading.Tasks;

namespace Issue1561
{
  public class MyAsyncClass
  {
    static public async Task<int> DoAsyncAction()
    {
      return await Task.FromResult<int>(1);
    }
  }

  public record MyRecord(int A);
}
