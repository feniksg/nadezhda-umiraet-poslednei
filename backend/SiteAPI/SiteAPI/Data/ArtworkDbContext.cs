using Microsoft.EntityFrameworkCore;
using SiteAPI.Models;

namespace SiteAPI.Data
{
    public class ArtworkDbContext : DbContext
    {
        public ArtworkDbContext(DbContextOptions<ArtworkDbContext> options): base(options) { }
    
        public DbSet<Artwork> Artworks { get; set; }
    }
}
