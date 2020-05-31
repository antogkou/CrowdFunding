using CrowdFundingCore.Database;
using CrowdFundingCore.Models;
using CrowdFundingCore.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingCore.Services
{
    public class MultimediaServices : IMultimediaServices
    {
        private CrFrDbContext _db;
        private readonly IHttpContextAccessor httpContextAccessor;
        private IProjectServices projectServices;

        public MultimediaServices(CrFrDbContext db, IHttpContextAccessor _httpContextAccessor, IProjectServices _projectServices)
        {
            _db = db;
            httpContextAccessor = _httpContextAccessor;
            projectServices = _projectServices;
        }

        //GetMultimediaOfProject(int projectId);



        public List<Multimedia> GetMultimediaOfProject(int projectId)
        {
            return _db.Set<Multimedia>()
                .Where(p => p.Project.ProjectId == projectId)
                .ToList();
        }
    }
}
