using System;
using CrowdFundingCore.Database;
using CrowdFundingCore.Models;
using CrowdFundingCore.Models.Options;
using CrowdFundingCore.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace CrowdFundingCore.Services
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


        public Result<Project> CreateProject(ProjectOptions projectoption, PledgeOptions pledgeOptions)
        {
            if (projectoption == null)
            {
                return Result<Project>.CreateFailed(
                    StatusCode.BadRequest, "Null options");
            }

            if (pledgeOptions == null)
            {
                return Result<Project>.CreateFailed(
                    StatusCode.BadRequest, "Null options");
            }

            if (string.IsNullOrWhiteSpace(projectoption.ProjectTitle))
            {
                return Result<Project>.CreateFailed(
                    StatusCode.BadRequest, "Null or empty ProjectTitle");
            }

            //get username and userid from httpcontext
            string userName = httpContextAccessor.HttpContext.User.Identity.Name;
            string userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var project = new Project()
            {
                UserId = userId,
                ProjectCreator = userName,
                ProjectTitle = projectoption.ProjectTitle,
                ProjectDescription = projectoption.ProjectDescription,
                ProjectTargetAmount = projectoption.ProjectTargetAmount,
                ProjectEndingDate = projectoption.ProjectEndingDate,
                ProjectCategory = projectoption.ProjectCategory,
                IsActive = true,

                ProjectPledges = new List<Pledge>
                {
                    new Pledge
                    {
                        PledgeTitle = "Level 1 Pledge", PledgeDescription = "liga", PledgePrice = 5,
                        PledgeReward = "iPhone SE"
                    },
                    new Pledge
                    {
                        PledgeTitle = "Level 2 Pledge", PledgeDescription = "metria", PledgePrice = 10,
                        PledgeReward = "SamsungGalaxyS10e"
                    },
                    new Pledge
                    {
                        PledgeTitle = "Level 3 Pledge", PledgeDescription = "polla", PledgePrice = 20,
                        PledgeReward = "OnePlus8Pro"
                    },
                },

                ProjectPosts = new List<Post>
                {
                    new Post
                    {
                        PostTitle = "Welcome to our Project!",
                        PostDescription =
                            "You can help us by funding our project, or simply share it to your friends who might be intrested!"
                    },
                },
            };
            _db.Add(project);
            var rows = 0;
            try
            {
                rows = _db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Result<Project>.CreateFailed(
                    StatusCode.InternalServerError, ex.ToString());
            }

            if (rows <= 0)
            {
                return Result<Project>.CreateFailed(
                    StatusCode.InternalServerError,
                    "Project could not be updated");
            }

            return Result<Project>.CreateSuccessful(project);

        }

        //Pledges list by project id
        public List<Pledge> GetPledgesByProjectId(int projectId)
        {
            return _db.Set<Pledge>()
                .Where(p => p.Project.ProjectId == projectId)
                .ToList();
        }
        public Result<Pledge> CreatePledges(PledgeOptions pledgeOptions)
        {
            if (pledgeOptions == null)
            {
                return Result<Pledge>.CreateFailed(
                    StatusCode.BadRequest, "Null options");
            }

            if (string.IsNullOrWhiteSpace(pledgeOptions.PledgeTitle))
            {
                return Result<Pledge>.CreateFailed(
                    StatusCode.BadRequest, "Null or empty PledgeTitle");
            }


            var project = FindProjectById(pledgeOptions.ProjectId);
            var pledge = new Pledge
            {
                Project = project,
                PledgeTitle = pledgeOptions.PledgeTitle,
                PledgeDescription = pledgeOptions.PledgeDescription,
                PledgePrice = pledgeOptions.PledgePrice,
                PledgeReward = pledgeOptions.PledgeReward,
            };
            _db.Add(pledge);

            var rows = 0;
            try
            {
                rows = _db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Result<Pledge>.CreateFailed(
                    StatusCode.InternalServerError, ex.ToString());
            }

            if (rows <= 0)
            {
                return Result<Pledge>.CreateFailed(
                    StatusCode.InternalServerError,
                    "Pledge could not be updated");
            }

            return Result<Pledge>.CreateSuccessful(pledge);

        }

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

        public IQueryable<Project> SearchProject2(ProjectOptions options)
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

        //Find A Project By ID
        public Project FindProjectById(int id)
        {
            return _db.Set<Project>().Find(id);
        }

        ////List Current User's Created Projects
        public List<Project> SearchProject()
        {
            return _db.Set<Project>().Select(s => new Project
            {
                UserId = s.UserId
            }).ToList();
        }

        //Edit Project
        public Result<Project> UpdateProject(UpdateProjectOptions options)
        {
            if (options == null)
            {
                return Result<Project>.CreateFailed(
                    StatusCode.BadRequest, "Null options");
            }

            if (string.IsNullOrWhiteSpace(options.ProjectTitle))
            {
                return Result<Project>.CreateFailed(
                    StatusCode.BadRequest, "Null or empty ProjectTitle");
            }
            if (string.IsNullOrWhiteSpace(options.ProjectDescription))
            {
                return Result<Project>.CreateFailed(
                    StatusCode.BadRequest, "Null or empty ProjectDescription");
            }
            if (options.ProjectTargetAmount == 0)
            {
                return Result<Project>.CreateFailed(
                    StatusCode.BadRequest, "Null or empty ProjectTargetAmount");
            }
            if (string.IsNullOrWhiteSpace(options.ProjectCategory))
            {
                return Result<Project>.CreateFailed(
                    StatusCode.BadRequest, "Null or empty ProjectCategory");
            }


            var project = _db.Set<Project>().Find(options.ProjectId);

            if (options.ProjectTitle != null)
                project.ProjectTitle = options.ProjectTitle;
            if (options.ProjectDescription != null)
                project.ProjectDescription = options.ProjectDescription;
            if (project.ProjectCategory != null)
                project.ProjectCategory = options.ProjectCategory;
            if (project.ProjectTargetAmount != 0)
                project.ProjectTargetAmount = options.ProjectTargetAmount;
            //if (options.ProjectEndingDate != null)
                project.ProjectEndingDate = options.ProjectEndingDate;

                project.IsActive = options.IsActive;
                project.IsComplete = options.IsComplete;

            var rows = 0;
            try
            {
                rows = _db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Result<Project>.CreateFailed(
                    StatusCode.InternalServerError, ex.ToString());
            }

            if (rows <= 0)
            {
                return Result<Project>.CreateFailed(
                    StatusCode.InternalServerError,
                    "Project could not be updated");
            }

            return Result<Project>.CreateSuccessful(project);
        }
    }
}