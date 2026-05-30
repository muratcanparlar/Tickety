using MediatR;
using Tickety.Modules.Events.Domain.Abstractions;

namespace Tickety.Modules.Events.Application.Abstraction.Messaging;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;

