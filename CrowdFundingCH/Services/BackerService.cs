using CrowdFundingMVC.Areas.Identity.Data;
using CrowdFundingMVC.Models;
using CrowdFundingMVC.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CrowdFundingMVC.Services
{
    public class BackerService : IBackerService
    {
        private IBackerService backMangr;
        private readonly CrowdFundingDBContext db;

        public BackerService(IBackerService _backMangr, CrowdFundingDBContext _db)
        {
            backMangr = _backMangr;
            db = _db;
        }

       
    }
}
