using CrowdFundingAPI.Models;
using CrowdFundingAPI.Models.Options;
using CrowdFundingAPI.Services.Interfaces;
using CrowdFundingAPI.Services;
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

        [HttpGet]
        public IActionResult CreatePost()
        {
            return View("/Project/SingleProject/{id}");
        }

        [HttpPost]
        public Post CreatePost([FromBody] PostOptions postOptions)
        {
            return _postservices.CreatePost(postOptions);
        }
    }
}