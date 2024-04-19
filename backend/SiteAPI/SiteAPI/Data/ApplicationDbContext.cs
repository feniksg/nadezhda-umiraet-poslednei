using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SiteAPI.Models;
using SiteAPI.Settings;
using System.Configuration;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace SiteAPI.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IOptions<SettingsOptions> settings, IConfiguration configuration) : DbContext(options)
    {

        public DbSet<Artwork> Artworks { get; set; }
        public DbSet<CustomUser> CustomUsers { get; set; }
        public DbSet<Documentation> Documentations { get; set; }
        public DbSet<EventInfo> Events { get; set; }
        public DbSet<LifePeriod> LifePeriods { get; set;}
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)                     //переопределение методв из базового DBContext
        {
            modelBuilder.Entity<LifePeriod>()
                .HasMany(e => e.Artworks)
                .WithOne(e => e.LifePeriod)
                .HasForeignKey(e => e.LifePeriodId)                                          //внешний ключ в табл арта связывание картины с периодом жизни
                .HasPrincipalKey(e => e.Id);                                                //в качестве ключа по которому происх соответствие исп ид из сущности LifePeriod
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite(settings.Value.ConnectionString);
            optionsBuilder.UseSqlite(configuration.GetConnectionString("SiteDb"));
        }


    }
}
