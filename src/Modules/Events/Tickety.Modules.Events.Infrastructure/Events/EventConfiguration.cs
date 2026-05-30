
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tickety.Modules.Events.Domain.Event;

namespace Tickety.Modules.Events.Infrastructure.Events;

internal class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
       builder.ToTable("event");
    }
}

