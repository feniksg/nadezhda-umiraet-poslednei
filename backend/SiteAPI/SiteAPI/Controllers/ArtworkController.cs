using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteAPI.Data;
using SiteAPI.Models;

namespace SiteAPI.Controllers
{
    [Route("api/arts")]
    [ApiController]
    public class ArtworkController : CrudController<Artwork, ApplicationDbContext>
    {
        public ArtworkController(ApplicationDbContext context) :base(context) { }

        public override async Task<IActionResult> GetList()
        {
            var items = await _context.Artworks
                .Include(art => art.LifePeriod)
                .Select(art => new { art.Id, art.YearCreated, art.Series, art.Genre, art.ImageFilePath, art.LifePeriod.Name })
                .ToListAsync();


            return Ok(items);
        }

        protected override bool ModelExists(int id)
        {
            return _context.Artworks.Any(a => a.Id == id);
        }

        protected override int GetModelId(Artwork model)
        {
            return model.Id;
        }
    }

}
