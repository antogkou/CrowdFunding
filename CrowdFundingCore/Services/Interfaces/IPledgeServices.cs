using CrowdFundingCore.Models;
using CrowdFundingCore.Models.Options;
using System.Collections.Generic;

namespace CrowdFundingCore.Services.Interfaces
{
    public interface IPledgeServices
    {
        //old
        //Pledge CreatePledges(PledgeOptions options);
        // BackedPledges AddPledge(int projectId, int pledgeId);
        Result<Pledge> CreatePledges(PledgeOptions pledgeOptions);
        Result<BackedPledges> AddPledge(int pledgeId, int projectId);
        Pledge FindPledgeById(int id);
        List<Pledge> GetPledgesByProjectId(int projectId);
        Result<Pledge> UpdatePledge(PledgeOptions pledgeOptions);


    }
}