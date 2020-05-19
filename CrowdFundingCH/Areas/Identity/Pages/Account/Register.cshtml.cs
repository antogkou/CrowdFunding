using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using CrowdFundingCH.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CrowdFundingCH.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<AllUsers> _signInManager;
        private readonly UserManager<AllUsers> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailSender _emailSender;
        private readonly CrowdFundingDBContext _db;

        public RegisterModel(
            UserManager<AllUsers> userManager,
            SignInManager<AllUsers> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager,
            CrowdFundingDBContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
            _db = db;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
          
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "FirstName")]
            public string FirstName { get; set; }
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "LastName")]
            public string LastName { get; set; }
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

           
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            //var role = _roleManager.FindByIdAsync(Input.Name).Result;
            if (ModelState.IsValid)
            {
                var user = new AllUsers { UserName = Input.Email, Email = Input.Email, FirstName = Input.FirstName, 
                    LastName = Input.LastName };
                var result = await _userManager.CreateAsync(user, Input.Password);

                //create roles for the first registers
                IdentityResult roleResult;
                bool adminRoleExists = await _roleManager.RoleExistsAsync("Admin");
                bool backerRoleExists = await _roleManager.RoleExistsAsync("Backer");
                bool projectCreatorRoleExists = await _roleManager.RoleExistsAsync("ProjectCreator");
                if (!adminRoleExists)
                {
                    _logger.LogInformation("Adding Admin role");
                    roleResult = await _roleManager.CreateAsync(new IdentityRole("Admin"));
                }
                if (!backerRoleExists)
                {
                    _logger.LogInformation("Adding Backer role");
                    roleResult = await _roleManager.CreateAsync(new IdentityRole("Backer"));
                }
                if (!projectCreatorRoleExists)
                {
                    _logger.LogInformation("Adding Project Creator role");
                    roleResult = await _roleManager.CreateAsync(new IdentityRole("Project Creator"));
                }
                if (result.Succeeded)
                {
                    if (!await _roleManager.RoleExistsAsync(SD.AdminEndUser))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(SD.AdminEndUser));
                    }

                    if (!await _roleManager.RoleExistsAsync(SD.BackerEndUser))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(SD.BackerEndUser));
                    }
                    //new users get these roles
                    await _userManager.AddToRoleAsync(user, SD.BackerEndUser);
                    await _userManager.AddToRoleAsync(user, SD.ProjectCreatorEndUser);
                    await _userManager.AddToRoleAsync(user, SD.AdminEndUser);
                    _logger.LogInformation("User created a new account with password.");
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
