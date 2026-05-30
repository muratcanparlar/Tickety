using Microsoft.EntityFrameworkCore;
using Tickety.Modules.Events.Application.Persistence;
using Tickety.Modules.Events.Domain.Event;
using Tickety.Modules.Events.Infrastructure.Events;

namespace Tickety.Modules.Events.Infrastructure
{
    public class EventsDbContext(DbContextOptions<EventsDbContext> options) : DbContext(options), IEventsDbContext
    {
        public DbSet<Event> Events { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EventConfiguration());
        }
    }
}
