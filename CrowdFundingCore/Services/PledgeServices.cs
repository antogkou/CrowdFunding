using CrowdFundingCore.Database;
using CrowdFundingCore.Models;
using CrowdFundingCore.Models.Options;
using CrowdFundingCore.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace CrowdFundingCore.Services
{
    public class PledgeServices : IPledgeServices
    {
        private readonly IProjectServices projectservices;
        private CrFrDbContext _db;
        private readonly IHttpContextAccessor httpContextAccessor;

        public PledgeServices(CrFrDbContext db, IProjectServices _projectservices,
            IHttpContextAccessor _httpContextAccessor)
        {
            _db = db;
            projectservices = _projectservices;
            httpContextAccessor = _httpContextAccessor;
        }

        //Get pledges by project id single project view
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


            var project = projectservices.FindProjectById(pledgeOptions.ProjectId);
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

        public Result<Pledge> UpdatePledge(PledgeOptions pledgeOptions)
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
            if (string.IsNullOrWhiteSpace(pledgeOptions.PledgeDescription))
            {
                return Result<Pledge>.CreateFailed(
                    StatusCode.BadRequest, "Null or empty PledgeDescription");
            }
            if (pledgeOptions.PledgePrice == 0)
            {
                return Result<Pledge>.CreateFailed(
                    StatusCode.BadRequest, "Null or empty PledgePrice");
            }
            if (string.IsNullOrWhiteSpace(pledgeOptions.PledgeReward))
            {
                return Result<Pledge>.CreateFailed(
                    StatusCode.BadRequest, "Null or empty PledgeReward");
            }
            

            var pledge = _db.Set<Pledge>().Find(pledgeOptions.PledgeId);


            pledge.PledgeTitle = pledgeOptions.PledgeTitle;
            pledge.PledgeDescription = pledgeOptions.PledgeDescription;
            pledge.PledgePrice = pledgeOptions.PledgePrice;
            pledge.PledgeReward = pledgeOptions.PledgeReward;

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


        //Buy a pledge from single project view
        public Result<BackedPledges> AddPledge(int pledgeId, int projectId)
        {

            if (pledgeId == 0)
            {
                return Result<BackedPledges>.CreateFailed(
                    StatusCode.BadRequest, "Null pledgeId");
            }

            if (projectId == 0)
            {
                return Result<BackedPledges>.CreateFailed(
                    StatusCode.BadRequest, "Null projectId");
            }

            var project = projectservices.FindProjectById(projectId);
            var pledge = _db
                .Set<Pledge>()
                .Where(i => i.PledgeId == pledgeId)
                .SingleOrDefault();
            string userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var backedPledge = new BackedPledges()
            {
                UserId = userId,
                PledgeId = pledgeId
            };

            project.ProjectCurrentAmount += pledge.PledgePrice;
            project.ProjectProgress = project.ProjectCurrentAmount / project.ProjectTargetAmount;
            if (project.ProjectCurrentAmount >= project.ProjectTargetAmount)
            {
                project.IsComplete = true;
            }

            _db.Add(backedPledge);
            _db.Update(project);


            var rows = 0;
            try
            {
                rows = _db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Result<BackedPledges>.CreateFailed(
                    StatusCode.InternalServerError, ex.ToString());
            }

            if (rows <= 0)
            {
                return Result<BackedPledges>.CreateFailed(
                    StatusCode.InternalServerError,
                    "Pledge could not be updated");
            }

            return Result<BackedPledges>.CreateSuccessful(backedPledge);

        }


        public Pledge FindPledgeById(int projectId, int pledgeId)
        {
            string userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = _db.Set<Pledge>()
                .Where(p => p.Project.ProjectId == projectId)
                .Where(p => p.PledgeId == pledgeId)
                .Where(p => p.Project.UserId == userId)
                .SingleOrDefault();
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public IQueryable<Pledge> ListPledges(PledgeOptions options)
        {
            if (options == null)
            {
                return null;
            }

            var query = _db
                .Set<Pledge>()
                .AsQueryable();

            query = query.Take(500);

            return query;
        }

        public bool DeletePledge(int pledgeId)
        {
            string userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Pledge pledge = _db.Set<Pledge>()
                .Include(p => p.Project)
                .Where(p => p.PledgeId == pledgeId)
                .Where(p => p.Project.UserId == userId)
                .SingleOrDefault();
            if (pledge != null)
            {
                _db.Set<Pledge>().Remove(pledge);
                _db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}