using CrowdFundingCH.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingCH.Models
{
    public class Fund
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Amount { get; set; }
        public AllUsers AllUsers { get; set; }

        public Project Project { get; set; }
        //[ForeignKey("ProjectId")]
        //public int ProjectId { get; set; }
    }
}
 