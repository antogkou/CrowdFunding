using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingCore.Models.Options
{
    public class PledgeProjectOptions
    {
        public string PledgeTitle { get; set; }
        public string PledgeDescription { get; set; }
        public decimal PledgePrice { get; set; }
        public string PledgeReward { get; set; }
        public int PledgeId { get; set; }

        public int ProjectId { get; set; }
        //test
        public string ProjectTitle { get; set; }

        public string ProjectDescription { get; set; }
        //  [Column(TypeName = "decimal(18,4)")]
        public decimal ProjectTargetAmount { get; set; }
        public string ProjectCategory { get; set; }
        public string UserId { get; set; }
        public string Creator { get; set; }
    }
}
