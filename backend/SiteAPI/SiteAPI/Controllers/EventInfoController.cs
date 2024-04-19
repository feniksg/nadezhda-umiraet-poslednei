using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteAPI.Data;
using SiteAPI.Models;

namespace SiteAPI.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventInfoController : CrudController<EventInfo, ApplicationDbContext>
    {
        public EventInfoController(ApplicationDbContext context) :base(context) { }

        protected override bool ModelExists(int id)
        {
            return _context.Events.Any(x => x.Id == id);
        }

        protected override int GetModelId(EventInfo model)
        {
            return model.Id;
        }
    }
}
