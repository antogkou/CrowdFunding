using CrowdFundingAPI.Models;
using CrowdFundingAPI.Models.Options;
using System.Collections.Generic;

namespace CrowdFundingAPI.Services.Interfaces
{
    public interface IPledgeServices
    {
        Pledge CreatePledge(PledgeOptions pledgeOptions);
    }
}
