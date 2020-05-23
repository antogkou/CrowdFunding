using CrowdFundingAPI.Database;
using CrowdFundingAPI.Models;
using CrowdFundingAPI.Models.Options;
using CrowdFundingAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingAPI.Services
{
    public class ProjectServices : IProjectServices
    {
        private CrFrDbContext _db;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ProjectServices(CrFrDbContext db, IHttpContextAccessor _httpContextAccessor)
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
                ProjectTitle = projectoption.ProjectTitle,
                ProjectDescription = projectoption.ProjectDescription,
                //CurrentAmount = projectoption.CurrentAmount,
                ProjectTargetAmount = projectoption.ProjectTargetAmount,
                //Progress = projectoption.CurrentAmount / projectoption.NeededAmount,
                CreationDate = DateTime.Now,
                EndingDate = projectoption.EndingDate,
                IsActive = true,
                Creator = userName,
                ProjectCategory = projectoption.ProjectCategory,
            };

            _db.Add(project);
            _db.SaveChanges();
            return project;
        }

        public Project CreateProject2(ProjectOptions projectoption)
        {
            if (projectoption == null)
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(projectoption.ProjectTitle))
            {
                return null;
            }

            var project = new Project()
            {
                ProjectTitle = projectoption.ProjectTitle,
                ProjectDescription = projectoption.ProjectDescription,
                ProjectTargetAmount = projectoption.ProjectTargetAmount,
                EndingDate = projectoption.EndingDate,

            };

            _db.Add(project);

            if (_db.SaveChanges() > 0)
            {
                return project;
            }

            return null;
        }

        //public async Task<ApiResult<Project>> CreateProject2(ProjectOptions projectoption)
        //{
        //    string userName = httpContextAccessor.HttpContext.User.Identity.Name;
        //    var project = new Project()
        //    {
        //        Creator = userName,
        //        ProjectDescription = options.ProjectDescription,
        //        ProjectTitle = options.ProjectTitle,
        //        ProjectFinancialGoal = options.ProjectFinancialGoal,
        //        ProjectCategory = options.ProjectCategory,
        //        ProjectDateExpiring = options.ProjectDateExpiring
        //    };
        //    context.Add(project);
        //}


        ////List Projects
        //public List<Project> GetAllProjects()
        //{
        //    return _db.Projects.ToList();
        //}

    }
}
