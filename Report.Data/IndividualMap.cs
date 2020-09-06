using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Data
{
    public class IndividualMap
    {
        public IndividualMap(EntityTypeBuilder<Individual> entityTypeBuilder)
        {
            entityTypeBuilder
                .HasKey(i => i.Id);

            entityTypeBuilder
                .Property(i => i.Id)
                .ValueGeneratedOnAdd();

            entityTypeBuilder
                .Property(i => i.FirstName)
                .HasMaxLength(32)
                .IsRequired();

            entityTypeBuilder
                .Property(i => i.LastName)
                .HasMaxLength(32)
                .IsRequired();
        }
    }
}
