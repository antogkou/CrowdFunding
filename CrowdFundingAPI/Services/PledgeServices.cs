using CrowdFundingAPI.Database;
using CrowdFundingAPI.Models;
using CrowdFundingAPI.Models.Options;
using CrowdFundingAPI.Services.Interfaces;

namespace CrowdFundingAPI.Services
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

        //CreatePledges
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