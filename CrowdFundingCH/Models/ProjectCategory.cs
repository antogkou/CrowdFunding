using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingCH.Models
{
    public class ProjectCategory
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public List<Project> Projects { get; set; }
    }
}
