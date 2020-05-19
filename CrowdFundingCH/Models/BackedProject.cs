using CrowdFundingCH.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingCH.Models
{
    public class BackedProject
    {
        public int Id { get; set; }
        public AllUsers AllUsers { get; set; }
        public Project Project { get; set; }

        //[ForeignKey("ProjectId")]
        //public int ProjectId { get; set; }
    }
}