using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrowdFundingMVC.Models
{
    public class Project
    {
        [Required]
        public int ProjectId { get; set; }
        public string Name { get; set; }
        [Required, Display(Name = "Project Short Discription")]
        public string Description { get; set; }

        [Required, Column(TypeName = "decimal(18,4)")]
        public decimal NeededAmount { get; set; } //The total amount of money this project needs.
        [Column(TypeName = "decimal(18,4)")]
        public decimal CurrentAmount { get; set; } //The current amount of money this project has gathered.

        [Column(TypeName = "decimal(18,4)")]
        public decimal Progress { get; set; } //calculated property - percentage progress
        public int Viewcounter { get; set; }
        public bool IsActive { get; set; }
        public bool IsComplete { get; set; }
        public DateTime StartingDate { get; set; }

        [Required, DataType(DataType.Date), Display(Name = "Ending date"), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime EndingDate { get; set; }
        public string Creator { get; set; }

        public string ProjectCategory { get; set;}

        //public List<Project> Projects { get; set; }

       // public virtual ICollection<ProjectCategory> Categories { get; set; }


    }
}
