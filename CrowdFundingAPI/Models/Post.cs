using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingAPI.Models
{
    public class Post
    {
        public int PostId { get; set; }

        public User User { get; set; }

        public Project Project { get; set; }

        public string PostTitle { get; set; }

        public string PostExcerpt { get; set; }

        public DateTimeOffset PostDateCreated { get; set; }

        public Post()
        {
            PostDateCreated = DateTimeOffset.Now;
        }
    }
}
