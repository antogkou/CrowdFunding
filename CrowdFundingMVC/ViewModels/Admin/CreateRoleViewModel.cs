using System.ComponentModel.DataAnnotations;

namespace CrowdFundingMVC.ViewModels.Admin
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }
    }
}