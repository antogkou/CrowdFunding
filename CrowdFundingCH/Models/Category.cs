using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingCH.Models
{
    public class Category
    {
        public int Id { get; set; }
        //public string Type { get; set; }
        //public List<Project> Projects { get; set; }

        //public Category()
        //{
        //    ProjectCategorys = new List<Category>();
        //}
        public int ProjectId;
        public string Name { get; set; }
        //public ICollection<Category> ProjectCategorys
        //{
        //    get; protected set;
        //}
    }
}
