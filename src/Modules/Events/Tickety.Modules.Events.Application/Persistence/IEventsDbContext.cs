using Microsoft.EntityFrameworkCore;
using Tickety.Modules.Events.Domain.Event;

namespace Tickety.Modules.Events.Application.Persistence;

public interface IEventsDbContext
{
    DbSet<Event> Events { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
