using CrowdFundingAPI.Database;
using CrowdFundingAPI.Models;
using CrowdFundingAPI.Models.Options;
using CrowdFundingAPI.Services.Interfaces;
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

    public class ProjectController : BaseController
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
        [HttpPost]
        public string GetAllProjects(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
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

        [HttpGet]
        public IActionResult SingleProject(int? id)
        {
            SingleProjectMV singleproject = new SingleProjectMV
            {
                Project = _projMangr.FindProjectById((int)id),
                Posts = _postservices.GetAllPosts((int)id)
            };

            return View(singleproject);  // will automatically look in the views folder
        }

        //[HttpGet]
        //public IActionResult PledgesByProjId(int? id)
        //{
        //    var pledgebyprojid = _projMangr.PledgesByProjId((int)id);

        //    return View(pledgebyprojid);  
        //}

        [HttpGet]
        public IActionResult CreatePledges(int? id)
        {
            var createPledgepage = _pledges.FindPledgeById((int)id);
            return View(createPledgepage);
        }


        //[HttpPost("/CreatePledges/{projectId}")]
        //public Pledge CreatePledges(int projectId, [FromBody] PledgeOptions options)
        //{
        //    return _pledges.CreatePledges(projectId, options);
        //}

        //[HttpPost("project/CreatePledges/{projectId}")]
        //public async Task<IActionResult> CreatePledges2(int projectId,[FromBody] PledgeOptions options)
        //{
        //    var result = await _pledges.CreatePledges(projectId, options);

        //    return result.AsStatusResult();
        //}


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
        public Project CreateProject([FromBody] ProjectOptions projOpt, PledgeOptions pledgeOptions)
        {
            return _projMangr.CreateProject2(projOpt, pledgeOptions);
        }


        //[HttpGet]
        //public async Task<IActionResult> Index(int? id, int? projectID)
        //{
        //    var viewModel = new ProjectIndexData();
        //    viewModel.Posts = await _db.Set<Post>()
        //          .Include(i => i.PostTitle)
        //          .Include(i => i.PostDescription)
        //          .Include(i => i.PostDateCreated)
        //          .AsNoTracking()
        //          .OrderBy(i => i.PostDateCreated)
        //          .ToListAsync();


        //    return View(viewModel);
        //}

        [HttpGet]
        public IActionResult GetPopularProjects()
        {
            return View();
        }

        public async Task<IActionResult> GetPosts()
        {
            var projects = _db.Set<Project>()
                .Include(c => c.ProjectPosts)
                .AsNoTracking();
            return View(await projects.ToListAsync());
        }


    }
}