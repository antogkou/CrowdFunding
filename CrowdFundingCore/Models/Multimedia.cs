using System;
using System.ComponentModel.DataAnnotations;

namespace CrowdFundingCore.Models
{
    public class Multimedia
    {
        public int MultimediaId { get; set; }

        public Project Project { get; set; }
        [Required(ErrorMessage = "Project Profile Photo is required")]
        public string MultimediaURL { get; set; }
        public MultimediaTypes MultimediaTypes { get; set; }

        public DateTimeOffset MultimediaDateCreated { get; set; }

        public Multimedia()
        {
            MultimediaDateCreated = DateTimeOffset.Now;
        }
    }
}
