using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrowdFundingCH.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //[Column(TypeName = "decimal(18,4)")]
        public decimal NeededAmount { get; set; } //The total amount of money this project needs.
        //[Column(TypeName = "decimal(18,4)")]
        public decimal CurrentAmount { get; set; } //The current amount of money this project has gathered.
        public DateTime EndingDate { get; set; }
        public string StatusUpdate { get; set; }
        public int Viewcounter { get; set; }
        public bool IsActive { get; set; }
        public bool IsComplete { get; set; }
        //[Column(TypeName = "decimal(18,4)")]
        public decimal Progress { get; set; } //calculated property - percentage progress
        public DateTime StartingDate { get; set; }
        public string Creator { get; set; }
        public ProjectCategory ProjectCategory  {  get; set; }

      


    }
}
