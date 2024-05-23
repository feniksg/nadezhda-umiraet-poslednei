using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteAPI.Data;
using SiteAPI.Models;

namespace SiteAPI.Controllers
{
    [Route("api/artworks")]
    [ApiController]
    public class ArtworkController : CrudController<Artwork, ApplicationDbContext>
    {
        public ArtworkController(ApplicationDbContext context) :base(context) { }

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
