
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrowdFundingAPI.Models
{
    public class Post
    {
        public int PostId { get; set; }

        [ForeignKey("UserId")]
        public virtual MyUsers MyUsers { get; set; }

        public Project Project { get; set; }

        public string PostTitle { get; set; }

        public string PostDescription { get; set; }

        public DateTimeOffset PostDateCreated { get; set; }

        public Post()
        {
            PostDateCreated = DateTimeOffset.Now;
        }
    }
}
