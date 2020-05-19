using CrowdFundingCH.Areas.Identity.Data;
using CrowdFundingCH.Options;
using CrowdFundingCH.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrowdFundingCH.Models
{
    public class ProjectController : Controller
    {
       private IProjectManager projMangr;
       private readonly CrowdFundingDBContext _db;

        public ProjectController(IProjectManager _projMangr, CrowdFundingDBContext db)
        {
            projMangr = _projMangr;
            _db = db;
        }

        public IActionResult CreateProject()
        {
            return View();
        }

       // [Authorize("Admin,Project Creator")]
        [HttpPost]
        public Project CreateProject([FromBody] ProjectOptions projOpt)
        {
            return projMangr.CreateProject(projOpt);
        }

    }
}