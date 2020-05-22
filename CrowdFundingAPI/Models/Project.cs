using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingAPI.Models
{
    public class Project
    {

        public int ProjectId { get; set; }

        public User User { get; set; }
        public string ProjectTitle { get; set; }
        
        public string ProjectDescription { get; set; }

        [Required, Column(TypeName = "decimal(18,4)")]
        public decimal ProjectTargetAmount { get; set; } 
        [Column(TypeName = "decimal(18,4)")]
        public decimal ProjectCurrentAmount { get; set; } 
        public int ProjectViewsCounter { get; set; }
        public bool IsActive { get; set; }
        public bool IsComplete { get; set; }
        public DateTimeOffset CreationDate { get; set; }

        [Required, DataType(DataType.Date), Display(Name = "Ending date"), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTimeOffset EndingDate { get; set; }

        public string ProjectCategory { get; set; }

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
