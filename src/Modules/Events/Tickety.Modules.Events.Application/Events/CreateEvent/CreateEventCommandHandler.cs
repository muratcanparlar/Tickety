using Tickety.Modules.Events.Application.Abstraction.Clock;
using Tickety.Modules.Events.Application.Abstraction.Messaging;
using Tickety.Modules.Events.Application.Persistence;
using Tickety.Modules.Events.Domain.Abstractions;
using Tickety.Modules.Events.Domain.Events;

namespace Tickety.Modules.Events.Application.Events.CreateEvent;

public class CreateEventCommandHandler(IEventsDbContext dbContext, IDateTimeProvider dateTimeProvider) : ICommandHandler<CreateEventCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        if (request.StartsAtUtc < dateTimeProvider.UtcNow)
        {
            return Result.Failure<Guid>(EventErrors.StartDateInPast);
        }

        Result<Event> result = Event.Create(
            request.Title,
            request.Description,
            request.Location,
            request.StartsAtUtc,
            request.EndsAtUtc);
        
        if (result.IsFailure)
        {
            return Result.Failure<Guid>(result.Error);
        }

        var createdEvent = result.Value;
    
        dbContext.Events.Add(createdEvent);
        await dbContext.SaveChangesAsync(cancellationToken);

        return createdEvent.Id;
    }

}
