using MediatR;
using Tickety.Modules.Events.Application.Abstraction.Messaging;

namespace Tickety.Modules.Events.Application.Events.CreateEvent;

public record CreateEventCommand(string Title,
    string Description,
    string Location,
    DateTime StartsAtUtc,
    DateTime? EndsAtUtc
) : ICommand<Guid>;


