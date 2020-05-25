using System.ComponentModel.DataAnnotations;

namespace CrowdFundingMVC.Models.Admin
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }
    }
}
