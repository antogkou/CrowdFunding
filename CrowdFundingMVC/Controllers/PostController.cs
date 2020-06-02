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
            //if (projectId == null)
            //{
            //    return BadRequest();
            //}
            //if (postId == null)
            //{
            //    return BadRequest();
            //}
            ////string userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            //var post = _postservices.SearchPosts(
            //   new PostOptions()
            //   {
            //       ProjectId = projectId.Value,
            //        // UserId = userId
            //    }).FirstOrDefault();

            //if (post == null)
            //{
            //    return NotFound();
            //}

            //return NotFound(); //404

            string userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (new EditPostVM
            {
                Post = _postservices.FindPostById((int)projectId.Value, (int)postId.Value),
                Project = _projectservices.FindProjectById((int)projectId.Value)
            }.Post != null)
                if (new EditPostVM
                {
                    Post = _postservices.FindPostById((int)projectId.Value, (int)postId.Value),
                    Project = _projectservices.FindProjectById((int)projectId.Value)
                }.Project.UserId == userId)

                    return View(new EditPostVM
                    {
                        Post = _postservices.FindPostById((int)projectId.Value, (int)postId.Value),
                        Project = _projectservices.FindProjectById((int)projectId.Value)
                    });
            return View("~/Views/Project/AuthorizationError.cshtml");

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