using Microsoft.EntityFrameworkCore;
using SiteAPI.Models;

namespace SiteAPI.Data
{
    public class CustomUserDbContext : DbContext
    {
        public CustomUserDbContext(DbContextOptions<CustomUserDbContext> options) : base(options) { }

        public DbSet<CustomUser> CustomUsers { get; set; }
    }
}
