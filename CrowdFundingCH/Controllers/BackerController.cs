using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrowdFundingCH.Controllers
{

    [Authorize(Roles="Backer,Admin,Project Creator")]
    public class BackerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateFund()
        {
            return View();
        }
    }
}