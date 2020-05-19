using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowdFundingCH.Areas.Identity.Data;
using CrowdFundingCH.Options;
using CrowdFundingCH.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrowdFundingCH.Models
{
    public class ProjectController : Controller
    {
        private IProjectManager projMangr;
        private readonly CrowdFundingDBContext _db;
        private readonly CrowdFundingDBContext _context;

        public ProjectController(IProjectManager _projMangr, CrowdFundingDBContext db)
        {
            projMangr = _projMangr;
            _db = db;
        }

        public IActionResult Index()
        {
            //List<ProjectCategory> projectCategoryList = new List<ProjectCategory>();
            //projectCategoryList = (from projectCategory in _db.ProjectCategory
            //                       select projectCategory).ToList();
            //projectCategoryList.Insert(0, new ProjectCategory { ProjectCategoryId = 0, ProjectCategoryName = "Select" });

            //ViewBag.ListofProjectCategory = projectCategoryList;
            return View();
        }

       // [Authorize("Admin,Project Creator")]
        [HttpPost]
        public Project AddProject([FromBody] ProjectOptions projOpt)
        {
            return projMangr.CreateProject(projOpt);
        }
        //[HttpPost]
        //[Authorize(Roles = "Admin,Project Creator")]
        //public async Task<IActionResult> CreateCategory([Bind("Id,Type,ProjectId")] ProjectCategory projectCategory)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _db.Add(projectCategory);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(projectCategory);
        //}


    }
}