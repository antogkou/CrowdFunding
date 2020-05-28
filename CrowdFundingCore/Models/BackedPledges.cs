using System;
using Microsoft.AspNetCore.Identity;

namespace CrowdFundingCore.Models
{
    public class BackedPledges
    {
        public int BackedPledgesId { get; set; }
        public string UserId { get; set; }
        public MyUsers User { get; set; }

        public int PledgeId { get; set; }
        public Pledge BackedPledge { get; set; }

        public DateTimeOffset created_BackedPledge { get; set; }

        public BackedPledges()
        {
            created_BackedPledge = DateTimeOffset.Now;
        }
    }

}
