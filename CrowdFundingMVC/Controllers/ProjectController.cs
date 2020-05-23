using CrowdFundingAPI.Database;
using CrowdFundingAPI.Models;
using CrowdFundingAPI.Models.Options;
using CrowdFundingAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        //[HttpGet]
        //public List<Project> GetAll()
        //{
        //    return _projservice.GetAll();
        //}
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
        public IActionResult GetAllProjects()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetPopularProjects()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // [HttpPost]

        //[HttpPost]
        //public Project AddProject([FromBody] ProjectOption projectopton)
        //{
        //    return projMangr.CreateProject(projectopton);
        //}
    }
}