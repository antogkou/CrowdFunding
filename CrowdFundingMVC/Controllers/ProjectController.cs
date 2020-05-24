﻿using CrowdFundingAPI.Database;
using CrowdFundingAPI.Models;
using CrowdFundingAPI.Models.Options;
using CrowdFundingAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CrowdFundingMVC.Controllers
{
    
    public class ProjectController : Controller
    {
        private IProjectServices _projMangr;
        private IPledgeServices _pledges;

        private readonly CrFrDbContext _db;

        private readonly IHttpContextAccessor httpContextAccessor;

        public ProjectController(IProjectServices projMangr, CrFrDbContext db, IHttpContextAccessor _httpContextAccessor, 
            IPledgeServices pledges)
        {
            _projMangr = projMangr;
            _pledges = pledges;
            _db = db;
            httpContextAccessor = _httpContextAccessor;
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

        [HttpGet]
        public IActionResult CreatePledges(int? id)
        {
            var createPledgepage = _pledges.FindPledgeById((int)id);
            return View(createPledgepage);  
        }

        [HttpPost("/CreatePledges/{ProjectId}")]
        public Pledge CreatePledges([FromRoute]int ProjectId, PledgeOptions options)
        {
            return _pledges.CreatePledges(ProjectId, options);
        }

        //Get Project by Id
        [HttpGet]
        public IActionResult GetProjectById([FromRoute] int projectId)
        {
            var project = _projMangr
            .SearchProject2(
                new ProjectOptions()
                {
                    ProjectId = projectId
                }).SingleOrDefault();

            return Json(project);
        }

        //Get My Projects by Id
        [HttpGet]
        public IActionResult GetMyProjects()
        {
            string userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var myprojectList = _db.Set<Project>()
                .Where(s => s.UserId == userId)
                .ToList();

            return View(myprojectList);
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

        //
        //[HttpPost]
        //public Project AddPledge([FromRoute] PledgeOptions pledgeOpts)
        //{
        //    return _projMangr.CreateProject2(pledgeOpts);
        //}

        
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

        

    }
}