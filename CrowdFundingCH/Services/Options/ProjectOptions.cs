using CrowdFundingMVC.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace CrowdFundingMVC.Options
{
    public class ProjectOptions
    {
        public string Name { get; set; }
        public string Description { get; set; }
      //  [Column(TypeName = "decimal(18,4)")]
        public decimal NeededAmount { get; set; } 
        public string ProjectCategory { get; set; }
        [Required, DataType(DataType.Date), Display(Name = "Ending date"), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime EndingDate { get; set; }       

    }
}
