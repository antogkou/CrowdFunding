using CrowdFundingCore.Database;
using CrowdFundingCore.Models.Options;
using CrowdFundingCore.Services.Interfaces;
using CrowdFundingMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace CrowdFundingMVC.Controllers
{
    public class PledgeController : Controller
    {
        private IProjectServices _projectservices;
        private IPledgeServices _pledgesservices;
        private IPostServices _postservices;
        private readonly CrFrDbContext _db;
        private readonly IHttpContextAccessor httpContextAccessor;


        public PledgeController(IProjectServices projectservices, CrFrDbContext db, IHttpContextAccessor _httpContextAccessor,
           IPledgeServices pledgesservices, IPostServices postservices)
        {
            _projectservices = projectservices;
            _postservices = postservices;
            _pledgesservices = pledgesservices;
            _db = db;
            httpContextAccessor = _httpContextAccessor;
        }
        [Authorize(Roles = "Administrator, Project Creator")]
        [HttpGet]
        public IActionResult CreatePledges(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            string userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var project = _projectservices.ListProjects(
                new ProjectOptions()
                {
                    ProjectId = id.Value,
                    UserId = userId
                }).SingleOrDefault();

            if (project == null)
            {
                return NotFound();
            }


            return NotFound(); //404
        }


        //CreatePledges
        [Authorize(Roles = "Administrator, Project Creator")]
        [HttpPost]
        public IActionResult CreatePledges([FromBody] PledgeOptions pledgeOptions)
        {
            var result = _pledgesservices.CreatePledges(pledgeOptions);

            if (!result.Success)
            {
                return StatusCode((int)result.ErrorCode,
                    result.ErrorText);
            }

            return Json(result.Data);
        }


        //Buy a pledge!
        [Authorize(Roles = "Administrator, Backer, Project Creator")]
        [HttpPost]
        public IActionResult AddPledge([FromBody] PledgeProjectOptions pledgeProjectOptions)
        {
            var result = _pledgesservices.AddPledge(pledgeProjectOptions.PledgeId, pledgeProjectOptions.ProjectId);

            if (!result.Success)
            {
                return StatusCode((int)result.ErrorCode,
                    result.ErrorText);
            }

            return Json(result.Data);
        }


        [Authorize(Roles = "Administrator, Backer, Project Creator")]
        [HttpGet, Route("Project/SingleProject/{projectId}/AddPledge/")]
        public IActionResult AddPledge([FromRoute] int? projectId)
        {

            return View(new AddPledgeVM
            {
                Project = _projectservices.FindProjectById(projectId.Value),
            });
        }



        //Edit Pledge
        [AllowAnonymous]
        //[Authorize(Roles = "Administrator, Project Creator")]
        [HttpGet, Route("Project/SingleProject/{projectId}/EditPledge/{pledgeId}")]
        public IActionResult EditPledge([FromRoute] int? projectId, [FromRoute] int? pledgeId)
        {
            //if (projectId == null)
            //{
            //    return BadRequest();
            //}
            //if (pledgeId == null)
            //{
            //    return BadRequest();
            //}
            ////string userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            //var pledge = _pledgesservices.ListPledges(
            //   new PledgeOptions()
            //   {
            //       ProjectId = projectId.Value,
            //       PledgeId = pledgeId.Value,
            //        // UserId = userId
            //    }).SingleOrDefault();

            //if (pledge == null)
            //{
            //    return NotFound();
            //}


            //return NotFound(); //404
            string userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (new EditPledgeVM
            {
                Pledge = _pledgesservices.FindPledgeById((int)projectId.Value, (int)pledgeId.Value),
                Project = _projectservices.FindProjectById((int)projectId.Value)
            }.Pledge != null)
                if (new EditPledgeVM
                {
                    Pledge = _pledgesservices.FindPledgeById((int)projectId.Value, (int)pledgeId.Value),
                    Project = _projectservices.FindProjectById((int)projectId.Value)
                }.Project.UserId == userId)

                    return View(new EditPledgeVM
                    {
                        Pledge = _pledgesservices.FindPledgeById((int)projectId.Value, (int)pledgeId.Value),
                        Project = _projectservices.FindProjectById((int)projectId.Value)
                    });
            return View("~/Views/Project/AuthorizationError.cshtml");
        }

        [Authorize(Roles = "Administrator, Backer, Project Creator")]
        [HttpPut]
        public IActionResult UpdatePledge([FromBody] PledgeOptions pledgeOptions)
        {
            var result = _pledgesservices.UpdatePledge(pledgeOptions);

            if (!result.Success)
            {
                return StatusCode((int)result.ErrorCode,
                    result.ErrorText);
            }
            return Json(result.Data);
        }




    }
}
