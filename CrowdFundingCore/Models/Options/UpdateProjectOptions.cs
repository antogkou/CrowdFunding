using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrowdFundingCore.Models.Options
{
    public class UpdateProjectOptions
    {
        public int ProjectId { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectDescription { get; set; }

        [DataType(DataType.Currency)] [Column(TypeName = "ProjectTargetAmount")]
        public decimal ProjectTargetAmount { get; set; }
        public string ProjectCategory { get; set; }
        public DateTime ProjectEndingDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsComplete { get; set; }
    }
}
