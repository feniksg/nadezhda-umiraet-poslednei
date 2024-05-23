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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite(settings.Value.ConnectionString);
            optionsBuilder.UseSqlite(configuration.GetConnectionString("SiteDb"));
        }


    }
}
