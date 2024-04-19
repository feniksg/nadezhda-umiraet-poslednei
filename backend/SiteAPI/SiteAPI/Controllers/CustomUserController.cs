using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteAPI.Data;
using SiteAPI.Models;

namespace SiteAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class CustomUserController : CrudController<CustomUser, ApplicationDbContext>
    {
        public CustomUserController(ApplicationDbContext context) :base(context) { }

        protected override bool ModelExists(int id)
        {
            return _context.CustomUsers.Any(u => u.Id == id);
        }

        protected override int GetModelId(CustomUser model)
        {
            return model.Id;    
        }
    }
}
