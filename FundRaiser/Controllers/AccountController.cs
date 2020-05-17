using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FundRaiser.Controllers;
using FundRaiserMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FundRaiserMVC.Controllers
{
    public class AccountController : Controller
    {
         private UserManager<AppUser> UserMgr { get; }
        private SignInManager<AppUser> SignInMgr { get; }
        public AccountController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)

        {
            UserMgr = userManager;
            SignInMgr = signInManager;
        }

        //public async Task<IActionResult> Login()
        //{
        //    return View();
        //}

        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password)
        {
            var result = await SignInMgr.PasswordSignInAsync(userName, password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Result = "result is: " + result.ToString();
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await SignInMgr.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
           
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> CreateToken([FromBody] JwtTokenViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await UserMgr.FindByNameAsync(model.UserName);
                var signInResult = await SignInMgr.CheckPasswordSignInAsync(user, model.Password, false);
                if (signInResult.Succeeded)
                {
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(MVSJwtTokens.Key));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, model.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.UniqueName, model.UserName)
                    };
                    var token = new JwtSecurityToken(
                        MVSJwtTokens.Issuer,
                        MVSJwtTokens.Audience,
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(5),
                        signingCredentials: creds
                        );
                    var results = new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    };

                    return Created("", results);
                }
                else
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

    }
}