using System;
using System.ComponentModel.DataAnnotations;

namespace CrowdFundingCore.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public MyUsers User { get; set; }
        public string UserId { get; set; }
        public Project Project { get; set; }
        [StringLength(255, MinimumLength = 3, ErrorMessage = "The Post should be between 3 and 255 characters")]
        public string PostDescription { get; set; }
        public DateTimeOffset PostDateCreated { get; set; }
        public Post()
        {
            PostDateCreated = DateTimeOffset.Now;
        }
    }
}