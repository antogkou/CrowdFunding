using CrowdFundingCore.Database;
using CrowdFundingCore.Models;
using CrowdFundingCore.Models.Options;
using CrowdFundingCore.Services.Interfaces;
using CrowdFundingMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingMVC.Controllers
{

    public class ProjectController : Controller
    {
        private IProjectServices _projectservices;
        private IPledgeServices _pledgesservices;
        private IPostServices _postservices;
        private IMultimediaServices _multimediaServices;
        private readonly CrFrDbContext _db;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IWebHostEnvironment hostingEnvironment;

        public ProjectController(IProjectServices projectservices, CrFrDbContext db,
            IHttpContextAccessor _httpContextAccessor,
            IPledgeServices pledgesservices,
            IPostServices postservices,
            IMultimediaServices multimediaServices,
            IWebHostEnvironment environment)
        {
            _projectservices = projectservices;
            _pledgesservices = pledgesservices;
            _postservices = postservices;
            _multimediaServices = multimediaServices;
            _db = db;
            httpContextAccessor = _httpContextAccessor;
            hostingEnvironment = environment;
        }

        //Create Project View
        [Authorize(Roles = "Administrator, Project Creator")]
        [HttpGet]
        public IActionResult CreateProject()
        {
            return View();
        }

        //Get backed user's projects View
        [Authorize(Roles = "Administrator, Backer, Project Creator")]
        [HttpGet]
        public IActionResult GetMyBackedProjects()
        {
            var mybackedprojects = new ProjectsGridVM()
            {
                Projects = _projectservices.GetMyBackedProjects().ToList(),
                ProjectMultimedia = _multimediaServices.GetAll()
            };
            return View(mybackedprojects);
        }

        //Get current user's projects View
        [Authorize(Roles = "Administrator, Backer, Project Creator")]
        [HttpGet]
        public IActionResult GetMyProjects()
        {
            var myprojects = new ProjectsGridVM
            {
                Projects = _projectservices.GetMyProjects().ToList(),
                ProjectMultimedia = _multimediaServices.GetAll()
            };
            return View(myprojects);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetTrendingProjects()
        {
            var trendingprojects = new ProjectsGridVM
            {
                Projects = _projectservices.GetTrendingProjects().ToList(),
                ProjectMultimedia = _multimediaServices.GetAll()
            };

            return View(trendingprojects);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult CompletedProjects()
        {
            var completedprojects = new ProjectsGridVM
            {
                Projects = _projectservices.GetCompletedProjects().ToList(),
                ProjectMultimedia = _multimediaServices.GetAll()
            };

            return View(completedprojects);
        }

        //All Projects List search
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllProjects(string projectCategory, string searchString)
        {
            //Use LINQ to get list of genres.
            IQueryable<string> categoryQuery = from m in _db.Set<Project>()
                                               orderby m.ProjectCategory
                                               select m.ProjectCategory;
            var viewallprojects = new ProjectsGridVM
            {
                Categories = new SelectList(await categoryQuery.Distinct().ToListAsync()),
                Projects = _projectservices.GetAllActiveProjects(projectCategory, searchString).ToList(),
                ProjectMultimedia = _multimediaServices.GetAll()
            };

            return View(viewallprojects);
        }

        //Single Project View
        [Authorize(Roles = "Administrator, Backer, Project Creator")]
        [HttpGet]
        public IActionResult SingleProject(int id)
        {
            SingleProjectMV singleproject = new SingleProjectMV
            {
                Project = _projectservices.FindProjectById(id),
                Posts = _postservices.GetAllPosts(id),
                Pledges = _pledgesservices.GetPledgesByProjectId(id),
                PledgeUsers = _pledgesservices.GetUsersPledges(id),
                ProjectMultimedia = _multimediaServices.GetMultimediaOfProject(id),
            };
            if (singleproject != null)
                return View(singleproject);
            return NotFound();
        }

        //Edit Project
        [Authorize(Roles = "Administrator, Project Creator")]
        [HttpGet, Route("Project/{projectId}/Edit/")]
        public IActionResult EditProject([FromRoute] int projectId)
        {
            var editproject = _projectservices.FindMyProjectById(projectId);
            if (editproject != null)
                return View(editproject);
            return NotFound();
        }

        //search projects
        [Authorize(Roles = "Administrator, Backer, Project Creator")]
        [HttpPost]
        public string GetAllProjects(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }


        [Authorize(Roles = "Administrator, Project Creator")]
        [HttpPost]
        public IActionResult CreateProject([FromForm] ProjectOptions projectoptions)
        {



            if (projectoptions.MultimediaURL != null)
            {
                var uniqueFileName = GetUniqueFileName(projectoptions.MultimediaURL.FileName);
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
                var filePath = Path.Combine(uploads, uniqueFileName);
                projectoptions.MultimediaURL.CopyTo(new FileStream(filePath, FileMode.Create));

                projectoptions.FilePath = "/uploads/" + uniqueFileName;
                //to do : Save uniqueFileName  to your db table   
                var result = _projectservices.CreateProject(projectoptions);

                if (!result.Success)
                {
                    return StatusCode((int)result.ErrorCode,
                        result.ErrorText);
                }

                return Json(result.Data);
            }

            else return NotFound();
        }
        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }


        //Update Project
        [Authorize(Roles = "Administrator, Project Creator")]
        [HttpPut]
        public IActionResult UpdateProject([FromBody] UpdateProjectOptions updateProjectOptions)
        {
            var result = _projectservices.UpdateProject(updateProjectOptions);

            if (!result.Success)
            {
                return StatusCode((int)result.ErrorCode,
                    result.ErrorText);
            }
            return Json(result.Data);
        }


    }
}