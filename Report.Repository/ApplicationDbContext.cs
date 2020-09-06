using Microsoft.EntityFrameworkCore;
using Report.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            new EventMap(builder.Entity<Event>());
            new IndividualMap(builder.Entity<Individual>());
            new InvitationMap(builder.Entity<Invitation>());
        }
    }
}
