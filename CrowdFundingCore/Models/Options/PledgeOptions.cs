﻿using System;

namespace CrowdFundingCore.Models.Options
{
    public class PledgeOptions
    {
        public string PledgeDescription { get; set; }
        public decimal PledgePrice { get; set; }
        public string PledgeReward { get; set; }
        public int ProjectId { get; set; }
        public int PledgeId { get; set; }
    }
}