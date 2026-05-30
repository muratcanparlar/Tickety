
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tickety.Modules.Events.Domain.Events;

namespace Tickety.Modules.Events.Infrastructure.Events;

internal class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
       builder.ToTable("event");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(e => e.CategoryId)
            .HasColumnName("category_id")
            .IsRequired();

        builder.Property(e => e.Title)
            .HasColumnName("title")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(e => e.Description)
            .HasColumnName("description")
            .IsRequired();

        builder.Property(e => e.Location)
            .HasColumnName("location")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(e => e.StartsAtUtc).HasColumnName("starts_at_utc");
        builder.Property(e => e.EndsAtUtc).HasColumnName("ends_at_utc");
        builder.Property(e => e.Status).HasColumnName("status");
    }
}

