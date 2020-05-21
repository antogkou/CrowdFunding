using CrowdFundingMVC.Areas.Identity.Data;
using CrowdFundingMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingMVC.Models
{
    public class Post
    {

        public int PostId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public Project Project { get; set; }

        public string PostTitle { get; set; }

        public DateTimeOffset PostDateCreated { get; set; }

        public Post()
        {
            PostDateCreated = DateTimeOffset.Now;
        }

    }
}
