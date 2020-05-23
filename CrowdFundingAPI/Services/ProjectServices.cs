using CrowdFundingAPI.Database;
using CrowdFundingAPI.Models;
using CrowdFundingAPI.Models.Options;
using CrowdFundingAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Security.Claims;

namespace CrowdFundingAPI.Services
{
    public class ProjectServices : IProjectServices
    {
        private CrFrDbContext _db;
        private readonly IHttpContextAccessor httpContextAccessor;
        protected UserManager<MyUsers> _userManager { get; set; }

        public ProjectServices(CrFrDbContext db, IHttpContextAccessor _httpContextAccessor, UserManager<MyUsers> userManager)
        {
            _db = db;
            _userManager = userManager;
            httpContextAccessor = _httpContextAccessor;
        }

        //Create Project approach1
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

        //Create Project approach2
        public Project CreateProject2(ProjectOptions projectoption)
        {
            string userName = httpContextAccessor.HttpContext.User.Identity.Name;
            string userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

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
                UserId = userId,
                Creator = userName,
                ProjectTitle = projectoption.ProjectTitle,
                ProjectDescription = projectoption.ProjectDescription,
                ProjectTargetAmount = projectoption.ProjectTargetAmount,
                EndingDate = projectoption.EndingDate,
                ProjectCategory = projectoption.ProjectCategory,
                IsActive = true,

            };

            _db.Add(project);

            if (_db.SaveChanges() > 0)
            {
                return project;
            }

            return null;
        }

        //public async Task<ApiResult<Project>> CreateProject3(ProjectOptions projectoption)
        //{
        //    string userName = httpContextAccessor.HttpContext.User.Identity.Name;
        //    string userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    var project = new Project()
        //    {
        //        UserId = userId,
        //        Creator = userName,
        //        ProjectTitle = projectoption.ProjectTitle,
        //        ProjectDescription = projectoption.ProjectDescription,
        //        ProjectTargetAmount = projectoption.ProjectTargetAmount,
        //        EndingDate = projectoption.EndingDate,
        //        ProjectCategory = projectoption.ProjectCategory,
        //        IsActive = true,
        //    };
        //    _db.Add(project);
        //}


        ////List Projects
        //public List<Project> GetAllProjects()
        //{
        //    return _db.Projects.ToList();
        //}

        public IQueryable<Project> ListProjects(ProjectOptions options)
        {
            if (options == null)
            {
                return null;
            }

            var query = _db
                .Set<Project>()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(options.ProjectTitle))
            {
                query = query.Where(c => c.ProjectTitle == options.ProjectTitle);
            }

            if (!string.IsNullOrWhiteSpace(options.ProjectDescription))
            {
                query = query.Where(c => c.ProjectDescription == options.ProjectDescription);
            }


            query = query.Take(500);

            return query;
        }

        public IQueryable<Project> SearchProject(ProjectOptions options)
        {
            if (options == null)
            {
                return null;
            }

            var query = _db
                .Set<Project>()
                .AsQueryable();

                query = query.Where(c => c.ProjectId == options.ProjectId);
          
            query = query.Take(500);

            return query;
        }

        //new find way
        public Project FindProjectById(int id)
        {
            return _db.Set<Project>().Find(id);
        }
    }
}
