using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteAPI.Data;
using SiteAPI.Models;

namespace SiteAPI.Controllers
{
    [Route("api/artwork")]
    [ApiController]
    public class ArtworkController : ControllerBase
    {
        private readonly ArtworkDbContext _context;

        public ArtworkController(ArtworkDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var arts = await _context.Artworks.ToListAsync();

            if (arts == null) { return NotFound(); }

            return Ok(arts);

        }

        [HttpPost]
        
        public async Task<IActionResult> Add(Artwork art)
        {
            await _context.Artworks.AddAsync(art);
            await _context.SaveChangesAsync();

            return Ok(art);
        }
    }
}
