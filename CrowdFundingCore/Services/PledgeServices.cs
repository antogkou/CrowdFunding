using CrowdFundingCore.Database;
using CrowdFundingCore.Models;
using CrowdFundingCore.Models.Options;
using CrowdFundingCore.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CrowdFundingCore.Services
{
    public class PledgeServices : IPledgeServices
    {
        private readonly IProjectServices projectservices;
        private CrFrDbContext _db;
        private readonly IHttpContextAccessor httpContextAccessor;

        public PledgeServices(CrFrDbContext db, IProjectServices _projectservices,
            IHttpContextAccessor _httpContextAccessor)
        {
            _db = db;
            projectservices = _projectservices;
            httpContextAccessor = _httpContextAccessor;
        }

        //Get pledges by project id
        public List<Pledge> GetPledgesByProjectId(int projectId)
        {
            return _db.Set<Pledge>()
                .Where(p => p.Project.ProjectId == projectId)
                .ToList();
        }

        //Create Pledges
        public Pledge CreatePledges(PledgeOptions pledgeOptions)
        {
            var project = projectservices.FindProjectById(pledgeOptions.ProjectId);
            Pledge pledge = new Pledge
            {
                Project = project,
                PledgeTitle = pledgeOptions.PledgeTitle,
                PledgeDescription = pledgeOptions.PledgeDescription,
                PledgePrice = pledgeOptions.PledgePrice,
                PledgeReward = pledgeOptions.PledgeReward,
            };

            _db.Add(pledge);
            _db.SaveChanges();
            return pledge;
        }

        //Buy a pledge
        public BackedPledges AddPledge(int pledgeId, int projectId)
        {
            var project = projectservices.FindProjectById(projectId);
            var pledge =  _db
                .Set<Pledge>()
                .Where(i => i.PledgeId == 2)
                .SingleOrDefault();
            string userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var backedPledge = new BackedPledges()
            {
                UserId = userId,
                //PledgeId = pledge.PledgeId
                PledgeId = pledgeId
            };

            project.ProjectCurrentAmount += pledge.PledgePrice;

            _db.Add(backedPledge);
            _db.Update(project);

            _db.SaveChanges();

            return backedPledge;
        }

        //new find way
        public Pledge FindPledgeById(int id)
        {
            return _db.Set<Pledge>().Find(id);
        }
    }
}