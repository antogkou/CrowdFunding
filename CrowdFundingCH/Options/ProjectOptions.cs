using CrowdFundingCH.Models;

namespace CrowdFundingCH.Options
{
    public class ProjectOptions
    {
        public string Name { get; set; }
        public string Description { get; set; }
      //  [Column(TypeName = "decimal(18,4)")]
        public decimal NeededAmount { get; set; } 
        public ProjectCategory ProjectCategory { get; set; }

    }
}
