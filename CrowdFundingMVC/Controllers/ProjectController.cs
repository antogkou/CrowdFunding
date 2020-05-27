using CrowdFundingCore.Database;
using CrowdFundingCore.Models;
using CrowdFundingCore.Models.Options;
using CrowdFundingCore.Services.Interfaces;
using CrowdFundingMVC.ViewModels;
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
        private readonly CrFrDbContext _db;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ProjectController(IProjectServices projMangr, CrFrDbContext db, IHttpContextAccessor _httpContextAccessor,
            IPledgeServices pledges, IPostServices postservices)
        {
            _projMangr = projMangr;
            _pledges = pledges;
            _postservices = postservices;
            _db = db;
            httpContextAccessor = _httpContextAccessor;
        }

        //Create Project View
        [HttpGet]
        public IActionResult CreateProject()
        {
            return View();
        }

        // [Authorize("Admin,Project Creator")]
        [HttpPost]
        public Project CreateProject([FromBody] ProjectOptions projOpt, PledgeOptions pledgeOptions)
        {
            return _projMangr.CreateProject(projOpt, pledgeOptions);
        }

        //All Projects List search
        [HttpGet]
        public async Task<IActionResult> GetAllProjects(string projectCategory, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> categoryQuery = from m in _db.Set<Project>()
                                               orderby m.ProjectCategory
                                               select m.ProjectCategory;

            var projects = from m in _db.Set<Project>()
                           select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                projects = projects.Where(s => s.ProjectTitle.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(projectCategory))
            {
                projects = projects.Where(x => x.ProjectCategory == projectCategory);
            }

            var projectCategoryVM = new ProjectCategoryViewModel
            {
                Categories = new SelectList(await categoryQuery.Distinct().ToListAsync()),
                Projects = await projects.ToListAsync()
            };

            return View(projectCategoryVM);
        }

        [HttpPost]
        public string GetAllProjects(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        //Single Project View (with posts, TODO pledges/multimedia)
        [HttpGet]
        public IActionResult SingleProject(int? id)
        {
            SingleProjectMV singleproject = new SingleProjectMV
            {
                Project = _projMangr.FindProjectById((int)id),
                Posts = _postservices.GetAllPosts((int)id),
                Pledges = _pledges.GetPledgesByProjectId((int)id)
            };

            return View(singleproject);  // will automatically look in the views folder
        }

        [HttpGet]
        public IActionResult CreatePledges(int? id)
        {
            string userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (new SingleProjectMV
            {
                Project = _projMangr.FindProjectById((int)id),
                Pledges = _pledges.GetPledgesByProjectId((int)id)
            }.Project != null)
            {
                if (new SingleProjectMV
                {
                    Project = _projMangr.FindProjectById((int)id),
                    Pledges = _pledges.GetPledgesByProjectId((int)id)
                }.Project.UserId == userId)
                {
                    return View(new SingleProjectMV
                    {
                        Project = _projMangr.FindProjectById((int)id),
                        Pledges = _pledges.GetPledgesByProjectId((int)id)
                    });
                }
            }
            return NotFound(); //404
        }

        [HttpPost]
        public Pledge CreatePledges([FromBody] PledgeOptions pledgeOptions)
        {
            return _pledges.CreatePledges(pledgeOptions);
        }

        //Edit Project
        [HttpGet]
        public IActionResult EditProject(int projectId)
        {
            Project project = _projMangr.FindProjectById((int) projectId);

          
            return View(project); 
        }

        //[HttpPost]
        //public Project EditProject(int projectId, UpdateProjectOptions options)
        //{
        //    return _projMangr.UpdateProject(projectId, options);
        //}



        [HttpGet]
        public IActionResult AddPledge()
        {
            return View();
        }

        [HttpPost]
        public BackedPledges AddPledge(int projectId, int pledgeId)
        {
            return _pledges.AddPledge(projectId, pledgeId);
        }

        //Get current user's projects View
        [HttpGet]
        public IActionResult GetMyProjects()
        {
            string userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var myprojectList = _db.Set<Project>()
                .Where(s => s.UserId == userId)
                .ToList();

            return View(myprojectList);
        }


        //TODO
        [HttpGet]
        public IActionResult GetPopularProjects()
        {
            return View();
        }

        //public async Task<IActionResult> GetPosts()
        //{
        //    var projects = _db.Set<Project>()
        //        .Include(c => c.ProjectPosts)
        //        .AsNoTracking();
        //    return View(await projects.ToListAsync());
        //}
        //All Projects List OLD no search
        //[HttpGet]
        //public IActionResult GetAllProjectsOLD()
        //{
        //    var projectList = _projMangr
        //        .ListProjects(new ProjectOptions())
        //        .ToList();

        //    return View(projectList);
        //}

        //search by category and project title 
        //Get Project by Id Json
        //[HttpGet]
        //public IActionResult GetProjectById([FromRoute] int projectId)
        //{
        //    var project = _projMangr
        //    .SearchProject2(
        //        new ProjectOptions()
        //        {
        //            ProjectId = projectId
        //        }).SingleOrDefault();

        //    return Json(project);
        //}

        //Get My Projects by Id

    }
}