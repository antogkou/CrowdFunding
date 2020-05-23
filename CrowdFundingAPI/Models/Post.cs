
using System;

namespace CrowdFundingAPI.Models
{
    public class Post
    {
        public int PostId { get; set; }

        public MyUsers User { get; set; }

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
