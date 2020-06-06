using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingCore.Models.Options
{
    public class FundOptions
    {
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        public decimal FundAmount { get; set; }
        public MyUsers User { get; set; }
        public string UserId { get; set; }

    }
}
