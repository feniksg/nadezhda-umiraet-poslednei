using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteAPI.Data;
using SiteAPI.Models;

namespace SiteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomUserController : ControllerBase
    {
        private readonly CustomUserDbContext _context; 
        public CustomUserController(CustomUserDbContext customUserDbContext)
        {
            _context = customUserDbContext;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var users = await _context.CustomUsers.ToListAsync();
            
            if (users == null) {  return NotFound(); }
            
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CustomUser user)
        {
            await _context.CustomUsers.AddAsync(user);
            await _context.SaveChangesAsync();
            
            return Ok(user);
        }
    }
}
