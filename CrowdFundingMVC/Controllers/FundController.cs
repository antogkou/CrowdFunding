using CrowdFundingCore.Database;
using CrowdFundingCore.Models.Options;
using CrowdFundingCore.Services.Interfaces;
using CrowdFundingMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrowdFundingMVC.Controllers
{
    [Authorize(Roles = "Administrator, Project Creator")]
    public class FundController : Controller
    {
        private IProjectServices _projectservices;
        private IFundServices _fundservices;
        private readonly CrFrDbContext _db;
        private readonly IHttpContextAccessor httpContextAccessor;

        public FundController(CrFrDbContext db, IFundServices fundservices, IProjectServices projectServices,
            IHttpContextAccessor _httpContextAccessor)
        {
            _db = db;
            _fundservices = fundservices;
            _projectservices = projectServices;
            httpContextAccessor = _httpContextAccessor;
        }

        //Add Fund
        [HttpPost]
        public IActionResult AddFund([FromBody] FundOptions fundOptions)
        {
            var result = _fundservices.AddFund(fundOptions);
            if (!result.Success)
            {
                return StatusCode((int)result.ErrorCode,
                    result.ErrorText);
            }
            return Json(result.Data);
        }
    }
}