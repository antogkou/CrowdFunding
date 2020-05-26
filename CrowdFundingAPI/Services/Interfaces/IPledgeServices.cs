using CrowdFundingAPI.Models;
using CrowdFundingAPI.Models.Options;
using System.Collections.Generic;

namespace CrowdFundingAPI.Services.Interfaces
{
    public interface IPledgeServices
    {
        Pledge CreatePledges(PledgeOptions options);
        Pledge FindPledgeById(int id);
        List<Pledge> GetPledgesByProjectId(int projectId);
    }
}