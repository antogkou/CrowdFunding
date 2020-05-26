using System;

namespace CrowdFundingCore.Models
{
    public class BackedPledges
    {
        public int UserId { get; set; }
        public MyUsers BackedUser { get; set; }

        public int PledgeId { get; set; }
        public Pledge BackedPledge { get; set; }

        public DateTimeOffset created_BackedPledge { get; set; }

        public BackedPledges()
        {
            created_BackedPledge = DateTimeOffset.Now;
        }
    }

}
