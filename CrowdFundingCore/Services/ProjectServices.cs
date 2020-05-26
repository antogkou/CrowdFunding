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

        //Create Project
        public Project CreateProject(ProjectOptions projectoption, PledgeOptions pledgeOptions)
        {
            //User's Email=UserName
            string userName = httpContextAccessor.HttpContext.User.Identity.Name;
            //User's ID
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
                ProjectTargetAmountTostring = projectoption.ProjectTargetAmount.ToString("0.####"),

                ProjectPledges = new List<Pledge>
                {
                    new Pledge { PledgeTitle = "Level 1 Pledge" , PledgeDescription = "liga", PledgePrice = 5, PledgeReward = "iPhone SE" },
                     new Pledge { PledgeTitle = "Level 2 Pledge" , PledgeDescription = "metria", PledgePrice = 10, PledgeReward = "SamsungGalaxyS10e"  },
                      new Pledge { PledgeTitle = "Level 3 Pledge" , PledgeDescription = "polla", PledgePrice = 20, PledgeReward = "OnePlus8Pro"  },
                },

                //ProjectPledges = new List<Pledge>
                //{
                //    new Pledge {
                //    PledgeTitle = pledgeOptions.PledgeTitle,
                //    PledgeDescription = pledgeOptions.PledgeDescription,
                //    PledgePrice = pledgeOptions.PledgePrice,
                //    PledgeReward = pledgeOptions.PledgeReward
                //    }
                //},


                ProjectPosts = new List<Post>
                {
                    new Post { PostTitle = "Welcome to our Project!" , PostDescription = "You can help us by funding our project, or simply share it to your friends who might be intrested!"},
                },

            };

            _db.Add(project);

            if (_db.SaveChanges() > 0)
            {
                return project;
            }

            return null;
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

        //new find way
        public Project FindProjectById(int id)
        {
            return _db.Set<Project>().Find(id);
        }

        ////List Projects
        public List<Project> GetAllProjects()
        {
            return _db.Set<Project>().ToList();
        }

        ////List My Projects
        public List<Project> SearchProject()
        {
            return _db.Set<Project>().Select(s => new Project
            {
                UserId = s.UserId
            }).ToList();
        }

    }
}
