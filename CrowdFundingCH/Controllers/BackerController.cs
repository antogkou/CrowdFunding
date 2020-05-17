using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrowdFundingCH.Controllers
{
    [Authorize(Roles="Backer")]
    public class BackerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}