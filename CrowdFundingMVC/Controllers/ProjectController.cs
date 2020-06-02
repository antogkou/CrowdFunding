using CrowdFundingCore.Database;
using CrowdFundingCore.Models;
using CrowdFundingCore.Models.Options;
using CrowdFundingCore.Services.Interfaces;
using CrowdFundingMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CrowdFundingMVC.Controllers
{

    public class ProjectController : Controller
    {
        private IProjectServices _projMangr;
        private IPledgeServices _pledges;
        private IPostServices _postservices;
        private IMultimediaServices _multimediaServices;
        private readonly CrFrDbContext _db;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ProjectController(IProjectServices projMangr, CrFrDbContext db, IHttpContextAccessor _httpContextAccessor,
            IPledgeServices pledges, IPostServices postservices, IMultimediaServices multimediaServices)
        {
            _projMangr = projMangr;
            _pledges = pledges;
            _postservices = postservices;
            _multimediaServices = multimediaServices;
            _db = db;
            httpContextAccessor = _httpContextAccessor;
        }

        //Create Project View
        [Authorize(Roles = "Administrator, Project Creator")]
        [HttpGet]
        public IActionResult CreateProject()
        {
            return View();
        }

        [Authorize(Roles = "Administrator, Project Creator")]
        [HttpPost]
        //public IActionResult CreateProject([FromBody] ProjectOptions projOpt, PledgeOptions pledgeOptions, MultimediaOptions multimediaOptions)
        public IActionResult CreateProject([FromBody] ProjectOptions projOpt)
        {

            var result = _projMangr.CreateProject(projOpt);
            if (!result.Success)
            {
                return StatusCode((int)result.ErrorCode,
                    result.ErrorText);
            }

            return Json(result.Data);
        }

        //All Projects List search
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllProjects(string projectCategory, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> categoryQuery = from m in _db.Set<Project>()
                                               orderby m.ProjectCategory
                                               select m.ProjectCategory;

            var projects = from m in _db.Set<Project>()
                           select m;

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                projects = projects.Where(s => s.ProjectTitle.Contains(searchString));
            }

            if (!string.IsNullOrWhiteSpace(projectCategory))
            {
                projects = projects.Where(x => x.ProjectCategory == projectCategory);
            }

            var viewallprojects = new ProjectsGridVM
            {
                Categories = new SelectList(await categoryQuery.Distinct().ToListAsync()),
                Projects = await projects.ToListAsync(),
                ProjectMultimedia = _multimediaServices.GetAll()
            };

            return View(viewallprojects);
        }

        [Authorize(Roles = "Administrator, Backer, Project Creator")]
        [HttpPost]
        public string GetAllProjects(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        //Single Project View
        [Authorize(Roles = "Administrator, Backer, Project Creator")]
        [HttpGet]
        public IActionResult SingleProject(int id)
        {
            SingleProjectMV singleproject = new SingleProjectMV
            {
                Project = _projMangr.FindProjectById(id),
                Posts = _postservices.GetAllPosts(id),
                Pledges = _pledges.GetPledgesByProjectId(id),
                ProjectMultimedia = _multimediaServices.GetMultimediaOfProject(id),
            };

            return View(singleproject);
        }
        
        //Edit Project
        [Authorize(Roles = "Administrator, Project Creator")]
        [HttpGet, Route("Project/{projectId}/Edit/")]
        public IActionResult EditProject([FromRoute] int? projectId)
        {
            string userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (new EditProjectVM
            {
                Project = _projMangr.FindProjectById((int)projectId)
            }.Project != null)
                if (new EditProjectVM
                {
                    Project = _projMangr.FindProjectById((int)projectId)
                }.Project.UserId == userId)
                    return View(new EditProjectVM
                    {
                        Project = _projMangr.FindProjectById((int)projectId)
                    });
            return View("~/Views/Project/AuthorizationError.cshtml");

        }

        [Authorize(Roles = "Administrator, Project Creator")]
        [HttpPut]
        public IActionResult UpdateProject([FromBody] UpdateProjectOptions updateProjectOptions)
        {
            var result = _projMangr.UpdateProject(updateProjectOptions);

            if (!result.Success)
            {
                return StatusCode((int)result.ErrorCode,
                    result.ErrorText);
            }
            return Json(result.Data);
        }

        


        //Get current user's projects View
        [Authorize(Roles = "Administrator, Backer, Project Creator")]
        [HttpGet]
        public IActionResult GetMyProjects()
        {
            string userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var myprojectList = _db.Set<Project>()
                .Where(s => s.UserId == userId)
                .ToList();
            var myprojects = new ProjectsGridVM
            {
                Projects = myprojectList,
                ProjectMultimedia = _multimediaServices.GetAll()
            };
            return View(myprojects);
        }

        //Get backed user's projects View
        [Authorize(Roles = "Administrator, Backer, Project Creator")]
        [HttpGet]
        public IActionResult GetMyBackedProjects()
        {
            string userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var projects = _db.Set<BackedPledges>()
                .Where(p => p.UserId == userId)
                .Select(p => p.BackedPledge)
                .Select(p => p.Project)
                .Distinct();

            var mybackedprojects = new ProjectsGridVM
            {
                Projects = projects.ToList(),
                ProjectMultimedia = _multimediaServices.GetAll()
            };

            return View(mybackedprojects);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetTrendingProjects()
        {

            var projects = _db.Set<Project>()
                .Where(s => s.ProjectProgress > 0.35m)
                .Where(s => s.IsActive == true)
                .ToList();

            var trendingprojects = new ProjectsGridVM
            {
                Projects = projects,
                ProjectMultimedia = _multimediaServices.GetAll()
            };

            return View(trendingprojects);
        }

       


       


    }
}