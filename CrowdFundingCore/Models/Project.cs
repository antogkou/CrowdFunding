using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrowdFundingCore.Models
{
    public class Project
    {

        public int ProjectId { get; set; }
        public MyUsers User { get; set; }
        public string UserId { get; set; }
        [StringLength(30, MinimumLength = 3)]
        [Required]
        public string ProjectTitle { get; set; }
        [Required]
        public string ProjectDescription { get; set; }
        [DataType(DataType.Currency)]
        [Required]
        public decimal ProjectTargetAmount { get; set; } 
        [DataType(DataType.Currency)]
        public decimal ProjectCurrentAmount { get; set; } 
        public decimal ProjectProgress { get; set; }
        public int ProjectViews { get; set; }
        public bool IsActive { get; set; }
        public bool IsComplete { get; set; }
        public DateTimeOffset ProjectCreationDate { get; set; }
        [Required, DataType(DataType.Date), Display(Name = "ProjectEndingDate"), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? ProjectEndingDate { get; set; }
        [Required]
        public string ProjectCategory { get; set; }
        public string ProjectCreator { get; set; }
        public ICollection<Post> ProjectPosts { get; set; }
        public ICollection<Pledge> ProjectPledges { get; set; }
        public ICollection<Multimedia> ProjectMultimedia { get; set; }
        public ICollection<Fund> Funds { get; set; }

        public Project()
        {
            ProjectCurrentAmount = 0;
            ProjectPosts = new List<Post>();
            ProjectPledges = new List<Pledge>();
            ProjectMultimedia = new List<Multimedia>();
            ProjectCreationDate = DateTimeOffset.Now;
        }
    }
}