using MediatR;
using Tickety.Modules.Events.Domain.Abstractions;

namespace Tickety.Modules.Events.Application.Abstraction.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;