using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrowdFundingCore.Models
{
    public class Pledge
    {
        public int PledgeId { get; set; }
        public Project Project { get; set; }
        [StringLength(20, MinimumLength = 3)]
        [Required]
        public string PledgeDescription { get; set; }

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal PledgePrice { get; set; }
        [StringLength(20, MinimumLength = 3)]
        [Required]
        public string PledgeReward { get; set; }
        public DateTimeOffset PledgeDateCreated { get; set; }
        public ICollection<BackedPledges> PledgeUsers { get; set; }
        public Pledge()
        {
            PledgeUsers = new List<BackedPledges>();
            PledgeDateCreated = DateTimeOffset.Now;
        }
    }
}