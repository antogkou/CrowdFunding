using CrowdFundingCore.Models;
using CrowdFundingCore.Models.Options;
using System.Collections.Generic;
using System.Linq;

namespace CrowdFundingCore.Services.Interfaces
{
    public interface IProjectServices
    {
        Project CreateProject(ProjectOptions projectoption, PledgeOptions pledgeOptions);
        IQueryable<Project> ListProjects(ProjectOptions options);
        IQueryable<Project> SearchProject2(ProjectOptions options);

        Project FindProjectById(int id);
        List<Project> SearchProject();
    }
}
