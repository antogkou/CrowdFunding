using CrowdFundingCore.Models;
using CrowdFundingCore.Models.Options;
using System.Collections.Generic;
using System.Linq;

namespace CrowdFundingCore.Services.Interfaces
{
    public interface IPledgeServices
    {
        Result<Pledge> CreatePledges(PledgeOptions pledgeOptions);
        Result<BackedPledges> AddPledge(int pledgeId, int projectId);
        Pledge FindPledgeById(int projectId, int pledgeId);
        List<Pledge> GetPledgesByProjectId(int projectId);
        Result<Pledge> UpdatePledge(PledgeOptions pledgeOptions);
        IQueryable<Pledge> ListPledges(PledgeOptions options);
    }
}