using CrowdFundingMVC.Areas.Identity.Data;
using CrowdFundingMVC.Models;
using CrowdFundingMVC.Options;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CrowdFundingMVC.Services
{
    public class ProjectServices : IProjectService
    {
        //Injections
        private CrowdFundingDBContext _db;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ProjectServices(CrowdFundingDBContext db, IHttpContextAccessor _httpContextAccessor)
        {
            _db = db;
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
                StartingDate = DateTime.Now,
                EndingDate = projectoption.EndingDate,
                IsActive = true,
                Creator = userName,
                ProjectCategory = projectoption.ProjectCategory,
            };
            _db.Projects.Add(project);
            _db.SaveChanges();
            return project;
        }

        //List Projects
        public List<Project> GetAllProjects()
        {
            return _db.Projects.ToList();
        }

        //Find Project by id
        public Project FindProjectById(int id)
        {
            return _db.Projects.Find(id);
        }


        //Find Project by name
        public Project FindProjectByName(ProjectOptions projectoption)
        {
            return _db.Projects
                .Where(project => project.Name == projectoption.Name)
                .FirstOrDefault();
        }

    }
}