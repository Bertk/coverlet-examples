using Mediator;

namespace MediatorApp1718;

public sealed class PingQueryHandler : IRequestHandler<PingQuery, string>
{
  public ValueTask<string> Handle(PingQuery request, CancellationToken cancellationToken)
  {
    return ValueTask.FromResult(request.Value);
  }
}
