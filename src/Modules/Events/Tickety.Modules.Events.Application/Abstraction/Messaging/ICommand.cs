using MediatR;
using Tickety.Modules.Events.Domain.Abstractions;

namespace Tickety.Modules.Events.Application.Abstraction.Messaging;

public interface ICommand : IRequest<Result>, IBaseCommand;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand;

public interface IBaseCommand;
