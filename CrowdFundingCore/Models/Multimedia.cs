using System;

namespace CrowdFundingCore.Models
{
    public class Multimedia
    {
        public int MultimediaId { get; set; }

        public Project Project { get; set; }

        public string MultimediaURL { get; set; }
        //public MultimediaTypes MultimediaType { get; set; }

        public DateTimeOffset MultimediaDateCreated { get; set; }

        public Multimedia()
        {
            MultimediaDateCreated = DateTimeOffset.Now;
        }
    }
}
