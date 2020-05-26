using CrowdFundingAPI.Database;
using CrowdFundingAPI.Models;
using CrowdFundingAPI.Models.Options;
using CrowdFundingAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CrowdFundingMVC.Controllers
{
    public class PledgeController : Controller
    {
        private IProjectServices _projMangr;
        private IPledgeServices _pledges;
        private readonly CrFrDbContext _db;
        private readonly IHttpContextAccessor httpContextAccessor;

        public PledgeController(IProjectServices projMangr, CrFrDbContext db,
            IHttpContextAccessor _httpContextAccessor,
            IPledgeServices pledges)
        {
            _projMangr = projMangr;
            _pledges = pledges;
            _db = db;
            httpContextAccessor = _httpContextAccessor;
        }

        [HttpGet]
        public IActionResult CreatePledges([FromRoute]int? id)
        {
           // TempData["projectid"] = id;
            //var createPledgepage = _pledges.FindPledgeById((int)id);
            return View();
        }
    
    }
}