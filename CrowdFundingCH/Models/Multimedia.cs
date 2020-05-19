using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingCH.Models
{
    public class Multimedia
    {
        public int MultimediaId { get; set; }

        public Project Project { get; set; }

        //public MultimediaTypes MultimediaType { get; set; }

        //public string MultimediaURL { get; set; }

        //public DateTimeOffset MMultimediaDateCreated { get; set; }

        //public Multimedia()
        //{
        //    MultimediaDateCreated = DateTimeOffset.Now;
        //}
    }
}
