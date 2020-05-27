using System;

namespace CrowdFundingCore.Models.Options
{
    public class UpdateProjectOptions
    {
        public string ProjectTitle { get; set; }

        public string ProjectDescription { get; set; }

        public decimal ProjectTargetAmount { get; set; }

        public decimal ProjectCurrentAmount { get; set; }

        public string ProjectCategory { get; set; }

        public DateTimeOffset EndingDate { get; set; }
    }
}
