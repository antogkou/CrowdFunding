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

        //// [Authorize("Admin,Project Creator")]
        //[HttpPost]
        //public Project CreateProject([FromBody] ProjectOptions projOpt, PledgeOptions pledgeOptions)
        //{
        //    return _projMangr.CreateProject(projOpt, pledgeOptions);
        //}

        // [Authorize("Admin,Project Creator")]
        [HttpPost]
        public IActionResult CreateProject([FromBody] ProjectOptions projOpt, PledgeOptions pledgeOptions)
        {

            var result = _projMangr.CreateProject(projOpt, pledgeOptions);
            if (!result.Success)
            {
                return StatusCode((int)result.ErrorCode,
                    result.ErrorText);
            }

            return Json(result.Data);
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

        //CreatePledges
        [HttpPost]
        public IActionResult CreatePledges([FromBody] PledgeOptions pledgeOptions)
        {
            var result = _pledges.CreatePledges(pledgeOptions);

            if (!result.Success)
            {
                return StatusCode((int)result.ErrorCode,
                    result.ErrorText);
            }

            return Json(result.Data);
        }

        //Buy a pledge!
        [HttpPost]
        public IActionResult AddPledge([FromBody] PledgeProjectOptions pledgeProjectOptions)
        {
            var result = _pledges.AddPledge(pledgeProjectOptions.PledgeId, pledgeProjectOptions.ProjectId);

            if (!result.Success)
            {
                return StatusCode((int)result.ErrorCode,
                    result.ErrorText);
            }

            return Json(result.Data);
        }

        //Edit Project
        [HttpGet]
        public IActionResult EditProject([FromQuery]int projectId)
        {
            Project project = _projMangr.FindProjectById((int) projectId);
            return View(project); 
        }

        //UpdateProjectInfo
        [HttpPut("updateproject")]
        public bool UpdateProject([FromBody]int projectId, UpdateProjectOptions options)
        {
            ProjectOptions p = new ProjectOptions()
            {
                ProjectTitle = options.ProjectTitle,
                ProjectTargetAmount  = options.ProjectTargetAmount,
                ProjectDescription  = options.ProjectDescription,
                ProjectCategory  = options.ProjectCategory,
            };
            _projMangr.UpdateProject(projectId, options);
            return true;
            //_projMangr.UpdateProject(projectId, options);
        }


        [HttpGet]
        public IActionResult AddPledge()
        {
            return View();
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

        //Get backed user's projects View
        [HttpGet]
        public IActionResult GetMyBackedProjects()
        {
            string userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var projects = _db.Set<BackedPledges>()
                .Where(p => p.UserId == userId)
                .Select(p => p.BackedPledge)
                .Select(p=>p.Project)
                .Distinct();
                
               
            return View(projects);
        }

        //TODO
        [HttpGet]
        public IActionResult GetPopularProjects()
        {
            return View();
        }

    }
}