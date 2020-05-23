using CrowdFundingAPI.Database;
using CrowdFundingAPI.Models;
using CrowdFundingAPI.Models.Options;
using CrowdFundingAPI.Services.Interfaces;

namespace CrowdFundingAPI.Services
{
    public class PledgeServices : IPledgeServices
    {
        private CrFrDbContext _db;

        public PledgeServices(CrFrDbContext db)
        {
            _db = db;
        }

        //public Pledge CreatePledge(PledgeOptions pledgeOptions)
        //{
        //    //var project = _db.Set<Project>().GetProjectById(projectId);

        //    Project project = _db.Set<Project>().Find(pledgeOptions.ProjectId);
        //    Pledge pledge = new Pledge
        //    {
        //        PledgeTitle = pledgeOptions.PledgeTitle,
        //        PledgePrice = pledgeOptions.PledgePrice,
        //        PledgeReward = pledgeOptions.PledgeReward,
        //        Project = project
        //    };

        //    _db.Set<Pledge>().Add(pledge);
        //    _db.SaveChanges();
        //    return pledge;
        //}

        public Pledge CreatePledges(int projectId, PledgeOptions options)
        {

            var project = _db.Set<Project>().Find(projectId);

            Pledge pledge = new Pledge
            {
                Project = project,
                PledgeTitle = options.PledgeTitle,
                PledgePrice = options.PledgePrice,
                PledgeReward = options.PledgeReward
            };

            _db.Add(pledge);
            //_db.Update(project.ProjectTargetAmount);
            _db.SaveChanges();
            return pledge;
            //Task<ApiResult<Pledge>> AddPledge(int projectId, PledgeOptions options);

        }

        //new find way
        public Pledge FindPledgeById(int id)
        {
            return _db.Set<Pledge>().Find(id);
        }
    }
}
