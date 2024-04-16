using Microsoft.EntityFrameworkCore;
using SiteAPI.Models;

namespace SiteAPI.Data
{
    public class DocumentationDbContext : DbContext
    {
        public DocumentationDbContext(DbContextOptions<DocumentationDbContext> options) : base(options) { }

        public DbSet<Documentation> documentations { get; set; }

    }
}
