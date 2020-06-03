using CrowdFundingCore.Database;
using CrowdFundingCore.Models;
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
    [Authorize(Roles = "Administrator, Project Creator")]
    public class PostController : Controller
    {
        private IProjectServices _projectservices;
        private IPostServices _postservices;
        private readonly CrFrDbContext _db;
        private readonly IHttpContextAccessor httpContextAccessor;

        public PostController(CrFrDbContext db, IPostServices postservices, IProjectServices projectServices,
            IHttpContextAccessor _httpContextAccessor)
        {
            _db = db;
            _postservices = postservices;
            _projectservices = projectServices;
            httpContextAccessor = _httpContextAccessor;
        }

        //Edit Post
        [Authorize(Roles = "Administrator, Project Creator")]
        [HttpGet, Route("Project/SingleProject/{projectId}/EditPost/{postId}")]
        public IActionResult EditPost([FromRoute] int? projectId, [FromRoute] int? postId)
        {
                    var editpost = new EditPostVM()
                    {
                        Post = _postservices.FindPostById(projectId.Value, postId.Value),
                        Project = _projectservices.FindProjectById(projectId.Value)
                    };

                    return View(editpost);
        }

        //Create Post(comment)
        [HttpPost]
        public IActionResult CreatePost([FromBody] PostOptions postOptions)
        {
            var result = _postservices.CreatePost(postOptions);
            if (!result.Success)
            {
                return StatusCode((int)result.ErrorCode,
                    result.ErrorText);
            }

            return Json(result.Data);
        }

        [Authorize(Roles = "Administrator, Backer, Project Creator")]
        [HttpPut]
        public IActionResult UpdatePost([FromBody] PostOptions postOptions)
        {
            var result = _postservices.UpdatePost(postOptions);
            if (!result.Success)
            {
                return StatusCode((int)result.ErrorCode,
                    result.ErrorText);
            }

            return Json(result.Data);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePost(int id)
        {
            return Ok();
        }
    }
}