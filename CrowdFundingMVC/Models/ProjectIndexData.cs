using CrowdFundingAPI.Models;
using System.Collections.Generic;

namespace CrowdFundingMVC.Models
{
    public class ProjectIndexData
    {
        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<Pledge> Pledges { get; set; }
        public IEnumerable<BackedPledges> BackedPledges { get; set; }
    }
}
