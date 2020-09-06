using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Data
{
    public class EventMap
    {
        public EventMap(EntityTypeBuilder<Event> entityTypeBuilder)
        {
            entityTypeBuilder
                .HasKey(e => e.Id);

            entityTypeBuilder
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entityTypeBuilder
                .Property(e => e.Title)
                .HasMaxLength(64)
                .IsRequired();

            entityTypeBuilder
                .Property(e => e.DateTime)
                .HasColumnType("datetime2")
                .IsRequired();

            entityTypeBuilder
                .Property(e => e.Status)
                .IsRequired();
        }
    }
}
