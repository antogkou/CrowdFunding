using CrowdFundingCH.Areas.Identity.Data;
using CrowdFundingCH.Models;
using CrowdFundingCH.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Security.Claims;

namespace CrowdFundingCH.Services
{
    public class ProjectManagement
    {
        private CrowdFundingDBContext db;
        private readonly UserManager<AllUsers> userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProjectManagement(CrowdFundingDBContext _db, UserManager<AllUsers> userManager, HttpContextAccessor httpContextAccessor)
        {
            db = _db;
            this.userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }


        //Create Project
        public Project CreateProject(ProjectOptions projectoption)
        {
            var creatorId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //CreatorManagement creatormanagement = new CreatorManagement(db);
            Project project = new Project
            {
                Name = projectoption.Name,
                Description = projectoption.Description,
                Category = projectoption.Category,
                CurrentAmount = projectoption.CurrentAmount,
                NeededAmount = projectoption.NeededAmount,
                Progress = projectoption.CurrentAmount / projectoption.NeededAmount,
                StartingDate = DateTime.Today,
                EndingDate = projectoption.EndingDate,
                IsActive = true,
                Creator = creatorId
            };

            db.Projects.Add(project);
            db.SaveChanges();
            return project;
        }

        //Find Project by id
        public Project FindProjectById(int id)
        {
            return db.Projects.Find(id);
        }

        //Find Project by name
        public Project FindProjectByName(ProjectOptions projectoption)
        {
            return db.Projects
                .Where(project => project.Name == projectoption.Name)
                .FirstOrDefault();
        }

    }
}