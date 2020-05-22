using CrowdFundingAPI.Database;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CrowdFundingMVC.Controllers
{
    public class ProjectController : Controller
    {
        private IProjectService _projservice;
        private readonly CrFrDbContext _db;

        public ProjectController(IProjectService projservice, CrFrDbContext db)
        {
            _projservice = projservice;
            _db = db;

        }

        [HttpGet]
        public List<Project> GetAll()
        {
            return _projservice.GetAll();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}