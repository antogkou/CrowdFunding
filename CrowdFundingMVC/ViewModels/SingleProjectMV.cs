using CrowdFundingAPI.Models;
using CrowdFundingAPI.Models.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingMVC.ViewModels
{
    public class SingleProjectMV
    {
        public Project Project { get; set; }
        public MyUsers User { get; set; }
        public List<Post> Posts { get; set; }
        public List<Pledge> Pledges { get; set; }
        public Pledge Pledge { get; set; }
    }
}