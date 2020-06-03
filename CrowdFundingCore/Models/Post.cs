using System;

namespace CrowdFundingCore.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public MyUsers User { get; set; }
        public string UserId { get; set; }
        public Project Project { get; set; }
        public string PostDescription { get; set; }
        public DateTimeOffset PostDateCreated { get; set; }
        public Post()
        {
            PostDateCreated = DateTimeOffset.Now;
        }
    }
}