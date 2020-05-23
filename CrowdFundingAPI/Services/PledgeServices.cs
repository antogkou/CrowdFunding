using CrowdFundingAPI.Database;
using CrowdFundingAPI.Models;
using CrowdFundingAPI.Models.Options;
using CrowdFundingAPI.Services.Interfaces;

namespace CrowdFundingAPI.Services
{
    public class PledgeServices : IPledgeServices
    {
        private CrFrDbContext _db;
        private IPledgeServices _pledgeManagr;

        public PledgeServices(CrFrDbContext db, IPledgeServices pledgeManagr)
        {
            _db = db;
            _pledgeManagr = pledgeManagr;
        }

        public Pledge CreatePledge(PledgeOptions pledgeOptions)
        {
            Project project = _db.Set<Project>().Find(pledgeOptions.ProjectId);
            Pledge pledge = new Pledge
            {
                PledgeTitle = pledgeOptions.PledgeTitle,
                PledgePrice = pledgeOptions.PledgePrice,
                PledgeReward = pledgeOptions.PledgeReward,
                Project = project
            };

            _db.Set<Pledge>().Add(pledge);
            _db.SaveChanges();
            return pledge;
        }


    }
}
