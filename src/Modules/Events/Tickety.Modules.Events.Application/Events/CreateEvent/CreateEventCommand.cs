using MediatR;

namespace Tickety.Modules.Events.Application.Events.CreateEvent;

public record CreateEventCommand(string Title,
    string Description,
    string Location,
    DateTimeOffset StartsAtUtc,
    DateTimeOffset EndsAtUtc,
    string Status
) : IRequest<Guid>;


