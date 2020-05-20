﻿using CrowdFundingCH.Areas.Identity.Data;
using CrowdFundingCH.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrowdFundingCH.Controllers
{

    [Authorize(Roles="Backer,Admin,Project Creator")]
    public class BackerController : Controller
    {
        //Injections
        private CrowdFundingDBContext db;

        public BackerController(CrowdFundingDBContext _db)
        {
            db = _db;
        }

        //Display List of Project in the Index view of Backer
        public async Task<IActionResult> Index()
        {
            var projects = db.Projects
                .AsNoTracking();
            return View(await projects.ToListAsync());
        }

        //CreateFund Landing Page
        public IActionResult CreateFund()
        {
            return View();
        }


    }
}