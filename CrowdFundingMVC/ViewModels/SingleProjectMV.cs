using CrowdFundingCore.Models;
using System.Collections.Generic;

namespace CrowdFundingMVC.ViewModels
{
    public class SingleProjectMV
    {
        public Project Project { get; set; }
        public MyUsers User { get; set; }
        public List<Post> Posts { get; set; }
        public List<Pledge> Pledges { get; set; }
        public List<Pledge> PledgeUsers { get; set; }
        public Pledge Pledge { get; set; }
        public List<Multimedia> ProjectMultimedia{ get; set; }
        public Multimedia Multimedia { get; set; }

    }
}