using CrowdFundingCore.Models;
using CrowdFundingCore.Models.Options;
using CrowdFundingCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CrowdFundingMVC.Controllers
{
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
        //GETnotused
        //[HttpGet]
        //public IActionResult CreatePost()
        //{
        //    return View("/Project/SingleProject/{id}");
        //}

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

        [HttpDelete("{id}")]
        public IActionResult DeletePost(int id)
        {
            return Ok();
        }

        
        //[HttpGet("{id}/edit")]
        //public IActionResult Edit(int id)
        //{
        //    var post = _postservices.DeletePost(
        //        new SearchPostOptions()
        //        {
        //            PostId = id
        //        }).SingleOrDefault();

        //    return View(post);
        //}
    }
}