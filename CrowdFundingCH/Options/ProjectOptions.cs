using System;
using System.ComponentModel.DataAnnotations.Schema;
using CrowdFundingCH.Models;

namespace CrowdFundingCH.Options
{
    public class ProjectOptions
    {
        public string Name { get; set; }
        public string Description { get; set; }
        // public string Category { get; set; }
        //  public decimal CurrentAmount { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal NeededAmount { get; set; } //The total amount of money this project needs.

        public ProjectCategory ProjectCategory { get; set; }



        //public decimal CurrentAmount { get; set; } //The current amount of money this project has gathered.
        //  public DateTime EndingDate { get; set; }
        //public string PhotoUrl { get; set; }
        //public string VideoUrl { get; set; }
        //public string StatusUpdate { get; set; }

    }
}