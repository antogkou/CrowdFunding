using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingCore.Models
{
    public class Fund
    {
        public int FundId { get; set; }
        public Project Project { get; set; }
        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal FundAmount { get; set; }
        public DateTimeOffset FundDateCreated { get; set; }
        public MyUsers User { get; set; }
        public string UserId { get; set; }

        public Fund()
        {
            //PledgeUsers = new List<BackedPledges>();
            FundDateCreated = DateTimeOffset.Now;
        }
    }
}