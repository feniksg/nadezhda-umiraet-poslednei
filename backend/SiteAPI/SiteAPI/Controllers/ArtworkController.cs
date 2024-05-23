using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteAPI.Data;
using SiteAPI.Models;

namespace SiteAPI.Controllers
{
    [Route("api/artworks")]
    [ApiController]
    public class ArtworkController: ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ArtworkController(ApplicationDbContext context) {
        
            _context = context;
        }

        private bool ModelExists(int id)
        {
            return _context.Artworks.Any(a => a.Id == id);
        }

        private int GetModelId(Artwork model)
        {
            return model.Id;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artwork>>> GetArtworks([FromQuery] string? search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return await _context.Artworks.ToListAsync();
            }

            var results = await _context.Artworks
                .Where(a => a.Title.Contains(search) || a.Description.Contains(search))
                .ToListAsync();

            return results;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _context.Artworks.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Edit(int id, Artwork model)
        {
            if (id != GetModelId(model))
            {
                return BadRequest();
            }

            _context.Entry(model).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public virtual async Task<IActionResult> Add(Artwork model)
        {
            await _context.Artworks.AddAsync(model);
            await _context.SaveChangesAsync();

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var model = await _context.Artworks.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            _context.Artworks.Remove(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
    

}
