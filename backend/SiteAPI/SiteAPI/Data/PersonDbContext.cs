using Microsoft.EntityFrameworkCore;
using SiteAPI.Models;

namespace SiteAPI.Data
{
    public class PersonDbContext: DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options) { }

        public DbSet<Person> persons { get; set; }
    }
}
