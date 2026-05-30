using Tickety.Modules.Events.Domain.Abstractions;
using Tickety.Modules.Events.Domain.Categories;

namespace Tickety.Modules.Events.Domain.Events;

public class Event : Entity
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; private set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string Location { get; set; }
    public DateTime StartsAtUtc { get; set; }
    public DateTime? EndsAtUtc { get; set; }
    public EventStatus Status { get; set; }


    public static Result<Event> Create(
       Category category,
       string title,
       string description,
       string location,
       DateTime startsAtUtc,
       DateTime? endsAtUtc
       )
    {
        if (endsAtUtc.HasValue && endsAtUtc < startsAtUtc)
        {
            return Result.Failure<Event>(EventErrors.EndDatePrecedesStartDate);
        }

        var @event = new Event
        {
            Id = Guid.NewGuid(),
            CategoryId = category.Id,
            Title = title,
            Description = description,
            Location = location,
            StartsAtUtc = startsAtUtc,
            EndsAtUtc = endsAtUtc,
            Status = EventStatus.Draft
        };

        @event.Raise(new EventCreatedDomainEvent(@event.Id));

        return @event;
    }
}
