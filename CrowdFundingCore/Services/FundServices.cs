using CrowdFundingCore.Database;
using CrowdFundingCore.Models;
using CrowdFundingCore.Models.Options;
using CrowdFundingCore.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CrowdFundingCore.Services
{
    public class FundServices : IFundServices
    {
        private CrFrDbContext _db;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IProjectServices projectServices;

        public FundServices(CrFrDbContext db, IHttpContextAccessor _httpContextAccessor,
            IProjectServices _projectServices)
        {
            _db = db;
            httpContextAccessor = _httpContextAccessor;
            projectServices = _projectServices;
        }

        public Result<Fund> AddFund(FundOptions fundOptions)
        {
            if (fundOptions == null)
            {
                return Result<Fund>.CreateFailed(
                    StatusCode.BadRequest, "Null options");
            }

            string userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var project = projectServices.FindProjectById(fundOptions.ProjectId);
            Fund fund = new Fund
            {
                UserId = userId,
                Project = project,
                FundAmount = fundOptions.FundAmount
            };

            project.ProjectCurrentAmount += fund.FundAmount;
            project.ProjectProgress = project.ProjectCurrentAmount / project.ProjectTargetAmount;
            if (project.ProjectCurrentAmount >= project.ProjectTargetAmount)
            {
                project.IsComplete = true;
            }

            _db.Add(fund);
            _db.Update(project);

            var rows = 0;
            try
            {
                rows = _db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Result<Fund>.CreateFailed(
                    StatusCode.InternalServerError, ex.ToString());
            }

            if (rows <= 0)
            {
                return Result<Fund>.CreateFailed(
                    StatusCode.InternalServerError,
                    "Fund could not be updated");
            }

            return Result<Fund>.CreateSuccessful(fund);

        }


    }
}
