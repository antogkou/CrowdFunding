using CrowdFundingCore.Models;
using CrowdFundingCore.Models.Options;
using CrowdFundingCore.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrowdFundingMVC.Controllers
{
    [Authorize(Roles = "Administrator, Project Creator")]
    public class PostController : Controller
    {
        private IProjectServices _projectservices;
        private IPostServices _postservices;
        public PostController(IPostServices postservices, IProjectServices projectServices)
        {
            _postservices = postservices;
            _projectservices = projectServices;
        }

        public IActionResult Index()
        {
            return View();
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

        [HttpPut]
        public IActionResult EditPost([FromBody] PostOptions postOptions)
        {
            var result = _postservices.EditPost(postOptions);
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