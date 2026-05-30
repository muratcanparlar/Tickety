using Tickety.Modules.Events.Domain.Abstractions;

namespace Tickety.Modules.Events.Domain.Categories;

public sealed class CategoryCreatedDomainEvent(Guid categoryId) : DomainEvent
{
    public Guid CategoryId { get; init; } = categoryId;
}
