using CrowdFundingAPI.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CrowdFundingMVC.ViewModels
{
    public class ProjectCategoryViewModel
    {
        public List<Project> Projects { get; set; }
        public SelectList Categories { get; set; }
        public string ProjectCategory { get; set; }
        public string SearchString { get; set; }
    }
}
