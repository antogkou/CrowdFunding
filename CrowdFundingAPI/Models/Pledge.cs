using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingAPI.Models
{
    public class Pledge
    {
        public int PledgedId { get; set; }

        public Project Project { get; set; }

        public string PledgeTitle { get; set; }
        public string PledgeDescription { get; set; }
        public decimal PledgePrice { get; set; }
        public string PledgeReward { get; set; }
        public DateTimeOffset PledgeDateCreated { get; set; }


        public ICollection<BackedPledges> FundBackers { get; set; }


        public Pledge()
        {
            FundBackers = new List<BackedPledges>();
            PledgeDateCreated = DateTimeOffset.Now;
        }
    }
}
