using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingCore.Models.Options
{
    public class PostOptions
    {
        public int PostId { get; set; }
        public int ProjectId { get; set; }
        public string UserId { get; set; }
        public string PostTitle { get; set; }
        public string PostDescription { get; set; }
    }
}