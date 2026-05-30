using Tickety.Modules.Events.Domain.Abstractions;

namespace Tickety.Modules.Events.Domain.Events;

public sealed class EventCreatedDomainEvent(Guid eventId) : DomainEvent
{
    public Guid EventId { get; init; } = eventId;
}

