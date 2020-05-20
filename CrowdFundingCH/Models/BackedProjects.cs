using CrowdFundingCH.Areas.Identity.Data;
using CrowdFundingMVC.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrowdFundingMVC.Models
{
    public class BackedProjects
    {
        public int BackedProjectsId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }     

        //[ForeignKey(nameof(Fund))]
        //public int FundId { get; set; }
        public Fund Fund { get; set; }


        //public Fund BackedProject { get; set; }
        public DateTimeOffset BackedFundDateCreated { get; set; }

        public BackedProjects()
        {
            BackedFundDateCreated = DateTimeOffset.Now;
        }
    }
}