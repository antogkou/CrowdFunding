using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingMVC.Options
{
    public class FundOptions
    {
        public string FundTitle { get; set; }

        public string FundDescription { get; set; }

        public decimal FundPrice { get; set; }

        public string FundReward { get; set; }
    }
}
