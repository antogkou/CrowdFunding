using CrowdFundingCH.Areas.Identity.Data;
using CrowdFundingCH.Models;
using CrowdFundingMVC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingMVC.Services
{
    public class BackerManagement : IBackerManager
    {
        private IBackerManager backMangr;
        private readonly CrowdFundingDBContext db;

        public BackerManagement(IBackerManager _backMangr, CrowdFundingDBContext _db)
        {
            backMangr = _backMangr;
            db = _db;
        }

        //List Projects
        public List<Project> GetAllProjects()
        {
            return db.Projects.ToList();
        }
    }
}
