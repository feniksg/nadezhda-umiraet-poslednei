using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteAPI.Data;
using SiteAPI.Models;

namespace SiteAPI.Controllers
{
    [Route("api/periods")]
    [ApiController]
    public class LifePeriodController : CrudController<LifePeriod,ApplicationDbContext>
    {
        public LifePeriodController(ApplicationDbContext context) :base(context) { }

        protected override bool ModelExists(int id)
        {
            return _context.LifePeriods.Any(x => x.Id == id);
        }

        protected override int GetModelId(LifePeriod model)
        {
            return model.Id;
        }
    }
}
