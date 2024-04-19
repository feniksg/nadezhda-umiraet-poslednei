using Microsoft.EntityFrameworkCore;
using SiteAPI.Models;
using System.Reflection.Metadata;

namespace SiteAPI.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Artwork> Artworks { get; set; }
        public DbSet<CustomUser> CustomUsers { get; set; }
        public DbSet<Documentation> Documentations { get; set; }
        public DbSet<EventInfo> Events { get; set; }
        public DbSet<LifePeriod> LifePeriods { get; set;}
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LifePeriod>()
                .HasMany(e => e.Artworks)
                .WithOne(e => e.LifePeriod)
                .HasForeignKey(e => e.LifePeriodId)
                .HasPrincipalKey(e => e.Id);
        }


    }
}
