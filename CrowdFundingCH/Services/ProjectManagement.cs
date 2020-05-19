using CrowdFundingCH.Areas.Identity.Data;
using CrowdFundingCH.Models;
using CrowdFundingCH.Options;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace CrowdFundingCH.Services
{
    public class ProjectManagement : IProjectManager
    {
        //Injections
        private CrowdFundingDBContext db;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ProjectManagement(CrowdFundingDBContext _db, IHttpContextAccessor _httpContextAccessor)
        {
            db = _db;
            httpContextAccessor = _httpContextAccessor;
        }

        //Create Project
        public Project CreateProject(ProjectOptions projectoption)
        {
            string userName = httpContextAccessor.HttpContext.User.Identity.Name;
            Project project = new Project
            {
                Name = projectoption.Name,
                Description = projectoption.Description,
                //CurrentAmount = projectoption.CurrentAmount,
                NeededAmount = projectoption.NeededAmount,
                //Progress = projectoption.CurrentAmount / projectoption.NeededAmount,
                StartingDate = DateTime.Today,
                //EndingDate = projectoption.EndingDate,
                IsActive = true,
                Creator = userName,
                ProjectCategory = projectoption.ProjectCategory,
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