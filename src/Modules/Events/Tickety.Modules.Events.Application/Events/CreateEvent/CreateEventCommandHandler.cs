using Tickety.Modules.Events.Application.Abstraction.Clock;
using Tickety.Modules.Events.Application.Abstraction.Data;
using Tickety.Modules.Events.Application.Abstraction.Messaging;
using Tickety.Modules.Events.Domain.Abstractions;
using Tickety.Modules.Events.Domain.Categories;
using Tickety.Modules.Events.Domain.Events;

namespace Tickety.Modules.Events.Application.Events.CreateEvent;

public class CreateEventCommandHandler(IEventRepository eventRepository, IUnitOfWork unitOfWork, IDateTimeProvider dateTimeProvider, ICategoryRepository categoryRepository) : ICommandHandler<CreateEventCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        if (request.StartsAtUtc < dateTimeProvider.UtcNow)
        {
            return Result.Failure<Guid>(EventErrors.StartDateInPast);
        }

        Category? category = await categoryRepository.GetAsync(request.CategoryId, cancellationToken);

        if (category is null)
        {
            return Result.Failure<Guid>(CategoryErrors.NotFound(request.CategoryId));
        }

        Result<Event> result = Event.Create(
            category,
            request.Title,
            request.Description,
            request.Location,
            request.StartsAtUtc,
            request.EndsAtUtc);
        
        if (result.IsFailure)
        {
            return Result.Failure<Guid>(result.Error);
        }

        eventRepository.Insert(result.Value);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return result.Value.Id;
    }

}
