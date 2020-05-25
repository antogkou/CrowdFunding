using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowdFundingAPI.Database;
using CrowdFundingAPI.Models;
using CrowdFundingAPI.Models.Options;
using CrowdFundingAPI.Services;
using CrowdFundingAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

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

        [HttpGet("/Project/CreatePledges/{id}")]
        //[HttpGet("/Project/CreatePledges/")]
        public IActionResult CreatePledges(int? id)
        {
            TempData["projectid"] = id;
            //ViewBag.projectID = projectId;
            var createPledgepage = _pledges.FindPledgeById((int)id);
            //return View();
            return View(createPledgepage);
        }


    [HttpPost]
    public Pledge CreatePledges([FromBody] PledgeOptions options)
    {
        return _pledges.CreatePledges(options);
    }


    public IActionResult Index()
    {
        return View();
    }
}
}