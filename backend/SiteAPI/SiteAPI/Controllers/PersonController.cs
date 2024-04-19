using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteAPI.Data;
using SiteAPI.Models;

namespace SiteAPI.Controllers
{
    [Route("api/persons")]
    [ApiController]
    public class PersonController : CrudController<Person, ApplicationDbContext>
    {
        public PersonController(ApplicationDbContext context) :base(context) { }

        protected override bool ModelExists(int id)
        {
            return _context.Persons.Any(p => p.Id == id);
        }

        protected override int GetModelId(Person model)
        {
            return model.Id;
        }
    }
}
