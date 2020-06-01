using CrowdFundingCore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingMVC.ViewModels
{
    public class ProjectsGridVM
    {
        public List<Project> Projects { get; set; }
        public SelectList Categories { get; set; }
        public string ProjectCategory { get; set; }
        public string SearchString { get; set; }
        public int ProjectId { get; set; }
        public MyUsers User { get; set; }
        public string UserId { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectDescription { get; set; }
        [DataType(DataType.Currency)]
        public decimal ProjectTargetAmount { get; set; }
        [DataType(DataType.Currency)]
        public decimal ProjectCurrentAmount { get; set; }
        public decimal ProjectProgress { get; set; }
        public int ProjectViews { get; set; }
        public bool IsActive { get; set; }
        public bool IsComplete { get; set; }
        public DateTimeOffset ProjectCreationDate { get; set; }
        [Required, DataType(DataType.Date), Display(Name = "ProjectEndingDate"), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime ProjectEndingDate { get; set; }
        public string ProjectCreator { get; set; }
        public ICollection<Post> ProjectPosts { get; set; }
        public ICollection<Pledge> ProjectPledges { get; set; }
        public ICollection<Multimedia> ProjectMultimedia { get; set; }
        public Multimedia Multimedia { get; set; }
    }
}
