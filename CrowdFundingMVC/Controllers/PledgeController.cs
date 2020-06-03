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
        private readonly CrFrDbContext _db;
        private readonly IHttpContextAccessor httpContextAccessor;


        public PledgeController(IProjectServices projectservices, CrFrDbContext db, IHttpContextAccessor _httpContextAccessor,
           IPledgeServices pledgesservices)
        {
            _db = db;
            _projectservices = projectservices;
            _pledgesservices = pledgesservices;
            httpContextAccessor = _httpContextAccessor;
        }

        //GET Add Pledge
        [Authorize(Roles = "Administrator, Backer, Project Creator")]
        [HttpGet, Route("Project/SingleProject/{projectId}/AddPledge/")]
        public IActionResult AddPledge([FromRoute] int? projectId)
        {
            var addpledge = new AddPledgeVM()
            {
                Project = _projectservices.FindMyProjectById(projectId.Value)
            };

            return View(addpledge);
        }

        //GET Edit Pledge
        [AllowAnonymous]
        //[Authorize(Roles = "Administrator, Project Creator")]
        [HttpGet, Route("Project/SingleProject/{projectId}/EditPledge/{pledgeId}")]
        public IActionResult EditPledge([FromRoute] int? projectId, [FromRoute] int? pledgeId)
        {
            var editpledge = new EditPledgeVM()
            {
                Pledge = _pledgesservices.FindPledgeById((int)projectId.Value, (int)pledgeId.Value),
                Project = _projectservices.FindMyProjectById((int)projectId.Value)
            };
            if (editpledge != null)
                return View(editpledge);
            return NotFound();
        }


        //POST CreatePledges
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

        //POST Buy a pledge!
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

        //POST Update Pledge
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

        [HttpDelete]
        public bool DeletePledge([FromBody] PledgeOptions pledgeOptions)
        {
            if (pledgeOptions != null)
                return _pledgesservices.DeletePledge(pledgeOptions.PledgeId);
            return false;
        }
    }
}