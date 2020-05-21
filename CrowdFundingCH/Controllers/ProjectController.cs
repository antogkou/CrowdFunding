using CrowdFundingMVC.Areas.Identity.Data;
using CrowdFundingMVC.Options;
using CrowdFundingMVC.Services;
using Microsoft.AspNetCore.Mvc;
using CrowdFundingMVC.Models;

namespace CrowdFundingMVC.Controllers
{
    
    public class ProjectController : Controller
    {
        private readonly CrowdFundingDBContext _db;
        private IProjectService _projMangr;
       

        public ProjectController( CrowdFundingDBContext db, IProjectService projMangr)
        {
            _db = db;
            _projMangr = projMangr;
        }

        public IActionResult Index()
        {
            return View();
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