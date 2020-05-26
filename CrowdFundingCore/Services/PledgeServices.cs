using CrowdFundingCore.Database;
using CrowdFundingCore.Models;
using CrowdFundingCore.Models.Options;
using CrowdFundingCore.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CrowdFundingCore.Services
{
    public class PledgeServices : IPledgeServices
    {

        private readonly IProjectServices projectservices;
        private CrFrDbContext _db;

        public PledgeServices(CrFrDbContext db, IProjectServices _projectservices)
        {
            _db = db;
            projectservices = _projectservices;
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

       

        //new find way
        public Pledge FindPledgeById(int id)
        {
            return _db.Set<Pledge>().Find(id);
        }
    }
}