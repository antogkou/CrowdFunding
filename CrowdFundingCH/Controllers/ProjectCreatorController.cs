using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrowdFundingCH.Controllers
{
    [Authorize(Roles = "Project Creator,Admin")]
    public class ProjectCreatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}