using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteAPI.Data;
using SiteAPI.Models;

namespace SiteAPI.Controllers
{
    [Route("api/docs")]
    [ApiController]
    public class DocumentationsController : CrudController<Documentation, ApplicationDbContext>
    {
        public DocumentationsController(ApplicationDbContext context) : base(context) { }

        protected override bool ModelExists(int id)
        {
            return _context.Documentations.Any(e => e.Id == id);
        }

        protected override int GetModelId(Documentation model)
        {
            return model.Id;
        }
    }
}
