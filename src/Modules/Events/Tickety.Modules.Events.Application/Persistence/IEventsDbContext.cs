using Microsoft.EntityFrameworkCore;
using Tickety.Modules.Events.Domain.Events;

namespace Tickety.Modules.Events.Application.Persistence;

public interface IEventsDbContext
{
    DbSet<Event> Events { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
