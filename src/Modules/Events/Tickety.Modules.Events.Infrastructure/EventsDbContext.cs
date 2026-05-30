using Microsoft.EntityFrameworkCore;
using Tickety.Modules.Events.Application.Abstraction.Data;
using Tickety.Modules.Events.Domain.Categories;
using Tickety.Modules.Events.Domain.Events;
using Tickety.Modules.Events.Infrastructure.Categories;
using Tickety.Modules.Events.Infrastructure.Events;

namespace Tickety.Modules.Events.Infrastructure;

public class EventsDbContext(DbContextOptions<EventsDbContext> options) : DbContext(options), IUnitOfWork
{
    public DbSet<Event> Events { get; set; } = null!;

    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EventConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
    }
}
