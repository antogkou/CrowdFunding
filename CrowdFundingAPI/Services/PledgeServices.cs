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

        //CreatePledges
        public Pledge CreatePledges(int ProjectId, PledgeOptions pledgeOptions)
        {

            Project project = _db.Set<Project>().Find(ProjectId);

            Pledge pledge = new Pledge
            {
                Project = project,
                PledgeTitle = pledgeOptions.PledgeTitle,
                PledgePrice = pledgeOptions.PledgePrice,
                PledgeReward = pledgeOptions.PledgeReward
            };

            _db.Add(pledge);
            _db.SaveChanges();
            return pledge;
        }

        //Task<ApiResult<Pledge>> AddPledge(int projectId, PledgeOptions options);
        //_db.Update(project.ProjectTargetAmount);


        //new find way
        public Pledge FindPledgeById(int id)
        {
            return _db.Set<Pledge>().Find(id);
        }
    }
}
