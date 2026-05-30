using MediatR;
using Tickety.Modules.Events.Application.Persistence;
using Tickety.Modules.Events.Domain.Events;

namespace Tickety.Modules.Events.Application.Events.CreateEvent;

internal class CreateEventCommandHandler(IEventsDbContext dbContext) : IRequestHandler<CreateEventCommand, Guid>
{
    private readonly IEventsDbContext _db = dbContext;

    public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        var createdEvent = new Event
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            Location = request.Location,
            StartsAtUtc = request.StartsAtUtc,
            EndsAtUtc = request.EndsAtUtc,
            Status = request.Status,
        };

        _db.Events.Add(createdEvent);
        await _db.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return createdEvent.Id;
    }
}
