using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tickety.Modules.Events.Domain.TicketTypes;

namespace Tickety.Modules.Events.Infrastructure.TicketTypes;

public class TicketTypeConfiguration : IEntityTypeConfiguration<TicketType>
{
    public void Configure(EntityTypeBuilder<TicketType> builder)
    {
        builder.ToTable("ticket_type");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(t => t.EventId)
            .HasColumnName("event_id")
            .IsRequired();

        builder.Property(t => t.Name)
            .HasColumnName("name")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(t => t.Price)
            .HasColumnName("price")
            .HasColumnType("numeric(18,2)")
            .IsRequired();

        builder.Property(t => t.Currency)
            .HasColumnName("currency")
            .HasMaxLength(3)
            .IsRequired();

        builder.Property(t => t.Quantity)
            .HasColumnName("quantity")
            .HasColumnType("integer")
            .IsRequired();

        builder.Property(t => t.CreatedAtUtc);
        //.HasColumnName("created_at_utc")
        //.HasColumnType("timestamp(6) with time zone")
        //.IsRequired();

        builder.Property(t => t.UpdatedAtUtc);
            //.HasColumnName("updated_at_utc")
            //.HasColumnType("timestamp(6) with time zone")
            //.IsRequired(false)
            //.HasConversion(new ValueConverter<DateTime?, DateTime?>(
            //    v => v.HasValue ? (v.Value.Kind == DateTimeKind.Utc ? v.Value : v.Value.ToUniversalTime()) : v,
            //    v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : v));

        builder.HasIndex(t => t.EventId)
            .HasDatabaseName("ix_ticket_type_event_id");
    }
}
