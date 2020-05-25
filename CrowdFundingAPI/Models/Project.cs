using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrowdFundingAPI.Models
{
    public class Project
    {

        public int ProjectId { get; set; }

        public MyUsers User { get; set; }

        public string UserId { get; set; }
        public string ProjectTitle { get; set; }
        
        public string ProjectDescription { get; set; }

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal ProjectTargetAmount { get; set; } 
        [Column(TypeName = "decimal(18,2)")]
        public decimal ProjectCurrentAmount { get; set; } 
        public string ProjectTargetAmountTostring { get; set; }
        public decimal Progress { get; set; }
        public int ProjectViewsCounter { get; set; }
        public bool IsActive { get; set; }
        public bool IsComplete { get; set; }
        public DateTimeOffset CreationDate { get; set; }

        [Required, DataType(DataType.Date), Display(Name = "Ending date"), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTimeOffset EndingDate { get; set; }

        public string ProjectCategory { get; set; }

        public string Creator { get; set; }

        public ICollection<Post> ProjectPosts { get; set; }

        public ICollection<Pledge> ProjectPledges { get; set; }

        public ICollection<Multimedia> ProjectMultimedia { get; set; }

        public Project()
        {
            ProjectCurrentAmount = 0;
            ProjectPosts = new List<Post>();
            ProjectPledges = new List<Pledge>();
            ProjectMultimedia = new List<Multimedia>();
            CreationDate = DateTimeOffset.Now;
        }
    }
}