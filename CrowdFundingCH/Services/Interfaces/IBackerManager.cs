using CrowdFundingCH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingMVC.Services.Interfaces
{
    public interface IBackerManager
    {
        List<Project> GetAllProjects();
    }
}
