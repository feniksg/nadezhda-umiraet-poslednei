using Microsoft.EntityFrameworkCore;
using SiteAPI.Models;

namespace SiteAPI.Data
{
    public class LifePeriodDbContext: DbContext
    {
        public LifePeriodDbContext(DbContextOptions<LifePeriodDbContext> options) : base(options) { }

        public DbSet<LifePeriod> LifePeriods { get; set; }
    }
}
