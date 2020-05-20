using CrowdFundingCH.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingMVC.Models
{
    public class Fund
    {
        public int FundId { get; set; }
       
        public Project Project { get; set; }

        public string FundTitle { get; set; }
        public string FundPrice { get; set; }
        public string FundReward { get; set; }
        public DateTimeOffset FundDateCreated { get; set; }


        public ICollection<BackedProjects> FundBackers { get; set; }
       

        public Fund()
        {
            FundBackers = new List<BackedProjects>();
            FundDateCreated = DateTimeOffset.Now;
        }
    }
}
