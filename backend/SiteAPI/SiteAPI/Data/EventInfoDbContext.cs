using Microsoft.EntityFrameworkCore;
using SiteAPI.Models;

namespace SiteAPI.Data
{
    public class EventInfoDbContext: DbContext
    {
        public EventInfoDbContext(DbContextOptions<EventInfoDbContext> options) : base(options) { }

        public DbSet<EventInfo> Events { get; set; }

    }
}
