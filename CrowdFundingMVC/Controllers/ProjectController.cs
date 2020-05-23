using CrowdFundingAPI.Database;
using CrowdFundingAPI.Models;
using CrowdFundingAPI.Models.Options;
using CrowdFundingAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingMVC.Controllers
{
    public class ProjectController : Controller
    {
        private IProjectServices _projMangr;
        private readonly CrFrDbContext _db;

        public ProjectController(IProjectServices projMangr, CrFrDbContext db)
        {
            _projMangr = projMangr;
            _db = db;
        }
       
        //All Projects List
        [HttpGet]
        public IActionResult GetAllProjects()
        {
            var projectList = _projMangr
                .ListProjects(new ProjectOptions())
                .ToList();

            return View(projectList);
        }

        [HttpGet]
        public IActionResult SingleProject(int? id)
        {
            var singleproject = _projMangr.FindProjectById((int)id);

            // strongly typed view - by putting object into the view vs. ViewBag.ComicBook = comicBook;
            return View(singleproject);  // will automatically look in the views folder
        }

        //Get Project by Id
        [HttpGet]
        public IActionResult GetProjectById([FromRoute] int projectId)
        {
            var project = _projMangr
            .SearchProject(
                new ProjectOptions()
                {
                    ProjectId = projectId
                }).SingleOrDefault();

            return Json(project);
        }

        //Create Project
        [HttpGet]
        public IActionResult CreateProject()
        {
            return View();
        }

        // [Authorize("Admin,Project Creator")]
        [HttpPost]
        public Project CreateProject([FromBody] ProjectOptions projOpt)
        {
            return _projMangr.CreateProject2(projOpt);
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetPopularProjects()
        {
            return View();
        }


        // [HttpPost]

        //[HttpPost]
        //public Project AddProject([FromBody] ProjectOption projectopton)
        //{
        //    return projMangr.CreateProject(projectopton);
        //}

        //old_not_working
        //[HttpGet]
        //public List<Project> GetAll()
        //{
        //    return _projMangr.ListProjects();
        //}
    }
}