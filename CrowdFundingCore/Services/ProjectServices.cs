using System;
using CrowdFundingCore.Database;
using CrowdFundingCore.Models;
using CrowdFundingCore.Models.Options;
using CrowdFundingCore.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

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


        public Result<Project> CreateProject(ProjectOptions projectoption)
        {
            if (projectoption == null)
            {
                return Result<Project>.CreateFailed(
                    StatusCode.BadRequest, "Null options");
            }


            if (string.IsNullOrWhiteSpace(projectoption.ProjectTitle))
            {
                return Result<Project>.CreateFailed(
                    StatusCode.BadRequest, "Null or empty ProjectTitle");
            }

            if (projectoption.ProjectTargetAmount == 0)
            {
                return Result<Project>.CreateFailed(
                    StatusCode.BadRequest, "Null or empty ProjectTargetAmount");
            }


            //get username and userid from httpcontext
            string userName = httpContextAccessor.HttpContext.User.Identity.Name;
            userName = userName.Substring(0, userName.IndexOf('@'));
            string userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            //am i sure?
            //if (string.IsNullOrWhiteSpace(projectoption.MultimediaURL))
            //{
            //    return Result<Project>.CreateFailed(
            //        StatusCode.BadRequest, "Null or empty Multimedia URL");
            //}


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

                ProjectMultimedia = new List<Multimedia>
                {
                    new Multimedia
                    {
                        MultimediaTypes = projectoption.MultimediaTypes,
                        MultimediaURL = projectoption.FilePath
                    },
                },

                ProjectPosts = new List<Post>
                {
                    new Post
                    {
                        PostDescription =
                            "You can help us by funding our project, or simply share it to your friends who might be interested!"
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

            var project = FindProjectById(pledgeOptions.ProjectId);
            var pledge = new Pledge
            {
                Project = project,
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

        public IQueryable<Project> SearchProject(ProjectOptions options)
        {
            string userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (options == null)
            {
                return null;
            }



            var query = _db
                .Set<Project>()
                .Where(p => p.ProjectId == options.ProjectId)
                .Where(p => p.UserId == userId)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(options.ProjectTitle))
            {
                query = query.Where(c => c.ProjectTitle == options.ProjectTitle);
            }

            if (!string.IsNullOrWhiteSpace(options.ProjectDescription))
            {
                query = query.Where(c => c.ProjectDescription == options.ProjectDescription);
            }

            if (!string.IsNullOrWhiteSpace(options.ProjectCategory))
            {
                query = query.Where(c => c.ProjectCategory == options.ProjectCategory);
            }


            query = query.Take(500);

            return query;
        }

        //Find A Project By ID
        //public Project FindProjectById(int id)
        //{
        //    string userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        //    return _db.Set<Project>()
        //        .Find(id);
        //}

        public Result<Project> GetProjectById(int id)
        {
            var project = _db.Set<Project>()
                .Find(id);

            if (project == null)
            {
                return Result<Project>.CreateFailed(
                    StatusCode.NotFound, $"Project with {id} was not found");
            }

            return Result<Project>.CreateSuccessful(project);
        }

        public Project FindProjectById(int projectId)
        {
            string userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = _db.Set<Project>()
                .Where(p => p.ProjectId == projectId)
                .SingleOrDefault();

            if (result == null)
            {
                return null;
            }
            return result;
        }

        public Project FindMyProjectById(int projectId)
        {
            string userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = _db.Set<Project>()
                .Where(p => p.ProjectId == projectId)
                .Where(p => p.UserId == userId)
                .SingleOrDefault();

            if (result == null)
            {
                return null;
            }
            return result;
        }

        public IQueryable<Project> GetTrendingProjects()
        {
            var result = _db.Set<Project>()
                .Where(s => s.ProjectProgress > 0.35m)
                .Where(s => s.IsActive == true)
                .Where(s => s.IsComplete == false)
                .AsQueryable();

            if (result == null)
            {
                return null;
            }
            return result;
        }

        public IQueryable<Project> GetCompletedProjects()
        {
            var result = _db.Set<Project>()
                .Where(s => s.IsComplete)
                .AsQueryable();

            if (result == null)
            {
                return null;
            }
            return result;
        }

        public IQueryable<Project> GetMyBackedProjects()
        {
            string userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = _db.Set<BackedPledges>()
                .Where(p => p.UserId == userId)
                .Select(p => p.BackedPledge)
                .Select(p => p.Project)
                .AsQueryable();

            var projects = _db.Set<Fund>()
                .Where(p => p.UserId == userId)
                .Select(p => p.Project)
                .AsQueryable();

            var i3 = result.AsQueryable().Concat(projects.AsQueryable()).Distinct();

            if (i3 == null)
            {
                return i3;
            }

            return i3;
        }

        public IQueryable<Project> GetMyProjects()
        {
            string userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = _db.Set<Project>()
                .Where(p => p.UserId == userId)
                .ToList()
                .AsQueryable();

            if (result == null)
            {
                return null;
            }
            return result;
        }

        public IQueryable<Project> GetAllActiveProjects(string projectCategory, string searchString)
        {

            //var projects = from m in _db.Set<Project>()
            //             select m;

            var projects = _db.Set<Project>()
                .Where(p => p.IsActive == true)
                .Where(p => p.IsComplete == false)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                projects = projects.Where(s => s.ProjectTitle.Contains(searchString));
            }

            if (!string.IsNullOrWhiteSpace(projectCategory))
            {
                projects = projects.Where(x => x.ProjectCategory == projectCategory);
            }


            if (projects == null)
            {
                return null;
            }
            return projects;
        }


        //go to edit project
        public Result<Project> FindProjectById2(int projectId)
        {
            string userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = _db.Set<Project>()
                .Where(p => p.ProjectId == projectId)
                .Where(p => p.UserId == userId)
                .SingleOrDefault();

            if (result == null)
            {
                return Result<Project>.CreateFailed(
                    StatusCode.NotFound, $"Project with {projectId} was not found");
            }
            return Result<Project>.CreateSuccessful(result);
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

            project.ProjectProgress = project.ProjectCurrentAmount / project.ProjectTargetAmount;
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