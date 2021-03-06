﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowdFundingCore.Models;
using CrowdFundingMVC.ViewModels.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrowdFundingMVC.Controllers
{ 
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
            private readonly RoleManager<IdentityRole> roleManager;
            private readonly UserManager<MyUsers> userManager;

            public AdminController(RoleManager<IdentityRole> roleManager,
                UserManager<MyUsers> userManager)
            {
                this.roleManager = roleManager;
                this.userManager = userManager;
            }

            [HttpGet]
            public IActionResult Index()
            {

                return View();
            }

            [HttpGet]
            public IActionResult ListUsers()
            {
                var users = userManager.Users;
                return View(users);
            }

            [HttpGet]
            public IActionResult ListRoles()
            {
                var roles = roleManager.Roles;
                return View(roles);
            }

            [HttpGet]
            public IActionResult CreateRole()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
            {
                if (ModelState.IsValid)
                {
                    // We just need to specify a unique role name to create a new role
                    IdentityRole identityRole = new IdentityRole
                    {
                        Name = model.RoleName
                    };

                    // Saves the role in the  AspNetRoles table
                   IdentityResult result = await roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                    {
                        return RedirectToAction("index", "admin");
                    }

                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                return View(model);
            }

            // Role ID is passed from the URL to the action
            [HttpGet]
            public async Task<IActionResult> EditRole(string id)
            {
                // Find the role by Role ID
                var role = await roleManager.FindByIdAsync(id);

                if (role == null)
                {
                    ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                    return View("NotFound");
                }

                var model = new EditRoleViewModel
                {
                    Id = role.Id,
                    RoleName = role.Name
                };

                foreach (var user in await userManager.Users.ToListAsync())
                {
                    if (await userManager.IsInRoleAsync(user, role.Name))
                    {
                        model.Users.Add(user.UserName);
                    }
                }

                return View(model);
            }

            //Delete a role from DB
            [HttpPost]
            public async Task<IActionResult> DeleteRole(string id)
            {
                var role = await roleManager.FindByIdAsync(id);

                if (role == null)
                {
                    ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                    return View("NotFound");
                }
                else
                {
                    var result = await roleManager.DeleteAsync(role);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("ListRoles");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View("ListRoles");
                }
            }

            // This action responds to HttpPost and receives EditRoleViewModel
            [HttpPost]
            public async Task<IActionResult> EditRole(EditRoleViewModel model)
            {
                var role = await roleManager.FindByIdAsync(model.Id);

                if (role == null)
                {
                    ViewBag.ErrorMessage = $"Role with Id = {model.Id} cannot be found";
                    return View("NotFound");
                }
                else
                {
                    role.Name = model.RoleName;

                    // Update the Role using UpdateAsync
                    var result = await roleManager.UpdateAsync(role);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("ListRoles");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View(model);
                }
            }

            //Edit Users Roles
            [HttpGet]
            public async Task<IActionResult> EditUsersInRole(string roleId)
            {
                ViewBag.roleId = roleId;

                var role = await roleManager.FindByIdAsync(roleId);

                if (role == null)
                {
                    ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                    return View("NotFound");
                }

                var model = new List<UsersRoleViewModel>();

                foreach (var user in userManager.Users)
                {
                    var userRoleViewModel = new UsersRoleViewModel
                    {
                        UserId = user.Id,
                        UserName = user.UserName
                    };

                    if (await userManager.IsInRoleAsync(user, role.Name))
                    {
                        userRoleViewModel.IsSelected = true;
                    }
                    else
                    {
                        userRoleViewModel.IsSelected = false;
                    }

                    model.Add(userRoleViewModel);
                }

                return View(model);
            }

            //Delete User from DB
            [HttpPost]
            public async Task<IActionResult> DeleteUser(string id)
            {
                var user = await userManager.FindByIdAsync(id);

                if (user == null)
                {
                    ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                    return View("NotFound");
                }
                else
                {
                    var result = await userManager.DeleteAsync(user);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("ListUsers");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View("ListUsers");
                }
            }

            [HttpPost]
            public async Task<IActionResult> EditUsersInRole(List<UsersRoleViewModel> model, string roleId)
            {
                var roleInEdit = await roleManager.FindByIdAsync(roleId);

                if (roleInEdit == null)
                {
                    ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                    return View("NotFound");
                }

                foreach (var userRole in model)
                {
                    var user = await userManager.FindByIdAsync(userRole.UserId);
                    var isInRole = await userManager.IsInRoleAsync(user, roleInEdit.Name);

                    IdentityResult result = null;
                    if (userRole.IsSelected && !isInRole)
                        result = await userManager.AddToRoleAsync(user, roleInEdit.Name);
                    else if (!userRole.IsSelected && isInRole)
                        result = await userManager.RemoveFromRoleAsync(user, roleInEdit.Name);

                    if (result?.Succeeded == false)
                        break;
                }

                return RedirectToAction("EditRole", new { Id = roleId });
            }

            [HttpGet]
            public async Task<IActionResult> EditUser(string id)
            {
                var user = await userManager.FindByIdAsync(id);

                if (user == null)
                {
                    ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                    return View("NotFound");
                }

                // GetClaimsAsync retunrs the list of user Claims
                var userClaims = await userManager.GetClaimsAsync(user);
                // GetRolesAsync returns the list of user Roles
                var userRoles = await userManager.GetRolesAsync(user);

                var model = new EditUserViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    UserName = user.UserName,
                    //City = user.City,
                    Claims = userClaims.Select(c => c.Value).ToList(),
                    Roles = userRoles
                };

                return View(model);
            }

            [HttpPost]
            public async Task<IActionResult> EditUser(EditUserViewModel model)
            {
                var user = await userManager.FindByIdAsync(model.Id);

                if (user == null)
                {
                    ViewBag.ErrorMessage = $"User with Id = {model.Id} cannot be found";
                    return View("NotFound");
                }
                else
                {
                    user.Email = model.Email;
                    user.UserName = model.UserName;
                    //user.City = model.City;

                    var result = await userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("ListUsers");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View(model);
                }
            }

    }
}
