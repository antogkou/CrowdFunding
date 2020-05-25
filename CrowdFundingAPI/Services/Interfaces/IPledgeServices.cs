using CrowdFundingAPI.Models;
using CrowdFundingAPI.Models.Options;

namespace CrowdFundingAPI.Services.Interfaces
{
    public interface IPledgeServices
    {
        // Pledge CreatePledge(PledgeOptions pledgeOptions);

        public Pledge CreatePledges(PledgeOptions options);
        Pledge FindPledgeById(int id);
    }
}