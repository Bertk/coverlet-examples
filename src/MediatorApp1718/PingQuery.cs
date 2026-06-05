using Mediator;

namespace MediatorApp1718;

public sealed record PingQuery(string Value) : IRequest<string>;
