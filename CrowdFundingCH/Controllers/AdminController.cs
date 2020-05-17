using System.Threading.Tasks;
using CrowdFundingCH.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CrowdFundingCH.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Roles="Admin")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

    }
}