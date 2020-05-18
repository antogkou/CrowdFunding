using CrowdFundingCH.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingCH.Models
{
    public class Project
    {
        public int Id { get; set; }
        //test
        public AllUsers AllUsers { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal NeededAmount { get; set; } //The total amount of money this project needs.
        public decimal CurrentAmount { get; set; } //The current amount of money this project has gathered.
        public DateTime EndingDate { get; set; }
        public string PhotoUrl { get; set; }
        public string VideoUrl { get; set; }
        public string StatusUpdate { get; set; }
        public int Viewcounter { get; set; }
        public bool IsActive { get; set; }
        public bool IsComplete { get; set; }
        public decimal Progress { get; set; } //calculated property - percentage progress
        public DateTime StartingDate { get; set; }
        public string Creator { get; set; }

        //A project can be backed by multiple backers
        //A backer can back multiple projects (many-many relationship)
        //so link class BackerProject is used
        public List<Funded> FundedProjects { get; set; }
        public ProjectCategory ProjectCategory { get; set; }
        //λιστα απο backers
    }
}
