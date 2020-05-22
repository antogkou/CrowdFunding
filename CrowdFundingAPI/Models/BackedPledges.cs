using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingAPI.Models
{
    public class BackedPledges
    {
        public int UserId { get; set; }
        public User BackedUser { get; set; }

        public int PledgeId { get; set; }
        public Pledge BackedPledge { get; set; }

        public DateTimeOffset created_BackedPledge { get; set; }

        public BackedPledges()
        {
            created_BackedPledge = DateTimeOffset.Now;
        }
    }
}
