using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SiteAPI.Controllers
{
    public abstract class CrudController<TModel, TContext> : ControllerBase
        where TModel : class
        where TContext : DbContext
    {
        protected readonly TContext _context;

        public CrudController(TContext context)
        {
            _context = context;
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetList()
        {
            var items = await _context.Set<TModel>().ToListAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetById(int id)
        {
            var item = await _context.Set<TModel>().FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Edit(int id, TModel model)
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
        public virtual async Task<IActionResult> Add(TModel model)
        {
            await _context.Set<TModel>().AddAsync(model);
            await _context.SaveChangesAsync();

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var model = await _context.Set<TModel>().FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            _context.Set<TModel>().Remove(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        protected abstract bool ModelExists(int id);
        protected abstract int GetModelId(TModel model);
    }
}
