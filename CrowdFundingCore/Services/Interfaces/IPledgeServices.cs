using CrowdFundingCore.Models;
using CrowdFundingCore.Models.Options;
using System.Collections.Generic;

namespace CrowdFundingCore.Services.Interfaces
{
    public interface IPledgeServices
    {
        //Pledge CreatePledges(PledgeOptions options);
        Result<Pledge> CreatePledges(PledgeOptions pledgeOptions);
        Pledge FindPledgeById(int id);
        List<Pledge> GetPledgesByProjectId(int projectId);
        BackedPledges AddPledge(int projectId, int pledgeId);
    }
}