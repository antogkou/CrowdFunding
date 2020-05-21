using CrowdFundingMVC.Models;
using CrowdFundingMVC.Options;
using System.Linq;

namespace CrowdFundingMVC.Services
{
    public interface IProjectService
    {
        Project CreateProject(ProjectOptions projectoption);
        Project FindProjectById(int id);
        Project FindProjectByName(ProjectOptions projectoption);
       
    }

}
