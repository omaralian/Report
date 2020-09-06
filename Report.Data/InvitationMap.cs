using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Data
{
    public class InvitationMap
    {
        public InvitationMap(EntityTypeBuilder<Invitation> entityTypeBuilder)
        {
            entityTypeBuilder
                .HasKey(i => new { i.EventId, i.IndividualId });

            entityTypeBuilder
                .HasOne(i => i.Event)
                .WithMany(e => e.Invitations)
                .HasForeignKey(i => i.EventId)
                .IsRequired();

            entityTypeBuilder
                .HasOne(i => i.Individual)
                .WithMany(e => e.Invitations)
                .HasForeignKey(i => i.IndividualId)
                .IsRequired();
        }
    }
}
