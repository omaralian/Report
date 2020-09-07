using Microsoft.EntityFrameworkCore;
using Report.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Proxies;

namespace Report.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Individual> Individuals { get; set; }
        public DbSet<Invitation> Invitations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            // optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            new EventMap(builder.Entity<Event>());
            new IndividualMap(builder.Entity<Individual>());
            new InvitationMap(builder.Entity<Invitation>());

            builder.Entity<Event>()
                .HasData(
                    new Event { 
                        Id = 1, 
                        Title = "Yas Water World",
                        DateTime = DateTime.Now,
                        Status = EventStatus.OnHold
                    },
                    new Event
                    {
                        Id = 2,
                        Title = "Abu Dhabi International Hunting & Equestrian Exhibition",
                        DateTime = DateTime.Now,
                        Status = EventStatus.Completed
                    },
                    new Event
                    {
                        Id = 3,
                        Title = "Abu Dhabi International Book Fair",
                        DateTime = DateTime.Now,
                        Status = EventStatus.Closed
                    },
                    new Event
                    {
                        Id = 4,
                        Title = "Kayaking Around The Museum",
                        DateTime = DateTime.Now,
                        Status = EventStatus.Closed
                    },
                    new Event
                    {
                        Id = 5,
                        Title = "Hypercars: Evolution of Uniqueness",
                        DateTime = DateTime.Now,
                        Status = EventStatus.InProgress
                    }
                );

            builder.Entity<Individual>()
                .HasData(
                    new Individual
                    {
                        Id = 1,
                        FirstName = "Ahmad",
                        LastName = "Khalid"
                    },
                    new Individual
                    {
                        Id = 2,
                        FirstName = "Omar",
                        LastName = "Alian"
                    },
                    new Individual
                    {
                        Id = 3,
                        FirstName = "Mansour",
                        LastName = "Ahmad"
                    },
                    new Individual
                    {
                        Id = 4,
                        FirstName = "Khalid",
                        LastName = "Mohamed"
                    },
                    new Individual
                    {
                        Id = 5,
                        FirstName = "Abdullah",
                        LastName = "Naser"
                    },
                    new Individual
                    {
                        Id = 6,
                        FirstName = "Mohamed",
                        LastName = "Faisal"
                    },
                    new Individual
                    {
                        Id = 7,
                        FirstName = "Mahmoud",
                        LastName = "Omar"
                    },
                    new Individual
                    {
                        Id = 8,
                        FirstName = "Amjad",
                        LastName = "Mohamed"
                    },
                    new Individual
                    {
                        Id = 9,
                        FirstName = "Hasan",
                        LastName = "Hani"
                    }
                );

            builder.Entity<Invitation>()
                .HasData(
                    new Invitation
                    {
                        EventId = 1,
                        IndividualId = 1
                    },
                    new Invitation
                    {
                        EventId = 1,
                        IndividualId = 2
                    },
                    new Invitation
                    {
                        EventId = 1,
                        IndividualId = 3
                    },
                    new Invitation
                    {
                        EventId = 1,
                        IndividualId = 4
                    },
                    new Invitation
                    {
                        EventId = 1,
                        IndividualId = 5
                    },
                    new Invitation
                    {
                        EventId = 1,
                        IndividualId = 6
                    },
                    new Invitation
                    {
                        EventId = 1,
                        IndividualId = 7
                    },
                    new Invitation
                    {
                        EventId = 1,
                        IndividualId = 8
                    },
                    new Invitation
                    {
                        EventId = 1,
                        IndividualId = 9
                    },

                    new Invitation
                    {
                        EventId = 2,
                        IndividualId = 5
                    },
                    new Invitation
                    {
                        EventId = 2,
                        IndividualId = 6
                    },
                    new Invitation
                    {
                        EventId = 2,
                        IndividualId = 7
                    },
                    new Invitation
                    {
                        EventId = 2,
                        IndividualId = 8
                    },
                    new Invitation
                    {
                        EventId = 2,
                        IndividualId = 9
                    },

                    new Invitation
                    {
                        EventId = 3,
                        IndividualId = 3
                    },
                    new Invitation
                    {
                        EventId = 3,
                        IndividualId = 4
                    },
                    new Invitation
                    {
                        EventId = 3,
                        IndividualId = 5
                    },
                    new Invitation
                    {
                        EventId = 3,
                        IndividualId = 6
                    },
                    new Invitation
                    {
                        EventId = 3,
                        IndividualId = 7
                    },

                    new Invitation
                    {
                        EventId = 4,
                        IndividualId = 1
                    },
                    new Invitation
                    {
                        EventId = 4,
                        IndividualId = 4
                    },
                    new Invitation
                    {
                        EventId = 4,
                        IndividualId = 9
                    },

                    new Invitation
                    {
                        EventId = 5,
                        IndividualId = 2
                    },
                    new Invitation
                    {
                        EventId = 5,
                        IndividualId = 3
                    },
                    new Invitation
                    {
                        EventId = 5,
                        IndividualId = 8
                    }
                );
        }
    }
}
