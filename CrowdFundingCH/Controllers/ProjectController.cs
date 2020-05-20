using CrowdFundingCH.Areas.Identity.Data;
using CrowdFundingCH.Options;
using CrowdFundingCH.Services;
using CrowdFundingMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrowdFundingCH.Models
{
    public class ProjectController : Controller
    {
        private IProjectManager _projMangr;
        private readonly CrowdFundingDBContext _db;

        public ProjectController(IProjectManager projMangr, CrowdFundingDBContext db)
        {
            _projMangr = projMangr;
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
            return _projMangr.CreateProject(projOpt);
        }



        [HttpGet]
        public IActionResult SingleProjectView(int? id)
        {

            var singleproject = _projMangr.FindProjectById((int)id);

            // strongly typed view - by putting object into the view vs. ViewBag.ComicBook = comicBook;
            return View(singleproject);  // will automatically look in the views folder
        }

    }
}