using System;
using System.ComponentModel.DataAnnotations;

namespace CrowdFundingCore.Models.Options
{
    public class ProjectOptions
    {
        //test
        public int ProjectId { get; set; }
        //test
        public string ProjectTitle { get; set; }
        
        public string ProjectDescription { get; set; }
        //  [Column(TypeName = "decimal(18,4)")]
        public decimal ProjectTargetAmount { get; set; }
        public string ProjectCategory { get; set; }
        [Required, DataType(DataType.Date), Display(Name = "Ending date"), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime ProjectEndingDate { get; set; }
        public string UserId { get; set; }
        public string Creator { get; set; }
        public string MultimediaURL { get; set; }
    }
}
